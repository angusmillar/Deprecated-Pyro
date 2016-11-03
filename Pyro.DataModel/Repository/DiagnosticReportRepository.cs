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
  public partial class DiagnosticReportRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_DiagnosticReport, new() 
    where ResourceHistoryType :Res_DiagnosticReport_History, new()
  {
    public DiagnosticReportRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_DiagnosticReport_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.category_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.diagnosis_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.image_List);
      IncludeList.Add(x => x.performer_List);
      IncludeList.Add(x => x.request_List);
      IncludeList.Add(x => x.result_List);
      IncludeList.Add(x => x.specimen_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.encounter_VersionId = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_ServiceRootURL_StoreID = null;      
      ResourceEntity.issued_DateTimeOffset = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_VersionId = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_DiagnosticReport_Index_category.RemoveRange(ResourceEntity.category_List);            
      _Context.Res_DiagnosticReport_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_DiagnosticReport_Index_diagnosis.RemoveRange(ResourceEntity.diagnosis_List);            
      _Context.Res_DiagnosticReport_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_DiagnosticReport_Index_image.RemoveRange(ResourceEntity.image_List);            
      _Context.Res_DiagnosticReport_Index_performer.RemoveRange(ResourceEntity.performer_List);            
      _Context.Res_DiagnosticReport_Index_request.RemoveRange(ResourceEntity.request_List);            
      _Context.Res_DiagnosticReport_Index_result.RemoveRange(ResourceEntity.result_List);            
      _Context.Res_DiagnosticReport_Index_specimen.RemoveRange(ResourceEntity.specimen_List);            
      _Context.Res_DiagnosticReport_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_DiagnosticReport_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_DiagnosticReport_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DiagnosticReport;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Effective != null)
      {
        if (ResourceTyped.Effective is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimePeriodIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Effective, Index) as DateTimePeriodIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffsetLow;
            ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
          }
        }
      }

      if (ResourceTyped.Effective != null)
      {
        if (ResourceTyped.Effective is Hl7.Fhir.Model.Period)
        {
          var Index = new DateTimePeriodIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Effective, Index) as DateTimePeriodIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffsetLow;
            ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
          }
        }
      }

      if (ResourceTyped.Encounter != null)
      {
        if (ResourceTyped.Encounter is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Encounter, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.encounter_Type = Index.Type;
            ResourseEntity.encounter_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.encounter_Url = Index.Url;
            }
            else
            {
              ResourseEntity.encounter_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Issued != null)
      {
        if (ResourceTyped.IssuedElement is Hl7.Fhir.Model.Instant)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.IssuedElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.issued_DateTimeOffset = Index.DateTimeOffset;
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

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus>)
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

      if (ResourceTyped.Category != null)
      {
        foreach (var item3 in ResourceTyped.Category.Coding)
        {
          var Index = new Res_DiagnosticReport_Index_category();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DiagnosticReport_Index_category;
          ResourseEntity.category_List.Add(Index);
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = new Res_DiagnosticReport_Index_code();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DiagnosticReport_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      if (ResourceTyped.CodedDiagnosis != null)
      {
        foreach (var item3 in ResourceTyped.CodedDiagnosis)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_DiagnosticReport_Index_diagnosis();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticReport_Index_diagnosis;
              ResourseEntity.diagnosis_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_DiagnosticReport_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DiagnosticReport_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Image)
      {
        if (item1.Link != null)
        {
          if (item1.Link is ResourceReference)
          {
            var Index = new Res_DiagnosticReport_Index_image();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Link, Index, FhirRequestUri, this) as Res_DiagnosticReport_Index_image;
            if (Index != null)
            {
              ResourseEntity.image_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Performer != null)
      {
        foreach (var item in ResourceTyped.Performer)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DiagnosticReport_Index_performer();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticReport_Index_performer;
            if (Index != null)
            {
              ResourseEntity.performer_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Request != null)
      {
        foreach (var item in ResourceTyped.Request)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DiagnosticReport_Index_request();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticReport_Index_request;
            if (Index != null)
            {
              ResourseEntity.request_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Result != null)
      {
        foreach (var item in ResourceTyped.Result)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DiagnosticReport_Index_result();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticReport_Index_result;
            if (Index != null)
            {
              ResourseEntity.result_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Specimen != null)
      {
        foreach (var item in ResourceTyped.Specimen)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DiagnosticReport_Index_specimen();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticReport_Index_specimen;
            if (Index != null)
            {
              ResourseEntity.specimen_List.Add(Index);
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
              var Index = new Res_DiagnosticReport_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_DiagnosticReport_Index__profile;
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
              var Index = new Res_DiagnosticReport_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticReport_Index__security;
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
              var Index = new Res_DiagnosticReport_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticReport_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

