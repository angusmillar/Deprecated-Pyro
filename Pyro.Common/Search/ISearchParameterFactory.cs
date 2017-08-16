using System;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Search
{
  public interface ISearchParameterFactory
  {
    ISearchParameterBase CreateSearchParameter(ServiceSearchParameterLight DtoSupportedSearchParametersResource, Tuple<string, string> Parameter);
  }
}