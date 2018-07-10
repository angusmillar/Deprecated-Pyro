namespace Pyro.Common.Service.Trigger.TriggerServices
{
  public interface ITriggerProtectedResource : ITriggerService
  {
    ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput);
  }
}