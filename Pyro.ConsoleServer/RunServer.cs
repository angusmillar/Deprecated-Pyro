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
      string PyroImage = PyroTextIMage();
      bool StopServer = false;
      using (WebApp.Start<StartupConsole>(uri))
      {
        while (!StopServer)
        {
          Console.Title = "Pyro.ConsoleServer";
          Console.WriteLine(PyroImage);
          Console.WriteLine("");
          Console.WriteLine("Endpoint: " + FhirEndpoint);
          Console.WriteLine("");
          Console.WriteLine("(Hit any key to stop the server)");
          Console.ReadKey();
          Console.Clear();
          Console.WriteLine("Are you sure you want to stop the server? ");
          Console.WriteLine("");
          Console.WriteLine("Hit [Enter] for Yes or any key for No.");
          Console.WriteLine("");
          ConsoleKeyInfo info = Console.ReadKey();
          if (info.Key == ConsoleKey.Enter)
          {
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
          }
          else
          {
            Console.Clear();
          }
        }                
      }
    }

    private static string PyroTextIMage()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("                                 `:+syhhhhys+:`");
      sb.AppendLine(" PYRO FHIR Server              .odNNNNNNNNNNNNNNdo.");
      sb.AppendLine("                             `+++oshNNNNNNNmhso+++.");
      sb.AppendLine(" FHIR Release 3.0.1        .-------::/dNNd:::-------.");
      sb.AppendLine("                           -        `o.Nm`o`        -");
      sb.AppendLine("                          .`         s`Nm`o         .`");
      sb.AppendLine("                          .`        :/+NN/+-        ..");
      sb.AppendLine("                          `.       /:/NNNm:/:       -");
      sb.AppendLine("                           -.    -/.oNNNNNN+-/.    ..");
      sb.AppendLine("                                -/---:-+mNNmddmNNd/-:---/-");
      sb.AppendLine("                       -::h.ymhhdNNd++o+:o++dNNdhhmy.y::-");
      sb.AppendLine("                   /::-`  +d.+yNNNs:mNNs+NNm:sNNNy+.d+  `-::/");
      sb.AppendLine("                   yy      shyshNN`mNN/ss/NNm`NNdsyhs      yy");
      sb.AppendLine("                   `m+      hshomN-ss++oo++os-Nmohsh      +m`");
      sb.AppendLine("                    sN:     `dod+Nm-+mNNNNmo-dNodod`     :Ns");
      sb.AppendLine("                     hm-     .m+--smho+oo++hms--+m.     -mh");
      sb.AppendLine("                     `dm`     :m.   `-::::-`   .m:     `md`");
      sb.AppendLine("                       sh   .::/.              ./::.   hs");
      sb.AppendLine("                        s+::`                      `::+s");

      return sb.ToString();
    }
  }

}
