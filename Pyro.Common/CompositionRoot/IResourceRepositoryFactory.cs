using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.CompositionRoot
{
  public interface IResourceRepositoryFactory
  {
    IResourceRepository Create<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(FHIRAllTypes FHIRAllTypes);
    //IDtoCommonRepository CreateDtoCommonRepository();
  }
}