using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Dip.Interfaces;
using Dip.Interfaces.Repositories;

namespace DataModel.Repository
{
  class ResourceRepository : BaseRepository, IResourceRepository
  {

    public int GetResourceCurrentVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true).Version;
    }

    public IDatabaseOperationOutcome GetCurrentResourceList(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = this.GetCurrentResource(FhirResourceId, CurrentResourceType);
      if (DatabaseOperationOutcome.ResourceMatchingSearch != null)
      {
        DatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>();
        DatabaseOperationOutcome.ResourcesMatchingSearchList.Add(DatabaseOperationOutcome.ResourceMatchingSearch);
        DatabaseOperationOutcome.ResourceMatchingSearch = null;
        DatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
        DatabaseOperationOutcome.PageRequested = 1;
        DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
        DatabaseOperationOutcome.SingleResourceRead = false;       
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetCurrentResource(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
      IDatabaseOperationOutcome oDatabaseOperationOutcome = new DatabaseOperationOutcome();
      var oResource = (from x in _Context.Resource where x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == false && x.ResourceType == CurrentResourceType select x).SingleOrDefault();
      if (oResource != null)
      {
        oDatabaseOperationOutcome.ResourceMatchingSearch = new DtoResource();
        oDatabaseOperationOutcome.ResourceMatchingSearch.FhirResourceType = oResource.ResourceType;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Id = oResource.Id;
        oDatabaseOperationOutcome.ResourceMatchingSearch.IsCurrent = oResource.IsCurrent;
        oDatabaseOperationOutcome.ResourceMatchingSearch.IsDeleted = oResource.IsDeleted;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Received = oResource.Received;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Version = oResource.Version;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Xml = oResource.Xml;
      }
      return oDatabaseOperationOutcome;
    }

    public DtoResource GetCurrentResourceWithOutXml(string FhirResourceId)
    {
      DtoResource oDtoResource = null;
      var oResource = (from x in _Context.Resource 
                       where x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true 
                       select 
                       new 
                       { 
                         Id = x.Id,
                         ResourceType = x.ResourceType,
                         IsCurrent = x.IsCurrent,
                         IsDeleted = x.IsDeleted,
                         Received = x.Received,
                         Version = x.Version
                       }
                       ).SingleOrDefault();


      if (oResource != null)
      {
        oDtoResource = new DtoResource();
        oDtoResource.Id = oResource.Id;
        oDtoResource.FhirResourceType = oResource.ResourceType;
        oDtoResource.IsCurrent = oResource.IsCurrent;
        oDtoResource.IsDeleted = oResource.IsDeleted;
        oDtoResource.Received = oResource.Received;
        oDtoResource.Version = oResource.Version;        
      }
      return oDtoResource;
    }

    public bool IsCurrentResourceDeleted(string FhirResourceId)
    {
      if (_Context.Resource.Any(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true))
        return true;
      else
        return false;
    }

    public int LastDeletedResourceVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true).Version;
    }

    public DtoEnums.SupportedFhirResource GetSupportedResourceTypeForFhirResourceId(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true).ResourceType;
    }

    public bool ResourceExists(string FhirResourceId)
    {
      if (_Context.ResourceIdentity.Any(x => x.FhirResourceId == FhirResourceId))
        return true;
      else
        return false;
    }

    #region Constructor
    public ResourceRepository(BlazeDbContext Context)
    {
      _Context = Context;
    }
    #endregion

  }
}
