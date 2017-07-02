using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBundleTransactionService
  {
    IResourceServiceOutcome Transact(Resource Resource, IDtoRequestUri RequestUri);
  }
}
