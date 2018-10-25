using AutoMapper;
using Pyro.Common.DtoEntity;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class FhirTaskWorkerProfile : Profile
  {
    public FhirTaskWorkerProfile()
    {
      CreateMap<DtoFhirTaskWorker, _FhirTaskWorker>().ReverseMap();
    }
  }
}
