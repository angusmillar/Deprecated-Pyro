using AutoMapper;
using Hl7.Fhir.Utility;
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
  public class FhirTaskQueueRepository : BaseRepository, IFhirTaskQueueRepository
  {
    private readonly IMapper IMapper;

    public FhirTaskQueueRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoFhirTaskQueue GetFhirTaskQueueByFhirTaskIdAndTypeWhereNoPerformer(string FhirTaskId, string TaskType)
    {
      _FhirTaskQueue DbFhirTaskQueue = IPyroDbContext.FhirTaskQueue.SingleOrDefault(x => x.TaskFhirId == FhirTaskId & x.TaskType == TaskType & x.PerfomrerConnectionId == null);
      if (DbFhirTaskQueue != null)
      {
        return IMapper.Map<DtoFhirTaskQueue>(DbFhirTaskQueue);
      }
      return null;
    }

    /// <summary>
    /// Gets records for the given type where the status is Ready or In-Progress
    /// </summary>
    /// <param name="TaskType"></param>
    /// <param name="BatchSize"></param>
    /// <returns></returns>
    public List<DtoFhirTaskQueue> GetPendingQueueList(BackgroundTaskType TaskType, int BatchSize)
    {
      string TaskTypeString = TaskType.GetPyroLiteral();
      string TaskStatusReady = Hl7.Fhir.Model.Task.TaskStatus.Ready.GetLiteral();
      string TaskStatusInProgress = Hl7.Fhir.Model.Task.TaskStatus.InProgress.GetLiteral();
      var DbFhirTaskQueueList = IPyroDbContext.FhirTaskQueue.Where(x => x.TaskType == TaskTypeString & (x.Status == TaskStatusReady | x.Status == TaskStatusInProgress))
        .OrderBy(y => y.CreatedDate).Take(BatchSize);

      return IMapper.Map<List<DtoFhirTaskQueue>>(DbFhirTaskQueueList);
    }

    public DtoFhirTaskQueue AddFhirTaskQueue(DtoFhirTaskQueue DtoFhirTaskQueue)
    {
      _FhirTaskQueue DbFhirTaskQueue = IMapper.Map<_FhirTaskQueue>(DtoFhirTaskQueue);
      var DateTimeNow = Common.Tools.DateTimeSupport.UTCDateTimeNow();
      DbFhirTaskQueue.CreatedDate = DateTimeNow;
      DbFhirTaskQueue.CreatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      DbFhirTaskQueue.LastUpdated = DateTimeNow;
      DbFhirTaskQueue.LastUpdatedUser = Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      DbFhirTaskQueue = IPyroDbContext.Set<_FhirTaskQueue>().Add(DbFhirTaskQueue);
      this.Save();
      return IMapper.Map<DtoFhirTaskQueue>(DbFhirTaskQueue);
    }

    public int RemovePerfomrerConnectionIdFromQueueItemsByStatus(string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      string Query = string.Empty;
      string TaskStatusString = TaskStatus.GetLiteral();
      string LastUpdatedString = string.Empty;
      if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
      {
        LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat();
        Query = $"UPDATE [_FhirTaskQueue] SET [PerfomrerConnectionId] = null, [LastUpdated] = '{LastUpdatedString}' " +
                $"WHERE [PerfomrerConnectionId] = '{ConnectionId}' and [Status] = '{TaskStatusString}'";
      }
      else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
      {
        LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat();
        Query = $"UPDATE public.\"_FhirTaskQueue\" SET \"PerfomrerConnectionId\" = null, \"LastUpdated\" = '{LastUpdatedString}' " +
                $"WHERE \"PerfomrerConnectionId\" = '{ConnectionId}' and \"Status\" = '{TaskStatusString}'";
      }
      return IPyroDbContext.Database.ExecuteSqlCommand(Query);
    }

    public int ClearConnectionIdFromAllNonCompletedQueueItems()
    {
      string Query = string.Empty;
      string TaskStatusCompletedString = Hl7.Fhir.Model.Task.TaskStatus.Completed.GetLiteral();
      string LastUpdatedString = string.Empty;
      if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
      {
        LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat();
        Query = $"UPDATE [_FhirTaskQueue] SET [PerfomrerConnectionId] = null, [LastUpdated] = '{LastUpdatedString}' " +
                $"WHERE [PerfomrerConnectionId] IS NOT NULL and NOT [Status] = '{TaskStatusCompletedString}'";
      }
      else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
      {
        LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat();
        Query = $"UPDATE public.\"_FhirTaskQueue\" SET \"PerfomrerConnectionId\" = null, \"LastUpdated\" = '{LastUpdatedString}' " +
                $"WHERE \"PerfomrerConnectionId\" IS NOT NULL and NOT \"Status\" = '{TaskStatusCompletedString}'";
      }
      return IPyroDbContext.Database.ExecuteSqlCommand(Query);
    }



    public bool AttemptToUpdateFhirTaskQueueStatus(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      int UpdateCount = 0;      
      _FhirTaskQueue DbFhirTaskQueue = IPyroDbContext.FhirTaskQueue.SingleOrDefault(x => x.TaskFhirId == FhirTaskId & x.TaskType == TaskType & x.PerfomrerConnectionId == ConnectionId);
      if (DbFhirTaskQueue != null)
      {
        string Query = string.Empty;
        string TaskStatusString = TaskStatus.GetLiteral();
        string LastUpdatedString = string.Empty;
        if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
        {
          LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat();
          Query = $"UPDATE [_FhirTaskQueue] SET [Status] = '{TaskStatusString}', [LastUpdated] = '{LastUpdatedString}' " +
                  $"WHERE [Id] = {DbFhirTaskQueue.Id} and [PerfomrerConnectionId] = '{ConnectionId}'";
        }
        else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
        {
          LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat();
          Query = $"UPDATE public.\"_FhirTaskQueue\" SET \"Status\" = '{TaskStatusString}' , \"LastUpdated\" = '{LastUpdatedString}' " +
                  $"WHERE \"Id\" = {DbFhirTaskQueue.Id} and \"PerfomrerConnectionId\" = '{ConnectionId}'";
        }

        UpdateCount = IPyroDbContext.Database.ExecuteSqlCommand(Query);
      }
      return (UpdateCount == 1);
    }

    public bool AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      int UpdateCount = 0;
      //Try and get it with performer == null
      _FhirTaskQueue DbFhirTaskQueue = IPyroDbContext.FhirTaskQueue.SingleOrDefault(x => x.TaskFhirId == FhirTaskId & x.TaskType == TaskType & x.PerfomrerConnectionId == null);
      if (DbFhirTaskQueue != null)
      {
        //Perform a an update with a where cause of PerfomrerConnectionId = null. If another thread has updated between the Read above and the Update
        //here then this will not update as PerfomrerConnectionId will not be null. So the count will be zero.
        //Therefore we return false to tell the caller they lost the race condition 
        //EF can not do this style of Update with a Where cause so we revert to a basic SQL query
        string Query = string.Empty;
        string TaskStatusString = TaskStatus.GetLiteral();
        string LastUpdatedString = string.Empty;
        if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.MicrosoftSQLServerProvider)
        {
          LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowMSSQLFormat();
          Query = $"UPDATE [_FhirTaskQueue] SET [PerfomrerConnectionId] = '{ConnectionId}', [Status] = '{TaskStatusString}', [LastUpdated] = '{LastUpdatedString}' " +
                  $"WHERE [Id] = {DbFhirTaskQueue.Id} and [PerfomrerConnectionId] is null";
        }
        else if (DatabaseConnection.CurrentProviderName() == DatabaseConnection.PostgreSQLProvider)
        {
          LastUpdatedString = Common.Tools.DateTimeSupport.UTCDateTimeNowPostgreFormat();
          Query = $"UPDATE public.\"_FhirTaskQueue\" SET \"PerfomrerConnectionId\" = '{ConnectionId}', \"Status\" = '{TaskStatusString}' , \"LastUpdated\" = '{LastUpdatedString}' " +
                  $"WHERE \"Id\" = {DbFhirTaskQueue.Id} and \"PerfomrerConnectionId\" is null";
        }

        UpdateCount = IPyroDbContext.Database.ExecuteSqlCommand(Query);
      }
      if (UpdateCount == 1)
        return true;
      else
        return false;
    }

  }


}
