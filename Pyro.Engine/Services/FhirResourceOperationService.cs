using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;

namespace Pyro.Engine.Services
{
  public class FhirResourceOperationService
  {
    IResourceOperationsServiceRequest _ServiceRequest;
    FhirOperationEnum.ResourceOperationType ResourceOperationType;
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
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {        
        ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;        
        return ResourceServiceOutcome;
      }

      var OperationDic = FhirOperationEnum.GetResourceOperationTypeByString();
      if (!OperationDic.ContainsKey(ServiceRequest.OperationName))
      {
        string Message = $"The resource operation named ${ServiceRequest.OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
      else
      {
        ResourceOperationType = OperationDic[ServiceRequest.OperationName];
      }

      switch (ResourceOperationType)
      {
        case FhirOperationEnum.ResourceOperationType.ServerIndexesDeleteHistoryIndexes:
          {
            var DeleteManyHistoryIndexesService = Common.CommonFactory.GetDeleteHistoryIndexesService(_ServiceRequest);
            return DeleteManyHistoryIndexesService.DeleteSingle();
          }          
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(ResourceOperationType.GetPyroLiteral(), (int)ResourceOperationType, typeof(FhirOperationEnum.ResourceOperationType));
      }      
    }
  }
}
