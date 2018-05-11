using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Tools;
using Pyro.Engine.Services.ResourceTrigger;

namespace Pyro.Engine.TriggerServices.CompartmentDefinitionResource
{
  /// <summary>
  /// Prevents the Updating or Deletion of CompartmentDefinition resources if that resource is an active Compartment in the Server.
  /// </summary>
  public class TriggerCompartmentDefinition : ITriggerService, ITriggerCompartmentDefinition
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IServiceCompartmentRepository IServiceCompartmentRepository;

    public TriggerCompartmentDefinition(IRepositorySwitcher IRepositorySwitcher, IServiceCompartmentRepository IServiceCompartmentRepository)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;
    }

    public ITriggerOutcome ProcessTrigger(RestEnum.CrudOperationType CrudOperationType, ResourceTriggerService.TriggerRaisedType TriggerRaised, string ResourceId, FHIRAllTypes ResourceType, Resource Resource = null)
    {
      if ((CrudOperationType == RestEnum.CrudOperationType.Update || CrudOperationType == RestEnum.CrudOperationType.Delete) && TriggerRaised == ResourceTriggerService.TriggerRaisedType.BeforeCommit)
      {        
        return ProcessUpdateOrDelete(CrudOperationType, TriggerRaised, ResourceId, ResourceType, Resource);
      }
      else if (CrudOperationType == RestEnum.CrudOperationType.Create && TriggerRaised == ResourceTriggerService.TriggerRaisedType.BeforeCommit)
      {
        RemoveActiveCompartmentTag(Resource);
        return new TriggerOutcome() { TriggerOutcomeResult = TriggerOutcome.TriggerOutcomeType.Contiune };
      }
      else
      {
        return new TriggerOutcome() { TriggerOutcomeResult = TriggerOutcome.TriggerOutcomeType.Contiune };
      }
    }

    private ITriggerOutcome ProcessUpdateOrDelete(RestEnum.CrudOperationType crudOperationType, ResourceTriggerService.TriggerRaisedType triggerRaised, string resourceId, FHIRAllTypes resourceType, Resource resource)
    {
      //Get any Compartment with the same FhirId
      var ServiceCompartment = IServiceCompartmentRepository.GetServiceCompartmentByFhirId(resourceId);
      if (ServiceCompartment != null)
      {
        string Message = "Error Message Not Set";
        if (crudOperationType == RestEnum.CrudOperationType.Update)
        {
          //If so do not allow the update 
            Message = $"The {FHIRAllTypes.CompartmentDefinition.GetLiteral()} resource cannot be updated because it is an active Compartment in the server. " +
            $"You must first set this compartment to Inactive before you can updated this resource. " +
            $"To do this you will need to call the server Operation ${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()} on this resource instance. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{resourceId}/${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()}' " +
            $"Once Inactive you will then be able to update this resource in the server. " +
            $"Caution should be taken as active Compartments affect how users interact with the server and the resources they have access to. " +
            $"To re-activate the Compartment after updating you must call the Operation ${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()}. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{resourceId}/${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()}' ";
        }
        else if (crudOperationType == RestEnum.CrudOperationType.Delete)
        {
            Message = $"The {FHIRAllTypes.CompartmentDefinition.GetLiteral()} resource cannot be deleted because it is an active Compartment in the server. " +
            $"You must first set this compartment to Inactive before you can delete this resource. " +
            $"To do this you will need to call the server Operation ${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()} on this resource instance. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{resourceId}/${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()}' " +
            $"Once Inactive you will then be able to delete this resource from the server. " +
            $"Caution should be taken as active Compartments affect how users interact with the server and the resources they have access to.";
        }
        var ReturnOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
        var TriggerOutcome = new TriggerOutcome();
        TriggerOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
        TriggerOutcome.TriggerOutcomeResult = TriggerOutcome.TriggerOutcomeType.Report;
        TriggerOutcome.Resource = ReturnOperationOutcome;
        return TriggerOutcome;
      }
      else
      {
        //the Compartmentdefinition is not active so can be Updated or deleted, if updating then ensure 
        //the active tags are not present and remove if they are
        RemoveActiveCompartmentTag(resource);
      }
      
      return new TriggerOutcome() { TriggerOutcomeResult = TriggerOutcome.TriggerOutcomeType.Contiune };
    }

    private void RemoveActiveCompartmentTag(Resource Resource)
    {
      if (Resource.Meta != null)
      {
        if (Resource.Meta.Tag != null)
        {
          var PyroCodeSystem = Common.PyroHealthInformation.PyroServerCodeSystem.GetCodeSystem();
          var ActiveCode = PyroCodeSystem.Concept.Single(x => x.Code == Common.PyroHealthInformation.PyroServerCodeSystem.Codes.ActiveCompartment.GetPyroLiteral());
          var TagCode = Resource.Meta.Tag.SingleOrDefault(x => x.System == PyroCodeSystem.Url && x.Code == ActiveCode.Code);
          if (TagCode != null)
          {
            Resource.Meta.Tag.Remove(TagCode);
          }
        }
      }
    }
  }
}
