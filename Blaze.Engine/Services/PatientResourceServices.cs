using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hl7.Fhir.Model;
using Blaze.Engine.CustomException;
using System.Web.UI;
using System.IO;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Engine.Response;
using Blaze.Common.BusinessEntities.Dto;


namespace Blaze.Engine.Services
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
      _CurrentResourceType = FHIRDefinedType.Patient;
    }

  }
}
