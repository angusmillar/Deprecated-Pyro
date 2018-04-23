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

    public List<DtoServiceCompartmentResource> GetServiceCompartmentResourceList(string Code, string Resource)
    {
      List<_ServiceCompartmentResource> ServiceCompartment2 = IPyroDbContext.ServiceCompartment.Include(x => x.ResourceList).SingleOrDefault(x => x.Code == Code).ResourceList.Where(c => c.Code == Resource).ToList();
      IQueryable<IEnumerable<_ServiceCompartmentResource>> ServiceCompartmentResource = IPyroDbContext.ServiceCompartment.Include(x => x.ResourceList).Where(b => b.Code == Code).Select(a => a.ResourceList.Where(y => y.Code == Resource));
      var aaaa = ServiceCompartmentResource.ToList();

      //if (ServiceCompartment != null)
      //{
      //  return IMapper.Map<DtoServiceCompartment>(ServiceCompartment);
      //}
      return null;
    }

    public DtoServiceCompartment UpdateServiceCompartment(DtoServiceCompartment DtoServiceCompartment)
    {      
      _ServiceCompartment ServiceCompartment = IMapper.Map<_ServiceCompartment>(DtoServiceCompartment);     
      DeleteServiceCompartment(ServiceCompartment.Code);
      ServiceCompartment = IPyroDbContext.Set<_ServiceCompartment>().Add(ServiceCompartment);
      this.Save();
      return  IMapper.Map<DtoServiceCompartment>(ServiceCompartment);     
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
