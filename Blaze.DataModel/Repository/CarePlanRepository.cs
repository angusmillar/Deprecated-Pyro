using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class CarePlanRepository : CommonRepository, IResourceRepository
  {

    public CarePlanRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as CarePlan;
      var ResourceEntity = new Res_CarePlan();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_CarePlan>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as CarePlan;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_CarePlan_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_CarePlan_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_CarePlan_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_CarePlan_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_CarePlan_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_CarePlan>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_CarePlan>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_CarePlan>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_CarePlan LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_CarePlan, object>>>();
      IncludeList.Add(x => x.activitycode_List);
      IncludeList.Add(x => x.activitydate_List);
      IncludeList.Add(x => x.activitydate_List);
      IncludeList.Add(x => x.activitydate_List);
      IncludeList.Add(x => x.activityreference_List);
      IncludeList.Add(x => x.condition_List);
      IncludeList.Add(x => x.goal_List);
      IncludeList.Add(x => x.participant_List);
      IncludeList.Add(x => x.performer_List);
      IncludeList.Add(x => x.relatedcode_List);
      IncludeList.Add(x => x.relatedplan_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_CarePlan>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_CarePlan ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_CarePlan_Index_activitycode.RemoveRange(ResourceEntity.activitycode_List);            
      _Context.Res_CarePlan_Index_activitydate.RemoveRange(ResourceEntity.activitydate_List);            
      _Context.Res_CarePlan_Index_activitydate.RemoveRange(ResourceEntity.activitydate_List);            
      _Context.Res_CarePlan_Index_activitydate.RemoveRange(ResourceEntity.activitydate_List);            
      _Context.Res_CarePlan_Index_activityreference.RemoveRange(ResourceEntity.activityreference_List);            
      _Context.Res_CarePlan_Index_condition.RemoveRange(ResourceEntity.condition_List);            
      _Context.Res_CarePlan_Index_goal.RemoveRange(ResourceEntity.goal_List);            
      _Context.Res_CarePlan_Index_participant.RemoveRange(ResourceEntity.participant_List);            
      _Context.Res_CarePlan_Index_performer.RemoveRange(ResourceEntity.performer_List);            
      _Context.Res_CarePlan_Index_relatedcode.RemoveRange(ResourceEntity.relatedcode_List);            
      _Context.Res_CarePlan_Index_relatedplan.RemoveRange(ResourceEntity.relatedplan_List);            
      _Context.Res_CarePlan_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_CarePlan_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_CarePlan_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_CarePlan ResourseEntity, string ResourceVersion, CarePlan ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Period != null)
      {
        if (ResourceTyped.Period is Hl7.Fhir.Model.Period)
        {
          var Index = new DatePeriodIndex();
          Index = IndexSetterFactory.Create(typeof(DatePeriodIndex)).Set(ResourceTyped.Period, Index) as DatePeriodIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffsetLow;
            ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
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

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Detail != null)
        {
          if (item1.Detail.Code != null)
          {
            foreach (var item5 in item1.Detail.Code.Coding)
            {
              var Index = new Res_CarePlan_Index_activitycode();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_CarePlan_Index_activitycode;
              ResourseEntity.activitycode_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Detail != null)
        {
          if (item1.Detail.Scheduled != null)
          {
            if (item1.Detail.Scheduled is Timing)
            {
              var Index = new Res_CarePlan_Index_activitydate();
              Index = IndexSetterFactory.Create(typeof(DatePeriodIndex)).Set(item1.Detail.Scheduled, Index) as Res_CarePlan_Index_activitydate;
              ResourseEntity.activitydate_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Detail != null)
        {
          if (item1.Detail.Scheduled != null)
          {
            if (item1.Detail.Scheduled is Period)
            {
              var Index = new Res_CarePlan_Index_activitydate();
              Index = IndexSetterFactory.Create(typeof(DatePeriodIndex)).Set(item1.Detail.Scheduled, Index) as Res_CarePlan_Index_activitydate;
              ResourseEntity.activitydate_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Detail != null)
        {
          if (item1.Detail.Scheduled != null)
          {
            if (item1.Detail.Scheduled is FhirString)
            {
              var Index = new Res_CarePlan_Index_activitydate();
              Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(item1.Detail.Scheduled, Index) as Res_CarePlan_Index_activitydate;
              ResourseEntity.activitydate_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Reference != null)
        {
          if (item1.Reference is ResourceReference)
          {
            var Index = new Res_CarePlan_Index_activityreference();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Reference, Index, FhirRequestUri, this) as Res_CarePlan_Index_activityreference;
            if (Index != null)
            {
              ResourseEntity.activityreference_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Addresses != null)
      {
        foreach (var item in ResourceTyped.Addresses)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_CarePlan_Index_condition();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_CarePlan_Index_condition;
            if (Index != null)
            {
              ResourseEntity.condition_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Goal != null)
      {
        foreach (var item in ResourceTyped.Goal)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_CarePlan_Index_goal();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_CarePlan_Index_goal;
            if (Index != null)
            {
              ResourseEntity.goal_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Member != null)
        {
          if (item1.Member is ResourceReference)
          {
            var Index = new Res_CarePlan_Index_participant();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Member, Index, FhirRequestUri, this) as Res_CarePlan_Index_participant;
            if (Index != null)
            {
              ResourseEntity.participant_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Activity)
      {
        if (item1.Detail != null)
        {
          if (item1.Detail.Performer != null)
          {
            foreach (var item in item1.Detail.Performer)
            {
              if (item is ResourceReference)
              {
                var Index = new Res_CarePlan_Index_performer();
                Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_CarePlan_Index_performer;
                if (Index != null)
                {
                  ResourseEntity.performer_List.Add(Index);
                }
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.RelatedPlan)
      {
        if (item1.Code != null)
        {
          if (item1.CodeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.CarePlan.CarePlanRelationship>)
          {
            var Index = new Res_CarePlan_Index_relatedcode();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.CodeElement, Index) as Res_CarePlan_Index_relatedcode;
            ResourseEntity.relatedcode_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.RelatedPlan)
      {
        if (item1.Plan != null)
        {
          if (item1.Plan is ResourceReference)
          {
            var Index = new Res_CarePlan_Index_relatedplan();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Plan, Index, FhirRequestUri, this) as Res_CarePlan_Index_relatedplan;
            if (Index != null)
            {
              ResourseEntity.relatedplan_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            if (item4 is Hl7.Fhir.Model.FhirUri)
            {
              var Index = new Res_CarePlan_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_CarePlan_Index_profile;
              ResourseEntity.profile_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Security != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Security)
          {
            if (item4 is Hl7.Fhir.Model.Coding)
            {
              var Index = new Res_CarePlan_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_CarePlan_Index_security;
              ResourseEntity.security_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Tag != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Tag)
          {
            if (item4 is Hl7.Fhir.Model.Coding)
            {
              var Index = new Res_CarePlan_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_CarePlan_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

