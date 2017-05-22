using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServerSearchParameterService
  {
    IResourceServiceOutcome ProcessSet();
    IResourceServiceOutcome ProcessReport();
    IResourceServiceOutcome ProcessIndex();
  }
}