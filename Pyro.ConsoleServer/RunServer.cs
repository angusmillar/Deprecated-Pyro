using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Web;

namespace Pyro.ConsoleServer
{  
  class RunServer
  {
    static void Main(string[] args)
    {
      string Port = Pyro.Common.Web.StaticWebInfo.TestingPort;
      string uri = "http://localhost:" + Port;
      string FhirEndpoint = "http://localhost:" + Port + Pyro.Common.Web.StaticWebInfo.ServiceRoute;
      using (WebApp.Start<Pyro.Web.Startup>(uri))
      {
        Console.WriteLine("Server Started");
        Console.WriteLine("===================================================================");
        Console.WriteLine();
        Console.WriteLine("On: " + uri);
        Console.WriteLine("(Hit any key to stop the server)");
        Console.WriteLine();
        Console.WriteLine("===================================================================");

        Console.ReadKey();

        Console.WriteLine("===================================================================");
        Console.WriteLine("Server Stopping");
      }
    }
  }  

}
