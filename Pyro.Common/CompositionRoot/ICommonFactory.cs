using Hl7.Fhir.Specification.Source;
using Pyro.Common.Service;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    //Reused objects
    IRequestHeader CreateDtoRequestHeaders();
    IPyroFhirUri CreateFhirRequestUri();
    IPyroRequestUri CreateDtoRequestUri();
    IPyroRequestUri CreateDtoRequestUri(string RequestUri);
    ISearchParameterGeneric CreateDtoSearchParameterGeneric();
    ISearchParameterService CreateSearchParameterService();
    ISearchParametersServiceOutcome CreateSearchParametersServiceOutcome();
    ISearchParameterReferance CreateDtoSearchParameterReferance();
    IDtoRootUrlStore CreateDtoRootUrlStore();
    IDatabaseOperationOutcome CreateDatabaseOperationOutcome();
    IResourceServiceOutcome CreateResourceServiceOutcome();
    IHtmlGenerationSupport CreateFhirNarativeGenerationSupport();

    //Services
    IBundleTransactionService CreateBundleTransactionService();
    IMetadataService CreateMetadataService();
    IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService();
    IServerSearchParameterService CreateServerSearchParameterService();
    IServerResourceReportService CreateServerResourceReportService();
    IFhirValidateOperationService CreateFhirValidateOperationService();
    IConnectathonAnswerService CreateConnectathonAnswerService();

    IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService();
    IFhirBaseOperationService CreateFhirBaseOperationService();
    IFhirResourceOperationService CreateFhirResourceOperationService();

    List<IResourceResolver> CreateResourceResolverList();



  }
}