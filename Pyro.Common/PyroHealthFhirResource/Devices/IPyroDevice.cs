using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.Devices
{
  public interface IPyroDevice : IPyroResource
  {        
    Hl7.Fhir.Model.Device GetResource();
  }
}
