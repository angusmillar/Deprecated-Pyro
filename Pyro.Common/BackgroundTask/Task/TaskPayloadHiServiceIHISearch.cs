using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BackgroundTask.Task
{
  public class TaskPayloadHiServiceIHISearch : BackgroundTaskPayloadBase, ITaskPayloadHiServiceIHISearch
  {
    public TaskPayloadHiServiceIHISearch(string TaskId, string PatientId) : base(TaskId, BackgroundTaskType.HiServiceIHISearch)
    {
      this.PatientId = PatientId;          
    }
    
    public string PatientId { get; set; }
    public override BackgroundTaskType TaskType { get; set; }
    public override string TaskId { get; set; }
  }
}
