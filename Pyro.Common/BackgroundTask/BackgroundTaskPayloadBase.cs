using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Attributes;

namespace Pyro.Common.BackgroundTask
{  
  public enum BackgroundTaskType
  {
    [EnumLiteral("HiServiceIHISearch")]
    HiServiceIHISearch,
  }

  public abstract class BackgroundTaskPayloadBase : IBackgroundTaskPayloadBase
  {
    public BackgroundTaskPayloadBase(string TaskId, BackgroundTaskType TaskType)
    {
      this.TaskId = TaskId;
      this.TaskType = TaskType;
    }
    public abstract BackgroundTaskType TaskType { get; set; }
    public abstract string TaskId { get; set; }
  }
}
