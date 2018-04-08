using Microsoft.AspNet.SignalR.Client;
//using Hl7.Fhir.Rest;
using System;
using System.Threading;
using Pyro.Common.BackgroundTask.Task;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Pyro.Backburner.ServiceTaskLaunch;
using Pyro.Backburner.ServiceTask;

namespace Pyro.Backburner.Service
{
  public class MainService
  {
    private HubConnection hubConnection;
    private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(10000);
    private readonly TimeSpan _StartupDelay = TimeSpan.FromMilliseconds(1000);
    private Timer _timer;
    private Uri PyroServerConnectionUrl = new Uri("http://localhost:8888");
    private Container container;

    public MainService()
    {
    }

    public void Start()
    {
      Console.Clear();
      Console.Write(Common.ProductText.PyroText.PyroTextLogo(" Pyro Backburner "));

      container = new Container();
      //container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
      container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      //Lifestyle.Singleton
      container.Register<CompositionRoot.IIhiSearchServiceFactory, CompositionRoot.IhiSearchServiceFactory>(Lifestyle.Singleton);
      container.Register<IIhiSearchServiceTaskLauncher, IhiSearchServiceTaskLauncher>(Lifestyle.Singleton);

      //Lifestyle.Scoped
      container.Register<ServiceTask.HiService.IOtherThing, ServiceTask.HiService.OtherThing>(Lifestyle.Scoped);
      container.Register<ServiceTask.HiService.IIhiSearchService, ServiceTask.HiService.IhiSearchService>(Lifestyle.Scoped);
      
      
      container.Verify();

      _timer = new Timer(InitilizeHub, null, _StartupDelay, _StartupDelay);
      //InitilizeHub();
      // write code here that runs when the Windows Service starts up.  
    }

    private void LoadTasks()
    {
      var hubProxy = hubConnection.CreateHubProxy("BroadcastHub");
      Console.WriteLine("");
      Console.WriteLine("Registered Tasks:");

      // ========================================================================================
      // ==============  Registered each task to run ============================================
      // ========================================================================================


      //Console.WriteLine($" - {Pyro.Backburner.ServiceTask.HiService.HiServiceIhiSearchTask.TaskName}");
      //hubProxy.On<TaskPayloadHiServiceIHISearch>("HiServiceResolveIHI", IHiServiceResolveIHIPayload 
      //  => new Pyro.Backburner.ServiceTask.HiService.HiServiceIhiSearchTask().Process(container, IHiServiceResolveIHIPayload));


      //hubProxy.On<TaskPayloadHiServiceIHISearch>("HiServiceResolveIHI", IHiServiceResolveIHIPayload
      //  => container.GetInstance<ITestService>().DoSomthing(IHiServiceResolveIHIPayload));


      hubProxy.On<TaskPayloadHiServiceIHISearch>("HiServiceResolveIHI", IHiServiceResolveIHIPayload
        => container.GetInstance<IIhiSearchServiceTaskLauncher>().Doit(IHiServiceResolveIHIPayload));


      // ========================================================================================
      Console.WriteLine("");
    }


    
    public void Stop()
    {
      hubConnection.Stop();
      // write code here that runs when the Windows Service stops.  
    }
    public void Pause()
    {
      hubConnection.Stop(); 
      // write code here that runs when the Windows Service Pauses.  
    }
    public void Continue()
    {
      StartupHub();
      // write code here that runs when the Windows Service Pauses.  
    }
    public void Shutdown()
    {
      hubConnection.Stop();
      // write code here that runs when the Windows Service Pauses.  
    }

    private void InitilizeHub(object state)
    {
      //stop the timer
      _timer.Change(Timeout.Infinite, Timeout.Infinite);

      hubConnection = new HubConnection(PyroServerConnectionUrl.OriginalString);
      hubConnection.Closed += HubConnection_Closed;
      hubConnection.ConnectionSlow += HubConnection_ConnectionSlow;
      hubConnection.Error += HubConnection_Error;
      hubConnection.Received += HubConnection_Received;
      hubConnection.Reconnected += HubConnection_Reconnected;
      hubConnection.Reconnecting += HubConnection_Reconnecting;
      hubConnection.StateChanged += HubConnection_StateChanged;
      LoadTasks();
      StartupHub();
    }

    

    private void StartupHub()
    {
      ConsoleWriteLine($"Connecting to Pyro Server at : {PyroServerConnectionUrl.OriginalString}");
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

        ConsoleWriteLine($"Now Connected to Pyro Server");
        ConsoleWriteLine($"At address: {PyroServerConnectionUrl.OriginalString}");
        //Tools.ConsoleSupport.DividingLine();
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
      ConsoleWriteLine($"Reconnecting to Pyro Server at : {PyroServerConnectionUrl.OriginalString}");
    }

    private void HubConnection_Reconnected()
    {
      ConsoleWriteLine($"Reconnected to Pyro Server");
    }

    private void HubConnection_Received(string obj)
    {
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
      Pyro.Backburner.Tools.ConsoleSupport.ConsoleWriteLine(message);
    }

  }
}
