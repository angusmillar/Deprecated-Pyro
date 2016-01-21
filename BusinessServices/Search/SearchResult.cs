using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities;
using Dip.Interfaces;
using Blaze.Engine.Support.ExtensionMethods;

namespace Blaze.Engine.Search
{
  public class SearchResult : Response.BlazeResponseBase
  {
    private IDatabaseSearchResult _DbSearchResult;
    public IDatabaseSearchResult DbSearchResult 
    { 
      get
      {
        return _DbSearchResult;
      }
      set
      {
        _DbSearchResult = value;
        if (_DbSearchResult.HasDbError)
        {          
          GenerateDbErrorResponse();         
        }
      } 
    }
    public Uri RequestUri { get; set; }    
    public override Resource ResourceToReturn()
    {
      if (this.HasError)
      {
        this.OperationOutcome.GenerateNarrative();
        return this.OperationOutcome;
      }
      else
      {
        if (this._DbSearchResult.ResourcesMatchingSearchList != null)
        {
          return SerializeToBundle();          
        }
        else if (this._DbSearchResult.ResourceMatchingSearch != null)
        {
          return SerializeToResource();          
        }
        else
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;            
          OpOutComeIssueComp.Diagnostics = "Internal Server Error: SearchResult has no error yet also has no resource or bundle.";
          var OpOutcome = new OperationOutcome();
          OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() {OpOutComeIssueComp};
          throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
        }
      }
    }
    private Resource SerializeToResource()
    { 
      if (!this.HasError)
      {
        if (this._DbSearchResult.ResourceMatchingSearch != null)
        {
          try
          {
            return Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(this._DbSearchResult.ResourceMatchingSearch.Xml) as Patient;            
          }
          catch (Exception oExec)
          {
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
            OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: Serialization of a Resource retrieved from the servers database failed. The record details were: Key: {0}, Received: {1}. The parser exception error was '{2}", this._DbSearchResult.ResourceMatchingSearch.Id, this._DbSearchResult.ResourceMatchingSearch.Received.ToString(), oExec.Message);
            var OpOutcome = new OperationOutcome();
            OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
            throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
          }
        }
        else
        {          
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: In the method SearchResult.SerializeToResource(). this._DbSearchResult.ResourceMatchingSearch was found to be null.'");
          var OpOutcome = new OperationOutcome();
          OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
          throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics); 
        }
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: SearchResult.SerializeToResource() called when Error detected in search results returned.");
        var OpOutcome = new OperationOutcome();
        OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);                      
      }
    }
    private Bundle SerializeToBundle()
    {
      if (!this.HasError)
      {
        if (this.DbSearchResult.ResourcesMatchingSearchList != null)
        {
          var FhirBundle = new Bundle() { Type = Bundle.BundleType.Searchset };

          FhirBundle.Total = this.DbSearchResult.ResourcesMatchingSearchCount;

          //Paging           
          int LastPageNumber = Support.PagingSupport.GetLastPageNumber(this.DbSearchResult.NumberOfRecordsPerPage, this.DbSearchResult.ResourcesMatchingSearchCount);
          FhirBundle.FirstLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, 1);
          FhirBundle.LastLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, LastPageNumber);
          FhirBundle.NextLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, Support.PagingSupport.GetNextPageNumber(this.DbSearchResult.PageRequested, LastPageNumber));
          FhirBundle.PreviousLink = Support.PagingSupport.GetPageNavigationUri(this.RequestUri, Support.PagingSupport.GetPreviousPageNumber(this.DbSearchResult.PageRequested, LastPageNumber));

          foreach (DtoResource DtoResource in this.DbSearchResult.ResourcesMatchingSearchList)
          {
            Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();
            try
            {
              var PatientResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(DtoResource.Xml) as Patient;
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
              throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
            }
            oResEntry.Search = new Bundle.SearchComponent();
            oResEntry.Search.Mode = Bundle.SearchEntryMode.Match;
            oResEntry.Link = new List<Bundle.LinkComponent>();

            FhirBundle.Entry.Add(oResEntry);            
          }
          return FhirBundle;
        }
        else
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: In the method SearchResult.SerializeToBundle(). this._DbSearchResult.ResourceMatchingSearch was found to be null.'");
          var OpOutcome = new OperationOutcome();
          OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
          throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics); 
        }
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: SearchResult.SerializeToBundle() called when Error detected in search results returned.");
        var OpOutcome = new OperationOutcome();
        OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);               
      }
    }
    private void GenerateDbErrorResponse()
    {
      var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
      OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
      OpOutComeIssueComp.Code = OperationOutcome.IssueType.Unknown;
      OpOutComeIssueComp.Diagnostics = this.DbSearchResult.ErrorMessage;
      this.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.InternalServerError);
    }
  }
}
