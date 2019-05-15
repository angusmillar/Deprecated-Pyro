using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools.Headers;
using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class InternalServerProfileResolver : IResourceResolver
  {
    private readonly IResourceServices IResourceServices;        
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;

    public InternalServerProfileResolver(IResourceServices IResourceServices, IRequestMetaFactory IRequestMetaFactory, IPyroFhirUriFactory IPyroFhirUriFactory)
    {
      this.IResourceServices = IResourceServices;                  
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
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
      IPyroFhirUri FhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
      if (FhirUri.Parse(uri))
      {
        if (FhirUri.IsRelativeToServer)
        {
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(FhirUri.ResourceType.Value, FhirUri.ResourceId);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId, RequestMeta);
          return ResourceServiceOutcome.ResourceResult;
        }
        else
        {

          Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirUri.PrimaryServiceRootRemote);
          clientFhir.Timeout = 1000 * 120; // 2 Min
          return clientFhir.Get(FhirUri.OriginalString);          
        }
      }
      else
      {
        string ErrorMessage = $"An invalid FHIR Uri was attempted to be resolved by the server's ServerProfileResolver. That Uri was: '{uri}'";
        var OptOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotFound, ErrorMessage);
        throw new Common.Exceptions.PyroException(System.Net.HttpStatusCode.BadRequest, OptOut, ErrorMessage);
      }    
    }
  }
}
