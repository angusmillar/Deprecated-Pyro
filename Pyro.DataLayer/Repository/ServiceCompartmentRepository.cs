using Pyro.Common.Compartment;
using Pyro.DataLayer.DbModel.Entity;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using AutoMapper;
using System.Data.Entity;
using Pyro.Common.Interfaces.Repositories;
using System.Collections.Generic;

namespace Pyro.DataLayer.Repository
{
  public class ServiceCompartmentRepository : BaseRepository, IServiceCompartmentRepository
  {
    private readonly IMapper IMapper;

    public ServiceCompartmentRepository(IPyroDbContext IPyroDbContext, IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IMapper = IMapper;
    }

    public DtoServiceCompartment GetServiceCompartment(string Code)
    {
      _ServiceCompartment ServiceCompartment = IPyroDbContext.ServiceCompartment.Include(x => x.ResourceList).SingleOrDefault(x => x.Code == Code);
      if (ServiceCompartment != null)
      {
        return IMapper.Map<DtoServiceCompartment>(ServiceCompartment);
      }
      return null;
    }


    public DtoServiceCompartmentCached GetServiceCompartmentResourceParameterListForCache(string ServiceCompartmentCode, string Resource)
    {
      IQueryable<_ServiceCompartmentResource> ServiceCompartmentResource = IPyroDbContext.ServiceCompartmentResource.Where(x => x.ServiceCompartment.Code == ServiceCompartmentCode && x.Code == Resource);
      var List = new List<DtoServiceCompartmentCached>();
      var dbList = ServiceCompartmentResource.ToList();
      if (dbList.Count > 0)
      {
        var ListItem = new DtoServiceCompartmentCached()
        {
          CompartmentCode = dbList[0].ServiceCompartment.Code,
          ResourceName = dbList[0].Code,
          ParamList = new List<DtoServiceCompartmentResourceCached>()
        };
        dbList.ForEach(x => ListItem.ParamList.Add(new DtoServiceCompartmentResourceCached() { Param = x.Param }));
        return ListItem;
      }
      return null;
    }


    public DtoServiceCompartment UpdateServiceCompartment(DtoServiceCompartment DtoServiceCompartment)
    {
      _ServiceCompartment ServiceCompartment = IMapper.Map<_ServiceCompartment>(DtoServiceCompartment);
      DeleteServiceCompartment(ServiceCompartment.Code);
      ServiceCompartment = IPyroDbContext.Set<_ServiceCompartment>().Add(ServiceCompartment);
      this.Save();
      return IMapper.Map<DtoServiceCompartment>(ServiceCompartment);
    }

    public bool DeleteServiceCompartment(string Code)
    {
      var Entity = IPyroDbContext.ServiceCompartment.SingleOrDefault(x => x.Code == Code);
      if (Entity != null)
      {
        IPyroDbContext.ServiceCompartment.Remove(Entity);
        this.Save();
        return true;
      }
      return false;
    }

  }


}
