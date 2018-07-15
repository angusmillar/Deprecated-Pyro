using Pyro.Common.ServiceRoot;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.Repository.Interfaces
{
  public interface IServiceBaseUrlRepository
  {
    IDtoRootUrlStore GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
