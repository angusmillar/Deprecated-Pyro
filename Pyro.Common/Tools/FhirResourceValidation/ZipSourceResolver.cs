using System;
using System.Web.Hosting;
using System.IO;
using Hl7.Fhir.Specification.Source;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class ZipSourceResolver : ZipSource, IResourceResolver
  {
    public ZipSourceResolver()
      : base(ResolveSpecificationZipFilePath())
    {
    }
    private static string ResolveSpecificationZipFilePath()
    {
      string SpecificationFileName = "specification.zip";
      if (HostingEnvironment.IsHosted)
      {
        //If running is IIS either IIS Express in dev or IIS in production i.e (Pyro.Web)
        return Path.Combine(AppContext.BaseDirectory, @"bin\" + SpecificationFileName);
      }
      else
      {
        //If running as a console server i.e (Pyro.ConsoleServer)
        return Path.Combine(AppContext.BaseDirectory, SpecificationFileName);
      }

    }
  }
}
