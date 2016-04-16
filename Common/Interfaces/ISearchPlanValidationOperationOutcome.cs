using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using System.Net;

namespace Common.Interfaces
{
  public interface ISearchPlanValidationOperationOutcome
  {
    OperationOutcome FhirOperationOutcome { get; set; }
    HttpStatusCode HttpStatusCode { get; set; }
  }
}
