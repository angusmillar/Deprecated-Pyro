using Pyro.Common.ServiceConfigration;
using Pyro.DataLayer.DbModel.Entity;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using AutoMapper;
using Pyro.Common.Interfaces.Repositories;
using System.Collections.Generic;

namespace Pyro.DataLayer.Repository
{
  public class ServiceConfigurationRepository : BaseRepository, IServiceConfigurationRepository
  {
    private readonly IMapper IMapper;

    public ServiceConfigurationRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoServiceConfigration GetDtoServiceConfigrationByParameter(string Parameter)
    {
      _ServiceConfiguration DbServiceConfiguration = IPyroDbContext.ServiceConfiguration.SingleOrDefault(x => x.Parameter == Parameter);
      if (DbServiceConfiguration != null)
      {
        return IMapper.Map<DtoServiceConfigration>(DbServiceConfiguration);
      }
      return null;
    }

    public DtoServiceConfigration UpdateServiceConfigration(DtoServiceConfigration DtoServiceConfigration)
    {
      var DateTimeNow = System.DateTimeOffset.Now;
      _ServiceConfiguration DbServiceConfigration = IPyroDbContext.ServiceConfiguration.SingleOrDefault(x => x.Parameter == DtoServiceConfigration.Parameter);
      if (DbServiceConfigration != null)
      {
        DbServiceConfigration.Value = DtoServiceConfigration.Value;
        DbServiceConfigration.LastUpdated = DateTimeNow;
        DbServiceConfigration.LastUpdatedUser = DtoServiceConfigration.LastUpdatedUser;
      }
      else
      {
        DbServiceConfigration = IMapper.Map<_ServiceConfiguration>(DtoServiceConfigration);
        DbServiceConfigration.LastUpdated = DateTimeNow;
        DbServiceConfigration.CreatedDate = DateTimeNow;
        DbServiceConfigration = IPyroDbContext.Set<_ServiceConfiguration>().Add(DbServiceConfigration);
      }
      this.Save();
      return IMapper.Map<DtoServiceConfigration>(DbServiceConfigration);
    }
 
    public bool UpdateIfNewOrModifiedServiceConfigration(string Parameter, string Value, string UserUpdating, System.DateTimeOffset UpdateingDateTime)
    {
      _ServiceConfiguration DbServiceConfigration = IPyroDbContext.ServiceConfiguration.SingleOrDefault(x => x.Parameter.ToLower() == Parameter.ToLower());
      if (DbServiceConfigration != null)
      {
        if (DbServiceConfigration.Value.Trim() != Value.Trim())
        {
          DbServiceConfigration.Value = Value;
          DbServiceConfigration.LastUpdated = UpdateingDateTime;
          DbServiceConfigration.LastUpdatedUser = UserUpdating;
          this.Save();
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        DbServiceConfigration = new _ServiceConfiguration();
        DbServiceConfigration.Parameter = Parameter;
        DbServiceConfigration.Value = Value;
        DbServiceConfigration.CreatedDate = UpdateingDateTime;
        DbServiceConfigration.LastUpdated = UpdateingDateTime;
        DbServiceConfigration.CreatedUser = UserUpdating;
        DbServiceConfigration.LastUpdatedUser = UserUpdating;
        DbServiceConfigration = IPyroDbContext.Set<_ServiceConfiguration>().Add(DbServiceConfigration);
        this.Save();
        return true;
      }

    }

    public Dictionary<string, string> GetServiceConfigrationDictionary()
    {
      //Dictionary<string, string>
      return
        IPyroDbContext
        .ServiceConfiguration
        .Select(x => new { x.Parameter, x.Value }).ToList().ToDictionary(c => c.Parameter, c => c.Value);

    }
  }


}
