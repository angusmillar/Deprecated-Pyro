using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.UriSupport;

namespace Pyro.DataLayer.IndexSetter
{
  public static class ReferenceSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)      
    {
      ResourceIndexList = new List<ResourceIndexType>();      
      ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {        
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetFhirUri(FhirUri);
        }  
        else if (Poco.FhirValue is ResourceReference ResourceReference)
        {

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

    private static void SetFhirUri(FhirUri FhirUri)
    {
      //if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      //{
      //  //Check the Uri is actual a Fhir resource reference 
      //  if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(FhirUri.Value))
      //  {
      //    IFhirUri ReferanceUri = null;
      //    if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Relative))
      //    {
      //      if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
      //      {
      //        SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
      //        ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.Id;
      //        return ReferenceIndex;
      //      }
      //    }
      //    else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
      //    {
      //      if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
      //      {
      //        SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
      //        if (FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
      //        {
      //          ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.Id;
      //        }
      //        else
      //        {
      //          ReferenceIndex.Url = CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
      //        }
      //        return ReferenceIndex;
      //      }
      //    }
      //  }
      //}
    }

    private static void SetInteger(Integer Integer) 
    {
      if (Integer.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndexList.Add(ResourceIndex);
        ResourceIndex.Quantity = Convert.ToInt32(Integer.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }    
  }
}
