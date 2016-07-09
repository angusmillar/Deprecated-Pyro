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
  public partial class EncounterRepository : CommonRepository, IResourceRepository
  {

    public EncounterRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

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
        DtoResource = DbGetALL<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Encounter>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
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
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Encounter>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Encounter ResourceEntity)
    {
      ResourceEntity.appointment_FhirId = null;      
      ResourceEntity.appointment_Type = null;      
      ResourceEntity.appointment_Url = null;      
      ResourceEntity.appointment_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.date_DateTimeOffsetLow = null;      
      ResourceEntity.date_DateTimeOffsetHigh = null;      
      ResourceEntity.length_Number = null;      
      ResourceEntity.part_of_FhirId = null;      
      ResourceEntity.part_of_Type = null;      
      ResourceEntity.part_of_Url = null;      
      ResourceEntity.part_of_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
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
      _Context.Res_Encounter_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Encounter_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Encounter_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Encounter ResourseEntity, string ResourceVersion, Encounter ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Appointment != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Appointment, FhirRequestUri, this);
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
              ResourseEntity.appointment_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Period != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Period);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffsetLow = Index.DateTimeOffset;
          ResourseEntity.date_DateTimeOffsetHigh = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Length != null)
      {
        var Index = IndexSettingSupport.SetIndex<NumberIndex>(new NumberIndex(), ResourceTyped.Length);
        if (Index != null)
        {
          ResourseEntity.length_Number = Index.Number;
        }
      }

      if (ResourceTyped.PartOf != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.PartOf, FhirRequestUri, this);
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
              ResourseEntity.part_of_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Patient, FhirRequestUri, this);
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
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_condition(), item, FhirRequestUri, this) as Res_Encounter_Index_condition;
          if (Index != null)
          {
            ResourseEntity.condition_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.EpisodeOfCare != null)
      {
        foreach (var item in ResourceTyped.EpisodeOfCare)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_episodeofcare(), item, FhirRequestUri, this) as Res_Encounter_Index_episodeofcare;
          if (Index != null)
          {
            ResourseEntity.episodeofcare_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_identifier(), item3) as Res_Encounter_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      if (ResourceTyped.IncomingReferral != null)
      {
        foreach (var item in ResourceTyped.IncomingReferral)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_incomingreferral(), item, FhirRequestUri, this) as Res_Encounter_Index_incomingreferral;
          if (Index != null)
          {
            ResourseEntity.incomingreferral_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_indication(), item, FhirRequestUri, this) as Res_Encounter_Index_indication;
          if (Index != null)
          {
            ResourseEntity.indication_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Location)
      {
        if (item1.Location != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_location(), item1.Location, FhirRequestUri, this) as Res_Encounter_Index_location;
          if (Index != null)
          {
            ResourseEntity.location_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Location)
      {
        if (item1.Period != null)
        {
          var Index = IndexSettingSupport.SetIndex<DatePeriodIndex>(new Res_Encounter_Index_location_period(), item1.Period) as Res_Encounter_Index_location_period;
          ResourseEntity.location_period_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Individual != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_participant(), item1.Individual, FhirRequestUri, this) as Res_Encounter_Index_participant;
          if (Index != null)
          {
            ResourseEntity.participant_List.Add(Index);
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
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_participant_type(), item5) as Res_Encounter_Index_participant_type;
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
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_practitioner(), item1.Individual, FhirRequestUri, this) as Res_Encounter_Index_practitioner;
          if (Index != null)
          {
            ResourseEntity.practitioner_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Indication != null)
      {
        foreach (var item in ResourceTyped.Indication)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Encounter_Index_procedure(), item, FhirRequestUri, this) as Res_Encounter_Index_procedure;
          if (Index != null)
          {
            ResourseEntity.procedure_List.Add(Index);
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
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_reason(), item4) as Res_Encounter_Index_reason;
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
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_special_arrangement(), item5) as Res_Encounter_Index_special_arrangement;
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
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_type(), item4) as Res_Encounter_Index_type;
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
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Encounter_Index_profile(), item4) as Res_Encounter_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_security(), item4) as Res_Encounter_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Encounter_Index_tag(), item4) as Res_Encounter_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

