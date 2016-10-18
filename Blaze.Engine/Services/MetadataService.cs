using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Services
{
  public class MetadataService
  {
    public Resource GetServersConformanceResource()
    {
      var Conformance = new Conformance();




      return Conformance;
    }


  }
}
