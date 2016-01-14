using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Blaze.Engine.CustomException;


namespace Blaze.Formatters
{
  public class FhirXmlMediaTypeFormatter: FhirMediaTypeFormatter
  {

    public FhirXmlMediaTypeFormatter()
      :base()
    {
      // Add the supported media type for Fhir XML i.e '"application/xml+fhir"
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
        SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
      
    }


    //=============== Read ==================================================
    public override bool CanReadType(Type type)
    {
      return type == typeof(Hl7.Fhir.Model.Resource);
    }

    
    public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      return Task.Factory.StartNew<object>(() =>
      {
        try
        {
          var body = base.ReadBodyFromStream(readStream, content);

          if (typeof(Resource).IsAssignableFrom(type))
          {
            Resource resource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(body);
            return resource;
          }
          else
          {
            var oIssueComponent = new OperationOutcome.IssueComponent();
            oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
            oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
            oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", type.Name));
            oIssueComponent.Details.Text = String.Format("FHIR resource type error, the resource does not appear to be a FHIR resource, type found was: " + type.Name);
            oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
            var oOperationOutcome = new OperationOutcome();
            oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
            throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);        
          }            
        }
        catch (FormatException Exec)
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Structure;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_CANT_PARSE_ROOT", String.Format("Unable to parse feed (root element name = '{0}')", "[Unknown]"));
          oIssueComponent.Details.Text = String.Format("FHIR parser failed with the following error message: " + Exec.Message);
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text, Exec);
        }
      });
    }

    //=============== Write ==================================================    
    public override bool CanWriteType(Type type)
    {
      return type == typeof(Hl7.Fhir.Model.Resource);
    }

    
    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
      return Task.Factory.StartNew(() =>
      {
        XmlWriter writer = new XmlTextWriter(writeStream, System.Text.Encoding.UTF8);
        if (type.IsAssignableFrom(typeof(Resource)))
        {
          Resource resource = (Resource)value;
          FhirSerializer.SerializeResource(resource, writer, false);
        }    
        writer.Flush();
      });
    }
  }
}