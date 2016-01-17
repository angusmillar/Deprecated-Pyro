using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir.Model;


namespace DataModel.Interface
{
  public interface IPatientRepository : IBaseRepository
  {
    string AddResource(Fhir.Patient Patient);
    Fhir.Patient GetCurrentResource(string FhirResourceId);
    bool ResourceExists(string FhirResourceId);       
    int GetResourceCurrentVersion(string FhirResourceId);
    string UpdateResource(int ResourceVersion, Fhir.Patient Patient);
    Fhir.Bundle SearchByFhirId(string FhirId, Tuple<string, string> ActiveSystemAndCode);
    Fhir.Bundle SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int Page, Uri RequestUri);
    Fhir.Bundle SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri);
    bool IsCurrentResourceDeleted(string FhirResourceId);
    int LastDeletedResourceVersion(string FhirResourceId);
    void UpdateResouceAsDeleted(string FhirResourceId);

  }
}
