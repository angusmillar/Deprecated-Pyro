using Hl7.Fhir.Model;

namespace Pyro.Common.Search
{
  public class DtoServiceSearchParameterTargetResource : IServiceSearchParameterTargetResource
  {
    public ResourceType ResourceType { get; set; }
  }
}
