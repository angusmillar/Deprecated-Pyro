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
  public partial class ImagingStudyRepository : CommonRepository, IResourceRepository
  {
    public ImagingStudyRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_ImagingStudy>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_ImagingStudy>(Predicate);
      var Query = DbGetAll<Res_ImagingStudy>(Predicate);

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
      var ResourceTyped = Resource as ImagingStudy;
      var ResourceEntity = new Res_ImagingStudy();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ImagingStudy>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ImagingStudy;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ImagingStudy_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ImagingStudy_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_ImagingStudy_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ImagingStudy_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_ImagingStudy_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_ImagingStudy>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_ImagingStudy>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_ImagingStudy>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ImagingStudy LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ImagingStudy, object>>>();
      IncludeList.Add(x => x.basedon_List);
      IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.dicom_class_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.modality_List);
      IncludeList.Add(x => x.reason_List);
      IncludeList.Add(x => x.series_List);
      IncludeList.Add(x => x.uid_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ImagingStudy>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ImagingStudy ResourceEntity)
    {
      ResourceEntity.accession_Code = null;      
      ResourceEntity.accession_System = null;      
      ResourceEntity.context_VersionId = null;      
      ResourceEntity.context_FhirId = null;      
      ResourceEntity.context_Type = null;      
      ResourceEntity.context_Url = null;      
      ResourceEntity.context_ServiceRootURL_StoreID = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.started_DateTimeOffset = null;      
      ResourceEntity.study_Uri = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ImagingStudy_Index_basedon.RemoveRange(ResourceEntity.basedon_List);            
      _Context.Res_ImagingStudy_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_ImagingStudy_Index_dicom_class.RemoveRange(ResourceEntity.dicom_class_List);            
      _Context.Res_ImagingStudy_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_ImagingStudy_Index_modality.RemoveRange(ResourceEntity.modality_List);            
      _Context.Res_ImagingStudy_Index_reason.RemoveRange(ResourceEntity.reason_List);            
      _Context.Res_ImagingStudy_Index_series.RemoveRange(ResourceEntity.series_List);            
      _Context.Res_ImagingStudy_Index_uid.RemoveRange(ResourceEntity.uid_List);            
      _Context.Res_ImagingStudy_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_ImagingStudy_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_ImagingStudy_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ImagingStudy ResourseEntity, string ResourceVersion, ImagingStudy ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Accession != null)
      {
        if (ResourceTyped.Accession is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Accession, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.accession_Code = Index.Code;
            ResourseEntity.accession_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Context != null)
      {
        if (ResourceTyped.Context is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Context, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.context_Type = Index.Type;
            ResourseEntity.context_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.context_Url = Index.Url;
            }
            else
            {
              ResourseEntity.context_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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

      if (ResourceTyped.Started != null)
      {
        if (ResourceTyped.StartedElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.StartedElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.started_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Uid != null)
      {
        if (ResourceTyped.UidElement is Hl7.Fhir.Model.Oid)
        {
          var Index = new UriIndex();
          Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(ResourceTyped.UidElement, Index) as UriIndex;
          if (Index != null)
          {
            ResourseEntity.study_Uri = Index.Uri;
          }
        }
      }

      if (ResourceTyped.BasedOn != null)
      {
        foreach (var item in ResourceTyped.BasedOn)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_ImagingStudy_Index_basedon();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_ImagingStudy_Index_basedon;
            if (Index != null)
            {
              ResourseEntity.basedon_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        if (item1.BodySite != null)
        {
          if (item1.BodySite is Hl7.Fhir.Model.Coding)
          {
            var Index = new Res_ImagingStudy_Index_bodysite();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.BodySite, Index) as Res_ImagingStudy_Index_bodysite;
            ResourseEntity.bodysite_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        foreach (var item2 in item1.Instance)
        {
          if (item2.SopClass != null)
          {
            if (item2.SopClassElement is Hl7.Fhir.Model.Oid)
            {
              var Index = new Res_ImagingStudy_Index_dicom_class();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item2.SopClassElement, Index) as Res_ImagingStudy_Index_dicom_class;
              ResourseEntity.dicom_class_List.Add(Index);
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
            var Index = new Res_ImagingStudy_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_ImagingStudy_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        if (item1.Modality != null)
        {
          if (item1.Modality is Hl7.Fhir.Model.Coding)
          {
            var Index = new Res_ImagingStudy_Index_modality();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.Modality, Index) as Res_ImagingStudy_Index_modality;
            ResourseEntity.modality_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Reason != null)
      {
        foreach (var item3 in ResourceTyped.Reason.Coding)
        {
          var Index = new Res_ImagingStudy_Index_reason();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_ImagingStudy_Index_reason;
          ResourseEntity.reason_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        if (item1.Uid != null)
        {
          if (item1.UidElement is Hl7.Fhir.Model.Oid)
          {
            var Index = new Res_ImagingStudy_Index_series();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.UidElement, Index) as Res_ImagingStudy_Index_series;
            ResourseEntity.series_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        foreach (var item2 in item1.Instance)
        {
          if (item2.Uid != null)
          {
            if (item2.UidElement is Hl7.Fhir.Model.Oid)
            {
              var Index = new Res_ImagingStudy_Index_uid();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item2.UidElement, Index) as Res_ImagingStudy_Index_uid;
              ResourseEntity.uid_List.Add(Index);
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
              var Index = new Res_ImagingStudy_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ImagingStudy_Index__profile;
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
              var Index = new Res_ImagingStudy_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImagingStudy_Index__security;
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
              var Index = new Res_ImagingStudy_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ImagingStudy_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

