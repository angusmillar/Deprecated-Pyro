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
  public partial class DiagnosticOrderRepository : CommonRepository, IResourceRepository
  {

    public DiagnosticOrderRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      throw new NotImplementedException("Resource Search not implemented in Db layer");
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DiagnosticOrder;
      var ResourceEntity = new Res_DiagnosticOrder();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_DiagnosticOrder>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DiagnosticOrder;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_DiagnosticOrder_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DiagnosticOrder_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_DiagnosticOrder_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DiagnosticOrder_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_DiagnosticOrder_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_DiagnosticOrder>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_DiagnosticOrder LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_DiagnosticOrder, object>>>();
      IncludeList.Add(x => x.actor_List);
      IncludeList.Add(x => x.actor_List);
      IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.event_date_List);
      IncludeList.Add(x => x.event_status_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.item_date_List);
      IncludeList.Add(x => x.item_past_status_List);
      IncludeList.Add(x => x.item_status_List);
      IncludeList.Add(x => x.specimen_List);
      IncludeList.Add(x => x.specimen_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_DiagnosticOrder>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_DiagnosticOrder ResourceEntity)
    {
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.orderer_FhirId = null;      
      ResourceEntity.orderer_Type = null;      
      ResourceEntity.orderer_Url = null;      
      ResourceEntity.orderer_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_DiagnosticOrder_Index_actor.RemoveRange(ResourceEntity.actor_List);            
      _Context.Res_DiagnosticOrder_Index_actor.RemoveRange(ResourceEntity.actor_List);            
      _Context.Res_DiagnosticOrder_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_DiagnosticOrder_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_DiagnosticOrder_Index_event_date.RemoveRange(ResourceEntity.event_date_List);            
      _Context.Res_DiagnosticOrder_Index_event_status.RemoveRange(ResourceEntity.event_status_List);            
      _Context.Res_DiagnosticOrder_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_DiagnosticOrder_Index_item_date.RemoveRange(ResourceEntity.item_date_List);            
      _Context.Res_DiagnosticOrder_Index_item_past_status.RemoveRange(ResourceEntity.item_past_status_List);            
      _Context.Res_DiagnosticOrder_Index_item_status.RemoveRange(ResourceEntity.item_status_List);            
      _Context.Res_DiagnosticOrder_Index_specimen.RemoveRange(ResourceEntity.specimen_List);            
      _Context.Res_DiagnosticOrder_Index_specimen.RemoveRange(ResourceEntity.specimen_List);            
      _Context.Res_DiagnosticOrder_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_DiagnosticOrder_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_DiagnosticOrder_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_DiagnosticOrder ResourseEntity, string ResourceVersion, DiagnosticOrder ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Encounter != null)
      {
        if (ResourceTyped.Encounter is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Encounter, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.encounter_Type = Index.Type;
            ResourseEntity.encounter_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.encounter_Url = Index.Url;
            }
            else
            {
              ResourseEntity.encounter_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Orderer != null)
      {
        if (ResourceTyped.Orderer is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Orderer, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.orderer_Type = Index.Type;
            ResourseEntity.orderer_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.orderer_Url = Index.Url;
            }
            else
            {
              ResourseEntity.orderer_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.patient_Type = Index.Type;
            ResourseEntity.patient_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.patient_Url = Index.Url;
            }
            else
            {
              ResourseEntity.patient_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>)
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

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Subject, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.subject_Type = Index.Type;
            ResourseEntity.subject_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.subject_Url = Index.Url;
            }
            else
            {
              ResourseEntity.subject_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Event)
      {
        if (item1.Actor != null)
        {
          if (item1.Actor is ResourceReference)
          {
            var Index = new Res_DiagnosticOrder_Index_actor();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Actor, Index, FhirRequestUri, this) as Res_DiagnosticOrder_Index_actor;
            if (Index != null)
            {
              ResourseEntity.actor_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        foreach (var item2 in item1.Event)
        {
          if (item2.Actor != null)
          {
            if (item2.Actor is ResourceReference)
            {
              var Index = new Res_DiagnosticOrder_Index_actor();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Actor, Index, FhirRequestUri, this) as Res_DiagnosticOrder_Index_actor;
              if (Index != null)
              {
                ResourseEntity.actor_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        if (item1.BodySite != null)
        {
          foreach (var item4 in item1.BodySite.Coding)
          {
            var Index = new Res_DiagnosticOrder_Index_bodysite();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticOrder_Index_bodysite;
            ResourseEntity.bodysite_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = new Res_DiagnosticOrder_Index_code();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticOrder_Index_code;
            ResourseEntity.code_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Event)
      {
        if (item1.DateTime != null)
        {
          if (item1.DateTimeElement is Hl7.Fhir.Model.FhirDateTime)
          {
            var Index = new Res_DiagnosticOrder_Index_event_date();
            Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(item1.DateTimeElement, Index) as Res_DiagnosticOrder_Index_event_date;
            ResourseEntity.event_date_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Event)
      {
        if (item1.Status != null)
        {
          if (item1.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>)
          {
            var Index = new Res_DiagnosticOrder_Index_event_status();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.StatusElement, Index) as Res_DiagnosticOrder_Index_event_status;
            ResourseEntity.event_status_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_DiagnosticOrder_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DiagnosticOrder_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        foreach (var item2 in item1.Event)
        {
          if (item2.DateTime != null)
          {
            if (item2.DateTimeElement is Hl7.Fhir.Model.FhirDateTime)
            {
              var Index = new Res_DiagnosticOrder_Index_item_date();
              Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(item2.DateTimeElement, Index) as Res_DiagnosticOrder_Index_item_date;
              ResourseEntity.item_date_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        foreach (var item2 in item1.Event)
        {
          if (item2.Status != null)
          {
            if (item2.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>)
            {
              var Index = new Res_DiagnosticOrder_Index_item_past_status();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.StatusElement, Index) as Res_DiagnosticOrder_Index_item_past_status;
              ResourseEntity.item_past_status_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        if (item1.Status != null)
        {
          if (item1.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>)
          {
            var Index = new Res_DiagnosticOrder_Index_item_status();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.StatusElement, Index) as Res_DiagnosticOrder_Index_item_status;
            ResourseEntity.item_status_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Specimen != null)
      {
        foreach (var item in ResourceTyped.Specimen)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DiagnosticOrder_Index_specimen();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticOrder_Index_specimen;
            if (Index != null)
            {
              ResourseEntity.specimen_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Item)
      {
        if (item1.Specimen != null)
        {
          foreach (var item in item1.Specimen)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_DiagnosticOrder_Index_specimen();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DiagnosticOrder_Index_specimen;
              if (Index != null)
              {
                ResourseEntity.specimen_List.Add(Index);
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
              var Index = new Res_DiagnosticOrder_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_DiagnosticOrder_Index_profile;
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
              var Index = new Res_DiagnosticOrder_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticOrder_Index_security;
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
              var Index = new Res_DiagnosticOrder_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DiagnosticOrder_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

