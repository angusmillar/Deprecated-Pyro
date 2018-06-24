using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Smart.Scopes;

namespace Pyro.Common.Service.Smart
{
  public interface ISmartScopeService
  {
    ISmartScopeOutcome ProcessScopes(PyroSearchParameters PyroSearchParameters, FHIRAllTypes ServiceResourceType, bool Read, bool Write);
  }
}