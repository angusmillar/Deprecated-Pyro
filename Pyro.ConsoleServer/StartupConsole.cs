using Microsoft.Owin;

[assembly: OwinStartup(typeof(Pyro.WebApi.Startup))]

namespace Pyro.ConsoleServer
{
  public partial class StartupConsole : Pyro.WebApi.Startup
  {
    //public override void RegisterAllAreas()
    //{
    //  //For ConsoleStartup we don't want to RegisterAllAreas
    //}
  }
}
