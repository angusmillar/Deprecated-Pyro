using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.WebApi;
using Pyro.Common.Cache;

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
      using (WebApp.Start<StartupConsole>(uri))
      {
        Console.WriteLine(PyroImage);        
        Console.WriteLine("");        
        Console.WriteLine("Endpoint: " + FhirEndpoint);
        Console.WriteLine("");
        Console.WriteLine("(Hit any key to stop the server)");        
        Console.ReadKey();
        Console.WriteLine(line);
        Console.WriteLine("Server Stopping");
        Console.WriteLine(line);
        Console.WriteLine(PyroImage);
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
