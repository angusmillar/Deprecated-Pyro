using Microsoft.Owin;

[assembly: OwinStartup(typeof(Pyro.Web.Startup))]

namespace Pyro.ConsoleServer
{
  public partial class StartupConsole : Pyro.Web.Startup
  {
    public override void RegisterAllAreas()
    {
      //For ConsoleStartup we don't want to RegisterAllAreas
    }
  }
}
