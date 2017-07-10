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
using Pyro.Web.Extensions;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Utility;
using System.Linq;

namespace Pyro.Web.Formatters
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
      headers.ContentType = Pyro.Engine.Rest.ContentType.GetMediaTypeHeaderValue(type, Hl7.Fhir.Rest.ResourceFormat.Json);
    }

    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      try
      {
        var body = base.ReadBodyFromStream(readStream, content);
        if (string.IsNullOrWhiteSpace(body))
        {
          string Message = string.Format("The server was expecting a FHIR resource in the request body and found the body empty.");
          var oOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, Message);
          throw new DtoPyroException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, Message);
        }
        else
        {
          return System.Threading.Tasks.Task.Factory.StartNew<object>(() =>
          {
            if (typeof(Resource).IsAssignableFrom(type))
            {
              return Common.Tools.FhirResourceSerializationSupport.DeSerializeFromJson(body);
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
              throw new DtoPyroException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
            }
          });
        }
      }
      catch (FormatException Exec)
      {
        string Message = String.Format("FHIR parser failed with the following error message: " + Exec.Message);
        var oOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, Message);
        throw new DtoPyroException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, Message);
      }
    }

    public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
      StreamWriter writer = new StreamWriter(writeStream);
      JsonWriter jsonwriter = SerializationUtil.CreateJsonTextWriter(writer); // This will use the BetterJsonWriter which handles precision correctly
      if (typeof(Resource).IsAssignableFrom(type))
      {
        if (value != null)
        {
          Resource Resource = value as Resource;

          var Summary = SummaryType.False;
          if (Resource is IAnnotated Annotated)
          {
            var SummaryTypeAnnotationList = Annotated.Annotations(typeof(SummaryType));
            if (SummaryTypeAnnotationList.FirstOrDefault() is SummaryType AnnotationSummary)
              Summary = AnnotationSummary;
          }

          FhirSerializer.SerializeResource(Resource, jsonwriter, Summary);
        }
      }
      writer.Flush();
      return System.Threading.Tasks.Task.CompletedTask;
    }


  }
}