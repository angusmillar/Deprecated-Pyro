using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Search
{
  public static class ResourceSearchExtensions
  {
    public static IQueryable<T> Paging<T>(this IQueryable<T> query, int PagRequested, int NumberOfRecordsPerPage)
    {
      return query.Skip(PagRequested * NumberOfRecordsPerPage).Take(NumberOfRecordsPerPage);
    }

    public static IQueryable<T> Ordering<T>(this IQueryable<T> query, DtoSearchParameters DtoSearchParameters)
    {     
      
      foreach (var SortItem in DtoSearchParameters.SortList)
      {
        //(x => x.lastUpdated)
        var type = typeof(T);
        string Property = string.Empty;
        switch (SortItem.Value.DbSearchParameterType)
        {
          case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.DatePeriodIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.NumberIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
            Property = SortItem.Value.DbPropertyName + "_Code";
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
            break;
          default:
            break;
        }

        //System.Reflection.MethodInfo MethodStartsWith = typeof(T).GetMethods().Where(m => m.Name == "OrderBy" && m.GetParameters().Length == 1).Single();
        //ParameterExpression prm = System.Linq.Expressions.Expression.Parameter(typeof(T), Property);
        ////Expression OrderByProperty = System.Linq.Expressions.Expression.Property(prm,)

        ////query.OrderBy(x => x.)
        //var ParameterReferance = System.Linq.Expressions.Expression.Parameter(type, "x");
        //var constantReference = System.Linq.Expressions.Expression.Property(ParameterReferance, Property);
        //var BinaryExpression = System.Linq.Expressions.Expression.Equal(ParameterReferance, constantReference);
        //var Expression = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(BinaryExpression);            
        //query = query.OrderBy(Expression);            
      }
        
      
      return query;      
    }
  }
}
