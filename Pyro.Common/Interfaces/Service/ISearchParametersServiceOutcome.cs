using System.Net;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.Interfaces.Service
{
  public interface ISearchParametersServiceOutcome
  {
    OperationOutcome FhirOperationOutcome { get; set; }
    HttpStatusCode HttpStatusCode { get; set; }
    DtoSearchParameters SearchParameters { get; set; }
  }
}