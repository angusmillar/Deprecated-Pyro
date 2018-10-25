using AutoMapper;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;
using Pyro.Common.Global;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.Entity;
using System.Collections.Generic;
using System.Linq;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.DataLayer.Repository
{
  public class FhirTaskWorkerRepository : BaseRepository, IFhirTaskWorkerRepository
  {
    private readonly IMapper IMapper;

    public FhirTaskWorkerRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskType TaskType)
    {
      string TaskTypeString = TaskType.GetPyroLiteral();
      _FhirTaskWorker DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.SingleOrDefault(x => x.TaskType == TaskTypeString);
      if (DbFhirTaskWorker != null)
      {
        return IMapper.Map<DtoFhirTaskWorker>(DbFhirTaskWorker);
      }
      return null;
    }

    public DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskType TaskType, bool IsClaimed)
    {
      _FhirTaskWorker DbFhirTaskWorker;
      string TaskTypeString = TaskType.GetPyroLiteral();
      if (IsClaimed)
      {
        DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.Single(x => x.TaskType == TaskTypeString & x.ClaimedBy != null);
      }
      else
      {
        DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.Single(x => x.TaskType == TaskTypeString & x.ClaimedBy == null);
      }
      if (DbFhirTaskWorker != null)
      {
        return IMapper.Map<DtoFhirTaskWorker>(DbFhirTaskWorker);
      }
      else
      {
        return null;
      }
    }

    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList(string ConnectionId)
    {
      List<_FhirTaskWorker> DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.Where(x => x.ClaimedBy == ConnectionId).ToList();      
      return IMapper.Map<List<DtoFhirTaskWorker>>(DbFhirTaskWorker);              
    }

    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList(bool AreClaimed)
    {
      List<_FhirTaskWorker> DbFhirTaskWorker;
      if (AreClaimed)
      {
        DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.Where(x => x.ClaimedBy != null).ToList();
      }
      else
      {
        DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.Where(x => x.ClaimedBy == null).ToList();
      }      
      return IMapper.Map<List<DtoFhirTaskWorker>>(DbFhirTaskWorker);
    }

    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList()
    {
      List<_FhirTaskWorker> DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.ToList();
      return IMapper.Map<List<DtoFhirTaskWorker>>(DbFhirTaskWorker);
    }

    public DtoFhirTaskWorker AddFhirTaskWorker(DtoFhirTaskWorker DtoFhirTaskWorker)
    {      
      _FhirTaskWorker DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.SingleOrDefault(x => x.TaskType == DtoFhirTaskWorker.TaskType);
      if (DbFhirTaskWorker == null)
      {
        DbFhirTaskWorker = IMapper.Map<_FhirTaskWorker>(DtoFhirTaskWorker);

        var DateTimeNow = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        DbFhirTaskWorker.CreatedDate = DateTimeNow;
        DbFhirTaskWorker.CreatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        DbFhirTaskWorker.LastUpdated = DateTimeNow;
        DbFhirTaskWorker.LastUpdatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        DbFhirTaskWorker.ClaimedBy = null;
        DbFhirTaskWorker = IPyroDbContext.Set<_FhirTaskWorker>().Add(DbFhirTaskWorker);
        this.Save();
        return IMapper.Map<DtoFhirTaskWorker>(DbFhirTaskWorker);
      }
      else
      {
        throw new System.ApplicationException($"Internal Server Error: Attempt to add a new FhirTaskWorker which was al ready present. FhirTaskWorker was of type {DtoFhirTaskWorker.TaskType}. ");
      }
    }

    public bool AttemptToUnClaim(BackgroundTaskType TaskType, string ConnectionId)
    {      
      int UpdateCount = 0;
      string Query = string.Empty;
      if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
      {
        Query = $"UPDATE [_FhirTaskWorker] SET [ClaimedBy] = null, [LastUpdated] = '{Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat()}' " +
                $"WHERE [TaskType] = '{TaskType.GetPyroLiteral()}' and [ClaimedBy] = '{ConnectionId}'";
      }
      else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
      {
        Query = $"UPDATE public.\"_FhirTaskWorker\" SET \"ClaimedBy\" = null, \"LastUpdated\" = '{Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat()}' " +
                $"WHERE \"TaskType\" = '{TaskType.GetPyroLiteral()}' and \"ClaimedBy\" = '{ConnectionId}'";
      }
      UpdateCount = IPyroDbContext.Database.ExecuteSqlCommand(Query);
      return (UpdateCount == 1);
    }

    public bool ForceUnClaimForType(BackgroundTaskType TaskType)
    {
      int UpdateCount = 0;
      string Query = string.Empty;
      if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
      {
        Query = $"UPDATE [_FhirTaskWorker] SET [ClaimedBy] = null, [LastUpdated] = '{Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat()}' " +
                $"WHERE [TaskType] = '{TaskType.GetPyroLiteral()}'";
      }
      else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
      {
        Query = $"UPDATE public.\"_FhirTaskWorker\" SET \"ClaimedBy\" = null, \"LastUpdated\" = '{Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat()}' " +
                $"WHERE \"TaskType\" = '{TaskType.GetPyroLiteral()}'";
      }
      UpdateCount = IPyroDbContext.Database.ExecuteSqlCommand(Query);
      return (UpdateCount == 1);
    }

    public bool AttemptToClaim(BackgroundTaskType TaskType, string ConnectionId)
    {
      int UpdateCount = 0;      
      string Query = string.Empty;
      if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
      {
        Query = $"UPDATE [_FhirTaskWorker] SET [ClaimedBy] = '{ConnectionId}', [LastUpdated] = '{Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat()}' " +
                $"WHERE [TaskType] = '{TaskType.GetPyroLiteral()}' and [ClaimedBy] is null";
      }
      else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
      {
        Query = $"UPDATE public.\"_FhirTaskWorker\" SET \"ClaimedBy\" = '{ConnectionId}', \"LastUpdated\" = '{Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat()}' " +
                $"WHERE \"TaskType\" = '{TaskType.GetPyroLiteral()}' and \"ClaimedBy\" is null";
      }
      UpdateCount = IPyroDbContext.Database.ExecuteSqlCommand(Query);
      return (UpdateCount == 1);
    }    

    public void DeleteFhirTaskWorker(BackgroundTaskType TaskType)
    {
      string TaskTypeString = TaskType.GetPyroLiteral();
      _FhirTaskWorker DbFhirTaskWorker = IPyroDbContext.FhirTaskWorker.SingleOrDefault(x => x.TaskType == TaskTypeString);
      if (DbFhirTaskWorker != null)
      {
        if (DbFhirTaskWorker.ClaimedBy == null)
        {
          IPyroDbContext.FhirTaskWorker.Remove(DbFhirTaskWorker);
          this.Save();
        }
        else
        {
          throw new System.ApplicationException($"Attempt to delete FhirTaskWorker of type: {DbFhirTaskWorker.TaskType} where the instance is claimed by the connection Id: {DbFhirTaskWorker.ClaimedBy}. FhirTaskWorker was not deleted. ");
        }        
      }
    }

  }


}
