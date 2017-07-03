using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServerResourceReportService
  {
    IResourceServiceOutcome Process(IDtoSearchParameterGeneric SearchParameterGeneric);
  }
}