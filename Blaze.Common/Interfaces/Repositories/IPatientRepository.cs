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
    string UpdateResource(int ResourceVersion, Patient Patient);
    bool ResourceExists(string FhirResourceId);
    IDatabaseOperationOutcome SearchByFhirId(string FhirId, Tuple<string, string> ActiveSystemAndCode);
    IDatabaseOperationOutcome SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int Page);
    IDatabaseOperationOutcome SearchByFamilyAndGiven2(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int Page);
    IDatabaseOperationOutcome SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri);        
    void UpdateResouceAsDeleted(string FhirResourceId);
  }
}
