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
  public partial class ImplementationGuideRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_ImplementationGuide, new() 
    where ResourceHistoryType :Res_ImplementationGuide_History, new()
  {
    public ImplementationGuideRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_ImplementationGuide_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.dependency_List);
      IncludeList.Add(x => x.resource_List);
      IncludeList.Add(x => x.resource_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.experimental_Code = null;      
      ResourceEntity.experimental_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ImplementationGuide_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_ImplementationGuide_Index_dependency.RemoveRange(ResourceEntity.dependency_List);            
      _Context.Res_ImplementationGuide_Index_resource.RemoveRange(ResourceEntity.resource_List);            
      _Context.Res_ImplementationGuide_Index_resource.RemoveRange(ResourceEntity.resource_List);            
      _Context.Res_ImplementationGuide_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_ImplementationGuide_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_ImplementationGuide_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ImplementationGuide;
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

      if (ResourceTyped.Description != null)
      {
        if (ResourceTyped.Description is Hl7.Fhir.Model.Markdown)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.Description, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.description_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Experimental != null)
      {
        if (ResourceTyped.ExperimentalElement is Hl7.Fhir.Model.FhirBoolean)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.ExperimentalElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.experimental_Code = Index.Code;
            ResourseEntity.experimental_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        if (ResourceTyped.NameElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.NameElement, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.name_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Publisher != null)
      {
        if (ResourceTyped.PublisherElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.PublisherElement, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.publisher_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ConformanceResourceStatus>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.StatusElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Url != null)
      {
        if (ResourceTyped.UrlElement is Hl7.Fhir.Model.FhirUri)
        {
          var Index = new UriIndex();
          Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(ResourceTyped.UrlElement, Index) as UriIndex;
          if (Index != null)
          {
            ResourseEntity.url_Uri = Index.Uri;
          }
        }
      }

      if (ResourceTyped.Version != null)
      {
        if (ResourceTyped.VersionElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.VersionElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.version_Code = Index.Code;
            ResourseEntity.version_System = Index.System;
          }
        }
      }

      if (ResourceTyped.UseContext != null)
      {
        foreach (var item3 in ResourceTyped.UseContext)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_ImplementationGuide_Index_context();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImplementationGuide_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Dependency)
      {
        if (item1.Uri != null)
        {
          if (item1.UriElement is Hl7.Fhir.Model.FhirUri)
          {
            var Index = new Res_ImplementationGuide_Index_dependency();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.UriElement, Index) as Res_ImplementationGuide_Index_dependency;
            ResourseEntity.dependency_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Package)
      {
        foreach (var item2 in item1.Resource)
        {
          if (item2.Source != null)
          {
            if (item2.Source is Hl7.Fhir.Model.FhirUri)
            {
              var Index = new Res_ImplementationGuide_Index_resource();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Source, Index) as Res_ImplementationGuide_Index_resource;
              ResourseEntity.resource_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Package)
      {
        foreach (var item2 in item1.Resource)
        {
          if (item2.Source != null)
          {
            if (item2.Source is ResourceReference)
            {
              var Index = new Res_ImplementationGuide_Index_resource();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Source, Index, FhirRequestUri, this) as Res_ImplementationGuide_Index_resource;
              if (Index != null)
              {
                ResourseEntity.resource_List.Add(Index);
              }
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
              var Index = new Res_ImplementationGuide_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ImplementationGuide_Index__profile;
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
              var Index = new Res_ImplementationGuide_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImplementationGuide_Index__security;
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
              var Index = new Res_ImplementationGuide_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImplementationGuide_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

