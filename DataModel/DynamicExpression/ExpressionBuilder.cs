using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DataModel.DynamicExpression
{
  public static class ExpressionBuilder
  {
    private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
    private static MethodInfo startsWithMethod =
    typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
    private static MethodInfo endsWithMethod =
    typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });


    public static Expression<Func<T,
    bool>> GetExpression<T>(IList<Filter> filters)
    {
      if (filters.Count == 0)
        return null;

      ParameterExpression param = Expression.Parameter(typeof(T), "t");
      Expression exp = null;

      if (filters.Count == 1)
        exp = GetExpression<T>(param, filters[0]);
      else if (filters.Count == 2)
        exp = GetExpression<T>(param, filters[0], filters[1]);
      else
      {
        while (filters.Count > 0)
        {
          var f1 = filters[0];
          var f2 = filters[1];

          if (exp == null)
            exp = GetExpression<T>(param, filters[0], filters[1]);
          else
            exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

          filters.Remove(f1);
          filters.Remove(f2);

          if (filters.Count == 1)
          {
            exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
            filters.RemoveAt(0);
          }
        }
      }

      return Expression.Lambda<Func<T, bool>>(exp, param);
    }

    private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
    {
      MemberExpression member = Expression.Property(param, filter.Property);
      ConstantExpression constant = Expression.Constant(filter.Value);

      switch (filter.Operation)
      {
        case Op.Equals:
          return Expression.Equal(member, constant);

        case Op.GreaterThan:
          return Expression.GreaterThan(member, constant);

        case Op.GreaterThanOrEqual:
          return Expression.GreaterThanOrEqual(member, constant);

        case Op.LessThan:
          return Expression.LessThan(member, constant);

        case Op.LessThanOrEqual:
          return Expression.LessThanOrEqual(member, constant);

        case Op.Contains:
          return Expression.Call(member, containsMethod, constant);

        case Op.StartsWith:
          return Expression.Call(member, startsWithMethod, constant);

        case Op.EndsWith:
          return Expression.Call(member, endsWithMethod, constant);
      }

      return null;
    }

    private static BinaryExpression GetExpression<T>
    (ParameterExpression param, Filter filter1, Filter filter2)
    {
      Expression bin1 = GetExpression<T>(param, filter1);
      Expression bin2 = GetExpression<T>(param, filter2);

      return Expression.AndAlso(bin1, bin2);
    }
  }
}
