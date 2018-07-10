using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Service.Trigger.TriggerServices;

namespace Pyro.Common.Service.Trigger
{
  /// <summary>
  /// This class manages any work that is required post a resource being commited or deleted from the database.
  /// For example, CompatmentDefinition resource commits and deletes require the _ServiceCompartment & ServiceCompartmentResource
  /// tables to be updated. This class does not hold that logic but rather manages which services need to run or not run
  /// based on a resource trigger (Create, Update, Delete)
  /// Note: 
  /// This service is triggered post the resource being commited to the db context but before the 
  /// end of the transaction for Create and Update.
  /// For Delete it is tiggered just before the delete action on the db context, so any service can get the 
  /// resource from the database to perform an action before it is deleted. Also deletes do not provide the Resource, you must go get it.
  /// Note:
  /// There are no triggers raised for Reads. This could be extended to support reads easily but there is no use
  /// case for this as yet.
  /// 
  /// </summary>
  public class ResourceTriggerService : IResourceTriggerService
  {
    private readonly ITriggerCompartmentDefinition ITriggerCompartmentDefinition;

    private bool _TriggersActive;

    public bool TriggersActive
    {
      get { return _TriggersActive; }
      set { _TriggersActive = value; }
    }

    public ResourceTriggerService(ITriggerCompartmentDefinition ITriggerCompartmentDefinition)
    {
      this.ITriggerCompartmentDefinition = ITriggerCompartmentDefinition;
      _TriggersActive = true;
    }

    public ITriggerInput TriggerInputFactory()
    {
      return new TriggerInput() { CrudOperationType = RestEnum.CrudOperationType.None };
    }

    public ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput)
    {
      //If triggers are not active then just return Report as False
      if (!_TriggersActive)
        return new TriggerOutcome() { Report = false };

      //Validate TriggerInput
      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.None)
        throw new System.NullReferenceException("TriggerInput.CrudOperationType cannot be None");

      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Create || 
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update)
      {
        if (TriggerInput.InboundResource == null)
          throw new System.NullReferenceException("TriggerInput.InboundResource cannot be null");               
      }

      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Create || 
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update ||
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete)
      {
        if (string.IsNullOrWhiteSpace(TriggerInput.InboundResourceId))
          throw new System.NullReferenceException("TriggerInput.InboundResourceId cannot be null or empty");
        if (TriggerInput.ResourceType == ResourceType.Resource)
          throw new System.NullReferenceException("TriggerInput.ResourceType cannot be equal to 'Resource'");
      }

      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update || 
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete)
      {
        if (TriggerInput.DbTokenIndexList == null)
          throw new System.NullReferenceException("TriggerInput.DbTokenIndexList cannot be null for Update or Delete actions");
      }


      switch (TriggerInput.ResourceType)
      {
        case ResourceType.CompartmentDefinition:
          return ITriggerCompartmentDefinition.ProcessTrigger(TriggerInput);
        default:
          //Return Contiune if no trigger processing required.
          return new TriggerOutcome() { Report = false };
      }
    }

    
  }
}
