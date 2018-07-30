using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.Elements
{
  public static class PyroHealthCanonicalUrl
  {
    private static string CanonicalUrlBase = "https://pyrohealth.net/fhir";
    public static string CanonicalUrlBuild(string Append)
    {
      return $"{CanonicalUrlBase}/{Append}";
    }
  }
}
