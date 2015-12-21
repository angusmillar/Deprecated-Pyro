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
    public ICollection<Prefix> Prefix { get; set; }
    public ICollection<Suffix> Suffix { get; set; }
    public virtual Period Period { get; set; }
    public int PatientResourceId { get; set; }
    public virtual PatientResource PatientResource { get; set; } 

    public HumanName()
    {
      Family = new HashSet<Family>();
      Given = new HashSet<Given>();
      Prefix = new HashSet<Prefix>();
      Suffix = new HashSet<Suffix>();
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
      public static readonly string Period = "Period";
      public static readonly string PatientResourceId = "PatientResourceId";
    }
  }
  
}
