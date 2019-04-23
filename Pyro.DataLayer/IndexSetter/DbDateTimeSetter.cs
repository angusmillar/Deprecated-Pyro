using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using Pyro.Common.SearchIndexer.Setter;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.DataLayer.IndexSetter
{
  public class DbDateTimeSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbDateTimeSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()    
  {
    private readonly IDateTimeSetter IDateTimeSetter;

    public DbDateTimeSetter(IDateTimeSetter IDateTimeSetter)
    {
      this.IDateTimeSetter = IDateTimeSetter;
    }

    public IList<ResIndexDateTimeType> Set(ITypedElement oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      var DateTimeIndexList = IDateTimeSetter.Set(oElement, SearchParameter);

      if (DateTimeIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexDateTimeType>();
      foreach (IDateTimeIndex Index in DateTimeIndexList)
      {
        var DbResourceIndex = new ResIndexDateTimeType();

        DbResourceIndex.HighUtcDateTime = Index.HighUtcDateTime;
        DbResourceIndex.LowUtcDateTime = Index.LowUtcDateTime;

        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;
        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;
    }

  }
}
