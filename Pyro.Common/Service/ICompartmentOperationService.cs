using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Service
{
  public interface ICompartmentOperationService
  {
    IResourceServiceOutcome Set(OperationClass OperationClass, Resource Resource, IRequestMeta RequestMeta);
  }
}