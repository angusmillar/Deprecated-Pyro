using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.ElementModel;
using Hl7.FhirPath;
using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools;
using Pyro.Common.Enum;
using Hl7.Fhir.Utility;
using Pyro.Common.PyroHealthFhirResource.CodeSystems;
using Pyro.Common.ServiceRoot;
using System.Text;
using Pyro.Common.Compartment;
using Pyro.Common.ServiceSearchParameter;
using Hl7.Fhir.FhirPath;
using Pyro.Common.Tools.FhirPathSupport;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.FhirOperation.MergePatient
{
  public class MergePatientOperation : IMergePatientOperation
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEventCodeSystem;
    private readonly IServiceCompartmentCache IServiceCompartmentCache;
    private readonly IServiceSearchParameterRepository IServiceSearchParameterRepository;
    private readonly IPyroFhirPathResolve IPyroFhirPathResolve;

    private Parameters _ParametersResource = null;
    private readonly string _CompartmentCode = "Patient";
    private readonly string _ServivingName = "Serviving";
    private readonly string _NonServivingName = "Non-Serviving";
    private Identifier _ServivingIdentifier = null;
    private Identifier _NonServivingIdentifier = null;
    private Patient _InboundServivingPatientResource = null;
    private Patient _ServivingPatientResource = null;
    private Patient _NonServivingPatientResource = null;


    public MergePatientOperation(IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      ISearchParameterServiceFactory ISearchParameterServiceFactory,
      IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEvent,
      IServiceCompartmentCache IServiceCompartmentCache,
      IServiceSearchParameterRepository IServiceSearchParameterRepository,
      IPyroFhirPathResolve IPyroFhirPathResolve)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IPyroHL7V2MessageTypeEventCodeSystem = IPyroHL7V2MessageTypeEvent;
      this.IServiceCompartmentCache = IServiceCompartmentCache;
      this.IServiceSearchParameterRepository = IServiceSearchParameterRepository;
      this.IPyroFhirPathResolve = IPyroFhirPathResolve;
    }

    public IResourceServiceOutcome Process(
          IPyroRequestUri RequestUri,
          ISearchParameterGeneric SearchParameterGeneric,
          Resource Resource)
    {
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      if (!ValidateParameterResource(out ResourceServiceOutcome, Resource))
      {
        return ResourceServiceOutcome;
      }

      if (!GetTargetPatientResources(out ResourceServiceOutcome))
      {
        return ResourceServiceOutcome;
      }

      //If there is no NonServivingPatientResource then no merge is required at all
      if (_NonServivingPatientResource == null)
      {
        return AllOkResponse();
      }
      else if (_ServivingPatientResource == null)
      {
        //We have only the Non Serviving Patient Resource found in the server, the Serviving Patient Resource is not in the server
        //We must add a new Patient Resource with the provided Serviving Patient Resource found in _InboundServivingPatientResource and then merge all content to it.          
        if (!AddResource(out ResourceServiceOutcome, out string PatientResourceId, ResourceType.Patient, _InboundServivingPatientResource))
        {
          return ResourceServiceOutcome;
        }
        else
        {
          _InboundServivingPatientResource.Id = PatientResourceId;
          _ServivingPatientResource = _InboundServivingPatientResource;
        }
      }

      //Now we should have both the Serviving and a Non-surviving patient resource so begin the content Merge
      if (_ServivingPatientResource != null && _NonServivingPatientResource != null)
      {
        //Test that the ServiceCompartment used by merge is loaded in the server.
        var ServiceCompartment = IServiceCompartmentCache.GetServiceCompartmentForCompartmentCode(_CompartmentCode);
        if (ServiceCompartment == null)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation is trying to utilises the '{_CompartmentCode}' compartment to resolve which resources have references to the surviving Patient resource. " +
            $"However it appears the '{_CompartmentCode}' compartment has not been loaded and set as an active compartment in this server. You may need to use the ${FhirOperationEnum.OperationType.xSetCompartmentActive} and ${FhirOperationEnum.OperationType.xSetCompartmentInActive} base operations to resolve this issue.";
          return SimpleErrorInvalidResponse(Message);
        }
        foreach (var SupportedResourceName in ModelInfo.SupportedResources)
        {          
          var PatientServiceCompartment = IServiceCompartmentCache.GetServiceCompartmentResourceForCompartmentCodeAndResource(_CompartmentCode, SupportedResourceName);
          if (PatientServiceCompartment != null) //Not every resource is in a compartment, so check for null.
          {
            foreach (var SearchParameter in PatientServiceCompartment.ParamList)
            {              
              //star '*' means that all resources of this type are in the compartmenmt even though there is not 
              //reference connteing them. For instance Practitioner does not reference Patient yet it is considered to be in the 
              //patient compartment. So for us here their is no reference to update so '*' can be skiped.
              if (SearchParameter.Param != "*")
              {
                DtoServiceSearchParameterLight DtoServiceSearchParameterLight = IServiceSearchParameterRepository.GetServiceSearchParametersLightForMerge(SupportedResourceName, SearchParameter.Param);
                if (DtoServiceSearchParameterLight != null)
                {
                  
                  string NonSurvivingPatientReference = $"{ResourceType.Patient.GetLiteral()}/{_NonServivingPatientResource.Id}";
                  string SearchQuery = $"?{DtoServiceSearchParameterLight.Name}={NonSurvivingPatientReference}";
                  ResourceType CurrentResourceType = ResourceNameResolutionSupport.GetResourceType(SupportedResourceName);

                  //Now we search for all resources of this CurrentResourceType that have this search parameter reference to the non-serviving patient
                  //and we update thoses references to point to the new Patient. This method is called recersivly untill all done. 
                  if (!MoveResourcesToSurvivingPatient(out ResourceServiceOutcome, CurrentResourceType, SearchQuery, DtoServiceSearchParameterLight.Expression))
                  {
                    return ResourceServiceOutcome;
                  }
                }
                else
                {                  
                  string CompartmentDefinitionReference = $"{ResourceType.CompartmentDefinition.GetLiteral()}/{ServiceCompartment.CompartmentDefinitionResourceId}/_history/{ServiceCompartment.CompartmentDefinitionResourceVersion}";
                  var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation utilises the '{_CompartmentCode}' compartment to resolve which resources have references to the surviving Patient resource. " +
                    $"The '{_CompartmentCode}' compartment is defined by a {ResourceType.CompartmentDefinition.GetLiteral()} resource that has been set as a compartment in this server. That{ResourceType.CompartmentDefinition.GetLiteral()} resource can be found in the server here GET: [base]/{CompartmentDefinitionReference} . " +
                    $"One of the {ResourceType.CompartmentDefinition.GetLiteral()}.resource.param properties in that {ResourceType.CompartmentDefinition.GetLiteral()} resource instance is invalid as the server does not support a search parameter listed here. " +
                    $"That particular search paramter is '{SearchParameter.Param}' for the '{SupportedResourceName}' resource. Please review the stated {ResourceType.CompartmentDefinition.GetLiteral()} resource. You may need to use the ${FhirOperationEnum.OperationType.xSetCompartmentInActive} and ${FhirOperationEnum.OperationType.xSetCompartmentActive} base operations to resolve this issue.";
                  return SimpleErrorInvalidResponse(Message);
                }
              }
            }
          }          
        }
        //We must here delete the non-serviving patient.
        if (!DeleteResource(out ResourceServiceOutcome, ResourceType.Patient, _NonServivingPatientResource.Id))
        {
          return ResourceServiceOutcome;
        }

        return AllOkResponse();
      }
      else
      {
        throw new ApplicationException("Server Error: The Merge Patient operation was unable to resolve both a Surviving and Non-Surviving Pateint resource.");
      }
    }

    
    private bool MoveResourcesToSurvivingPatient(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType CurrentResourceTypeToMove, string QueryString, string FhirPathExpression)
    {
      string SurvivingPatientReference = $"{ResourceType.Patient.GetLiteral()}/{_ServivingPatientResource.Id}";      
      var RequestMetaFindResource = IRequestMetaFactory.CreateRequestMeta().Set(CurrentResourceTypeToMove, QueryString);
      IResourceServiceOutcome SearchOutcome = IResourceServices.GetSearch(RequestMetaFindResource);
      
      if (SearchOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (SearchOutcome.ResourceResult is Bundle ResultBundle)
        {
          foreach (var Entry in ResultBundle.Entry)
          {
            FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
            ITypedElement TypedElement = Entry.Resource.ToTypedElement();
            var oFhirEvaluationContext = new FhirEvaluationContext(TypedElement);
            //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
            //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
            oFhirEvaluationContext.ElementResolver = IPyroFhirPathResolve.Resolver;
            IEnumerable<ITypedElement> ResultList = TypedElement.Select(FhirPathExpression, oFhirEvaluationContext);
            foreach (ITypedElement oElement in ResultList)
            {
              if (oElement is IFhirValueProvider FhirValueProvider && FhirValueProvider.FhirValue != null)
              {
                if (FhirValueProvider.FhirValue is ResourceReference ResourceReference)
                {
                  ResourceReference.Reference = SurvivingPatientReference;
                  ResourceReference.Identifier = null;
                  ResourceReference.Type = ResourceType.Patient.GetLiteral();
                  ResourceReference.Extension = null;
                  string FormattedName = GetFormattedPatientName(_ServivingPatientResource);
                  if (!string.IsNullOrEmpty(FormattedName))
                    ResourceReference.Display = FormattedName;
                }
              }
            }
            if (!UpdateResource(out ResourceServiceOutcome, CurrentResourceTypeToMove, Entry.Resource))
            {
              return false;
            }
            //todo: More to do here, if we have a next link then repeat above recursive 
            Bundle.LinkComponent NextLink = ResultBundle.Link.SingleOrDefault(x => x.Relation.Equals("next"));
            if (NextLink != null)
            {
              string NextQueryString = $"?{NextLink.Url.Split('?')[1]}";
              MoveResourcesToSurvivingPatient(out ResourceServiceOutcome, CurrentResourceTypeToMove, NextQueryString, FhirPathExpression);
            }            
          }
          ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
          return true;
        }
        else
        {
          throw new ApplicationException($"Server error: The server search result for {CurrentResourceTypeToMove} did not retrun a Bundle resource but did return 200 OK.");
        }
      }
      else
      {
        if (SearchOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to perfomed a Search for the {CurrentResourceTypeToMove.GetLiteral()} resource " +
            $"in the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          ResourceServiceOutcome = CombineOperationOutComeInvalidResponse(Message, ReturnOpOut);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server SEARCH did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 200 OK ");
        }
      }
    }

    private bool AddResource(out IResourceServiceOutcome ResourceServiceOutcome, out string ResourceId, ResourceType ResourceType, Resource Resource)
    {
      ResourceId = string.Empty;
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      string OriginalResourceId = Resource.Id;

      Resource.Id = null;
      var RequestMetaPost = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, string.Empty);
      IResourceServiceOutcome PostOutcome = IResourceServices.Post(Resource, RequestMetaPost);
      if (PostOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
      {
        ResourceId = PostOutcome.FhirResourceId;
        return true;
      }
      else
      {
        if (PostOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to Post the {ResourceType.GetLiteral()} resource " +
            $"to the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          ResourceServiceOutcome = CombineOperationOutComeInvalidResponse(Message, ReturnOpOut);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server POST did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool UpdateResource(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType ResourceType, Resource Resource)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var RequestMetaPut = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, Resource.Id);
      IResourceServiceOutcome PutOutcome = IResourceServices.Put(Resource.Id, Resource, RequestMetaPut);
      if (PutOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return true;
      }
      else
      {
        if (PutOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.xMergePatient.GetPyroLiteral()} operation was not able to PUT the {ResourceType} resource " +
            $"to the server. Please read the full issue list in this {ResourceType.OperationOutcome.GetLiteral()} resource for more info.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server PUT did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool DeleteResource(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType ResourceType, string ResourceId)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var RequestMetaPost = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, ResourceId);
      IResourceServiceOutcome DeleteOutcome = IResourceServices.Delete(ResourceId, RequestMetaPost);
      if (DeleteOutcome.HttpStatusCode == System.Net.HttpStatusCode.NoContent || DeleteOutcome.HttpStatusCode == System.Net.HttpStatusCode.Gone)
      {
        return true;
      }
      else
      {
        if (DeleteOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.xMergePatient.GetPyroLiteral()} operation was not able to DELETE the {ResourceType} resource wiht the id of {ResourceId} " +
            $"to the server. Please read the full issue list in this {ResourceType.OperationOutcome.GetLiteral()} resource for more info.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server DELETE did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 deleting when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool GetTargetPatientResources(out IResourceServiceOutcome ResourceServiceOutcome)
    {
      //There is no need to get the Serviving Patient if there is no NonServiving Patinet to merge with it.
      if (!GetResourceByIdentifier(out ResourceServiceOutcome, out Resource NonSurvivingResource, ResourceType.Patient, _NonServivingIdentifier))
      {
        return false;
      }
      else
      {
        if (NonSurvivingResource != null)
        {
          _NonServivingPatientResource = NonSurvivingResource as Patient;
        }
      }

      if (!GetResourceByIdentifier(out ResourceServiceOutcome, out Resource SurvivingResource, ResourceType.Patient, _ServivingIdentifier))
      {
        return false;
      }
      else
      {
        if (SurvivingResource != null)
        {
          _ServivingPatientResource = SurvivingResource as Patient;
        }
        return true;
      }
    }

    private bool GetResourceByIdentifier(out IResourceServiceOutcome ResourceServiceOutcome, out Resource Resource, ResourceType ResourceType, Identifier PrimaryIdentifier)
    {
      //First Search for the resource
      var RequestMetaFindResource = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, $"?identifier={PrimaryIdentifier.System}|{PrimaryIdentifier.Value}");
      IResourceServiceOutcome FindByIdOutcome = IResourceServices.GetSearch(RequestMetaFindResource);
      if (FindByIdOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (FindByIdOutcome.ResourceResult is Bundle Resultbundle)
        {
          //Not found return null
          if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 0)
          {
            ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
            Resource = null;
            return true;
          }
          //One found
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 1)
          {
            ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
            Resource = Resultbundle.Entry[0].Resource;
            return true;
          }
          //## Erorr if more then one found #############
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value > 1)
          {
            string Msg = $"Found more than one {ResourceType.GetLiteral()} resource with the identifier={PrimaryIdentifier.System}|{PrimaryIdentifier.Value}. " +
              $"This must be manualy resolved by a system administrator as there should never more than one {ResourceType.GetLiteral()} resource with the same identifier at any time.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
            Resource = null;
            return false;
          }
          else
          {
            throw new ApplicationException($"Server error: The server search result for {ResourceType.GetLiteral()} has no Bundle.Total property.");
          }
        }
        else
        {
          throw new ApplicationException($"Server error: The server search result for {ResourceType.GetLiteral()} has no Bundle.Total property.");
        }
      }
      else
      {
        if (FindByIdOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.xMergePatient.GetPyroLiteral()} operation was not able to perfomed a Search for the {ResourceType.GetLiteral()} resource " +
            $"in the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} issues for more info.";
          ResourceServiceOutcome = CombineOperationOutComeInvalidResponse(Message, ReturnOpOut);
          Resource = null;
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server SEARCH did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 200 OK ");
        }
      }
    }
    private bool ValidateParameterResource(out IResourceServiceOutcome ResourceServiceOutcome, Resource Resource)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (Resource is Parameters Parameters)
      {
        _ParametersResource = Parameters;
        var SurvivingParameter = Parameters.Parameter.SingleOrDefault(x => x.Name.ToUpper() == _ServivingName.ToUpper());
        if (SurvivingParameter == null)
        {
          string Msg = $"The {ResourceType.Parameters.GetLiteral()} resource must have a parametrer with a Name property equal to {_ServivingName} which represents the {_ServivingName} Patient's idenitfier";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
          return false;
        }
        else
        {
          if (!GetIdentifierFromParameter(out ResourceServiceOutcome, SurvivingParameter, true))
          {
            return false;
          }

        }
        var NonSurvivingParameter = Parameters.Parameter.SingleOrDefault(x => x.Name.ToUpper() == _NonServivingName.ToUpper());
        if (NonSurvivingParameter == null)
        {
          string Msg = $"The {ResourceType.Parameters.GetLiteral()} resource must have a parametrer with a Name property equal to {_NonServivingName} which represents the {_NonServivingName} Patient's idenitfier";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
          return false;
        }
        else
        {
          if (!GetIdentifierFromParameter(out ResourceServiceOutcome, NonSurvivingParameter, false))
          {
            return false;
          }
        }

        return true;
      }
      else
      {
        string Msg = $"The resource provided to the {FhirOperationEnum.OperationType.xMergePatient.GetPyroLiteral()} operation must be a {ResourceType.Parameters.GetLiteral()} resource. " +
          $"found resource type of {Resource.ResourceType.GetLiteral()}";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
        return false;
      }
    }

    private bool GetIdentifierFromParameter(out IResourceServiceOutcome ResourceServiceOutcome, Parameters.ParameterComponent ParameterComponent, bool IsServivingParameter)
    {
      string ParameterName = _NonServivingName;
      if (IsServivingParameter)
      {
        ParameterName = _ServivingName;
      }

      if (ParameterComponent.Resource != null)
      {
        if (ParameterComponent.Resource is Patient PatientResource)
        {
          Identifier PrimaryId = PatientResource.Identifier.SingleOrDefault(x => IsPrimaryIdentifier(x));
          if (PrimaryId != null)
          {
            if (IsServivingParameter)
            {
              _ServivingIdentifier = PrimaryId;
              _InboundServivingPatientResource = PatientResource;
            }
            else
            {
              _NonServivingIdentifier = PrimaryId;
            }
            ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
            return true;
          }
          else
          {            
            string Msg = $"The {ResourceType.Patient.GetLiteral()} resource for the {ParameterName} parameter must have a single Identifier with a Type code of 'MR' and Use property equal to {Identifier.IdentifierUse.Official.GetLiteral()}";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
            return false;
          }
        }
        else
        {
          string Msg = $"If providing a resource for the {ParameterName} parameter then that resource must be of type {ResourceType.Patient.GetLiteral()}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
          return false;
        }
      }
      else if (ParameterComponent.Value is Identifier Id)
      {
        if (IsServivingParameter)
        {
          string Msg = $"The {ParameterName} parameter must provide a Patient Resource and not only an Identifier as the server will have to create a new Patient Resource if the {ParameterName} Pateint does not exist as yet.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
          return false;
        }
        else
        {
          if (IsPrimaryIdentifier(Id))
          {
            _NonServivingIdentifier = Id;
            ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
            return true;
          }
          else
          {
            string Msg = $"The {ParameterName} parameter with an Identifier datatype must have an type Code of 'MR' and a Use of '{Identifier.IdentifierUse.Official.GetLiteral()}'.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
            return false;
          }
        }
      }
      else
      {
        string Msg = $"The {_NonServivingName} parameter must have either a Patient resource on the resource property or an Identifier data type on the value property.";
        if (IsServivingParameter)
        {
          Msg = $"The {_ServivingName} parameter must have either a Patient resource on the resource property.";
        }
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Msg);
        return false;
      }
    }

    private bool IsPrimaryIdentifier(Identifier Id)
    {
      if (Id.Type != null &&
            Id.Type.Coding != null &&
            Id.Type.Coding.SingleOrDefault(c => c.Code == "MR") != null &&
            Id.Use != null &&
            Id.Use == Identifier.IdentifierUse.Official &&
            !string.IsNullOrWhiteSpace(Id.Value))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private string GetFormattedPatientName(Patient Pat)
    {
      string Family = string.Empty;
      string Given = string.Empty;
      string Title = string.Empty;
      string FormatedName = string.Empty;
      HumanName PrimaryName = null; 
      if (Pat.Name != null)
      {
        if (Pat.Name.Count == 1)
        {
          PrimaryName = Pat.Name.First();          
        }
        else if (Pat.Name.Count > 1)
        {
          PrimaryName = Pat.Name.FirstOrDefault(x => x.Use == HumanName.NameUse.Official);
          if (PrimaryName == null)
          {
            PrimaryName = Pat.Name.FirstOrDefault(x => x.Use == HumanName.NameUse.Usual);
            if (PrimaryName == null)
            {
              PrimaryName = Pat.Name.First();
            }
          }
        }        
      }

      if (PrimaryName != null)
      {
        if (!string.IsNullOrEmpty(PrimaryName.Text))
        {
          FormatedName = PrimaryName.Text;
        }
        else
        {
          Family = PrimaryName.Family ?? string.Empty;
          if (PrimaryName.Given != null)
          {
            foreach (var item in PrimaryName.Given)
            {
              Given = $"{Given} {item}";
            }
            Given = Given.Trim();
          }

          if (PrimaryName.Prefix != null)
          {
            foreach (var item in PrimaryName.Prefix)
            {
              Title = $"{Title} {item}";
            }
            Title = Title.Trim();
          }            
          
          if (string.IsNullOrEmpty(Family) && string.IsNullOrEmpty(Given) && string.IsNullOrEmpty(Title))
          {
            FormatedName = $"{Family.ToUpper()}, {Title} {Given}";
          } 
          else if (string.IsNullOrEmpty(Family) && string.IsNullOrEmpty(Given))
          {
            FormatedName = $"{Family.ToUpper()}, {Given}";
          }
          else if (string.IsNullOrEmpty(Family))
          {
            FormatedName = $"{Family.ToUpper()}";
          }
          else
          {
            FormatedName = string.Empty;
          }
        }        
      }
      return FormatedName.Trim();
    }

    private IResourceServiceOutcome AllOkResponse()
    {
      var ReturnParametersResource = new Parameters();

      ReturnParametersResource.Parameter = new List<Parameters.ParameterComponent>()
      {
        new Parameters.ParameterComponent()
        {
           Name = "Sucess",
           Value = new FhirBoolean(true)
        },
      };

      if (_NonServivingPatientResource != null)
      {
        ReturnParametersResource.Parameter.Add(new Parameters.ParameterComponent()
        {
          Name = "NonServivingPatientResourceReference",
          Value = new ResourceReference($"{_NonServivingPatientResource.ResourceType.GetLiteral()}/{_NonServivingPatientResource.Id}")
        });
      }

      if (_ServivingPatientResource != null)
      {
        ReturnParametersResource.Parameter.Add(new Parameters.ParameterComponent()
        {
          Name = "ServivingPatientResourceReference",
          Value = new ResourceReference($"{_ServivingPatientResource.ResourceType.GetLiteral()}/{_ServivingPatientResource.Id}")
        });

        ReturnParametersResource.Parameter.Add(new Parameters.ParameterComponent()
        {
          Name = "ServivingPatientResource",
          Resource = _ServivingPatientResource
        });
      }
      
      //ReturnParametersResource.Parameter.AddRange(_ParametersResource.Parameter);
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      ResourceServiceOutcome.ResourceResult = ReturnParametersResource;
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.SuccessfulTransaction = true;
      return ResourceServiceOutcome;
    }

    private IResourceServiceOutcome SimpleErrorInvalidResponse(string Message)
    {
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      ResourceServiceOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.SuccessfulTransaction = false;
      return ResourceServiceOutcome;
    }

    private IResourceServiceOutcome CombineOperationOutComeInvalidResponse(string Message, OperationOutcome OptOutCome)
    {
      var IssueOne = FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
      List<OperationOutcome.IssueComponent> IssueList = new List<OperationOutcome.IssueComponent>();
      IssueList.Add(IssueOne);
      IssueList.AddRange(OptOutCome.Issue);
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      ResourceServiceOutcome.ResourceResult = FhirOperationOutcomeSupport.Generate(IssueList);
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.SuccessfulTransaction = false;
      return ResourceServiceOutcome;
    }
  }
}

