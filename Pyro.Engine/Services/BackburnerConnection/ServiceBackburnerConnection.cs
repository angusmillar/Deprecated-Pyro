using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.DtoEntity;
using System.Collections.Generic;

namespace Pyro.Engine.Services.BackburnerConnection
{
  public class ServiceBackburnerConnection : IServiceBackburnerConnection
  {
    private readonly IBackburnerConnectionRepository IBackburnerConnectionRepository;

    public ServiceBackburnerConnection(IBackburnerConnectionRepository IBackburnerConnectionRepository)       
    {
      this.IBackburnerConnectionRepository = IBackburnerConnectionRepository;
    }

    public DtoBackburnerConnection AddConnectionAsConnected(string ConnectionId)
    {
      return IBackburnerConnectionRepository.AddConnectionAsConnected(ConnectionId);
    }

    public List<DtoBackburnerConnection> GetAllConnectionListByIsConnected(bool IsConnected)
    {
      return IBackburnerConnectionRepository.GetAllConnectionListByIsConnected(IsConnected);
    }

    public DtoBackburnerConnection GetConnectionByConnectionId(string ConnectionId)
    {
      return IBackburnerConnectionRepository.GetConnectionByConnectionId(ConnectionId);
    }

    public bool IsConnected(string ConnectionId)
    {
      return IBackburnerConnectionRepository.IsConnected(ConnectionId);
    }

    public int UpdateAllConnectedAsDisconnected()
    {
      return IBackburnerConnectionRepository.UpdateAllConnectedAsDisconnected();
    }

    public void UpdateAsDisconnected(string ConnectionId)
    {
      IBackburnerConnectionRepository.UpdateAsDisconnected(ConnectionId);
    }

    public void CleanConnections()
    {
      IBackburnerConnectionRepository.CleanConnections();
    }

    public int ConnectedCount()
    {
      return IBackburnerConnectionRepository.ConnectedCount();
    }

  }
}
