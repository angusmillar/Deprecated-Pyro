using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Attributes;

namespace Pyro.Common.BackgroundTask.TaskPayload
{    
  public class BackgroundTaskPayload : IBackgroundTaskPayload
  {    
    public BackgroundTaskEnum.BackgroundTaskType TaskType { get; set; }
    public string TaskId { get; set; }
  }
}
