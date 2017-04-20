using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;
using System.Net;

namespace Pyro.Common.BusinessEntities.Service
{
  public class SearchParametersServiceOutcome : Pyro.Common.Interfaces.Service.ISearchParametersServiceOutcome
  {
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public DtoSearchParameters SearchParameters { get; set; }

    internal SearchParametersServiceOutcome() { }

  }
}
