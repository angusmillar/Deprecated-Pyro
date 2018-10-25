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
        //Note that the Backburner instance updated the database that it is connected, not the FHIR Server here
        //The FHIR Server only updates on disconnect, this save the server resource slightly and ensures the backburner
        //instance only begins work when it is connected, not when the server things it is connected. Its a small thing but feels correct.       
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
        UpdateConnectionInDatabase(Context.ConnectionId);
      }        
      return base.OnDisconnected(stopCalled);
    }

    private void UpdateConnectionInDatabase(string ConnectionId)
    {
      Pyro.WebApi.App_Start.BackburnerConectionDisconnectedUpdateDatabase.RunTask(Startup.HttpConfiguration.DependencyResolver, ConnectionId);            
    }



  }
}