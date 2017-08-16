using Pyro.Common.Search;
using Pyro.Common.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IMetadataService
  {
    IResourceServiceOutcome GetServersConformanceResource(ISearchParameterGeneric SearchParameterGeneric);
  }
}