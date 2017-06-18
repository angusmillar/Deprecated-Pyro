using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IFhirValidateOperationService
  {
    IResourceServiceOutcome ValidateResource();
    IResourceServiceOutcome ValidateResourceInstance();
  }
}