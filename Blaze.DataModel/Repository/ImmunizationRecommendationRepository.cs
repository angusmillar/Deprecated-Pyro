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
  public partial class ImmunizationRecommendationRepository : CommonRepository, IResourceRepository
  {
    public ImmunizationRecommendationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_ImmunizationRecommendation>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_ImmunizationRecommendation>(Predicate);
      var Query = DbGetAll<Res_ImmunizationRecommendation>(Predicate);

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
      var ResourceTyped = Resource as ImmunizationRecommendation;
      var ResourceEntity = new Res_ImmunizationRecommendation();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ImmunizationRecommendation>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ImmunizationRecommendation;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ImmunizationRecommendation_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ImmunizationRecommendation_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_ImmunizationRecommendation_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ImmunizationRecommendation_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_ImmunizationRecommendation_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ImmunizationRecommendation>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_ImmunizationRecommendation>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_ImmunizationRecommendation>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ImmunizationRecommendation LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ImmunizationRecommendation, object>>>();
      IncludeList.Add(x => x.date_List);
      IncludeList.Add(x => x.dose_number_List);
      IncludeList.Add(x => x.dose_sequence_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.information_List);
      IncludeList.Add(x => x.status_List);
      IncludeList.Add(x => x.support_List);
      IncludeList.Add(x => x.vaccine_type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ImmunizationRecommendation>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ImmunizationRecommendation ResourceEntity)
    {
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ImmunizationRecommendation_Index_date.RemoveRange(ResourceEntity.date_List);            
      _Context.Res_ImmunizationRecommendation_Index_dose_number.RemoveRange(ResourceEntity.dose_number_List);            
      _Context.Res_ImmunizationRecommendation_Index_dose_sequence.RemoveRange(ResourceEntity.dose_sequence_List);            
      _Context.Res_ImmunizationRecommendation_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_ImmunizationRecommendation_Index_information.RemoveRange(ResourceEntity.information_List);            
      _Context.Res_ImmunizationRecommendation_Index_status.RemoveRange(ResourceEntity.status_List);            
      _Context.Res_ImmunizationRecommendation_Index_support.RemoveRange(ResourceEntity.support_List);            
      _Context.Res_ImmunizationRecommendation_Index_vaccine_type.RemoveRange(ResourceEntity.vaccine_type_List);            
      _Context.Res_ImmunizationRecommendation_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ImmunizationRecommendation_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ImmunizationRecommendation_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ImmunizationRecommendation ResourseEntity, string ResourceVersion, ImmunizationRecommendation ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

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

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.Date != null)
        {
          if (item1.DateElement is Hl7.Fhir.Model.FhirDateTime)
          {
            var Index = new Res_ImmunizationRecommendation_Index_date();
            Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(item1.DateElement, Index) as Res_ImmunizationRecommendation_Index_date;
            ResourseEntity.date_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.DoseNumber != null)
        {
          if (item1.DoseNumberElement is Hl7.Fhir.Model.PositiveInt)
          {
            var Index = new Res_ImmunizationRecommendation_Index_dose_number();
            Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(item1.DoseNumberElement, Index) as Res_ImmunizationRecommendation_Index_dose_number;
            ResourseEntity.dose_number_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.Protocol != null)
        {
          if (item1.Protocol.DoseSequence != null)
          {
            if (item1.Protocol.DoseSequenceElement is Hl7.Fhir.Model.Integer)
            {
              var Index = new Res_ImmunizationRecommendation_Index_dose_sequence();
              Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(item1.Protocol.DoseSequenceElement, Index) as Res_ImmunizationRecommendation_Index_dose_sequence;
              ResourseEntity.dose_sequence_List.Add(Index);
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
            var Index = new Res_ImmunizationRecommendation_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_ImmunizationRecommendation_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.SupportingPatientInformation != null)
        {
          foreach (var item in item1.SupportingPatientInformation)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_ImmunizationRecommendation_Index_information();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ImmunizationRecommendation_Index_information;
              if (Index != null)
              {
                ResourseEntity.information_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.ForecastStatus != null)
        {
          foreach (var item4 in item1.ForecastStatus.Coding)
          {
            var Index = new Res_ImmunizationRecommendation_Index_status();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImmunizationRecommendation_Index_status;
            ResourseEntity.status_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.SupportingImmunization != null)
        {
          foreach (var item in item1.SupportingImmunization)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_ImmunizationRecommendation_Index_support();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ImmunizationRecommendation_Index_support;
              if (Index != null)
              {
                ResourseEntity.support_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Recommendation)
      {
        if (item1.VaccineCode != null)
        {
          foreach (var item4 in item1.VaccineCode.Coding)
          {
            var Index = new Res_ImmunizationRecommendation_Index_vaccine_type();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImmunizationRecommendation_Index_vaccine_type;
            ResourseEntity.vaccine_type_List.Add(Index);
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
              var Index = new Res_ImmunizationRecommendation_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ImmunizationRecommendation_Index_profile;
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
              var Index = new Res_ImmunizationRecommendation_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImmunizationRecommendation_Index_security;
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
              var Index = new Res_ImmunizationRecommendation_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImmunizationRecommendation_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

