
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.Devices
{
  public interface IPyroFhirServer
  {
    FhirModel.Device GetDevice();
    string GetResourceId();
    string GetName();
  }
}