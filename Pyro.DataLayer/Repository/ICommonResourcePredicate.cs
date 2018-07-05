using Pyro.Common.Search.SearchParameterEntity;
using Pyro.DataLayer.DbModel.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.Repository
{
  public interface ICommonResourcePredicate
  {
    IQueryable<OtherResCurrentType> ChainRecursion<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>
      (IQueryable<OtherResCurrentType> Query, ISearchParameterBase ChainedSearchParameter)
     where OtherResCurrentType : ResourceCurrentBase<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexStringType : ResourceIndexString<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexTokenType : ResourceIndexToken<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexUriType : ResourceIndexUri<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexReferenceType : ResourceIndexReference<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexQuantityType : ResourceIndexQuantity<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
     where OtherResIndexDateTimeType : ResourceIndexDateTime<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new();

  }
}
