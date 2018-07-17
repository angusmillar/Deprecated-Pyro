/*
 * Copyright 2011 NEHTA
 *
 * Licensed under the NEHTA Open Source (Apache) License; you may not use this
 * file except in compliance with the License. A copy of the License is in the
 * 'license.txt' file, which should be provided with this work.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Security.Cryptography.X509Certificates;
using Pyro.ADHA.mcaR3.ConsumerSearchIHI;
using Pyro.ADHA.VendorLibrary.Common;
using Pyro.ADHA.VendorLibrary.HI;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Pyro.ADHA.Api
{
  /// <summary>
  /// Requirements:
  /// a) Certificate from Medicare Australia with the Key Usage of "Digital Signature", for the purpose
  ///    of signing soap request messages, and establishing TLS connections to the HI Service.
  /// b) The TLS Web Service endpoint URL for the HI service.
  /// c) Details for the client product information (PCIN) - These include a QualifiedId for the product, 
  ///    the product name and version, and the product platform. These are provided by Medicare.
  /// d) User identifier details.
  /// </summary>
  public class HiServiceApi : IHiServiceApi
  {
    //private readonly string HiServiceTestEndpoint = "https://www5.medicareaustralia.gov.au/cert/soap/services/";
    //private readonly string HiServiceProdEndpoint = "https://www3.medicareaustralia.gov.au/pcert/soap/services/";
    private readonly string IhiNamespace = "http://ns.electronichealth.net.au/id/hi/ihi/1.0/";
    bool RequestHasMedicareNumber = false;
    bool RequestHasDvaNumber = false;
    bool RequestHasIHINumber = false;
    int ConfigHash = 0;

    private readonly IIhiSearchValidateConfig IhiSearchValidateConfig;
    IhiSearchValidateOutcome IhiSearchValidateOutcome;
    public HiServiceApi(IIhiSearchValidateConfig Item)
    {
      IhiSearchValidateConfig = Item;
    }

    public IIhiSearchValidateOutcome SearchOrValidateIhi(IIhiRequestData IhiRequestData)
    {
      IhiSearchValidateOutcome = new IhiSearchValidateOutcome(IhiRequestData);

      //Hash the config so that we don't validate it is unchanged.
      int ConfigHashTemp = IhiSearchValidateConfig.GetHashCode();
      if (ConfigHashTemp != ConfigHash)
      {
        if (!IsConfigrationDataValid())
        {
          return IhiSearchValidateOutcome;
        }
        else
        {
          ConfigHash = ConfigHashTemp;
        }
      }
      
      if (!IsRequestDataValid())
        return IhiSearchValidateOutcome;

      IhiSeachOrValidateQuery();
      return IhiSearchValidateOutcome;
    }

    private void IhiSeachOrValidateQuery()
    {
      // ------------------------------------------------------------------------------
      // Set up
      // ------------------------------------------------------------------------------

      // Set up the request
      searchIHI request = new searchIHI();
      
      SetRequestDataForQuery(IhiSearchValidateOutcome, request);

      // Obtain the certificate by serial number
      string CertSerial = RemoveWhitespace(IhiSearchValidateConfig.CertificateSerialNumber);
      X509Certificate2 tlsCert = GetCertificate(
          IhiSearchValidateConfig.CertificateSerialNumber, //The serial number is commonly seen with spaces "06 3c 23' yet we don't want then in this call.
          X509FindType.FindBySerialNumber,
          StoreName.My,
          StoreLocation.LocalMachine,
          true
          );

      //Test that we found a certificate, there will be a error message write for return if it was not found
      if (tlsCert != null)
      {
        // The same certificate is used for signing the request.
        // This certificate will be different to TLS cert for some operations.
        X509Certificate2 signingCert = tlsCert;

        // Set up client product information (PCIN)
        // Values below should be provided by Medicare
        Pyro.ADHA.mcaR3.ConsumerSearchIHI.ProductType product = new Pyro.ADHA.mcaR3.ConsumerSearchIHI.ProductType()
        {
          platform = System.Environment.OSVersion.ToString(),      // Can be any value
          productName = IhiSearchValidateConfig.ProductName,       // Provided by Medicare
          productVersion = IhiSearchValidateConfig.ProductVersion, // Provided by Medicare
          vendor = new Pyro.ADHA.mcaR3.ConsumerSearchIHI.QualifiedId()
          {
            id = IhiSearchValidateConfig.VendorId,       // Provided by Medicare               
            qualifier = IhiSearchValidateConfig.VendorIdQualifier// Provided by Medicare
          }
        };


        // Set up user identifier details
        Pyro.ADHA.mcaR3.ConsumerSearchIHI.QualifiedId user = new Pyro.ADHA.mcaR3.ConsumerSearchIHI.QualifiedId()
        {
          id = IhiSearchValidateOutcome.RequestData.UserId,                                                     // User ID internal to your system
          qualifier = IhiSearchValidateOutcome.RequestData.UserIdQualifier    // Eg: http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0
        };

        // Set up user HPI-O identifier
        //The HPI-O is optional and only required if you are setup and using a CSP certificate, in this case you must pass the HPI-O
        //of the orginisation you are making the call for.
        Pyro.ADHA.mcaR3.ConsumerSearchIHI.QualifiedId hpio = new Pyro.ADHA.mcaR3.ConsumerSearchIHI.QualifiedId()
        {
          id = "8003621313528997",                                              // HPIO internal to your system
          qualifier = "http://ns.electronichealth.net.au/id/hi/hpio/1.0"    // Eg: http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0
        };

        // ------------------------------------------------------------------------------
        // Client instantiation and invocation
        // ------------------------------------------------------------------------------

        // Instantiate the client
        ConsumerSearchIHIClient client = new ConsumerSearchIHIClient(
            new Uri(IhiSearchValidateConfig.HiServiceEndpoint),
            product,
            user,
            null,
            signingCert,
            tlsCert);

        searchIHIResponse ihiResponse = null;
        try
        {
          // Invokes the query based on type                  
          if (RequestHasIHINumber || (RequestHasDvaNumber && RequestHasMedicareNumber))
          {
            ihiResponse = client.BasicSearch(request);
          }

          if (RequestHasMedicareNumber)
          {
            ihiResponse = client.BasicMedicareSearch(request);
          }

          if (RequestHasDvaNumber)
          {
            ihiResponse = client.BasicDvaSearch(request);
          }

          SetResponseDataToReturnData(IhiSearchValidateOutcome, ihiResponse);
          SetSoapRequestAndResponseData(IhiSearchValidateOutcome, client, ihiResponse);
          IhiSearchValidateOutcome.SuccessfulQuery = true;
        }
        catch (FaultException fex)
        {
          IhiSearchValidateOutcome.SuccessfulQuery = false;

          MessageFault fault = fex.CreateMessageFault();
          if (fault.HasDetail)
          {
            Pyro.ADHA.mcaR3.ConsumerSearchIHI.ServiceMessagesType error = fault.GetDetail<Pyro.ADHA.mcaR3.ConsumerSearchIHI.ServiceMessagesType>();
            // Look at error details in here
            if (error.serviceMessage.Length > 0)
            {
              string returnMessage = error.serviceMessage[0].code + ": " + error.serviceMessage[0].reason;
              IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = returnMessage;
            }
          }

        }
        catch (Exception Exec)
        {
          IhiSearchValidateOutcome.SuccessfulQuery = false;
          // If an error is encountered, client.LastSoapResponse often provides a more
          // detailed description of the error.
          IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = Exec.Message;
          SetSoapRequestAndResponseData(IhiSearchValidateOutcome, client, ihiResponse);
        }
        finally
        {
          // Clean up
          client.Dispose();
        }
      }
    }

    private void SetRequestDataForQuery(IhiSearchValidateOutcome IhiSearchValidateOutcome, searchIHI request)
    {
      RequestHasMedicareNumber = false;
      RequestHasDvaNumber = false;
      RequestHasIHINumber = false;

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.Given))
      {
        request.givenName = IhiSearchValidateOutcome.RequestData.Given;
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.Family))
      {
        request.familyName = IhiSearchValidateOutcome.RequestData.Family;
      }

      if (IhiSearchValidateOutcome.RequestData.Dob.HasValue)
      {
        request.dateOfBirth = IhiSearchValidateOutcome.RequestData.Dob.Value;
      }

      if (Char.IsLetter(IhiSearchValidateOutcome.RequestData.SexChar))
      {
        request.sex = GetSexTypeByChar(IhiSearchValidateOutcome.RequestData.SexChar);
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber))
      {
        request.medicareCardNumber = RemoveWhitespace(IhiSearchValidateOutcome.RequestData.MedicareNumber);
        RequestHasMedicareNumber = true;
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareIRN))
      {
        request.medicareIRN = IhiSearchValidateOutcome.RequestData.MedicareIRN;
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.DVANumber))
      {
        request.dvaFileNumber = RemoveWhitespace(IhiSearchValidateOutcome.RequestData.DVANumber);
        RequestHasDvaNumber = true;
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber))
      {
        request.ihiNumber = IhiNamespace + RemoveWhitespace(IhiSearchValidateOutcome.RequestData.IHINumber);
        RequestHasIHINumber = true;
      }
    }

    private void SetResponseDataToReturnData(IhiSearchValidateOutcome IhiSearchValidateOutcome, searchIHIResponse ihiResponse)
    {
      if (ihiResponse.searchIHIResult != null)
      {
        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.familyName))
          IhiSearchValidateOutcome.ResponseData.Family = ihiResponse.searchIHIResult.familyName;

        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.givenName))
          IhiSearchValidateOutcome.ResponseData.Given = ihiResponse.searchIHIResult.givenName;

        if (ihiResponse.searchIHIResult.dateOfBirth != null)
          IhiSearchValidateOutcome.ResponseData.Dob = ihiResponse.searchIHIResult.dateOfBirth;

        IhiSearchValidateOutcome.ResponseData.SexChar = GetSexCharBySexType(ihiResponse.searchIHIResult.sex);

        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.ihiNumber))
        {
          if (ihiResponse.searchIHIResult.ihiNumber.StartsWith(IhiNamespace) && ihiResponse.searchIHIResult.ihiNumber.Length == (IhiNamespace.Length + 16))
          {
            //Strip off the namespace and only return the 16 digit IHI number
            string IHIValue = ihiResponse.searchIHIResult.ihiNumber;
            IhiSearchValidateOutcome.ResponseData.IHINumber = IHIValue.Substring(IHIValue.Length - 16, 16);
          }
          else
          {
            //For some reason the retuned value does not conform to the namespave and 16 digit IHI default, so just return what we got.
            IhiSearchValidateOutcome.ResponseData.IHINumber = ihiResponse.searchIHIResult.ihiNumber;
          }
        }

        if (ihiResponse.searchIHIResult.ihiRecordStatusSpecified)
        {
          IhiSearchValidateOutcome.ResponseData.IHIRecordStatus = ihiResponse.searchIHIResult.ihiRecordStatus.ToString();
        }

        if (ihiResponse.searchIHIResult.ihiStatusSpecified)
        {
          IhiSearchValidateOutcome.ResponseData.IHIStatus = ihiResponse.searchIHIResult.ihiStatus.ToString();
        }

        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.medicareCardNumber))
        {
          IhiSearchValidateOutcome.ResponseData.MedicareNumber = ihiResponse.searchIHIResult.medicareCardNumber;
        }

        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.medicareIRN))
        {
          IhiSearchValidateOutcome.ResponseData.MedicareIRN = ihiResponse.searchIHIResult.medicareIRN;
        }

        if (!String.IsNullOrWhiteSpace(ihiResponse.searchIHIResult.dvaFileNumber))
        {
          IhiSearchValidateOutcome.ResponseData.DVANumber = ihiResponse.searchIHIResult.dvaFileNumber;
        }

      }
    }

    private void SetSoapRequestAndResponseData(IhiSearchValidateOutcome IhiSearchValidateOutcome, ConsumerSearchIHIClient client, searchIHIResponse ihiResponse)
    {
      if (ihiResponse != null && ihiResponse.searchIHIResult != null && ihiResponse.searchIHIResult.serviceMessages != null)
      {
        ServiceMessagesType ServiceMessage = ihiResponse.searchIHIResult.serviceMessages;        
        foreach (var Msg in ServiceMessage.serviceMessage)
        {
          HiServiceMessage HiServiceMessage = new HiServiceMessage();
          if (!String.IsNullOrWhiteSpace(Msg.code))
            HiServiceMessage.Code = Msg.code;
          if (!String.IsNullOrWhiteSpace(Msg.reason))
            HiServiceMessage.Reason = Msg.reason;          
            HiServiceMessage.SeverityType = GetSeverityTypeString(Msg.severity);
          IhiSearchValidateOutcome.QueryMetadata.ServiceMessage.Add(HiServiceMessage);
        }        
      }

      if (client.SoapMessages != null)
      {
        if (!String.IsNullOrWhiteSpace(client.SoapMessages.SoapRequestMessageId))
          IhiSearchValidateOutcome.QueryMetadata.SoapRequestMessageId = client.SoapMessages.SoapRequestMessageId;

        if (!String.IsNullOrWhiteSpace(client.SoapMessages.SoapResponseMessageId))
          IhiSearchValidateOutcome.QueryMetadata.SoapResponseMessageId = client.SoapMessages.SoapResponseMessageId;
        
        if (IhiSearchValidateOutcome.RequestData.ReturnSoapRequestAndResponseData)
        {
          if (!String.IsNullOrWhiteSpace(client.SoapMessages.SoapRequest))
            IhiSearchValidateOutcome.QueryMetadata.SoapRequest = client.SoapMessages.SoapRequest;

          if (!String.IsNullOrWhiteSpace(client.SoapMessages.SoapResponse))
            IhiSearchValidateOutcome.QueryMetadata.SoapResponse = client.SoapMessages.SoapResponse;
        }
      }
    }

    private X509Certificate2 GetCertificate(String findValue,
          X509FindType findType, StoreName storeName,
          StoreLocation storeLocation, bool valid)
    {
      X509Store certStore = new X509Store(storeName, storeLocation);
      certStore.Open(OpenFlags.ReadOnly);

      X509Certificate2Collection foundCerts =
        certStore.Certificates.Find(findType, findValue, valid);
      certStore.Close();

      // Check if any certificates were found with the criteria
      if (foundCerts.Count == 0)
      {
        //Look to see if the certificate is there but expired.
        foundCerts = certStore.Certificates.Find(findType, findValue, false);
        certStore.Close();
        if (foundCerts.Count == 1)
        {
          if (foundCerts[0].NotBefore != null && foundCerts[0].NotAfter != null)
          {
            var From = foundCerts[0].NotBefore.ToString("yyyy-MM-ddTHH:mm");
            var To = foundCerts[0].NotAfter.ToString("yyyy-MM-ddTHH:mm");
            IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = $"A single certificate could be found in the store named '{storeName.ToString()}' and the store location of '{storeLocation.ToString()}' for the account in use by the IIS Application pool with the serial {findValue}. Yet, this certificate is expiried with the date range From: {From}, To: {To}. Review the systems certificates as they seem to be expired.";
            return null;
          }
        }
        if (foundCerts.Count > 1)
        {
          IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = $"More than one certificate could be found in the store named '{storeName.ToString()}' and the store location of '{storeLocation.ToString()}' for the account in use by the IIS Application pool with the serial {findValue}. Yet, all appear to be expiried. Review the systems certificates as they seem to be expired.";
          return null;
        }

        IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = $"The certificate could not be found in the store named '{storeName.ToString()}' and the store location of '{storeLocation.ToString()}' for the account in use by the IIS Application pool with the serial {findValue}.";
        return null;
      }

      // Check if more than one certificate was found with the criteria
      if (foundCerts.Count > 1)
      {
        IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = $"More than one certificate found in the store named '{storeName.ToString()}' and the store location of '{storeLocation.ToString()}' for the account in use by the IIS Application pool with the serial {findValue}.";
        return null;
      }
        
      return foundCerts[0];
    }

    private bool IsRequestDataValid()
    {
      StringBuilder sb = new StringBuilder();
      bool isValid = true;

      if (String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.UserId))
      {
        sb.Append("Configuration error: No UserId supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.UserIdQualifier))
      {
        sb.Append("Configuration error: No UserIdQualifier supplied. ");
        isValid = false;
      }

      if (!IhiSearchValidateOutcome.RequestData.Dob.HasValue)
      {
        isValid = false;
        sb.Append("No Dob (Date of Birth) supplied. Dob is mandatory.");
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.DVANumber) &&
        String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber) &&
        String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber))
      {
        isValid = false;
        sb.Append("No identifier supplied. Must have at least one of the folowing identifiers: (MedicareNumber, DVANumber or IHINumber).");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.DVANumber) &&
          !String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber) &&
          !String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber))
      {
        isValid = false;
        sb.Append("A MedicareNumber, DVANumber and IHINumber supplied in the same request. Must only have a single identifier per call: (MedicareNumber, DVANumber or IHINumber).");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.DVANumber) &&
          !String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber))
      {
        isValid = false;
        sb.Append("A MedicareNumber and DVANumber supplied in the same request. Must only have a single identifier per call: (MedicareNumber, DVANumber or IHINumber).");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber) &&
          !String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber))
      {
        isValid = false;
        sb.Append("A MedicareNumber and IHINumber supplied in the same request. Must only have a single identifier per call: (MedicareNumber, DVANumber or IHINumber).");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber) &&
    !String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.DVANumber))
      {
        isValid = false;
        sb.Append("A DVANumber and IHINumber supplied in the same request. Must only have a single identifier per call: (MedicareNumber, DVANumber or IHINumber).");
      }


      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber) && RemoveWhitespace(IhiSearchValidateOutcome.RequestData.IHINumber).Length != 16)
      {
        isValid = false;
        sb.Append($"The IHI Number given is not 16 charaters long, all IHIs have a length of 16, valid given was {IhiSearchValidateOutcome.RequestData.IHINumber}.");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.IHINumber) && !RemoveWhitespace(IhiSearchValidateOutcome.RequestData.IHINumber).StartsWith("800360"))
      {
        isValid = false;
        sb.Append($"The IHI Number given is does not start with '800360', all IHIs start with '800360', valid given was {IhiSearchValidateOutcome.RequestData.IHINumber}.");
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.Family))
      {
        isValid = false;
        sb.Append("No Family name supplied. Family name is mandatory.");
      }

      if (!String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareIRN) &&
        String.IsNullOrWhiteSpace(IhiSearchValidateOutcome.RequestData.MedicareNumber))
      {
        isValid = false;
        sb.Append("A Medicare IRN was supplied yet no Medicare Number was supplied. If supplying a Medicare IRN then you must supply a Medicare Number");
      }

      if (!Char.IsLetter(IhiSearchValidateOutcome.RequestData.SexChar))
      {
        isValid = false;
        sb.Append("No Sex Character or Character was not a letter. SexChar must be supplied and must be one of (M,F,I,N).");
      }

      switch (Char.ToUpper(IhiSearchValidateOutcome.RequestData.SexChar))
      {
        case 'M':
          break;
        case 'F':
          break;
        case 'I':
          break;
        case 'N':
          break;
        default:
          {
            isValid = false;
            sb.Append("SexChar must be supplied and must be one of (M,F,I,N).");
            break;
          }
      }



      if (!isValid)
        IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = sb.ToString();

      return isValid;
    }

    private bool IsConfigrationDataValid()
    {
      StringBuilder sb = new StringBuilder();
      bool isValid = true;

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.CertificateSerialNumber))
      {
        sb.Append("Configuration error: No CertificateSerialNumber supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.HiServiceEndpoint))
      {
        sb.Append("Configuration error: No HiServiceEndpoint supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.ProductName))
      {
        sb.Append("Configuration error: No ProductName supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.ProductVersion))
      {
        sb.Append("Configuration error: No ProductVersion supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.VendorId))
      {
        sb.Append("Configuration error: No VendorId supplied. ");
        isValid = false;
      }

      if (String.IsNullOrWhiteSpace(IhiSearchValidateConfig.VendorIdQualifier))
      {
        sb.Append("Configuration error: No VendorIdQualifier supplied. ");
        isValid = false;
      }
      if (!isValid)
        IhiSearchValidateOutcome.QueryMetadata.ErrorMessge = sb.ToString();

      return isValid;
    }
    private SexType GetSexTypeByChar(char SexChar)
    {
      switch (Char.ToUpper(SexChar))
      {
        case 'M':
          return SexType.M;
        case 'F':
          return SexType.F;
        case 'I':
          return SexType.I;
        case 'N':
          return SexType.N;
        default:
          throw new FormatException($"SexChar unknown: {SexChar}, only allow the following sex chars [M:Male, F: Female, I:Indeterminate , N:Not stated/inadequately described]");
      }
    }
    private char GetSexCharBySexType(SexType SexType)
    {
      switch (SexType)
      {
        case SexType.F:
          return 'F';
        case SexType.I:
          return 'I';
        case SexType.M:
          return 'M';
        case SexType.N:
          return 'N';
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException($"Internal error: Unkown SexType retuned by HI Service of : {SexType.ToString()}");
      }
    }

    private string GetSeverityTypeString(SeverityType SeverityType)
    {
      switch (SeverityType)
      {
        case SeverityType.Fatal:
          return "Fatal";
        case SeverityType.Error:
          return "Error";
        case SeverityType.Warning:
          return "Warning";
        case SeverityType.Informational:
          return "Informational";          
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SeverityType.ToString(), (int)SeverityType, typeof(SeverityType));
      }
    }
      
    private string RemoveWhitespace(string input)
    {
      return new string(input.ToCharArray()
          .Where(c => !Char.IsWhiteSpace(c))
          .ToArray());
    }
  }


}
