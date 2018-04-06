using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Pyro.WebApi.SignalRHub
{
  [HubName("BroadcastHub")]
  public class BroadcastHub : Hub
  {
    private readonly Broadcaster _broadcaster = Broadcaster.Instance;
    
    public override System.Threading.Tasks.Task OnConnected()
    {
      if (Context != null)
        System.Console.WriteLine($"Pyro Backburner service connected Id: {Context.ConnectionId}");     
      return base.OnConnected();
    }

    public override Task OnDisconnected(bool stopCalled)
    {
      if (Context != null)
      {
        if (stopCalled)
        {
          System.Console.WriteLine($"Pyro Backburner service client has disconnected gracefully");
          System.Console.WriteLine($"Client Id: {Context.ConnectionId}");
        }
        else
        {
          System.Console.WriteLine($"Pyro Backburner service has lost connection to this server");
          System.Console.WriteLine($"Client Id: {Context.ConnectionId}");
        }
      }
        
      return base.OnDisconnected(stopCalled);
    }

  }
}