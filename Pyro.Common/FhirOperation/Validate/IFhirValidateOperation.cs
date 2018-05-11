using Hl7.Fhir.Model;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirOperation.Validate
{
  public interface IFhirValidateOperation
  {
    IResourceServiceOutcome ValidateResource(
      OperationClass OperationClass,
      Resource Resource,
      IRequestMeta RequestMeta);

    IResourceServiceOutcome ValidateResourceInstance(
      OperationClass OperationClass,
      Resource Resource,
      IRequestMeta RequestMeta);
  }
}