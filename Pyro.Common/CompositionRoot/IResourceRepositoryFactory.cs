using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.CompositionRoot
{
  public interface IResourceRepositoryFactory
  {
    IResourceRepository Create<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FHIRAllTypes FHIRAllTypes);
    IDtoCommonRepository CreateDtoCommonRepository();
  }
}