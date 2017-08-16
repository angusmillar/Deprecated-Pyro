using System;
using System.Linq;
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
      throw new NotImplementedException();
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
