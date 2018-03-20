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
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class InternalServerProfileResolver : IResourceResolver
  {
    private readonly IResourceServices IResourceServices;        
    private readonly IRequestMetaFactory IRequestMetaFactory;

    public InternalServerProfileResolver(IResourceServices IResourceServices, IRequestMetaFactory IRequestMetaFactory)
    {
      this.IResourceServices = IResourceServices;                  
      this.IRequestMetaFactory = IRequestMetaFactory;
    }
    public Resource ResolveByCanonicalUri(string uri)
    {
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{ResourceType.StructureDefinition.GetLiteral()}?url={uri}");      
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
      if (ResourceServiceOutcome.ResourceResult != null && (ResourceServiceOutcome.ResourceResult as Bundle).Entry.Count > 1)
      {
        throw new System.Exception($"More than a single {ResourceType.StructureDefinition.GetLiteral()} instance was found with the Canonical Uri of {uri} at the endpoint {RequestMeta.PyroRequestUri.FhirRequestUri.OriginalString}.");
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
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.StructureDefinition.GetLiteral()}/{uri}");      
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId, RequestMeta);
      return ResourceServiceOutcome.ResourceResult;
    }
  }
}
