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
  public partial class DiagnosticOrderRepository : CommonRepository, IResourceRepository
  {

    public DiagnosticOrderRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DiagnosticOrder;
      var ResourceEntity = new Res_DiagnosticOrder();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_DiagnosticOrder>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DiagnosticOrder;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_DiagnosticOrder_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DiagnosticOrder_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_DiagnosticOrder_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DiagnosticOrder_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_DiagnosticOrder LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_DiagnosticOrder, object>>>();
      IncludeList.Add(x => x.actor_List);
      IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.event_date_List);
      IncludeList.Add(x => x.event_status_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.item_date_List);
      IncludeList.Add(x => x.item_past_status_List);
      IncludeList.Add(x => x.item_status_List);
      IncludeList.Add(x => x.specimen_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_DiagnosticOrder>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_DiagnosticOrder ResourceEntity)
    {
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.orderer_FhirId = null;      
      ResourceEntity.orderer_Type = null;      
      ResourceEntity.orderer_Url = null;      
      ResourceEntity.orderer_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_DiagnosticOrder_Index_actor.RemoveRange(ResourceEntity.actor_List);            
      _Context.Res_DiagnosticOrder_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_DiagnosticOrder_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_DiagnosticOrder_Index_event_date.RemoveRange(ResourceEntity.event_date_List);            
      _Context.Res_DiagnosticOrder_Index_event_status.RemoveRange(ResourceEntity.event_status_List);            
      _Context.Res_DiagnosticOrder_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_DiagnosticOrder_Index_item_date.RemoveRange(ResourceEntity.item_date_List);            
      _Context.Res_DiagnosticOrder_Index_item_past_status.RemoveRange(ResourceEntity.item_past_status_List);            
      _Context.Res_DiagnosticOrder_Index_item_status.RemoveRange(ResourceEntity.item_status_List);            
      _Context.Res_DiagnosticOrder_Index_specimen.RemoveRange(ResourceEntity.specimen_List);            
      _Context.Res_DiagnosticOrder_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_DiagnosticOrder_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_DiagnosticOrder_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_DiagnosticOrder ResourseEntity, string ResourceVersion, DiagnosticOrder ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

