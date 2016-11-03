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
  public partial class CareTeamRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_CareTeam, new() 
    where ResourceHistoryType :Res_CareTeam_History, new()
  {
    public CareTeamRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_CareTeam_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.participant_List);
      IncludeList.Add(x => x.status_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.subject_VersionId = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_CareTeam_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_CareTeam_Index_participant.RemoveRange(ResourceEntity.participant_List);            
      _Context.Res_CareTeam_Index_status.RemoveRange(ResourceEntity.status_List);            
      _Context.Res_CareTeam_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_CareTeam_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_CareTeam_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_CareTeam_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as CareTeam;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Period != null)
      {
        if (ResourceTyped.Period is Hl7.Fhir.Model.Period)
        {
          var Index = new DateTimePeriodIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Period, Index) as DateTimePeriodIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffsetLow;
            ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.subject_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
            var Index = new Res_CareTeam_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_CareTeam_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Member != null)
        {
          if (item1.Member is ResourceReference)
          {
            var Index = new Res_CareTeam_Index_participant();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Member, Index, FhirRequestUri, this) as Res_CareTeam_Index_participant;
            if (Index != null)
            {
              ResourseEntity.participant_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        foreach (var item3 in ResourceTyped.Status.Coding)
        {
          var Index = new Res_CareTeam_Index_status();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_CareTeam_Index_status;
          ResourseEntity.status_List.Add(Index);
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_CareTeam_Index_type();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_CareTeam_Index_type;
              ResourseEntity.type_List.Add(Index);
            }
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
              var Index = new Res_CareTeam_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_CareTeam_Index__profile;
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
              var Index = new Res_CareTeam_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_CareTeam_Index__security;
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
              var Index = new Res_CareTeam_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_CareTeam_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

