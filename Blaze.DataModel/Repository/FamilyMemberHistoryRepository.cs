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
  public partial class FamilyMemberHistoryRepository : CommonRepository, IResourceRepository
  {
    public FamilyMemberHistoryRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_FamilyMemberHistory>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_FamilyMemberHistory>(Predicate);
      var Query = DbGetAll<Res_FamilyMemberHistory>(Predicate);

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
      var ResourceTyped = Resource as FamilyMemberHistory;
      var ResourceEntity = new Res_FamilyMemberHistory();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_FamilyMemberHistory>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as FamilyMemberHistory;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_FamilyMemberHistory_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_FamilyMemberHistory_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_FamilyMemberHistory_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_FamilyMemberHistory_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_FamilyMemberHistory_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_FamilyMemberHistory>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_FamilyMemberHistory>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_FamilyMemberHistory>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_FamilyMemberHistory LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_FamilyMemberHistory, object>>>();
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.relationship_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_FamilyMemberHistory>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_FamilyMemberHistory ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.patient_VersionId = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_FamilyMemberHistory_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_FamilyMemberHistory_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_FamilyMemberHistory_Index_relationship.RemoveRange(ResourceEntity.relationship_List);            
      _Context.Res_FamilyMemberHistory_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_FamilyMemberHistory_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_FamilyMemberHistory_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_FamilyMemberHistory ResourseEntity, string ResourceVersion, FamilyMemberHistory ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Date != null)
      {
        if (ResourceTyped.DateElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.DateElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Gender != null)
      {
        if (ResourceTyped.GenderElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.AdministrativeGender>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.GenderElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.gender_Code = Index.Code;
            ResourseEntity.gender_System = Index.System;
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

      foreach (var item1 in ResourceTyped.Condition)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = new Res_FamilyMemberHistory_Index_code();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index_code;
            ResourseEntity.code_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_FamilyMemberHistory_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_FamilyMemberHistory_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Relationship != null)
      {
        foreach (var item3 in ResourceTyped.Relationship.Coding)
        {
          var Index = new Res_FamilyMemberHistory_Index_relationship();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_FamilyMemberHistory_Index_relationship;
          ResourseEntity.relationship_List.Add(Index);
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
              var Index = new Res_FamilyMemberHistory_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__profile;
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
              var Index = new Res_FamilyMemberHistory_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__security;
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
              var Index = new Res_FamilyMemberHistory_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_FamilyMemberHistory_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

