using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Pyro.Common.Search;

namespace Pyro.DataLayer.Search.Extentions
{
  public static class ResourceSearchExtensions
  {
    public static IQueryable<T> Paging<T>(this IQueryable<T> query, int PagRequested, int NumberOfRecordsPerPage)
    {
      if (PagRequested > 0)
      {
        PagRequested = PagRequested - 1;
      }
      return query.Skip(PagRequested * NumberOfRecordsPerPage).Take(NumberOfRecordsPerPage);
    }

    public static IQueryable<T> Ordering<T>(this IQueryable<T> query, PyroSearchParameters DtoSearchParameters)
    {
      bool IsAscending = true;
      if (DtoSearchParameters.SortList != null && DtoSearchParameters.SortList.Count > 0)
      {
        if (DtoSearchParameters.SortList[0].SortOrderType == Hl7.Fhir.Rest.SortOrder.Descending)
        {
          IsAscending = false;
        }
      }

      var entityType = typeof(T);

      string PropertyName = Common.Database.StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      //Create x=>x.PropName
      var propertyInfo = entityType.GetProperty(PropertyName);
      ParameterExpression arg = Expression.Parameter(entityType, "x");
      MemberExpression property = Expression.Property(arg, PropertyName);
      var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

      //Get System.Linq.Queryable.OrderBy() method.
      var enumarableType = typeof(System.Linq.Queryable);

      MethodInfo genericMethod = null;
      if (IsAscending)
      {
        MethodInfo method = enumarableType.GetMethods()
           .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
           .Where(m =>
           {
             var parameters = m.GetParameters().ToList();
             //Put more restriction here to ensure selecting the right overload                
             return parameters.Count == 2;//overload that has 2 parameters
           }).Single();
        //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
        genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

      }
      else
      {
        MethodInfo method = enumarableType.GetMethods()
           .Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition)
           .Where(m =>
           {
             var parameters = m.GetParameters().ToList();
             //Put more restriction here to ensure selecting the right overload                
             return parameters.Count == 2;//overload that has 2 parameters
           }).Single();
        //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
        genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

      }

      /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
        Note that we pass the selector as Expression to the method and we don't compile it.
        By doing so EF can extract "order by" columns and generate SQL for it.*/
      var newQuery = (IOrderedQueryable<T>)genericMethod
           .Invoke(genericMethod, new object[] { query, selector });
      return newQuery;



      //throw new NotImplementedException();
      //foreach (var SortItem in DtoSearchParameters.SortList)
      //{
      //  //(x => x.lastUpdated)
      //  var type = typeof(T);
      //  string Property = string.Empty;
      //  switch (SortItem.Value.DbSearchParameterType)
      //  {
      //    case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.NumberIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
      //      Property = SortItem.Value.DbPropertyName + "_Code";
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
      //      break;
      //    default:
      //      break;
      //  }                  
      //}
      //return query;
    }
  }
}
