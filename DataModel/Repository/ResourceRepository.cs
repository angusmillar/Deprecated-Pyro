using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Model;
using Hl7.Fhir.Model;
using DataModel.ModelExtend;
using BusinessEntities;
using Dip.Interfaces;
using Dip.Interfaces.Repositories;

namespace DataModel.Repository
{
  class ResourceRepository : BaseRepository, IResourceRepository
  {
        
    public string AddResource(Hl7.Fhir.Model.Resource Resource)
    {
      var NewResource = this.PopulateResourceEntity(1, Resource);
      using (var scope = new TransactionScope())
      {
        _Context.Resource.Add(NewResource);
        this.Save();
        scope.Complete();
      }
      return Resource.Id;
    }

    public string UpdateResource(int ResourceVersion, Hl7.Fhir.Model.Resource FhirResource)
    {
      //##issues## Check  if (entry.State != EntityState.Modified) here to see if not change results in modified
      var NewInboundResource = this.PopulateResourceEntity(ResourceVersion, FhirResource);

      var DbResource = (from x in _Context.Resource
                          .Include(y => y.ResourceIdentity)                          
                        where x.IsCurrent == true && x.ResourceIdentity.FhirResourceId == FhirResource.Id
                        select x).SingleOrDefault();

      //The last update to the resource was a delete so no ValueSetResource to be found need to add one
      if (DbResource.IsDeleted == true)
      {
        using (var scope = new TransactionScope())
        {
          //== Add the ValueSet Structure as required =============================================          
          NewInboundResource.ResourceIdentity = DbResource.ResourceIdentity;
          DbResource.IsCurrent = false;
          //Plan Resource has nothing at present

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.

          NewInboundResource.Version = ResourceVersion;
          NewInboundResource.Received = (DateTimeOffset)FhirResource.Meta.LastUpdated;
          NewInboundResource.IsCurrent = true;
          NewInboundResource.ResourceIdentity = DbResource.ResourceIdentity;          
          _Context.Resource.Add(NewInboundResource);
          //DbValueSetResource.Resources.Add(InboundResource);

          this.Save();

          scope.Complete();
        }
        return string.Empty;

      }
      else
      {
        //The last update to the resource was a found not deleted
        using (var scope = new TransactionScope())
        {
          //== Update the ValueSet Structure as required =============================================

          //Value Set has nothing at present

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.

          NewInboundResource.Version = ResourceVersion;
          NewInboundResource.Received = (DateTimeOffset)FhirResource.Meta.LastUpdated;
          NewInboundResource.IsCurrent = true;
          NewInboundResource.ResourceIdentity = DbResource.ResourceIdentity;

          _Context.Resource.Add(NewInboundResource);

          //Set the past Current Resource to not current
          DbResource.IsCurrent = false;

          this.Save();

          scope.Complete();
        }
        return string.Empty;
      }
    }

    public void UpdateResouceAsDeleted(string FhirResourceId)
    {
      var DbResource = (from r in _Context.Resource
                                .Include(x => x.ResourceIdentity)
                        where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true
                        select r).FirstOrDefault();

      using (var scope = new TransactionScope())
      {

        //=== Clean Up ==========================================================
        DbResource.IsCurrent = false;
                
        //=== Add Delete Record =================================================        
        var NewResource = new DataModel.Model.Resource();
        NewResource.ResourceType = DbResource.ResourceType;
        NewResource.IsDeleted = true;
        NewResource.IsCurrent = true;
        NewResource.Xml = string.Empty;
        NewResource.Version = DbResource.Version + 1;
        NewResource.Received = DateTimeOffset.Now;
        NewResource.ResourceIdentity = DbResource.ResourceIdentity;

        _Context.Resource.Add(NewResource);

        this.Save();

        scope.Complete();
      }
    }

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

    private Model.Resource PopulateResourceEntity(int ResourceVersion, Hl7.Fhir.Model.Resource Resource)
    {

      var ResourceIdentity = new Model.ResourceIdentity();
      ResourceIdentity.FhirResourceId = Resource.Id;

      var ResourceXml = new DataModel.Model.Resource();
      ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Resource);
      ResourceXml.Received = (DateTimeOffset)Resource.Meta.LastUpdated;
      ResourceXml.Version = ResourceVersion;
      ResourceXml.IsCurrent = true;
      ResourceXml.IsDeleted = false;
      ResourceXml.ResourceType = DtoEnums.GetBlazeSupportedResorceTypeByFhirResourceTypeDictionary()[Resource.ResourceType];
      ResourceXml.ResourceIdentity = ResourceIdentity;

      return ResourceXml;
    }

    #region Constructor
    public ResourceRepository(BlazeDbContext Context)
    {
      _Context = Context;
    }
    #endregion

  }
}
