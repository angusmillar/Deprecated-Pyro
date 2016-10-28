using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Pyro.Engine.Rest
{

  //This class provides functionality that was not available in Hl7.Fhir.Rest.ContentType
  //also note that some of these methods where in Spark.Engine.Core.FhirMediaType yet there 
  //was also a comment in this file saying 'API: This class can be merged into HL7.Fhir.Rest.ContentType'
  //This is what I have done here. When a new Fhir api is released this class may be able to be removed
  

  public static class ContentType 
  {

    public const string XmlResource = "application/xml+fhir";    
    public const string JsonResource = "application/json+fhir";

    public static string GetContentType(Type type, Hl7.Fhir.Rest.ResourceFormat format)
    {
      if (typeof(Hl7.Fhir.Model.Resource).IsAssignableFrom(type) || type == typeof(Hl7.Fhir.Model.Resource))
      {
        switch (format)
        {
          case Hl7.Fhir.Rest.ResourceFormat.Json: return JsonResource;
          case Hl7.Fhir.Rest.ResourceFormat.Xml: return XmlResource;
          default: return XmlResource;
        }
      }
      else
        return "application/octet-stream";
    }

    public static MediaTypeHeaderValue GetMediaTypeHeaderValue(Type type, Hl7.Fhir.Rest.ResourceFormat format)
    {
      string mediatype = ContentType.GetContentType(type, format);
      MediaTypeHeaderValue header = new MediaTypeHeaderValue(mediatype);
      header.CharSet = Encoding.UTF8.WebName;
      return header;
    }
  }
}
