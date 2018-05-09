using Pyro.Common.FhirRelease;
using Pyro.DataLayer.DbModel.Entity;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using AutoMapper;
using Pyro.Common.Interfaces.Repositories;
using System.Collections.Generic;

namespace Pyro.DataLayer.Repository
{
  public class FhirReleaseRepository : BaseRepository, IFhirReleaseRepository
  {
    private readonly IMapper IMapper;

    public FhirReleaseRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoFhirRelease GetFhirReleaseByFhirVersion(string Version)
    {
      _FhirRelease DbFhirRelease = IPyroDbContext.FhirRelease.SingleOrDefault(x => x.FhirVersion == Version);
      if (DbFhirRelease != null)
      {
        return IMapper.Map<DtoFhirRelease>(DbFhirRelease);
      }
      return null;
    }
    
    public List<DtoFhirRelease> GetAllFhirReleases()
    {
      List<_FhirRelease> DbFhirReleaseList = IPyroDbContext.FhirRelease.ToList();
      if (DbFhirReleaseList != null)
      {
        return IMapper.Map<List<DtoFhirRelease>>(DbFhirReleaseList);
      }
      return null;
    }    

    public DtoFhirRelease UpdateFhirRelease(DtoFhirRelease DtoFhirRelease)
    {
      if (DtoFhirRelease == null)
        throw new System.NullReferenceException("DtoFhirRelease cannot be null");
      if (string.IsNullOrWhiteSpace(DtoFhirRelease.FhirVersion))
        throw new System.NullReferenceException("DtoFhirRelease.FhirVersion cannot be null or empty string");

      _FhirRelease DbFhirRelease = IPyroDbContext.FhirRelease.SingleOrDefault(x => x.FhirVersion == DtoFhirRelease.FhirVersion);
      if (DbFhirRelease == null)
      {
        throw new System.NullReferenceException($"Unable to update FhirRelease as no FhirRelease found in the database for the FhirVersion provided: '{DtoFhirRelease.FhirVersion}'");
      }
      else
      {
        DbFhirRelease.FhirVersion = DtoFhirRelease.FhirVersion;
        DbFhirRelease.Description = DtoFhirRelease.Description;
        DbFhirRelease.Date = DtoFhirRelease.Date;
        DbFhirRelease.CreatedDate = DtoFhirRelease.CreatedDate;
        DbFhirRelease.CreatedUser = DtoFhirRelease.CreatedUser;
        DbFhirRelease.LastUpdated = DtoFhirRelease.LastUpdated;
        DbFhirRelease.LastUpdatedUser = DtoFhirRelease.LastUpdatedUser;
      }
      DbFhirRelease = IPyroDbContext.Set<_FhirRelease>().Add(DbFhirRelease);      
      this.Save();
      return IMapper.Map<DtoFhirRelease>(DbFhirRelease);      
    }
    
  }


}
