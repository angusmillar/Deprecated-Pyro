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
  public partial class EncounterRepository : CommonRepository, IResourceRepository
  {

    public EncounterRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Encounter;
      var ResourceEntity = new Res_Encounter();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Encounter>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Encounter;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Encounter_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Encounter_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_Encounter_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Encounter_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_Encounter>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Encounter LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Encounter, object>>>();
      IncludeList.Add(x => x.condition_List);
      IncludeList.Add(x => x.episodeofcare_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.incomingreferral_List);
      IncludeList.Add(x => x.indication_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.location_period_List);
      IncludeList.Add(x => x.participant_List);
      IncludeList.Add(x => x.participant_type_List);
      IncludeList.Add(x => x.practitioner_List);
      IncludeList.Add(x => x.procedure_List);
      IncludeList.Add(x => x.reason_List);
      IncludeList.Add(x => x.special_arrangement_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Encounter>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Encounter ResourceEntity)
    {
      ResourceEntity.appointment_FhirId = null;      
      ResourceEntity.appointment_Type = null;      
      ResourceEntity.appointment_Url = null;      
      ResourceEntity.appointment_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.length_Number = null;      
      ResourceEntity.part_of_FhirId = null;      
      ResourceEntity.part_of_Type = null;      
      ResourceEntity.part_of_Url = null;      
      ResourceEntity.part_of_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Encounter_Index_condition.RemoveRange(ResourceEntity.condition_List);            
      _Context.Res_Encounter_Index_episodeofcare.RemoveRange(ResourceEntity.episodeofcare_List);            
      _Context.Res_Encounter_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Encounter_Index_incomingreferral.RemoveRange(ResourceEntity.incomingreferral_List);            
      _Context.Res_Encounter_Index_indication.RemoveRange(ResourceEntity.indication_List);            
      _Context.Res_Encounter_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_Encounter_Index_location_period.RemoveRange(ResourceEntity.location_period_List);            
      _Context.Res_Encounter_Index_participant.RemoveRange(ResourceEntity.participant_List);            
      _Context.Res_Encounter_Index_participant_type.RemoveRange(ResourceEntity.participant_type_List);            
      _Context.Res_Encounter_Index_practitioner.RemoveRange(ResourceEntity.practitioner_List);            
      _Context.Res_Encounter_Index_procedure.RemoveRange(ResourceEntity.procedure_List);            
      _Context.Res_Encounter_Index_reason.RemoveRange(ResourceEntity.reason_List);            
      _Context.Res_Encounter_Index_special_arrangement.RemoveRange(ResourceEntity.special_arrangement_List);            
      _Context.Res_Encounter_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Encounter_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Encounter_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Encounter_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Encounter ResourseEntity, string ResourceVersion, Encounter ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

