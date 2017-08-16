using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Net;

namespace Pyro.Common.Service
{
  public class SearchParametersServiceOutcome : ISearchParametersServiceOutcome
  {
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public PyroSearchParameters SearchParameters { get; set; }

    public SearchParametersServiceOutcome() { }

  }
}
