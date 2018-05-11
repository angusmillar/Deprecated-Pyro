using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Interfaces.Operation
{
  public interface IFhirBaseOperationService
  {
    IResourceServiceOutcome Process(string OperationName, Resource Resource, IRequestMeta RequestMeta);
  }
}