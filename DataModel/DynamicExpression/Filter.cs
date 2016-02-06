using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DynamicExpression
{
  public enum Op
  {
    Equals,
    GreaterThan,
    LessThan,
    GreaterThanOrEqual,
    LessThanOrEqual,
    Contains,
    StartsWith,
    EndsWith
  }

  public class Filter
  {
    public string Property { get; set; }
    public Op Operation { get; set; }
    public object Value { get; set; }
  }
}
