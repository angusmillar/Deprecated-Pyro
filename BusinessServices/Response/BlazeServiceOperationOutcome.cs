using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Dip.Interfaces;
using System.Net;
using Blaze.Engine.Search;
using BusinessEntities;

namespace Blaze.Engine.Response
{  
  public class BlazeServiceOperationOutcome : Dip.Interfaces.IBlazeServiceOperationOutcome
  {    
    #region Public Properties
    
    public string FhirResourceId { get; set; }
    public Uri RequestUri { get; set; }
    public int ResourceVersionNumber { get; set; }
    public DtoEnums.CrudOperationType OperationType { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public ISearchParametersValidationOperationOutcome SearchValidationOperationOutcome { get; set; }
    public IResourceValidationOperationOutcome ResourceValidationOperationOutcome { get; set; }
    public ISearchPlanValidationOperationOutcome SearchPlanValidationOperationOutcome { get; set; }
    public IDatabaseOperationOutcome DatabaseOperationOutcome { get; set; }
    public HttpStatusCode HttpStatusCodeToReturn
    {
      get
      {
        return ResolveHttpStatusCodeToReturn();
      }
    }
    public Resource ResourceToReturn
    {
      get
      {
        return ResolveResourceToReturn();
      }
    }
    #endregion

    #region Constructor
    public BlazeServiceOperationOutcome()
    {
      this.OperationType = DtoEnums.CrudOperationType.None;
    }
    #endregion

    #region Private Methods
    private HttpStatusCode ResolveHttpStatusCodeToReturn()
    {     
      if (this.SearchValidationOperationOutcome != null)
      {
        return this.SearchValidationOperationOutcome.HttpStatusCode;
      }
      if (this.SearchPlanValidationOperationOutcome != null)
      {
        return this.SearchPlanValidationOperationOutcome.HttpStatusCode;
      }
      else if (this.ResourceValidationOperationOutcome != null)
      {
        return this.ResourceValidationOperationOutcome.HttpStatusCode;
      }      
      else if (this.OperationType == DtoEnums.CrudOperationType.Create)
      {
        return HttpStatusCode.Created;
      }
      if (this.OperationType == DtoEnums.CrudOperationType.Read)
      {
        if (this.DatabaseOperationOutcome.SingleResourceRead)
        {
          if (this.DatabaseOperationOutcome.ResourceMatchingSearch == null)
          {
            return HttpStatusCode.Gone;
          }
          else
          {
            return HttpStatusCode.OK;
          }
        }
        else
        {
          return HttpStatusCode.OK;
        }
      }
      else if (this.OperationType == DtoEnums.CrudOperationType.Update)
      {
        return HttpStatusCode.OK;
      }
      else if (this.OperationType == DtoEnums.CrudOperationType.Delete)
      {
        return HttpStatusCode.NoContent;
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = "Internal Server Error: BlazeServiceOperationoutcome was unable to resolve a Http Status Code for the operation performed.";
        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoBlazeException(HttpStatusCode.InternalServerError, OpOutCome, OpOutComeIssueComp.Diagnostics);
      }
    }
    private Resource ResolveResourceToReturn()
    {
      if (this.OperationType == DtoEnums.CrudOperationType.Delete)
      {
        return null;
      }
      else if (this.SearchValidationOperationOutcome != null)
      {
        return this.SearchValidationOperationOutcome.FhirOperationOutcome;
      }
      else if (this.SearchPlanValidationOperationOutcome != null)
      {
        return this.SearchPlanValidationOperationOutcome.FhirOperationOutcome;
      }
      else if (this.ResourceValidationOperationOutcome != null)
      {
        return this.ResourceValidationOperationOutcome.FhieOperationOutcome;
      }
      else if (this.DatabaseOperationOutcome != null)
      {
        if (this.DatabaseOperationOutcome.SingleResourceRead)
        {
          if (this.DatabaseOperationOutcome.ResourceMatchingSearch != null)
          {
            return SerializeToResource();
          }
          else
          {
            //There is no error, we just did not find a resource for the FHIRResourceId they provided. 
            return null;
          }
        }
        else if (this.DatabaseOperationOutcome.ResourcesMatchingSearchList != null)
        {
          return SerializeToBundle();
        }
        else
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = "Internal Server Error: BlazeServiceOperationoutcome was unable to resolve any Resource to return for the operation performed even though no error was detected, this s a bug in the server!.";
          var OpOutCome = new OperationOutcome();
          OpOutCome.Issue = new List<OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
          throw new DtoBlazeException(HttpStatusCode.InternalServerError, OpOutCome, OpOutComeIssueComp.Diagnostics);
        }
      }
      else if (this.OperationType == DtoEnums.CrudOperationType.Create)
      {
        return null;
      }
      else if (this.OperationType == DtoEnums.CrudOperationType.Update)
      {
        return null;
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = "Internal Server Error: BlazeServiceOperationoutcome was unable to resolve a Http Status Code for the operation performed.";
        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoBlazeException(HttpStatusCode.InternalServerError, OpOutCome, OpOutComeIssueComp.Diagnostics);
      }
    }
    private Resource SerializeToResource()
    {
      try
      {        
        Resource oResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(this.DatabaseOperationOutcome.ResourceMatchingSearch.Xml);
        return oResource;
      }
      catch (Exception oExec)
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: Serialization of a Resource retrieved from the servers database failed. The record details were: Key: {0}, Received: {1}. The parser exception error was '{2}", this.DatabaseOperationOutcome.ResourceMatchingSearch.Id, this.DatabaseOperationOutcome.ResourceMatchingSearch.Received.ToString(), oExec.Message);
        var OpOutcome = new OperationOutcome();
        OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
      }
    }
    private Bundle SerializeToBundle()
    {
      var FhirBundle = new Bundle() { Type = Bundle.BundleType.Searchset };

      FhirBundle.Total = this.DatabaseOperationOutcome.ResourcesMatchingSearchCount;

      //Paging           
      int LastPageNumber = Support.PagingSupport.GetLastPageNumber(this.DatabaseOperationOutcome.NumberOfRecordsPerPage, this.DatabaseOperationOutcome.ResourcesMatchingSearchCount);
      FhirBundle.FirstLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, 1);
      FhirBundle.LastLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, LastPageNumber);
      FhirBundle.NextLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, Support.PagingSupport.GetNextPageNumber(this.DatabaseOperationOutcome.PageRequested, LastPageNumber));
      FhirBundle.PreviousLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, Support.PagingSupport.GetPreviousPageNumber(this.DatabaseOperationOutcome.PageRequested, LastPageNumber));

      foreach (BusinessEntities.DtoResource DtoResource in this.DatabaseOperationOutcome.ResourcesMatchingSearchList)
      {
        Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();
        try
        {
          var PatientResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(DtoResource.Xml) as Resource;
          oResEntry.Resource = PatientResource;
        }
        catch (Exception oExec)
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: Serialization of a Resource retrieved from the servers database failed. The record details were: Key: {0}, Received: {1}. The parser exception error was '{2}", DtoResource.Id, DtoResource.Received.ToString(), oExec.Message);
          var OpOutcome = new OperationOutcome();
          OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
          throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
        }
        oResEntry.Search = new Bundle.SearchComponent();
        oResEntry.Search.Mode = Bundle.SearchEntryMode.Match;
        oResEntry.Link = new List<Bundle.LinkComponent>();

        FhirBundle.Entry.Add(oResEntry);
      }
      return FhirBundle;
    }
    #endregion

  }
}
