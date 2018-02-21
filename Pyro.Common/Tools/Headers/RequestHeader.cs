using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Tools.Headers;

namespace Pyro.Common.Tools.Headers
{
  public class RequestHeader : IRequestHeader
  {
    private const string _IfNoneExistHeader = "If-None-Exist";
    private const string _IfModifiedSinceHeader = "If-Modified-Since";
    private const string _IfNoneMatchHeader = "If-None-Match";
    private const string _IfMatchHeader = "If-Match";
    private const string _HandlingHeader = "handling";

    public string IfNoneExist { get; set; }
    public string IfModifiedSince { get; set; }
    public string IfNoneMatch { get; set; }
    public string IfMatch { get; set; }
    public string Handling { get; set; }

    public RequestHeader() { }
    public IRequestHeader Parse(Bundle.RequestComponent RequestComponent)
    {
      if (!string.IsNullOrWhiteSpace(RequestComponent.IfNoneExist))
      {
        this.IfNoneExist = RequestComponent.IfNoneExist;
      }

      if (RequestComponent.IfModifiedSince.HasValue)
      {
        var DateTime = new FhirDateTime(RequestComponent.IfModifiedSince.Value);
        this.IfModifiedSince = DateTime.Value;
      }

      if (!string.IsNullOrWhiteSpace(RequestComponent.IfNoneMatch))
      {
        this.IfNoneMatch = ParseVersionHeader(RequestComponent.IfNoneMatch);
      }

      if (!string.IsNullOrWhiteSpace(RequestComponent.IfMatch))
      {
        this.IfMatch = ParseVersionHeader(RequestComponent.IfMatch);
      }
      return this;
    }
    public IRequestHeader Parse(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders)
    {
      IEnumerable<string> IfNoneExist;
      if (HttpRequestHeaders.TryGetValues(_IfNoneExistHeader, out IfNoneExist))
        this.IfNoneExist = IfNoneExist.FirstOrDefault();

      IEnumerable<string> IfModifiedSince;
      if (HttpRequestHeaders.TryGetValues(_IfModifiedSinceHeader, out IfModifiedSince))
        this.IfModifiedSince = IfModifiedSince.FirstOrDefault();

      IEnumerable<string> IfNoneMatchHeader;
      if (HttpRequestHeaders.TryGetValues(_IfNoneMatchHeader, out IfNoneMatchHeader))
        this.IfNoneMatch = IfNoneMatchHeader.FirstOrDefault();

      IEnumerable<string> IfMatchHeader;
      if (HttpRequestHeaders.TryGetValues(_IfMatchHeader, out IfMatchHeader))
        this.IfMatch = IfMatchHeader.FirstOrDefault();

      IEnumerable<string> HandlingHeader;
      if (HttpRequestHeaders.TryGetValues(_HandlingHeader, out HandlingHeader))
        this.Handling = HandlingHeader.FirstOrDefault();

      return this;
    }
    public string ParseVersionHeader(string VersionMatch)
    {
      //Example: W/"2"
      VersionMatch = VersionMatch.Trim();
      if (VersionMatch.ToUpper().StartsWith("W/"))
      {
        VersionMatch = VersionMatch.Trim();
        VersionMatch = VersionMatch.Substring(2, VersionMatch.Length - 2);
      }
      if (VersionMatch.StartsWith("\"") && VersionMatch.EndsWith("\""))
      {
        VersionMatch = VersionMatch.Substring(1, VersionMatch.Length - 1);
        VersionMatch = VersionMatch.Substring(0, VersionMatch.Length - 1);
      }
      return VersionMatch;
    }
  }
}
