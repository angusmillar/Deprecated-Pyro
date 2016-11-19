using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Pyro.Common.Tools
{
  public static class HttpHeaderSupport
  {
    public static void AddResponseLocation(HttpResponseMessage Response, HttpRequestMessage Request, string FhirId)
    {
      string BaseURLPath = String.Format("{0}://{1}{2}", Request.RequestUri.Scheme, Request.RequestUri.Authority, Request.RequestUri.LocalPath);
      BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));
      Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, FhirId));
    }

    public static void AddVersionETag(HttpResponseMessage Response, string Version)
    {
      Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + Version + "\"");
    }

    public static void AddResponseLastModified(HttpResponseMessage Response, DateTimeOffset LastModified)
    {
      Response.Content.Headers.LastModified = LastModified;
    }



    public static bool IsAcceptMediaTypeSetInRequest(HttpRequestMessage Request)
    {
      if (Request.Headers.Accept.Count == 1)
      {
        foreach (var Accept in Request.Headers.Accept)
        {
          if (Accept.MediaType == "*/*")
          {
            return false;
          }
        }
      }
      return true;
    }

    public static string GetFhirMediaTypeString(string value)
    {
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
      {                
        if (value == System.Net.WebUtility.UrlDecode(mediaType))
        {
          return Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER;
        }
      }
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
      {
        if (value == System.Net.WebUtility.UrlDecode(mediaType))
        {
          return Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER;
        }
      }
      return string.Empty;
    }

  }
}
