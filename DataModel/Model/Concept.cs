using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Concept
  {
    public int Id { get; set; }
    public string Code { get; set; }

    //ForwardLinks
    public virtual CodeSystem CodeSystem { get; set; }    
  }

  public static partial class DbInfo
  {
    public static partial class Concept
    {
      public static readonly string TableNameIs = "Concept";

      public static readonly string Id = "Id";
      public static readonly string Code = "Code";
      public static readonly string CodeSystem_Id = "CodeSystem_Id";
    }
  }
}
