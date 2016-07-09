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
  public partial class ClinicalImpressionRepository : CommonRepository, IResourceRepository
  {

    public ClinicalImpressionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourceEntity = new Res_ClinicalImpression();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ClinicalImpression>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ClinicalImpression_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ClinicalImpression_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_ClinicalImpression_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ClinicalImpression_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_ClinicalImpression_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ClinicalImpression LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ClinicalImpression, object>>>();
      IncludeList.Add(x => x.action_List);
      IncludeList.Add(x => x.finding_List);
      IncludeList.Add(x => x.investigation_List);
      IncludeList.Add(x => x.plan_List);
      IncludeList.Add(x => x.problem_List);
      IncludeList.Add(x => x.resolved_List);
      IncludeList.Add(x => x.ruledout_List);
      IncludeList.Add(x => x.trigger_code_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ClinicalImpression>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ClinicalImpression ResourceEntity)
    {
      ResourceEntity.assessor_FhirId = null;      
      ResourceEntity.assessor_Type = null;      
      ResourceEntity.assessor_Url = null;      
      ResourceEntity.assessor_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.previous_FhirId = null;      
      ResourceEntity.previous_Type = null;      
      ResourceEntity.previous_Url = null;      
      ResourceEntity.previous_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.trigger_FhirId = null;      
      ResourceEntity.trigger_Type = null;      
      ResourceEntity.trigger_Url = null;      
      ResourceEntity.trigger_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ClinicalImpression_Index_action.RemoveRange(ResourceEntity.action_List);            
      _Context.Res_ClinicalImpression_Index_finding.RemoveRange(ResourceEntity.finding_List);            
      _Context.Res_ClinicalImpression_Index_investigation.RemoveRange(ResourceEntity.investigation_List);            
      _Context.Res_ClinicalImpression_Index_plan.RemoveRange(ResourceEntity.plan_List);            
      _Context.Res_ClinicalImpression_Index_problem.RemoveRange(ResourceEntity.problem_List);            
      _Context.Res_ClinicalImpression_Index_resolved.RemoveRange(ResourceEntity.resolved_List);            
      _Context.Res_ClinicalImpression_Index_ruledout.RemoveRange(ResourceEntity.ruledout_List);            
      _Context.Res_ClinicalImpression_Index_trigger_code.RemoveRange(ResourceEntity.trigger_code_List);            
      _Context.Res_ClinicalImpression_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ClinicalImpression_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ClinicalImpression_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ClinicalImpression ResourseEntity, string ResourceVersion, ClinicalImpression ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Assessor != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Assessor, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.assessor_Type = Index.Type;
            ResourseEntity.assessor_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.assessor_Url = Index.Url;
            }
            else
            {
              ResourseEntity.assessor_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Date != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.DateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
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

      if (ResourceTyped.Previous != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Previous, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.previous_Type = Index.Type;
            ResourseEntity.previous_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.previous_Url = Index.Url;
            }
            else
            {
              ResourseEntity.previous_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
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

      if (ResourceTyped.Trigger != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Trigger, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.trigger_Type = Index.Type;
            ResourseEntity.trigger_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.trigger_Url = Index.Url;
            }
            else
            {
              ResourseEntity.trigger_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Action != null)
      {
        foreach (var item in ResourceTyped.Action)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ClinicalImpression_Index_action(), item, FhirRequestUri, this) as Res_ClinicalImpression_Index_action;
          if (Index != null)
          {
            ResourseEntity.action_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Finding)
      {
        if (item1.Item != null)
        {
          foreach (var item4 in item1.Item.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_finding(), item4) as Res_ClinicalImpression_Index_finding;
            ResourseEntity.finding_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Investigations)
      {
        if (item1.Item != null)
        {
          foreach (var item in item1.Item)
          {
            var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ClinicalImpression_Index_investigation(), item, FhirRequestUri, this) as Res_ClinicalImpression_Index_investigation;
            if (Index != null)
            {
              ResourseEntity.investigation_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Plan != null)
      {
        foreach (var item in ResourceTyped.Plan)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ClinicalImpression_Index_plan(), item, FhirRequestUri, this) as Res_ClinicalImpression_Index_plan;
          if (Index != null)
          {
            ResourseEntity.plan_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Problem != null)
      {
        foreach (var item in ResourceTyped.Problem)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_ClinicalImpression_Index_problem(), item, FhirRequestUri, this) as Res_ClinicalImpression_Index_problem;
          if (Index != null)
          {
            ResourseEntity.problem_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Resolved != null)
      {
        foreach (var item3 in ResourceTyped.Resolved)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_resolved(), item4) as Res_ClinicalImpression_Index_resolved;
              ResourseEntity.resolved_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.RuledOut)
      {
        if (item1.Item != null)
        {
          foreach (var item4 in item1.Item.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_ruledout(), item4) as Res_ClinicalImpression_Index_ruledout;
            ResourseEntity.ruledout_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Trigger != null)
      {
        if (ResourceTyped.Trigger is CodeableConcept)
        {
          CodeableConcept CodeableConcept = ResourceTyped.Trigger as CodeableConcept;
          foreach (var item3 in CodeableConcept.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_trigger_code(), item3) as Res_ClinicalImpression_Index_trigger_code;
            ResourseEntity.trigger_code_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ClinicalImpression_Index_profile(), item4) as Res_ClinicalImpression_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_security(), item4) as Res_ClinicalImpression_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ClinicalImpression_Index_tag(), item4) as Res_ClinicalImpression_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

