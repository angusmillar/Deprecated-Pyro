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
  public partial class ClaimRepository : CommonRepository, IResourceRepository
  {
    public ClaimRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_Claim>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_Claim>(Predicate);
      var Query = DbGetAll<Res_Claim>(Predicate);

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
      DatabaseOperationOutcome.ReturnedResourceCount = TotalRecordCount;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Claim;
      var ResourceEntity = new Res_Claim();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Claim>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Claim;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Claim_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Claim_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_Claim_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Claim_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_Claim_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Claim>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);        
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
        DtoResource = DbGetAll<Res_Claim>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_Claim>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Claim LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Claim, object>>>();
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Claim>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Claim ResourceEntity)
    {
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.facility_identifier_Code = null;      
      ResourceEntity.facility_identifier_System = null;      
      ResourceEntity.facility_reference_VersionId = null;      
      ResourceEntity.facility_reference_FhirId = null;      
      ResourceEntity.facility_reference_Type = null;      
      ResourceEntity.facility_reference_Url = null;      
      ResourceEntity.facility_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.insurer_identifier_Code = null;      
      ResourceEntity.insurer_identifier_System = null;      
      ResourceEntity.insurer_reference_VersionId = null;      
      ResourceEntity.insurer_reference_FhirId = null;      
      ResourceEntity.insurer_reference_Type = null;      
      ResourceEntity.insurer_reference_Url = null;      
      ResourceEntity.insurer_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.organization_identifier_Code = null;      
      ResourceEntity.organization_identifier_System = null;      
      ResourceEntity.organization_reference_VersionId = null;      
      ResourceEntity.organization_reference_FhirId = null;      
      ResourceEntity.organization_reference_Type = null;      
      ResourceEntity.organization_reference_Url = null;      
      ResourceEntity.organization_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.patient_identifier_Code = null;      
      ResourceEntity.patient_identifier_System = null;      
      ResourceEntity.patient_reference_VersionId = null;      
      ResourceEntity.patient_reference_FhirId = null;      
      ResourceEntity.patient_reference_Type = null;      
      ResourceEntity.patient_reference_Url = null;      
      ResourceEntity.patient_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.priority_Code = null;      
      ResourceEntity.priority_System = null;      
      ResourceEntity.provider_identifier_Code = null;      
      ResourceEntity.provider_identifier_System = null;      
      ResourceEntity.provider_reference_VersionId = null;      
      ResourceEntity.provider_reference_FhirId = null;      
      ResourceEntity.provider_reference_Type = null;      
      ResourceEntity.provider_reference_Url = null;      
      ResourceEntity.provider_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.use_Code = null;      
      ResourceEntity.use_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Claim_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Claim_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Claim_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Claim_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Claim ResourseEntity, string ResourceVersion, Claim ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

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

      if (ResourceTyped.Facility != null)
      {
        if (ResourceTyped.Facility is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Facility, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.facility_identifier_Code = Index.Code;
            ResourseEntity.facility_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Facility != null)
      {
        if (ResourceTyped.Facility is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Facility, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.facility_reference_Type = Index.Type;
            ResourseEntity.facility_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.facility_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.facility_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Insurer != null)
      {
        if (ResourceTyped.Insurer is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Insurer, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.insurer_identifier_Code = Index.Code;
            ResourseEntity.insurer_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Insurer != null)
      {
        if (ResourceTyped.Insurer is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Insurer, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.insurer_reference_Type = Index.Type;
            ResourseEntity.insurer_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.insurer_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.insurer_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Organization != null)
      {
        if (ResourceTyped.Organization is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Organization, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.organization_identifier_Code = Index.Code;
            ResourseEntity.organization_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Organization != null)
      {
        if (ResourceTyped.Organization is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Organization, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.organization_reference_Type = Index.Type;
            ResourseEntity.organization_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.organization_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.organization_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Patient, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.patient_identifier_Code = Index.Code;
            ResourseEntity.patient_identifier_System = Index.System;
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
            ResourseEntity.patient_reference_Type = Index.Type;
            ResourseEntity.patient_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.patient_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.patient_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Priority != null)
      {
        if (ResourceTyped.Priority is Hl7.Fhir.Model.Coding)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Priority, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.priority_Code = Index.Code;
            ResourseEntity.priority_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Provider != null)
      {
        if (ResourceTyped.Provider is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Provider, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.provider_identifier_Code = Index.Code;
            ResourseEntity.provider_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Provider != null)
      {
        if (ResourceTyped.Provider is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Provider, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.provider_reference_Type = Index.Type;
            ResourseEntity.provider_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.provider_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.provider_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Use_ != null)
      {
        if (ResourceTyped.Use_Element is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.Claim.Use>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Use_Element, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.use_Code = Index.Code;
            ResourseEntity.use_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_Claim_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Claim_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
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
              var Index = new Res_Claim_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Claim_Index__profile;
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
              var Index = new Res_Claim_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Claim_Index__security;
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
              var Index = new Res_Claim_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Claim_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

