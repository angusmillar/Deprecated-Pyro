using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools.Headers;
using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class InternalServerProfileResolver : IResourceResolver
  {
    private readonly IResourceServices IResourceServices;
    private readonly ICommonFactory ICommonFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;

    public InternalServerProfileResolver(IResourceServices IResourceServices, ICommonFactory ICommonFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache, ISearchParameterGenericFactory ISearchParameterGenericFactory)
    {
      this.IResourceServices = IResourceServices;
      this.ICommonFactory = ICommonFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
    }
    public Resource ResolveByCanonicalUri(string uri)
    {
      IResourceServices.SetCurrentResourceType(FHIRAllTypes.StructureDefinition);
      string PrimaryServiceRoot = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Url;
      string RequestUriString = $"https://{PrimaryServiceRoot}/{ResourceType.StructureDefinition.GetLiteral()}/?url={uri}";
      IPyroRequestUri RequestUri = ICommonFactory.CreateDtoRequestUri(RequestUriString);
      ISearchParameterGeneric SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse($"url={ uri}");
      IRequestHeader RequestHeaders = ICommonFactory.CreateDtoRequestHeaders();
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestUri, SearchParameterGeneric, RequestHeaders);
      if (ResourceServiceOutcome.ResourceResult != null && (ResourceServiceOutcome.ResourceResult as Bundle).Entry.Count > 1)
      {
        throw new System.Exception($"More than a single {ResourceType.StructureDefinition.GetLiteral()} instance was found with the Canonical Uri of {uri} at the endpoint {PrimaryServiceRoot + "/" + ResourceType.StructureDefinition.GetLiteral()}.");
      }
      else if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is Bundle bundle && bundle.Entry.Count == 1)
      {
        return bundle.Entry[0].Resource;
      }
      else
      {
        return null;
      }
    }
    public Resource ResolveByUri(string uri)
    {
      IResourceServices.SetCurrentResourceType(FHIRAllTypes.StructureDefinition);
      string PrimaryServiceRoot = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Url;
      string RequestUriString = System.IO.Path.Combine(PrimaryServiceRoot, uri);
      IRequestHeader DtoRequestHeaders = ICommonFactory.CreateDtoRequestHeaders();
      IPyroRequestUri RequestUri = ICommonFactory.CreateDtoRequestUri(RequestUriString);
      ISearchParameterGeneric SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric();
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(RequestUri.FhirRequestUri.ResourceId, RequestUri, SearchParameterGeneric, DtoRequestHeaders);
      return ResourceServiceOutcome.ResourceResult;
    }
  }
}
