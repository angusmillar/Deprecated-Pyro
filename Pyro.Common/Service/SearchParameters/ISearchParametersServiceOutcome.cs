using System.Net;
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.Service.SearchParameters
{
  public interface ISearchParametersServiceOutcome
  {
    OperationOutcome FhirOperationOutcome { get; set; }
    OperationOutcome FhirOperationOutcomeUnsupportedParameters { get; set; }    
    HttpStatusCode HttpStatusCode { get; set; }
    PyroSearchParameters SearchParameters { get; set; }
  }
}