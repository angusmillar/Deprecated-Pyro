using System;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.Repositories;


namespace Pyro.Engine.Services
{
  /// <summary>
  /// This Class is here to handle any unique methods required for Patient resource beyond the basic REST operations.
  /// These might be FHIR operations on the resource such as '$expand' in the ValueSet Resource.
  /// </summary>
  public class PatientResourceServices : BaseResourceServices, IPatientResourceServices, ICommonServices, IBaseServices
  {
    //Constructor for dependency injection
    public PatientResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork)
    {
      _ResourceRepository = _UnitOfWork.PatientRepository;
      _CurrentResourceType = FHIRAllTypes.Patient;
    }

  }
}
