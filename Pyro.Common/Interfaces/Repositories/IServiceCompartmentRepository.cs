using Pyro.Common.Compartment;
using System.Collections.Generic;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IServiceCompartmentRepository
  {
    bool DeleteServiceCompartment(string Code);
    DtoServiceCompartment GetServiceCompartmenByCompartmentCode(string Code);
    DtoServiceCompartment GetServiceCompartmentByFhirId(string FhirId);
    DtoServiceCompartment UpdateServiceCompartment(DtoServiceCompartment DtoServiceCompartment);
    DtoServiceCompartmentCached GetServiceCompartmentForCache(string ServiceCompartmentCode);
    DtoServiceCompartmentResourceCached GetServiceCompartmentResourceParameterListForCache(string Code, string Resource);
  }
}