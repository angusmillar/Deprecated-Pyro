using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
  public class PatientResourceValidation : BaseResourceValidation, Interfaces.IResourceValidation
  {   
    public IResourceValidationOperationOutcome Validate(Resource Resource)
    {
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();
      this.ValidateBaseResource(Resource, oResourceValidationOperationOutcome);
      var oPatient = CastToPatientResource(Resource, oResourceValidationOperationOutcome);
      if (oPatient == null)
        return oResourceValidationOperationOutcome;

      //StartChecking the Patient Resource
      if (oPatient.BirthDate != null)
      {        
        if (!Date.IsValidValue(oPatient.BirthDateElement.Value))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;          
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The Date value '{0}' is not in the correct format (Xml Date Format required)", oPatient.BirthDate));
          OpOutComeIssueComp.Details.Text = String.Format("Patient BirthDate was not able to be parsed to a FhirDate.");
          OpOutComeIssueComp.Diagnostics = String.Format("Patient BirthDate was not able to be parsed to a FhirDate. The value found was {0}. An example of a correctly formatted date would be: '<birthDate value=\"1973-09-30\">' for the 30th of September 1973.", oPatient.BirthDate);
          OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:Patient/f:birthDate") };
          if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
            oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          
        }
      }

      if (oPatient.Name != null)
      {
        for (int i = 0; i < oPatient.Name.Count; i++)        
        {
          if (oPatient.Name[i].Period != null)
          {
            if (!String.IsNullOrWhiteSpace(oPatient.Name[i].Period.Start))
            {
              if (!IsParsableDateTimeOffset(oPatient.Name[i].Period.Start))
              {
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The Date value '{0}' is not in the correct format (Xml Date Format required)", oPatient.Name[i].Period.Start));
                OpOutComeIssueComp.Details.Text = String.Format("Patient's Name Period Start date was not able to be parsed to a FhirDateTime.");
                OpOutComeIssueComp.Diagnostics = String.Format("Patient's Name Period Start was not able to be parsed to a FhirDateTime. The value found was {0}. An example of a correctly formatted date would be: '<start value=\"2015-02-14T13:55:00+10:00\"/>'", oPatient.Name[i].Period.Start);
                OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:Patient/f:name[{0}]/f:period/f:start", i.ToString()) };
                if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                  oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          

              }
            }
            if (!String.IsNullOrWhiteSpace(oPatient.Name[i].Period.End))
            {
              if (!IsParsableDateTimeOffset(oPatient.Name[i].Period.End))
              {
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The Date value '{0}' is not in the correct format (Xml Date Format required)", oPatient.Name[i].Period.End));
                OpOutComeIssueComp.Details.Text = String.Format("Patient's Name Period End date was not able to be parsed to a FhirDateTime.");
                OpOutComeIssueComp.Diagnostics = String.Format("Patient's Name Period End was not able to be parsed to a FhirDateTime. The value found was {0}. An example of a correctly formatted date would be: '<end value=\"2015-02-14T13:55:00+10:00\"/>'", oPatient.Name[i].Period.End);
                OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:Patient/f:name[{0}]/f:period/f:end", i.ToString()) };
                if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                  oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          
              }
            }
            if (!String.IsNullOrWhiteSpace(oPatient.Name[i].Period.Start) && !String.IsNullOrWhiteSpace(oPatient.Name[i].Period.End))
            {
              DateTimeOffset StartDate;
              DateTimeOffset EndDate;
              if (DateTimeOffset.TryParse(oPatient.Name[i].Period.Start, out StartDate) && DateTimeOffset.TryParse(oPatient.Name[i].Period.End, out EndDate))
              {
                if (StartDate > EndDate)
                {
                  var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                  OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
                  OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                  OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", "Patient"));
                  OpOutComeIssueComp.Details.Text = String.Format("One of the Patient's Name Period element has a 'start' that is after the 'end'.");
                  OpOutComeIssueComp.Diagnostics = String.Format("Patient's Name Period 'start' date is after the 'end' date. Start date was: {0} and end date was: {1}.", oPatient.Name[i].Period.Start, oPatient.Name[i].Period.End);
                  OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:Patient/f:name[{0}]/f:period/f:start", i.ToString()), String.Format("/f:Patient/f:name[{0}]/f:period/f:end", i.ToString()) };
                  if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                    oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
                  oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
                  oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          
                }
              }
            }
          }
        }
      }
      return oResourceValidationOperationOutcome;
    }

    private static Patient CastToPatientResource(Resource Resource, IResourceValidationOperationOutcome oResourceValidationOperationOutcome)
    {      
      if (Resource is Patient)
      {
        return Resource as Patient;
      }
      else
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;        
        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", Resource.GetType().ToString()));
        OpOutComeIssueComp.Details.Text = String.Format("Internal server error: Unable to cast Resource to Patient Resource in validation method.");
        if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
          oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
        oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
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
