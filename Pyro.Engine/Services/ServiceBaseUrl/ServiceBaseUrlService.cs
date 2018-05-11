using Pyro.Common.ServiceRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.Services.ServiceBaseUrl
{
  public class ServiceBaseUrlService : IServicePrimaryBaseUrlService
  {
    private readonly IServicePrimaryBaseUrlRepository IServicePrimaryBaseUrlRepository;

    public ServiceBaseUrlService(IServicePrimaryBaseUrlRepository IServicePrimaryBaseUrlRepository)       
    {
      this.IServicePrimaryBaseUrlRepository = IServicePrimaryBaseUrlRepository;
    }

    public IDtoRootUrlStore GetPrimaryServiceRootUrl()
    {
      return IServicePrimaryBaseUrlRepository.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      return IServicePrimaryBaseUrlRepository.SetPrimaryRootUrlStore(RootUrl);
    }
  }
}
