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
  public partial class AllergyIntoleranceRepository : CommonRepository, IResourceRepository
  {

    public AllergyIntoleranceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as AllergyIntolerance;
      var ResourceEntity = new Res_AllergyIntolerance();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_AllergyIntolerance>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as AllergyIntolerance;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_AllergyIntolerance_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_AllergyIntolerance_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_AllergyIntolerance_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_AllergyIntolerance_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_AllergyIntolerance_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_AllergyIntolerance>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_AllergyIntolerance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_AllergyIntolerance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_AllergyIntolerance LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_AllergyIntolerance, object>>>();
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.manifestation_List);
      IncludeList.Add(x => x.onset_List);
      IncludeList.Add(x => x.route_List);
      IncludeList.Add(x => x.severity_List);
      IncludeList.Add(x => x.substance_List);
      IncludeList.Add(x => x.substance_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_AllergyIntolerance>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_AllergyIntolerance ResourceEntity)
    {
      ResourceEntity.category_Code = null;      
      ResourceEntity.category_System = null;      
      ResourceEntity.criticality_Code = null;      
      ResourceEntity.criticality_System = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.last_date_DateTimeOffset = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.recorder_FhirId = null;      
      ResourceEntity.recorder_Type = null;      
      ResourceEntity.recorder_Url = null;      
      ResourceEntity.recorder_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.reporter_FhirId = null;      
      ResourceEntity.reporter_Type = null;      
      ResourceEntity.reporter_Url = null;      
      ResourceEntity.reporter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_AllergyIntolerance_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_AllergyIntolerance_Index_manifestation.RemoveRange(ResourceEntity.manifestation_List);            
      _Context.Res_AllergyIntolerance_Index_onset.RemoveRange(ResourceEntity.onset_List);            
      _Context.Res_AllergyIntolerance_Index_route.RemoveRange(ResourceEntity.route_List);            
      _Context.Res_AllergyIntolerance_Index_severity.RemoveRange(ResourceEntity.severity_List);            
      _Context.Res_AllergyIntolerance_Index_substance.RemoveRange(ResourceEntity.substance_List);            
      _Context.Res_AllergyIntolerance_Index_substance.RemoveRange(ResourceEntity.substance_List);            
      _Context.Res_AllergyIntolerance_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_AllergyIntolerance_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_AllergyIntolerance_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_AllergyIntolerance ResourseEntity, string ResourceVersion, AllergyIntolerance ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Category != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.CategoryElement);
        if (Index != null)
        {
          ResourseEntity.category_Code = Index.Code;
          ResourseEntity.category_System = Index.System;
        }
      }

      if (ResourceTyped.Criticality != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.CriticalityElement);
        if (Index != null)
        {
          ResourseEntity.criticality_Code = Index.Code;
          ResourseEntity.criticality_System = Index.System;
        }
      }

      if (ResourceTyped.RecordedDate != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.RecordedDateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.LastOccurence != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.LastOccurenceElement);
        if (Index != null)
        {
          ResourseEntity.last_date_DateTimeOffset = Index.DateTimeOffset;
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

      if (ResourceTyped.Recorder != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Recorder, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.recorder_Type = Index.Type;
            ResourseEntity.recorder_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.recorder_Url = Index.Url;
            }
            else
            {
              ResourseEntity.recorder_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Reporter != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Reporter, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.reporter_Type = Index.Type;
            ResourseEntity.reporter_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.reporter_Url = Index.Url;
            }
            else
            {
              ResourseEntity.reporter_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
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

      if (ResourceTyped.Type != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.TypeElement);
        if (Index != null)
        {
          ResourseEntity.type_Code = Index.Code;
          ResourseEntity.type_System = Index.System;
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_identifier(), item3) as Res_AllergyIntolerance_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Manifestation != null)
        {
          foreach (var item4 in item1.Manifestation)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_manifestation(), item5) as Res_AllergyIntolerance_Index_manifestation;
                ResourseEntity.manifestation_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Onset != null)
        {
          var Index = IndexSettingSupport.SetIndex<DateIndex>(new Res_AllergyIntolerance_Index_onset(), item1.OnsetElement) as Res_AllergyIntolerance_Index_onset;
          ResourseEntity.onset_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.ExposureRoute != null)
        {
          foreach (var item4 in item1.ExposureRoute.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_route(), item4) as Res_AllergyIntolerance_Index_route;
            ResourseEntity.route_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Severity != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_severity(), item1.SeverityElement) as Res_AllergyIntolerance_Index_severity;
          ResourseEntity.severity_List.Add(Index);
        }
      }

      if (ResourceTyped.Substance != null)
      {
        foreach (var item3 in ResourceTyped.Substance.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_substance(), item3) as Res_AllergyIntolerance_Index_substance;
          ResourseEntity.substance_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Reaction)
      {
        if (item1.Substance != null)
        {
          foreach (var item4 in item1.Substance.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_substance(), item4) as Res_AllergyIntolerance_Index_substance;
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
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_AllergyIntolerance_Index_profile(), item4) as Res_AllergyIntolerance_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_security(), item4) as Res_AllergyIntolerance_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_AllergyIntolerance_Index_tag(), item4) as Res_AllergyIntolerance_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

