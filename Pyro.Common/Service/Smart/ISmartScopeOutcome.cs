using Hl7.Fhir.Model;

namespace Pyro.Common.Service.Smart
{
  public interface ISmartScopeOutcome
  {
    OperationOutcome OperationOutcome { get; set; }
    bool ScopesOK { get; set; }
  }
}