using AutoMapper;
using Pyro.Common.ServiceConfigration;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class ServiceConfigurationProfile : Profile
  {
    public ServiceConfigurationProfile()
    {
      CreateMap<DtoServiceConfigration, _ServiceConfiguration>().ReverseMap();
    }
  }
}
