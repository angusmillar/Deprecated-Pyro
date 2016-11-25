using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Validation
{
  public class BaseResourceValidation
  {
    protected void ValidateBaseResource(Resource oResource, IResourceValidationOperationOutcome oResourceValidationOperationOutcome)
    {
      if (string.IsNullOrWhiteSpace(oResource.Id) || !Id.IsValidValue(oResource.Id))
      {
        string Message = string.Format("The id found in the Resource contains invalid characters. The allowed characters are any combination of upper or lower case ASCII letters ('A'..'Z', and 'a'..'z', numerals ('0'..'9'), '-' and '.', with a length limit of 64 characters. ");
        OperationOutcome OpOutcome = Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Value, Message);
        OpOutcome.Issue[0].Details = new CodeableConcept();
        OpOutcome.Issue[0].Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ID_INVALID", String.Format("Id {0} has an invalid character.", oResource.Id));
        OpOutcome.Issue[0].Location = new List<string>() { String.Format("Resource.id") };
        if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
          oResourceValidationOperationOutcome.FhirOperationOutcome = OpOutcome;
        else
          oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutcome.Issue[0]);
        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      }
    }
  }
}
