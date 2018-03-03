using Pyro.Common.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface IResourceServiceOutcomeFactory
  {
    IResourceServiceOutcome CreateResourceServiceOutcome();
  }
}