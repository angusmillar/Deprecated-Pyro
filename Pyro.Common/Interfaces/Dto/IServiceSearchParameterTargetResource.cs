using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Dto
{
  public interface IServiceSearchParameterTargetResource
  {
    ResourceType ResourceType { get; set; }
  }
}