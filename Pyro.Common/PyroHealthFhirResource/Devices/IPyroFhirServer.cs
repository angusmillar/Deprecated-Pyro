
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Devices
{
  public interface IPyroFhirServer
  {
    FhirModel.Device GetDevice();
    string GetResourceId();
    string GetName();
  }
}