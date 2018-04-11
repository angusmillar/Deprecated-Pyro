using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Pyro.WebApi.SignalRHub
{
  [HubName("BroadcastHub")]
  public class BroadcastHub : Hub
  {
    private readonly Broadcaster _broadcaster = Broadcaster.Instance;
    
    public override Task OnConnected()
    {
      if (Context != null)
      {        
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}: Pyro Backburner service connected:");
        Console.WriteLine($" - Client connection Id: {Context.ConnectionId}");
      }
      return base.OnConnected();
    }

    public override Task OnDisconnected(bool stopCalled)
    {
      if (Context != null)
      {
        if (stopCalled)
        {          
          Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}: Pyro Backburner service client has disconnected gracefully");
          Console.WriteLine($"Client Id: {Context.ConnectionId}");
        }
        else
        {
          Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}: Pyro Backburner service has lost connection to this server");
          Console.WriteLine($"Client Id: {Context.ConnectionId}");
        }
      }
        
      return base.OnDisconnected(stopCalled);
    }

  }
}