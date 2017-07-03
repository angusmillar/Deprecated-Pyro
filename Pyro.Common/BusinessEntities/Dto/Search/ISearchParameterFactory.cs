using System;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.BusinessEntities.Search
{
  public interface ISearchParameterFactory
  {
    IDtoSearchParameterBase CreateSearchParameter(DtoServiceSearchParameterLight DtoSupportedSearchParametersResource, Tuple<string, string> Parameter);
  }
}