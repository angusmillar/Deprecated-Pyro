using Hl7.Fhir.ElementModel;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Pyro.Common.CompositionRoot;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;
using Pyro.Common.Extentions;
using Pyro.Common.FhirRelease;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.Search;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Common.Service.Trigger;
using Pyro.Common.ServiceRoot;
using Pyro.Common.ServiceSearchParameter;
using Pyro.Common.Tools;
using Pyro.Common.Tools.FhirPathSupport;
using Pyro.Common.Tools.Paging;
using Pyro.Common.Tools.UriSupport;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.IndexSetter;
using Pyro.DataLayer.Search.Extentions;
using Pyro.DataLayer.Support;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Pyro.DataLayer.Repository
{
  public class CommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    BaseRepository,
    ICommonResourcePredicate,
    ICommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>,
    IResourceRepository
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
  {
    public FHIRAllTypes RepositoryResourceType { get; set; }

    private readonly IDbIndexSetterFactory<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> IDbIndexSetterFactory;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IFhirReleaseCache IFhirReleaseCache;
    private readonly IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory;
    private readonly IPagingSupport IPagingSupport;
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IResourceTriggerService IResourceTriggerService;
    private readonly IPyroFhirPathResolve IPyroFhirPathResolve;
    private readonly ILog ILog;

    private readonly CommonRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> CommonRepository;

    public CommonResourceRepository(IPyroDbContext IPyroDbContext,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IDbIndexSetterFactory<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> IDbIndexSetterFactory,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      IFhirReleaseCache IFhirReleaseCache,
      IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory,
      IPagingSupport IPagingSupport,
      IRepositorySwitcher IRepositorySwitcher,
      IResourceTriggerService IResourceTriggerService,
      IPyroFhirPathResolve IPyroFhirPathResolve,
      ILog ILog)
      : base(IPyroDbContext)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IDbIndexSetterFactory = IDbIndexSetterFactory;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IFhirReleaseCache = IFhirReleaseCache;
      this.IDatabaseOperationOutcomeFactory = IDatabaseOperationOutcomeFactory;
      this.IPagingSupport = IPagingSupport;
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IResourceTriggerService = IResourceTriggerService;
      this.ILog = ILog;
      this.IPyroFhirPathResolve = IPyroFhirPathResolve;
      this.CommonRepository = new CommonRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(IPyroDbContext, IPrimaryServiceRootCache);
    }

    //Used for _include and _Revinclude
    public string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int[] SearchParameterIdArray, string ResourceName = "")
    {
      LinqKit.ExpressionStarter<ResIndexReferenceType> RefPredicate = null;
      if (string.IsNullOrWhiteSpace(ResourceName))
        RefPredicate = this.CommonRepository.IndexRefPredicateGenerator(ResourceId, SearchParameterIdArray);
      else
        RefPredicate = this.CommonRepository.IndexRefPredicateGenerator(ResourceId, SearchParameterIdArray, ResourceName);

      var IndexQuery = this.CommonRepository.GetDbIndexAll(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }

    //Used for Chain Reference Searching
    public string[] GetResourceFhirIdByReferanceIndex(IEnumerable<string> FhirIdArray, string ResourceName, int SearchParameterIdArray)
    {
      LinqKit.ExpressionStarter<ResCurrentType> ResCurrentTypePredicate = null;

      ResCurrentTypePredicate = this.CommonRepository.ResourceCurrentPredicateGeneratorByRefereneNoPaging(FhirIdArray, ResourceName, SearchParameterIdArray);

      var Query = this.CommonRepository.GetDbEntityAllQuery(ResCurrentTypePredicate);

      var Result = Query.Select(x => x.FhirId).ToArray();
      return Result;
    }
    
    public IQueryable<OtherResCurrentType> ChainRecursion<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>
      (IQueryable<OtherResCurrentType> OtherResourceContext, ISearchParameterBase ChainedSearchParameter)
      where OtherResCurrentType : ResourceCurrentBase<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexStringType : ResourceIndexString<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexTokenType : ResourceIndexToken<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexUriType : ResourceIndexUri<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexReferenceType : ResourceIndexReference<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexQuantityType : ResourceIndexQuantity<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
      where OtherResIndexDateTimeType : ResourceIndexDateTime<OtherResCurrentType, OtherResIndexStringType, OtherResIndexTokenType, OtherResIndexUriType, OtherResIndexReferenceType, OtherResIndexQuantityType, OtherResIndexDateTimeType>, new()
    {
      // This method is recursive and works through each chain in the chain search parameter
      //For debug the query example is:
      //[base]/DiagnosticReport?result:Observation.performer:Organization.name = Friday Computer Club Organisation
      // Which in this method results in the follow set-up:
      //  OtherResourceContext = DiagnosticReport  
      //  ResCurrentTypeContext = Observation
      //  RootChainSearch = Organisation 

      if (ChainedSearchParameter.ChainedSearchParameter != null)
      {
        //Recursively move through each child chain search parameter until at the end and child is null
        //The last one is the root search at the end of the chain, performer:Organization.name from the example. 
        string DummayResourceName = ChainedSearchParameter.ChainedSearchParameter.Resource;
        FHIRAllTypes InnnerResourceType = Common.Tools.ResourceNameResolutionSupport.GetResourceFhirAllType(Common.Tools.ResourceNameResolutionSupport.GetResourceType(DummayResourceName));
        var InnnerResourceRepository = this.IRepositorySwitcher.GetRepository(InnnerResourceType);

        if (InnnerResourceRepository is ICommonResourcePredicate InnerResourcePredicate)
        {
          IQueryable<ResCurrentType> ResCurrentTypeContext = IPyroDbContext.Set<ResCurrentType>();
          ResCurrentTypeContext = InnerResourcePredicate.ChainRecursion<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
            (ResCurrentTypeContext, ChainedSearchParameter.ChainedSearchParameter);

          string ReferenceResourceName = ChainedSearchParameter.TypeModifierResource;
          int ReferenceSearchParameterId = ChainedSearchParameter.Id;
          int ReferencePrimaryServiceRootUrlId = this.IPrimaryServiceRootCache.GetPrimaryRootUrlStoreFromDatabase().Id;

          //The Chain Reference Query
          OtherResourceContext = OtherResourceContext
            .Where(x => x.IndexReferenceList
              .Any(c => ResCurrentTypeContext
                .Where(a => a.IsCurrent == true & a.IsDeleted == false & a.IndexReferenceList.Any(f => f.ReferenceResourceType == ReferenceResourceName & f.ServiceSearchParameterId == ReferenceSearchParameterId & f.ReferenceVersionId == null & f.ReferenceServiceBaseUrlId == ReferencePrimaryServiceRootUrlId))
                  .Select(v => v.FhirId)
                    .Contains(c.ReferenceFhirId)));

          return OtherResourceContext;
        }
        else
        {
          throw new InvalidCastException("Internal Server error: Unable to cast InnnerResourceRepository to ICommonResourcePredicate for chain searching.");
        }
      }
      else
      {
        // The last search in the chain search parameter chain.
        var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
        Predicate = Predicate.And(this.CommonRepository.PredicateCurrentNotDeleted());
        var ChainParanmeterList = new List<ISearchParameterBase>() { ChainedSearchParameter };
        Predicate = Predicate.And(this.CommonRepository.PredicateResourceId(ChainParanmeterList));
        Predicate = Predicate.And(this.CommonRepository.ANDSearchParameterListPredicateGenerator(ChainParanmeterList));

        IQueryable<ResCurrentType> ResCurrentTypeContext = IPyroDbContext.Set<ResCurrentType>();
        ResCurrentTypeContext = ResCurrentTypeContext.Where(Predicate);
        OtherResourceContext = OtherResourceContext
          .Where(x => x.IndexReferenceList
            .Any(c => ResCurrentTypeContext
              .Select(v => v.FhirId)
                .Contains(c.ReferenceFhirId)));

        return OtherResourceContext;
      }
    }

    private IQueryable<ResCurrentType> Chaining(IQueryable<ResCurrentType> CurrentResourceContext, ISearchParameterBase ChainedSearchParameter)
    {
      string DummayResourceName = ChainedSearchParameter.ChainedSearchParameter.Resource;
      FHIRAllTypes InnnerResourceType = Common.Tools.ResourceNameResolutionSupport.GetResourceFhirAllType(Common.Tools.ResourceNameResolutionSupport.GetResourceType(DummayResourceName));
      var InnnerResourceRepository = this.IRepositorySwitcher.GetRepository(InnnerResourceType);

      if (InnnerResourceRepository is ICommonResourcePredicate InnerResourcePredicate)
      {
        return InnerResourcePredicate.ChainRecursion<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
          (CurrentResourceContext, ChainedSearchParameter.ChainedSearchParameter);
      }
      else
      {
        throw new InvalidCastException("Internal Server error: Unable to cast InnnerResourceRepository to ICommonResourcePredicate for chain searching.");
      }
    }

    public IDatabaseOperationOutcome GetResourceBySearch(PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      List<ISearchParameterBase> ChainedSearchParametersList = DtoSearchParameters.SearchParametersList.Where(x => x.ChainedSearchParameter != null).ToList();
      List<ISearchParameterBase> NoChainedSearchParametersList = DtoSearchParameters.SearchParametersList.Where(x => x.ChainedSearchParameter == null).ToList();

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var PredicateCurrentResources = this.CommonRepository.PredicateCurrentNotDeleted();
      var PredicateResourceId = this.CommonRepository.PredicateResourceId(NoChainedSearchParametersList);
      var PredicateSearchParameters = this.CommonRepository.ANDSearchParameterListPredicateGenerator(NoChainedSearchParametersList);

      Predicate = Predicate.And(PredicateCurrentResources);
      Predicate = Predicate.And(PredicateResourceId);
      Predicate = Predicate.And(PredicateSearchParameters);

      IQueryable<ResCurrentType> CurrentResourceContext = IPyroDbContext.Set<ResCurrentType>();
      CurrentResourceContext = CurrentResourceContext.Where(Predicate);

      //Add Chain Search Parameters
      foreach (var Chain in ChainedSearchParametersList)
        CurrentResourceContext = Chaining(CurrentResourceContext, Chain);

      int TotalRecordCount = CurrentResourceContext.Count();

      //Work to do for dynamic Sort
      CurrentResourceContext = CurrentResourceContext.Ordering<ResCurrentType>(DtoSearchParameters);

      //if (DtoSearchParameters.SortList[0].SortOrderType == Hl7.Fhir.Rest.SortOrder.Descending)
      //{
      //  //_sort=-_LastUpdated
      //  CurrentResourceContext = CurrentResourceContext.OrderByDescending(x => x.LastUpdated);
      //}
      //else
      //{
      //  //_sort=_LastUpdated
      //  CurrentResourceContext = CurrentResourceContext.OrderBy(x => x.LastUpdated);
      //}


      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      CurrentResourceContext = CurrentResourceContext.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));

      var DtoResourceList = new List<DtoResource>();
      if (WithXml)
      {
        DtoResourceList = CurrentResourceContext.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType,
          Resource = x.Resource
        }).ToList();
      }
      else
      {
        DtoResourceList = CurrentResourceContext.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType
        }).ToList();
      }

      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }   

    public IDatabaseOperationOutcome GetResourceByCompartmentSearch(PyroSearchParameters CompartmentSearchParameters, PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      //SetNumberOfRecordsPerPage(DtoSearchParameters);
      List<ISearchParameterBase> ChainedSearchParametersList = DtoSearchParameters.SearchParametersList.Where(x => x.ChainedSearchParameter != null).ToList();
      List<ISearchParameterBase> NoChainedSearchParametersList = DtoSearchParameters.SearchParametersList.Where(x => x.ChainedSearchParameter == null).ToList();


      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var PredicateCurrentResources = this.CommonRepository.PredicateCurrentNotDeleted();
      var PredicateResourceId = this.CommonRepository.PredicateResourceId(NoChainedSearchParametersList);
      var PredicateSearchParameters = this.CommonRepository.ANDSearchParameterListPredicateGenerator(NoChainedSearchParametersList);
      var PredicateCompartment = this.CommonRepository.ORSearchParameterListPredicateGenerator(CompartmentSearchParameters.SearchParametersList);

      Predicate = Predicate.And(PredicateCurrentResources);
      Predicate = Predicate.And(PredicateResourceId);
      Predicate = Predicate.And(PredicateSearchParameters);
      Predicate = Predicate.And(PredicateCompartment);

      IQueryable<ResCurrentType> CurrentResourceContext = IPyroDbContext.Set<ResCurrentType>();
      CurrentResourceContext = CurrentResourceContext.Where(Predicate);

      //Add Chain Search Parameters
      foreach (var Chain in ChainedSearchParametersList)
        CurrentResourceContext = Chaining(CurrentResourceContext, Chain);

      int TotalRecordCount = CurrentResourceContext.Count();

      CurrentResourceContext = CurrentResourceContext.OrderBy(x => x.LastUpdated);
      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      CurrentResourceContext = CurrentResourceContext.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));





      //int TotalRecordCount = this.CommonRepository.DbGetALLCount<ResCurrentType>(Predicate);
      //var Query = this.CommonRepository.DbGetAll(Predicate);

      ////Todo: Sort not implemented just defaulting to last update order      
      //Query = Query.OrderBy(x => x.LastUpdated);

      //int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);

      //Query = Query.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));
      var DtoResourceList = new List<DtoResource>();
      if (WithXml)
      {
        DtoResourceList = CurrentResourceContext.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType,
          Resource = x.Resource
        }).ToList();
      }
      else
      {
        DtoResourceList = CurrentResourceContext.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType
        }).ToList();
      }

      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirId, bool WithXml = false, bool IncludeDeleted = true)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DtoResource DtoResource = null;
      if (WithXml)
      {
        if (IncludeDeleted)
          DtoResource = this.CommonRepository.GetDbWithXML(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = this.CommonRepository.GetDbWithXML(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      else
      {
        if (IncludeDeleted)
          DtoResource = this.CommonRepository.GetDbNoXML(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = this.CommonRepository.GetDbNoXML(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      if (DtoResource != null)
      {
        DtoResource.ResourceType = this.RepositoryResourceType;
        DatabaseOperationOutcome.ReturnedResourceList.Add(DtoResource);
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();

      if (!string.IsNullOrWhiteSpace(ResourceVersionNumber))
      {
        DatabaseOperationOutcome.SingleResourceRead = true;
        var ResourceHistoryEntity = this.CommonRepository.GetDbEntity(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, this.RepositoryResourceType));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = this.CommonRepository.GetDbALLCount<ResCurrentType>(Predicate);
        var Query = this.CommonRepository.GetDbEntityAllQuery(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource<ResourceBase>(x, this.RepositoryResourceType)));

      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirResourceId, PyroSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      //SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);

      //Query for total count
      int TotalRecordCount = this.CommonRepository.GetDbALLCount<ResCurrentType>(Predicate);

      //Paging set-up
      var Query = this.CommonRepository.GetDbEntityAllQuery(Predicate);

      //Which way to order, touchstone tests failing for history due to wrong way, have changed to Descending to see if they pass 
      //Query = Query.OrderBy(x => x.LastUpdated);
      Query = Query.OrderByDescending(x => x.LastUpdated);

      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      Query = Query.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));
      int PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);

      //Query for Resources
      var HistoryEntityList = Query.ToList();

      //Convert to DTO
      var DtoResourceList = new List<DtoResource>();
      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));

      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      DatabaseOperationOutcome.PageRequested = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();

      ITriggerInput TriggerInput = IResourceTriggerService.TriggerInputFactory();
      TriggerInput.CrudOperationType = Common.Enum.RestEnum.CrudOperationType.Create;
      TriggerInput.InboundResource = Resource;
      TriggerInput.InboundResourceId = Resource.Id;
      TriggerInput.ResourceType = Resource.ResourceType;
      TriggerInput.DbTokenIndexList = null;
      ITriggerOutcome TriggerOutcomeBeforeUpdate = IResourceTriggerService.ProcessTrigger(TriggerInput);
      if (TriggerOutcomeBeforeUpdate.Report)
      {
        DatabaseOperationOutcome.TriggerOutCome = TriggerOutcomeBeforeUpdate;
        return DatabaseOperationOutcome;
      }
      else
      {
        var ResourceEntity = new ResCurrentType();
        DtoFhirRelease DtoFhirRelease = IFhirReleaseCache.GetFhirReleaseByFhirVersion(Hl7.Fhir.Model.ModelInfo.Version);
        CheckFhirReleaseSeedIssue(DtoFhirRelease);
        IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST, DtoFhirRelease.Id);
        this.PopulateResourceEntity(ResourceEntity, Resource);
        ResourceEntity.IsCurrent = true;
        this.CommonRepository.AddDbEntity(ResourceEntity);
        DatabaseOperationOutcome.SingleResourceRead = true;
        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType));
        return DatabaseOperationOutcome;
      }
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      ResCurrentType NewResourceEntity = new ResCurrentType();
      //Also specify which Includes to also load, only need token in this case;
      ResCurrentType ResourceHistoryEntity = LoadCurrentResourceEntity(Resource.Id, new SearchParamType[] { SearchParamType.Token });
      ITriggerInput TriggerInput = IResourceTriggerService.TriggerInputFactory();
      TriggerInput.CrudOperationType = Common.Enum.RestEnum.CrudOperationType.Update;
      TriggerInput.InboundResource = Resource;
      TriggerInput.InboundResourceId = Resource.Id;
      TriggerInput.ResourceType = Resource.ResourceType;
      TriggerInput.DbTokenIndexList = new List<DtoTokenIndex>();
      foreach (var Token in ResourceHistoryEntity.IndexTokenList)
      {
        TriggerInput.DbTokenIndexList.Add(new DtoTokenIndex() { ServiceSearchParameterId = Token.ServiceSearchParameterId, Code = Token.Code, System = Token.System });
      }
      ITriggerOutcome TriggerOutcome = IResourceTriggerService.ProcessTrigger(TriggerInput);
      if (TriggerOutcome.Report)
      {
        DatabaseOperationOutcome.TriggerOutCome = TriggerOutcome;
        return DatabaseOperationOutcome;
      }
      else
      {
        ResourceHistoryEntity.IsCurrent = false;
        DtoFhirRelease DtoFhirRelease = IFhirReleaseCache.GetFhirReleaseByFhirVersion(Hl7.Fhir.Model.ModelInfo.Version);
        CheckFhirReleaseSeedIssue(DtoFhirRelease);
        IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, NewResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT, DtoFhirRelease.Id);
        this.PopulateResourceEntity(NewResourceEntity, Resource);
        NewResourceEntity.IsCurrent = true;
        this.CommonRepository.AddDbEntity(NewResourceEntity);
        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
        DatabaseOperationOutcome.SingleResourceRead = true;

        //Delete all the old Resource's Indexes 
        DeleteAllResourceIndexesByResourceId(ResourceHistoryEntity.Id);
        return DatabaseOperationOutcome;
      }
    }

    public IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirId)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      var OldResourceEntity = this.LoadCurrentResourceEntity(FhirId, new SearchParamType[] { SearchParamType.Token });
      ITriggerInput TriggerInput = IResourceTriggerService.TriggerInputFactory();
      TriggerInput.CrudOperationType = Common.Enum.RestEnum.CrudOperationType.Delete;
      TriggerInput.InboundResource = null;
      TriggerInput.InboundResourceId = FhirId;
      TriggerInput.ResourceType = Common.Tools.ResourceNameResolutionSupport.GetResourceType(this.RepositoryResourceType.GetLiteral());
      TriggerInput.DbTokenIndexList = new List<DtoTokenIndex>();
      foreach (var Token in OldResourceEntity.IndexTokenList)
      {
        TriggerInput.DbTokenIndexList.Add(new DtoTokenIndex() { ServiceSearchParameterId = Token.ServiceSearchParameterId, Code = Token.Code, System = Token.System });
      }
      ITriggerOutcome TriggerOutcome = IResourceTriggerService.ProcessTrigger(TriggerInput);
      if (TriggerOutcome.Report)
      {
        DatabaseOperationOutcome.TriggerOutCome = TriggerOutcome;
      }
      else
      {
        var NewResourceEntity = new ResCurrentType();
        IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
        NewResourceEntity.IsCurrent = true;
        NewResourceEntity.IsDeleted = true;
        NewResourceEntity.LastUpdated = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
        NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        NewResourceEntity.Resource = null;
        NewResourceEntity.VersionId = NewDeletedResourceVersion;
        this.CommonRepository.AddDbEntity(NewResourceEntity);
        OldResourceEntity.IsCurrent = false;

        //Delete all the old Resource's Indexes
        DeleteAllResourceIndexesByResourceId(OldResourceEntity.Id);

        //this.Save();
        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdColectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      List<ResCurrentType> OldResourceEntityList = new List<ResCurrentType>();
      //Get each from the database and check for any issues from the triggers
      foreach (string ResourceId in ResourceIdCollection)
      {
        var OldResourceEntity = this.LoadCurrentResourceEntity(ResourceId, new SearchParamType[] { SearchParamType.Token });
        OldResourceEntityList.Add(OldResourceEntity);

        ITriggerInput TriggerInput = IResourceTriggerService.TriggerInputFactory();
        TriggerInput.CrudOperationType = Common.Enum.RestEnum.CrudOperationType.Delete;
        TriggerInput.InboundResource = null;
        TriggerInput.InboundResourceId = ResourceId;
        TriggerInput.ResourceType = Common.Tools.ResourceNameResolutionSupport.GetResourceType(this.RepositoryResourceType.GetLiteral());
        TriggerInput.DbTokenIndexList = new List<DtoTokenIndex>();
        foreach (var Token in OldResourceEntity.IndexTokenList)
        {
          TriggerInput.DbTokenIndexList.Add(new DtoTokenIndex() { ServiceSearchParameterId = Token.ServiceSearchParameterId, Code = Token.Code, System = Token.System });
        }
        ITriggerOutcome TriggerOutcome = IResourceTriggerService.ProcessTrigger(TriggerInput);
        if (TriggerOutcome.Report)
        {
          DatabaseOperationOutcome.TriggerOutCome = TriggerOutcome;
          return DatabaseOperationOutcome;
        }
      }

      //We have checked all Triggers and no issue so now delete the list.
      foreach (var OLdEntry in OldResourceEntityList)
      {
        var NewResourceEntity = new ResCurrentType();
        IndexSettingSupport.SetHistoryResourceEntity(OLdEntry, NewResourceEntity);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OLdEntry.VersionId);
        NewResourceEntity.IsCurrent = true;
        NewResourceEntity.IsDeleted = true;
        NewResourceEntity.LastUpdated = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
        NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        NewResourceEntity.Resource = null;
        NewResourceEntity.VersionId = NewDeletedResourceVersion;
        this.CommonRepository.AddDbEntity(NewResourceEntity);
        OLdEntry.IsCurrent = false;
        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
        //Delete all the old Resource's Indexes
        DeleteAllResourceIndexesByResourceId(OLdEntry.Id);
      }
      return DatabaseOperationOutcome;
    }


    private List<Expression<Func<ResCurrentType, object>>> GetIndexIncludeExpression(SearchParamType[] IncludeSearchParamType = null)
    {
      var IncludeList = new List<Expression<Func<ResCurrentType, object>>>();
      if (IncludeSearchParamType != null)
      {
        foreach (var Type in IncludeSearchParamType)
        {
          switch (Type)
          {
            case SearchParamType.Number | SearchParamType.Quantity:
              IncludeList.Add(x => x.IndexQuantityList);
              break;
            case SearchParamType.Date:
              IncludeList.Add(x => x.IndexDateTimeList);
              break;
            case SearchParamType.String:
              IncludeList.Add(x => x.IndexStringList);
              break;
            case SearchParamType.Token:
              IncludeList.Add(x => x.IndexTokenList);
              break;
            case SearchParamType.Reference:
              IncludeList.Add(x => x.IndexReferenceList);
              break;
            case SearchParamType.Composite:
              //Composite Search Parameters are actually made up of the other types.
              break;
            case SearchParamType.Uri:
              IncludeList.Add(x => x.IndexUriList);
              break;
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(Type.ToString(), (int)Type, typeof(SearchParamType));
          }
        }
      }
      else
      {
        IncludeList.Add(x => x.IndexQuantityList);
        IncludeList.Add(x => x.IndexDateTimeList);
        IncludeList.Add(x => x.IndexReferenceList);
        IncludeList.Add(x => x.IndexStringList);
        IncludeList.Add(x => x.IndexTokenList);
        IncludeList.Add(x => x.IndexUriList);

      }      
      return IncludeList;
    }

    public ResCurrentType LoadCurrentResourceEntity(string FhirId, SearchParamType[] IncludeSearchParamType = null)
    {
      var IncludeList = GetIndexIncludeExpression(IncludeSearchParamType);      
      var ResourceEntity = this.CommonRepository.GetDbEntityWithInclude(x => x.FhirId == FhirId & x.IsCurrent == true, IncludeList);
      return ResourceEntity;
    }
    
    public int GetTotalCurrentResourceCount()
    {
      return this.CommonRepository.GetDbALLCount<ResCurrentType>(x => x.IsCurrent == true);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue()
    {
      var LastEntity = IPyroDbContext.Set<ResCurrentType>().Max(x => x.LastUpdated);
      if (LastEntity != null)
        return LastEntity;
      else
        return null;
    }

    public void AddAndUpdateResourceIndexes(List<DtoServiceSearchParameterHeavy> ServiceSearchParameterHeavyList, System.Threading.CancellationTokenSource CancellationToken = null)
    {
      int ChunkSize = 100;
      int ProgressCount = 0;      
      var Count = this.CommonRepository.GetDbEntityAllQuery(x => x.IsCurrent == true & x.IsDeleted == false).Count();

      while (Count > ProgressCount)
      {                
        var EntityList = this.CommonRepository
                             .GetDbEntityAllQuery(x => x.IsCurrent == true & x.IsDeleted == false)
                             .OrderBy(x => x.Id)
                             .Skip(ProgressCount)
                             .Take(ChunkSize);

        foreach (var Entity in EntityList.ToList())
        {
          //If we have a CancellationToken then check it, this will throw and exception 
          //is a cancel is called for. The higher level task should roll-back the database transaction based on this exception type.  
          if (CancellationToken != null)
            CancellationToken.Token.ThrowIfCancellationRequested();

          foreach (var SearchParam in ServiceSearchParameterHeavyList)
          {
            DeleteAllResourceIndexesByResourceIdSearchParameterIdAndIndexType(Entity.Id, SearchParam.Id, SearchParam.Type);
          }

          //Only re-index SearchParameters that in a status of Active or Draft, although as above we do want to delete all. 
          ServiceSearchParameterHeavyList = ServiceSearchParameterHeavyList.Where(x => x.Status == PublicationStatus.Draft || x.Status == PublicationStatus.Active).ToList();

          Resource Resource = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromGZip(Entity.Resource);
          var LightList = ServiceSearchParameterHeavyList.Cast<Common.Search.DtoServiceSearchParameterLight>().ToList();
          _PopulateResourceEntity(Entity, Resource, LightList);
        }
        this.Save();
        ProgressCount = ProgressCount + ChunkSize;
      }
    }

    //Used when deleting Search Indexes on re-index events 
    public void DeleteAllResourceIndexesByResourceIdSearchParameterIdAndIndexType(int ResourceId, int SearchParameterId, SearchParamType SearchParamType)
    {
      int Counter = 0;
      switch (SearchParamType)
      {
        case SearchParamType.Number | SearchParamType.Quantity:
          Counter = Counter + DeleteIndexByResourceId<ResIndexQuantityType>(ResourceId);
          break;
        case SearchParamType.Date:
          Counter = Counter + DeleteIndexByResourceId<ResIndexDateTimeType>(ResourceId);
          break;
        case SearchParamType.String:
          Counter = Counter + DeleteIndexByResourceId<ResIndexStringType>(ResourceId);
          break;
        case SearchParamType.Token:
          Counter = Counter + DeleteIndexByResourceId<ResIndexTokenType>(ResourceId);
          break;
        case SearchParamType.Reference:
          Counter = Counter + DeleteIndexByResourceId<ResIndexReferenceType>(ResourceId);
          break;
        case SearchParamType.Composite:
          //No indexes for this type
          break;       
        case SearchParamType.Uri:
          Counter = Counter + DeleteIndexByResourceId<ResIndexUriType>(ResourceId);
          break;
        case SearchParamType.Special:
          //No indexes for this type
          break;
        default:
          break;
      }            
      this.Save();
    }

    //Used when deleting Search Indexes on Resource Delete or Update.
    public void DeleteAllResourceIndexesByResourceId(int ResourceId)
    {
      int Counter = 0;
      Counter = Counter + DeleteIndexByResourceId<ResIndexStringType>(ResourceId);
      Counter = Counter + DeleteIndexByResourceId<ResIndexTokenType>(ResourceId);
      Counter = Counter + DeleteIndexByResourceId<ResIndexUriType>(ResourceId);
      Counter = Counter + DeleteIndexByResourceId<ResIndexReferenceType>(ResourceId);
      Counter = Counter + DeleteIndexByResourceId<ResIndexQuantityType>(ResourceId);
      Counter = Counter + DeleteIndexByResourceId<ResIndexDateTimeType>(ResourceId);
      this.Save();
    }

    //Used when deleting Search Indexes on Resource Delete or Update.
    private int DeleteIndexByResourceId<IndexType>(int ResourceId)
      where IndexType : ResourceIndexNewBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    {
      int Counter = 0;
      foreach (int IdToDelete in IPyroDbContext.Set<IndexType>().Where(x => x.ResourceId == ResourceId).Select(c => c.Id).ToArray())
      {
        var DbIndex = new IndexType() { Id = IdToDelete };
        if (!IPyroDbContext.Set<IndexType>().Local.Any(l => l.Id == DbIndex.Id))
        {
          IPyroDbContext.Set<IndexType>().Attach(DbIndex);
        }
        else
        {
          DbIndex = IPyroDbContext.Set<IndexType>().Local.Single(l => l.Id == DbIndex.Id);
        }
        Counter++;
        IPyroDbContext.Set<IndexType>().Remove(DbIndex);
      }
      return Counter;
    }

    //Used when deleting Search Indexes on re-index events 
    private int DeleteIndexByResourceIdAndSearchParameterId<IndexType>(int ResourceId, int SearchParameterId)
      where IndexType : ResourceIndexNewBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    {
      int Counter = 0;
      var IndexList = IPyroDbContext.Set<IndexType>().Where(x => x.ResourceId == ResourceId & x.ServiceSearchParameterId == SearchParameterId).Select(c => c.Id).ToArray();
      foreach (int IdToDelete in IndexList)
      {
        var DbIndex = new IndexType() { Id = IdToDelete };
        if (!IPyroDbContext.Set<IndexType>().Local.Any(l => l.Id == DbIndex.Id))
        {
          IPyroDbContext.Set<IndexType>().Attach(DbIndex);
        }
        else
        {
          DbIndex = IPyroDbContext.Set<IndexType>().Local.Single(l => l.Id == DbIndex.Id);
        }
        Counter++;
        IPyroDbContext.Set<IndexType>().Remove(DbIndex);
      }
      return Counter;
    }

    public void PopulateResourceEntity(ResCurrentType ResourceEntity, Resource Resource)
    {
      IList<DtoServiceSearchParameterLight> SearchParmeters = IServiceSearchParameterCache.GetSearchParameterForResource(Resource.ResourceType.GetLiteral());
      _PopulateResourceEntity(ResourceEntity, Resource, SearchParmeters);
    }
    
    private void _PopulateResourceEntity(ResCurrentType ResourceEntity, Resource CurrentResource, IList<DtoServiceSearchParameterLight> SearchParametersList)
    {
      ITypedElement TypedElement = CurrentResource.ToTypedElement();
      //Hl7.Fhir.ElementModel.PocoNavigator Navigator = new Hl7.Fhir.ElementModel.PocoNavigator(CurrentResource);
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      foreach (DtoServiceSearchParameterLight SearchParameter in SearchParametersList)
      {
        //Composite searchParameters do not require populating as they are a Composite of other SearchParameter Types
        if (SearchParameter.Type != SearchParamType.Composite)
        {
          bool SetSearchParameterIndex = true;

          //We exclude the _id search parameter here because it is not indexed by the Token indexer but rather is on the Main resource table 
          //where the blob is stored. We must do this as all Token Codes are lower-cased and yet Resource Id is case sensitive.
          if (SearchParameter.Resource == Resource_ResourceName && SearchParameter.Name == SearchParameterForAllResourcesType._id.GetPyroLiteral())
          {
            SetSearchParameterIndex = false;
          }

          if (SetSearchParameterIndex)
          {
            string Expression = SearchParameter.Expression;
            if (SearchParameter.Resource == Resource_ResourceName)
            {
              //If the Expression is one with a parent resource of Resource then swap it for the actual current resource name
              //For example make 'Resource._tag' be 'Observation._tag' for Observation resources.
              Expression = CurrentResource.TypeName + SearchParameter.Expression.TrimStart(Resource_ResourceName.ToCharArray());
            }


            //New in FHIR R4 to handle fhir path resolve()
            //------------------------------------------------------------------------------------------
            //Add in the extended FhirPath functions from the fhir.net API as found here Hl7.Fhir.FhirPath.FhirEvaluationContext 
            //this adds extended support for some FHIR Path functions (hasValue, resolve, htmlchecks)                        
            //Hl7.FhirPath.FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
            //var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(Navigator);
            //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
            //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
            //oFhirEvaluationContext.Resolver = IPyroFhirPathResolve.Resolver;
            

            FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
            var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(TypedElement);
            //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
            //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
            oFhirEvaluationContext.ElementResolver = IPyroFhirPathResolve.Resolver;
            IEnumerable<ITypedElement> ResultList = null;
            
            try
            {
              ResultList = TypedElement.Select(Expression, oFhirEvaluationContext);
              //ResultList = Navigator.Select(Expression, oFhirEvaluationContext);
            }
            catch(Exception Exec)
            {
              string mesage = Exec.Message;
              ILog.Error(Exec, $"Seems to be a FHRI API FHIR Path internal issue. Have put logging here to investigate. Have seen it coming up intermittently on AuditEvent commits. Details: ResourceName: {CurrentResource.TypeName}, SearchParameterName: {SearchParameter.Name}, FhirPathExpression: {SearchParameter.Expression}");
            }

            //------------------------------------------------------------------------------------
            //This null check of ResultList is only here due to the exception issue above.
            if (ResultList != null)
            {
              foreach (ITypedElement oElement in ResultList)
              {
                if (oElement != null)
                {
                  switch (SearchParameter.Type)
                  {
                    case SearchParamType.Number:
                      {
                        ICollection<ResIndexQuantityType> ResourceIndexQuantity = IDbIndexSetterFactory.CreateNumberSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexQuantity != null)
                          ResourceEntity.IndexQuantityList.AddRange(ResourceIndexQuantity);
                        break;
                      }
                    case SearchParamType.Date:
                      {
                        ICollection<ResIndexDateTimeType> ResourceIndexDateTime = IDbIndexSetterFactory.CreateDateTimeSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexDateTime != null)
                          ResourceEntity.IndexDateTimeList.AddRange(ResourceIndexDateTime);
                        break;
                      }
                    case SearchParamType.String:
                      {
                        ICollection<ResIndexStringType> ResourceIndexString = IDbIndexSetterFactory.CreateStringSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexString != null)
                          ResourceEntity.IndexStringList.AddRange(ResourceIndexString);
                        break;
                      }
                    case SearchParamType.Token:
                      {
                        ICollection<ResIndexTokenType> ResourceIndexToken = IDbIndexSetterFactory.CreateTokenSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexToken != null)
                          ResourceEntity.IndexTokenList.AddRange(ResourceIndexToken);
                        break;
                      }
                    case SearchParamType.Reference:
                      {
                        ICollection<ResIndexReferenceType> ResourceIndexReference = IDbIndexSetterFactory.CreateReferenceSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexReference != null)
                          ResourceEntity.IndexReferenceList.AddRange(ResourceIndexReference);
                        break;
                      }
                    case SearchParamType.Composite:
                      {
                        //Composite searchParameters do not require populating as they are a Composite of other SearchParameter Types
                        break;
                      }
                    case SearchParamType.Quantity:
                      {
                        ICollection<ResIndexQuantityType> ResourceIndexQuantity = IDbIndexSetterFactory.CreateQuantitySetter().Set(oElement, SearchParameter);
                        if (ResourceIndexQuantity != null)
                          ResourceEntity.IndexQuantityList.AddRange(ResourceIndexQuantity);
                        break;
                      }
                    case SearchParamType.Uri:
                      {
                        ICollection<ResIndexUriType> ResourceIndexUri = IDbIndexSetterFactory.CreateUriSetter().Set(oElement, SearchParameter);
                        if (ResourceIndexUri != null)
                          ResourceEntity.IndexUriList.AddRange(ResourceIndexUri);
                        break;
                      }
                    default:
                      throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.Type.ToString(), (int)SearchParameter.Type, typeof(SearchParamType));
                  }
                }
              }
            }
          }
        }
      }
    }

    public LinqKit.ExpressionStarter<ResCurrentType> Predicate()
    {
      return this.CommonRepository.PredicateCurrentNotDeleted();
    }

    private void CheckFhirReleaseSeedIssue(DtoFhirRelease DtoFhirRelease)
    {
      if (DtoFhirRelease == null)
      {
        string Message = $"The _FhirRelease database table returned no entry for the fhir Version '{Hl7.Fhir.Model.ModelInfo.Version}', this typically occurs when the table was never seeded at the time of database creation. You must create the database using the Pyro.DbManager application and not rely on the service creating it on startup as the service will not seed the initial data required.` If this is true for you then drop your database and start again by running the Pyro.DbManager application first.";
        ILog.Fatal(Message);
        var OptOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
        throw new Common.Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OptOut, Message);
      }
    }
  }
}
