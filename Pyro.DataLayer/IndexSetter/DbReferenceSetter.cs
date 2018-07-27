using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.DataLayer.Repository.Interfaces;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;
using Pyro.Common.SearchIndexer.Index;
using Pyro.Common.SearchIndexer.Setter;

namespace Pyro.DataLayer.IndexSetter
{
  public class DbReferenceSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDbReferenceSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    private readonly IServiceBaseUrlRepository IServiceBaseUrlRepository;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IReferenceSetter IReferenceSetter;

    public DbReferenceSetter(IServiceBaseUrlRepository IServiceBaseUrlRepository, IPyroFhirUriFactory IPyroFhirUriFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache, ICommonFactory ICommonFactory, IReferenceSetter IReferenceSetter)
    {
      this.IServiceBaseUrlRepository = IServiceBaseUrlRepository;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IReferenceSetter = IReferenceSetter;
    }

    public IList<ResIndexReferenceType> Set(IElementNavigator oElement, IServiceSearchParameterLight SearchParameter)
    {
      var ReferenceIndexList = IReferenceSetter.Set(oElement, SearchParameter);
      if (ReferenceIndexList.Count == 0)
      {
        return null;
      }

      var DbReferenceIndexList = new List<ResIndexReferenceType>();
      foreach (IReferenceIndex Index in ReferenceIndexList)
      {
        var DbResourceIndex = new ResIndexReferenceType();
        DbResourceIndex.ReferenceVersionId = Index.VersionId;
        DbResourceIndex.ReferenceFhirId = Index.FhirId;
        DbResourceIndex.ReferenceResourceType = Index.ResourceType;
        DbResourceIndex.ServiceSearchParameterId = Index.ServiceSearchParameterLight.Id;

        if (Index.IsRelativeToServer)
        {
          DbResourceIndex.ReferenceServiceBaseUrlId = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Id;
        }
        else
        {          
          DbResourceIndex.ReferenceServiceBaseUrlId = IServiceBaseUrlRepository.GetAndOrAddService_RootUrlStore(Index.BaseUrl).Id;
        }
        DbReferenceIndexList.Add(DbResourceIndex);
      }
      return DbReferenceIndexList;
    }

  }
}
