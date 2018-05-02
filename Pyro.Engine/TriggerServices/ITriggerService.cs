using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using static Pyro.Engine.Services.ResourceTriggerService;

namespace Pyro.Engine.TriggerServices
{
  public interface ITriggerService
  {
    ITriggerOutcome ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null);
  }
}