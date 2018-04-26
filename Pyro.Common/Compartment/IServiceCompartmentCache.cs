using Pyro.Common.Compartment;

namespace Pyro.Common.Compartment
{
  public interface IServiceCompartmentCache
  {
    DtoServiceCompartmentCached GetServiceCompartmentForCompartmentCodeAndResource(string CompartmentCode, string Resource);
    void ClearServiceCompartmentForCompartmentCodeAndResource(string CompartmentCode, string Resource);
  }
}