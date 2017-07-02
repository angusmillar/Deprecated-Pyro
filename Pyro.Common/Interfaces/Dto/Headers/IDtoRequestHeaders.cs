using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Dto.Headers
{
  public interface IDtoRequestHeaders
  {
    string IfNoneExist { get; set; }
    string IfModifiedSince { get; set; }
    string IfMatch { get; set; }
    string IfNoneMatch { get; set; }
    IDtoRequestHeaders Parse(Bundle.RequestComponent RequestComponent);
    IDtoRequestHeaders Parse(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders);
    string ParseVersionHeader(string VersionMatch);

  }
}