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
  public partial class PractitionerRoleRepository : CommonRepository, IResourceRepository
  {

    public PractitionerRoleRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as PractitionerRole;
      var ResourceEntity = new Res_PractitionerRole();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_PractitionerRole>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as PractitionerRole;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_PractitionerRole_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_PractitionerRole_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_PractitionerRole_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_PractitionerRole_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_PractitionerRole_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_PractitionerRole>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_PractitionerRole>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_PractitionerRole>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_PractitionerRole LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_PractitionerRole, object>>>();
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.role_List);
      IncludeList.Add(x => x.specialty_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_PractitionerRole>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_PractitionerRole ResourceEntity)
    {
      ResourceEntity.organization_FhirId = null;      
      ResourceEntity.organization_Type = null;      
      ResourceEntity.organization_Url = null;      
      ResourceEntity.organization_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.practitioner_FhirId = null;      
      ResourceEntity.practitioner_Type = null;      
      ResourceEntity.practitioner_Url = null;      
      ResourceEntity.practitioner_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_PractitionerRole_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_PractitionerRole_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_PractitionerRole_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_PractitionerRole_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_PractitionerRole_Index_role.RemoveRange(ResourceEntity.role_List);            
      _Context.Res_PractitionerRole_Index_specialty.RemoveRange(ResourceEntity.specialty_List);            
      _Context.Res_PractitionerRole_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_PractitionerRole_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_PractitionerRole_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_PractitionerRole_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_PractitionerRole ResourseEntity, string ResourceVersion, PractitionerRole ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Organization != null)
      {
        if (ResourceTyped.Organization is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Organization, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.organization_Type = Index.Type;
            ResourseEntity.organization_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.organization_Url = Index.Url;
            }
            else
            {
              ResourseEntity.organization_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Practitioner != null)
      {
        if (ResourceTyped.Practitioner is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Practitioner, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.practitioner_Type = Index.Type;
            ResourseEntity.practitioner_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.practitioner_Url = Index.Url;
            }
            else
            {
              ResourseEntity.practitioner_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Email)
          {
            if (item2 is ContactPoint)
            {
              var Index = new Res_PractitionerRole_Index_email();
              Index = IndexSettingSupport.SetIndex(Index, item2) as Res_PractitionerRole_Index_email;
              ResourseEntity.email_List.Add(Index);
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
            Res_PractitionerRole_Index_identifier Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_PractitionerRole_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Location != null)
      {
        foreach (var item in ResourceTyped.Location)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_PractitionerRole_Index_location();
            IndexSettingSupport.SetIndex(Index, item, FhirRequestUri, this);
            if (Index != null)
            {
              ResourseEntity.location_List.Add(Index);
            }
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Phone)
          {
            if (item2 is ContactPoint)
            {
              var Index = new Res_PractitionerRole_Index_phone();
              Index = IndexSettingSupport.SetIndex(Index, item2) as Res_PractitionerRole_Index_phone;
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Role != null)
      {
        foreach (var item3 in ResourceTyped.Role)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              Res_PractitionerRole_Index_role Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_PractitionerRole_Index_role;
              ResourseEntity.role_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Specialty != null)
      {
        foreach (var item3 in ResourceTyped.Specialty)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              Res_PractitionerRole_Index_specialty Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_PractitionerRole_Index_specialty;
              ResourseEntity.specialty_List.Add(Index);
            }
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2 is ContactPoint)
        {
          var Index = new Res_PractitionerRole_Index_telecom();
          Index = IndexSettingSupport.SetIndex(Index, item2) as Res_PractitionerRole_Index_telecom;
          ResourseEntity.telecom_List.Add(Index);
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
              Res_PractitionerRole_Index_profile Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_PractitionerRole_Index_profile;
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
              Res_PractitionerRole_Index_security Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_PractitionerRole_Index_security;
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
              Res_PractitionerRole_Index_tag Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_PractitionerRole_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

