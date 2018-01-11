using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface ICommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> : IResourceRepository
  {
    new FHIRAllTypes RepositoryResourceType { get; set; }
  }
}