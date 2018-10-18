using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BackgroundTask.TaskPayload
{
  public class TaskPayloadHiServiceIHISearch : BackgroundTaskPayloadBase, ITaskPayloadHiServiceIHISearch
  {
    public TaskPayloadHiServiceIHISearch() : base(BackgroundTaskType.HiServiceIHISearch)
    {     
    }
    
    public string PatientId { get; set; }
    //public override BackgroundTaskType TaskType { get; set; }
    //public override string TaskId { get; set; }
  }
}
