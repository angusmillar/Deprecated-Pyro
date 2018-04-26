using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.FhirOperation;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Compartment;
using Pyro.Common.ServiceSearchParameter;

namespace Pyro.Common.Service
{
  public class CompartmentOperationService : ICompartmentOperationService
  {
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IServiceCompartmentRepository IServiceCompartmentRepository;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;
    private readonly IServiceCompartmentCache IServiceCompartmentCache;

    IResourceServiceOutcome ResourceServiceOutcome;

    //Pyro url compartments will override the standard HL7 compatments
    private readonly string HL7OrgUrl = "http://hl7.org/fhir/CompartmentDefinition/patient";
    private readonly string PyroOrgUrl = "https://Pyrohealth.net/Codesystem/CompartmentDefinition/patient";

    public CompartmentOperationService(
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IResourceServices IResourceServices,      
      IRequestMetaFactory IRequestMetaFactory,
      IServiceCompartmentRepository IServiceCompartmentRepository,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      IServiceCompartmentCache IServiceCompartmentCache)      
    {
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IServiceCompartmentCache = IServiceCompartmentCache;
    }

    public IResourceServiceOutcome Set(OperationClass OperationClass, Resource Resource, IRequestMeta RequestMeta)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      if (Resource is CompartmentDefinition CompartDef)
      {
        if (CompartDef.Status != PublicationStatus.Active)
        {
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
          $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource status must be {PublicationStatus.Active.GetLiteral()}. The resource supplied has a status of {CompartDef.Status.GetLiteral()}.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        if (string.IsNullOrWhiteSpace(CompartDef.Id))
        {
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
          $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource must have a resource id.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }

        if (CompartDef.Url == HL7OrgUrl || CompartDef.Url == PyroOrgUrl)
        {
          DtoServiceCompartment NewServiceCompartment = new DtoServiceCompartment();
          NewServiceCompartment.CompartmentDefinitionResourceId = CompartDef.Id;
          NewServiceCompartment.Code = CompartDef.Code.GetLiteral();
          NewServiceCompartment.LastUpdated = DateTimeOffset.Now;
          NewServiceCompartment.Name = CompartDef.Name;
          NewServiceCompartment.Title = CompartDef.Title;
          NewServiceCompartment.Url = CompartDef.Url;
          NewServiceCompartment.ResourceList = new List<DtoServiceCompartmentResource>();
          foreach (var ResourceComponent in CompartDef.Resource)
          {
            List<Search.ServiceSearchParameterLight> SupportedSerachParamList = IServiceSearchParameterCache.GetSearchParameterForResource(ResourceComponent.Code.GetLiteral());
            if (ResourceComponent.Param.Count() == 0)
            {
              var CompatmentResource = new DtoServiceCompartmentResource()
              {
                Code = ResourceComponent.Code.GetLiteral(),
                // '*' means no paramerter, which means all Resource of this type
                //are in the compartment. 
                //If there is no 'ResourceComponent' at all then that Resources type and all its instances 
                //are not in the compartment
                Param = "*"
              };
              NewServiceCompartment.ResourceList.Add(CompatmentResource);
            }

            foreach (var Param in ResourceComponent.Param)
            {              
              var FoundParam = SupportedSerachParamList.SingleOrDefault(x => x.Name == Param.Split('.')[0]);
              if (FoundParam != null)
              {
                if (FoundParam.Type != SearchParamType.Reference)
                {
                  ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
                  $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource has a search parameter that is not a Reference search parameter type. The parameter in question is '{Param}' for the resource '{ResourceComponent.Code.GetLiteral()}'");
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ResourceServiceOutcome.SuccessfulTransaction = true;
                  return ResourceServiceOutcome;
                }
              }
              else
              {
                ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
                  $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource has a search parameter that is not supported by the server. The parameter in question is '{Param}' for the resource '{ResourceComponent.Code.GetLiteral()}'");
                ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                ResourceServiceOutcome.SuccessfulTransaction = true;
                return ResourceServiceOutcome;
              }
              
              var CompatmentResource = new DtoServiceCompartmentResource()
              {
                Code = ResourceComponent.Code.GetLiteral(),
                Param = Param
              };
              NewServiceCompartment.ResourceList.Add(CompatmentResource);
            }
          }
          
          //Commit or Update the compartment
          NewServiceCompartment = IServiceCompartmentRepository.UpdateServiceCompartment(NewServiceCompartment);
          //Clear any level one cached instances for this compartment.  
          ModelInfo.SupportedResources.ForEach(x =>
          {
            IServiceCompartmentCache.ClearServiceCompartmentForCompartmentCodeAndResource(NewServiceCompartment.Code, x);
          });
          
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.IsDeleted = false;
          ResourceServiceOutcome.OperationType = RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else
        {
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
          $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource url property must be either: '{HL7OrgUrl}' or '{PyroOrgUrl}'. The resource supplied has a url property of '{CompartDef.Url}'.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The resource supplied to the ${FhirOperationEnum.OperationType.xSetCompartment.GetPyroLiteral()} operation must be a {ResourceType.CompartmentDefinition.GetLiteral()} resource type. The resource type given was: {Resource.ResourceType.GetLiteral()}.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }
      
    }
    
  }
}
