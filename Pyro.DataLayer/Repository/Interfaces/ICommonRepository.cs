using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.Repository.Interfaces
{
  public interface ICommonRepository
  {
    _ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
