using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class ResourceNameResolutionSupport
  {
    public static FHIRAllTypes GetResourceFhirAllType(ResourceType ResourceType)
    {
      return ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceType.GetLiteral());
    }
    public static FHIRAllTypes GetResourceFhirAllType(string ResourceName)
    {
      Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);
      if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
      {
        return (FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName);
      }
      else
      {
        string ErrorMessage = string.Empty;
        if (ResourceName.ToLower() == "_history")
        {
          ErrorMessage = $"This server has not implemented the Whole System Interaction of history. Instance level history is implemented, for example '[base]/Patient/1/_history'";
        }
        else if (ResourceName.ToLower() == "conformance")
        {
          ErrorMessage = $"The Resource name given '{ResourceName}' is not a Resource supported by the .net FHIR API Version: {ModelInfo.Version}. Perhaps you wish to find the server's conformance statement Resource named 'CapabilityStatement' which can be obtained from the endpoint '[base]/metadata' ";
        }
        else
        {
          ResourceType = ModelInfo.GetTypeForFhirType(StringSupport.UppercaseFirst(ResourceName));
          if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
          {
            ErrorMessage = $"The Resource name given '{ResourceName}' must begin with a capital letter, e.g ({StringSupport.UppercaseFirst(ResourceName)})";
          }
          else
          {
            ErrorMessage = $"The Resource name given '{ResourceName}' is not a Resource supported by the .net FHIR API Version: {ModelInfo.Version}.";
          }
        }
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, ErrorMessage);
        OpOutCome.Issue[0].Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
        throw new PyroException(HttpStatusCode.BadRequest, OpOutCome, ErrorMessage);
      }
    }
  }
}
