using Pyro.Common.Compartment;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Exceptions;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Common.Service
{
  public class CompartmentSearchParameterService : ICompartmentSearchParameterService
  {
    private readonly IServiceCompartmentCache IServiceCompartmentCache;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;

    public CompartmentSearchParameterService(IServiceCompartmentCache IServiceCompartmentCache, ISearchParameterServiceFactory ISearchParameterServiceFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory)
    {
      this.IServiceCompartmentCache = IServiceCompartmentCache;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
    }

    public PyroSearchParameters GetSearchParameters(string Compartment, string CompartmentId, string ResourceName)
    {

      //I need to check that Compartment and ResourceName are actual FHIR Resource Types, the two lines
      //below do that and throw Pyro Exception if they are not.
      FHIRAllTypes CompartmentType = ResourceNameResolutionSupport.GetResourceFhirAllType(Compartment);
      FHIRAllTypes ResourceNameType = ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceName);
      
      //Now to contruct the Container search parameters, these are cached from the database Conatiner Resource      
      DtoServiceCompartmentResourceCached ServiceCompartmentResource = IServiceCompartmentCache.GetServiceCompartmentResourceForCompartmentCodeAndResource(Compartment, ResourceName);
      string ConatinerSerachString = string.Empty;

      if (ServiceCompartmentResource != null)
      {
        var CompartmentParamQuery = new List<string>();
        foreach (var CompartmentSearchParameter in ServiceCompartmentResource.ParamList)
        {
          if (CompartmentSearchParameter.Param == "*")
          {
            // if the param="*" then all instances of this Resource Type are in the container and there are no
            // actualy parameters that it needs to be restricted by. So the ConatinerSerachString remains as empty string.
            break;
          }
          else
          {
            CompartmentParamQuery.Add($"{CompartmentSearchParameter.Param}:{Compartment}={CompartmentId}");
          }
        }
        ConatinerSerachString = String.Join("&", CompartmentParamQuery.ToArray());
      }
      else
      {
        DtoServiceCompartmentCached ServiceCompartment = IServiceCompartmentCache.GetServiceCompartmentForCompartmentCode(Compartment);
        if (ServiceCompartment == null)
        {
          string Message = $"No active {Compartment} Compartment exist in this server. Perhaps you could create one using a {FHIRAllTypes.CompartmentDefinition.GetLiteral()} resource and the resource instance ${Pyro.Common.Enum.FhirOperationEnum.OperationType.xSetCompartmentActive} Operation. " +
            $"For example: '[base]/{FHIRAllTypes.CompartmentDefinition.GetLiteral()}/[id]/${Pyro.Common.Enum.FhirOperationEnum.OperationType.xSetCompartmentActive}' ";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
          throw new PyroException(System.Net.HttpStatusCode.BadRequest, OpOutcome, Message);
        }
        else
        {          
          string Message = $"The {Compartment} Compartment defined by the {FHIRAllTypes.CompartmentDefinition.GetLiteral()} with the resource id of '{ServiceCompartment.CompartmentDefinitionResourceId}' does not allow access to any {ResourceName} resource type instances.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
          throw new PyroException(System.Net.HttpStatusCode.BadRequest, OpOutcome, Message);
        }        
      }

      ISearchParameterGeneric ContainerSearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(ConatinerSerachString);
      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome ContainerSearchParametersServiceOutcome = SearchService.ProcessSearchParameters(ContainerSearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Resource, ResourceNameType, null);
      return ContainerSearchParametersServiceOutcome.SearchParameters;
    }
  }
}
