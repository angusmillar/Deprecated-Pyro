using Hl7.Fhir.Model;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.FhirOperation.BundleTransaction
{
  public interface IBundleTransactionOperation
  {
    IResourceServiceOutcome Transact(Resource Resource, IRequestMeta RequestMeta);
  }
}
