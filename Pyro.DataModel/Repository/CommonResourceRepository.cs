using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Support;
using Pyro.DataModel.IndexSetter;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.Search;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;

namespace Pyro.DataModel.Repository
{
  public abstract class CommonResourceRepository<ResourceType, ResourceHistoryType> : CommonRepository, IResourceRepository
    where ResourceType : ResourceIndexBase, new()
    where ResourceHistoryType : ResourceIndexBase, new()
  {
    public CommonResourceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<ResourceType>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<ResourceType>(Predicate);
      var Query = DbGetAll<ResourceType>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, true)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResourceType();
      this.PopulateResourceEntity(ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), Resource, FhirRequestUri);
      this.DbAddEntity<ResourceType>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, true));
      return DatabaseOperationOutcome;      
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {
        DtoResource = DbGetAll<ResourceType>(x => x.FhirId == FhirResourceId)
          .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
          {
            FhirId = x.FhirId,
            IsDeleted = x.IsDeleted,
            IsCurrent = true,
            Version = x.versionId,
            Received = x.lastUpdated,
            Xml = x.XmlBlob
          }
          ).SingleOrDefault();
      }
      else
      {
        DtoResource = DbGetAll<ResourceType>(x => x.FhirId == FhirResourceId)
          .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
          {
            FhirId = x.FhirId,
            IsDeleted = x.IsDeleted,
            IsCurrent = true,
            Version = x.versionId,
            Received = x.lastUpdated
          }
          ).SingleOrDefault();
      }
      if (DtoResource != null)
        DatabaseOperationOutcome.ReturnedResourceList.Add(DtoResource);
      return DatabaseOperationOutcome;
    }
    
    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();

      if (!string.IsNullOrWhiteSpace(ResourceVersionNumber))
      {
        DatabaseOperationOutcome.SingleResourceRead = true;
        var ResourceHistoryEntity = DbGet<ResourceHistoryType>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, false));
        }
        else
        {
          var ResourceEntity = DbGet<ResourceType>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
          if (ResourceEntity != null)
            DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, true));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResourceHistoryType>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = DbGetALLCount<ResourceHistoryType>(Predicate);
        var Query = DbGetAll<ResourceHistoryType>(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, true)));

      }
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceHistoryEntity = new ResourceHistoryType();
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      this.AddResourceHistoryEntityToResourceEntity(ResourceEntity, ResourceHistoryEntity);
      //ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      ResourceEntity.XmlBlob = string.Empty;
      this.Save();
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceHistoryEntity = new ResourceHistoryType();
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      this.AddResourceHistoryEntityToResourceEntity(ResourceEntity, ResourceHistoryEntity);
      //ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, Resource, FhirRequestUri);
      return UpdateEntity(ResourceEntity);
    }
    
    // --- Abstract Methods -------------------------------------------------------------
    protected abstract void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity);

    protected abstract void ResetResourceEntity(ResourceType resourceEntity);

    protected abstract ResourceType LoadCurrentResourceEntity(string fhirResourceId);

    protected abstract void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri);
  }
}
