using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Engine.Services
{
  public interface IResourceTriggerService
  {
    void Trigger(RestEnum.CrudOperationType CrudOperationType, Resource Resource);
    void Trigger(RestEnum.CrudOperationType CrudOperationType, string ResourceId, FHIRAllTypes ResourceType);
  }
}