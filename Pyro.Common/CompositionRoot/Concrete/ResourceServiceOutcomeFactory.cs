using Pyro.Common.Service.ResourceService;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.CompositionRoot.Concrete
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