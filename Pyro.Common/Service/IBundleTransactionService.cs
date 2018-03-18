using Hl7.Fhir.Model;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service;
using Pyro.Common.Tools.Headers;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBundleTransactionService
  {
    IResourceServiceOutcome Transact(Resource Resource, IRequestMeta RequestMeta);
  }
}
