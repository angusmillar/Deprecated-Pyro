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
  public static class ReferenceSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;
    private static IDtoFhirRequestUri _FhirRequestUri;
    private static ICommonRepository _CommonRepository;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository)      
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
          IFhirUri ReferanceUri = null;
          if (DtoFhirUri.TryParse(ResourceReference.Url, out ReferanceUri))
          {
            var ResourceIndex = new ResourceIndexType();
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);
            if (ResourceReference.Url.IsAbsoluteUri)
            {
              if (_FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
              {
                ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = _CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
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
          IFhirUri ReferanceUri = null;
          if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Relative))
          {
            if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              ResourceIndexList.Add(ResourceIndex);
            }
          }
          else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
          {
            if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
            {
              var ResourceIndex = new ResourceIndexType();
              SetResourceIndentityElements(ResourceIndex, ReferanceUri);
              if (_FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
              {
                ResourceIndex.ReferenceServiceBaseUrlId = _FhirRequestUri.PrimaryRootUrlStore.Id;
              }
              else
              {
                ResourceIndex.ReferenceUrl = _CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
              }
              ResourceIndexList.Add(ResourceIndex);
            }
          }
        }
      }
    }

    private static void SetResourceIndentityElements(ResourceIndexType ResourceIndex, IFhirUri ReferanceUri)
    {
      ResourceIndex.ReferenceResourceType = ReferanceUri.ResourseType;
      ResourceIndex.ReferenceVersionId = ReferanceUri.VersionId;
      ResourceIndex.ReferenceFhirId = ReferanceUri.Id;
    }
  }
}
