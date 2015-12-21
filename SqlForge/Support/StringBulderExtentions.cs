using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SqlForge.Support
{
  public static class StringBulderExtentions
  {
    public static StringBuilder Space(this StringBuilder value, int HowMany = 1)
    {
      for (int i = 0; i < HowMany; i++)
      {
        value.Append(" ");
      }
      return value;
    }
    public static StringBuilder NewLine(this StringBuilder value)
    {
      return value.Append(Environment.NewLine);
    }
    public static StringBuilder Asterix(this StringBuilder value)
    {
      return value.Append("*");
    }
    public static StringBuilder Select(this StringBuilder value)
    {
      return value.Append("SELECT");
    }
    public static StringBuilder From(this StringBuilder value)
    {
      return value.Append("FROM");
    }
    public static StringBuilder Join(this StringBuilder value)
    {
      return value.Append("JOIN");
    }
    public static StringBuilder On(this StringBuilder value)
    {
      return value.Append("ON");
    }
    public static StringBuilder Where(this StringBuilder value)
    {
      return value.Append("WHERE");
    }
    public static StringBuilder OrderBy(this StringBuilder value)
    {
      return value.Append("ORDER BY");
    }
    public static StringBuilder Offset(this StringBuilder value)
    {
      return value.Append("OFFSET");
    }
    public static StringBuilder Rows(this StringBuilder value)
    {
      return value.Append("ROWS");
    }
    public static StringBuilder Count(this StringBuilder value, SqlTable TableProperty)
    {
      return value.Append("COUNT(").Append(TableProperty.TableAlias).Dot().Append(TableProperty.PropertyName).Append(")").Space().As().Append(TableProperty.PropertyAlias);
    }
    public static StringBuilder CountAll(this StringBuilder value)
    {
      return value.Append("COUNT(").Asterix().Append(")");
    }
    public static StringBuilder Fetch(this StringBuilder value)
    {
      return value.Append("FETCH");
    }
    public static StringBuilder Next(this StringBuilder value)
    {
      return value.Append("NEXT");
    }
    public static StringBuilder Only(this StringBuilder value)
    {
      return value.Append("ONLY");
    }
    public static StringBuilder Dot(this StringBuilder value)
    {
      return value.Append(".");
    }
    public static StringBuilder Comma(this StringBuilder value)
    {
      return value.Append(",");
    }
    public static StringBuilder As(this StringBuilder value)
    {
      return value.Append("AS");
    }
    public static StringBuilder dbo(this StringBuilder value)
    {
      return value.Append("[dbo]");
    }
    public static StringBuilder Sign(this StringBuilder value, Enums.Sign sign)
    {
      switch (sign)
      {
        case Enums.Sign.Equal:
          return value.Append("=");
        case Enums.Sign.NotEqual:
          return value.Append("!=");
        case Enums.Sign.GreaterThan:
          return value.Append(">");
        case Enums.Sign.GreaterThanEqualTo:
          return value.Append(">=");
        case Enums.Sign.LessThan:
          return value.Append("<=");
        case Enums.Sign.LessThanEqualTo:
          return value.Append("<=");
        case Enums.Sign.Like:
          return value.Append("LIKE");
        case Enums.Sign.Not:
          return value.Append("NOT");
        default:
          throw new ApplicationException("Internal error SQL sign of '" + sign.ToString() + "' Not found in extensions for SqlQueryForge.");
      }
    }
    public static StringBuilder Operator(this StringBuilder value, Enums.Operator op)
    {
      switch (op)
      {
        case Enums.Operator.None:
          return value;
        case Enums.Operator.AND:
          return value.Append("AND");
        case Enums.Operator.OR:
          return value.Append("OR");
        default:
          throw new ApplicationException("Internal error SQL operator of '" + op.ToString() + "' Not found in extensions for SqlQueryForge.");
      }
    }
    public static StringBuilder SortOrder(this StringBuilder value, Enums.SortOrder sortOrder)
    {
      switch (sortOrder)
      {
        case Enums.SortOrder.Ascending:
          return value.Append("ASC");
        case Enums.SortOrder.Descending:
          return value.Append("DESC");
        default:
          throw new ApplicationException("Internal error, SQL Sort Order of '" + sortOrder.ToString() + "' Not found in extensions for SqlQueryForge.");
      }


    }
  }
}
