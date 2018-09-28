using Hl7.Fhir.ElementModel;

namespace Pyro.Common.Tools.FhirPathSupport
{
  public interface IPyroFhirPathResolve
  {
    IElementNavigator Resolver(string url);
  }
}