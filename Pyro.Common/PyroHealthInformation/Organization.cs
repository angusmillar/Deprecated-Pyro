using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.PyroHealthInformation.Organizations;

namespace Pyro.Common.PyroHealthInformation
{
  public class Organization : IOrganization
  {
    private readonly IPyroHealth IPyroHealth;
    public Organization(IPyroHealth IPyroHealth)
    {
      this.IPyroHealth = IPyroHealth;
    }
    public IPyroHealth PyroHealthOrganization => IPyroHealth;
  }
}
