using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IValidateResourceInstanceService
  {
    IResourceServiceOutcome ValidateResource();
  }
}