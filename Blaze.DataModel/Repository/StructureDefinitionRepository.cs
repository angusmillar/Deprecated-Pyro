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
        if (ResourceTyped.AbstractElement is Hl7.Fhir.Model.FhirBoolean)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.AbstractElement) as TokenIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.BaseDefinitionElement) as UriIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ContextTypeElement) as TokenIndex;
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
          var Index = new DateIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DateElement) as DateIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DerivationElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.derivation_Code = Index.Code;
            ResourseEntity.derivation_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Description != null)
      {
        if (ResourceTyped.DescriptionElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DescriptionElement) as StringIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DisplayElement) as StringIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ExperimentalElement) as TokenIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.KindElement) as TokenIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.NameElement) as StringIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.PublisherElement) as StringIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.StatusElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
          }
        }
      }

      if (ResourceTyped.BaseType != null)
      {
        if (ResourceTyped.BaseTypeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.FHIRDefinedType>)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.BaseTypeElement) as TokenIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.UrlElement) as UriIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.VersionElement) as TokenIndex;
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
                Index = IndexSettingSupport.SetIndex(Index, item2.Base.PathElement) as Res_StructureDefinition_Index_base_path;
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
                Index = IndexSettingSupport.SetIndex(Index, item2.Base.PathElement) as Res_StructureDefinition_Index_base_path;
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
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_StructureDefinition_Index_code;
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
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_StructureDefinition_Index_context;
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
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_StructureDefinition_Index_ext_context;
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
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_StructureDefinition_Index_identifier;
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
              Index = IndexSettingSupport.SetIndex(Index, item2.PathElement) as Res_StructureDefinition_Index_path;
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
              Index = IndexSettingSupport.SetIndex(Index, item2.PathElement) as Res_StructureDefinition_Index_path;
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
                Index = IndexSettingSupport.SetIndex(Index, item2.Binding.ValueSet) as Res_StructureDefinition_Index_valueset;
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
                IndexSettingSupport.SetIndex(Index, item2.Binding.ValueSet, FhirRequestUri, this);
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
              var Index = new Res_StructureDefinition_Index_profile();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_StructureDefinition_Index_profile;
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
              var Index = new Res_StructureDefinition_Index_security();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_StructureDefinition_Index_security;
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
              var Index = new Res_StructureDefinition_Index_tag();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_StructureDefinition_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

