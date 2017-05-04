using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.IndexSetter
{
  public static class IndexSetterFactory
  {
    public static IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      switch (SearchParameter.Type)
      {
        case SearchParamType.Number:
          return NumberSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Date:
          return DateTimeSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);          
        case SearchParamType.String:
          return StringSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Token:
          return TokenSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Reference:
          {
            if (FhirRequestUri == null || FhirRequestUri.PrimaryRootUrlStore == null)
              throw new NullReferenceException("FhirRequestUri and FhirRequestUri.PrimaryRootUrlStore cannot be null for SearchParamType.Reference type index setting.");
            if (FhirRequestUri == null || FhirRequestUri.PrimaryRootUrlStore == null)
              throw new NullReferenceException("CommonRepository cannot be null for SearchParamType.Reference type index setting.");

            return ReferenceSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter, FhirRequestUri, CommonRepository);
          }
        case SearchParamType.Composite:
          return null;
        case SearchParamType.Quantity:
          return QuantitySetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);          
        case SearchParamType.Uri:
          return UriSetter<ResourceCurrentType, ResourceIndexType>.Set(oElement, SearchParameter);          
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.Type.ToString(), (int)SearchParameter.Type, typeof(SearchParamType));
      }

    }
  }
}