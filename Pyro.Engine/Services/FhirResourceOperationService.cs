using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.FhirOperation;

namespace Pyro.Engine.Services
{
  //[base]/[Resource]/$some-operation
  public class FhirResourceOperationService
  {
    IResourceOperationsServiceRequest _ServiceRequest;
    public IResourceServiceOutcome Process(IResourceOperationsServiceRequest ServiceRequest)
    {
      if (string.IsNullOrWhiteSpace(ServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (ServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (ServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (ServiceRequest.ResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (ServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

      _ServiceRequest = ServiceRequest;
      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = ServiceRequest.SearchParameterGeneric;
      var SearchParameterService = new SearchParameterService();
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      var OperationDic = FhirOperationEnum.GetOperationTypeByString();
      if (!OperationDic.ContainsKey(ServiceRequest.OperationName))
      {
        string Message = $"The resource operation named ${ServiceRequest.OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[ServiceRequest.OperationName];
      OperationClass OperationClass = Common.BusinessEntities.FhirOperation.OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Resource && x.Type == Op);
      if (OperationClass == null)
      {
        string Message = $"The resource operation named ${ServiceRequest.OperationName} is not supported by the server as a resource service operation type.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
      _ServiceRequest.OperationClass = OperationClass;


      switch (OperationClass.Type)
      {
        case FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes:
          {
            var DeleteManyHistoryIndexesService = Common.CommonFactory.GetDeleteHistoryIndexesService(_ServiceRequest);
            return DeleteManyHistoryIndexesService.DeleteSingle();
          }
        case FhirOperationEnum.OperationType.Validate:
          {
            var ValidateResourceInstanceService = Common.CommonFactory.GetValidateResourceInstanceService(_ServiceRequest);
            return ValidateResourceInstanceService.ValidateResource();
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
