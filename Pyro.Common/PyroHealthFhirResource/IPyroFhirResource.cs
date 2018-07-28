
namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IPyroFhirResource
  {
    ICodeSystem CodeSystem { get; }
    IOrganization Organization { get; }       
    ITask Task { get; }
    IDevice Device { get; }
  }
}