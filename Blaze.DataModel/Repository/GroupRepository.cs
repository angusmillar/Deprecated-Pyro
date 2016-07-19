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
  public partial class GroupRepository : CommonRepository, IResourceRepository
  {

    public GroupRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Group;
      var ResourceEntity = new Res_Group();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Group>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Group;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Group_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Group_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Group_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Group_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Group_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Group>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Group>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Group>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Group LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Group, object>>>();
      IncludeList.Add(x => x.characteristic_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.exclude_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.member_List);
      IncludeList.Add(x => x.value_List);
      IncludeList.Add(x => x.value_List);
      IncludeList.Add(x => x.value_List);
      IncludeList.Add(x => x.value_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Group>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Group ResourceEntity)
    {
      ResourceEntity.actual_Code = null;      
      ResourceEntity.actual_System = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Group_Index_characteristic.RemoveRange(ResourceEntity.characteristic_List);            
      _Context.Res_Group_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_Group_Index_exclude.RemoveRange(ResourceEntity.exclude_List);            
      _Context.Res_Group_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Group_Index_member.RemoveRange(ResourceEntity.member_List);            
      _Context.Res_Group_Index_value.RemoveRange(ResourceEntity.value_List);            
      _Context.Res_Group_Index_value.RemoveRange(ResourceEntity.value_List);            
      _Context.Res_Group_Index_value.RemoveRange(ResourceEntity.value_List);            
      _Context.Res_Group_Index_value.RemoveRange(ResourceEntity.value_List);            
      _Context.Res_Group_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Group_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Group_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Group ResourseEntity, string ResourceVersion, Group ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Actual != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.ActualElement);
        if (Index != null)
        {
          ResourseEntity.actual_Code = Index.Code;
          ResourseEntity.actual_System = Index.System;
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

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_characteristic(), item4) as Res_Group_Index_characteristic;
            ResourseEntity.characteristic_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_code(), item3) as Res_Group_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Exclude != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_exclude(), item1.ExcludeElement) as Res_Group_Index_exclude;
          ResourseEntity.exclude_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_identifier(), item3) as Res_Group_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Member)
      {
        if (item1.Entity != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Group_Index_member(), item1.Entity, FhirRequestUri, this) as Res_Group_Index_member;
          if (Index != null)
          {
            ResourseEntity.member_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Value != null)
        {
          if (item1.Value is CodeableConcept)
          {
            CodeableConcept CodeableConcept = item1.Value as CodeableConcept;
            foreach (var item4 in CodeableConcept.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_value(), item4) as Res_Group_Index_value;
              ResourseEntity.value_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Value != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_value(), item1.Value) as Res_Group_Index_value;
          ResourseEntity.value_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Value != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_value(), item1.Value) as Res_Group_Index_value;
          ResourseEntity.value_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Characteristic)
      {
        if (item1.Value != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_value(), item1.Value) as Res_Group_Index_value;
          ResourseEntity.value_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Group_Index_profile(), item4) as Res_Group_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_security(), item4) as Res_Group_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Group_Index_tag(), item4) as Res_Group_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

