using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.PyroHealthInformation.Devices;

namespace Pyro.Common.PyroHealthInformation
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
