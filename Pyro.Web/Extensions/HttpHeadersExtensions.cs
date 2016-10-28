using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Hl7.Fhir.Rest;

namespace Pyro.Web.Extensions
{
  public static class HttpHeadersExtensions
  {
    public static string GetParameter(this HttpRequestMessage request, string key)
    {
      foreach (var param in request.GetQueryNameValuePairs())
      {
        if (param.Key == key) return param.Value;
      }
      return null;
    }

    public static List<Tuple<string, string>> TupledParameters(this HttpRequestMessage request)
    {
      var list = new List<Tuple<string, string>>();

      IEnumerable<KeyValuePair<string, string>> query = request.GetQueryNameValuePairs();
      foreach (var pair in query)
      {
        list.Add(new Tuple<string, string>(pair.Key, pair.Value));
      }
      return list;
    }

    public static SearchParams GetSearchParams(this HttpRequestMessage request)
    {
      var parameters = request.TupledParameters();
      UriParamList actualParameters = new UriParamList(parameters);
      var searchCommand = SearchParams.FromUriParamList(parameters);
      return searchCommand;
    }

  }
}