using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServerResourceReportService
  {
    IResourceServiceOutcome Process();
  }
}