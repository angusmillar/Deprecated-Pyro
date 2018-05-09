using AutoMapper;
using Pyro.Common.FhirRelease;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.AutoMapperProfile
{
  public class FhirReleaseProfile : Profile
  {
    public FhirReleaseProfile()
    {
      CreateMap<DtoFhirRelease, _FhirRelease>()
        .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
        .ForMember(x => x.FhirVersion, opt => opt.MapFrom(y => y.FhirVersion))
        .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
        .ForMember(x => x.Date, opt => opt.MapFrom(y => y.Date))
        .ForMember(x => x.CreatedDate, opt => opt.MapFrom(y => y.CreatedDate))
        .ForMember(x => x.CreatedUser, opt => opt.MapFrom(y => y.CreatedUser))
        .ForMember(x => x.LastUpdated, opt => opt.MapFrom(y => y.LastUpdated))
        .ForMember(x => x.LastUpdatedUser, opt => opt.MapFrom(y => y.LastUpdatedUser))
        .ForAllOtherMembers(opt => opt.Ignore());
    }
  }
}
