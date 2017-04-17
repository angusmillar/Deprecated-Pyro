using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.Repository.Interfaces
{
  public interface ICommonRepository
  {
    ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
