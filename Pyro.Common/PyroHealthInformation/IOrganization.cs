using Pyro.Common.PyroHealthInformation.Organizations;

namespace Pyro.Common.PyroHealthInformation
{
  public interface IOrganization
  {
    IPyroHealth PyroHealthOrganization { get; }
  }
}