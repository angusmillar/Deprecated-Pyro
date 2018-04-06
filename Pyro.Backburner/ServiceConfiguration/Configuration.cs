using Pyro.Backburner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Runtime;

namespace Pyro.Backburner.ServiceConfiguration
{
  internal static class Configuration
  {
    internal static void Configure()
    {
      HostFactory.Run(configure =>
      {
        configure.Service<ServiceTask>(service =>
        {
          service.ConstructUsing(s => new ServiceTask());
          service.WhenStarted(s => s.Start());
          service.WhenStopped(s => s.Stop());
          service.WhenPaused(s => s.Pause());
          service.WhenContinued(s => s.Continue());
          service.WhenShutdown(s => s.Shutdown());
        });


        //Setup Account that window service use to run.  
        configure.RunAsLocalSystem();
        configure.SetServiceName("PyroBackburner");
        configure.SetDisplayName("Pyro.Backburner");
        configure.SetDescription("Pyro Server background task worker");
      });
    }
  }
}
