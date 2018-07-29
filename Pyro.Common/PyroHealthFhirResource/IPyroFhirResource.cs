using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IPyroFhirResource
  {
    ICodeSystem CodeSystem { get; }
    IOrganization Organization { get; }       
    ITask Task { get; }
    IDevice Device { get; }
    IEnumerable<Resource> ResourceToLoadOnStartupList();
    
  }
}