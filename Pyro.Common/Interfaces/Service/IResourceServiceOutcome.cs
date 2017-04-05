using System;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceOutcome
  {
    string FhirResourceId { get; set; }    
    RestEnum.CrudOperationType OperationType { get; set; }
    string ResourceVersionNumber { get; set; }
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
    DateTimeOffset? LastModified { get; set; }
    bool? IsDeleted { get; set; }
    Uri RequestUri { get; set; }
    Uri ServiceRootUri { get; set; }
    Resource ResourceResult { get; set; }
    string FormatMimeType { get; set; }
    IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }
    Service.ISearchParametersServiceOutcome SearchParametersServiceOutcome { get; set; }
    bool SuccessfulTransaction { get; set; }
  }
}
