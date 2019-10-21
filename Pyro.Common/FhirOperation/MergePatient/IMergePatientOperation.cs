using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.FhirOperation.MergePatient
{
  public interface IMergePatientOperation
  {
    IResourceServiceOutcome Process(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}