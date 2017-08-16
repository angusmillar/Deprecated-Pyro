using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface IServerResourceReportService
  {
    IResourceServiceOutcome Process(ISearchParameterGeneric SearchParameterGeneric);
  }
}