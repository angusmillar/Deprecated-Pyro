using Microsoft.AspNet.SignalR.Client;
//using Hl7.Fhir.Rest;
using System;
using System.Threading;
using Pyro.Common.BackgroundTask.Task;
using Pyro.Common.BackgroundTask;
using Pyro.Common.Enum;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Pyro.Backburner.ServiceTaskLaunch;
using Pyro.Backburner.ServiceTask;
using System.Threading.Tasks;
using Pyro.Backburner.Tools;

namespace Pyro.Backburner.Service
{
  public class MainService
  {
    private HubConnection hubConnection;
    private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000 * 5); //5 secs
    private readonly TimeSpan _StartupDelay = TimeSpan.FromMilliseconds(1000 * 1); //1 sec
    private Timer _timer;
    private string PyroServerConnectionUrl = string.Empty;
    private Container Container;

    public MainService()
    {
    }

    public void Start()
    {
      // write code here that runs when the Windows Service starts up.  
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write(Common.ProductText.PyroText.PyroTextLogo(" Pyro Backburner "));
      Console.ResetColor();
      ConsoleSupport.DateTimeStampWriteLine("Starting...");
      Container = new Container();
      App_Start.SimpleInjectorWebApiInitializer.Initialize(Container);


      // IHI Search Service
      var FhirApiDiscoveryTaskLauncher = new FhirApiDiscoveryTaskLauncher(Container);
      ConsoleSupport.TimeStampWriteLine(LogMessageSupport.RegisterTask("FhirApiDiscoveryTaskLauncher"));
      PyroServerConnectionUrl = FhirApiDiscoveryTaskLauncher.Launch();



      _timer = new Timer(InitilizeHub, null, _StartupDelay, _StartupDelay);
            
    }

    private void LoadTasks()
    {
      var hubProxy = hubConnection.CreateHubProxy("BroadcastHub");
      Console.WriteLine("");
      Console.WriteLine("Registered Tasks:");

      // ========================================================================================
      // ==============  Registered each task Launcher to run ====================================
      // ========================================================================================

      // IHI Search Service
      var IhiSearchServiceTaskLauncher = new IhiSearchServiceTaskLauncher(Container);
      ConsoleSupport.TimeStampWriteLine(LogMessageSupport.RegisterTask(BackgroundTaskType.HiServiceIHISearch.GetPyroLiteral()));
      hubProxy.On<TaskPayloadHiServiceIHISearch>(BackgroundTaskType.HiServiceIHISearch.GetPyroLiteral(), 
        IHiServiceResolveIHIPayload => IhiSearchServiceTaskLauncher.Launch(IHiServiceResolveIHIPayload));
      

      // ========================================================================================
      Console.WriteLine("");
    }
    
    public void Stop()
    {
      // write code here that runs when the Windows Service stops.  
      hubConnection.Stop();      
    }
    public void Pause()
    {
      // write code here that runs when the Windows Service Pauses.  
      hubConnection.Stop();
    }
    public void Continue()
    {
      // write code here that runs when the Windows Service Pauses.  
      StartupHub();      
    }
    public void Shutdown()
    {
      // write code here that runs when the Windows Service Pauses.  
      hubConnection.Stop();      
    }

    private void InitilizeHub(object state)
    {
      //stop the timer
      _timer.Change(Timeout.Infinite, Timeout.Infinite);
      
      StartupHub();
    }
    
    private void StartupHub()
    {

      //We don't actualy know if the pyro server is running with TLS or not so we first try https and is not connected we try http next time
      if (PyroServerConnectionUrl.ToLower().StartsWith("https://"))
      {
        PyroServerConnectionUrl = "http://" + PyroServerConnectionUrl.Substring(8, PyroServerConnectionUrl.Length - 8);
      }
      else if (PyroServerConnectionUrl.ToLower().StartsWith("http://"))
      {
        PyroServerConnectionUrl = "https://" + PyroServerConnectionUrl.Substring(7, PyroServerConnectionUrl.Length - 7);
      }
      else
      {
        PyroServerConnectionUrl = "https://" + PyroServerConnectionUrl;
      }

      hubConnection = new HubConnection(PyroServerConnectionUrl);

      hubConnection.Closed += HubConnection_Closed;
      hubConnection.ConnectionSlow += HubConnection_ConnectionSlow;
      hubConnection.Error += HubConnection_Error;
      hubConnection.Received += HubConnection_Received;
      hubConnection.Reconnected += HubConnection_Reconnected;
      hubConnection.Reconnecting += HubConnection_Reconnecting;
      hubConnection.StateChanged += HubConnection_StateChanged;
      LoadTasks();

      ConsoleWriteLine($"Connecting to Pyro Server at : {PyroServerConnectionUrl}");
      try
      {
        hubConnection.Start();
      }
      catch (Exception exec)
      {
        ConsoleWriteLine($"Pyro Backburner exception: " + exec.Message);
      }
    }

    private void HubConnection_StateChanged(StateChange obj)
    {
      if (obj.NewState == ConnectionState.Connected)
      {
        Console.Clear();        
        Console.WriteLine();
        Console.Write(Common.ProductText.PyroText.PyroTextLogo(" Pyro Backburner "));
        Console.WriteLine();
        ConsoleSupport.Line();
        ConsoleSupport.DateTimeStampWriteLine("Connected to Pyro Server");        
        ConsoleWriteLine($"At address: {PyroServerConnectionUrl}");
        //ConsoleSupport.Line();
      }
      else
      {
        ConsoleWriteLine($"Contection state changed:");
        ConsoleWriteLine($"  Old state: {obj.OldState.ToString()}");
        ConsoleWriteLine($"  New state: {obj.NewState.ToString()}");
      }
    }

    private void HubConnection_Reconnecting()
    {
      ConsoleWriteLine($"Reconnecting to Pyro Server at : {PyroServerConnectionUrl}");
    }

    private void HubConnection_Reconnected()
    {
      ConsoleWriteLine($"Reconnected to Pyro Server");
    }

    private void HubConnection_Received(string obj)
    {
      //Only for debugging
      //ConsoleWriteLine($"Received data: {obj.}");
    }

    private void HubConnection_Error(Exception obj)
    {
      ConsoleWriteLine($"Connection Error: {obj.Message}");
    }

    private void HubConnection_ConnectionSlow()
    {
      ConsoleWriteLine($"Warning connection running slow");
    }

    private void HubConnection_Closed()
    {
      ConsoleWriteLine($"Connection to Pyro Server has closed");
      ConsoleWriteLine($"Connection will be restart in: {_updateInterval.Seconds.ToString()} seconds");
      _timer = new Timer(Restart, null, _updateInterval, _updateInterval);
    }

    private void Restart(object state)
    {
      _timer.Change(Timeout.Infinite, Timeout.Infinite);
      ConsoleWriteLine($"Connection to Pyro Server is restarting");
      StartupHub();
    }

    private void ConsoleWriteLine(string message)
    {
      ConsoleSupport.TimeStampWriteLine(message);
    }

  }
}
