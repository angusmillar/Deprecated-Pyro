using AutoMapper;
using Pyro.Common.DtoEntity;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class FhirTaskQueueProfile : Profile
  {
    public FhirTaskQueueProfile()
    {
      CreateMap<DtoFhirTaskQueue, _FhirTaskQueue>().ReverseMap();
    }
  }
}
