using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Attributes;

namespace Pyro.Common.BackgroundTask.TaskPayload
{  
  public enum BackgroundTaskType
  {
    [EnumLiteral("HiServiceIHISearch")]
    HiServiceIHISearch,
    [EnumLiteral("PyroServerIndexing")]
    PyroServerIndexing,
  }

  public abstract class BackgroundTaskPayloadBase : IBackgroundTaskPayloadBase
  {
    public BackgroundTaskPayloadBase(BackgroundTaskType TaskType)
    {      
      this.TaskType = TaskType;
    }
    public BackgroundTaskType TaskType { get; set; }
    public string TaskId { get; set; }
  }
}
