using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IMetadataService
  {
    IResourceServiceOutcome GetServersConformanceResource(IDtoSearchParameterGeneric SearchParameterGeneric);
  }
}