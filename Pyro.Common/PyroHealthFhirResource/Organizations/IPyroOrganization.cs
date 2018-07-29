using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.Organizations
{
  public interface IPyroOrganization : IPyroResource
  {
    string GetName();
    Hl7.Fhir.Model.Organization GetResource();
  }
}
