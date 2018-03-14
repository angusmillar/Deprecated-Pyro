using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service
{
  public interface IFhirValidateOperationService
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