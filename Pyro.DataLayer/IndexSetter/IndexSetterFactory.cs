using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.DataLayer.DbModel.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.IndexSetter
{
  public static class IndexSetterFactory
  {
    public static IList<ResourceIndexType> Set<ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceIndexType : ResourceIndexBase, new()
    {
      switch (SearchParameter.Type)
      {
        case SearchParamType.Number:
          return NumberSetter<ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Date:
          return DateTimeSetter<ResourceIndexType>.Set(oElement, SearchParameter);          
        case SearchParamType.String:
          return StringSetter<ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Token:
          return TokenSetter<ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Reference:
          return ReferenceSetter<ResourceIndexType>.Set(oElement, SearchParameter);
        case SearchParamType.Composite:
          return null;
        case SearchParamType.Quantity:
          return QuantitySetter<ResourceIndexType>.Set(oElement, SearchParameter);          
        case SearchParamType.Uri:
          return UriSetter<ResourceIndexType>.Set(oElement, SearchParameter);          
        default:
          return null;
      }

    }
  }
}