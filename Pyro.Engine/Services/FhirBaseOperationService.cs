using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;

namespace Pyro.Engine.Services
{
  public class FhirBaseOperationService : IFhirBaseOperationService
  {
    private readonly ICommonFactory ICommonFactory;

    public FhirBaseOperationService(ICommonFactory ICommonFactory)
    {
      this.ICommonFactory = ICommonFactory;
    }

    public IResourceServiceOutcome Process(
      string OperationName,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchPrameterGeneric,
      IDtoRequestHeaders RequestHeaders,
      Resource Resource)
    {
      if (string.IsNullOrWhiteSpace(OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      //if (IResourceServices == null)
      //  throw new NullReferenceException("ResourceServices cannot be null.");
      if (SearchPrameterGeneric == null)
        throw new NullReferenceException("SearchPrameterGeneric cannot be null.");

      //_ServiceRequest = ServiceRequest;
      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParameterService SearchService = ICommonFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchPrameterGeneric);
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
        string Message = $"The base operation named ${OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[OperationName];
      OperationClass OperationClass = Common.BusinessEntities.FhirOperation.OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Base && x.Type == Op);
      if (OperationClass == null)
      {
        string Message = $"The base operation named ${OperationName} is not supported by the server as a service base operation type.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      switch (OperationClass.Type)
      {
        case FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes:
          {
            IDeleteHistoryIndexesService DeleteManyHistoryIndexesService = ICommonFactory.CreateDeleteHistoryIndexesService();
            return DeleteManyHistoryIndexesService.DeleteMany(RequestUri, SearchPrameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesSet:
          {
            IServerSearchParameterService ServerSearchParameterService = ICommonFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessSet(RequestUri, SearchPrameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerSearchParameterIndexReport:
          {
            IServerSearchParameterService ServerSearchParameterService = ICommonFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessReport(RequestUri, SearchPrameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesIndex:
          {
            IServerSearchParameterService ServerSearchParameterService = ICommonFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessIndex(RequestUri, SearchPrameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerResourceReport:
          {
            IServerResourceReportService ServerResourceReportService = ICommonFactory.CreateServerResourceReportService();
            return ServerResourceReportService.Process(SearchPrameterGeneric);
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
