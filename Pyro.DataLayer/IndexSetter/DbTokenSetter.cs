using System;
using System.Collections.Generic;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Setter;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.DataLayer.IndexSetter
{
  public class DbTokenSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbTokenSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    private readonly ITokenSetter ITokenSetter;

    public DbTokenSetter(ITokenSetter ITokenSetter)
    {
      this.ITokenSetter = ITokenSetter;
    }
    public IList<ResIndexTokenType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      var TokenIndexList = ITokenSetter.Set(oElement, SearchParameter);

      if (TokenIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexTokenType>();
      foreach (ITokenIndex Index in TokenIndexList)
      {
        var DbResourceIndex = new ResIndexTokenType();
        DbResourceIndex.Code = Index.Code;
        DbResourceIndex.System = Index.System;
        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;
        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;      
    }
  }
}
