using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.Tasks
{
  public interface IPyroTask : IPyroResource
  {
    Hl7.Fhir.Model.Task GetResource();
  }
}
