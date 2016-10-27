using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.Search;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class ClinicalImpressionRepository : CommonRepository, IResourceRepository
  {
    public ClinicalImpressionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_ClinicalImpression>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_ClinicalImpression>(Predicate);
      var Query = DbGetAll<Res_ClinicalImpression>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);      
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceCount = TotalRecordCount;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourceEntity = new Res_ClinicalImpression();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ClinicalImpression>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
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
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
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
      ResourceEntity.XmlBlob = string.Empty;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_ClinicalImpression_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);        
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
        DtoResource = DbGetAll<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ClinicalImpression LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ClinicalImpression, object>>>();
      IncludeList.Add(x => x.action_List);
      IncludeList.Add(x => x.finding_code_List);
      IncludeList.Add(x => x.finding_ref_List);
      IncludeList.Add(x => x.investigation_List);
      IncludeList.Add(x => x.plan_List);
      IncludeList.Add(x => x.problem_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ClinicalImpression>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ClinicalImpression ResourceEntity)
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

    private void PopulateResourceEntity(Res_ClinicalImpression ResourseEntity, string ResourceVersion, ClinicalImpression ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
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

