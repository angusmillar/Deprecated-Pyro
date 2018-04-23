using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Tools;

namespace Pyro.Engine.Services
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
  /// resource from the database to perform an action before it is deleted.
  /// Note:
  /// There are no triggers raised for Reads. This could be extended to support reads easily but there is no use
  /// case for this as yet.
  /// 
  /// </summary>
  public class ResourceTriggerService : IResourceTriggerService
  {
    public ResourceTriggerService(){ }

    /// <summary>
    /// Primarily used for Delete actions as their is no Resource given in the API call
    /// However services can scource the resource being deletd from the database
    /// </summary>
    /// <param name="CrudOperationType"></param>
    /// <param name="ResourceId"></param>
    /// <param name="ResourceType"></param>
    public void Trigger(RestEnum.CrudOperationType CrudOperationType, string ResourceId, FHIRAllTypes ResourceType)
    {
      ProcessTrigger(CrudOperationType, ResourceId, ResourceType);
    }

    /// <summary>
    /// Primarily used for Create & Update actions where a Resource is given in the API call
    /// Previous resource version can be sccourced from the database by version if required
    /// </summary>
    /// <param name="CrudOperationType"></param>
    /// <param name="Resource"></param>
    public void Trigger(RestEnum.CrudOperationType CrudOperationType, Resource Resource)
    {      
      ProcessTrigger(CrudOperationType, Resource.Id, ResourceNameResolutionSupport.GetResourceFhirAllType(Resource.ResourceType), Resource);
    }

    private void ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null)
    {
      switch (ResourceType)
      {
        case FHIRAllTypes.CompartmentDefinition:
          break;
        default:
          break;
      }
    }

  }
}
