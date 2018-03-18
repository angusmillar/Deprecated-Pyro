using System;
using System.Linq;
using Pyro.Common.Service;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;

namespace Pyro.Engine.Services
{
  public class FhirBaseOperationService : IFhirBaseOperationService
  {
    private readonly ICommonFactory ICommonFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IServerSearchParameterServiceFactory IServerSearchParameterServiceFactory;

    public FhirBaseOperationService(ICommonFactory ICommonFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory, IServerSearchParameterServiceFactory IServerSearchParameterServiceFactory)
    {
      this.ICommonFactory = ICommonFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IServerSearchParameterServiceFactory = IServerSearchParameterServiceFactory;
    }

    public IResourceServiceOutcome Process(
      string OperationName, Resource Resource, IRequestMeta RequestMeta)
    {
      if (string.IsNullOrWhiteSpace(OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("PyroRequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");     
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchPrameterGeneric cannot be null.");      

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
        string Message = $"The base operation named ${OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[OperationName];
      OperationClass OperationClass = OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Base && x.Type == Op);
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
            return DeleteManyHistoryIndexesService.DeleteMany(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesSet:
          {            
            IServerSearchParameterService ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessSet(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerSearchParameterIndexReport:
          {
            IServerSearchParameterService ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessReport(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesIndex:
          {
            IServerSearchParameterService ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessIndex(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ConnectathonAnswer:
          {
            IConnectathonAnswerService ConnectathonAnswerService = ICommonFactory.CreateConnectathonAnswerService();
            return ConnectathonAnswerService.Process(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerResourceReport:
          {
            IServerResourceReportService ServerResourceReportService = ICommonFactory.CreateServerResourceReportService();
            return ServerResourceReportService.Process(RequestMeta.SearchParameterGeneric);
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
