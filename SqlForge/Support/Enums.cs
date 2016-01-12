using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlForge.Support
{
  public class Enums
  {
    public enum Sign {None, Equal, NotEqual, GreaterThan, GreaterThanEqualTo, LessThan, LessThanEqualTo, Like, NotLike, Not, Plus };
    public enum Operator { None, AND, OR };
    public enum SortOrder { Ascending, Descending };
  }
}
