using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using System.ServiceModel.Dispatcher;
using Pyro.ADHA.VendorLibrary.Common;

namespace Pyro.ADHA.VendorLibrary.HI
{
  /// <summary>
  /// Utility class to add a custom behavior to a Medicare HI Service endpoint which will capture the soap
  /// requests and responses, and also sign the outgoing messages.
  /// </summary>
  public class HIEndpointProcessor
  {
    private const string UserNamespace = "http://ns.electronichealth.net.au/hi/xsd/common/CommonCoreElements/3.0";

    /// <summary>
    /// Specify the endpoint on which the signing and inspector behavior is to be applied.
    /// </summary>
    /// <param name="endpoint">The service endpoint to process.</param>
    /// <param name="messageID">A UniqueId instance which specifies the ID of the request message.</param>
    /// <param name="signingCertificate">The X509Certificate2 instance which will be used to sign the request message.</param>
    /// <param name="soapMessages">A SoapMessages instance which will contain the soap request and response messages on the endpoint.</param>
    public static void ProcessEndpoint(
        ServiceEndpoint endpoint,
        X509Certificate2 signingCertificate,
        SoapMessages soapMessages)
    {
      // Add a behavior to remove reply-to and set the message id, to, from ws-address details
      InspectorBehavior newBehavior = new InspectorBehavior(soapMessages, signingCertificate);

      // Add the behavior
      endpoint.Behaviors.Add(newBehavior);
    }

    /// <summary>
    /// Internal class to contain the soap request and response messages.
    /// </summary>
    public class SoapMessages
    {
      /// <summary>
      /// Soap request XML.
      /// </summary>
      public string SoapRequest { get; set; }

      /// <summary>
      /// Soap response XML.
      /// </summary>
      public string SoapResponse { get; set; }

      /// <summary>
      /// Soap request Message ID.
      /// </summary>
      public string SoapRequestMessageId { get; set; }

      /// <summary>
      /// Soap response Message ID. 
      /// </summary>
      public string SoapResponseMessageId { get; set; }
    }

    /// <summary>
    /// Implementation of a MessageInspector which populates a SoapMessages instance with the
    /// soap request and response messages. This also signs the request message with the signing certificate.
    /// </summary>
    internal class MessageInspector : IClientMessageInspector
    {
      SoapMessages soapMessages;
      X509Certificate2 signingCertificate;

      public MessageInspector(SoapMessages soapMessages, X509Certificate2 signingCertificate)
      {
        this.soapMessages = soapMessages;
        this.signingCertificate = signingCertificate;
      }

      public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
      {
        MessageBuffer msgBuffer = reply.CreateBufferedCopy(int.MaxValue);

        MemoryStream ms = new MemoryStream();
        msgBuffer.WriteMessage(ms);

        ms.Position = 0;

        StreamReader sr = new StreamReader(ms);
        string output = sr.ReadToEnd();
        sr.Close();

        soapMessages.SoapResponse = output;
        soapMessages.SoapResponseMessageId = GetMessageId(output);

        reply = msgBuffer.CreateMessage();

        msgBuffer.Close();

        //Below for debug, write Soap to static File
        //DirectoryInfo DirectoryInfo = new DirectoryInfo(@"C:\temp\HIServiceSOAP");
        //if (!DirectoryInfo.Exists)
        //{
        //  DirectoryInfo.Create();
        //}
        //FileInfo FileInfo = new FileInfo($"{DirectoryInfo.FullName}\\{DateTime.Now.ToString("yyyyMMddTHHmmss")}_ResponseSoap.xml");
        //File.WriteAllText(FileInfo.FullName, soapMessages.SoapRequest);

        // Comment this out as if error back from ESB - it doesn't get passed Validation
        // bool isValid = VerifyXML(soapMessages.SoapResponse);
        // soapMessages.IsSoapResponseSignatureValid = VerifyXML(soapMessages.SoapResponse);
      }

      internal string GetMessageId(string responseXml)
      {
        var responseDoc = new XmlDocument();
        responseDoc.LoadXml(responseXml);
        var nm = new XmlNamespaceManager(responseDoc.NameTable);
        nm.AddNamespace("a", "http://www.w3.org/2005/08/addressing");
        var messageIdNode = responseDoc.SelectSingleNode("//a:MessageID", nm);
        if (messageIdNode != null)
          return messageIdNode.InnerText;
        else
          return null;
      }

      public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
      {
        UniqueId messageId = new UniqueId();

        // Set message ID
        soapMessages.SoapRequestMessageId = messageId.ToString();

        // Modify MessageId and From headers
        request.Headers.MessageId = messageId;

        // Removed as MCA have a problem with it ! Dont need it anyway !
        request.Headers.From = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");

        // To: Gets changed to endpointURI value anyway so it won't do this
        request.Headers.To = new Uri("http://www.w3.org/2005/08/addressing/anonymous");

        // Might want to check here for medicare body elements to see if signing is needed
        string outboundXml = string.Empty;
        request = SignBodyAndAddressingHeaders(request, ref outboundXml);

        soapMessages.SoapRequest = outboundXml;

        //Below for debug, write to static file
        //DirectoryInfo DirectoryInfo = new DirectoryInfo(@"C:\temp\HIServiceSOAP");
        //if (!DirectoryInfo.Exists)
        //{
        //  DirectoryInfo.Create();
        //}
        //FileInfo FileInfo = new FileInfo($"{DirectoryInfo.FullName}\\{DateTime.Now.ToString("yyyyMMddTHHmmss")}_RequestSoap.xml");
        //File.WriteAllText(FileInfo.FullName, soapMessages.SoapRequest);

        return null;
      }

      internal Message SignBodyAndAddressingHeaders(Message requestMessage, ref string outboundXml)
      {
        XmlReader reader = XmlReader.Create(new StringReader(requestMessage.ToString()));
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(reader);
        XmlElement root = xdoc.DocumentElement;

        string soapNs = xdoc.DocumentElement.NamespaceURI;
        XmlNamespaceManager nm = new XmlNamespaceManager(reader.NameTable);
        nm.AddNamespace("s", soapNs);
        nm.AddNamespace("a", "http://www.w3.org/2005/08/addressing");
        nm.AddNamespace("h", UserNamespace);

        // Create references
        List<string> references = new List<string>();

        // Get the body element and assign ID
        XmlElement bodyElement = (XmlElement)root.SelectSingleNode("//s:Body", nm);
        string bodyId = "body-" + Guid.NewGuid().ToString();
        bodyElement.SetAttribute("xml:id", bodyId);
        references.Add(bodyId);

        // Get the user element and assign ID
        XmlElement userElement = (XmlElement)root.SelectSingleNode("//s:Header/h:user", nm);
        string userId = "user-" + Guid.NewGuid().ToString();
        userElement.SetAttribute("xml:id", userId);
        references.Add(userId);


        // Get the timestamp element and assign ID
        XmlElement productElement = (XmlElement)root.SelectSingleNode("//s:Header/h:timestamp", nm);
        string timestampId = "timestamp-" + Guid.NewGuid().ToString();
        productElement.SetAttribute("xml:id", timestampId);
        references.Add(timestampId);

        if (references.Count > 0)
        {
          // Create signature
          XmlElement signatureElement = Sign(root, signingCertificate, references);

          // Get the SOAP header element
          XmlElement headerSignatureElement = (XmlElement)root.SelectSingleNode("//s:Header/h:signature", nm);

          // Import and append the created signature
          XmlNode signatureNode = xdoc.ImportNode(signatureElement, true);
          headerSignatureElement.AppendChild(signatureNode);
        }

        

        // Get serialized text (Not necessary, just for the hell of it...)  
        Stream tempStream = new MemoryStream(Encoding.UTF8.GetBytes(root.OuterXml));
        StreamReader sr = new StreamReader(tempStream);
        outboundXml = sr.ReadToEnd();
        bool isValid = VerifyXML(outboundXml);

        Stream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(root.OuterXml));

        //Chnaged to UTF-8 which works fine but HI Service ca not accept Funny UTF-8 Charaters like 'é'
        //// Get serialized text (Not necessary, just for the hell of it...)  
        //Stream tempStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(root.OuterXml));
        //StreamReader sr = new StreamReader(tempStream);
        //outboundXml = sr.ReadToEnd();
        //bool isValid = VerifyXML(outboundXml);

        //Stream memoryStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(root.OuterXml));
        XmlDictionaryReader dictionaryReader = XmlDictionaryReader.CreateTextReader(memoryStream, new XmlDictionaryReaderQuotas());

        Message newMessage = Message.CreateMessage(dictionaryReader, int.MaxValue, requestMessage.Version);

        return newMessage;
      }

      internal XmlElement Sign(XmlElement element, X509Certificate2 signingCertificate, List<string> references)
      {
        XmlDocument xmlDoc = new XmlDocument();
        // xmlDoc.LoadXml(element.ToString(SaveOptions.DisableFormatting));

        xmlDoc.LoadXml(element.OuterXml);

        // Create the signature object
        NehtaSignedXml signedXml = new NehtaSignedXml(xmlDoc);
        signedXml.SigningKey = signingCertificate.PrivateKey;

        // Specify the canonicalization method
        signedXml.Signature.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;

        // Specify the signature method
        signedXml.Signature.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

        // Add all the signing references
        foreach (string signReferenceId in references)
        {
          Reference reference = new Reference();
          reference.Uri = "#" + signReferenceId;
          reference.DigestMethod = SignedXml.XmlDsigSHA1Url;

          // Add the transform
          XmlDsigExcC14NTransform transform = new XmlDsigExcC14NTransform();
          reference.AddTransform(transform);

          // Add the reference
          signedXml.AddReference(reference);
        }

        // Calculate the signature
        signedXml.ComputeSignature();

        // Add the key information to the signature 
        signedXml.KeyInfo = new KeyInfo();
        signedXml.KeyInfo.AddClause(new KeyInfoX509Data(signingCertificate));

        // Return the signature
        return signedXml.GetXml();
      }

      internal static bool VerifyXML(string xml)
      {
        XmlDocument env = new XmlDocument();
        env.PreserveWhitespace = true;
        env.LoadXml(xml);

        string soapNs = env.DocumentElement.NamespaceURI;
        XmlNamespaceManager xmlnm = new XmlNamespaceManager(env.NameTable);
        xmlnm.AddNamespace("s", soapNs);
        xmlnm.AddNamespace("def", "http://www.w3.org/2000/09/xmldsig#");
        xmlnm.AddNamespace("h", UserNamespace);

        XmlElement ele = (XmlElement)env.SelectSingleNode("/s:Envelope/s:Header/h:signature/def:Signature", xmlnm);

        if (ele == null) return false;

        NehtaSignedXml signedXml = new NehtaSignedXml(env);
        signedXml.LoadXml(ele);
        bool answer = signedXml.CheckSignature();
        return answer;
      }
    }

    /// <summary>
    /// Implementation of a behavior that instantiates a MessageInspector.
    /// </summary>
    class InspectorBehavior : IEndpointBehavior
    {
      SoapMessages soapMessages;
      X509Certificate2 signingCertificate;

      public InspectorBehavior(SoapMessages soapMessages, X509Certificate2 signingCertificate)
      {
        this.soapMessages = soapMessages;
        this.signingCertificate = signingCertificate;
      }

      public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
      {
      }

      public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
      {
        clientRuntime.MessageInspectors.Add(new MessageInspector(soapMessages, signingCertificate));
      }

      public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
      {
      }

      public void Validate(ServiceEndpoint endpoint)
      {
      }
    }
  }
}
