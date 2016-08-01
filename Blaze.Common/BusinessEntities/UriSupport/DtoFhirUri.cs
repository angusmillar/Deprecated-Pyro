using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Common.BusinessEntities.UriSupport
{
  public class DtoFhirUri : IFhirUri
  {
    //Info
    //Absolute
    //value="http://angusmilllar.com.au/someApi/Organization/f001"

    //Absolute with _history
    //value="http://angusmilllar.com.au/someApi/Organization/f001/_history/2"   

    //Relative
    //value="Organization/f001"

    //Contained, this object does not need to parse these
    //value="#org1"

    private readonly char UriDelimieter = '/';
    private readonly string HistorySegmentName = "_history";
    private readonly string RegexResourceDilimeter = "|";

    public DtoFhirUri(Uri Uri)
    {
      ParseUri(Uri);
    }

    public DtoFhirUri(string UriString)
    {
      if (Uri.IsWellFormedUriString(UriString, UriKind.Absolute))
      {        
        var Uri = new Uri(UriString);
        this.ParseUri(Uri);
      }
      else
      {
        if (HttpUtil.IsRestResourceIdentity(UriString))
        {
          this.IsAbsoluteUri = false;
          ParseOutResourceIdentity(UriString);
        }
        else
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_RESOURCE_TYPE_MISMATCH", String.Format("Resource Type Mismatch"));
          oIssueComponent.Details.Text = String.Format("A URL was not formed correctly, server expected a known FHIR Resource type and Id in the URL, URL was : {0}", Uri.AbsoluteUri);
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
        }
      }
    }

    public bool IsAbsoluteUri { get; private set; }
    public bool IsRelativeUri { get { return !this.IsAbsoluteUri; } }

    /// <summary>
    /// The Raw Uri as it was passed in to DtoFhirUri
    /// </summary>
    public Uri Uri { get; private set; }
    /// <summary>
    /// example: 'Http' or 'Https'
    /// </summary>
    public string Schema { get; private set; }
    /// <summary>
    /// '://'
    /// </summary>
    public string SchemaDelimiter { get; private set; }
    /// <summary>
    /// example: 'www.somewhere.com'
    /// </summary>
    public string Authority { get; private set; }
    /// <summary>
    /// example: 'fhirapi/open' or 'fhirapi/open' or 'fhirapi'
    /// </summary>
    public string[] ApiSegments { get; private set; }
    /// <summary>
    /// example: 'Patient' or 'DiagnosticReport'
    /// </summary>
    public string ResourseType { get; private set; }
    /// <summary>
    /// example: '123456789'
    /// </summary>
    public string Id { get; private set; }
    /// <summary>
    /// example: True if the identity points to a history resource
    /// </summary>
    public bool IsHistory { get; private set; }
    /// <summary>
    /// The Version Id of the identity, null unless IsHistory is true 
    /// </summary>
    public string VersionId { get; private set; }    
    /// <summary>
    /// Returns the full Service Root part as a Uri DataType
    /// </summary>
    public Uri ServiceRootUrl
    {
      get
      {
        if (this.IsAbsoluteUri)
        {
          string NewUriString = string.Empty;
          if (this.ApiSegments.Length == 0)
            NewUriString = String.Format("{0}{1}{2}", Schema, SchemaDelimiter, Authority);
          else
            NewUriString = String.Format("{0}{1}{2}{3}{4}", Schema, SchemaDelimiter, Authority, UriDelimieter, ApiSegmentsToPath());
          return new Uri(NewUriString);
        }
        else
        {
          return null;
        }
      }
    }
    /// <summary>
    /// The Service Root without the Schema 'Http or Https' or Schema delimiter '://'
    /// This can be used to compare to URL's ServiceRoot for equality.  
    /// </summary>
    public string ServiceRootUrlForComparison
    {
      get
      {
        if (this.ApiSegments.Length == 0)
          return String.Format("{0}", Authority);
        else
          return String.Format("{0}{1}{2}", Authority, UriDelimieter, ApiSegmentsToPath());
      }
    }
    /// <summary>
    /// Retuns the full Resource identity with out the resource type (e.g /10/_history/2
    /// </summary>
    public string FullResourceIdentity
    {
      get
      {
        if (this.IsHistory)
          return String.Format("{1}{0}{2}{0}{3}", UriDelimieter.ToString(), this.Id, this.HistorySegmentName, this.VersionId);
        else
          return this.Id;
      }
    }

    private void ParseUri(Uri Uri)
    {
      this.SchemaDelimiter = Uri.SchemeDelimiter;
      this.Uri = Uri;

      if (Uri.IsAbsoluteUri)
      {
        this.IsAbsoluteUri = true;
        this.Schema = Uri.Scheme;
        this.Authority = Uri.Authority;
      }
      else
      {
        this.IsAbsoluteUri = false;
      }

      ParseOutResourceIdentity(Uri.OriginalString);

      if (this.ResourseType == null)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
        oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_RESOURCE_TYPE_MISMATCH", String.Format("Resource Type Mismatch"));
        oIssueComponent.Details.Text = String.Format("A URL was not formed correctly, server expected a known FHIR Resource type in the URL and yet did not find one in the URL: {0}", Uri.AbsoluteUri);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
      }

      if (this.Id != null)
      {
        if (!HttpUtil.IsRestResourceIdentity(Uri))
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted"));
          oIssueComponent.Details.Text = String.Format("A URL was not formed correctly, server expected a FHIR Resource Identity URL yet found: '{0}'", Uri.AbsoluteUri);
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
        }
      }

    }

    private void ParseOutResourceIdentity(string OriginalString)
    {
      var ApiSegmentList = new List<string>();
      string FhirResourceRegexPattern = string.Empty;
      FhirResourceRegexPattern += String.Join(RegexResourceDilimeter, ModelInfo.SupportedResources);

      string[] AbsolutePathArray = null;
      AbsolutePathArray = OriginalString.Split(UriDelimieter);
      for (int i = 0; i < AbsolutePathArray.Length; i++)
      {
        if (this.ResourseType == null)
        {
          if (Regex.IsMatch(AbsolutePathArray[i], FhirResourceRegexPattern))
          {
            this.ResourseType = AbsolutePathArray[i];
          }
          else
          {
            if (i > 0)
            {
              ApiSegmentList.Add(AbsolutePathArray[i]);
            }
          }
        }
        else
        {
          if (this.Id == null)
          {
            //for now I am amusing Id could contain the _historyversion as well, e.g Patient/123?_history=2
            this.Id = AbsolutePathArray[i];
          }
          else
          {
            if (this.IsHistory)
            {
              this.VersionId = AbsolutePathArray[i];
            }
            else
            {
              if (Regex.IsMatch(AbsolutePathArray[i], HistorySegmentName, RegexOptions.IgnoreCase))
              {
                this.IsHistory = true;
              }
              else
              {
                var oIssueComponent = new OperationOutcome.IssueComponent();
                oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
                oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
                oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted"));
                oIssueComponent.Details.Text = String.Format("A URL was not formed correctly, server expected a _history segment in the URL yet found '{0}' in the URL: {1}", AbsolutePathArray[i], OriginalString);
                oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
                var oOperationOutcome = new OperationOutcome();
                oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
                throw new DtoBlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
              }
            }
          }
        }
      }
      this.ApiSegments = ApiSegmentList.ToArray();
    }

    private string ApiSegmentsToPath()
    {
      var ReturnString = string.Empty;
      ReturnString += String.Join(UriDelimieter.ToString(), this.ApiSegments);
      return ReturnString;
    }
  }
}
