using System.Net;
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface ISearchParametersServiceOutcome
  {
    OperationOutcome FhirOperationOutcome { get; set; }
    HttpStatusCode HttpStatusCode { get; set; }
    PyroSearchParameters SearchParameters { get; set; }
  }
}