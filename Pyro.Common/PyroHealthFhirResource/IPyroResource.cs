using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IPyroResource
  {
    string GetResourceId();    
    DateTimeOffset MasterLastUpdated { get; }
  }
}
