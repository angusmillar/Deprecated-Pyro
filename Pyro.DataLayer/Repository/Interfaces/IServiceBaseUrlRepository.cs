using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.Repository.Interfaces
{
  public interface IServiceBaseUrlRepository
  {
    _ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
