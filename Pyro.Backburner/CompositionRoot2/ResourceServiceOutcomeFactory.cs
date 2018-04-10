using Pyro.Common.Service;
using Pyro.Common.CompositionRoot;

namespace Pyro.Backburner.CompositionRoot2
{
  public class ResourceServiceOutcomeFactory : IResourceServiceOutcomeFactory
  {
    private readonly SimpleInjector.Container Container;

    public ResourceServiceOutcomeFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IResourceServiceOutcome CreateResourceServiceOutcome()
    {
      return Container.GetInstance<IResourceServiceOutcome>();
    }
  }
}