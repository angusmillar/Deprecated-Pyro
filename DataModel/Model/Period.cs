using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Period
  {
    public int Id { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }    
    public virtual HumanName OfHumanName { get; set; } 
  }

  public static partial class DbInfo
  {
    public static partial class Period
    {
      public static readonly string TableNameIs = "Period";
      public static readonly string Id = "Id";
      public static readonly string Start = "Start";
      public static readonly string End = "End";
    }
  }
}
