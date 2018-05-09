using System.Collections.Generic;
using Pyro.Common.FhirRelease;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IFhirReleaseRepository
  {
    List<DtoFhirRelease> GetAllFhirReleases();
    DtoFhirRelease GetFhirReleaseByFhirVersion(string Version);
    DtoFhirRelease UpdateFhirRelease(DtoFhirRelease DtoFhirRelease);
  }
}