using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Tools.FhirResourceValidation
{
  public class InternalServerProfileResolver : IResourceResolver
  {
    private IResourceServices _Resource;
    public List<StructureDefinition> TestProfiles = new List<StructureDefinition>();

    public InternalServerProfileResolver(IResourceServices ResourceServices)
    {
      _Resource = ResourceServices;
      _Resource.SetCurrentResourceType(FHIRAllTypes.StructureDefinition);

      //Add StructureDefinition resource to this list when we have them rather than obtaining from Server.
      // TestProfiles.Add();
    }
    public Resource ResolveByCanonicalUri(string uri)
    {
      return TestProfiles.SingleOrDefault(p => p.Url == uri);
    }

    public Resource ResolveByUri(string uri)
    {
      return ResolveByCanonicalUri(uri);
    }
  }
}
