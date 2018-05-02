using Pyro.Common.Compartment;

namespace Pyro.Common.Compartment
{
  public interface IServiceCompartmentCache
  {
    DtoServiceCompartmentCached GetServiceCompartmentForCompartmentCode(string CompartmentCode);
    DtoServiceCompartmentResourceCached GetServiceCompartmentResourceForCompartmentCodeAndResource(string CompartmentCode, string Resource);

    void ClearServiceCompartmentForCompartmentCode(string CompartmentCode);
    void ClearServiceCompartmentResourceForCompartmentCodeAndResource(string CompartmentCode, string Resource);
    
  }
}