using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Validation
{
  public class BaseResourceValidation
  {
    protected void ValidateBaseResource(Resource oResource, IResourceValidationOperationOutcome oResourceValidationOperationOutcome)
    {
      if (string.IsNullOrWhiteSpace(oResource.Id) || !Id.IsValidValue(oResource.Id))
      {        
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ID_INVALID", String.Format("Id {0} has an invalid character.", oResource.Id));
          OpOutComeIssueComp.Details.Text = String.Format("The id found in the Resource contains invalid characters. The allowed characters are any combination of upper or lower case ASCII letters ('A'..'Z', and 'a'..'z', numerals ('0'..'9'), '-' and '.', with a length limit of 64 characters. ");
        OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
          OpOutComeIssueComp.Location = new List<string>() { String.Format("Resource.id") };
          if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
            oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;       
      }
    } 
  }
}
