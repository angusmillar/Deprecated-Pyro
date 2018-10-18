using AutoMapper;
using Pyro.Common.DtoEntity;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class BackburnerConnectionProfile : Profile
  {
    public BackburnerConnectionProfile()
    {
      CreateMap<DtoBackburnerConnection, _BackburnerConnection>().ReverseMap();
    }
  }
}
