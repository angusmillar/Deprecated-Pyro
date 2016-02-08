using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace DataModel.Model
{
  public class Identifier
  {
    public int Id { get; set; }
    public Hl7.Fhir.Model.Identifier.IdentifierUse? Use { get; set; }    
    
    public string System { get; set; }
    public string Value { get; set; }            
    
    //ForwardLinks
    public CodeableConcept Type { get; set; }
    public virtual Period Period { get; set; }
    public virtual PatientResource PatientResource { get; set; }
    public virtual ValueSetResource ValueSetResource { get; set; } 

    public Identifier()
    {      
    }

  }

  public static partial class DbInfo
  {
    public static partial class Identifier
    {
      public static readonly string TableNameIs = "Identifier";

      public static readonly string Id = "Id";
      public static readonly string Use = "Use";      
      public static readonly string Nav_Type = "Type";
      public static readonly string System = "System";
      public static readonly string Value = "Value";                
      public static readonly string Assigner = "Assigner";

      public static readonly string Type_Id = "Type_Id";
      public static readonly string PatientResource_Id = "PatientResource_Id";
      public static readonly string Period_Id = "Period_Id";
    }
  }
}
