using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Pyro.Common.Tools
{
  public static class HttpHeaderSupport
  {
    public static void AddResponseLocation(HttpResponseHeaders HttpResponseHeaders, Uri RequestUri, string FhirId = null)
    {
      string BaseURLPath = String.Format("{0}://{1}{2}", RequestUri.Scheme, RequestUri.Authority, RequestUri.LocalPath);
      if (string.IsNullOrWhiteSpace(FhirId))
      {
        HttpResponseHeaders.Location = new Uri(BaseURLPath);
      }
      else
      {
        BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));
        HttpResponseHeaders.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, FhirId));
      }
    }

    public static void AddVersionETag(HttpResponseHeaders HttpResponseHeaders, string Version)
    {
      //example: ETag: W/"3141"      
      HttpResponseHeaders.ETag = new EntityTagHeaderValue('\"' + Version + '\"', true);
    }

    public static void AddResponseLastModified(HttpContentHeaders HttpContentHeaders, DateTimeOffset LastModified)
    {
      HttpContentHeaders.LastModified = LastModified;
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
