using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
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
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      throw new NotImplementedException("Resource Search not implemented in Db layer");
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Coverage;
      var ResourceEntity = new Res_Coverage();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Coverage>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
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
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
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
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Coverage>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Coverage>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Coverage>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Coverage LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Coverage, object>>>();
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Coverage>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Coverage ResourceEntity)
    {
      ResourceEntity.beneficiaryidentifier_Code = null;      
      ResourceEntity.beneficiaryidentifier_System = null;      
      ResourceEntity.beneficiaryreference_FhirId = null;      
      ResourceEntity.beneficiaryreference_Type = null;      
      ResourceEntity.beneficiaryreference_Url = null;      
      ResourceEntity.beneficiaryreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.dependent_Code = null;      
      ResourceEntity.dependent_System = null;      
      ResourceEntity.group_Code = null;      
      ResourceEntity.group_System = null;      
      ResourceEntity.issueridentifier_Code = null;      
      ResourceEntity.issueridentifier_System = null;      
      ResourceEntity.issuerreference_FhirId = null;      
      ResourceEntity.issuerreference_Type = null;      
      ResourceEntity.issuerreference_Url = null;      
      ResourceEntity.issuerreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.plan_Code = null;      
      ResourceEntity.plan_System = null;      
      ResourceEntity.planholderidentifier_Code = null;      
      ResourceEntity.planholderidentifier_System = null;      
      ResourceEntity.planholderreference_FhirId = null;      
      ResourceEntity.planholderreference_Type = null;      
      ResourceEntity.planholderreference_Url = null;      
      ResourceEntity.planholderreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.sequence_Code = null;      
      ResourceEntity.sequence_System = null;      
      ResourceEntity.subplan_Code = null;      
      ResourceEntity.subplan_System = null;      
      ResourceEntity.type_Code = null;      
      ResourceEntity.type_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Coverage_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Coverage_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Coverage_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Coverage_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
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
            ResourseEntity.beneficiaryidentifier_Code = Index.Code;
            ResourseEntity.beneficiaryidentifier_System = Index.System;
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
            ResourseEntity.beneficiaryreference_Type = Index.Type;
            ResourseEntity.beneficiaryreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.beneficiaryreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.beneficiaryreference_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Dependent != null)
      {
        if (ResourceTyped.DependentElement is Hl7.Fhir.Model.PositiveInt)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.DependentElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.dependent_Code = Index.Code;
            ResourseEntity.dependent_System = Index.System;
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
            ResourseEntity.issueridentifier_Code = Index.Code;
            ResourseEntity.issueridentifier_System = Index.System;
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
            ResourseEntity.issuerreference_Type = Index.Type;
            ResourseEntity.issuerreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.issuerreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.issuerreference_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
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
            ResourseEntity.planholderidentifier_Code = Index.Code;
            ResourseEntity.planholderidentifier_System = Index.System;
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
            ResourseEntity.planholderreference_Type = Index.Type;
            ResourseEntity.planholderreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.planholderreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.planholderreference_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Sequence != null)
      {
        if (ResourceTyped.SequenceElement is Hl7.Fhir.Model.PositiveInt)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.SequenceElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.sequence_Code = Index.Code;
            ResourseEntity.sequence_System = Index.System;
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
              var Index = new Res_Coverage_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Coverage_Index_profile;
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
              var Index = new Res_Coverage_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Coverage_Index_security;
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
              var Index = new Res_Coverage_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Coverage_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

