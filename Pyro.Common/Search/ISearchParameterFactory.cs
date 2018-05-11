using System;
using Pyro.Common.DtoEntity;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Search
{
  public interface ISearchParameterFactory
  {
    ISearchParameterBase CreateSearchParameter(DtoServiceSearchParameterLight DtoSupportedSearchParametersResource, Tuple<string, string> Parameterbool, bool IsChainedReferance = false);
  }
}