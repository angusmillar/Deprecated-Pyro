using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.Enum;
using Pyro.Common.Exceptions;
using Pyro.Common.Tools.UriSupport;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pyro.Common.Service.ResourceService
{
  public class ResourceServiceOutcome : IResourceServiceOutcome
  {
    #region Public Properties

    public string FhirResourceId { get; set; }
    //public Uri RequestUri { get; set; }
    public IPyroFhirUri RequestUri { get; set; }
    public string ResourceVersionNumber { get; set; }
    public RestEnum.CrudOperationType OperationType { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public bool? IsDeleted { get; set; }
    private HttpStatusCode _HttpStatusCode { get; set; }
    public HttpStatusCode HttpStatusCode
    {
      get
      {
        return ResolveHttpStatusCode();
      }
      set
      {
        _HttpStatusCode = value;
      }
    }
    private Resource _ResourceResult;
    public Resource ResourceResult
    {
      get
      {
        return ResolveResource();
      }
      set
      {
        _ResourceResult = value;
      }
    }
    public string FormatMimeType { get; set; }
    public SummaryType? SummaryType { get; set; }
    public bool SuccessfulTransaction { get; set; }
    public IList<IBackgroundTaskPayload> BackgroundTaskList { get; set; }
    #endregion

    #region Constructor
    public ResourceServiceOutcome()
    {
      this.OperationType = RestEnum.CrudOperationType.None;
      this.FormatMimeType = null;
      this.SuccessfulTransaction = false;
      this.BackgroundTaskList = new List<IBackgroundTaskPayload>();
    }
    #endregion

    #region Private Methods

    private HttpStatusCode ResolveHttpStatusCode()
    {
      return _HttpStatusCode;
    }

    private Resource ResolveResource()
    {
      if (this._ResourceResult != null)
      {
        return this._ResourceResult;
      }
      else if (this.OperationType == RestEnum.CrudOperationType.Create ||
        this.OperationType == RestEnum.CrudOperationType.Update ||
        this.OperationType == RestEnum.CrudOperationType.Delete ||
        this.OperationType == RestEnum.CrudOperationType.Read)
      {
        //We do return a resource on Create and Update and this logic will work to return that resource but
        //it will also work if we decide to not return a resource for these cases in the future.
        return null;
      }
      else
      {
        string message = "Internal Server Error: PyroServiceOperationoutcome was unable to resolve a Http Status Code for the operation performed.";
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, message);
        throw new PyroException(HttpStatusCode.InternalServerError, OpOutCome, message);
      }
    }

    #endregion

  }
}
