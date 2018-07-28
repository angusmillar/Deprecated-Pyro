using Pyro.Common.PyroHealthFhirResource.Devices;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IDevice
  {
    IPyroFhirServer PyroFhirServerDevice { get; }
  }
}