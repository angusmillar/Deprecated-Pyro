using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir.Model;

namespace DataModel.Model
{
  public class ValueSetResource
  {
    public int Id { get; set; }
    public int ResourceIdentity_Id { get; set; }
    public DateTime? Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Publisher { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
    public Fhir.ConformanceResourceStatus Status { get; set; }
    public ICollection<Resource> Resource { get; set; }
    public ICollection<CodeableConcept> UseContext { get; set; }

    //Key Links
    public virtual ResourceIdentity ResourceIdentity { get; set; }
    public virtual CodeSystem CodeSystem { get; set; }
    public virtual Compose Compose { get; set; }    
    public virtual Expansion Expansion { get; set; }
    public virtual Identifier Identifier { get; set; }    
        
    public ValueSetResource()
    {
      
      
      Resource = new HashSet<Resource>();
      UseContext = new HashSet<CodeableConcept>();
    }
 
  }

  public static partial class DbInfo
  {
    public static partial class ValueSetResource
    {
      public static readonly string TableNameIs = "ValueSetResource";

      public static readonly string Id = "Id";      
      public static readonly string Date = "Date";
      public static readonly string Name = "Name";
      public static readonly string Description = "Description";      
      public static readonly string Publisher = "Publisher";
      public static readonly string Version = "Version";
      public static readonly string Url = "Url";
      public static readonly string Status = "Status";

      public static readonly string ResourceIdentity_Id = "ResourceIdentity_Id";
      public static readonly string CodeSystem_Id = "CodeSystem_Id";
      public static readonly string Compose_Id = "Compose_Id";
      public static readonly string Expansion_Id = "Expansion_Id";
      public static readonly string Identifier_Id = "Identifier_Id";
      
      public static readonly string List_Resources = "Resources";
      public static readonly string List_UseContext = "UseContext";
      
    }
  }
}
