using System.Collections.Generic;
using Pyro.Common.DtoEntity;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IBackburnerConnectionRepository
  {
    DtoBackburnerConnection AddConnectionAsConnected(string ConnectionId);
    List<DtoBackburnerConnection> GetAllConnectionListByIsConnected(bool IsConnected);
    DtoBackburnerConnection GetConnectionByConnectionId(string ConnectionId);
    bool IsConnected(string ConnectionId);
    int UpdateAllConnectedAsDisconnected();
    void UpdateAsDisconnected(string ConnectionId);
    void CleanConnections();
    int ConnectedCount();
  }
}