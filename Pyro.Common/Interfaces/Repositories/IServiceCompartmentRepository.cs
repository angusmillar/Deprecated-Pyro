using Pyro.Common.Compartment;
using System.Collections.Generic;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IServiceCompartmentRepository
  {
    bool DeleteServiceCompartment(string Code);
    DtoServiceCompartment GetServiceCompartment(string Code);
    DtoServiceCompartment UpdateServiceCompartment(DtoServiceCompartment DtoServiceCompartment);
    List<DtoServiceCompartmentResource> GetServiceCompartmentResourceList(string Code, string Resource);
  }
}