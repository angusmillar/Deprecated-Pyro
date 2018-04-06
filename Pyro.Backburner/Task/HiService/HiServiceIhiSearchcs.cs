using Pyro.Common.BackgroundTask.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Backburner.Tools;

namespace Pyro.Backburner.Task.HiService
{
  public class HiServiceIhiSearchcs
  {
    public static string TaskName = "Hi Service IHI Search";
    public void Process(TaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      ConsoleSupport.ConsoleWriteLine($"Task Recived: Hi Service IHI Search ");
      ConsoleSupport.ConsoleWriteLine($"HI Test PayloadId: {TaskPayloadHiServiceIHISearch.Payloadid}");
      ConsoleSupport.ConsoleWriteLine($"HI Test PatientId: {TaskPayloadHiServiceIHISearch.PatientId}");
      ConsoleSupport.ConsoleWriteLine($"HI Test TaskId: {TaskPayloadHiServiceIHISearch.TaskId}");
  }
}
}
