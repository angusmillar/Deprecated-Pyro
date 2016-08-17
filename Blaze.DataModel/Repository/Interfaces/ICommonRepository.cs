using Blaze.DataModel.DatabaseModel;

namespace Blaze.DataModel.Repository.Interfaces
{
  public interface ICommonRepository
  {
    ServiceRootURL_Store GetAndOrAddBlaze_RootUrlStore(string ServiceRootUrl);
  }
}
