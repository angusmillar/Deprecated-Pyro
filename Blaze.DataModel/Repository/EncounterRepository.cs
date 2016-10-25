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
  public partial class EncounterRepository : CommonRepository, IResourceRepository
  {
    public EncounterRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_Encounter>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_Encounter>(Predicate);
      var Query = DbGetAll<Res_Encounter>(Predicate);

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
      var ResourceTyped = Resource as Encounter;
      var ResourceEntity = new Res_Encounter();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Encounter>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Encounter;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Encounter_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Encounter_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Encounter_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Encounter_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_Encounter_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Encounter>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Encounter LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Encounter, object>>>();
      IncludeList.Add(x => x.condition_List);
      IncludeList.Add(x => x.episodeofcare_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.incomingreferral_List);
      IncludeList.Add(x => x.indication_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.location_period_List);
      IncludeList.Add(x => x.participant_List);
      IncludeList.Add(x => x.participant_type_List);
      IncludeList.Add(x => x.practitioner_List);
      IncludeList.Add(x => x.procedure_List);
      IncludeList.Add(x => x.reason_List);
      IncludeList.Add(x => x.special_arrangement_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Encounter>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Encounter ResourceEntity)
    {
      ResourceEntity.appointment_VersionId = null;      
      ResourceEntity.appointment_FhirId = null;      
      ResourceEntity.appointment_Type = null;      
      ResourceEntity.appointment_Url = null;      
      ResourceEntity.appointment_ServiceRootURL_StoreID = null;      
      ResourceEntity.class_Code = null;      
      ResourceEntity.class_System = null;      
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.length_Comparator = null;      
      ResourceEntity.length_Quantity = null;      
      ResourceEntity.part_of_VersionId = null;      
      ResourceEntity.part_of_FhirId = null;      
      ResourceEntity.part_of_Type = null;      
      ResourceEntity.part_of_Url = null;      
      ResourceEntity.part_of_ServiceRootURL_StoreID = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Encounter_Index_condition.RemoveRange(ResourceEntity.condition_List);            
      _Context.Res_Encounter_Index_episodeofcare.RemoveRange(ResourceEntity.episodeofcare_List);            
      _Context.Res_Encounter_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Encounter_Index_incomingreferral.RemoveRange(ResourceEntity.incomingreferral_List);            
      _Context.Res_Encounter_Index_indication.RemoveRange(ResourceEntity.indication_List);            
      _Context.Res_Encounter_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_Encounter_Index_location_period.RemoveRange(ResourceEntity.location_period_List);            
      _Context.Res_Encounter_Index_participant.RemoveRange(ResourceEntity.participant_List);            
      _Context.Res_Encounter_Index_participant_type.RemoveRange(ResourceEntity.participant_type_List);            
      _Context.Res_Encounter_Index_practitioner.RemoveRange(ResourceEntity.practitioner_List);            
      _Context.Res_Encounter_Index_procedure.RemoveRange(ResourceEntity.procedure_List);            
      _Context.Res_Encounter_Index_reason.RemoveRange(ResourceEntity.reason_List);            
      _Context.Res_Encounter_Index_special_arrangement.RemoveRange(ResourceEntity.special_arrangement_List);            
      _Context.Res_Encounter_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Encounter_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Encounter_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Encounter_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Encounter ResourseEntity, string ResourceVersion, Encounter ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Appointment != null)
      {
        if (ResourceTyped.Appointment is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Appointment, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.appointment_Type = Index.Type;
            ResourseEntity.appointment_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.appointment_Url = Index.Url;
            }
            else
            {
              ResourseEntity.appointment_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Class != null)
      {
        if (ResourceTyped.Class is Hl7.Fhir.Model.Coding)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Class, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.class_Code = Index.Code;
            ResourseEntity.class_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Period != null)
      {
        if (ResourceTyped.Period is Hl7.Fhir.Model.Period)
        {
          var Index = new DateTimePeriodIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(ResourceTyped.Period, Index) as DateTimePeriodIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffsetLow;
            ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffsetHigh;
          }
        }
      }

      if (ResourceTyped.Length != null)
      {
        if (ResourceTyped.Length is Hl7.Fhir.Model.Duration)
        {
          var Index = new NumberIndex();
          Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(ResourceTyped.Length, Index) as NumberIndex;
          if (Index != null)
          {
            ResourseEntity.length_Comparator = Index.Comparator;
            ResourseEntity.length_Quantity = Index.Quantity;
          }
        }
      }

      if (ResourceTyped.PartOf != null)
      {
        if (ResourceTyped.PartOf is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.PartOf, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.part_of_Type = Index.Type;
            ResourseEntity.part_of_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.part_of_Url = Index.Url;
            }
            else
            {
              ResourseEntity.part_of_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Patient, Index, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.Encounter.EncounterStatus>)
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

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Encounter_Index_condition();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Encounter_Index_condition;
            if (Index != null)
            {
              ResourseEntity.condition_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.EpisodeOfCare != null)
      {
        foreach (var item in ResourceTyped.EpisodeOfCare)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Encounter_Index_episodeofcare();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Encounter_Index_episodeofcare;
            if (Index != null)
            {
              ResourseEntity.episodeofcare_List.Add(Index);
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
            var Index = new Res_Encounter_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Encounter_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.IncomingReferral != null)
      {
        foreach (var item in ResourceTyped.IncomingReferral)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Encounter_Index_incomingreferral();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Encounter_Index_incomingreferral;
            if (Index != null)
            {
              ResourseEntity.incomingreferral_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Encounter_Index_indication();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Encounter_Index_indication;
            if (Index != null)
            {
              ResourseEntity.indication_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Location)
      {
        if (item1.Location != null)
        {
          if (item1.Location is ResourceReference)
          {
            var Index = new Res_Encounter_Index_location();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Location, Index, FhirRequestUri, this) as Res_Encounter_Index_location;
            if (Index != null)
            {
              ResourseEntity.location_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Location)
      {
        if (item1.Period != null)
        {
          if (item1.Period is Period)
          {
            var Index = new Res_Encounter_Index_location_period();
            Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(item1.Period, Index) as Res_Encounter_Index_location_period;
            ResourseEntity.location_period_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Individual != null)
        {
          if (item1.Individual is ResourceReference)
          {
            var Index = new Res_Encounter_Index_participant();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Individual, Index, FhirRequestUri, this) as Res_Encounter_Index_participant;
            if (Index != null)
            {
              ResourseEntity.participant_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Type != null)
        {
          foreach (var item4 in item1.Type)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = new Res_Encounter_Index_participant_type();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_Encounter_Index_participant_type;
                ResourseEntity.participant_type_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Individual != null)
        {
          if (item1.Individual is ResourceReference)
          {
            var Index = new Res_Encounter_Index_practitioner();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Individual, Index, FhirRequestUri, this) as Res_Encounter_Index_practitioner;
            if (Index != null)
            {
              ResourseEntity.practitioner_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Encounter_Index_procedure();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Encounter_Index_procedure;
            if (Index != null)
            {
              ResourseEntity.procedure_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Reason != null)
      {
        foreach (var item3 in ResourceTyped.Reason)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_Encounter_Index_reason();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Encounter_Index_reason;
              ResourseEntity.reason_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Hospitalization != null)
      {
        if (ResourceTyped.Hospitalization.SpecialArrangement != null)
        {
          foreach (var item4 in ResourceTyped.Hospitalization.SpecialArrangement)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = new Res_Encounter_Index_special_arrangement();
                Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item5, Index) as Res_Encounter_Index_special_arrangement;
                ResourseEntity.special_arrangement_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = new Res_Encounter_Index_type();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Encounter_Index_type;
              ResourseEntity.type_List.Add(Index);
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
              var Index = new Res_Encounter_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Encounter_Index__profile;
              ResourseEntity._profile_List.Add(Index);
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
              var Index = new Res_Encounter_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Encounter_Index__security;
              ResourseEntity._security_List.Add(Index);
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
              var Index = new Res_Encounter_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Encounter_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

