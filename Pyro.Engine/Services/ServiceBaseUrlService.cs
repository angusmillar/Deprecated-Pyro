using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.Services
{
  public class ServiceBaseUrlService : BaseServices, IServicePrimaryBaseUrlService
  {
    private readonly IServicePrimaryBaseUrlRepository IServicePrimaryBaseUrlRepository;
    public ServiceBaseUrlService(IUnitOfWork IUnitOfWork, IServicePrimaryBaseUrlRepository IServicePrimaryBaseUrlRepository) 
      : base(IUnitOfWork)
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
