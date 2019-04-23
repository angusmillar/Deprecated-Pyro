using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using Pyro.Common.Database;
using System.Collections.Generic;
using Pyro.Common.SearchIndexer.Setter;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.DataLayer.IndexSetter
{
  public class DbStringSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbStringSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    private readonly IStringSetter IStringSetter;
    private const string ItemDelimeter = " ";
    public DbStringSetter(IStringSetter IStringSetter)
    {
      this.IStringSetter = IStringSetter;
    }

    public IList<ResIndexStringType> Set(ITypedElement oElement, DtoServiceSearchParameterLight SearchParameter)
    {      
      var StringIndexList = IStringSetter.Set(oElement, SearchParameter);

      if (StringIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexStringType>();
      foreach (IStringIndex Index in StringIndexList)
      {
        var DbResourceIndex = new ResIndexStringType();
        DbResourceIndex.String = Index.String;
        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;
        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;
    }
  }
}
      