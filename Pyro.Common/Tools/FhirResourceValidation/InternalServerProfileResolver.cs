using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Utility;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class InternalServerProfileResolver : IResourceResolver
  {
    private readonly IResourceServices IResourceServices;
    private readonly ICommonFactory ICommonFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;

    public InternalServerProfileResolver(IResourceServices IResourceServices, ICommonFactory ICommonFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      this.IResourceServices = IResourceServices;
      this.ICommonFactory = ICommonFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }
    public Resource ResolveByCanonicalUri(string uri)
    {
      IResourceServices.SetCurrentResourceType(FHIRAllTypes.StructureDefinition);
      string PrimaryServiceRoot = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Url;
      string RequestUriString = $"https://{PrimaryServiceRoot}/{ResourceType.StructureDefinition.GetLiteral()}/?url={uri}";
      Interfaces.UriSupport.IDtoRequestUri RequestUri = ICommonFactory.CreateDtoRequestUri(RequestUriString);
      Interfaces.Dto.IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse($"url={ uri}");
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestUri, SearchParameterGeneric);
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
      IDtoRequestHeaders DtoRequestHeaders = ICommonFactory.CreateDtoRequestHeaders();
      Interfaces.UriSupport.IDtoRequestUri RequestUri = ICommonFactory.CreateDtoRequestUri(RequestUriString);
      Interfaces.Dto.IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric();
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(RequestUri.FhirRequestUri.ResourceId, RequestUri, SearchParameterGeneric, DtoRequestHeaders);
      return ResourceServiceOutcome.ResourceResult;
    }
  }
}
