using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.SearchIndexer.Setter;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.DataLayer.IndexSetter
{
  public class DbUriSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbUriSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {
    private readonly IUriSetter IUriSetter;
    public DbUriSetter(IUriSetter IUriSetter)
    {
      this.IUriSetter = IUriSetter;
    }

    public IList<ResIndexUriType> Set(ITypedElement oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      var UriIndexList = IUriSetter.Set(oElement, SearchParameter);

      if (UriIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexUriType>();
      foreach (IUriIndex Index in UriIndexList)
      {
        var DbResourceIndex = new ResIndexUriType();
        DbResourceIndex.Uri = Index.Uri;
        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;
        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;
    }
    
  }
}
