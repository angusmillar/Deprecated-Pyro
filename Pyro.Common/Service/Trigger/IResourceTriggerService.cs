namespace Pyro.Common.Service.Trigger
{
  public interface IResourceTriggerService
  {
    bool TriggersActive { get; set; }
    ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput);
    ITriggerInput TriggerInputFactory();
  }
}