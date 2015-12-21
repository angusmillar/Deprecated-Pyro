using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using Hl7.Fhir.Rest;
using Blaze.Extensions;
using Blaze.Engine.CustomException;

namespace Blaze.Formatters
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
      headers.ContentType = Blaze.Engine.Rest.ContentType.GetMediaTypeHeaderValue(type, ResourceFormat.Json);
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
            Resource resource = FhirParser.ParseResourceFromJson(body);
            return resource;
          }
          else
          {            
            throw new BlazeException(HttpStatusCode.BadRequest, String.Format("FHIR resource type error, the resource does not appear to be a FHIR resource, type found was: " + type.Name));                      
          }
        }
        catch (FormatException Exec)
        {
          throw new BlazeException(HttpStatusCode.BadRequest, String.Format("FHIR parser failed with the following error: " + Exec.Message), Exec);      
        }
      });
    }

    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {

      return Task.Factory.StartNew(() =>
      {
        using (StreamWriter streamwriter = new StreamWriter(writeStream))
        using (JsonWriter writer = new JsonTextWriter(streamwriter))
        {
          
          bool summary = requestMessage.RequestSummary();

          if (typeof(Resource).IsAssignableFrom(type))
          {
            Resource resource = (Resource)value;
            FhirSerializer.SerializeResource(resource, writer);
          }         
        }
      });
    }


  }
}