using Pyro.Common.Interfaces.Repositories;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;

namespace Pyro.Web.CompositionRoot
{
  public class ResourceRepositoryFactory : IResourceRepositoryFactory
  {
    private readonly SimpleInjector.Container Container;

    public ResourceRepositoryFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IResourceRepository Create<ResourceCurrentType, ResourceIndexType>(FHIRAllTypes FHIRAllTypes)
    {
      var CommonResourceRepository = (ICommonResourceRepository<ResourceCurrentType, ResourceIndexType>)Container.GetInstance(typeof(ICommonResourceRepository<ResourceCurrentType, ResourceIndexType>));
      CommonResourceRepository.RepositoryResourceType = FHIRAllTypes;
      return CommonResourceRepository;
    }
  }
}