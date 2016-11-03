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
  public partial class FamilyMemberHistoryRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_FamilyMemberHistory, new() 
    where ResourceHistoryType :Res_FamilyMemberHistory_History, new()
  {
    public FamilyMemberHistoryRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_FamilyMemberHistory_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.relationship_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_FamilyMemberHistory_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_FamilyMemberHistory_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_FamilyMemberHistory_Index_relationship.RemoveRange(ResourceEntity.relationship_List);            
      _Context.Res_FamilyMemberHistory_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_FamilyMemberHistory_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_FamilyMemberHistory_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as FamilyMemberHistory;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

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

      if (ResourceTyped.Gender != null)
      {
        if (ResourceTyped.GenderElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.AdministrativeGender>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.GenderElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.gender_Code = Index.Code;
            ResourseEntity.gender_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Patient, Index, FhirRequestUri, this) as ReferenceIndex;
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

      foreach (var item1 in ResourceTyped.Condition)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = new Res_FamilyMemberHistory_Index_code();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index_code;
            ResourseEntity.code_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_FamilyMemberHistory_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_FamilyMemberHistory_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Relationship != null)
      {
        foreach (var item3 in ResourceTyped.Relationship.Coding)
        {
          var Index = new Res_FamilyMemberHistory_Index_relationship();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_FamilyMemberHistory_Index_relationship;
          ResourseEntity.relationship_List.Add(Index);
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
              var Index = new Res_FamilyMemberHistory_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__profile;
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
              var Index = new Res_FamilyMemberHistory_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__security;
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
              var Index = new Res_FamilyMemberHistory_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

