using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirOperation.Compartment
{
  public interface ICompartmentOperation
  {
    IResourceServiceOutcome SetActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId);
    IResourceServiceOutcome SetInActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId);
  }
}