using Hl7.Fhir.ElementModel;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;
using Pyro.Common.SearchIndexer.Setter;
using Pyro.DataLayer.DbModel.EntityBase;
using System.Collections.Generic;


namespace Pyro.DataLayer.IndexSetter
{
  public class DbNumberSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbNumberSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
  {
    
    private readonly INumberSetter INumberSetter;
    public DbNumberSetter(INumberSetter INumberSetter)
    {
      this.INumberSetter = INumberSetter;
    }
    
    public IList<ResIndexQuantityType> Set(IElementNavigator oElement, IServiceSearchParameterLight SearchParameter)
    {
      var QuantityIndexList = INumberSetter.Set(oElement, SearchParameter);

      if (QuantityIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexQuantityType>();
      foreach (IQuantityIndex Index in QuantityIndexList)
      {
        var DbResourceIndex = new ResIndexQuantityType();
        DbResourceIndex.Comparator = Index.Comparator;
        DbResourceIndex.Quantity = Index.Quantity;
        DbResourceIndex.Code = Index.Code;
        DbResourceIndex.System = Index.System;
        DbResourceIndex.Unit = Index.Unit;

        DbResourceIndex.ComparatorHigh = Index.ComparatorHigh;
        DbResourceIndex.QuantityHigh = Index.QuantityHigh;
        DbResourceIndex.CodeHigh = Index.CodeHigh;
        DbResourceIndex.SystemHigh = Index.SystemHigh;
        DbResourceIndex.UnitHigh = Index.UnitHigh;

        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;

        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;
    }

  }
}
