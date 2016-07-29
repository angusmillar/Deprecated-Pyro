using Blaze.DataModel.DatabaseModel;

namespace Blaze.DataModel.Repository.Interfaces
{
  public interface ICommonRepository
  {
    Blaze_RootUrlStore GetAndOrAddBlaze_RootUrlStore(string ServiceRootUrl);
  }
}
