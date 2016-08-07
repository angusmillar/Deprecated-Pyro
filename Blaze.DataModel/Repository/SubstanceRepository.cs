using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class SubstanceRepository : CommonRepository, IResourceRepository
  {

    public SubstanceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      throw new NotImplementedException("Resource Search not implemented in Db layer");
    }

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
      ResourceEntity.XmlBlob = string.Empty;
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
              var Index = new Res_Substance_Index_category();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Substance_Index_category;
              ResourseEntity.category_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = new Res_Substance_Index_code();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Substance_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Identifier != null)
        {
          if (item1.Identifier is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_Substance_Index_container_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.Identifier, Index) as Res_Substance_Index_container_identifier;
            ResourseEntity.container_identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Expiry != null)
        {
          if (item1.ExpiryElement is Hl7.Fhir.Model.FhirDateTime)
          {
            var Index = new Res_Substance_Index_expiry();
            Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(item1.ExpiryElement, Index) as Res_Substance_Index_expiry;
            ResourseEntity.expiry_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_Substance_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Substance_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Instance)
      {
        if (item1.Quantity != null)
        {
          if (item1.Quantity is Hl7.Fhir.Model.SimpleQuantity)
          {
            var Index = new Res_Substance_Index_quantity();
            Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(item1.Quantity, Index) as Res_Substance_Index_quantity;
            ResourseEntity.quantity_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Ingredient)
      {
        if (item1.Substance != null)
        {
          if (item1.Substance is ResourceReference)
          {
            var Index = new Res_Substance_Index_substance();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Substance, Index, FhirRequestUri, this) as Res_Substance_Index_substance;
            if (Index != null)
            {
              ResourseEntity.substance_List.Add(Index);
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
              var Index = new Res_Substance_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Substance_Index_profile;
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
              var Index = new Res_Substance_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Substance_Index_security;
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
              var Index = new Res_Substance_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Substance_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

