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
  public partial class CoverageRepository : CommonRepository, IResourceRepository
  {
    public CoverageRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_Coverage>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_Coverage>(Predicate);
      var Query = DbGetAll<Res_Coverage>(Predicate);

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
      var ResourceTyped = Resource as Coverage;
      var ResourceEntity = new Res_Coverage();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Coverage>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Coverage;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Coverage_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Coverage_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Coverage_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Coverage_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_Coverage_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Coverage>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_Coverage>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_Coverage>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Coverage LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Coverage, object>>>();
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Coverage>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Coverage ResourceEntity)
    {
      ResourceEntity.beneficiary_identifier_Code = null;      
      ResourceEntity.beneficiary_identifier_System = null;      
      ResourceEntity.beneficiary_reference_VersionId = null;      
      ResourceEntity.beneficiary_reference_FhirId = null;      
      ResourceEntity.beneficiary_reference_Type = null;      
      ResourceEntity.beneficiary_reference_Url = null;      
      ResourceEntity.beneficiary_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.dependent_Comparator = null;      
      ResourceEntity.dependent_Quantity = null;      
      ResourceEntity.group_Code = null;      
      ResourceEntity.group_System = null;      
      ResourceEntity.issuer_identifier_Code = null;      
      ResourceEntity.issuer_identifier_System = null;      
      ResourceEntity.issuer_reference_VersionId = null;      
      ResourceEntity.issuer_reference_FhirId = null;      
      ResourceEntity.issuer_reference_Type = null;      
      ResourceEntity.issuer_reference_Url = null;      
      ResourceEntity.issuer_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.plan_Code = null;      
      ResourceEntity.plan_System = null;      
      ResourceEntity.planholder_identifier_Code = null;      
      ResourceEntity.planholder_identifier_System = null;      
      ResourceEntity.planholder_reference_VersionId = null;      
      ResourceEntity.planholder_reference_FhirId = null;      
      ResourceEntity.planholder_reference_Type = null;      
      ResourceEntity.planholder_reference_Url = null;      
      ResourceEntity.planholder_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.sequence_Comparator = null;      
      ResourceEntity.sequence_Quantity = null;      
      ResourceEntity.subgroup_Code = null;      
      ResourceEntity.subgroup_System = null;      
      ResourceEntity.subplan_Code = null;      
      ResourceEntity.subplan_System = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Coverage_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Coverage_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Coverage_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Coverage_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Coverage ResourseEntity, string ResourceVersion, Coverage ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Beneficiary != null)
      {
        if (ResourceTyped.Beneficiary is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Beneficiary, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.beneficiary_identifier_Code = Index.Code;
            ResourseEntity.beneficiary_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Beneficiary != null)
      {
        if (ResourceTyped.Beneficiary is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Beneficiary, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.beneficiary_reference_Type = Index.Type;
            ResourseEntity.beneficiary_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.beneficiary_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.beneficiary_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Dependent != null)
      {
        if (ResourceTyped.DependentElement is Hl7.Fhir.Model.PositiveInt)
        {
          var Index = new NumberIndex();
          Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(ResourceTyped.DependentElement, Index) as NumberIndex;
          if (Index != null)
          {
            ResourseEntity.dependent_Comparator = Index.Comparator;
            ResourseEntity.dependent_Quantity = Index.Quantity;
          }
        }
      }

      if (ResourceTyped.Group != null)
      {
        if (ResourceTyped.GroupElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.GroupElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.group_Code = Index.Code;
            ResourseEntity.group_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Issuer != null)
      {
        if (ResourceTyped.Issuer is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Issuer, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.issuer_identifier_Code = Index.Code;
            ResourseEntity.issuer_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Issuer != null)
      {
        if (ResourceTyped.Issuer is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Issuer, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.issuer_reference_Type = Index.Type;
            ResourseEntity.issuer_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.issuer_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.issuer_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Plan != null)
      {
        if (ResourceTyped.PlanElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.PlanElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.plan_Code = Index.Code;
            ResourseEntity.plan_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Planholder != null)
      {
        if (ResourceTyped.Planholder is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Planholder, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.planholder_identifier_Code = Index.Code;
            ResourseEntity.planholder_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Planholder != null)
      {
        if (ResourceTyped.Planholder is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Planholder, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.planholder_reference_Type = Index.Type;
            ResourseEntity.planholder_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.planholder_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.planholder_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Sequence != null)
      {
        if (ResourceTyped.SequenceElement is Hl7.Fhir.Model.PositiveInt)
        {
          var Index = new NumberIndex();
          Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(ResourceTyped.SequenceElement, Index) as NumberIndex;
          if (Index != null)
          {
            ResourseEntity.sequence_Comparator = Index.Comparator;
            ResourseEntity.sequence_Quantity = Index.Quantity;
          }
        }
      }

      if (ResourceTyped.SubGroup != null)
      {
        if (ResourceTyped.SubGroupElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.SubGroupElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.subgroup_Code = Index.Code;
            ResourseEntity.subgroup_System = Index.System;
          }
        }
      }

      if (ResourceTyped.SubPlan != null)
      {
        if (ResourceTyped.SubPlanElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.SubPlanElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.subplan_Code = Index.Code;
            ResourseEntity.subplan_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        if (ResourceTyped.Type is Hl7.Fhir.Model.Coding)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Type, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.type_Code = Index.Code;
            ResourseEntity.type_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_Coverage_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Coverage_Index_identifier;
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
              var Index = new Res_Coverage_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Coverage_Index__profile;
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
              var Index = new Res_Coverage_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Coverage_Index__security;
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
              var Index = new Res_Coverage_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Coverage_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

