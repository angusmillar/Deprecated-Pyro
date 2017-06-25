using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.Interfaces.ITools
{
  public interface IRepositorySwitcher
  {
    IResourceRepository GetRepository(FHIRAllTypes ResourceType);
  }
}