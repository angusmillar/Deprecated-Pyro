using Pyro.Backburner.Tools;
using Pyro.Common.BackgroundTask.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Backburner.ServiceTask.HiService
{
  public class IhiSearchService : IIhiSearchService
  {
    private readonly IOtherThing IOtherThing;
    public IhiSearchService(IOtherThing IOtherThing)
    {
      this.IOtherThing = IOtherThing;
    }
    public void DoSomthing(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      ConsoleSupport.ConsoleWriteLine($"Task Sleeep 10 Sec");
      IOtherThing.Thing();
      System.Threading.Thread.Sleep(10000);
      ConsoleSupport.ConsoleWriteLine($"In the task");
      ConsoleSupport.ConsoleWriteLine($"Task Recived: Hi Service IHI Search ");
      ConsoleSupport.ConsoleWriteLine($"HI Test PayloadId: {TaskPayloadHiServiceIHISearch.Payloadid}");
      ConsoleSupport.ConsoleWriteLine($"HI Test PatientId: {TaskPayloadHiServiceIHISearch.PatientId}");
      ConsoleSupport.ConsoleWriteLine($"HI Test TaskId: {TaskPayloadHiServiceIHISearch.TaskId}");
     // throw new NullReferenceException("My exception ANgus");
    }
  }
}
