using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;
using System.Net;

namespace Pyro.Common.BusinessEntities.Search.Validation
{
  public class SearchParametersValidationOperationOutcome : Common.Interfaces.ISearchParametersValidationOperationOutcome
  {    
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public DtoSearchParameters SearchParameters { get; set; }    
  }
}
