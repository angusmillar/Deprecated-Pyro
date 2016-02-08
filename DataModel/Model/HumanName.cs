using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir.Model;

namespace DataModel.Model
{
  public class HumanName
  {
    public int Id { get; set; }
    public Fhir.HumanName.NameUse? Use { get; set; }
    public string Text { get; set; }
    public ICollection<Family> Family { get; set; }
    public ICollection<Given> Given { get; set; }    

    //Keyed
    public virtual Period Period { get; set; }    
    public virtual PatientResource PatientResource { get; set; } 

    public HumanName()
    {
      Family = new HashSet<Family>();
      Given = new HashSet<Given>();    
    }
  }

  public static partial class DbInfo
  {
    public static partial class HumanName
    {
      public static readonly string TableNameIs = "HumanName";
     
      public static readonly string Id = "Id";
      public static readonly string Use = "Use";
      public static readonly string Text = "Text";
      public static readonly string List_Family = "Family";
      public static readonly string List_Given = "Given";
      public static readonly string Period_Id = "Period_Id";
      public static readonly string PatientResource_Id = "PatientResource_Id";
      
    }
  }
  
}
