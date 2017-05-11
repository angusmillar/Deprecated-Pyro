using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.Repository.Interfaces;

namespace Pyro.DataLayer.IndexSetter
{
  public static class ReferenceSetter<ResourceCurrentType, ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;
    private static IDtoRequestUri _FhirRequestUri;
    private static ICommonRepository _CommonRepository;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter, IDtoRequestUri FhirRequestUri, ICommonRepository CommonRepository)      
    {
      ResourceIndexList = new List<ResourceIndexType>();      
      ServiceSearchParameterId = SearchParameter.Id;
      _FhirRequestUri = FhirRequestUri;
      _CommonRepository = CommonRepository;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {        
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetFhirUri(FhirUri);
        }  
        else if (Poco.FhirValue is ResourceReference ResourceReference)
        {
          SetResourcereference(ResourceReference);
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }      
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private static void SetResourcereference(ResourceReference ResourceReference)
    {
      //Check the Uri is actual a Fhir resource reference 
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(ResourceReference.Reference))
      {
        if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
        {
          string ErrorMessage;
          IFhirRequestUri ReferanceUri = null;
          if (FhirRequestUri.TryParse(_FhirRequestUri.PrimaryRootUrlStore.Url, ResourceReference.Url.OriginalString, out ReferanceUri, out ErrorMessage))
          {
            var ResourceIndex = new ResourceIndexType();
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);
            if (ResourceReference.Url.IsAbsoluteUri)
            {
              if (_FhirRequestUri.PrimaryRootUrlStore.Url.ToLower() == ReferanceUri.UriPrimaryServiceRoot.OriginalString.ToLower())
              {
                ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = _CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.UriPrimaryServiceRoot.OriginalString.ToLower());
              }
            }
            else
            {
              ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
            }
            ResourceIndexList.Add(ResourceIndex);            
          }
        }
      }
    }

    private static void SetFhirUri(FhirUri FhirUri)
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
            
            if (FhirRequestUri.TryParse(_FhirRequestUri.PrimaryRootUrlStore.Url, FhirUri.Value.Trim(), out ReferanceUri, out ErrorMessage))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              ResourceIndexList.Add(ResourceIndex);
            }
          }
          else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
          {
            if (FhirRequestUri.TryParse(_FhirRequestUri.PrimaryRootUrlStore.Url, FhirUri.Value.Trim(), out ReferanceUri, out ErrorMessage))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              if (_FhirRequestUri.PrimaryRootUrlStore.Url.ToLower() == ReferanceUri.UriPrimaryServiceRoot.OriginalString.ToLower())
              {
                ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = _CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.UriPrimaryServiceRoot.OriginalString.ToLower());
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
