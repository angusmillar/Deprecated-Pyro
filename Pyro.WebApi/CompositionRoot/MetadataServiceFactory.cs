using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Service;

namespace Pyro.WebApi.CompositionRoot
{
  public class MetadataServiceFactory : IMetadataServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public MetadataServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IMetadataService CreateMetadataService()
    {
      return Container.GetInstance<IMetadataService>();
    }
  }
}