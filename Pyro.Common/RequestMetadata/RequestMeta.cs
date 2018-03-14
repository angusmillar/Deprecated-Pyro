using Hl7.Fhir.Rest;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;
using System.Net.Http;
using Pyro.Common.Extentions;
using Hl7.Fhir.Model;

namespace Pyro.Common.RequestMetadata
{
  public class RequestMeta : IRequestMeta
  {    
    private readonly IPyroRequestUriFactory IPyroRequestUriFactory;
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;

    public RequestMeta(IPyroRequestUriFactory IPyroRequestUriFactory, IRequestHeaderFactory IRequestHeaderFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory)
    {      
      this.IPyroRequestUriFactory = IPyroRequestUriFactory;
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
    }

    public IRequestMeta Set(HttpRequestMessage Request)
    {      
      this.PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
      this.PyroRequestUri.FhirRequestUri.Parse(Request.RequestUri.OriginalString);
      this.RequestHeader = IRequestHeaderFactory.CreateRequestHeader().Parse(Request.Headers);
      this.SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
      return this;
    }

    public IRequestMeta Set(HttpRequestMessage Request, SearchParams SearchParams)
    {
      this.PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
      this.PyroRequestUri.FhirRequestUri.Parse(Request.RequestUri.OriginalString);
      this.RequestHeader = IRequestHeaderFactory.CreateRequestHeader().Parse(Request.Headers);
      this.SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(SearchParams);
      return this;
    }

    /// <summary>
    /// RelativeUrlRequestString can also contain search parameters and must be relative to the server:
    /// Relative: Patient?family=millar&given=angus
    /// </summary>
    /// <param name="RelativeUrlRequestString"></param>
    /// <returns></returns>
    public IRequestMeta Set(string RelativeUrlRequestString)
    {
      this.PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
      CreateAndParsePyroRequestUri(RelativeUrlRequestString);
      this.RequestHeader = IRequestHeaderFactory.CreateRequestHeader();
      this.SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(this.PyroRequestUri.FhirRequestUri.Query);
      return this;
    }
    
    public IRequestMeta Set(Bundle.RequestComponent RequestComponent)
    {
      this.PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
      CreateAndParsePyroRequestUri(ConstructAbsoluteRequestUrl(RequestComponent.Url, this.PyroRequestUri.PrimaryRootUrlStore.Url));      
      this.RequestHeader = IRequestHeaderFactory.CreateRequestHeader().Parse(RequestComponent);
      this.SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(this.PyroRequestUri.FhirRequestUri.Query);
      return this;
    }
    
    public IRequestMeta Set(IPyroRequestUri PyroRequestUri, IRequestHeader RequestHeader, ISearchParameterGeneric SearchParameterGeneric)
    {
      this.PyroRequestUri = PyroRequestUri;      
      this.RequestHeader = RequestHeader;
      this.SearchParameterGeneric = SearchParameterGeneric;
      return this;
    }

    public IPyroRequestUri PyroRequestUri { get; set; }
    public IRequestHeader RequestHeader { get; set; }
    public ISearchParameterGeneric SearchParameterGeneric { get; set; }

    private void CreateAndParsePyroRequestUri(string RelativeUrlRequestString)
    {      
      if (this.PyroRequestUri.FhirRequestUri.Parse(ConstructAbsoluteRequestUrl(RelativeUrlRequestString, this.PyroRequestUri.PrimaryRootUrlStore.Url)))
      {
        if (!this.PyroRequestUri.FhirRequestUri.IsRelativeToServer)
        {
          string Message = $"Internal Server Error: Attempt to create RequestMeta with request URL that is not relative to the server. The URL used was: {RelativeUrlRequestString}";
          throw new Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Fatal, Hl7.Fhir.Model.OperationOutcome.IssueType.Exception, Message), Message);
        }
      }
      else
      {
        string Message = $"Internal Server Error: Attempt to create RequestMeta failed due to the Request URL string failing to be parsed as a FHIR URL. That string was: {RelativeUrlRequestString}";
        throw new Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Fatal, Hl7.Fhir.Model.OperationOutcome.IssueType.Exception, Message), Message);
      }
    }

    private string ConstructAbsoluteRequestUrl(string RelativeUrlRequestString, string PrimaryServiceRoot)
    {
      if (RelativeUrlRequestString.StartsWith(PrimaryServiceRoot))
        return RelativeUrlRequestString;

      string RequestUrlTemp = string.Empty;
      if (RelativeUrlRequestString.StartsWith(@"/"))
      {
        RequestUrlTemp = RelativeUrlRequestString.Substring(1, RelativeUrlRequestString.Length - 1);
      }
      else
      {
        RequestUrlTemp = RelativeUrlRequestString;
      }
      return $"{PrimaryServiceRoot}/{RequestUrlTemp}";
    }
  }
}
