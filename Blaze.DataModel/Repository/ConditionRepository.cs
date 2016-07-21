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
  public partial class ConditionRepository : CommonRepository, IResourceRepository
  {

    public ConditionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Condition;
      var ResourceEntity = new Res_Condition();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Condition>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Condition;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Condition_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Condition_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Condition_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Condition_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Condition_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Condition>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Condition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Condition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Condition LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Condition, object>>>();
      IncludeList.Add(x => x.body_site_List);
      IncludeList.Add(x => x.category_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.evidence_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.severity_List);
      IncludeList.Add(x => x.stage_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Condition>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Condition ResourceEntity)
    {
      ResourceEntity.asserter_FhirId = null;      
      ResourceEntity.asserter_Type = null;      
      ResourceEntity.asserter_Url = null;      
      ResourceEntity.asserter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.clinicalstatus_Code = null;      
      ResourceEntity.clinicalstatus_System = null;      
      ResourceEntity.date_recorded_DateTimeOffset = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Condition_Index_body_site.RemoveRange(ResourceEntity.body_site_List);            
      _Context.Res_Condition_Index_category.RemoveRange(ResourceEntity.category_List);            
      _Context.Res_Condition_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_Condition_Index_evidence.RemoveRange(ResourceEntity.evidence_List);            
      _Context.Res_Condition_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Condition_Index_severity.RemoveRange(ResourceEntity.severity_List);            
      _Context.Res_Condition_Index_stage.RemoveRange(ResourceEntity.stage_List);            
      _Context.Res_Condition_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Condition_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Condition_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Condition ResourseEntity, string ResourceVersion, Condition ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Asserter != null)
      {
        if (ResourceTyped.Asserter is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Asserter, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.asserter_Type = Index.Type;
            ResourseEntity.asserter_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.asserter_Url = Index.Url;
            }
            else
            {
              ResourseEntity.asserter_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.ClinicalStatus != null)
      {
        if (ResourceTyped.ClinicalStatusElement is Hl7.Fhir.Model.Code)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ClinicalStatusElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.clinicalstatus_Code = Index.Code;
            ResourseEntity.clinicalstatus_System = Index.System;
          }
        }
      }

      if (ResourceTyped.DateRecorded != null)
      {
        if (ResourceTyped.DateRecordedElement is Hl7.Fhir.Model.Date)
        {
          DateIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DateRecordedElement) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.date_recorded_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Encounter != null)
      {
        if (ResourceTyped.Encounter is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Encounter, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.encounter_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Patient, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.BodySite != null)
      {
        foreach (var item3 in ResourceTyped.BodySite)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              Res_Condition_Index_body_site Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_body_site;
              ResourseEntity.body_site_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Category != null)
      {
        foreach (var item3 in ResourceTyped.Category.Coding)
        {
          Res_Condition_Index_category Index = null;
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Condition_Index_category;
          ResourseEntity.category_List.Add(Index);
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          Res_Condition_Index_code Index = null;
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Condition_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Evidence)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            Res_Condition_Index_evidence Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_evidence;
            ResourseEntity.evidence_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            Res_Condition_Index_identifier Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Condition_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Severity != null)
      {
        foreach (var item3 in ResourceTyped.Severity.Coding)
        {
          Res_Condition_Index_severity Index = null;
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Condition_Index_severity;
          ResourseEntity.severity_List.Add(Index);
        }
      }

      if (ResourceTyped.Stage != null)
      {
        if (ResourceTyped.Stage.Summary != null)
        {
          foreach (var item4 in ResourceTyped.Stage.Summary.Coding)
          {
            Res_Condition_Index_stage Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_stage;
            ResourseEntity.stage_List.Add(Index);
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
              Res_Condition_Index_profile Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_profile;
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
              Res_Condition_Index_security Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_security;
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
              Res_Condition_Index_tag Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Condition_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

