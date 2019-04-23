using Hl7.Fhir.ElementModel;

namespace Pyro.Common.Tools.FhirPathSupport
{
  public interface IPyroFhirPathResolve
  {
    ITypedElement Resolver(string url);
  }
}