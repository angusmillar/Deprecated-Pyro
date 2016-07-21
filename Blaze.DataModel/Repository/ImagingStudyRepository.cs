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
  public partial class ImagingStudyRepository : CommonRepository, IResourceRepository
  {

    public ImagingStudyRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

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
        DtoResource = DbGetALL<Res_ImagingStudy>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_ImagingStudy>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ImagingStudy LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ImagingStudy, object>>>();
      IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.dicom_class_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.modality_List);
      IncludeList.Add(x => x.order_List);
      IncludeList.Add(x => x.series_List);
      IncludeList.Add(x => x.uid_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ImagingStudy>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ImagingStudy ResourceEntity)
    {
      ResourceEntity.accession_Code = null;      
      ResourceEntity.accession_System = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.started_DateTimeOffset = null;      
      ResourceEntity.study_Uri = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ImagingStudy_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_ImagingStudy_Index_dicom_class.RemoveRange(ResourceEntity.dicom_class_List);            
      _Context.Res_ImagingStudy_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_ImagingStudy_Index_modality.RemoveRange(ResourceEntity.modality_List);            
      _Context.Res_ImagingStudy_Index_order.RemoveRange(ResourceEntity.order_List);            
      _Context.Res_ImagingStudy_Index_series.RemoveRange(ResourceEntity.series_List);            
      _Context.Res_ImagingStudy_Index_uid.RemoveRange(ResourceEntity.uid_List);            
      _Context.Res_ImagingStudy_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ImagingStudy_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ImagingStudy_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ImagingStudy ResourseEntity, string ResourceVersion, ImagingStudy ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Accession != null)
      {
        if (ResourceTyped.Accession is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Accession) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.accession_Code = Index.Code;
            ResourseEntity.accession_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Patient, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Started != null)
      {
        if (ResourceTyped.StartedElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.StartedElement) as DateIndex;
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
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.UidElement) as UriIndex;
          if (Index != null)
          {
            ResourseEntity.study_Uri = Index.Uri;
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
            Index = IndexSettingSupport.SetIndex(Index, item1.BodySite) as Res_ImagingStudy_Index_bodysite;
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
              Index = IndexSettingSupport.SetIndex(Index, item2.SopClassElement) as Res_ImagingStudy_Index_dicom_class;
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
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_ImagingStudy_Index_identifier;
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
            Index = IndexSettingSupport.SetIndex(Index, item1.Modality) as Res_ImagingStudy_Index_modality;
            ResourseEntity.modality_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Order != null)
      {
        foreach (var item in ResourceTyped.Order)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_ImagingStudy_Index_order();
            IndexSettingSupport.SetIndex(Index, item, FhirRequestUri, this);
            if (Index != null)
            {
              ResourseEntity.order_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Series)
      {
        if (item1.Uid != null)
        {
          if (item1.UidElement is Hl7.Fhir.Model.Oid)
          {
            var Index = new Res_ImagingStudy_Index_series();
            Index = IndexSettingSupport.SetIndex(Index, item1.UidElement) as Res_ImagingStudy_Index_series;
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
              Index = IndexSettingSupport.SetIndex(Index, item2.UidElement) as Res_ImagingStudy_Index_uid;
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
              var Index = new Res_ImagingStudy_Index_profile();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_ImagingStudy_Index_profile;
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
              var Index = new Res_ImagingStudy_Index_security();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_ImagingStudy_Index_security;
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
              var Index = new Res_ImagingStudy_Index_tag();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_ImagingStudy_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

