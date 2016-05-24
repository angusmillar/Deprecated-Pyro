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
  public partial class PractitionerRepository : CommonRepository, IResourceRepository
  {

    public PractitionerRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Practitioner;
      var ResourceEntity = new Res_Practitioner();
      this.PopulateResourceEntity(ResourceEntity, 1, ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Practitioner>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Practitioner;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Practitioner_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Practitioner_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_Practitioner_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Practitioner_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_Practitioner>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Practitioner>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Practitioner>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Practitioner LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Practitioner, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.communication_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.family_List);
      IncludeList.Add(x => x.given_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.name_List);
      IncludeList.Add(x => x.organization_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phonetic_List);
      IncludeList.Add(x => x.role_List);
      IncludeList.Add(x => x.specialty_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Practitioner>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Practitioner ResourceEntity)
    {
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Practitioner_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_Practitioner_Index_address_city.RemoveRange(ResourceEntity.address_city_List);            
      _Context.Res_Practitioner_Index_address_country.RemoveRange(ResourceEntity.address_country_List);            
      _Context.Res_Practitioner_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);            
      _Context.Res_Practitioner_Index_address_state.RemoveRange(ResourceEntity.address_state_List);            
      _Context.Res_Practitioner_Index_address_use.RemoveRange(ResourceEntity.address_use_List);            
      _Context.Res_Practitioner_Index_communication.RemoveRange(ResourceEntity.communication_List);            
      _Context.Res_Practitioner_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_Practitioner_Index_family.RemoveRange(ResourceEntity.family_List);            
      _Context.Res_Practitioner_Index_given.RemoveRange(ResourceEntity.given_List);            
      _Context.Res_Practitioner_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Practitioner_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_Practitioner_Index_name.RemoveRange(ResourceEntity.name_List);            
      _Context.Res_Practitioner_Index_organization.RemoveRange(ResourceEntity.organization_List);            
      _Context.Res_Practitioner_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_Practitioner_Index_phonetic.RemoveRange(ResourceEntity.phonetic_List);            
      _Context.Res_Practitioner_Index_role.RemoveRange(ResourceEntity.role_List);            
      _Context.Res_Practitioner_Index_specialty.RemoveRange(ResourceEntity.specialty_List);            
      _Context.Res_Practitioner_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_Practitioner_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Practitioner_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Practitioner_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Practitioner ResourseEntity, int ResourceVersion, Practitioner ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

