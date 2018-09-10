using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Global;
using Pyro.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Service.Trigger.TriggerServices
{
  public class TriggerServerReadOnlyMode : ITriggerServerReadOnlyMode
  {
    private readonly IGlobalProperties IGlobalProperties;

    public TriggerServerReadOnlyMode(IGlobalProperties IGlobalProperties)
    {
      this.IGlobalProperties = IGlobalProperties;
    }

    public ResourceType ResourceTypeToTriggerFor => ResourceType.Resource;

    public ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput)
    {
      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update || 
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Create || 
          TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete)
      {
        return ProcessCreateUpdateOrDelete(TriggerInput);
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

    private ITriggerOutcome ProcessCreateUpdateOrDelete(ITriggerInput triggerInput)
    {
      if (IGlobalProperties.ServerReadOnlyMode)
      {
        //The Resource is protected 
        string Message = $"The FHIR Server is currently in a read only mode. ";
        if (!string.IsNullOrWhiteSpace(IGlobalProperties.ServerReadOnlyModeMessage))
        {
          Message += $"Administrator's Message: {IGlobalProperties.ServerReadOnlyModeMessage}";
        }
                
        var ReturnOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Information, OperationOutcome.IssueType.Informational, Message);
        var TriggerOutcome = new TriggerOutcome();
        TriggerOutcome.Report = true;
        TriggerOutcome.HttpStatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        TriggerOutcome.Resource = ReturnOperationOutcome;
        return TriggerOutcome;
      }
      else
      {
        //The resource is not Protected
        return new TriggerOutcome() { Report = false };
      }
    }
  }
}
