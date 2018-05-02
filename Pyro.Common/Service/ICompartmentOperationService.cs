using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Service
{
  public interface ICompartmentOperationService
  {
    IResourceServiceOutcome SetActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId);
    IResourceServiceOutcome SetInActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId);
  }
}