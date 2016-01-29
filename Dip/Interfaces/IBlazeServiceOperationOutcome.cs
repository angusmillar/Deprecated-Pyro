using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace Dip.Interfaces
{
  public interface IBlazeServiceOperationOutcome
  {    
    string FhirResourceId { get; set; }
    Dip.Interfaces.IDatabaseOperationOutcome DatabaseOperationOutcome { get; set; }
    DtoEnums.CrudOperationType OperationType { get; set; }
    int ResourceVersionNumber { get; set; }    
    System.Net.HttpStatusCode HttpStatusCodeToReturn { get; }    
    DateTimeOffset? LastModified { get; set; }
    Uri RequestUri { get; set; }
    Hl7.Fhir.Model.Resource ResourceToReturn { get; }
    IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }
    ISearchTermValidationOperationOutcome SearchValidationOperationOutcome { get; set; }
    ISearchPlanValidationOperationOutcome SearchPlanValidationOperationOutcome { get; set; }
  }
}
