using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Support;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.Search;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Pyro.DataModel.Repository
{
  public partial class StructureDefinitionRepository : CommonRepository, IResourceRepository
  {
    public StructureDefinitionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_StructureDefinition>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_StructureDefinition>(Predicate);
      var Query = DbGetAll<Res_StructureDefinition>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);      
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceCount = TotalRecordCount;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as StructureDefinition;
      var ResourceEntity = new Res_StructureDefinition();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_StructureDefinition>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as StructureDefinition;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_StructureDefinition_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_StructureDefinition_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_StructureDefinition_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_StructureDefinition_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      ResourceEntity.XmlBlob = string.Empty;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_StructureDefinition_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_StructureDefinition>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);        
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {        
        DtoResource = DbGetAll<Res_StructureDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_StructureDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_StructureDefinition LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_StructureDefinition, object>>>();
      IncludeList.Add(x => x.base_path_List);
      IncludeList.Add(x => x.base_path_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.ext_context_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.path_List);
      IncludeList.Add(x => x.path_List);
      IncludeList.Add(x => x.valueset_List);
      IncludeList.Add(x => x.valueset_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_StructureDefinition>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_StructureDefinition ResourceEntity)
    {
      ResourceEntity.abstract_Code = null;      
      ResourceEntity.abstract_System = null;      
      ResourceEntity.base_Uri = null;      
      ResourceEntity.context_type_Code = null;      
      ResourceEntity.context_type_System = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.derivation_Code = null;      
      ResourceEntity.derivation_System = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.display_String = null;      
      ResourceEntity.experimental_Code = null;      
      ResourceEntity.experimental_System = null;      
      ResourceEntity.kind_Code = null;      
      ResourceEntity.kind_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_StructureDefinition_Index_base_path.RemoveRange(ResourceEntity.base_path_List);            
      _Context.Res_StructureDefinition_Index_base_path.RemoveRange(ResourceEntity.base_path_List);            
      _Context.Res_StructureDefinition_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_StructureDefinition_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_StructureDefinition_Index_ext_context.RemoveRange(ResourceEntity.ext_context_List);            
      _Context.Res_StructureDefinition_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_StructureDefinition_Index_path.RemoveRange(ResourceEntity.path_List);            
      _Context.Res_StructureDefinition_Index_path.RemoveRange(ResourceEntity.path_List);            
      _Context.Res_StructureDefinition_Index_valueset.RemoveRange(ResourceEntity.valueset_List);            
      _Context.Res_StructureDefinition_Index_valueset.RemoveRange(ResourceEntity.valueset_List);            
      _Context.Res_StructureDefinition_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_StructureDefinition_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_StructureDefinition_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_StructureDefinition ResourseEntity, string ResourceVersion, StructureDefinition ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Abstract != null)
      {
        if (ResourceTyped.AbstractElement is Hl7.Fhir.Model.FhirBoolean)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.AbstractElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.abstract_Code = Index.Code;
            ResourseEntity.abstract_System = Index.System;
          }
        }
      }

      if (ResourceTyped.BaseDefinition != null)
      {
        if (ResourceTyped.BaseDefinitionElement is Hl7.Fhir.Model.FhirUri)
        {
          var Index = new UriIndex();
          Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(ResourceTyped.BaseDefinitionElement, Index) as UriIndex;
          if (Index != null)
          {
            ResourseEntity.base_Uri = Index.Uri;
          }
        }
      }

      if (ResourceTyped.ContextType != null)
      {
        if (ResourceTyped.ContextTypeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.StructureDefinition.ExtensionContext>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.ContextTypeElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.context_type_Code = Index.Code;
            ResourseEntity.context_type_System = Index.System;
          }
        }
      }

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

      if (ResourceTyped.Derivation != null)
      {
        if (ResourceTyped.DerivationElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.DerivationElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.derivation_Code = Index.Code;
            ResourseEntity.derivation_System = Index.System;
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

      if (ResourceTyped.Display != null)
      {
        if (ResourceTyped.DisplayElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.DisplayElement, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.display_String = Index.String;
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

      if (ResourceTyped.Kind != null)
      {
        if (ResourceTyped.KindElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.KindElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.kind_Code = Index.Code;
            ResourseEntity.kind_System = Index.System;
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

      if (ResourceTyped.Type != null)
      {
        if (ResourceTyped.TypeElement is Hl7.Fhir.Model.Code)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.TypeElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.type_Code = Index.Code;
            ResourseEntity.type_System = Index.System;
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

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Base != null)
          {
            if (item2.Base.Path != null)
            {
              if (item2.Base.PathElement is Hl7.Fhir.Model.FhirString)
              {
                var Index = new Res_StructureDefinition_Index_base_path();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.Base.PathElement, Index) as Res_StructureDefinition_Index_base_path;
                ResourseEntity.base_path_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Differential != null)
      {
        foreach (var item2 in ResourceTyped.Differential.Element)
        {
          if (item2.Base != null)
          {
            if (item2.Base.Path != null)
            {
              if (item2.Base.PathElement is Hl7.Fhir.Model.FhirString)
              {
                var Index = new Res_StructureDefinition_Index_base_path();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.Base.PathElement, Index) as Res_StructureDefinition_Index_base_path;
                ResourseEntity.base_path_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code)
        {
          if (item3 is Hl7.Fhir.Model.Coding)
          {
            var Index = new Res_StructureDefinition_Index_code();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_StructureDefinition_Index_code;
            ResourseEntity.code_List.Add(Index);
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
              var Index = new Res_StructureDefinition_Index_context();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_StructureDefinition_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        foreach (var item3 in ResourceTyped.ContextElement)
        {
          if (item3 is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_StructureDefinition_Index_ext_context();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item3, Index) as Res_StructureDefinition_Index_ext_context;
            ResourseEntity.ext_context_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_StructureDefinition_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_StructureDefinition_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Path != null)
          {
            if (item2.PathElement is Hl7.Fhir.Model.FhirString)
            {
              var Index = new Res_StructureDefinition_Index_path();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.PathElement, Index) as Res_StructureDefinition_Index_path;
              ResourseEntity.path_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Differential != null)
      {
        foreach (var item2 in ResourceTyped.Differential.Element)
        {
          if (item2.Path != null)
          {
            if (item2.PathElement is Hl7.Fhir.Model.FhirString)
            {
              var Index = new Res_StructureDefinition_Index_path();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.PathElement, Index) as Res_StructureDefinition_Index_path;
              ResourseEntity.path_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Binding != null)
          {
            if (item2.Binding.ValueSet != null)
            {
              if (item2.Binding.ValueSet is Hl7.Fhir.Model.FhirUri)
              {
                var Index = new Res_StructureDefinition_Index_valueset();
                Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Binding.ValueSet, Index) as Res_StructureDefinition_Index_valueset;
                ResourseEntity.valueset_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Binding != null)
          {
            if (item2.Binding.ValueSet != null)
            {
              if (item2.Binding.ValueSet is ResourceReference)
              {
                var Index = new Res_StructureDefinition_Index_valueset();
                Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Binding.ValueSet, Index, FhirRequestUri, this) as Res_StructureDefinition_Index_valueset;
                if (Index != null)
                {
                  ResourseEntity.valueset_List.Add(Index);
                }
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
              var Index = new Res_StructureDefinition_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_StructureDefinition_Index__profile;
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
              var Index = new Res_StructureDefinition_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_StructureDefinition_Index__security;
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
              var Index = new Res_StructureDefinition_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_StructureDefinition_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

