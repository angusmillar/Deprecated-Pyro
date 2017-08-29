using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface ICommonResourceRepository<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> : IResourceRepository
  {
    FHIRAllTypes RepositoryResourceType { get; set; }
  }
}