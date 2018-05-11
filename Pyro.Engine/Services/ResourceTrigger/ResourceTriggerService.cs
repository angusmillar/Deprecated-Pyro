using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Pyro.Engine.TriggerServices;
using Pyro.Engine.Services.ResourceTrigger;
using Pyro.Engine.TriggerServices.CompartmentDefinitionResource;

namespace Pyro.Engine.Services.ResourceTrigger
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

    public ResourceTriggerService(ITriggerCompartmentDefinition ITriggerCompartmentDefinition)
    {
      this.ITriggerCompartmentDefinition = ITriggerCompartmentDefinition;
    }

    public enum TriggerRaisedType { BeforeCommit, AfterCommit }
    /// <summary>
    /// Primarily used for Delete actions as their is no Resource given in the API call
    /// However services can scource the resource being deleted from the database
    /// </summary>
    /// <param name="CrudOperationType"></param>
    /// <param name="ResourceId"></param>
    /// <param name="ResourceType"></param>
    public ITriggerOutcome Trigger(RestEnum.CrudOperationType CrudOperationType, TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType)
    {
      return ProcessTrigger(CrudOperationType, TriggerRaised, ResourceId, ResourceType);
    }

    /// <summary>
    /// Primarily used for Create & Update actions where a Resource is given in the API call
    /// Previous resource version can be sccourced from the database by version if required
    /// </summary>
    /// <param name="CrudOperationType"></param>
    /// <param name="Resource"></param>
    public ITriggerOutcome Trigger(RestEnum.CrudOperationType CrudOperationType, TriggerRaisedType TriggerRaised, Resource Resource)
    {
      return ProcessTrigger(CrudOperationType, TriggerRaised, Resource.Id, ResourceNameResolutionSupport.GetResourceFhirAllType(Resource.ResourceType), Resource);
    }

    private ITriggerOutcome ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null)
    {
      switch (ResourceType)
      {
        case FHIRAllTypes.CompartmentDefinition:
          return ITriggerCompartmentDefinition.ProcessTrigger(CrudOperationType, TriggerRaised, ResourceId, ResourceType, Resource);
        default:
          //Return Contiune if no trigger processing required.
          return new TriggerOutcome() { TriggerOutcomeResult = TriggerOutcome.TriggerOutcomeType.Contiune };
      }
    }

  }
}
