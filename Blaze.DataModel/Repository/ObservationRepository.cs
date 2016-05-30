using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
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

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Observation;
      var ResourceEntity = new Res_Observation();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Observation>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Observation;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Observation_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Observation_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
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
      var ResourceEntity = DbGet<Res_Observation>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
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
      ResourceEntity.value_concept_Code = null;      
      ResourceEntity.value_concept_System = null;      
      ResourceEntity.value_date_DateTimeOffset = null;      
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
      _Context.Res_Observation_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Observation_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Observation_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Observation ResourseEntity, string ResourceVersion, Observation ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

