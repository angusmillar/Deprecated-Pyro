using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.Search;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class DocumentReferenceRepository : CommonRepository, IResourceRepository
  {
    public DocumentReferenceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_DocumentReference>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_DocumentReference>(Predicate);
      var Query = DbGetAll<Res_DocumentReference>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);      
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = TotalRecordCount;
      DatabaseOperationOutcome.ResourcesMatchingSearchList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DocumentReference;
      var ResourceEntity = new Res_DocumentReference();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_DocumentReference>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as DocumentReference;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_DocumentReference_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DocumentReference_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_DocumentReference_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_DocumentReference_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_DocumentReference_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_DocumentReference>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_DocumentReference>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_DocumentReference>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_DocumentReference LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_DocumentReference, object>>>();
      IncludeList.Add(x => x.author_List);
      IncludeList.Add(x => x.class_List);
      IncludeList.Add(x => x.event_List);
      IncludeList.Add(x => x.facility_List);
      IncludeList.Add(x => x.format_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.language_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.related_id_List);
      IncludeList.Add(x => x.related_ref_List);
      IncludeList.Add(x => x.relatesto_List);
      IncludeList.Add(x => x.relation_List);
      IncludeList.Add(x => x.securitylabel_List);
      IncludeList.Add(x => x.setting_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_DocumentReference>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_DocumentReference ResourceEntity)
    {
      ResourceEntity.authenticator_VersionId = null;      
      ResourceEntity.authenticator_FhirId = null;      
      ResourceEntity.authenticator_Type = null;      
      ResourceEntity.authenticator_Url = null;      
      ResourceEntity.authenticator_ServiceRootURL_StoreID = null;      
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.custodian_VersionId = null;      
      ResourceEntity.custodian_FhirId = null;      
      ResourceEntity.custodian_Type = null;      
      ResourceEntity.custodian_Url = null;      
      ResourceEntity.custodian_ServiceRootURL_StoreID = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.encounter_VersionId = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_ServiceRootURL_StoreID = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.indexed_DateTimeOffset = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.period_DateTimeOffsetLow = null;      
      ResourceEntity.period_DateTimeOffsetHigh = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_VersionId = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_DocumentReference_Index_author.RemoveRange(ResourceEntity.author_List);            
      _Context.Res_DocumentReference_Index_class.RemoveRange(ResourceEntity.class_List);            
      _Context.Res_DocumentReference_Index_event.RemoveRange(ResourceEntity.event_List);            
      _Context.Res_DocumentReference_Index_facility.RemoveRange(ResourceEntity.facility_List);            
      _Context.Res_DocumentReference_Index_format.RemoveRange(ResourceEntity.format_List);            
      _Context.Res_DocumentReference_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_DocumentReference_Index_language.RemoveRange(ResourceEntity.language_List);            
      _Context.Res_DocumentReference_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_DocumentReference_Index_related_id.RemoveRange(ResourceEntity.related_id_List);            
      _Context.Res_DocumentReference_Index_related_ref.RemoveRange(ResourceEntity.related_ref_List);            
      _Context.Res_DocumentReference_Index_relatesto.RemoveRange(ResourceEntity.relatesto_List);            
      _Context.Res_DocumentReference_Index_relation.RemoveRange(ResourceEntity.relation_List);            
      _Context.Res_DocumentReference_Index_securitylabel.RemoveRange(ResourceEntity.securitylabel_List);            
      _Context.Res_DocumentReference_Index_setting.RemoveRange(ResourceEntity.setting_List);            
      _Context.Res_DocumentReference_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_DocumentReference_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_DocumentReference_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_DocumentReference_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_DocumentReference ResourseEntity, string ResourceVersion, DocumentReference ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Authenticator != null)
      {
        if (ResourceTyped.Authenticator is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Authenticator, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.authenticator_Type = Index.Type;
            ResourseEntity.authenticator_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.authenticator_Url = Index.Url;
            }
            else
            {
              ResourseEntity.authenticator_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Created != null)
      {
        if (ResourceTyped.CreatedElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.CreatedElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.created_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Custodian != null)
      {
        if (ResourceTyped.Custodian is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Custodian, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.custodian_Type = Index.Type;
            ResourseEntity.custodian_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.custodian_Url = Index.Url;
            }
            else
            {
              ResourseEntity.custodian_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Description != null)
      {
        if (ResourceTyped.DescriptionElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.DescriptionElement, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.description_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context.Encounter != null)
        {
          if (ResourceTyped.Context.Encounter is Hl7.Fhir.Model.ResourceReference)
          {
            var Index = new ReferenceIndex();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Context.Encounter, Index, FhirRequestUri, this) as ReferenceIndex;
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
                ResourseEntity.encounter_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
              }
            }
          }
        }
      }

      if (ResourceTyped.MasterIdentifier != null)
      {
        if (ResourceTyped.MasterIdentifier is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.MasterIdentifier, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.identifier_Code = Index.Code;
            ResourseEntity.identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Indexed != null)
      {
        if (ResourceTyped.IndexedElement is Hl7.Fhir.Model.Instant)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.IndexedElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.indexed_DateTimeOffset = Index.DateTimeOffset;
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
              ResourseEntity.patient_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context.Period != null)
        {
          if (ResourceTyped.Context.Period is Hl7.Fhir.Model.Period)
          {
            var Index = new DateTimePeriodIndex();
            Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Context.Period, Index) as DateTimePeriodIndex;
            if (Index != null)
            {
              ResourseEntity.period_DateTimeOffsetLow = Index.DateTimeOffsetLow;
              ResourseEntity.period_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DocumentReferenceStatus>)
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
              ResourseEntity.subject_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Author != null)
      {
        foreach (var item in ResourceTyped.Author)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_DocumentReference_Index_author();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_DocumentReference_Index_author;
            if (Index != null)
            {
              ResourseEntity.author_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Class != null)
      {
        foreach (var item3 in ResourceTyped.Class.Coding)
        {
          var Index = new Res_DocumentReference_Index_class();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DocumentReference_Index_class;
          ResourseEntity.class_List.Add(Index);
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context.Event != null)
        {
          foreach (var item4 in ResourceTyped.Context.Event)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = new Res_DocumentReference_Index_event();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_DocumentReference_Index_event;
                ResourseEntity.event_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context.FacilityType != null)
        {
          foreach (var item4 in ResourceTyped.Context.FacilityType.Coding)
          {
            var Index = new Res_DocumentReference_Index_facility();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_facility;
            ResourseEntity.facility_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Content)
      {
        if (item1.Format != null)
        {
          foreach (var item4 in item1.Format)
          {
            if (item4 is Hl7.Fhir.Model.Coding)
            {
              var Index = new Res_DocumentReference_Index_format();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_format;
              ResourseEntity.format_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_DocumentReference_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DocumentReference_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Content)
      {
        if (item1.Attachment != null)
        {
          if (item1.Attachment.Language != null)
          {
            if (item1.Attachment.LanguageElement is Hl7.Fhir.Model.Code)
            {
              var Index = new Res_DocumentReference_Index_language();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.Attachment.LanguageElement, Index) as Res_DocumentReference_Index_language;
              ResourseEntity.language_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Content)
      {
        if (item1.Attachment != null)
        {
          if (item1.Attachment.Url != null)
          {
            if (item1.Attachment.UrlElement is Hl7.Fhir.Model.FhirUri)
            {
              var Index = new Res_DocumentReference_Index_location();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.Attachment.UrlElement, Index) as Res_DocumentReference_Index_location;
              ResourseEntity.location_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        foreach (var item2 in ResourceTyped.Context.Related)
        {
          if (item2.Identifier != null)
          {
            if (item2.Identifier is Hl7.Fhir.Model.Identifier)
            {
              var Index = new Res_DocumentReference_Index_related_id();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2.Identifier, Index) as Res_DocumentReference_Index_related_id;
              ResourseEntity.related_id_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        foreach (var item2 in ResourceTyped.Context.Related)
        {
          if (item2.Ref != null)
          {
            if (item2.Ref is ResourceReference)
            {
              var Index = new Res_DocumentReference_Index_related_ref();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item2.Ref, Index, FhirRequestUri, this) as Res_DocumentReference_Index_related_ref;
              if (Index != null)
              {
                ResourseEntity.related_ref_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.RelatesTo)
      {
        if (item1.Target != null)
        {
          if (item1.Target is ResourceReference)
          {
            var Index = new Res_DocumentReference_Index_relatesto();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Target, Index, FhirRequestUri, this) as Res_DocumentReference_Index_relatesto;
            if (Index != null)
            {
              ResourseEntity.relatesto_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.RelatesTo)
      {
        if (item1.Code != null)
        {
          if (item1.CodeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType>)
          {
            var Index = new Res_DocumentReference_Index_relation();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.CodeElement, Index) as Res_DocumentReference_Index_relation;
            ResourseEntity.relation_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.SecurityLabel != null)
      {
        foreach (var item3 in ResourceTyped.SecurityLabel)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_DocumentReference_Index_securitylabel();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_securitylabel;
              ResourseEntity.securitylabel_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context.PracticeSetting != null)
        {
          foreach (var item4 in ResourceTyped.Context.PracticeSetting.Coding)
          {
            var Index = new Res_DocumentReference_Index_setting();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_setting;
            ResourseEntity.setting_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = new Res_DocumentReference_Index_type();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_DocumentReference_Index_type;
          ResourseEntity.type_List.Add(Index);
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
              var Index = new Res_DocumentReference_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_DocumentReference_Index_profile;
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
              var Index = new Res_DocumentReference_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_security;
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
              var Index = new Res_DocumentReference_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_DocumentReference_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

