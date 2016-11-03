using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Support;
using Pyro.DataModel.IndexSetter;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;



namespace Pyro.DataModel.Repository
{
  public partial class CoverageRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_Coverage, new() 
    where ResourceHistoryType :Res_Coverage_History, new()
  {
    public CoverageRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_Coverage_History_List.Add(ResourceHistoryEntity);
    }
    
    protected override ResourceType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceType, object>>>();
         IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<ResourceType>(x => x.FhirId == FhirId, IncludeList);
      return ResourceEntity;
    }
    
    protected override void ResetResourceEntity(ResourceType ResourceEntity)
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

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Coverage;
      var ResourseEntity = ResourceEntity as ResourceType;
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

