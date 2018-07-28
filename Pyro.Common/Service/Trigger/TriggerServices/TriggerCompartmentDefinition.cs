using System;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.PyroHealthFhirResource;
using Pyro.Common.Tools;

namespace Pyro.Common.Service.Trigger.TriggerServices
{
  /// <summary>
  /// Prevents the Updating or Deletion of CompartmentDefinition resources if that resource is an active Compartment in the Server.
  /// </summary>
  public class TriggerCompartmentDefinition : ITriggerCompartmentDefinition
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IServiceCompartmentRepository IServiceCompartmentRepository;
    private readonly IPyroFhirResource IPyroFhirResource;

    public TriggerCompartmentDefinition(IRepositorySwitcher IRepositorySwitcher, IServiceCompartmentRepository IServiceCompartmentRepository, IPyroFhirResource IPyroFhirResource)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;
      this.IPyroFhirResource = IPyroFhirResource;
    }

    public ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput)
    {
      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update || TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete) 
      {        
        return ProcessUpdateOrDelete(TriggerInput);
      }
      else if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Create)
      {
        RemoveActiveCompartmentTag(TriggerInput.InboundResource);
        return new TriggerOutcome() { Report = false };
      }
      else if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Read)
      {
        return new TriggerOutcome() { Report = false };
      }
      else
      {
        throw new FormatException("TriggerInput.CrudOperationType cannot be None.");
      }
    }

    private ITriggerOutcome ProcessUpdateOrDelete(ITriggerInput TriggerInput)
    {
      //Get any Compartment with the same FhirId
      var ServiceCompartment = IServiceCompartmentRepository.GetServiceCompartmentByFhirId(TriggerInput.InboundResourceId);
      if (ServiceCompartment != null)
      {
        string Message = "Error Message Not Set";
        if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update)
        {
          //If so do not allow the update 
            Message = $"The {FHIRAllTypes.CompartmentDefinition.GetLiteral()} resource cannot be updated because it is an active Compartment in the server. " +
            $"You must first set this compartment to Inactive before you can updated this resource. " +
            $"To do this you will need to call the server Operation ${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()} on this resource instance. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{TriggerInput.InboundResourceId}/${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()}' " +
            $"Once Inactive you will then be able to update this resource in the server. " +
            $"Caution should be taken as active Compartments affect how users interact with the server and the resources they have access to. " +
            $"To re-activate the Compartment after updating you must call the Operation ${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()}. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{TriggerInput.InboundResourceId}/${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()}' ";
        }
        else if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete)
        {
            Message = $"The {FHIRAllTypes.CompartmentDefinition.GetLiteral()} resource cannot be deleted because it is an active Compartment in the server. " +
            $"You must first set this compartment to Inactive before you can delete this resource. " +
            $"To do this you will need to call the server Operation ${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()} on this resource instance. " +
            $"For example '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/{TriggerInput.InboundResourceId}/${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()}' " +
            $"Once Inactive you will then be able to delete this resource from the server. " +
            $"Caution should be taken as active Compartments affect how users interact with the server and the resources they have access to.";
        }
        var ReturnOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
        var TriggerOutcome = new TriggerOutcome();
        TriggerOutcome.Report = true;
        TriggerOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;        
        TriggerOutcome.Resource = ReturnOperationOutcome;
        return TriggerOutcome;
      }
      else
      {
        //the Compartmentdefinition is not active so can be Updated or deleted, if updating then ensure 
        //the active tags are not present and remove if they are
        RemoveActiveCompartmentTag(TriggerInput.InboundResource);
      }
      
      return new TriggerOutcome() { Report = false};
    }

    private void RemoveActiveCompartmentTag(Resource Resource)
    {
      if (Resource.Meta != null)
      {
        if (Resource.Meta.Tag != null)
        {
          var ActiveCoding = IPyroFhirResource.CodeSystem.PyroFhirServerCodeSystem.GetCoding(PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ActiveCompartment);
          var TagCode = Resource.Meta.Tag.SingleOrDefault(x => x.System == ActiveCoding.System && x.Code == ActiveCoding.Code);
          if (TagCode != null)
          {
            Resource.Meta.Tag.Remove(TagCode);
          }
        }
      }
    }
  }
}
