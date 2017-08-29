using Pyro.Common.Interfaces.Repositories;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;
using Pyro.DataLayer.Repository.Interfaces;

namespace Pyro.Web.CompositionRoot
{
  public class ResourceRepositoryFactory : IResourceRepositoryFactory
  {
    private readonly SimpleInjector.Container Container;

    public ResourceRepositoryFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IResourceRepository Create<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FHIRAllTypes FHIRAllTypes)
    {
      var CommonResourceRepository = (ICommonResourceRepository<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>)Container.GetInstance(typeof(ICommonResourceRepository<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>));
      CommonResourceRepository.RepositoryResourceType = FHIRAllTypes;
      return CommonResourceRepository;
    }

    public IDtoCommonRepository CreateDtoCommonRepository()
    {
      return (IDtoCommonRepository)Container.GetInstance<ICommonRepository>();
    }
  }
}