using System;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Tools.UriSupport;
using System.Collections.Generic;
using Pyro.Common.BackgroundTask.TaskPayload;

namespace Pyro.Common.Service.ResourceService
{
  public interface IResourceServiceOutcome
  {
    string FhirResourceId { get; set; }
    RestEnum.CrudOperationType OperationType { get; set; }
    string ResourceVersionNumber { get; set; }
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
    DateTimeOffset? LastModified { get; set; }
    bool? IsDeleted { get; set; }
    IPyroFhirUri RequestUri { get; set; }
    Resource ResourceResult { get; set; }
    string FormatMimeType { get; set; }
    SummaryType? SummaryType { get; set; }
    bool SuccessfulTransaction { get; set; }
    IList<IBackgroundTaskPayloadBase> BackgroundTaskList { get; set; }
}
}
