using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.Validation
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
          var Location = new List<string>() { String.Format("/f:{0}/f:{1}", oConceptMap.TypeName, PropertyName) };
          string Message = string.Format("{0}'s {1} was not able to be parsed to a FhirDate.", oConceptMap.TypeName, PropertyName);
          oResourceValidationOperationOutcome.FhirOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Value, Message, Location, oResourceValidationOperationOutcome.FhirOperationOutcome);
          oResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
      }

      if (oConceptMap.Status == null)
      {
        string PropertyName = "status";
        var Location = new List<string>() { String.Format("/f:{0}/f:{1}", oConceptMap.TypeName, PropertyName) };
        string Message = string.Format("{0}'s {1} was not found. All {0} resources must have a populated {1} property.", oConceptMap.TypeName, PropertyName);
        oResourceValidationOperationOutcome.FhirOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Value, Message, Location, oResourceValidationOperationOutcome.FhirOperationOutcome);
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
        string Message = string.Format("Internal server error: Unable to cast Resource to ConceptMap Resource in validation method.");
        oResourceValidationOperationOutcome.FhirOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message, oResourceValidationOperationOutcome.FhirOperationOutcome);
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
