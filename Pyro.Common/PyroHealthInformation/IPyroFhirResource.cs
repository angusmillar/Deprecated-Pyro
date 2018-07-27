
namespace Pyro.Common.PyroHealthInformation
{
  public interface IPyroFhirResource
  {
    ICodeSystem CodeSystem { get; }
    IOrganization Organization { get; }       
    ITask Task { get; }
    IDevice Device { get; }
  }
}