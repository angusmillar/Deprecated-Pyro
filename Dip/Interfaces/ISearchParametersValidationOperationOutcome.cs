using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Interfaces
{
  public interface ISearchParametersValidationOperationOutcome
  {
    Hl7.Fhir.Model.OperationOutcome FhirOperationOutcome { get; set; }    
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
  }
}
