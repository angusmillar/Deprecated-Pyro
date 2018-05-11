using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Engine.Services.ResourceTrigger
{
  public interface IResourceTriggerService
  {
    TriggerServices.ITriggerOutcome Trigger(RestEnum.CrudOperationType CrudOperationType, ResourceTriggerService.TriggerRaisedType TriggerRaised, Resource Resource);
    TriggerServices.ITriggerOutcome Trigger(RestEnum.CrudOperationType CrudOperationType, ResourceTriggerService.TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType);
  }
}