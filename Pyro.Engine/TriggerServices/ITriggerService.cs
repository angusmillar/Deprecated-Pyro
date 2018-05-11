using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Engine.Services.ResourceTrigger;

namespace Pyro.Engine.TriggerServices
{
  public interface ITriggerService
  {
    ITriggerOutcome ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, ResourceTriggerService.TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null);
  }
}