using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using Hl7.Fhir.Rest;
using Blaze.Web.Extensions;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Web.Formatters
{
  public class FhirJsonMediaTypeFormatter : FhirMediaTypeFormatter
  {
    public FhirJsonMediaTypeFormatter()
      : base()
    {
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
    }

    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    {
      base.SetDefaultContentHeaders(type, headers, mediaType);
      //MediaTypeHeaderValue
      headers.ContentType = Blaze.Engine.Rest.ContentType.GetMediaTypeHeaderValue(type, Hl7.Fhir.Rest.ResourceFormat.Json);
    }

    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      return System.Threading.Tasks.Task.Factory.StartNew<object>(() =>
      {
        try
        {
          var body = base.ReadBodyFromStream(readStream, content);

          if (typeof(Resource).IsAssignableFrom(type))
          {
            Resource resource = FhirParser.ParseResourceFromJson(body);
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
            throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);                    
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
          throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text, Exec);                     
        }
      });
    }

    public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
      return System.Threading.Tasks.Task.Factory.StartNew(() =>
      {
        using (StreamWriter streamwriter = new StreamWriter(writeStream))
        {
          using (JsonWriter writer = new JsonTextWriter(streamwriter))
          {
            //Todo:
            //bool summary = requestMessage.RequestSummary();

            if (typeof(Resource).IsAssignableFrom(type))
            {
              Resource resource = (Resource)value;
              FhirSerializer.SerializeResource(resource, writer);
            }
          }
        }
      });
    }


  }
}