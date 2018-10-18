using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public abstract class BaseTaskLauncher
  {
    protected void DelayLaunch()
    {
      int MaxNumber = 30000;
      Random Ran = new Random(Guid.NewGuid().GetHashCode());
      int DelayInt = Ran.Next(0, MaxNumber);
      Common.Logging.Logger.Log.Info($"Start Delay amount :{DelayInt.ToString()}");
      Task.Delay(DelayInt).Wait();
      //System.Threading.Thread.Sleep(DelayInt);
      Common.Logging.Logger.Log.Info($"End Delay amount :{DelayInt.ToString()}");
    }
  }
}
