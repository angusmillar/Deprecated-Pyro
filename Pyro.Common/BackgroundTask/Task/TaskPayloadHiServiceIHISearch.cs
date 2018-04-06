using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BackgroundTask.Task
{
  public class TaskPayloadHiServiceIHISearch : BackgroundTaskPayloadBase, ITaskPayloadHiServiceIHISearch
  {
    public TaskPayloadHiServiceIHISearch(string PatientId, string TaskId) : base()
    {
      this.PatientId = PatientId;
      this.TaskId = TaskId;
    }

    public string PatientId { get; set; }
    public string TaskId { get; set; }
    public override string Payloadid { get; set; }
  }
}
