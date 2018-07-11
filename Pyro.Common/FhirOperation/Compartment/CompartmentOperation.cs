using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Compartment;
using Pyro.Common.ServiceSearchParameter;
using Pyro.Common.Tools;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Trigger;

namespace Pyro.Common.FhirOperation.Compartment
{
  public class CompartmentOperation : ICompartmentOperation
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IServiceCompartmentRepository IServiceCompartmentRepository;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;
    private readonly IServiceCompartmentCache IServiceCompartmentCache;
    private readonly IResourceTriggerService IResourceTriggerService;

    IResourceServiceOutcome ResourceServiceOutcome;

    //Pyro url compartments will override the standard HL7 compatments
    private readonly string HL7OrgUrl = "http://hl7.org/fhir/CompartmentDefinition";
    private string PyroOrgUrl = string.Empty;

    public CompartmentOperation(
      IRepositorySwitcher IRepositorySwitcher,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IServiceCompartmentRepository IServiceCompartmentRepository,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      IServiceCompartmentCache IServiceCompartmentCache,
      IResourceTriggerService IResourceTriggerService)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IServiceCompartmentCache = IServiceCompartmentCache;
      this.IResourceTriggerService = IResourceTriggerService;

      var PyroHealthCodeSystem = PyroHealthInformation.PyroServerCodeSystem.GetCodeSystem();
      PyroOrgUrl = $"{PyroHealthCodeSystem.Url}/{PyroHealthInformation.PyroServerCodeSystem.Codes.CompartmentDefinition.GetPyroLiteral()}";
    }

    public IResourceServiceOutcome SetActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
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

      CompartmentDefinition CompartDef = GetCompartmentResource(FhirId);

      if (CompartDef != null)
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

        if (CompartDef.Url.StartsWith(HL7OrgUrl) || CompartDef.Url.StartsWith(PyroOrgUrl))
        {
          DtoServiceCompartment NewServiceCompartment = new DtoServiceCompartment();
          NewServiceCompartment.CompartmentDefinitionResourceId = CompartDef.Id;
          NewServiceCompartment.CompartmentDefinitionResourceVersion = CompartDef.Meta.VersionId;
          NewServiceCompartment.Code = CompartDef.Code.GetLiteral();
          NewServiceCompartment.LastUpdated = DateTimeOffset.Now;
          NewServiceCompartment.Name = CompartDef.Name;
          NewServiceCompartment.Title = CompartDef.Title;
          NewServiceCompartment.Url = CompartDef.Url;
          NewServiceCompartment.ResourceList = new List<DtoServiceCompartmentResource>();
          foreach (var ResourceComponent in CompartDef.Resource)
          {
            List<Search.DtoServiceSearchParameterLight> SupportedSerachParamList = IServiceSearchParameterCache.GetSearchParameterForResource(ResourceComponent.Code.GetLiteral());
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
              //The Resource param value equals {def} then thnis shoudl be the same Resource as that of the Compartment its self
              //in this case there are no search parameters
              if (Param.ToLower() == "{def}")
              {
                if (ResourceComponent.Code.GetLiteral() != CompartDef.Code.GetLiteral())
                {
                  ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
                   $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource has a search parameter that has a value of '{{def}}' which should indicate that this Resource is the target of the Compatment it's self, Yet they do not match, Compartment is: '{ResourceComponent.Code.GetLiteral()}' and '{{def}}' parametrer is found for ResourceType {ResourceComponent.Code.GetLiteral()}");
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ResourceServiceOutcome.SuccessfulTransaction = true;
                  return ResourceServiceOutcome;
                }
              }
              else
              {
                var FoundParam = SupportedSerachParamList.SingleOrDefault(x => x.Name == Param.Split('.')[0].Split(':')[0]);
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
          }

          //Commit or Update the compartment
          NewServiceCompartment = IServiceCompartmentRepository.UpdateServiceCompartment(NewServiceCompartment);
          ClearCompartmentCache(NewServiceCompartment.Code);
          AddCompartmentActiveTag(CompartDef);

          //Commit CompartmentDefinition with Active tag, disable triggers on doing so as the triggers will block
          //the update. 
          IRequestMeta RequestMetaUpdateCompartmentDef = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.CompartmentDefinition}/{CompartDef.Id}");
          //IResourceServices.TriggersActive = false;
          this.IResourceTriggerService.TriggersActive = false;
          var IResourceServicesOutcome = IResourceServices.Put(CompartDef.Id, CompartDef, RequestMetaUpdateCompartmentDef);
          this.IResourceTriggerService.TriggersActive = true;

          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.IsDeleted = false;
          ResourceServiceOutcome.OperationType = RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else
        {
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
          $"The {ResourceType.CompartmentDefinition.GetLiteral()} resource url property must start with either: '{HL7OrgUrl}' or '{PyroOrgUrl}'. The resource supplied has a url property of '{CompartDef.Url}'.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        //Not CompartmentDefinition Resource found
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The resource id supplied to the ${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()} operation was not found in the server at: {ResourceType.CompartmentDefinition.GetLiteral()}/{FhirId}");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
        ResourceServiceOutcome.FhirResourceId = null;
        ResourceServiceOutcome.LastModified = null;
        ResourceServiceOutcome.IsDeleted = null;
        ResourceServiceOutcome.OperationType = RestEnum.CrudOperationType.Read;
        ResourceServiceOutcome.ResourceVersionNumber = null;
        ResourceServiceOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }
    }

    private static void AddCompartmentActiveTag(CompartmentDefinition CompartDef)
    {
      if (CompartDef.Meta == null)
        CompartDef.Meta = new Meta();
      if (CompartDef.Meta.Tag == null)
        CompartDef.Meta.Tag = new List<Coding>();
      var PyroCodeSystem = PyroHealthInformation.PyroServerCodeSystem.GetCodeSystem();
      var PyroActiveCode = PyroCodeSystem.Concept.Single(x => x.Code == PyroHealthInformation.PyroServerCodeSystem.Codes.ActiveCompartment.GetPyroLiteral());
      CompartDef.Meta.Tag.Add(new Coding(PyroCodeSystem.Url, PyroActiveCode.Code, PyroActiveCode.Display));
    }

    public IResourceServiceOutcome SetInActive(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      CompartmentDefinition CompartDef = GetCompartmentResource(FhirId);
      if (CompartDef != null)
      {
        var DbServiceCompartment = IServiceCompartmentRepository.GetServiceCompartmentByFhirId(CompartDef.Id);
        if (DbServiceCompartment != null)
        {
          IServiceCompartmentRepository.DeleteServiceCompartment(DbServiceCompartment.Code);
          ClearCompartmentCache(DbServiceCompartment.Code);
        }
        //Regadless of the Compartment being there or not we return NoContent when it is deleted.
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        ResourceServiceOutcome.FhirResourceId = null;
        ResourceServiceOutcome.LastModified = null;
        ResourceServiceOutcome.IsDeleted = null;
        ResourceServiceOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        ResourceServiceOutcome.ResourceVersionNumber = null;
        ResourceServiceOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }
      else
      {
        //Not CompartmentDefinition Resource found
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The resource id supplied to the ${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()} operation was not found in the server at: {ResourceType.CompartmentDefinition.GetLiteral()}/{FhirId}");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
        ResourceServiceOutcome.FhirResourceId = null;
        ResourceServiceOutcome.LastModified = null;
        ResourceServiceOutcome.IsDeleted = null;
        ResourceServiceOutcome.OperationType = RestEnum.CrudOperationType.Read;
        ResourceServiceOutcome.ResourceVersionNumber = null;
        ResourceServiceOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }
    }

    private void ClearCompartmentCache(string Code)
    {
      //Clear the root ServiceCompartment from cache
      IServiceCompartmentCache.ClearServiceCompartmentForCompartmentCode(Code);
      //Clear the all ServiceCompartmentResource parameters from cache
      ModelInfo.SupportedResources.ForEach(x =>
      {
        IServiceCompartmentCache.ClearServiceCompartmentResourceForCompartmentCodeAndResource(Code, x);
      });
    }

    private CompartmentDefinition GetCompartmentResource(string CompartmentDefintionFhirId)
    {
      IResourceRepository IResourceRepository = IRepositorySwitcher.GetRepository(FHIRAllTypes.CompartmentDefinition);
      var DatabaseOperation = IResourceRepository.GetResourceByFhirID(CompartmentDefintionFhirId, true, false);
      if (DatabaseOperation.ReturnedResourceList.Count > 0)
      {
        return Tools.FhirResourceSerializationSupport.DeSerializeFromGZip(DatabaseOperation.ReturnedResourceList[0].Resource) as CompartmentDefinition;        
      }
      return null;
    }
  }
}
