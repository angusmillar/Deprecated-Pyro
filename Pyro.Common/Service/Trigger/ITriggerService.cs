namespace Pyro.Common.Service.Trigger
{
  public interface ITriggerService
  {
    /// <summary>
    /// The Trigger Service runs for all Resource actions to check if the action should perfom or to modifiy 
    /// resources where required.
    /// </summary>
    /// <param name="TriggerInput"></param>
    /// <returns></returns>
    ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput);
  }
}