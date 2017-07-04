using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public interface IFhirValidationSupport
  {
    OperationOutcome Validate(Resource ResourceToValidate, IEnumerable<StructureDefinition> StructureDefinitionList);
    OperationOutcome Validate(Resource ResourceToValidate, IList<string> StructureDefinitionUriList);
  }
}