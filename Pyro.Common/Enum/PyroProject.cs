using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Enum
{
  public static class PyroProject
  {
    public enum PyroProjectType
    {
      /// <summary>
      /// The Main FHIR API, could be Pyro.Console or Pyro.WebAPI
      /// </summary>
      FhirApi,
      //The Pyro.Backburner project
      Backburner
    };
  }
}
