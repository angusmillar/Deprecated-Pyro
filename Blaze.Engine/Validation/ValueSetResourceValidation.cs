using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
  public class ValueSetResourceValidation : Interfaces.IResourceValidation
  {
    public IResourceValidationOperationOutcome Validate(Resource Resource)
    {
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();

      var oValueSet = CastToPatientResource(Resource, oResourceValidationOperationOutcome);
      if (oValueSet == null)
        return oResourceValidationOperationOutcome;

      //StartChecking the ValueSet Resource
      if (oValueSet.Date != null)
      {
        DateTime oDate;
        if (!DateTime.TryParse(oValueSet.Date, out oDate))
        {
          string PropertyName = "date";
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_DATE_FORMAT", String.Format("The {0} value '{1}' is not in the correct format (Xml Date Format required)", PropertyName, oValueSet.Date));
          OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} was not able to be parsed to a FhirDate.", oValueSet.TypeName, PropertyName);
          OpOutComeIssueComp.Diagnostics = String.Format("{0} {1} was not able to be parsed to a FhirDate. The value found was {2}. An example of a correctly formatted date would be: '<birthDate value=\"1973-09-30\">' for the 30th of September 1973.", oValueSet.TypeName, PropertyName, oValueSet.Date);
          OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oValueSet.TypeName, PropertyName) };
          if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
            oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
      }

      if (oValueSet.Status == null)
      {       
        string PropertyName = "status";
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_CONTENT", String.Format("Unknown Content (empty) at {0}", PropertyName));
        OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} was not found. All {0} resources must have a populated {1} property.", oValueSet.TypeName, PropertyName);
        OpOutComeIssueComp.Diagnostics = String.Format("{0}'s {1} was not found. All {0} resources must have a populated {1} property.", oValueSet.TypeName, PropertyName);
        OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oValueSet.TypeName, PropertyName) };
        if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
          oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
        oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;       
      }

     
      //FHIR Spec DSTU 2.1 : vsd-1: On ValueSet.compose: A value set composition SHALL have an include or an import 
      //(xpath on f:ValueSet/f:compose: exists(f:include) or exists(f:import))
      if (oValueSet.Compose != null)        
      {
       if (oValueSet.Compose.Include == null && oValueSet.Compose.Import == null)
       {
         string PropertyName = "Compose";
         var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
         OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
         OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
         OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
         OpOutComeIssueComp.Details.Text = String.Format("{0}'s {1} SHALL have an include or an import. Not both or neither.", oValueSet.TypeName, PropertyName);
         OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
         OpOutComeIssueComp.Location = new List<string>() { String.Format("/f:{0}/f:{1}", oValueSet.TypeName, PropertyName) };
         if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
           oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
         oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
         oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;   
       }
      }

      //FHIR Spec DSTU 2.1 : vsd-10: On ValueSet.expansion.contains: Must have a system if a code is present 
      //(xpath on f:ValueSet/f:expansion/f:contains: exists(f:system) or not(exists(f:code)))
      if (oValueSet.Expansion != null)
      {
        if (oValueSet.Expansion.Contains != null)
        {
          int counter = 0;
          foreach(var Contains in oValueSet.Expansion.Contains)
          {
            if (!String.IsNullOrWhiteSpace(Contains.Code) && String.IsNullOrWhiteSpace(Contains.System))
            {
              string PropertyName = ".expansion.contains";
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
              OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: Must have a system if a code is present", oValueSet.TypeName, PropertyName);
              OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
              OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ValueSet/f:expansion/f:contains[{0}]", counter.ToString()) };
              if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;   
            }
            counter++;
          }
        }
      }
      //FHIR Spec DSTU 2.1 : vsd-11: On ValueSet.compose.include: Cannot have both concept and filter 
      //(xpath on f:ValueSet/f:compose/f:include: not(exists(f:concept)) or not(exists(f:filter)))
      if (oValueSet.Compose != null)
      {
        if (oValueSet.Compose.Include != null)
        {
          int counter = 0;
          foreach(var Include in oValueSet.Compose.Include)
          {
            if ((Include.Concept != null && Include.Concept.Count() > 0) && (Include.Filter != null && Include.Filter.Count() > 0))
            {
              string PropertyName = ".compose.include";
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
              OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: Cannot have both concept and filter", oValueSet.TypeName, PropertyName);
              OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
              OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ValueSet/f:compose/f:include[{0}]", counter.ToString()) };
              if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
            }
            counter++;
          }
        }
      }

      //FHIR Spec DSTU 2.1 : vsd-2: A value set with only one import SHALL also have an include and/or an exclude unless the value set includes and inline code system 
      //(xpath: not(exists(f:compose)) or (count(f:compose/f:import)!=1 or exists(f:compose/f:include) or exists(f:compose/f:exclude) or exists(f:codeSystem)))
      if (oValueSet.Compose != null && oValueSet.Compose.Import != null && oValueSet.Compose.Import.Count() == 1)
      {
        if (oValueSet.CodeSystem == null || String.IsNullOrWhiteSpace(oValueSet.CodeSystem.System))
        {
          if (oValueSet.Compose.Include == null || oValueSet.Compose.Include.Count() == 0)
          {
            if (oValueSet.Compose.Exclude == null || oValueSet.Compose.Exclude.Count() == 0)
            {              
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
              OpOutComeIssueComp.Details.Text = String.Format("A {0} with only one import SHALL also have an include and/or an exclude unless the value set includes and inline code system.", oValueSet.TypeName);
              OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
              OpOutComeIssueComp.Location = new List<string>() 
              { String.Format("not(exists(f:compose)) or (count(f:compose/f:import)!=1 or exists(f:compose/f:include) or exists(f:compose/f:exclude) or exists(f:codeSystem)))")};
              if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
            }
          }
        }        
      }

      //ToDo: How is this requirement any different to vsd-8 below?
      //FHIR Spec DSTU 2.1 : vsd-3: On ValueSet.codeSystem: Within a code system definition, all the codes SHALL be unique 
      //(xpath on f:ValueSet/f:codeSystem: count(distinct-values(descendant::f:concept/f:code/@value))=count(descendant::f:concept))
      if (oValueSet.CodeSystem != null && oValueSet.CodeSystem.Concept != null && oValueSet.CodeSystem.Concept.Count() > 0)
      {
        string ErrorMessage = "The following codes have duplicate entries for the same CodeSystem: ( ";
        if (oValueSet.CodeSystem.Concept.Select(x => x.Code).Distinct().Count() != oValueSet.CodeSystem.Concept.Count())
        {
          var Hash = new HashSet<string>();
          foreach(var Code in oValueSet.CodeSystem.Concept)
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
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
          OpOutComeIssueComp.Details.Text = String.Format("On {0}{1}: Within a code system definition, all the codes SHALL be unique.", oValueSet.TypeName, PropertyName);
          OpOutComeIssueComp.Diagnostics = ErrorMessage;
          OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ValueSet/f:codeSystem: count(distinct-values(descendant::f:concept/f:code/@value))=count(descendant::f:concept))") };
          if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
            oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
        }
      }

      //FHIR Spec DSTU 2.1 : vsd-5: Value set SHALL contain at least one of a codeSystem, a compose, or an expansion element 
      //(xpath: exists(f:codeSystem) or exists(f:compose) or exists(f:expansion))      
      if (oValueSet.CodeSystem == null && oValueSet.Compose == null && oValueSet.Compose == null)
      {        
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
        OpOutComeIssueComp.Details.Text = String.Format("{0} SHALL contain at least one of a codeSystem, a compose, or an expansion element ", oValueSet.TypeName);
        OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
        OpOutComeIssueComp.Location = new List<string>() { String.Format("exists(f:codeSystem) or exists(f:compose) or exists(f:expansion)") };
        if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
          oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
        oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
      }

      //FHIR Spec DSTU 2.1 : vsd-6: On ValueSet.expansion.contains: SHALL have a code or a display 
      //(xpath on f:ValueSet/f:expansion/f:contains: exists(f:code) or exists(f:display))
      if (oValueSet.Expansion != null)
      {
        if (oValueSet.Expansion.Contains != null)
        {
          int counter = 0;
          foreach (var Contains in oValueSet.Expansion.Contains)
          {
            if (String.IsNullOrWhiteSpace(Contains.Code) || String.IsNullOrWhiteSpace(Contains.Display))
            {
              string PropertyName = ".expansion.contains";
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
              OpOutComeIssueComp.Details.Text = String.Format("{0}{1}: SHALL have a code or a display", oValueSet.TypeName, PropertyName);
              OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
              OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ValueSet/f:expansion/f:contains[{0}]: exists(f:code) or exists(f:display)", counter.ToString()) };
              if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
                oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
            }
            counter++;
          }
        }
      }

      //FHIR Spec DSTU 2.1 : vsd-7: A defined code system (if present) SHALL have a different url than the value set url 
      //(xpath: not(f:codeSystem/f:system/@value = f:url/@value))
      if (oValueSet.CodeSystem != null && oValueSet.CodeSystem.System == oValueSet.Url)
      {        
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
        OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
        OpOutComeIssueComp.Details.Text = String.Format("A {0}'s defined code system (if present) SHALL have a different url than the value set url", oValueSet.TypeName);
        OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
        OpOutComeIssueComp.Location = new List<string>() { String.Format("not(f:codeSystem/f:system/@value = f:url/@value)") };
        if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
          oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
        oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
        oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
      }

      //ToDo: How is this requirement any different to vsd-3 above?
      //FHIR Spec DSTU 2.1 : vsd-8: On ValueSet.codeSystem: Codes must be unique 
      //(xpath on f:ValueSet/f:codeSystem: count(descendant::f:concept)=count(distinct-values(descendant::f:concept/f:code/@value)))


      //FHIR Spec DSTU 2.1 : vsd-9: On ValueSet.expansion.contains: Must have a code if not abstract 
      //(xpath on f:ValueSet/f:expansion/f:contains: exists(f:code) or (f:abstract/@value = true()))

      if (oValueSet.Expansion != null && oValueSet.Expansion.Contains != null)
      {
        foreach(var Contains in oValueSet.Expansion.Contains)
        {
          if ((Contains.Abstract == null && Contains.Abstract == false) && String.IsNullOrWhiteSpace(Contains.Code))
          {
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Value;
            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_ERROR_PARSING", String.Format("Error parsing resource Xml ({0})", oValueSet.TypeName));
            OpOutComeIssueComp.Details.Text = String.Format("On {0} ValueSet.expansion.contains: Must have a code if not abstract ", oValueSet.TypeName);
            OpOutComeIssueComp.Diagnostics = OpOutComeIssueComp.Details.Text;
            OpOutComeIssueComp.Location = new List<string>() { String.Format("f:ValueSet/f:expansion/f:contains: exists(f:code) or (f:abstract/@value = true())") };
            if (oResourceValidationOperationOutcome.FhirOperationOutcome == null)
              oResourceValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
            oResourceValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
            oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;  
          }
        }
      }


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
