using Pyro.Common.PyroHealthFhirResource.Organizations;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IOrganization
  {
    IPyroHealth PyroHealthOrganization { get; }
  }
}