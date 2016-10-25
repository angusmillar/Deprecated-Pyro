using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.Search;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class ConceptMapRepository : CommonRepository, IResourceRepository
  {
    public ConceptMapRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_ConceptMap>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_ConceptMap>(Predicate);
      var Query = DbGetAll<Res_ConceptMap>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);      
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = TotalRecordCount;
      DatabaseOperationOutcome.ResourcesMatchingSearchList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

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
      ResourceEntity.XmlBlob = string.Empty;
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
        DtoResource = DbGetAll<Res_ConceptMap>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_ConceptMap>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
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
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
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
      ResourceEntity.source_VersionId = null;      
      ResourceEntity.source_FhirId = null;      
      ResourceEntity.source_Type = null;      
      ResourceEntity.source_Url = null;      
      ResourceEntity.source_ServiceRootURL_StoreID = null;      
      ResourceEntity.source_uri_VersionId = null;      
      ResourceEntity.source_uri_FhirId = null;      
      ResourceEntity.source_uri_Type = null;      
      ResourceEntity.source_uri_Url = null;      
      ResourceEntity.source_uri_ServiceRootURL_StoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.target_VersionId = null;      
      ResourceEntity.target_FhirId = null;      
      ResourceEntity.target_Type = null;      
      ResourceEntity.target_Url = null;      
      ResourceEntity.target_ServiceRootURL_StoreID = null;      
      ResourceEntity.target_uri_VersionId = null;      
      ResourceEntity.target_uri_FhirId = null;      
      ResourceEntity.target_uri_Type = null;      
      ResourceEntity.target_uri_Url = null;      
      ResourceEntity.target_uri_ServiceRootURL_StoreID = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ConceptMap_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_ConceptMap_Index_dependson.RemoveRange(ResourceEntity.dependson_List);            
      _Context.Res_ConceptMap_Index_product.RemoveRange(ResourceEntity.product_List);            
      _Context.Res_ConceptMap_Index_source_code.RemoveRange(ResourceEntity.source_code_List);            
      _Context.Res_ConceptMap_Index_source_system.RemoveRange(ResourceEntity.source_system_List);            
      _Context.Res_ConceptMap_Index_target_code.RemoveRange(ResourceEntity.target_code_List);            
      _Context.Res_ConceptMap_Index_target_system.RemoveRange(ResourceEntity.target_system_List);            
      _Context.Res_ConceptMap_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_ConceptMap_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_ConceptMap_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ConceptMap ResourseEntity, string ResourceVersion, ConceptMap ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
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

      if (ResourceTyped.Identifier != null)
      {
        if (ResourceTyped.Identifier is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Identifier, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.identifier_Code = Index.Code;
            ResourseEntity.identifier_System = Index.System;
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

      if (ResourceTyped.Source != null)
      {
        if (ResourceTyped.Source is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Source, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.source_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Source != null)
      {
        if (ResourceTyped.Source is Hl7.Fhir.Model.FhirUri)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Source, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.source_uri_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
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

      if (ResourceTyped.Target != null)
      {
        if (ResourceTyped.Target is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Target, Index, FhirRequestUri, this) as ReferenceIndex;
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
              ResourseEntity.target_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Target != null)
      {
        if (ResourceTyped.Target is Hl7.Fhir.Model.FhirUri)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Target, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.target_uri_Type = Index.Type;
            ResourseEntity.target_uri_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.target_uri_Url = Index.Url;
            }
            else
            {
              ResourseEntity.target_uri_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
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
              var Index = new Res_ConceptMap_Index_context();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ConceptMap_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        foreach (var item2 in item1.Element)
        {
          foreach (var item3 in item2.Target)
          {
            foreach (var item4 in item3.DependsOn)
            {
              if (item4.Property != null)
              {
                if (item4.PropertyElement is Hl7.Fhir.Model.FhirUri)
                {
                  var Index = new Res_ConceptMap_Index_dependson();
                  Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4.PropertyElement, Index) as Res_ConceptMap_Index_dependson;
                  ResourseEntity.dependson_List.Add(Index);
                }
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        foreach (var item2 in item1.Element)
        {
          foreach (var item3 in item2.Target)
          {
            foreach (var item4 in item3.Product)
            {
              if (item4.Property != null)
              {
                if (item4.PropertyElement is Hl7.Fhir.Model.FhirUri)
                {
                  var Index = new Res_ConceptMap_Index_product();
                  Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4.PropertyElement, Index) as Res_ConceptMap_Index_product;
                  ResourseEntity.product_List.Add(Index);
                }
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        foreach (var item2 in item1.Element)
        {
          if (item2.Code != null)
          {
            if (item2.CodeElement is Hl7.Fhir.Model.Code)
            {
              var Index = new Res_ConceptMap_Index_source_code();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.CodeElement, Index) as Res_ConceptMap_Index_source_code;
              ResourseEntity.source_code_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        if (item1.Source != null)
        {
          if (item1.SourceElement is Hl7.Fhir.Model.FhirUri)
          {
            var Index = new Res_ConceptMap_Index_source_system();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.SourceElement, Index) as Res_ConceptMap_Index_source_system;
            ResourseEntity.source_system_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        foreach (var item2 in item1.Element)
        {
          foreach (var item3 in item2.Target)
          {
            if (item3.Code != null)
            {
              if (item3.CodeElement is Hl7.Fhir.Model.Code)
              {
                var Index = new Res_ConceptMap_Index_target_code();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3.CodeElement, Index) as Res_ConceptMap_Index_target_code;
                ResourseEntity.target_code_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Group)
      {
        if (item1.Target != null)
        {
          if (item1.TargetElement is Hl7.Fhir.Model.FhirUri)
          {
            var Index = new Res_ConceptMap_Index_target_system();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.TargetElement, Index) as Res_ConceptMap_Index_target_system;
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
            if (item4 is Hl7.Fhir.Model.FhirUri)
            {
              var Index = new Res_ConceptMap_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ConceptMap_Index__profile;
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
              var Index = new Res_ConceptMap_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ConceptMap_Index__security;
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
              var Index = new Res_ConceptMap_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ConceptMap_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

