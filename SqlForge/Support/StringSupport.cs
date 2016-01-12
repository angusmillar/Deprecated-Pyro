using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlForge.Support
{
  public static class StringSupport
  {
    public static string SignToString(Enums.Sign sign)
    {
      switch (sign)
      {
        case Enums.Sign.Equal:
          return "=";
        case Enums.Sign.NotEqual:
          return "!=";
        case Enums.Sign.GreaterThan:
          return ">";
        case Enums.Sign.GreaterThanEqualTo:
          return ">=";
        case Enums.Sign.LessThan:
          return "<=";
        case Enums.Sign.LessThanEqualTo:
          return "<=";
        case Enums.Sign.Like:
          return "LIKE";
        case Enums.Sign.NotLike:
          return "NOT LIKE";
        case Enums.Sign.Not:
          return "NOT";
        case Enums.Sign.Plus:
          return "+";
        case Enums.Sign.None:
          return "";
        default:
          throw new ApplicationException("Internal error SQL sign of '" + sign.ToString() + "' Not found in extensions for SqlQueryForge.");
      }
    }
    public static string OperatorToString(Enums.Operator Operator)
    {
      switch (Operator)
      {
        case Enums.Operator.None:
          return "";
        case Enums.Operator.AND:
          return "AND";
        case Enums.Operator.OR:
          return "OR";
        default:
          throw new ApplicationException("Internal error SQL operator of '" + Operator.ToString() + "' Not found in extensions for SqlQueryForge.");
      }
    }
    public static string SortOrderToString(Enums.SortOrder SortOrder)
    {
      switch (SortOrder)
      {
        case Enums.SortOrder.Ascending:
          return "ASC";
        case Enums.SortOrder.Descending:
          return "DESC";
        default:
          throw new ApplicationException("Internal error SQL Sort Order of '" + SortOrder.ToString() + "' Not found in extensions for SqlQueryForge.");
      }
    }

    public static string Property(SqlTable TableProperty)
    {
      if (TableProperty.TableAlias != string.Empty)
        return String.Format("{0}.{1}", TableProperty.TableAlias, TableProperty.PropertyName);
      else
        return String.Format("{0}", TableProperty.PropertyName);
    }
  }
}
