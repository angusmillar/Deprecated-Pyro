using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.Tools
{
  public interface IRepositorySwitcher
  {
    IResourceRepository GetRepository(FHIRAllTypes ResourceType);
  }
}