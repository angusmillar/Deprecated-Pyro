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
  public partial class ObservationRepository : CommonRepository, IResourceRepository
  {

    public ObservationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Observation;
      var ResourceEntity = new Res_Observation();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Observation>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Observation;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Observation_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Observation_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Observation_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Observation_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Observation_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Observation>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Observation>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Observation>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Observation LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Observation, object>>>();
      IncludeList.Add(x => x.category_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.component_code_List);
      IncludeList.Add(x => x.component_data_absent_reason_List);
      IncludeList.Add(x => x.component_value_concept_List);
      IncludeList.Add(x => x.component_value_quantity_List);
      IncludeList.Add(x => x.component_value_string_List);
      IncludeList.Add(x => x.data_absent_reason_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.performer_List);
      IncludeList.Add(x => x.related_target_List);
      IncludeList.Add(x => x.related_type_List);
      IncludeList.Add(x => x.value_concept_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Observation>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Observation ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.device_FhirId = null;      
      ResourceEntity.device_Type = null;      
      ResourceEntity.device_Url = null;      
      ResourceEntity.device_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.specimen_FhirId = null;      
      ResourceEntity.specimen_Type = null;      
      ResourceEntity.specimen_Url = null;      
      ResourceEntity.specimen_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.value_date_DateTimeOffset = null;      
      ResourceEntity.value_quantity_Comparator = null;      
      ResourceEntity.value_quantity_Quantity = null;      
      ResourceEntity.value_quantity_System = null;      
      ResourceEntity.value_quantity_Code = null;      
      ResourceEntity.value_string_String = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Observation_Index_category.RemoveRange(ResourceEntity.category_List);            
      _Context.Res_Observation_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_Observation_Index_component_code.RemoveRange(ResourceEntity.component_code_List);            
      _Context.Res_Observation_Index_component_data_absent_reason.RemoveRange(ResourceEntity.component_data_absent_reason_List);            
      _Context.Res_Observation_Index_component_value_concept.RemoveRange(ResourceEntity.component_value_concept_List);            
      _Context.Res_Observation_Index_component_value_quantity.RemoveRange(ResourceEntity.component_value_quantity_List);            
      _Context.Res_Observation_Index_component_value_string.RemoveRange(ResourceEntity.component_value_string_List);            
      _Context.Res_Observation_Index_data_absent_reason.RemoveRange(ResourceEntity.data_absent_reason_List);            
      _Context.Res_Observation_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Observation_Index_performer.RemoveRange(ResourceEntity.performer_List);            
      _Context.Res_Observation_Index_related_target.RemoveRange(ResourceEntity.related_target_List);            
      _Context.Res_Observation_Index_related_type.RemoveRange(ResourceEntity.related_type_List);            
      _Context.Res_Observation_Index_value_concept.RemoveRange(ResourceEntity.value_concept_List);            
      _Context.Res_Observation_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Observation_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Observation_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Observation ResourseEntity, string ResourceVersion, Observation ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Effective != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Effective);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Device != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Device, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.device_Type = Index.Type;
            ResourseEntity.device_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.device_Url = Index.Url;
            }
            else
            {
              ResourseEntity.device_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Encounter != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Encounter, FhirRequestUri, this);
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

      if (ResourceTyped.Subject != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Subject, FhirRequestUri, this);
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

      if (ResourceTyped.Specimen != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Specimen, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.specimen_Type = Index.Type;
            ResourseEntity.specimen_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.specimen_Url = Index.Url;
            }
            else
            {
              ResourseEntity.specimen_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
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

      if (ResourceTyped.Value != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Value);
        if (Index != null)
        {
          ResourseEntity.value_date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Value != null)
      {
        var Index = IndexSettingSupport.SetIndex<QuantityIndex>(new QuantityIndex(), ResourceTyped.Value);
        if (Index != null)
        {
          ResourseEntity.value_quantity_Code = Index.Code;
          ResourseEntity.value_quantity_System = Index.System;
          ResourseEntity.value_quantity_Quantity = Index.Quantity;
        }
      }

      if (ResourceTyped.Value != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.Value);
        if (Index != null)
        {
          ResourseEntity.value_string_String = Index.String;
        }
      }

      if (ResourceTyped.Category != null)
      {
        foreach (var item3 in ResourceTyped.Category.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_category(), item3) as Res_Observation_Index_category;
          ResourseEntity.category_List.Add(Index);
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_code(), item3) as Res_Observation_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Component)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_component_code(), item4) as Res_Observation_Index_component_code;
            ResourseEntity.component_code_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Component)
      {
        if (item1.DataAbsentReason != null)
        {
          foreach (var item4 in item1.DataAbsentReason.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_component_data_absent_reason(), item4) as Res_Observation_Index_component_data_absent_reason;
            ResourseEntity.component_data_absent_reason_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Component)
      {
        if (item1.Value != null)
        {
          if (item1.Value is CodeableConcept)
          {
            CodeableConcept CodeableConcept = item1.Value as CodeableConcept;
            foreach (var item4 in CodeableConcept.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_component_value_concept(), item4) as Res_Observation_Index_component_value_concept;
              ResourseEntity.component_value_concept_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Component)
      {
        if (item1.Value != null)
        {
          var Index = IndexSettingSupport.SetIndex<QuantityIndex>(new Res_Observation_Index_component_value_quantity(), item1.Value) as Res_Observation_Index_component_value_quantity;
          ResourseEntity.component_value_quantity_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Component)
      {
        if (item1.Value != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Observation_Index_component_value_string(), item1.Value) as Res_Observation_Index_component_value_string;
          ResourseEntity.component_value_string_List.Add(Index);
        }
      }

      if (ResourceTyped.DataAbsentReason != null)
      {
        foreach (var item3 in ResourceTyped.DataAbsentReason.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_data_absent_reason(), item3) as Res_Observation_Index_data_absent_reason;
          ResourseEntity.data_absent_reason_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_identifier(), item3) as Res_Observation_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      if (ResourceTyped.Performer != null)
      {
        foreach (var item in ResourceTyped.Performer)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Observation_Index_performer(), item, FhirRequestUri, this) as Res_Observation_Index_performer;
          if (Index != null)
          {
            ResourseEntity.performer_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Related)
      {
        if (item1.Target != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Observation_Index_related_target(), item1.Target, FhirRequestUri, this) as Res_Observation_Index_related_target;
          if (Index != null)
          {
            ResourseEntity.related_target_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Related)
      {
        if (item1.Type != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_related_type(), item1.TypeElement) as Res_Observation_Index_related_type;
          ResourseEntity.related_type_List.Add(Index);
        }
      }

      if (ResourceTyped.Value != null)
      {
        if (ResourceTyped.Value is CodeableConcept)
        {
          CodeableConcept CodeableConcept = ResourceTyped.Value as CodeableConcept;
          foreach (var item3 in CodeableConcept.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_value_concept(), item3) as Res_Observation_Index_value_concept;
            ResourseEntity.value_concept_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Observation_Index_profile(), item4) as Res_Observation_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_security(), item4) as Res_Observation_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Observation_Index_tag(), item4) as Res_Observation_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

