using Pyro.Common.Search;

namespace Pyro.Common.Service.CompartmentSearchParameter
{
  public interface ICompartmentSearchParameterService
  {
    PyroSearchParameters GetSearchParameters(string Compartment, string CompartmentId, string ResourceName);
  }
}