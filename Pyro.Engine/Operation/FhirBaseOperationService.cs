using System;
using System.Linq;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Interfaces.Operation;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.FhirOperation.DeleteHistoryIndexes;
using Pyro.Common.FhirOperation.ServerSearchParameter;
using Pyro.Common.FhirOperation.ConnectathonAnswer;
using Pyro.Common.FhirOperation.ResourceReport;
using Pyro.Common.Service.SearchParameters;

namespace Pyro.Engine.Operation
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
            IDeleteHistoryIndexesOperation DeleteManyHistoryIndexesService = ICommonFactory.CreateDeleteHistoryIndexesOperation();
            return DeleteManyHistoryIndexesService.DeleteMany(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesSet:
          {
            IServerSearchParameterOperation ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessSet(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerSearchParameterIndexReport:
          {
            IServerSearchParameterOperation ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessReport(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerIndexesIndex:
          {
            IServerSearchParameterOperation ServerSearchParameterService = IServerSearchParameterServiceFactory.CreateServerSearchParameterService();
            return ServerSearchParameterService.ProcessIndex(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ConnectathonAnswer:
          {
            IConnectathonAnswerOperation ConnectathonAnswerService = ICommonFactory.CreateConnectathonAnswerOperation();
            return ConnectathonAnswerService.Process(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Resource);
          }
        case FhirOperationEnum.OperationType.ServerResourceReport:
          {
            IResourceReportOperation ServerResourceReportService = ICommonFactory.CreateResourceReportOperation();
            return ServerResourceReportService.Process(RequestMeta.SearchParameterGeneric);
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
