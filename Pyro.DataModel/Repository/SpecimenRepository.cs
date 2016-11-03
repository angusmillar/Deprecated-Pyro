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
  public partial class SpecimenRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_Specimen, new() 
    where ResourceHistoryType :Res_Specimen_History, new()
  {
    public SpecimenRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_Specimen_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.container_List);
      IncludeList.Add(x => x.container_id_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.parent_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.accession_Code = null;      
      ResourceEntity.accession_System = null;      
      ResourceEntity.collected_DateTimeOffsetLow = null;      
      ResourceEntity.collected_DateTimeOffsetHigh = null;      
      ResourceEntity.collected_DateTimeOffsetLow = null;      
      ResourceEntity.collected_DateTimeOffsetHigh = null;      
      ResourceEntity.collector_VersionId = null;      
      ResourceEntity.collector_FhirId = null;      
      ResourceEntity.collector_Type = null;      
      ResourceEntity.collector_Url = null;      
      ResourceEntity.collector_ServiceRootURL_StoreID = null;      
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
 
      
      _Context.Res_Specimen_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_Specimen_Index_container.RemoveRange(ResourceEntity.container_List);            
      _Context.Res_Specimen_Index_container_id.RemoveRange(ResourceEntity.container_id_List);            
      _Context.Res_Specimen_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Specimen_Index_parent.RemoveRange(ResourceEntity.parent_List);            
      _Context.Res_Specimen_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Specimen_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Specimen_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Specimen_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Specimen;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.AccessionIdentifier != null)
      {
        if (ResourceTyped.AccessionIdentifier is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.AccessionIdentifier, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.accession_Code = Index.Code;
            ResourseEntity.accession_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collected != null)
        {
          if (ResourceTyped.Collection.Collected is Hl7.Fhir.Model.FhirDateTime)
          {
            var Index = new DateTimePeriodIndex();
            Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Collection.Collected, Index) as DateTimePeriodIndex;
            if (Index != null)
            {
              ResourseEntity.collected_DateTimeOffsetLow = Index.DateTimeOffsetLow;
              ResourseEntity.collected_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
            }
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collected != null)
        {
          if (ResourceTyped.Collection.Collected is Hl7.Fhir.Model.Period)
          {
            var Index = new DateTimePeriodIndex();
            Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Collection.Collected, Index) as DateTimePeriodIndex;
            if (Index != null)
            {
              ResourseEntity.collected_DateTimeOffsetLow = Index.DateTimeOffsetLow;
              ResourseEntity.collected_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
            }
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collector != null)
        {
          if (ResourceTyped.Collection.Collector is Hl7.Fhir.Model.ResourceReference)
          {
            var Index = new ReferenceIndex();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Collection.Collector, Index, FhirRequestUri, this) as ReferenceIndex;
            if (Index != null)
            {
              ResourseEntity.collector_Type = Index.Type;
              ResourseEntity.collector_FhirId = Index.FhirId;
              if (Index.Url != null)
              {
                ResourseEntity.collector_Url = Index.Url;
              }
              else
              {
                ResourseEntity.collector_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
              }
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

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.BodySite != null)
        {
          foreach (var item4 in ResourceTyped.Collection.BodySite.Coding)
          {
            var Index = new Res_Specimen_Index_bodysite();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Specimen_Index_bodysite;
            ResourseEntity.bodysite_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Container)
      {
        if (item1.Type != null)
        {
          foreach (var item4 in item1.Type.Coding)
          {
            var Index = new Res_Specimen_Index_container();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Specimen_Index_container;
            ResourseEntity.container_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Container)
      {
        if (item1.Identifier != null)
        {
          foreach (var item4 in item1.Identifier)
          {
            if (item4 is Hl7.Fhir.Model.Identifier)
            {
              var Index = new Res_Specimen_Index_container_id();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Specimen_Index_container_id;
              ResourseEntity.container_id_List.Add(Index);
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
            var Index = new Res_Specimen_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Specimen_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Parent != null)
      {
        foreach (var item in ResourceTyped.Parent)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Specimen_Index_parent();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Specimen_Index_parent;
            if (Index != null)
            {
              ResourseEntity.parent_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = new Res_Specimen_Index_type();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Specimen_Index_type;
          ResourseEntity.type_List.Add(Index);
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
              var Index = new Res_Specimen_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Specimen_Index__profile;
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
              var Index = new Res_Specimen_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Specimen_Index__security;
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
              var Index = new Res_Specimen_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Specimen_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

