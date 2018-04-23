using AutoMapper;
using Pyro.Common.Compartment;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class ServiceCompartmentProfile : Profile
  {
    public ServiceCompartmentProfile()
    {
      CreateMap<DtoServiceCompartment, _ServiceCompartment>().ReverseMap();
    }
  }
}
