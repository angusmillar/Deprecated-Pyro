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
  public partial class ExplanationOfBenefitRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_ExplanationOfBenefit, new() 
    where ResourceHistoryType :Res_ExplanationOfBenefit_History, new()
  {
    public ExplanationOfBenefitRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_ExplanationOfBenefit_History_List.Add(ResourceHistoryEntity);
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
      ResourceEntity.claimidentifier_Code = null;      
      ResourceEntity.claimidentifier_System = null;      
      ResourceEntity.claimreference_VersionId = null;      
      ResourceEntity.claimreference_FhirId = null;      
      ResourceEntity.claimreference_Type = null;      
      ResourceEntity.claimreference_Url = null;      
      ResourceEntity.claimreference_ServiceRootURL_StoreID = null;      
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.disposition_String = null;      
      ResourceEntity.facilityidentifier_Code = null;      
      ResourceEntity.facilityidentifier_System = null;      
      ResourceEntity.facilityreference_VersionId = null;      
      ResourceEntity.facilityreference_FhirId = null;      
      ResourceEntity.facilityreference_Type = null;      
      ResourceEntity.facilityreference_Url = null;      
      ResourceEntity.facilityreference_ServiceRootURL_StoreID = null;      
      ResourceEntity.organizationidentifier_Code = null;      
      ResourceEntity.organizationidentifier_System = null;      
      ResourceEntity.organizationreference_VersionId = null;      
      ResourceEntity.organizationreference_FhirId = null;      
      ResourceEntity.organizationreference_Type = null;      
      ResourceEntity.organizationreference_Url = null;      
      ResourceEntity.organizationreference_ServiceRootURL_StoreID = null;      
      ResourceEntity.patientidentifier_Code = null;      
      ResourceEntity.patientidentifier_System = null;      
      ResourceEntity.patientreference_VersionId = null;      
      ResourceEntity.patientreference_FhirId = null;      
      ResourceEntity.patientreference_Type = null;      
      ResourceEntity.patientreference_Url = null;      
      ResourceEntity.patientreference_ServiceRootURL_StoreID = null;      
      ResourceEntity.provideridentifier_Code = null;      
      ResourceEntity.provideridentifier_System = null;      
      ResourceEntity.providerreference_VersionId = null;      
      ResourceEntity.providerreference_FhirId = null;      
      ResourceEntity.providerreference_Type = null;      
      ResourceEntity.providerreference_Url = null;      
      ResourceEntity.providerreference_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ExplanationOfBenefit_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_ExplanationOfBenefit_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_ExplanationOfBenefit_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_ExplanationOfBenefit_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ExplanationOfBenefit;
      var ResourseEntity = ResourceEntity as ResourceType;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Claim != null)
      {
        if (ResourceTyped.Claim is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Claim, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.claimidentifier_Code = Index.Code;
            ResourseEntity.claimidentifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Claim != null)
      {
        if (ResourceTyped.Claim is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Claim, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.claimreference_Type = Index.Type;
            ResourseEntity.claimreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.claimreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.claimreference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

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

      if (ResourceTyped.Disposition != null)
      {
        if (ResourceTyped.DispositionElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.DispositionElement, Index) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.disposition_String = Index.String;
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
            ResourseEntity.facilityidentifier_Code = Index.Code;
            ResourseEntity.facilityidentifier_System = Index.System;
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
            ResourseEntity.facilityreference_Type = Index.Type;
            ResourseEntity.facilityreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.facilityreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.facilityreference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
            ResourseEntity.organizationidentifier_Code = Index.Code;
            ResourseEntity.organizationidentifier_System = Index.System;
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
            ResourseEntity.organizationreference_Type = Index.Type;
            ResourseEntity.organizationreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.organizationreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.organizationreference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
            ResourseEntity.patientidentifier_Code = Index.Code;
            ResourseEntity.patientidentifier_System = Index.System;
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
            ResourseEntity.patientreference_Type = Index.Type;
            ResourseEntity.patientreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.patientreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.patientreference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
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
            ResourseEntity.provideridentifier_Code = Index.Code;
            ResourseEntity.provideridentifier_System = Index.System;
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
            ResourseEntity.providerreference_Type = Index.Type;
            ResourseEntity.providerreference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.providerreference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.providerreference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
            var Index = new Res_ExplanationOfBenefit_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_ExplanationOfBenefit_Index_identifier;
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
              var Index = new Res_ExplanationOfBenefit_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_ExplanationOfBenefit_Index__profile;
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
              var Index = new Res_ExplanationOfBenefit_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ExplanationOfBenefit_Index__security;
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
              var Index = new Res_ExplanationOfBenefit_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_ExplanationOfBenefit_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

