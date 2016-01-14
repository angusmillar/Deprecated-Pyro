using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Coding
  {
    public int Id { get; set; }
    public string System { get; set; }
    public string Version { get; set; }
    public string Code { get; set; }
    public string Display { get; set; }
    public bool? UserSelected { get; set; }    

    //ForwardLinks
    public virtual CodeableConcept CodeableConcept { get; set; } 
  }

  public static partial class DbInfo
  {
    public static partial class Coding
    {
      public static readonly string TableNameIs = "Coding";

      public static readonly string Id = "Id";
      public static readonly string System = "System";
      public static readonly string Version = "Version";
      public static readonly string Code = "Code";
      public static readonly string Display = "Display";
      public static readonly string UserSelected = "UserSelected";
      public static readonly string CodeableConcept_Id = "CodeableConcept_Id";      
    }
  }
}
