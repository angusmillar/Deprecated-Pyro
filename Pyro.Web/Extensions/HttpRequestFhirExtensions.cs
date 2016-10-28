using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace Blaze.Web.Extensions
{
  public static class HttpRequestFhirExtensions
  {
    public static bool RequestSummary(this HttpRequestMessage request)
    {
      return (request.GetParameter("_summary") == "true");
    }
  }
}