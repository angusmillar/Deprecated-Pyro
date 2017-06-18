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
  public class FhirBaseOperationService
  {
    IBaseOperationsServiceRequest _ServiceRequest;

    public IResourceServiceOutcome Process(IBaseOperationsServiceRequest ServiceRequest)
    {
      if (string.IsNullOrWhiteSpace(ServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
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
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      var OperationDic = FhirOperationEnum.GetOperationTypeByString();
      if (!OperationDic.ContainsKey(ServiceRequest.OperationName))
      {
        string Message = $"The base operation named ${ServiceRequest.OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[ServiceRequest.OperationName];
      OperationClass OperationClass = Common.BusinessEntities.FhirOperation.OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Base && x.Type == Op);
      if (OperationClass == null)
      {
        string Message = $"The base operation named ${ServiceRequest.OperationName} is not supported by the server as a service base operation type.";
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
            return DeleteManyHistoryIndexesService.DeleteMany();
          }
        case FhirOperationEnum.OperationType.ServerIndexesSet:
          {
            var ServerSearchParameterService = Common.CommonFactory.GetServerSearchParameterService(_ServiceRequest);
            return ServerSearchParameterService.ProcessSet();
          }
        case FhirOperationEnum.OperationType.ServerSearchParameterIndexReport:
          {
            var ServerSearchParameterService = Common.CommonFactory.GetServerSearchParameterService(_ServiceRequest);
            return ServerSearchParameterService.ProcessReport();
          }
        case FhirOperationEnum.OperationType.ServerIndexesIndex:
          {
            var ServerSearchParameterService = Common.CommonFactory.GetServerSearchParameterService(_ServiceRequest);
            return ServerSearchParameterService.ProcessIndex();
          }
        case FhirOperationEnum.OperationType.ServerResourceReport:
          {
            var ServerSearchParameterService = Common.CommonFactory.GetServerResourceReportService(_ServiceRequest);
            return ServerSearchParameterService.Process();
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
