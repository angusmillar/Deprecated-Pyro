using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Engine.TriggerServices
{
  public interface ITriggerService
  {
    void ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null);
  }
}