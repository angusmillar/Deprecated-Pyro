using System.Collections.Generic;
using Hl7.Fhir.ElementModel;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.IndexSetter
{
  public interface IUriSetter
  {
    IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new();
  }
}