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
  public partial class SubstanceRepository : CommonRepository, IResourceRepository
  {

    public SubstanceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Substance;
      var ResourceEntity = new Res_Substance();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Substance>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Substance;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Substance_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Substance_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Substance_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Substance_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Substance_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Substance>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Substance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Substance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Substance LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Substance, object>>>();
      IncludeList.Add(x => x.category_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.container_identifier_List);
      IncludeList.Add(x => x.expiry_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.quantity_List);
      IncludeList.Add(x => x.substance_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Substance>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Substance ResourceEntity)
    {
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Substance_Index_category.RemoveRange(ResourceEntity.category_List);            
      _Context.Res_Substance_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_Substance_Index_container_identifier.RemoveRange(ResourceEntity.container_identifier_List);            
      _Context.Res_Substance_Index_expiry.RemoveRange(ResourceEntity.expiry_List);            
      _Context.Res_Substance_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Substance_Index_quantity.RemoveRange(ResourceEntity.quantity_List);            
      _Context.Res_Substance_Index_substance.RemoveRange(ResourceEntity.substance_List);            
      _Context.Res_Substance_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Substance_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Substance_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Substance ResourseEntity, string ResourceVersion, Substance ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Category != null)
      {
        foreach (var item3 in ResourceTyped.Category)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_category(), item4) as Res_Substance_Index_category;
              ResourseEntity.category_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_code(), item3) as Res_Substance_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Identifier != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_container_identifier(), item1.Identifier) as Res_Substance_Index_container_identifier;
          ResourseEntity.container_identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Expiry != null)
        {
          var Index = IndexSettingSupport.SetIndex<DateIndex>(new Res_Substance_Index_expiry(), item1.ExpiryElement) as Res_Substance_Index_expiry;
          ResourseEntity.expiry_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_identifier(), item3) as Res_Substance_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Quantity != null)
        {
          var Index = IndexSettingSupport.SetIndex<QuantityIndex>(new Res_Substance_Index_quantity(), item1.Quantity) as Res_Substance_Index_quantity;
          ResourseEntity.quantity_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Ingredient)
      {
        if (item1.Substance != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Substance_Index_substance(), item1.Substance, FhirRequestUri, this) as Res_Substance_Index_substance;
          if (Index != null)
          {
            ResourseEntity.substance_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Substance_Index_profile(), item4) as Res_Substance_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_security(), item4) as Res_Substance_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Substance_Index_tag(), item4) as Res_Substance_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

