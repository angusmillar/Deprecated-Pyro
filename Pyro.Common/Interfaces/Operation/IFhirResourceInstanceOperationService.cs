using Hl7.Fhir.Model;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Interfaces.Operation
{
  public interface IFhirResourceInstanceOperationService
  {
    IResourceServiceOutcome ProcessPost(string ResourceName, string FhirId, string OperationName, IRequestMeta RequestMeta, Resource Resource);
    IResourceServiceOutcome ProcessGet(string ResourceName, string FhirId, string OperationName, IRequestMeta RequestMeta);    
  }
}