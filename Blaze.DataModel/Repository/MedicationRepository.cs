using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class MedicationRepository : CommonRepository, IResourceRepository
  {

    public MedicationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Medication;
      var ResourceEntity = new Res_Medication();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Medication>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Medication;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Medication_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Medication_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Medication_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Medication_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Medication_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Medication>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Medication>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Medication>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Medication LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Medication, object>>>();
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.container_List);
      IncludeList.Add(x => x.form_List);
      IncludeList.Add(x => x.ingredient_List);
      IncludeList.Add(x => x.ingredient_code_List);
      IncludeList.Add(x => x.package_item_List);
      IncludeList.Add(x => x.package_item_code_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Medication>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Medication ResourceEntity)
    {
      ResourceEntity.manufacturer_FhirId = null;      
      ResourceEntity.manufacturer_Type = null;      
      ResourceEntity.manufacturer_Url = null;      
      ResourceEntity.manufacturer_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Medication_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_Medication_Index_container.RemoveRange(ResourceEntity.container_List);            
      _Context.Res_Medication_Index_form.RemoveRange(ResourceEntity.form_List);            
      _Context.Res_Medication_Index_ingredient.RemoveRange(ResourceEntity.ingredient_List);            
      _Context.Res_Medication_Index_ingredient_code.RemoveRange(ResourceEntity.ingredient_code_List);            
      _Context.Res_Medication_Index_package_item.RemoveRange(ResourceEntity.package_item_List);            
      _Context.Res_Medication_Index_package_item_code.RemoveRange(ResourceEntity.package_item_code_List);            
      _Context.Res_Medication_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Medication_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Medication_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Medication ResourseEntity, string ResourceVersion, Medication ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Manufacturer != null)
      {
        if (ResourceTyped.Manufacturer is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Manufacturer, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.manufacturer_Type = Index.Type;
            ResourseEntity.manufacturer_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.manufacturer_Url = Index.Url;
            }
            else
            {
              ResourseEntity.manufacturer_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Code != null)
      {
        foreach (var item3 in ResourceTyped.Code.Coding)
        {
          var Index = new Res_Medication_Index_code();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Medication_Index_code;
          ResourseEntity.code_List.Add(Index);
        }
      }

      if (ResourceTyped.Package != null)
      {
        if (ResourceTyped.Package.Container != null)
        {
          foreach (var item4 in ResourceTyped.Package.Container.Coding)
          {
            var Index = new Res_Medication_Index_container();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Medication_Index_container;
            ResourseEntity.container_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Product != null)
      {
        if (ResourceTyped.Product.Form != null)
        {
          foreach (var item4 in ResourceTyped.Product.Form.Coding)
          {
            var Index = new Res_Medication_Index_form();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Medication_Index_form;
            ResourseEntity.form_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Product != null)
      {
        foreach (var item2 in ResourceTyped.Product.Ingredient)
        {
          if (item2.Item != null)
          {
            if (item2.Item is ResourceReference)
            {
              var Index = new Res_Medication_Index_ingredient();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Item, Index, FhirRequestUri, this) as Res_Medication_Index_ingredient;
              if (Index != null)
              {
                ResourseEntity.ingredient_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Product != null)
      {
        foreach (var item2 in ResourceTyped.Product.Ingredient)
        {
          if (item2.Item != null)
          {
            if (item2.Item is CodeableConcept)
            {
              CodeableConcept CodeableConcept = item2.Item as CodeableConcept;
              foreach (var item5 in CodeableConcept.Coding)
              {
                var Index = new Res_Medication_Index_ingredient_code();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_Medication_Index_ingredient_code;
                ResourseEntity.ingredient_code_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Package != null)
      {
        foreach (var item2 in ResourceTyped.Package.Content)
        {
          if (item2.Item != null)
          {
            if (item2.Item is ResourceReference)
            {
              var Index = new Res_Medication_Index_package_item();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Item, Index, FhirRequestUri, this) as Res_Medication_Index_package_item;
              if (Index != null)
              {
                ResourseEntity.package_item_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Package != null)
      {
        foreach (var item2 in ResourceTyped.Package.Content)
        {
          if (item2.Item != null)
          {
            if (item2.Item is CodeableConcept)
            {
              CodeableConcept CodeableConcept = item2.Item as CodeableConcept;
              foreach (var item5 in CodeableConcept.Coding)
              {
                var Index = new Res_Medication_Index_package_item_code();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_Medication_Index_package_item_code;
                ResourseEntity.package_item_code_List.Add(Index);
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
              var Index = new Res_Medication_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Medication_Index_profile;
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
              var Index = new Res_Medication_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Medication_Index_security;
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
              var Index = new Res_Medication_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Medication_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

