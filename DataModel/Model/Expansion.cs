using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Expansion
  {
    public int Id { get; set; }
    public string Identifier { get; set; }

    public virtual ValueSetResource ValueSetResource { get; set; } 
  }

  public static partial class DbInfo
  {
    public static partial class Expansion
    {
      public static readonly string TableNameIs = "Expansion";

      public static readonly string Id = "Id";
      public static readonly string Use = "Identifier";   
    }
  }
}
