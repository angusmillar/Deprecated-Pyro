using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface ICompartmentSearchParameterService
  {
    PyroSearchParameters GetSearchParameters(string Compartment, string CompartmentId, string ResourceName);
  }
}