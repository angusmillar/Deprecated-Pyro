using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface ICommonResourceRepository<ResourceCurrentType, ResourceIndexType> : IResourceRepository
  {
    FHIRAllTypes RepositoryResourceType { get; set; }
  }
}