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
  public partial class ConceptMapRepository : CommonRepository, IResourceRepository
  {

    public ConceptMapRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ConceptMap;
      var ResourceEntity = new Res_ConceptMap();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ConceptMap>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ConceptMap;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ConceptMap_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ConceptMap_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_ConceptMap_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ConceptMap_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_ConceptMap_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ConceptMap>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_ConceptMap>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_ConceptMap>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ConceptMap LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ConceptMap, object>>>();
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.dependson_List);
      IncludeList.Add(x => x.product_List);
      IncludeList.Add(x => x.source_code_List);
      IncludeList.Add(x => x.source_system_List);
      IncludeList.Add(x => x.target_code_List);
      IncludeList.Add(x => x.target_system_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ConceptMap>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ConceptMap ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.source_FhirId = null;      
      ResourceEntity.source_Type = null;      
      ResourceEntity.source_Url = null;      
      ResourceEntity.source_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.source_uri_FhirId = null;      
      ResourceEntity.source_uri_Type = null;      
      ResourceEntity.source_uri_Url = null;      
      ResourceEntity.source_uri_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.target_FhirId = null;      
      ResourceEntity.target_Type = null;      
      ResourceEntity.target_Url = null;      
      ResourceEntity.target_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.target_FhirId = null;      
      ResourceEntity.target_Type = null;      
      ResourceEntity.target_Url = null;      
      ResourceEntity.target_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ConceptMap_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_ConceptMap_Index_dependson.RemoveRange(ResourceEntity.dependson_List);            
      _Context.Res_ConceptMap_Index_product.RemoveRange(ResourceEntity.product_List);            
      _Context.Res_ConceptMap_Index_source_code.RemoveRange(ResourceEntity.source_code_List);            
      _Context.Res_ConceptMap_Index_source_system.RemoveRange(ResourceEntity.source_system_List);            
      _Context.Res_ConceptMap_Index_target_code.RemoveRange(ResourceEntity.target_code_List);            
      _Context.Res_ConceptMap_Index_target_system.RemoveRange(ResourceEntity.target_system_List);            
      _Context.Res_ConceptMap_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ConceptMap_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ConceptMap_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ConceptMap ResourseEntity, string ResourceVersion, ConceptMap ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Date != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.DateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Description != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.DescriptionElement);
        if (Index != null)
        {
          ResourseEntity.description_String = Index.String;
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Identifier);
        if (Index != null)
        {
          ResourseEntity.identifier_Code = Index.Code;
          ResourseEntity.identifier_System = Index.System;
        }
      }

      if (ResourceTyped.Name != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.NameElement);
        if (Index != null)
        {
          ResourseEntity.name_String = Index.String;
        }
      }

      if (ResourceTyped.Publisher != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.PublisherElement);
        if (Index != null)
        {
          ResourseEntity.publisher_String = Index.String;
        }
      }

      if (ResourceTyped.Source != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Source, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.source_Type = Index.Type;
            ResourseEntity.source_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.source_Url = Index.Url;
            }
            else
            {
              ResourseEntity.source_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Source != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Source, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.source_uri_Type = Index.Type;
            ResourseEntity.source_uri_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.source_uri_Url = Index.Url;
            }
            else
            {
              ResourseEntity.source_uri_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.Target != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Target, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.target_Type = Index.Type;
            ResourseEntity.target_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.target_Url = Index.Url;
            }
            else
            {
              ResourseEntity.target_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Url != null)
      {
        var Index = IndexSettingSupport.SetIndex<UriIndex>(new UriIndex(), ResourceTyped.UrlElement);
        if (Index != null)
        {
          ResourseEntity.url_Uri = Index.Uri;
        }
      }

      if (ResourceTyped.Version != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.VersionElement);
        if (Index != null)
        {
          ResourseEntity.version_Code = Index.Code;
          ResourseEntity.version_System = Index.System;
        }
      }

      if (ResourceTyped.Target != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Target, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.target_Type = Index.Type;
            ResourseEntity.target_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.target_Url = Index.Url;
            }
            else
            {
              ResourseEntity.target_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
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
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ConceptMap_Index_context(), item4) as Res_ConceptMap_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        foreach (var item2 in item1.Target)
        {
          foreach (var item3 in item2.DependsOn)
          {
            if (item3.Element != null)
            {
              var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ConceptMap_Index_dependson(), item3.ElementElement) as Res_ConceptMap_Index_dependson;
              ResourseEntity.dependson_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        foreach (var item2 in item1.Target)
        {
          foreach (var item3 in item2.Product)
          {
            if (item3.Element != null)
            {
              var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ConceptMap_Index_product(), item3.ElementElement) as Res_ConceptMap_Index_product;
              ResourseEntity.product_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        if (item1.Code != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ConceptMap_Index_source_code(), item1.CodeElement) as Res_ConceptMap_Index_source_code;
          ResourseEntity.source_code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        if (item1.System != null)
        {
          var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ConceptMap_Index_source_system(), item1.SystemElement) as Res_ConceptMap_Index_source_system;
          ResourseEntity.source_system_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        foreach (var item2 in item1.Target)
        {
          if (item2.Code != null)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ConceptMap_Index_target_code(), item2.CodeElement) as Res_ConceptMap_Index_target_code;
            ResourseEntity.target_code_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Element)
      {
        foreach (var item2 in item1.Target)
        {
          if (item2.System != null)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ConceptMap_Index_target_system(), item2.SystemElement) as Res_ConceptMap_Index_target_system;
            ResourseEntity.target_system_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_ConceptMap_Index_profile(), item4) as Res_ConceptMap_Index_profile;
            ResourseEntity.profile_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Security != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Security)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ConceptMap_Index_security(), item4) as Res_ConceptMap_Index_security;
            ResourseEntity.security_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Tag != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Tag)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_ConceptMap_Index_tag(), item4) as Res_ConceptMap_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

