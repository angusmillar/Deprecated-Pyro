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
  public partial class AppointmentRepository : CommonRepository, IResourceRepository
  {

    public AppointmentRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Appointment;
      var ResourceEntity = new Res_Appointment();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Appointment>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Appointment;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Appointment_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Appointment_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Appointment_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Appointment_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Appointment_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Appointment>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Appointment>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Appointment>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Appointment LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Appointment, object>>>();
      IncludeList.Add(x => x.actor_List);
      IncludeList.Add(x => x.appointment_type_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.part_status_List);
      IncludeList.Add(x => x.patient_List);
      IncludeList.Add(x => x.practitioner_List);
      IncludeList.Add(x => x.service_type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Appointment>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Appointment ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Appointment_Index_actor.RemoveRange(ResourceEntity.actor_List);            
      _Context.Res_Appointment_Index_appointment_type.RemoveRange(ResourceEntity.appointment_type_List);            
      _Context.Res_Appointment_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Appointment_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_Appointment_Index_part_status.RemoveRange(ResourceEntity.part_status_List);            
      _Context.Res_Appointment_Index_patient.RemoveRange(ResourceEntity.patient_List);            
      _Context.Res_Appointment_Index_practitioner.RemoveRange(ResourceEntity.practitioner_List);            
      _Context.Res_Appointment_Index_service_type.RemoveRange(ResourceEntity.service_type_List);            
      _Context.Res_Appointment_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Appointment_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Appointment_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Appointment ResourseEntity, string ResourceVersion, Appointment ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Start != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.StartElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
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

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Appointment_Index_actor(), item1.Actor, FhirRequestUri, this) as Res_Appointment_Index_actor;
          if (Index != null)
          {
            ResourseEntity.actor_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.AppointmentType != null)
      {
        foreach (var item3 in ResourceTyped.AppointmentType.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_appointment_type(), item3) as Res_Appointment_Index_appointment_type;
          ResourseEntity.appointment_type_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_identifier(), item3) as Res_Appointment_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Appointment_Index_location(), item1.Actor, FhirRequestUri, this) as Res_Appointment_Index_location;
          if (Index != null)
          {
            ResourseEntity.location_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Status != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_part_status(), item1.StatusElement) as Res_Appointment_Index_part_status;
          ResourseEntity.part_status_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Appointment_Index_patient(), item1.Actor, FhirRequestUri, this) as Res_Appointment_Index_patient;
          if (Index != null)
          {
            ResourseEntity.patient_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Participant)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Appointment_Index_practitioner(), item1.Actor, FhirRequestUri, this) as Res_Appointment_Index_practitioner;
          if (Index != null)
          {
            ResourseEntity.practitioner_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.ServiceType != null)
      {
        foreach (var item3 in ResourceTyped.ServiceType)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_service_type(), item4) as Res_Appointment_Index_service_type;
              ResourseEntity.service_type_List.Add(Index);
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
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Appointment_Index_profile(), item4) as Res_Appointment_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_security(), item4) as Res_Appointment_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Appointment_Index_tag(), item4) as Res_Appointment_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

