using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Service.Trigger.TriggerServices;
using System.Collections.Generic;
using System.Linq;

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
    //private readonly ITriggerCompartmentDefinition ITriggerCompartmentDefinition;
    //private readonly ITriggerProtectedResource ITriggerProtectedResource;
    //private readonly ITriggerServerReadOnlyMode ITriggerServerReadOnlyMode;
    private readonly List<ITriggerService> ITriggerServiceList;

    private bool _TriggersActive;

    public bool TriggersActive
    {
      get { return _TriggersActive; }
      set { _TriggersActive = value; }
    }

    public ResourceTriggerService(ITriggerCompartmentDefinition ITriggerCompartmentDefinition, ITriggerProtectedResource ITriggerProtectedResource, ITriggerServerReadOnlyMode ITriggerServerReadOnlyMode)
    {
      //this.ITriggerCompartmentDefinition = ITriggerCompartmentDefinition;
      //this.ITriggerProtectedResource = ITriggerProtectedResource;
      //this.ITriggerServerReadOnlyMode = ITriggerServerReadOnlyMode;
      ITriggerServiceList = new List<ITriggerService>();
      ITriggerServiceList.Add(ITriggerCompartmentDefinition);
      ITriggerServiceList.Add(ITriggerProtectedResource);
      ITriggerServiceList.Add(ITriggerServerReadOnlyMode);

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

      ITriggerOutcome TriggerOutcomeMain = null;

      //Resource Specific
      var ResourceSpecificList = ITriggerServiceList.Where(x => x.ResourceTypeToTriggerFor == TriggerInput.ResourceType);      
      foreach (var TriggerService in ResourceSpecificList)
      {
        TriggerOutcomeMain = CollateOutcomes(TriggerOutcomeMain, TriggerService.ProcessTrigger(TriggerInput));        
      }

      //All Resource Types
      ResourceSpecificList = ITriggerServiceList.Where(x => x.ResourceTypeToTriggerFor == ResourceType.Resource);
      foreach (var TriggerService in ResourceSpecificList)
      {
        TriggerOutcomeMain = CollateOutcomes(TriggerOutcomeMain, TriggerService.ProcessTrigger(TriggerInput));        
      }
      
      return TriggerOutcomeMain;
    }
    
    private ITriggerOutcome CollateOutcomes(ITriggerOutcome TriggerOutcomeMain, ITriggerOutcome TriggerOutcomeNew)
    {
      if (TriggerOutcomeMain == null)
      {
        return TriggerOutcomeNew;
      }
      else
      {
        if (!TriggerOutcomeMain.Report && TriggerOutcomeNew.Report)
        {
          //The main does not need to report but the new one does so just return the new one
          return TriggerOutcomeNew;
        }
        else if (TriggerOutcomeMain.Report && TriggerOutcomeNew.Report)
        {
          //Both Main and New need to report so collate the OperationOutcome Issue lists into a single OperationOutcome.
          if (TriggerOutcomeMain.Resource != null && TriggerOutcomeMain.Resource is OperationOutcome OptOutMain)
          {
            if (TriggerOutcomeNew.Resource != null && TriggerOutcomeNew.Resource is OperationOutcome OptOut)
            {
              OptOutMain.Issue.AddRange(OptOut.Issue);
              return TriggerOutcomeMain;
            }
          }
          throw new System.InvalidCastException("Internal Server Error: ITriggerOutcome Resource is not an OperationOutcome");
        }
        else if (TriggerOutcomeMain.Report && !TriggerOutcomeNew.Report)
        {
          //The new does not need to report but the Main does so return only the Main
          return TriggerOutcomeMain;
        }
        else
        {
          //Both do not need to report so just return the New as it will not be null;
          return TriggerOutcomeNew;
        }
      }
    }
  }
}
