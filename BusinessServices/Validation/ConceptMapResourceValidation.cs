using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Dip.Interfaces;

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
                    if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                        oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                    oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
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
                if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                    oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }


            //FHIR Spec DSTU 2.1 : vsd-1: On ConceptMap.compose: A value set composition SHALL have an include or an import 
            //(xpath on f:ConceptMap/f:compose: exists(f:include) or exists(f:import))
            if (oConceptMap.Compose != null)
            {
                if (oConceptMap.Compose.Include == null && oConceptMap.Compose.Import == null)
                {
                    string PropertyName = "Compose";
                    var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                    OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                    OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                    OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                    OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} SHALL have an include or an import. Not both or neither.", oConceptMap.TypeName, PropertyName);
                    OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                    OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oConceptMap.TypeName, PropertyName) };
                    if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                        oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                    oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                    oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }

            //FHIR Spec DSTU 2.1 : vsd-10: On ConceptMap.expansion.contains: Must have a system if a code is present 
            //(xpath on f:ConceptMap/f:expansion/f:contains: exists(f:system) or not(exists(f:code)))
            if (oConceptMap.Expansion != null)
            {
                if (oConceptMap.Expansion.Contains != null)
                {
                    int counter = 0;
                    foreach (var Contains in oConceptMap.Expansion.Contains)
                    {
                        if (!String.IsNullOrWhiteSpace(Contains.Code) && String.IsNullOrWhiteSpace(Contains.System))
                        {
                            string PropertyName = ".expansion.contains";
                            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                            OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: Must have a system if a code is present", oConceptMap.TypeName, PropertyName);
                            OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                            OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ConceptMap/f:expansion/f:contains[{0}]", counter.ToString()) };
                            if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                                oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                            oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                            oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        counter++;
                    }
                }
            }
            //FHIR Spec DSTU 2.1 : vsd-11: On ConceptMap.compose.include: Cannot have both concept and filter 
            //(xpath on f:ConceptMap/f:compose/f:include: not(exists(f:concept)) or not(exists(f:filter)))
            if (oConceptMap.Compose != null)
            {
                if (oConceptMap.Compose.Include != null)
                {
                    int counter = 0;
                    foreach (var Include in oConceptMap.Compose.Include)
                    {
                        if ((Include.Concept != null && Include.Concept.Count() > 0) && (Include.Filter != null && Include.Filter.Count() > 0))
                        {
                            string PropertyName = ".compose.include";
                            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                            OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: Cannot have both concept and filter", oConceptMap.TypeName, PropertyName);
                            OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                            OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ConceptMap/f:compose/f:include[{0}]", counter.ToString()) };
                            if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                                oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                            oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                            oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        counter++;
                    }
                }
            }

            //FHIR Spec DSTU 2.1 : vsd-2: A value set with only one import SHALL also have an include and/or an exclude unless the value set includes and inline code system 
            //(xpath: not(exists(f:compose)) or (count(f:compose/f:import)!=1 or exists(f:compose/f:include) or exists(f:compose/f:exclude) or exists(f:codeSystem)))
            if (oConceptMap.Compose != null && oConceptMap.Compose.Import != null && oConceptMap.Compose.Import.Count() == 1)
            {
                if (oConceptMap.CodeSystem == null || String.IsNullOrWhiteSpace(oConceptMap.CodeSystem.System))
                {
                    if (oConceptMap.Compose.Include == null || oConceptMap.Compose.Include.Count() == 0)
                    {
                        if (oConceptMap.Compose.Exclude == null || oConceptMap.Compose.Exclude.Count() == 0)
                        {
                            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                            OpOutComeIssueComp.Details.Text = String.Format("A {0} with only one import SHALL also have an include and/or an exclude unless the value set includes and inline code system.", oConceptMap.TypeName);
                            OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                            OpOutComeIssueComp.Location = new List<string>()
              { String.Format("not(exists(f:compose)) or (count(f:compose/f:import)!=1 or exists(f:compose/f:include) or exists(f:compose/f:exclude) or exists(f:codeSystem)))")};
                            if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                                oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                            oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                            oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                    }
                }
            }

            //ToDo: How is this requirement any different to vsd-8 below?
            //FHIR Spec DSTU 2.1 : vsd-3: On ConceptMap.codeSystem: Within a code system definition, all the codes SHALL be unique 
            //(xpath on f:ConceptMap/f:codeSystem: count(distinct-values(descendant::f:concept/f:code/@value))=count(descendant::f:concept))
            if (oConceptMap.CodeSystem != null && oConceptMap.CodeSystem.Concept != null && oConceptMap.CodeSystem.Concept.Count() > 0)
            {
                string ErrorMessage = "The following codes have duplicate entries for the same CodeSystem: ( ";
                if (oConceptMap.CodeSystem.Concept.Select(x => x.Code).Distinct().Count() != oConceptMap.CodeSystem.Concept.Count())
                {
                    var Hash = new HashSet<string>();
                    foreach (var Code in oConceptMap.CodeSystem.Concept)
                    {
                        if (Hash.Contains(Code.Code))
                        {
                            ErrorMessage = ErrorMessage + Code.Code + ",";
                        }
                        else
                        {
                            Hash.Add(Code.Code);
                        }
                    }
                    ErrorMessage = ErrorMessage.Substring(0, ErrorMessage.Length - 1) + " )";

                    string PropertyName = ".codeSystem";
                    var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                    OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                    OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                    OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                    OpOutComeIssueComp.Details.Text = String.Format("On {0}{1}: Within a code system definition, all the codes SHALL be unique.", oConceptMap.TypeName, PropertyName);
                    OpOutComeIssueComp.Diagnostics = ErrorMessage;
                    OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ConceptMap/f:codeSystem: count(distinct-values(descendant::f:concept/f:code/@value))=count(descendant::f:concept))") };
                    if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                        oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                    oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                    oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }

            //FHIR Spec DSTU 2.1 : vsd-5: Value set SHALL contain at least one of a codeSystem, a compose, or an expansion element 
            //(xpath: exists(f:codeSystem) or exists(f:compose) or exists(f:expansion))      
            if (oConceptMap.CodeSystem == null && oConceptMap.Compose == null && oConceptMap.Compose == null)
            {
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                OpOutComeIssueComp.Details.Text = String.Format("{0} SHALL contain at least one of a codeSystem, a compose, or an expansion element ", oConceptMap.TypeName);
                OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                OpOutComeIssueComp.Location = new List<string>() { String.Format("exists(f:codeSystem) or exists(f:compose) or exists(f:expansion)") };
                if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                    oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            //FHIR Spec DSTU 2.1 : vsd-6: On ConceptMap.expansion.contains: SHALL have a code or a display 
            //(xpath on f:ConceptMap/f:expansion/f:contains: exists(f:code) or exists(f:display))
            if (oConceptMap.Expansion != null)
            {
                if (oConceptMap.Expansion.Contains != null)
                {
                    int counter = 0;
                    foreach (var Contains in oConceptMap.Expansion.Contains)
                    {
                        if (String.IsNullOrWhiteSpace(Contains.Code) || String.IsNullOrWhiteSpace(Contains.Display))
                        {
                            string PropertyName = ".expansion.contains";
                            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                            OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: SHALL have a code or a display", oConceptMap.TypeName, PropertyName);
                            OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                            OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ConceptMap/f:expansion/f:contains[{0}]: exists(f:code) or exists(f:display)", counter.ToString()) };
                            if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                                oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                            oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                            oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        counter++;
                    }
                }
            }

            //FHIR Spec DSTU 2.1 : vsd-7: A defined code system (if present) SHALL have a different url than the value set url 
            //(xpath: not(f:codeSystem/f:system/@value = f:url/@value))
            if (oConceptMap.CodeSystem != null && oConceptMap.CodeSystem.System == oConceptMap.Url)
            {
                var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                OpOutComeIssueComp.Details.Text = String.Format("A {0}'s defined code system (if present) SHALL have a different url than the value set url", oConceptMap.TypeName);
                OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                OpOutComeIssueComp.Location = new List<string>() { String.Format("not(f:codeSystem/f:system/@value = f:url/@value)") };
                if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                    oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            //ToDo: How is this requirement any different to vsd-3 above?
            //FHIR Spec DSTU 2.1 : vsd-8: On ConceptMap.codeSystem: Codes must be unique 
            //(xpath on f:ConceptMap/f:codeSystem: count(descendant::f:concept)=count(distinct-values(descendant::f:concept/f:code/@value)))


            //FHIR Spec DSTU 2.1 : vsd-9: On ConceptMap.expansion.contains: Must have a code if not abstract 
            //(xpath on f:ConceptMap/f:expansion/f:contains: exists(f:code) or (f:abstract/@value = true()))

            if (oConceptMap.Expansion != null && oConceptMap.Expansion.Contains != null)
            {
                foreach (var Contains in oConceptMap.Expansion.Contains)
                {
                    if ((Contains.Abstract == null && Contains.Abstract == false) && String.IsNullOrWhiteSpace(Contains.Code))
                    {
                        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
                        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
                        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
                        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oConceptMap.TypeName));
                        OpOutComeIssueComp.Details.Text = String.Format("On {0} ConceptMap.expansion.contains: Must have a code if not abstract ", oConceptMap.TypeName);
                        OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
                        OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ConceptMap/f:expansion/f:contains: exists(f:code) or (f:abstract/@value = true())") };
                        if (oResourceValidationOperationOutcome.FhieOperationOutcome == null)
                            oResourceValidationOperationOutcome.FhieOperationOutcome = new OperationOutcome();
                        oResourceValidationOperationOutcome.FhieOperationOutcome.Issue.Add(OpOutComeIssueComp);
                        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
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
