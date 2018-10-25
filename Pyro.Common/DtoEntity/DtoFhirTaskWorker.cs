using System;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Common.DtoEntity
{
  public class DtoFhirTaskWorker : DtoConfigEntityBase
  {    
    public BackgroundTaskType GetTaskType()
    {
      BackgroundTaskType Temp;
      if (System.Enum.TryParse(this.TaskType, out Temp))
      {
        return Temp;
      }
      else
      {
        throw new FormatException($"Internal Server Error: DtoFhirTaskWorker's TaskType string was not equal to a BackgroundTaskType Enum.");
      }      
    }
    public string TaskType { get; set; }
    public string ClaimedBy { get; set; }
  }
}
