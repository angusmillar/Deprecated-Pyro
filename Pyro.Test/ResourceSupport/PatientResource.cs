using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Test.ResourceSupport
{
  public static class PatientResource
  {
    public static Patient GetPatientResource(string FhirResourceId)
    {
      var oPatient = new Patient();
      oPatient.Id = FhirResourceId;
      oPatient.Active = true;
      oPatient.Text = new Narrative();
      oPatient.Text.Status = Narrative.NarrativeStatus.Generated;
      oPatient.Text.Div = "This is a test patient resource only";
      oPatient.Identifier = new List<Identifier>();
      var Id1 = new Identifier();
      Id1.Use = Identifier.IdentifierUse.Official;
      Id1.System = "urn:oid:1.2.36.1.2001.1003";
      Id1.Value = "800360124567891";
      Id1.Type = new CodeableConcept();
      Id1.Type.Text = "Individual Healthcare Identifier (IHI)";
      oPatient.Identifier.Add(Id1);

      oPatient.Name = new List<HumanName>();
      var Name1 = new HumanName();
      Name1.Use = HumanName.NameUse.Official;
      Name1.Family = new List<string>() { "Millar"};
      Name1.Given = new List<string>() { "Angus", "Brian"};
      Name1.Prefix = new List<string>() { "Mr"};
      Name1.Text = "Angus Millar";
      Name1.Period = new Period();
      Name1.Period.Start = new FhirDateTime(new DateTimeOffset(new DateTime(1973, 09, 30), new TimeSpan(8, 0, 0))).Value;
      oPatient.Name.Add(Name1);

      oPatient.Gender = AdministrativeGender.Male;

      oPatient.BirthDate = new FhirDateTime(new DateTime(1973, 09, 30)).Value;

      return oPatient; 
    }
  }
}
