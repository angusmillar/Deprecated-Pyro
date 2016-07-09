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
  public partial class SearchParameterRepository : CommonRepository, IResourceRepository
  {

    public SearchParameterRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as SearchParameter;
      var ResourceEntity = new Res_SearchParameter();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_SearchParameter>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as SearchParameter;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_SearchParameter_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_SearchParameter_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_SearchParameter_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_SearchParameter_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_SearchParameter_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_SearchParameter>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_SearchParameter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_SearchParameter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_SearchParameter LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_SearchParameter, object>>>();
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.target_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_SearchParameter>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_SearchParameter ResourceEntity)
    {
      ResourceEntity.base_Code = null;      
      ResourceEntity.base_System = null;      
      ResourceEntity.code_Code = null;      
      ResourceEntity.code_System = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_SearchParameter_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_SearchParameter_Index_target.RemoveRange(ResourceEntity.target_List);            
      _Context.Res_SearchParameter_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_SearchParameter_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_SearchParameter_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_SearchParameter ResourseEntity, string ResourceVersion, SearchParameter ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Base != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.BaseElement);
        if (Index != null)
        {
          ResourseEntity.base_Code = Index.Code;
          ResourseEntity.base_System = Index.System;
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

      if (ResourceTyped.Description != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.DescriptionElement);
        if (Index != null)
        {
          ResourseEntity.description_String = Index.String;
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

      if (ResourceTyped.Type != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.TypeElement);
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

      if (ResourceTyped.UseContext != null)
      {
        foreach (var item3 in ResourceTyped.UseContext)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_SearchParameter_Index_context(), item4) as Res_SearchParameter_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Target != null)
      {
        foreach (var item3 in ResourceTyped.TargetElement)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_SearchParameter_Index_target(), item3) as Res_SearchParameter_Index_target;
          ResourseEntity.target_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_SearchParameter_Index_profile(), item4) as Res_SearchParameter_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_SearchParameter_Index_security(), item4) as Res_SearchParameter_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_SearchParameter_Index_tag(), item4) as Res_SearchParameter_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

