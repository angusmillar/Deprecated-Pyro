using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Compose
  {
    public int Id { get; set; }
    public ICollection<Include> Include { get; set; }

    //BackLinks
    public virtual ValueSetResource ValueSetResource { get; set; }
    
    public Compose()
    {
      Include = new HashSet<Include>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class Compose
    {
      public static readonly string TableNameIs = "Compose";

      public static readonly string Id = "Id";
      public static readonly string List_Include = "Include";
    }
  }
}
