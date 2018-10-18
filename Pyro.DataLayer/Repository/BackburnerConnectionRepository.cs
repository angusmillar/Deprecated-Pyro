using Pyro.DataLayer.DbModel.Entity;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using AutoMapper;
using Pyro.Common.DtoEntity;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.DataLayer.Repository
{
  public class BackburnerConnectionRepository : BaseRepository, IBackburnerConnectionRepository
  {
    private readonly IMapper IMapper;

    public BackburnerConnectionRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoBackburnerConnection GetConnectionByConnectionId(string ConnectionId)
    {
      _BackburnerConnection DbBackburnerConnection = IPyroDbContext.BackburnerConnection.SingleOrDefault(x => x.ConnectionId == ConnectionId);
      if (DbBackburnerConnection != null)
      {
        return IMapper.Map<DtoBackburnerConnection>(DbBackburnerConnection);
      }
      return null;
    }
    
    public List<DtoBackburnerConnection> GetAllConnectionListByIsConnected(bool IsConnected)
    {
      List<_BackburnerConnection> DbBackburnerConnectionList = IPyroDbContext.BackburnerConnection.Where(x => x.IsConnected == IsConnected).ToList();
      if (DbBackburnerConnectionList != null)
      {
        return IMapper.Map<List<DtoBackburnerConnection>>(DbBackburnerConnectionList);
      }
      return null;
    }

    public bool IsConnected(string ConnectionId)
    {
      return IPyroDbContext.BackburnerConnection.Any(x => x.ConnectionId == ConnectionId & x.IsConnected == true);
    }

    public int ConnectedCount()
    {
      return IPyroDbContext.BackburnerConnection.Count(x => x.IsConnected == true);
    }

    public DtoBackburnerConnection AddConnectionAsConnected(string ConnectionId)
    {
      var DateTimeNow = Common.Tools.DateTimeSupport.UTCDateTimeNow(); ;
      _BackburnerConnection DbBackburnerConnection = new _BackburnerConnection()
      {
        ConnectionId = ConnectionId,
        CreatedDate = DateTimeNow,
        CreatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User,
        LastUpdated = DateTimeNow,
        LastUpdatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User,
        IsConnected = true
      };

      DbBackburnerConnection = IPyroDbContext.Set<_BackburnerConnection>().Add(DbBackburnerConnection);      
      this.Save();
      return IMapper.Map<DtoBackburnerConnection>(DbBackburnerConnection);      
    }

    public void UpdateAsDisconnected(string ConnectionId)
    {
      _BackburnerConnection DbBackburnerConnection = IPyroDbContext.BackburnerConnection.SingleOrDefault(x => x.ConnectionId == ConnectionId);
      if (DbBackburnerConnection != null)
      {
        DbBackburnerConnection.IsConnected = false;
        DbBackburnerConnection.LastUpdated = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        DbBackburnerConnection.LastUpdatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        this.Save();
      }
      else
      {
        throw new System.NullReferenceException($"No _BackburnerConnection found with the ConnectionId of: {ConnectionId}.");
      }
           
    }

    public int UpdateAllConnectedAsDisconnected()
    {
      int Counter = 0;
      var DbBackburnerConnectionList = IPyroDbContext.BackburnerConnection.Where(x => x.IsConnected == true);
      foreach(var DbBackburnerConnection in DbBackburnerConnectionList)
      {
        Counter++;
        DbBackburnerConnection.IsConnected = false;
        DbBackburnerConnection.LastUpdated = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        DbBackburnerConnection.LastUpdatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      }
      this.Save();
      return Counter;
    }

    public void CleanConnections()
    {
      var DaysBack = new System.TimeSpan(2, 0, 0, 0); //2 day      
      System.DateTime CompaireDateTime = Common.Tools.DateTimeSupport.UTCDateTimeNow().Subtract(DaysBack);
      var DbBackburnerConnectionList = IPyroDbContext.BackburnerConnection.Where(x => x.IsConnected == false & x.LastUpdated < CompaireDateTime);
      IPyroDbContext.BackburnerConnection.RemoveRange(DbBackburnerConnectionList);
      this.Save();
    }
  }


}
