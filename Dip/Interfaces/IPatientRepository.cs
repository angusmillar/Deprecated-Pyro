using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Dip.Interfaces
{
  public interface IPatientRepository : IBaseRepository
  {
    string AddResource(Patient Patient);
    IDatabaseOperationOutcome GetCurrentResource(string FhirResourceId);    
    int GetResourceCurrentVersion(string FhirResourceId);
    string UpdateResource(int ResourceVersion, Patient Patient);
    IDatabaseOperationOutcome SearchByFhirId(string FhirId, Tuple<string, string> ActiveSystemAndCode);
    IDatabaseOperationOutcome SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int Page);
    IDatabaseOperationOutcome SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri);        
    void UpdateResouceAsDeleted(string FhirResourceId);
  }
}
