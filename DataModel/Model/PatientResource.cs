using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir.Model;

namespace DataModel.Model
{
  public class PatientResource
  {
    public int Id { get; set; }
    public string FhirResourceId { get; set; }    
    public ICollection<HumanName> HumanNames { get; set; }
    public Fhir.AdministrativeGender? Gender { get; set; }
    public ICollection<Resource> Resources { get; set; }
    public PatientResource()
    {
      HumanNames = new HashSet<HumanName>();
      Resources = new HashSet<Resource>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class PatientResource
    {
      public static readonly string TableNameIs = "PatientResource";
     
      public static readonly string Id = "Id";
      public static readonly string FhirResourceId = "FhirResourceId";
      public static readonly string Gender = "Gender";
    }
  }
}
