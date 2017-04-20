using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Engine.RepositorySupport
{
  static class RepositorySwitcher
  {
    public static IResourceRepository GetRepository(FHIRAllTypes ResourceType, IUnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        case FHIRAllTypes.Patient:
            return UnitOfWork.PatientRepository;
        case FHIRAllTypes.Observation:
          return UnitOfWork.ObservationRepository;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(ResourceType.ToString(), (int)ResourceType, typeof(FHIRAllTypes));
      }      
    }
  }
}

