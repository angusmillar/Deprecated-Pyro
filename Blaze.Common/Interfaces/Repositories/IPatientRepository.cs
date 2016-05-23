using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IPatientRepository : IBaseRepository
  {
    string AddResource(Patient Patient, IDtoFhirRequestUri FhirRequestUri);            
    string UpdateResource(int ResourceVersion, Patient Patient, IDtoFhirRequestUri FhirRequestUri);    
    IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, int ResourceVersionNumber);
    IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId);
    void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion);
  }
}
