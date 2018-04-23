using Pyro.Common.Compartment;

namespace Pyro.Common.Compartment
{
  public interface IServiceCompartmentCache
  {
    DtoServiceCompartment GetServiceCompartmentForCode(string Code);
    void ClearServiceCompartmentForCode(string Code);
  }
}