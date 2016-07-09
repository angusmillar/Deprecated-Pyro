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
  public partial class ReferralRequestRepository : CommonRepository, IResourceRepository
  {

    public ReferralRequestRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ReferralRequest;
      var ResourceEntity = new Res_ReferralRequest();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ReferralRequest>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ReferralRequest;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ReferralRequest_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ReferralRequest_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_ReferralRequest_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ReferralRequest_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_ReferralRequest_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ReferralRequest>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_ReferralRequest>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_ReferralRequest>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ReferralRequest LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ReferralRequest, object>>>();
      IncludeList.Add(x => x.basedon_List);
      IncludeList.Add(x => x.priority_List);
      IncludeList.Add(x => x.recipient_List);
      IncludeList.Add(x => x.specialty_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ReferralRequest>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ReferralRequest ResourceEntity)
    {
      ResourceEntity.category_Code = null;      
      ResourceEntity.category_System = null;      
      ResourceEntity.context_FhirId = null;      
      ResourceEntity.context_Type = null;      
      ResourceEntity.context_Url = null;      
      ResourceEntity.context_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.parent_Code = null;      
      ResourceEntity.parent_System = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.requester_FhirId = null;      
      ResourceEntity.requester_Type = null;      
      ResourceEntity.requester_Url = null;      
      ResourceEntity.requester_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ReferralRequest_Index_basedon.RemoveRange(ResourceEntity.basedon_List);            
      _Context.Res_ReferralRequest_Index_priority.RemoveRange(ResourceEntity.priority_List);            
      _Context.Res_ReferralRequest_Index_recipient.RemoveRange(ResourceEntity.recipient_List);            
      _Context.Res_ReferralRequest_Index_specialty.RemoveRange(ResourceEntity.specialty_List);            
      _Context.Res_ReferralRequest_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_ReferralRequest_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ReferralRequest_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ReferralRequest_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ReferralRequest ResourseEntity, string ResourceVersion, ReferralRequest ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Category != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.CategoryElement);
        if (Index != null)
        {
          ResourseEntity.category_Code = Index.Code;
          ResourseEntity.category_System = Index.System;
        }
      }

      if (ResourceTyped.Context != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Context, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.context_Type = Index.Type;
            ResourseEntity.context_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.context_Url = Index.Url;
            }
            else
            {
              ResourseEntity.context_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Authored != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.AuthoredElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Parent != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Parent);
        if (Index != null)
        {
          ResourseEntity.parent_Code = Index.Code;
          ResourseEntity.parent_System = Index.System;
        }
      }

      if (ResourceTyped.Patient != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Patient, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.patient_Type = Index.Type;
            ResourseEntity.patient_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.patient_Url = Index.Url;
            }
            else
            {
              ResourseEntity.patient_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Requester != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Requester, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.requester_Type = Index.Type;
            ResourseEntity.requester_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.requester_Url = Index.Url;
            }
            else
            {
              ResourseEntity.requester_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
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

      if (ResourceTyped.BasedOn != null)
      {
        foreach (var item in ResourceTyped.BasedOn)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ReferralRequest_Index_basedon(), item, FhirRequestUri, this) as Res_ReferralRequest_Index_basedon;
          if (Index != null)
          {
            ResourseEntity.basedon_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Priority != null)
      {
        foreach (var item3 in ResourceTyped.Priority.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ReferralRequest_Index_priority(), item3) as Res_ReferralRequest_Index_priority;
          ResourseEntity.priority_List.Add(Index);
        }
      }

      if (ResourceTyped.Recipient != null)
      {
        foreach (var item in ResourceTyped.Recipient)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ReferralRequest_Index_recipient(), item, FhirRequestUri, this) as Res_ReferralRequest_Index_recipient;
          if (Index != null)
          {
            ResourseEntity.recipient_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Specialty != null)
      {
        foreach (var item3 in ResourceTyped.Specialty.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ReferralRequest_Index_specialty(), item3) as Res_ReferralRequest_Index_specialty;
          ResourseEntity.specialty_List.Add(Index);
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ReferralRequest_Index_type(), item3) as Res_ReferralRequest_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ReferralRequest_Index_profile(), item4) as Res_ReferralRequest_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ReferralRequest_Index_security(), item4) as Res_ReferralRequest_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ReferralRequest_Index_tag(), item4) as Res_ReferralRequest_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

