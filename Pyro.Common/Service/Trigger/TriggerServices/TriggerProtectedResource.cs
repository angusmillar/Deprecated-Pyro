using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.PyroHealthFhirResource;
using Pyro.Common.Search;
using Pyro.Common.ServiceSearchParameter;
using Pyro.Common.Tools;

namespace Pyro.Common.Service.Trigger.TriggerServices
{
  /// <summary>
  /// Prevents the Updating or Deletion of CompartmentDefinition resources if that resource is an active Compartment in the Server.
  /// </summary>
  public class TriggerProtectedResource : ITriggerProtectedResource
  {
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;
    private readonly IPyroFhirResource IPyroFhirResource;

    private Coding _ProtectedCoding = null;

    public TriggerProtectedResource(IServiceSearchParameterCache IServiceSearchParameterCache, IPyroFhirResource IPyroFhirResource)
    {
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IPyroFhirResource = IPyroFhirResource;
      _ProtectedCoding = IPyroFhirResource.CodeSystem.PyroFhirServerCodeSystem.GetCoding(PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.Protected);
    }

    public ITriggerOutcome ProcessTrigger(ITriggerInput TriggerInput)
    {
      if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update || TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete) 
      {        
        return ProcessUpdateOrDelete(TriggerInput);
      }
      else if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Create)
      {
        RemoveProtectedTag(TriggerInput.InboundResource);
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
      DtoServiceSearchParameterLight TagSearchParameter = GetTagSearchParameters(TriggerInput.ResourceType.GetLiteral());
      if (TriggerInput.DbTokenIndexList.Any(x => x.ServiceSearchParameterId == TagSearchParameter.Id && x.Code == _ProtectedCoding.Code && x.System == _ProtectedCoding.System))
      {
        //The Resource is protected 
        string Message = "Error Message Not Set";
        if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Update)
        {          
          Message = $"The {TriggerInput.ResourceType.GetLiteral()} resource instance with Id: {TriggerInput.InboundResourceId} cannot be updated because it is a {_ProtectedCoding.Display}.";
        }
        else if (TriggerInput.CrudOperationType == RestEnum.CrudOperationType.Delete)
        {
          Message = $"The {TriggerInput.ResourceType.GetLiteral()} resource instance with Id: {TriggerInput.InboundResourceId} cannot be deleted because it is a {_ProtectedCoding.Display}.";
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
        //The resource is not Protected
        return new TriggerOutcome() { Report = false };
      }      
    }

    /// <summary>
    /// Uses can not add Protected resource so if they try to just remove the Tags Code
    /// </summary>
    /// <param name="Resource"></param>
    private void RemoveProtectedTag(Resource Resource)
    {
      if (Resource.Meta != null)
      {
        if (Resource.Meta.Tag != null)
        {          
          var TagCode = Resource.Meta.Tag.SingleOrDefault(x => x.Code == _ProtectedCoding.Code && x.System == _ProtectedCoding.System);
          if (TagCode != null)
          {
            Resource.Meta.Tag.Remove(TagCode);
          }
        }
      }
    }



    private DtoServiceSearchParameterLight GetTagSearchParameters(string ResourceName)
    {
      List<DtoServiceSearchParameterLight> SearchParamList = IServiceSearchParameterCache.GetSearchParameterForResource(ResourceName);
      var Tag = SearchParamList.SingleOrDefault(x => x.Name == "_tag");           
      if (Tag != null)
      {
        return Tag;
      }
      else
      {
        throw new Exception($"Internal Server Error: No _tag search parameter found for Resource Type {ResourceName}");
      }
    }

  }
}
