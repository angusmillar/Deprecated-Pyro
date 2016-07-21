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
  public partial class SpecimenRepository : CommonRepository, IResourceRepository
  {

    public SpecimenRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Specimen;
      var ResourceEntity = new Res_Specimen();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Specimen>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Specimen;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Specimen_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Specimen_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Specimen_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Specimen_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Specimen_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Specimen>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Specimen>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Specimen>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Specimen LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Specimen, object>>>();
      IncludeList.Add(x => x.bodysite_List);
      IncludeList.Add(x => x.container_List);
      IncludeList.Add(x => x.container_id_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.parent_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Specimen>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Specimen ResourceEntity)
    {
      ResourceEntity.accession_Code = null;      
      ResourceEntity.accession_System = null;      
      ResourceEntity.collected_DateTimeOffset = null;      
      ResourceEntity.collected_DateTimeOffsetLow = null;      
      ResourceEntity.collected_DateTimeOffsetHigh = null;      
      ResourceEntity.collector_FhirId = null;      
      ResourceEntity.collector_Type = null;      
      ResourceEntity.collector_Url = null;      
      ResourceEntity.collector_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Specimen_Index_bodysite.RemoveRange(ResourceEntity.bodysite_List);            
      _Context.Res_Specimen_Index_container.RemoveRange(ResourceEntity.container_List);            
      _Context.Res_Specimen_Index_container_id.RemoveRange(ResourceEntity.container_id_List);            
      _Context.Res_Specimen_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Specimen_Index_parent.RemoveRange(ResourceEntity.parent_List);            
      _Context.Res_Specimen_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Specimen_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Specimen_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Specimen_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Specimen ResourseEntity, string ResourceVersion, Specimen ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.AccessionIdentifier != null)
      {
        if (ResourceTyped.AccessionIdentifier is Hl7.Fhir.Model.Identifier)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.AccessionIdentifier) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.accession_Code = Index.Code;
            ResourseEntity.accession_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collected != null)
        {
          if (ResourceTyped.Collection.Collected is Hl7.Fhir.Model.FhirDateTime)
          {
            DateIndex Index = null;
            Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Collection.Collected) as DateIndex;
            if (Index != null)
            {
              ResourseEntity.collected_DateTimeOffset = Index.DateTimeOffset;
            }
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collected != null)
        {
          if (ResourceTyped.Collection.Collected is Hl7.Fhir.Model.Period)
          {
            DateIndex Index = null;
            Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Collection.Collected) as DateIndex;
            if (Index != null)
            {
              ResourseEntity.collected_DateTimeOffsetLow = Index.DateTimeOffset;
              ResourseEntity.collected_DateTimeOffsetHigh = Index.DateTimeOffset;
            }
          }
        }
      }

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.Collector != null)
        {
          if (ResourceTyped.Collection.Collector is ResourceReference)
          {
            ReferenceIndex Index = null;
            Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Collection.Collector, FhirRequestUri, this) as ReferenceIndex;
            if (Index != null)
            {
              ResourseEntity.collector_Type = Index.Type;
              ResourseEntity.collector_FhirId = Index.FhirId;
              if (Index.Url != null)
              {
                ResourseEntity.collector_Url = Index.Url;
              }
              else
              {
                ResourseEntity.collector_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
              }
            }
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Subject, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Subject != null)
      {
        if (ResourceTyped.Subject is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Subject, FhirRequestUri, this) as ReferenceIndex;
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

      if (ResourceTyped.Collection != null)
      {
        if (ResourceTyped.Collection.BodySite != null)
        {
          foreach (var item4 in ResourceTyped.Collection.BodySite.Coding)
          {
            Res_Specimen_Index_bodysite Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_bodysite;
            ResourseEntity.bodysite_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Container)
      {
        if (item1.Type != null)
        {
          foreach (var item4 in item1.Type.Coding)
          {
            Res_Specimen_Index_container Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_container;
            ResourseEntity.container_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Container)
      {
        if (item1.Identifier != null)
        {
          foreach (var item4 in item1.Identifier)
          {
            if (item4 is Hl7.Fhir.Model.Identifier)
            {
              Res_Specimen_Index_container_id Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_container_id;
              ResourseEntity.container_id_List.Add(Index);
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
            Res_Specimen_Index_identifier Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Specimen_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Parent != null)
      {
        foreach (var item in ResourceTyped.Parent)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Specimen_Index_parent();
            IndexSettingSupport.SetIndex(Index, item, FhirRequestUri, this);
            if (Index != null)
            {
              ResourseEntity.parent_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          Res_Specimen_Index_type Index = null;
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Specimen_Index_type;
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
              Res_Specimen_Index_profile Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_profile;
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
              Res_Specimen_Index_security Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_security;
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
              Res_Specimen_Index_tag Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Specimen_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

