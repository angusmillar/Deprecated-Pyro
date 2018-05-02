using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Service;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation;
using Hl7.Fhir.Model;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;

namespace Pyro.Engine.Services
{
  //[base]/[Resource]/[FhirId]/$some-operation
  public class FhirResourceInstanceOperationService : IFhirResourceInstanceOperationService
  {
    private readonly ICommonFactory ICommonFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;

    public FhirResourceInstanceOperationService(ICommonFactory ICommonFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory)
    {
      this.ICommonFactory = ICommonFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
    }

    public IResourceServiceOutcome ProcessPost(
      string ResourceName,
      string FhirId,
      string OperationName,
      IRequestMeta RequestMeta,
      Resource Resource)
    {
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      return Process(ResourceName, FhirId, OperationName, RequestMeta, Resource);
    }

    public IResourceServiceOutcome ProcessGet(
      string ResourceName,
      string FhirId,
      string OperationName,
      IRequestMeta RequestMeta)
    {     
      return Process(ResourceName, FhirId, OperationName, RequestMeta, null);
    }

    private IResourceServiceOutcome Process(
      string ResourceName, 
      string FhirId, 
      string OperationName,      
      IRequestMeta RequestMeta,
      Resource Resource = null)
    {
      if (string.IsNullOrWhiteSpace(OperationName))
        throw new NullReferenceException("OperationName cannot be null.");      
      if(RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("ServiceRequest.RequestUri.FhirRequestUri cannot be null.");
      if (string.IsNullOrWhiteSpace(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId))
        throw new NullReferenceException("ServiceRequest.RequestUri.FhirRequestUri.ResourceId cannot be null or empty.");    
      if (ICommonFactory == null)
        throw new NullReferenceException("ICommonFactory cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      var OperationDic = FhirOperationEnum.GetOperationTypeByString();
      if (!OperationDic.ContainsKey(OperationName))
      {
        string Message = $"The resource operation named ${OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[OperationName];
      OperationClass OperationClass = OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Instance && x.Type == Op);
      if (OperationClass == null)
      {
        string Message = $"The resource operation named ${OperationName} is not supported by the server as a resource instance service operation type.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      switch (OperationClass.Type)
      {
        case FhirOperationEnum.OperationType.Validate:
          {
            IFhirValidateOperationService FhirValidateOperationService = ICommonFactory.CreateFhirValidateOperationService();
            return FhirValidateOperationService.ValidateResourceInstance(OperationClass, Resource, RequestMeta);
          }
        case FhirOperationEnum.OperationType.xSetCompartmentActive:
          {
            ICompartmentOperationService CompartmentOperationService = ICommonFactory.CreateCompartmentOperationService();
            return CompartmentOperationService.SetActive(OperationClass, RequestMeta, FhirId);
          }
        case FhirOperationEnum.OperationType.xSetCompartmentInActive:
          {
            ICompartmentOperationService CompartmentOperationService = ICommonFactory.CreateCompartmentOperationService();
            return CompartmentOperationService.SetInActive(OperationClass, RequestMeta, FhirId);
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
