using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dip.Interfaces;
using Hl7.Fhir.Model;
using System.Net;

namespace Blaze.Engine.Search
{
  public class SearchPlanValidationOperationOutcome : ISearchPlanValidationOperationOutcome
  {
    public OperationOutcome FhirOperationOutcome { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
  }
}
