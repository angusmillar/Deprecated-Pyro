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
  public partial class EligibilityResponseRepository<ResourceType, ResourceHistoryType> : CommonResourceRepository<ResourceType, ResourceHistoryType>, IResourceRepository 
    where ResourceType : Res_EligibilityResponse, new() 
    where ResourceHistoryType :Res_EligibilityResponse_History, new()
  {
    public EligibilityResponseRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    protected override void AddResourceHistoryEntityToResourceEntity(ResourceType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.Res_EligibilityResponse_History_List.Add(ResourceHistoryEntity);
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
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.disposition_String = null;      
      ResourceEntity.organization_identifier_Code = null;      
      ResourceEntity.organization_identifier_System = null;      
      ResourceEntity.organization_reference_VersionId = null;      
      ResourceEntity.organization_reference_FhirId = null;      
      ResourceEntity.organization_reference_Type = null;      
      ResourceEntity.organization_reference_Url = null;      
      ResourceEntity.organization_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.outcome_Code = null;      
      ResourceEntity.outcome_System = null;      
      ResourceEntity.request_identifier_Code = null;      
      ResourceEntity.request_identifier_System = null;      
      ResourceEntity.request_organization_identifier_Code = null;      
      ResourceEntity.request_organization_identifier_System = null;      
      ResourceEntity.request_organization_reference_VersionId = null;      
      ResourceEntity.request_organization_reference_FhirId = null;      
      ResourceEntity.request_organization_reference_Type = null;      
      ResourceEntity.request_organization_reference_Url = null;      
      ResourceEntity.request_organization_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.request_provider_identifier_Code = null;      
      ResourceEntity.request_provider_identifier_System = null;      
      ResourceEntity.request_provider_reference_VersionId = null;      
      ResourceEntity.request_provider_reference_FhirId = null;      
      ResourceEntity.request_provider_reference_Type = null;      
      ResourceEntity.request_provider_reference_Url = null;      
      ResourceEntity.request_provider_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.request_reference_VersionId = null;      
      ResourceEntity.request_reference_FhirId = null;      
      ResourceEntity.request_reference_Type = null;      
      ResourceEntity.request_reference_Url = null;      
      ResourceEntity.request_reference_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_EligibilityResponse_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_EligibilityResponse_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_EligibilityResponse_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_EligibilityResponse_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    protected override void PopulateResourceEntity(ResourceType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as EligibilityResponse;
      var ResourseEntity = ResourceEntity as ResourceType;
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

      if (ResourceTyped.Outcome != null)
      {
        if (ResourceTyped.OutcomeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ClaimProcessingCodes>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.OutcomeElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.outcome_Code = Index.Code;
            ResourseEntity.outcome_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Request != null)
      {
        if (ResourceTyped.Request is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Request, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.request_identifier_Code = Index.Code;
            ResourseEntity.request_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.RequestOrganization != null)
      {
        if (ResourceTyped.RequestOrganization is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.RequestOrganization, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.request_organization_identifier_Code = Index.Code;
            ResourseEntity.request_organization_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.RequestOrganization != null)
      {
        if (ResourceTyped.RequestOrganization is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.RequestOrganization, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.request_organization_reference_Type = Index.Type;
            ResourseEntity.request_organization_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.request_organization_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.request_organization_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.RequestProvider != null)
      {
        if (ResourceTyped.RequestProvider is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.RequestProvider, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.request_provider_identifier_Code = Index.Code;
            ResourseEntity.request_provider_identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.RequestProvider != null)
      {
        if (ResourceTyped.RequestProvider is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.RequestProvider, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.request_provider_reference_Type = Index.Type;
            ResourseEntity.request_provider_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.request_provider_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.request_provider_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Request != null)
      {
        if (ResourceTyped.Request is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Request, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.request_reference_Type = Index.Type;
            ResourseEntity.request_reference_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.request_reference_Url = Index.Url;
            }
            else
            {
              ResourseEntity.request_reference_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
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
            var Index = new Res_EligibilityResponse_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_EligibilityResponse_Index_identifier;
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
              var Index = new Res_EligibilityResponse_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_EligibilityResponse_Index__profile;
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
              var Index = new Res_EligibilityResponse_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_EligibilityResponse_Index__security;
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
              var Index = new Res_EligibilityResponse_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_EligibilityResponse_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      
    }

  }
} 

