using System;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

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
    Pyro.Common.Interfaces.UriSupport.IFhirRequestUri RequestUri { get; set; }
    Resource ResourceResult { get; set; }
    string FormatMimeType { get; set; }
    SummaryType? SummaryType { get; set; }
    bool SuccessfulTransaction { get; set; }
  }
}
