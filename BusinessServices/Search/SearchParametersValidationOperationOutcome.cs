using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities.Search;
using System.Net;

namespace Blaze.Engine.Search
{
  public class SearchParametersValidationOperationOutcome : Dip.Interfaces.ISearchParametersValidationOperationOutcome
  {    
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public DtoSearchParameters SearchParameters { get; set; }
  }
}
