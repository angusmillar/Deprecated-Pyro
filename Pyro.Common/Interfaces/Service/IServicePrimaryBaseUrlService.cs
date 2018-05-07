using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{ 
  public interface IServicePrimaryBaseUrlService
  {
    IDtoRootUrlStore GetPrimaryServiceRootUrl();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}