using System;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Services
{
  public interface IServiceOperationOutcome
  {
    string FhirResourceId { get; set; }
    RestEnum.CrudOperationType OperationType { get; set; }
    string ResourceVersionNumber { get; set; }
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
    //System.Net.HttpStatusCode HttpStatusCodeToReturn { get; }
    DateTimeOffset? LastModified { get; set; }
    bool? IsDeleted { get; set; }
    Uri RequestUri { get; set; }
    Uri ServiceRootUri { get; set; }
    Resource ResourceResult { get; set; }
    //Hl7.Fhir.Model.Resource ResourceToReturn();
    //Common.Interfaces.IDatabaseOperationOutcome DatabaseOperationOutcome { get; set; }
    IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }
    ISearchParametersValidationOperationOutcome SearchValidationOperationOutcome { get; set; }
  }
}
