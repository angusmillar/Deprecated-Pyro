using Hl7.Fhir.Model;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Interfaces.Operation
{
  public interface IFhirResourceOperationService
  {
    IResourceServiceOutcome Process(string OperationName, Resource Resource, IRequestMeta RequestMeta);
  }
}