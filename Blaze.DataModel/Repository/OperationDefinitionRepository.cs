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
  public partial class OperationDefinitionRepository : CommonRepository, IResourceRepository
  {

    public OperationDefinitionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as OperationDefinition;
      var ResourceEntity = new Res_OperationDefinition();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_OperationDefinition>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as OperationDefinition;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_OperationDefinition_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_OperationDefinition_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_OperationDefinition_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_OperationDefinition_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_OperationDefinition_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_OperationDefinition>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_OperationDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_OperationDefinition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_OperationDefinition LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_OperationDefinition, object>>>();
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.paramprofile_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_OperationDefinition>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_OperationDefinition ResourceEntity)
    {
      ResourceEntity.base_FhirId = null;      
      ResourceEntity.base_Type = null;      
      ResourceEntity.base_Url = null;      
      ResourceEntity.base_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.code_Code = null;      
      ResourceEntity.code_System = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.instance_Code = null;      
      ResourceEntity.instance_System = null;      
      ResourceEntity.kind_Code = null;      
      ResourceEntity.kind_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.system_Code = null;      
      ResourceEntity.system_System = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_OperationDefinition_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_OperationDefinition_Index_paramprofile.RemoveRange(ResourceEntity.paramprofile_List);            
      _Context.Res_OperationDefinition_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_OperationDefinition_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_OperationDefinition_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_OperationDefinition_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_OperationDefinition ResourseEntity, string ResourceVersion, OperationDefinition ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Base != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Base, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.base_Type = Index.Type;
            ResourseEntity.base_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.base_Url = Index.Url;
            }
            else
            {
              ResourseEntity.base_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.CodeElement);
        if (Index != null)
        {
          ResourseEntity.code_Code = Index.Code;
          ResourseEntity.code_System = Index.System;
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

      if (ResourceTyped.Instance != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.InstanceElement);
        if (Index != null)
        {
          ResourseEntity.instance_Code = Index.Code;
          ResourseEntity.instance_System = Index.System;
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

      if (ResourceTyped.System != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.SystemElement);
        if (Index != null)
        {
          ResourseEntity.system_Code = Index.Code;
          ResourseEntity.system_System = Index.System;
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

      if (ResourceTyped.UseContext != null)
      {
        foreach (var item3 in ResourceTyped.UseContext)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_OperationDefinition_Index_context(), item4) as Res_OperationDefinition_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Parameter)
      {
        if (item1.Profile != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_OperationDefinition_Index_paramprofile(), item1.Profile, FhirRequestUri, this) as Res_OperationDefinition_Index_paramprofile;
          if (Index != null)
          {
            ResourseEntity.paramprofile_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.TypeElement)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_OperationDefinition_Index_type(), item3) as Res_OperationDefinition_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_OperationDefinition_Index_profile(), item4) as Res_OperationDefinition_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_OperationDefinition_Index_security(), item4) as Res_OperationDefinition_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_OperationDefinition_Index_tag(), item4) as Res_OperationDefinition_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

