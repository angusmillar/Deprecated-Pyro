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
    public bool? Active { get; set; }
    public Fhir.AdministrativeGender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public int ResourceIdentity_Id { get; set; }

    public ICollection<Identifier> Identifier { get; set; }
    public ICollection<HumanName> HumanName { get; set; }
    public ICollection<Resource> Resources { get; set; }

    public ResourceIdentity ResourceIdentity { get; set; }

    public PatientResource()
    {
      Identifier = new HashSet<Identifier>();
      HumanName = new HashSet<HumanName>();
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
      public static readonly string Active = "Active";                
      public static readonly string Gender = "Gender";
      public static readonly string BirthDate = "BirthDate";
      public static readonly string ResourceIdentity_Id = "ResourceIdentity_Id";      

      public static readonly string List_Identifier = "Identifier";
      public static readonly string List_HumanNames = "HumanNames";
      public static readonly string List_Resources = "Resources";      

    }
  }
}
