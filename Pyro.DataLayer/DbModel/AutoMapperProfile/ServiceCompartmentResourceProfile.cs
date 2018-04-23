using AutoMapper;
using Pyro.Common.Compartment;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class ServiceCompartmentResourceProfile : Profile
  {
    public ServiceCompartmentResourceProfile()
    {
      CreateMap<DtoServiceCompartmentResource, _ServiceCompartmentResource>().ReverseMap();
    }
  }
}
