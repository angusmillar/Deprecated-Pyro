using Pyro.Common.PyroHealthInformation.Devices;

namespace Pyro.Common.PyroHealthInformation
{
  public interface IDevice
  {
    IPyroFhirServer PyroFhirServerDevice { get; }
  }
}