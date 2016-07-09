using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class TaskRepository : CommonRepository, IResourceRepository
  {

    public TaskRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Task;
      var ResourceEntity = new Res_Task();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Task>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Task;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Task_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Task_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_Task_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Task_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Task_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Task>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);        
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Blaze.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {        
        DtoResource = DbGetALL<Res_Task>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Task>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Task LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Task, object>>>();
      IncludeList.Add(x => x.failure_List);
      IncludeList.Add(x => x.performer_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Task>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Task ResourceEntity)
    {
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.creator_FhirId = null;      
      ResourceEntity.creator_Type = null;      
      ResourceEntity.creator_Url = null;      
      ResourceEntity.creator_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.definition_Uri = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.modified_DateTimeOffset = null;      
      ResourceEntity.owner_FhirId = null;      
      ResourceEntity.owner_Type = null;      
      ResourceEntity.owner_Url = null;      
      ResourceEntity.owner_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.parent_FhirId = null;      
      ResourceEntity.parent_Type = null;      
      ResourceEntity.parent_Url = null;      
      ResourceEntity.parent_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.priority_Code = null;      
      ResourceEntity.priority_System = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Task_Index_failure.RemoveRange(ResourceEntity.failure_List);            
      _Context.Res_Task_Index_performer.RemoveRange(ResourceEntity.performer_List);            
      _Context.Res_Task_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Task_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Task_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Task_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Task ResourseEntity, string ResourceVersion, Task ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Created != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.CreatedElement);
        if (Index != null)
        {
          ResourseEntity.created_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Creator != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Creator, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.creator_Type = Index.Type;
            ResourseEntity.creator_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.creator_Url = Index.Url;
            }
            else
            {
              ResourseEntity.creator_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Definition != null)
      {
        var Index = IndexSettingSupport.SetIndex<UriIndex>(new UriIndex(), ResourceTyped.DefinitionElement);
        if (Index != null)
        {
          ResourseEntity.definition_Uri = Index.Uri;
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Identifier);
        if (Index != null)
        {
          ResourseEntity.identifier_Code = Index.Code;
          ResourseEntity.identifier_System = Index.System;
        }
      }

      if (ResourceTyped.LastModified != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.LastModifiedElement);
        if (Index != null)
        {
          ResourseEntity.modified_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Owner != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Owner, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.owner_Type = Index.Type;
            ResourseEntity.owner_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.owner_Url = Index.Url;
            }
            else
            {
              ResourseEntity.owner_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Parent != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Parent, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.parent_Type = Index.Type;
            ResourseEntity.parent_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.parent_Url = Index.Url;
            }
            else
            {
              ResourseEntity.parent_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Priority != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.PriorityElement);
        if (Index != null)
        {
          ResourseEntity.priority_Code = Index.Code;
          ResourseEntity.priority_System = Index.System;
        }
      }

      if (ResourceTyped.Status != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.Subject != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Subject, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.subject_Type = Index.Type;
            ResourseEntity.subject_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.subject_Url = Index.Url;
            }
            else
            {
              ResourseEntity.subject_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.FailureReason != null)
      {
        foreach (var item3 in ResourceTyped.FailureReason.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Task_Index_failure(), item3) as Res_Task_Index_failure;
          ResourseEntity.failure_List.Add(Index);
        }
      }

      if (ResourceTyped.PerformerType != null)
      {
        foreach (var item3 in ResourceTyped.PerformerType)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Task_Index_performer(), item3) as Res_Task_Index_performer;
          ResourseEntity.performer_List.Add(Index);
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Task_Index_type(), item3) as Res_Task_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Task_Index_profile(), item4) as Res_Task_Index_profile;
            ResourseEntity.profile_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Security != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Security)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Task_Index_security(), item4) as Res_Task_Index_security;
            ResourseEntity.security_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Tag != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Tag)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Task_Index_tag(), item4) as Res_Task_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

