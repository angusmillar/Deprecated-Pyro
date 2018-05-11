using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirOperation.ResourceReport
{
  public interface IResourceReportOperation
  {
    IResourceServiceOutcome Process(ISearchParameterGeneric SearchParameterGeneric);
  }
}