using System;
using System.Linq;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Interfaces.Operation;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation;
using Pyro.Common.CompositionRoot;
using Hl7.Fhir.Model;
using Pyro.Common.RequestMetadata;
using Pyro.Common.FhirOperation.IhiSearch;
using Pyro.Common.FhirOperation.Validate;
using Pyro.Common.FhirOperation.DeleteHistoryIndexes;
using Pyro.Common.Service.SearchParameters;

namespace Pyro.Engine.Operation
{
  //[base]/[Resource]/$some-operation
  public class FhirResourceOperationService : IFhirResourceOperationService
  {
    private readonly ICommonFactory ICommonFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;

    public FhirResourceOperationService(ICommonFactory ICommonFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory)
    {
      this.ICommonFactory = ICommonFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
    }

    public IResourceServiceOutcome Process(string OperationName, Resource Resource, IRequestMeta RequestMeta)
    {
      if (string.IsNullOrWhiteSpace(OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri== null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (ICommonFactory == null)
        throw new NullReferenceException("ICommonFactory cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

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
      if (!OperationDic.ContainsKey(Pyro.Common.Tools.StringSupport.ToLowerFast(OperationName)))
      {
        string Message = $"The resource operation named ${OperationName} is not supported by the server.";
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Error, Hl7.Fhir.Model.OperationOutcome.IssueType.NotSupported, Message);
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }

      var Op = OperationDic[Pyro.Common.Tools.StringSupport.ToLowerFast(OperationName)];
      OperationClass OperationClass = OperationClassFactory.OperationClassList.SingleOrDefault(x => x.Scope == FhirOperationEnum.OperationScope.Resource && x.Type == Op);
      if (OperationClass == null)
      {
        string Message = $"The resource operation named ${OperationName} is not supported by the server as a resource service operation type.";
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
            IDeleteHistoryIndexesOperation DeleteManyHistoryIndexesOperation = ICommonFactory.CreateDeleteHistoryIndexesOperation();
            return DeleteManyHistoryIndexesOperation.DeleteSingle(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric);
          }
        case FhirOperationEnum.OperationType.Validate:
          {
            IFhirValidateOperation FhirValidateOperation = ICommonFactory.CreateFhirValidateOperation();
            return FhirValidateOperation.ValidateResource(OperationClass, Resource, RequestMeta);
          }
        case FhirOperationEnum.OperationType.xIHISearchOrValidate:
          {
            IIHISearchOrValidateOperation IHISearchOrValidateOperation = ICommonFactory.CreateIHISearchOrValidateOperation();
            return IHISearchOrValidateOperation.IHISearchOrValidate(OperationClass, Resource, RequestMeta);
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(OperationClass.Type.GetPyroLiteral(), (int)OperationClass.Type, typeof(FhirOperationEnum.OperationType));
      }
    }
  }
}
