using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroCodeSystem : IPyroResource
  {
    string GetSystem();
    string GetName();
    Hl7.Fhir.Model.CodeSystem GetResource();
  }
}
