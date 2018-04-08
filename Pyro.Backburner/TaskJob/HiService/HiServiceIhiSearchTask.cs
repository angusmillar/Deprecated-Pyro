using Pyro.Common.BackgroundTask.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pyro.Backburner.Tools;


namespace Pyro.Backburner.TaskJob.HiService
{
  public class HiServiceIhiSearchTask
  {
    public static string TaskName = "Hi Service IHI Search";
    public void Process(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      //An exception thrown inside the DoWork task will not buble out to here and
      //must therefore be handled in the DoWork task
      Task task = Task.Factory.StartNew(() => DoWork(TaskPayloadHiServiceIHISearch));
     
      ConsoleSupport.ConsoleWriteLine($"Post the task");
    }

    private void DoWork(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      try
      {
        ConsoleSupport.ConsoleWriteLine($"Task Sleeep 10 Sec");
        Thread.Sleep(10000);
        ConsoleSupport.ConsoleWriteLine($"In the task");
        ConsoleSupport.ConsoleWriteLine($"Task Recived: Hi Service IHI Search ");
        ConsoleSupport.ConsoleWriteLine($"HI Test PayloadId: {TaskPayloadHiServiceIHISearch.Payloadid}");
        ConsoleSupport.ConsoleWriteLine($"HI Test PatientId: {TaskPayloadHiServiceIHISearch.PatientId}");
        ConsoleSupport.ConsoleWriteLine($"HI Test TaskId: {TaskPayloadHiServiceIHISearch.TaskId}");
        throw new NullReferenceException("My exception ANgus");
      }
      catch(Exception exec)
      {
        ConsoleSupport.ConsoleWriteLine(exec.Message);
      }
      throw new NullReferenceException("My exception ANgus");
    }
  }
}
