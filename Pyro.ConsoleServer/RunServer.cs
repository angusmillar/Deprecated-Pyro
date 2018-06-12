using Microsoft.Owin.Hosting;
using System;
using System.Text;
using Pyro.Common.Global;

namespace Pyro.ConsoleServer
{
  class RunServer
  {
    static void Main(string[] args)
    {
      string FhirEndpoint = WebConfigProperties.ServiceBaseURL();
      Uri FhirEndpointUri = new Uri(FhirEndpoint);
      string uri = $"{FhirEndpointUri.Scheme}://{FhirEndpointUri.Authority}";
      string line = new String('=', 79);
      //string PyroImage = PyroTextIMage();
      string PyroImage = Pyro.Common.ProductText.PyroText.PyroTextLogo("Pyro FHIR Server", $"Version: {System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Common.Global.GlobalProperties).Assembly.Location).ProductVersion}");


      bool StopServer = false;
      using (WebApp.Start<StartupConsole>(uri))
      {
        while (!StopServer)
        {
          
          Console.Title = "Pyro.ConsoleServer";
          Console.WriteLine(PyroImage);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("");
          Console.WriteLine("Endpoint: " + FhirEndpoint);
          Console.WriteLine("");
          Console.WriteLine("(Hit any key to stop the server)");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.ReadKey();
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("Are you sure you want to stop the server? ");
          Console.WriteLine("");
          Console.WriteLine("Hit [Enter] for Yes or any key for No.");
          Console.WriteLine("");
          Console.ResetColor();
          ConsoleKeyInfo info = Console.ReadKey();
          if (info.Key == ConsoleKey.Enter)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            StopServer = true;
            Console.WriteLine("Server is Stopping, Bye!");            
            Console.WriteLine("");
            Console.Clear();
            Console.WriteLine(PyroImage);
            Console.WriteLine("Server Stopping in:");
            Console.Write("..3");
            System.Threading.Thread.Sleep(500);
            Console.Write("..2");
            System.Threading.Thread.Sleep(500);
            Console.Write("..1");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("........Bye!");
            Console.ResetColor();
          }
          else
          {
            Console.Clear();
          }
        }                
      }
    }

  }

}
