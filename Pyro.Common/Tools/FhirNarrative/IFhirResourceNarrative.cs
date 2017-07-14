using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.FhirNarrative
{
  public interface IFhirResourceNarrative
  {
    void CreateNarrative(OperationOutcome value);
  }
}