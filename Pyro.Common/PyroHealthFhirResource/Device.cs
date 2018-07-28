namespace Pyro.Common.PyroHealthFhirResource
{
  public class Device : IDevice
  {
    private readonly Devices.IPyroFhirServer IPyroFhirServerDevice;
  
    public Device(Devices.IPyroFhirServer IPyroFhirServerDevice)
    {
      this.IPyroFhirServerDevice = IPyroFhirServerDevice;
     
    }

    public Devices.IPyroFhirServer PyroFhirServerDevice => IPyroFhirServerDevice;
  
    
  }
}
