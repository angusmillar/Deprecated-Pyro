using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces;
using System.Net;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Enum;
using Pyro.Common.Tools;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ServiceOperationOutcome : IServiceOperationOutcome
  {
    #region Public Properties

    public string FhirResourceId { get; set; }
    public Uri RequestUri { get; set; }
    public Uri ServiceRootUri { get; set; }
    public string ResourceVersionNumber { get; set; }
    public RestEnum.CrudOperationType OperationType { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public bool? IsDeleted { get; set; }
    public ISearchParametersValidationOperationOutcome SearchValidationOperationOutcome { get; set; }
    public IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }    
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

    #endregion

    #region Constructor
    internal ServiceOperationOutcome()
    {
      this.OperationType = RestEnum.CrudOperationType.None;
    }
    #endregion

    #region Private Methods

    private HttpStatusCode ResolveHttpStatusCode()
    {
      if (this.SearchValidationOperationOutcome != null && this.SearchValidationOperationOutcome.FhirOperationOutcome != null)
      {
        return this.SearchValidationOperationOutcome.HttpStatusCode;
      }
      else if (this.ResourceValidationOperationOutcome != null && this.ResourceValidationOperationOutcome.FhirOperationOutcome != null)
      {
        return this.ResourceValidationOperationOutcome.HttpStatusCode;
      }
      else
      {
        return _HttpStatusCode;
      }      
    }

    private Resource ResolveResource()
    {      
      if (this.SearchValidationOperationOutcome != null && this.SearchValidationOperationOutcome.FhirOperationOutcome != null)
      {
        return this.SearchValidationOperationOutcome.FhirOperationOutcome;
      }
      else if (this.ResourceValidationOperationOutcome != null && this.ResourceValidationOperationOutcome.FhirOperationOutcome != null)
      {
        return this.ResourceValidationOperationOutcome.FhirOperationOutcome;
      }
      else if (this._ResourceResult != null)
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
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = "Internal Server Error: PyroServiceOperationoutcome was unable to resolve a Http Status Code for the operation performed.";
        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoPyroException(HttpStatusCode.InternalServerError, OpOutCome, OpOutComeIssueComp.Diagnostics);
      }
    }

    #endregion

  }
}
