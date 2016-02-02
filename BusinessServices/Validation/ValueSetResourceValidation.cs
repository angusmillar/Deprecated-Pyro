using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Dip.Interfaces;

namespace Blaze.Engine.Validation
{
  public class ValueSetResourceValidation : Interfaces.IResourceValidation
  {
    public IResourceValidationOperationOutcome Validate(Resource Resource)
    {
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();

      var oPatient = CastToPatientResource(Resource, oResourceValidationOperationOutcome);
      if (oPatient == null)
        return oResourceValidationOperationOutcome;

      //StartChecking the Patient Resource
      //if (oPatient.BirthDate != null)
      //{
      //  DateTime oDate;
      //  if (!DateTime.TryParse(oPatient.BirthDate, out oDate))
      //  {
      //    var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
      //    OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
      //    OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
      //    OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The Date value '{0}' is not in the correct format (Xml Date Format required)", oPatient.BirthDate));
      //    OpOutComeIssueComp.Details.Text = String.Format("Patient BirthDate was not able to be parsed to a FhirDate.");
      //    OpOutComeIssueComp.Diagnostics = String.Format("Patient BirthDate was not able to be parsed to a FhirDate. The value found was {0}. An example of a correctly formatted date would be: '<birthDate value=\"1973-09-30\">' for the 30th of September 1973.", oPatient.BirthDate);
      //    OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:Patient/f:birthDate") };
      //    if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
      //      oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
      //    oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
      //    oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      //  }
      //}

  
      return oResourceValidationOperationOutcome;
    }

    private static ValueSet CastToPatientResource(Resource Resource, IResourceValidationOperationOutcome oResourceValidationOperationOutcome)
    {
      if (Resource is ValueSet)
      {
        return Resource as ValueSet;
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", Resource.GetType().ToString()));
        OpOutComeIssueComp.Details.Text = String.Format("Internal server error: Unable to cast Resource to Patient Resource in validation method.");
        if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
          oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
        oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
        return null;
      }
    }

    private bool IsParsableDateTimeOffset(string value)
    {
      DateTimeOffset DateTime;
      if (DateTimeOffset.TryParse(value, out DateTime))
        return true;
      else
        return false;
    }

  }
}
