using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Interfaces.Service
{ 
  public interface IServicePrimaryBaseUrlService
  {
    IDtoRootUrlStore GetPrimaryServiceRootUrl();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}