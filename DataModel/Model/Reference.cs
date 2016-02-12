using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Reference
  {
    public int Id { get; set; }
    public string ReferenceElement { get; set; }
    public string Display { get; set; }

    //BackLinks
    public virtual ConceptMapResource ConceptMapResource { get; set; }
  }

  public static partial class DbInfo
  {
    public static partial class Reference
    {
      public static readonly string TableNameIs = "Reference";

      public static readonly string Id = "Id";
      public static readonly string ReferenceElement = "ReferenceElement";
      public static readonly string Display = "Display";
    }
  }
}
