using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    IDtoRequestHeaders CreateDtoRequestHeaders();
    IFhirRequestUri CreateFhirRequestUri();
    IDtoRequestUri CreateDtoRequestUri();
    IDtoRequestUri CreateDtoRequestUri(string RequestUri);
    IDtoSearchParameterGeneric CreateDtoSearchParameterGeneric();

    IBundleTransactionService CreateBundleTransactionService();
    IMetadataService CreateMetadataService();
  }
}