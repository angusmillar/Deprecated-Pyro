using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Support;
using Pyro.DataModel.IndexSetter;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;



namespace Pyro.DataModel.Repository
{
  public partial class ClinicalImpressionRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_ClinicalImpression, new() 
    where ResourceHistoryType :Res_ClinicalImpression_History, new()
  {
    public ClinicalImpressionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_ClinicalImpression_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.action_List);
      IncludeList.Add(x => x.finding_code_List);
      IncludeList.Add(x => x.finding_ref_List);
      IncludeList.Add(x => x.investigation_List);
      IncludeList.Add(x => x.plan_List);
      IncludeList.Add(x => x.problem_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.assessor_VersionId = null;      
      ResourceEntity.assessor_FhirId = null;      
      ResourceEntity.assessor_Type = null;      
      ResourceEntity.assessor_Url = null;      
      ResourceEntity.assessor_ServiceRootURL_StoreID = null;      
      ResourceEntity.context_VersionId = null;      
      ResourceEntity.context_FhirId = null;      
      ResourceEntity.context_Type = null;      
      ResourceEntity.context_Url = null;      
      ResourceEntity.context_ServiceRootURL_StoreID = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.previous_VersionId = null;      
      ResourceEntity.previous_FhirId = null;      
      ResourceEntity.previous_Type = null;      
      ResourceEntity.previous_Url = null;      
      ResourceEntity.previous_ServiceRootURL_StoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_VersionId = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ClinicalImpression_Index_action.RemoveRange(ResourceEntity.action_List);            
      _Context.Res_ClinicalImpression_Index_finding_code.RemoveRange(ResourceEntity.finding_code_List);            
      _Context.Res_ClinicalImpression_Index_finding_ref.RemoveRange(ResourceEntity.finding_ref_List);            
      _Context.Res_ClinicalImpression_Index_investigation.RemoveRange(ResourceEntity.investigation_List);            
      _Context.Res_ClinicalImpression_Index_plan.RemoveRange(ResourceEntity.plan_List);            
      _Context.Res_ClinicalImpression_Index_problem.RemoveRange(ResourceEntity.problem_List);            
      _Context.Res_ClinicalImpression_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_ClinicalImpression_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_ClinicalImpression_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Assessor != null)
      {
        if (ResourceTyped.Assessor is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Assessor, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.assessor_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Context, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.context_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Date != null)
      {
        if (ResourceTyped.DateElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.DateElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
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
              ResourseEntity.patient_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Previous != null)
      {
        if (ResourceTyped.Previous is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Previous, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.previous_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.StatusElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
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
              ResourseEntity.subject_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Action != null)
      {
        foreach (var item in ResourceTyped.Action)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_ClinicalImpression_Index_action();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ClinicalImpression_Index_action;
            if (Index != null)
            {
              ResourseEntity.action_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Finding)
      {
        if (item1.Item != null)
        {
          if (item1.Item is CodeableConcept)
          {
            CodeableConcept CodeableConcept = item1.Item as CodeableConcept;
            foreach (var item4 in CodeableConcept.Coding)
            {
              var Index = new Res_ClinicalImpression_Index_finding_code();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ClinicalImpression_Index_finding_code;
              ResourseEntity.finding_code_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Finding)
      {
        if (item1.Item != null)
        {
          if (item1.Item is ResourceReference)
          {
            var Index = new Res_ClinicalImpression_Index_finding_ref();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Item, Index, FhirRequestUri, this) as Res_ClinicalImpression_Index_finding_ref;
            if (Index != null)
            {
              ResourseEntity.finding_ref_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Investigations)
      {
        if (item1.Item != null)
        {
          foreach (var item in item1.Item)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_ClinicalImpression_Index_investigation();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ClinicalImpression_Index_investigation;
              if (Index != null)
              {
                ResourseEntity.investigation_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Plan != null)
      {
        foreach (var item in ResourceTyped.Plan)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_ClinicalImpression_Index_plan();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ClinicalImpression_Index_plan;
            if (Index != null)
            {
              ResourseEntity.plan_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Problem != null)
      {
        foreach (var item in ResourceTyped.Problem)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_ClinicalImpression_Index_problem();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ClinicalImpression_Index_problem;
            if (Index != null)
            {
              ResourseEntity.problem_List.Add(Index);
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
              var Index = new Res_ClinicalImpression_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ClinicalImpression_Index__profile;
              ResourseEntity._profile_List.Add(Index);
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
              var Index = new Res_ClinicalImpression_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ClinicalImpression_Index__security;
              ResourseEntity._security_List.Add(Index);
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
              var Index = new Res_ClinicalImpression_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ClinicalImpression_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

