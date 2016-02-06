using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class CodeSystem
  {
    public int Id { get; set; }
    public string System { get; set; }
    public ICollection<Concept> Concept { get; set; }

    //BackLinks
    public virtual ValueSetResource ValueSetResource { get; set; }
    
    public CodeSystem()
    {
      Concept = new HashSet<Concept>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class CodeSystem
    {
      public static readonly string TableNameIs = "CodeSystem";

      public static readonly string Id = "Id";
      public static readonly string System = "System";
      public static readonly string List_Concept = "Concept";
    }
  }
}