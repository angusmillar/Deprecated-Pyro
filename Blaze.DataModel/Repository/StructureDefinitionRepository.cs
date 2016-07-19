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
  public partial class StructureDefinitionRepository : CommonRepository, IResourceRepository
  {

    public StructureDefinitionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as StructureDefinition;
      var ResourceEntity = new Res_StructureDefinition();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_StructureDefinition>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
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
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
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
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_StructureDefinition_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_StructureDefinition>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_StructureDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_StructureDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
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
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
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
      _Context.Res_StructureDefinition_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_StructureDefinition_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_StructureDefinition_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_StructureDefinition ResourseEntity, string ResourceVersion, StructureDefinition ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Abstract != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.AbstractElement);
        if (Index != null)
        {
          ResourseEntity.abstract_Code = Index.Code;
          ResourseEntity.abstract_System = Index.System;
        }
      }

      if (ResourceTyped.BaseDefinition != null)
      {
        var Index = IndexSettingSupport.SetIndex<UriIndex>(new UriIndex(), ResourceTyped.BaseDefinitionElement);
        if (Index != null)
        {
          ResourseEntity.base_Uri = Index.Uri;
        }
      }

      if (ResourceTyped.ContextType != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.ContextTypeElement);
        if (Index != null)
        {
          ResourseEntity.context_type_Code = Index.Code;
          ResourseEntity.context_type_System = Index.System;
        }
      }

      if (ResourceTyped.Date != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.DateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Derivation != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.DerivationElement);
        if (Index != null)
        {
          ResourseEntity.derivation_Code = Index.Code;
          ResourseEntity.derivation_System = Index.System;
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

      if (ResourceTyped.Display != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.DisplayElement);
        if (Index != null)
        {
          ResourseEntity.display_String = Index.String;
        }
      }

      if (ResourceTyped.Experimental != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.ExperimentalElement);
        if (Index != null)
        {
          ResourseEntity.experimental_Code = Index.Code;
          ResourseEntity.experimental_System = Index.System;
        }
      }

      if (ResourceTyped.Kind != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.KindElement);
        if (Index != null)
        {
          ResourseEntity.kind_Code = Index.Code;
          ResourseEntity.kind_System = Index.System;
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

      if (ResourceTyped.Status != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.BaseType != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.BaseTypeElement);
        if (Index != null)
        {
          ResourseEntity.type_Code = Index.Code;
          ResourseEntity.type_System = Index.System;
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

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Base != null)
          {
            if (item2.Base.Path != null)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_base_path(), item2.Base.PathElement) as Res_StructureDefinition_Index_base_path;
              ResourseEntity.base_path_List.Add(Index);
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
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_base_path(), item2.Base.PathElement) as Res_StructureDefinition_Index_base_path;
              ResourseEntity.base_path_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_code(), item3) as Res_StructureDefinition_Index_code;
          ResourseEntity.code_List.Add(Index);
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
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_context(), item4) as Res_StructureDefinition_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        foreach (var item3 in ResourceTyped.ContextElement)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_StructureDefinition_Index_ext_context(), item3) as Res_StructureDefinition_Index_ext_context;
          ResourseEntity.ext_context_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_identifier(), item3) as Res_StructureDefinition_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      if (ResourceTyped.Snapshot != null)
      {
        foreach (var item2 in ResourceTyped.Snapshot.Element)
        {
          if (item2.Path != null)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_path(), item2.PathElement) as Res_StructureDefinition_Index_path;
            ResourseEntity.path_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Differential != null)
      {
        foreach (var item2 in ResourceTyped.Differential.Element)
        {
          if (item2.Path != null)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_path(), item2.PathElement) as Res_StructureDefinition_Index_path;
            ResourseEntity.path_List.Add(Index);
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
              var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_StructureDefinition_Index_valueset(), item2.Binding.ValueSet) as Res_StructureDefinition_Index_valueset;
              ResourseEntity.valueset_List.Add(Index);
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
              var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_StructureDefinition_Index_valueset(), item2.Binding.ValueSet, FhirRequestUri, this) as Res_StructureDefinition_Index_valueset;
              if (Index != null)
              {
                ResourseEntity.valueset_List.Add(Index);
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
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_StructureDefinition_Index_profile(), item4) as Res_StructureDefinition_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_security(), item4) as Res_StructureDefinition_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_StructureDefinition_Index_tag(), item4) as Res_StructureDefinition_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

