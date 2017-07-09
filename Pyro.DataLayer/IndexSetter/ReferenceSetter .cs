using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Tools;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.Repository.Interfaces;

namespace Pyro.DataLayer.IndexSetter
{
  public static class ReferenceSetter<ResourceCurrentType, ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
  {

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter, IDtoRequestUri FhirRequestUri, ICommonRepository CommonRepository)
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetFhirUri(FhirUri, ResourceIndexList, FhirRequestUri, CommonRepository);
        }
        else if (Poco.FhirValue is ResourceReference ResourceReference)
        {
          SetResourcereference(ResourceReference, ResourceIndexList, FhirRequestUri, CommonRepository);
        }
        else if (Poco.FhirValue is Resource Resource)
        {
          SetResource(Resource, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private static void SetResource(Resource resource, List<ResourceIndexType> ResourceIndexList)
    {
      if (resource.ResourceType == ResourceType.Composition || resource.ResourceType == ResourceType.MessageHeader)
      {
        //ToDo: What do we do with this Resource as a ResourceReferance??
        //FHIR Spec says:
        //The first resource in the bundle, if the bundle type is "document" - this is a composition, and this parameter provides access to searches its contents
        //and
        //The first resource in the bundle, if the bundle type is "message" - this is a message header, and this parameter provides access to search its contents
      }
    }

    private static void SetResourcereference(ResourceReference ResourceReference, List<ResourceIndexType> ResourceIndexList, IDtoRequestUri FhirRequestUri, ICommonRepository CommonRepository)
    {
      //Check the Uri is actual a Fhir resource reference 
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(ResourceReference.Reference))
      {
        if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
        {
          string ErrorMessage;
          IFhirRequestUri ReferanceUri = null;
          if (Common.BusinessEntities.UriSupport.FhirRequestUri.TryParse(FhirRequestUri.PrimaryRootUrlStore.Url, ResourceReference.Url.OriginalString, out ReferanceUri, out ErrorMessage))
          {
            var ResourceIndex = new ResourceIndexType();
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);
            if (ResourceReference.Url.IsAbsoluteUri)
            {
              if (FhirRequestUri.PrimaryRootUrlStore.Url.IsEqualUri(ReferanceUri.UriPrimaryServiceRoot.OriginalString))
              {
                ResourceIndex.ReferenceServiceBaseUrlId = FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.UriPrimaryServiceRoot.OriginalString.StripHttp().ToLower());
              }
            }
            else
            {
              ResourceIndex.ReferenceServiceBaseUrlId = FhirRequestUri.PrimaryRootUrlStore.Id;
            }
            ResourceIndexList.Add(ResourceIndex);
          }
        }
      }
    }

    private static void SetFhirUri(FhirUri FhirUri, List<ResourceIndexType> ResourceIndexList, IDtoRequestUri FhirRequestUri, ICommonRepository CommonRepository)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        //Check the Uri is actual a Fhir resource reference 
        if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(FhirUri.Value))
        {
          IFhirRequestUri ReferanceUri = null;
          string ErrorMessage;
          if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Relative))
          {

            if (Common.BusinessEntities.UriSupport.FhirRequestUri.TryParse(FhirRequestUri.PrimaryRootUrlStore.Url, FhirUri.Value.Trim(), out ReferanceUri, out ErrorMessage))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              ResourceIndex.ReferenceServiceBaseUrlId = FhirRequestUri.PrimaryRootUrlStore.Id;
              ResourceIndexList.Add(ResourceIndex);
            }
          }
          else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
          {
            if (Common.BusinessEntities.UriSupport.FhirRequestUri.TryParse(FhirRequestUri.PrimaryRootUrlStore.Url, FhirUri.Value.Trim(), out ReferanceUri, out ErrorMessage))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              if (FhirRequestUri.PrimaryRootUrlStore.Url.IsEqualUri(ReferanceUri.UriPrimaryServiceRoot.OriginalString))
              {
                ResourceIndex.ReferenceServiceBaseUrlId = FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.UriPrimaryServiceRoot.OriginalString.StripHttp().ToLower());
              }
              ResourceIndexList.Add(ResourceIndex);
            }
          }
        }
      }
    }

    private static void SetResourceIndentityElements(ResourceIndexType ResourceIndex, IFhirRequestUri FhirRequestUri)
    {
      ResourceIndex.ReferenceResourceType = FhirRequestUri.ResourseName;
      ResourceIndex.ReferenceVersionId = FhirRequestUri.VersionId;
      ResourceIndex.ReferenceFhirId = FhirRequestUri.ResourceId;
    }
  }
}
