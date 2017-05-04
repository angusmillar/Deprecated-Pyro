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
using Hl7.Fhir.Utility;
using Hl7.Fhir.Rest;
using Pyro.Common.BusinessEntities.Dto;


namespace Pyro.Web.Formatters
{
  public class FhirXmlMediaTypeFormatter : FhirMediaTypeFormatter
  {

    public FhirXmlMediaTypeFormatter()
      : base()
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


    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      try
      {
        var body = base.ReadBodyFromStream(readStream, content);
        if (string.IsNullOrWhiteSpace(body))
        {
          //return System.Threading.Tasks.Task.FromResult<object>(null);
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
              FhirXmlParser FhirXmlParser = new FhirXmlParser();
              Resource resource = FhirXmlParser.Parse<Resource>(body);
              return resource;
            }
            else
            {
              string Message = string.Format("FHIR resource type error, the resource does not appear to be a FHIR resource, type found was: " + type.Name);
              var oOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, Message);
              throw new DtoPyroException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, Message);
            }
          });
        }
      }
      catch (FormatException Exec)
      {
        string Message = string.Format("FHIR parser failed with the following error message: " + Exec.Message);
        var oOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Structure, Message);
        throw new DtoPyroException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, Message, Exec);
      }
    }

    //=============== Write ==================================================    
    public override bool CanWriteType(Type type)
    {
      return type == typeof(Hl7.Fhir.Model.Resource);
    }

    public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
      return System.Threading.Tasks.Task.Factory.StartNew(() =>
      {
        XmlWriter writer = new XmlTextWriter(writeStream, new System.Text.UTF8Encoding(false));
        if (type.IsAssignableFrom(typeof(Resource)))
        {
          Resource Resource = (Resource)value;

          var Summary = SummaryType.False;
          if (Resource is IAnnotated Annotated)
          {
            var SummaryTypeAnnotationList = Annotated.Annotations(typeof(SummaryType));
            if (SummaryTypeAnnotationList.FirstOrDefault() is SummaryType AnnotationSummary)
              Summary = AnnotationSummary;
          }
          FhirSerializer.SerializeResource(Resource, writer, Summary);
        }
        writer.Flush();
        return System.Threading.Tasks.Task.CompletedTask;
      });
    }

  }
}