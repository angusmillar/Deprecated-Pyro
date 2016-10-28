using System;
using Blaze.Common.Enum;

namespace Blaze.Common.Interfaces.Services
{
  public interface IServiceOperationOutcome
  {
    string FhirResourceId { get; set; }
    Common.Interfaces.IDatabaseOperationOutcome DatabaseOperationOutcome { get; set; }
    RestEnum.CrudOperationType OperationType { get; set; }
    string ResourceVersionNumber { get; set; }
    System.Net.HttpStatusCode HttpStatusCodeToReturn { get; }
    DateTimeOffset? LastModified { get; set; }
    Uri RequestUri { get; set; }
    Hl7.Fhir.Model.Resource ResourceToReturn();
    IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }
    ISearchParametersValidationOperationOutcome SearchValidationOperationOutcome { get; set; }
    ISearchPlanValidationOperationOutcome SearchPlanValidationOperationOutcome { get; set; }
  }
}
