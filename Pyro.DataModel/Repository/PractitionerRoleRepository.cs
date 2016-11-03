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
  public partial class PractitionerRoleRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_PractitionerRole, new() 
    where ResourceHistoryType :Res_PractitionerRole_History, new()
  {
    public PractitionerRoleRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_PractitionerRole_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.role_List);
      IncludeList.Add(x => x.specialty_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.organization_VersionId = null;      
      ResourceEntity.organization_FhirId = null;      
      ResourceEntity.organization_Type = null;      
      ResourceEntity.organization_Url = null;      
      ResourceEntity.organization_ServiceRootURL_StoreID = null;      
      ResourceEntity.practitioner_VersionId = null;      
      ResourceEntity.practitioner_FhirId = null;      
      ResourceEntity.practitioner_Type = null;      
      ResourceEntity.practitioner_Url = null;      
      ResourceEntity.practitioner_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_PractitionerRole_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_PractitionerRole_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_PractitionerRole_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_PractitionerRole_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_PractitionerRole_Index_role.RemoveRange(ResourceEntity.role_List);            
      _Context.Res_PractitionerRole_Index_specialty.RemoveRange(ResourceEntity.specialty_List);            
      _Context.Res_PractitionerRole_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_PractitionerRole_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_PractitionerRole_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_PractitionerRole_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as PractitionerRole;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Organization != null)
      {
        if (ResourceTyped.Organization is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Organization, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.organization_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Practitioner != null)
      {
        if (ResourceTyped.Practitioner is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Practitioner, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.practitioner_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_PractitionerRole_Index_email;
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
            var Index = new Res_PractitionerRole_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_PractitionerRole_Index_identifier;
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
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_PractitionerRole_Index_location;
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
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_PractitionerRole_Index_phone;
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_PractitionerRole_Index_role();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_PractitionerRole_Index_role;
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
              var Index = new Res_PractitionerRole_Index_specialty();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_PractitionerRole_Index_specialty;
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
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_PractitionerRole_Index_telecom;
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
              var Index = new Res_PractitionerRole_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_PractitionerRole_Index__profile;
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
              var Index = new Res_PractitionerRole_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_PractitionerRole_Index__security;
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
              var Index = new Res_PractitionerRole_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_PractitionerRole_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

