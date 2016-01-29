using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using System.Net;

namespace Blaze.Engine.Search
{
  public class SearchTermValidationOperationOutcome : Dip.Interfaces.ISearchTermValidationOperationOutcome
  {    
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public SearchTerms SearchTerms { get; set; }
  }
}
