using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.FhirUri;

namespace Blaze.Common.BusinessEntities.FhirUri
{
  public class DtoFhirUri : IFhirUri
  {
    private readonly char UriDelimieter = '/';
    private readonly char UriSearchParameterDelimieter = '?';
    
    public Uri Uri { get; set; }
    /// <summary>
    /// example: 'Http' or 'Https'
    /// </summary>
    public string Schema { get; set; }
    /// <summary>
    /// '://'
    /// </summary>
    public string SchemaDilemeter { get; set; }
    /// <summary>
    /// example: 'www.somewhere.com'
    /// </summary>
    public string Authority { get; set; }
    /// <summary>
    /// example: 'fhirapi/open' or 'fhirapi/open' or 'fhirapi'
    /// </summary>
    public string ApiSegments { get; set; }
    /// <summary>
    /// example: 'Patient' or 'DiagnosticReport'
    /// </summary>
    public string ResourseType { get; set; }
    /// <summary>
    /// example: '123456789'
    /// </summary>
    public string Id { get; set; }
    // example: 'Encounter' or 'Patient'
    public string Compartment { get; set; }

    public DtoFhirUri(Uri Uri, string RoutePrefix)
    {
      if (HttpUtil.IsRestResourceIdentity(Uri))
      {
        //Need to use RoutePrefix to sort out parts
        var AbsolutePathTemp = Uri.AbsolutePath;        
        if (AbsolutePathTemp.StartsWith(UriDelimieter + RoutePrefix.ToLower() + UriDelimieter))
        {
          this.ApiSegments = RoutePrefix.ToLower();
          AbsolutePathTemp = AbsolutePathTemp.Substring(RoutePrefix.Count() + 2, AbsolutePathTemp.Count() - RoutePrefix.Count() - 2);
        }
        else
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: The RoutePrefix of '{0}' was not found at the start of the Url AbsolutePath.", RoutePrefix);
          var OpOutcome = new OperationOutcome();
          OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
          throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
        }
        var PathArrayTemp = AbsolutePathTemp.Split(UriDelimieter);
        if (PathArrayTemp.Count() > 0)
          this.ResourseType = PathArrayTemp[0];
        if (PathArrayTemp.Count() > 1)
          this.Id = PathArrayTemp[1].Split(UriSearchParameterDelimieter)[0].Trim();
        if (PathArrayTemp.Count() > 2)
          this.Compartment = PathArrayTemp[2].Split(UriSearchParameterDelimieter)[0].Trim();
        this.Schema = Uri.Scheme;
        this.SchemaDilemeter = Uri.SchemeDelimiter;
        this.Authority = Uri.Authority;
        this.Uri = Uri;
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: The Url did not pass the Fhir API regex validation. The Url was: {0}", Uri.AbsoluteUri);
        var OpOutcome = new OperationOutcome();
        OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
      }
    }
    public Uri RootFhirUri 
    { 
      get
      {
        string NewUriString = String.Format("{0}{1}{2}{3}{4}{5}", Schema, SchemaDilemeter, Authority, UriDelimieter, ApiSegments, UriDelimieter);
        return new Uri(NewUriString);
      }
    }
  }
}
