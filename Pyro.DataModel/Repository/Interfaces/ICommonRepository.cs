using Pyro.DataModel.DatabaseModel;

namespace Pyro.DataModel.Repository.Interfaces
{
  public interface ICommonRepository
  {
    ServiceRootURL_Store GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
