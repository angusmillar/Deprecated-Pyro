using Hl7.Fhir.Model;

namespace Pyro.Smart.Scopes
{
  public interface ISmartScope
  {
    SmartEnum.Action Action { get; }
    SmartEnum.Entity Entity { get; }
    FHIRAllTypes Resource { get; }
  }
}