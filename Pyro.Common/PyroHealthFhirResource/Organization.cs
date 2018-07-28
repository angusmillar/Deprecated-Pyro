using Pyro.Common.PyroHealthFhirResource.Organizations;

namespace Pyro.Common.PyroHealthFhirResource
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
