using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
    public class ConceptMapResourceValidation : Interfaces.IResourceValidation
    {
        public IResourceValidationOperationOutcome Validate(Resource Resource)
        {
            IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();

            var oConceptMap = CastToConceptMapResource(Resource, oResourceValidationOperationOutcome);
            if (oConceptMap == null)
                return oResourceValidationOperationOutcome;

            //StartChecking the ConceptMap Resource
            if (oConceptMap.Date != null)
            {
                DateTime oDate;
                if (!DateTime.TryParse(oConceptMap.Date, out oDate))
                {
                    string PropertyName = "date";
                    var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                    OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                    OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                    OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The {0} value '{1}' is not in the correct format (Xml Date Format required)", PropertyName, oConceptMap.Date));
                    OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} was not able to be parsed to a FhirDate.", oConceptMap.TypeName, PropertyName);
                    OpOutComeIssueComp.Diagnostics = String.Format("{0} {1} was not able to be parsed to a FhirDate. The value found was {2}. An example of a correctly formatted date would be: '<birthDate value=\"1973-09-30\">' for the 30th of September 1973.", oConceptMap.TypeName, PropertyName, oConceptMap.Date);
                    OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oConceptMap.TypeName, PropertyName) };
                    if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                        oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
                    oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
                    oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }

            if (oConceptMap.Status == null)
            {
                string PropertyName = "status";
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_CONTENT", String.Format("Unknown Content (empty) at {0}", PropertyName));
                OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} was not found. All {0} resources must have a populated {1} property.", oConceptMap.TypeName, PropertyName);
                OpOutComeIssueComp.Diagnostics = String.Format("{0}'s {1} was not found. All {0} resources must have a populated {1} property.", oConceptMap.TypeName, PropertyName);
                OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oConceptMap.TypeName, PropertyName) };
                if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                    oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }


            
            return oResourceValidationOperationOutcome;
        }

        private static ConceptMap CastToConceptMapResource(Resource Resource, IResourceValidationOperationOutcome oResourceValidationOperationOutcome)
        {
            if (Resource is ConceptMap)
            {
                return Resource as ConceptMap;
            }
            else
            {
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", Resource.GetType().ToString()));
                OpOutComeIssueComp.Details.Text = String.Format("Internal server error: Unable to cast Resource to ConceptMap Resource in validation method.");
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
