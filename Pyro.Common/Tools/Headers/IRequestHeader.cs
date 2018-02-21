using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.Headers
{
  public interface IRequestHeader
  {
    string IfNoneExist { get; set; }
    string IfModifiedSince { get; set; }
    string IfMatch { get; set; }
    string IfNoneMatch { get; set; }
    string Handling { get; set; }
    IRequestHeader Parse(Bundle.RequestComponent RequestComponent);
    IRequestHeader Parse(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders);   
    string ParseVersionHeader(string VersionMatch);

  }
}