using Blaze.DataModel.DatabaseModel;

namespace Blaze.DataModel.Repository.Interfaces
{
  public interface ICommonRepository
  {
    ServiceRootURL_Store GetAndOrAddService_RootUrlStore(string ServiceRootUrl);
  }
}
