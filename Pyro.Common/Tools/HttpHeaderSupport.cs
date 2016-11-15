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
    public static void AddLocation(HttpResponseMessage Response, HttpRequestMessage Request, string FhirId)
    {
      string BaseURLPath = String.Format("{0}://{1}{2}", Request.RequestUri.Scheme, Request.RequestUri.Authority, Request.RequestUri.LocalPath);
      BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));
      Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, FhirId));
    }

    public static void AddVersionETag(HttpResponseMessage Response, string Version)
    {
      Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + Version + "\"");
    }

    public static void AddLastModified(HttpResponseMessage Response, DateTimeOffset LastModified)
    {
      Response.Content.Headers.LastModified = LastModified;
    }
  }
}
