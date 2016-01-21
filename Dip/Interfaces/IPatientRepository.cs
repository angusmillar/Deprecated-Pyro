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
    IDatabaseSearchResult GetCurrentResource(string FhirResourceId);
    bool ResourceExists(string FhirResourceId);
    int GetResourceCurrentVersion(string FhirResourceId);
    string UpdateResource(int ResourceVersion, Patient Patient);
    IDatabaseSearchResult SearchByFhirId(string FhirId, Tuple<string, string> ActiveSystemAndCode);
    IDatabaseSearchResult SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int Page);
    IDatabaseSearchResult SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri);
    bool IsCurrentResourceDeleted(string FhirResourceId);
    int LastDeletedResourceVersion(string FhirResourceId);
    void UpdateResouceAsDeleted(string FhirResourceId);
  }
}
