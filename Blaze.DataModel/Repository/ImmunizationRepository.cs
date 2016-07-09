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
  public partial class ImmunizationRepository : CommonRepository, IResourceRepository
  {

    public ImmunizationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Immunization;
      var ResourceEntity = new Res_Immunization();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Immunization>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Immunization;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Immunization_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Immunization_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Immunization_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Immunization_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Immunization_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Immunization>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Immunization>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Immunization>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Immunization LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Immunization, object>>>();
      IncludeList.Add(x => x.dose_sequence_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.reaction_List);
      IncludeList.Add(x => x.reaction_date_List);
      IncludeList.Add(x => x.reason_List);
      IncludeList.Add(x => x.reason_not_given_List);
      IncludeList.Add(x => x.vaccine_code_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Immunization>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Immunization ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.location_FhirId = null;      
      ResourceEntity.location_Type = null;      
      ResourceEntity.location_Url = null;      
      ResourceEntity.location_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.lot_number_String = null;      
      ResourceEntity.manufacturer_FhirId = null;      
      ResourceEntity.manufacturer_Type = null;      
      ResourceEntity.manufacturer_Url = null;      
      ResourceEntity.manufacturer_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.notgiven_Code = null;      
      ResourceEntity.notgiven_System = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.performer_FhirId = null;      
      ResourceEntity.performer_Type = null;      
      ResourceEntity.performer_Url = null;      
      ResourceEntity.performer_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.requester_FhirId = null;      
      ResourceEntity.requester_Type = null;      
      ResourceEntity.requester_Url = null;      
      ResourceEntity.requester_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Immunization_Index_dose_sequence.RemoveRange(ResourceEntity.dose_sequence_List);            
      _Context.Res_Immunization_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Immunization_Index_reaction.RemoveRange(ResourceEntity.reaction_List);            
      _Context.Res_Immunization_Index_reaction_date.RemoveRange(ResourceEntity.reaction_date_List);            
      _Context.Res_Immunization_Index_reason.RemoveRange(ResourceEntity.reason_List);            
      _Context.Res_Immunization_Index_reason_not_given.RemoveRange(ResourceEntity.reason_not_given_List);            
      _Context.Res_Immunization_Index_vaccine_code.RemoveRange(ResourceEntity.vaccine_code_List);            
      _Context.Res_Immunization_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Immunization_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Immunization_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Immunization ResourseEntity, string ResourceVersion, Immunization ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Date != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.DateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Location != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Location, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.location_Type = Index.Type;
            ResourseEntity.location_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.location_Url = Index.Url;
            }
            else
            {
              ResourseEntity.location_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.LotNumber != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.LotNumberElement);
        if (Index != null)
        {
          ResourseEntity.lot_number_String = Index.String;
        }
      }

      if (ResourceTyped.Manufacturer != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Manufacturer, FhirRequestUri, this);
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

      if (ResourceTyped.WasNotGiven != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.WasNotGivenElement);
        if (Index != null)
        {
          ResourseEntity.notgiven_Code = Index.Code;
          ResourseEntity.notgiven_System = Index.System;
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

      if (ResourceTyped.Performer != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Performer, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.performer_Type = Index.Type;
            ResourseEntity.performer_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.performer_Url = Index.Url;
            }
            else
            {
              ResourseEntity.performer_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Requester != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Requester, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.requester_Type = Index.Type;
            ResourseEntity.requester_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.requester_Url = Index.Url;
            }
            else
            {
              ResourseEntity.requester_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
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

      foreach (var item1 in ResourceTyped.VaccinationProtocol)
      {
        if (item1.DoseSequence != null)
        {
          var Index = IndexSettingSupport.SetIndex<NumberIndex>(new Res_Immunization_Index_dose_sequence(), item1.DoseSequenceElement) as Res_Immunization_Index_dose_sequence;
          ResourseEntity.dose_sequence_List.Add(Index);
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_identifier(), item3) as Res_Immunization_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Detail != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Immunization_Index_reaction(), item1.Detail, FhirRequestUri, this) as Res_Immunization_Index_reaction;
          if (Index != null)
          {
            ResourseEntity.reaction_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Date != null)
        {
          var Index = IndexSettingSupport.SetIndex<DateIndex>(new Res_Immunization_Index_reaction_date(), item1.DateElement) as Res_Immunization_Index_reaction_date;
          ResourseEntity.reaction_date_List.Add(Index);
        }
      }

      if (ResourceTyped.Explanation != null)
      {
        if (ResourceTyped.Explanation.Reason != null)
        {
          foreach (var item4 in ResourceTyped.Explanation.Reason)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_reason(), item5) as Res_Immunization_Index_reason;
                ResourseEntity.reason_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Explanation != null)
      {
        if (ResourceTyped.Explanation.ReasonNotGiven != null)
        {
          foreach (var item4 in ResourceTyped.Explanation.ReasonNotGiven)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_reason_not_given(), item5) as Res_Immunization_Index_reason_not_given;
                ResourseEntity.reason_not_given_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.VaccineCode != null)
      {
        foreach (var item3 in ResourceTyped.VaccineCode.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_vaccine_code(), item3) as Res_Immunization_Index_vaccine_code;
          ResourseEntity.vaccine_code_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Immunization_Index_profile(), item4) as Res_Immunization_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_security(), item4) as Res_Immunization_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Immunization_Index_tag(), item4) as Res_Immunization_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

