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
    public static ResourceIndexType Set<ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceIndexType : ResourceIndexBase, new()
    {
      switch (SearchParameter.Type)
      {
        case SearchParamType.Number:
          return null;
        case SearchParamType.Date:
          return DateTimeSetter.Set<ResourceIndexType>(oElement, SearchParameter);          
        case SearchParamType.String:
          return StringSetter.Set<ResourceIndexType>(oElement, SearchParameter);
        case SearchParamType.Token:
          return null;
        case SearchParamType.Reference:
          return null;
        case SearchParamType.Composite:
          return null;
        case SearchParamType.Quantity:
          return null;
        case SearchParamType.Uri:
          return null;
        default:
          return null;
      }

    }
  }
}