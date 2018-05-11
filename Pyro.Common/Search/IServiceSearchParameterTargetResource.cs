using Hl7.Fhir.Model;

namespace Pyro.Common.Search
{
  public interface IServiceSearchParameterTargetResource
  {
    ResourceType ResourceType { get; set; }
  }
}