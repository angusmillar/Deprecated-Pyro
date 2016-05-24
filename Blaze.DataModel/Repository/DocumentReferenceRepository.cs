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
  public partial class DocumentReferenceRepository : CommonRepository, IResourceRepository
  {

    public DocumentReferenceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DocumentReference;
      var ResourceEntity = new Res_DocumentReference();
      this.PopulateResourceEntity(ResourceEntity, 1, ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_DocumentReference>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DocumentReference;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_DocumentReference_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DocumentReference_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_DocumentReference_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DocumentReference_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_DocumentReference>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_DocumentReference>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_DocumentReference>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_DocumentReference LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_DocumentReference, object>>>();
      IncludeList.Add(x => x.author_List);
      IncludeList.Add(x => x.class_List);
      IncludeList.Add(x => x.event_List);
      IncludeList.Add(x => x.facility_List);
      IncludeList.Add(x => x.format_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.language_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.related_id_List);
      IncludeList.Add(x => x.related_ref_List);
      IncludeList.Add(x => x.relatesto_List);
      IncludeList.Add(x => x.relation_List);
      IncludeList.Add(x => x.securitylabel_List);
      IncludeList.Add(x => x.setting_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_DocumentReference>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_DocumentReference ResourceEntity)
    {
      ResourceEntity.authenticator_FhirId = null;      
      ResourceEntity.authenticator_Type = null;      
      ResourceEntity.authenticator_Url = null;      
      ResourceEntity.authenticator_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.custodian_FhirId = null;      
      ResourceEntity.custodian_Type = null;      
      ResourceEntity.custodian_Url = null;      
      ResourceEntity.custodian_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.indexed_DateTimeOffset = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.period_DateTimeOffset = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_DocumentReference_Index_author.RemoveRange(ResourceEntity.author_List);            
      _Context.Res_DocumentReference_Index_class.RemoveRange(ResourceEntity.class_List);            
      _Context.Res_DocumentReference_Index_event.RemoveRange(ResourceEntity.event_List);            
      _Context.Res_DocumentReference_Index_facility.RemoveRange(ResourceEntity.facility_List);            
      _Context.Res_DocumentReference_Index_format.RemoveRange(ResourceEntity.format_List);            
      _Context.Res_DocumentReference_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_DocumentReference_Index_language.RemoveRange(ResourceEntity.language_List);            
      _Context.Res_DocumentReference_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_DocumentReference_Index_related_id.RemoveRange(ResourceEntity.related_id_List);            
      _Context.Res_DocumentReference_Index_related_ref.RemoveRange(ResourceEntity.related_ref_List);            
      _Context.Res_DocumentReference_Index_relatesto.RemoveRange(ResourceEntity.relatesto_List);            
      _Context.Res_DocumentReference_Index_relation.RemoveRange(ResourceEntity.relation_List);            
      _Context.Res_DocumentReference_Index_securitylabel.RemoveRange(ResourceEntity.securitylabel_List);            
      _Context.Res_DocumentReference_Index_setting.RemoveRange(ResourceEntity.setting_List);            
      _Context.Res_DocumentReference_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_DocumentReference_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_DocumentReference_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_DocumentReference_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_DocumentReference ResourseEntity, int ResourceVersion, DocumentReference ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

