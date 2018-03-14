using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;
using System.Net.Http;

namespace Pyro.Common.RequestMetadata
{
  public interface IRequestMeta
  {
    IRequestMeta Set(HttpRequestMessage Request);
    IRequestMeta Set(IPyroRequestUri PyroRequestUri, IRequestHeader RequestHeader, ISearchParameterGeneric SearchParameterGeneric);
    IRequestMeta Set(Bundle.RequestComponent RequestComponent);
    IRequestMeta Set(HttpRequestMessage Request, SearchParams SearchParams);
    IRequestMeta Set(string RelativeUrlRequestString);

    IPyroRequestUri PyroRequestUri { get; set; }
    IRequestHeader RequestHeader { get; set; }
    ISearchParameterGeneric SearchParameterGeneric { get; set; }
  }
}
