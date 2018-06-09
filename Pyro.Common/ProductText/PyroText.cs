using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pyro.Common.ProductText
{
  public static class PyroText
  {
    /// <summary>
    /// ServiceName must be 16 char long, or it will look funnny.
    /// </summary>
    /// <param name="ServiceName"></param>
    /// <returns></returns>
    public static string PyroTextLogo(string ServiceName)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("                                 `:+syhhhhys+:`");
      sb.AppendLine($" {ServiceName}              .odNNNNNNNNNNNNNNdo.");
      //sb.AppendLine(" PYRO FHIR Server              .odNNNNNNNNNNNNNNdo.");
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
