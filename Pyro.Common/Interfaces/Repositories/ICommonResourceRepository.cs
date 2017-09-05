using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface ICommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> : IResourceRepository
  {
    FHIRAllTypes RepositoryResourceType { get; set; }
  }
}