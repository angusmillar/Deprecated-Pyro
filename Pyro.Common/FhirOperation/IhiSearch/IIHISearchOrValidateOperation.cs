using Hl7.Fhir.Model;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirOperation.IhiSearch
{
  public interface IIHISearchOrValidateOperation
  {
    IResourceServiceOutcome IHISearchOrValidate(OperationClass OperationClass, Resource Resource, IRequestMeta RequestMeta);   
  }
}