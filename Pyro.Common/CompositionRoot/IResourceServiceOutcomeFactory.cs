using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.CompositionRoot
{
  public interface IResourceServiceOutcomeFactory
  {
    IResourceServiceOutcome CreateResourceServiceOutcome();
  }
}