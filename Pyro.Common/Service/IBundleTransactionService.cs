using Hl7.Fhir.Model;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBundleTransactionService
  {
    IResourceServiceOutcome Transact(Resource Resource, IPyroRequestUri RequestUri);
  }
}
