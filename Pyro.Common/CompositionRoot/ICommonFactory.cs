using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    //Reused objects
    IDtoRequestHeaders CreateDtoRequestHeaders();
    IFhirRequestUri CreateFhirRequestUri();
    IDtoRequestUri CreateDtoRequestUri();
    IDtoRequestUri CreateDtoRequestUri(string RequestUri);
    IDtoSearchParameterGeneric CreateDtoSearchParameterGeneric();
    ISearchParameterService CreateSearchParameterService();
    IDtoSearchParameterReferance CreateDtoSearchParameterReferance();

    //Services
    IBundleTransactionService CreateBundleTransactionService();
    IMetadataService CreateMetadataService();
    IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService();
    IServerSearchParameterService CreateServerSearchParameterService();
    IServerResourceReportService CreateServerResourceReportService();
    IFhirValidateOperationService CreateFhirValidateOperationService();

    IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService();
    IFhirBaseOperationService CreateFhirBaseOperationService();
    IFhirResourceOperationService CreateFhirResourceOperationService();
  }
}