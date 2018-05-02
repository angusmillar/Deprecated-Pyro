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

    public DtoServiceCompartment GetServiceCompartmenByCompartmentCode(string Code)
    {
      _ServiceCompartment ServiceCompartment = IPyroDbContext.ServiceCompartment.Include(x => x.ResourceList).SingleOrDefault(x => x.Code == Code);
      if (ServiceCompartment != null)
      {
        return IMapper.Map<DtoServiceCompartment>(ServiceCompartment);
      }
      return null;
    }

    public DtoServiceCompartment GetServiceCompartmentByFhirId(string FhirId)
    {
      _ServiceCompartment ServiceCompartment = IPyroDbContext.ServiceCompartment.Include(x => x.ResourceList).SingleOrDefault(x => x.CompartmentDefinitionResourceId == FhirId);
      if (ServiceCompartment != null)
      {
        return IMapper.Map<DtoServiceCompartment>(ServiceCompartment);
      }
      return null;
    }

    public DtoServiceCompartmentCached GetServiceCompartmentForCache(string ServiceCompartmentCode)
    {
      _ServiceCompartment ServiceCompartment = IPyroDbContext.ServiceCompartment.SingleOrDefault(x => x.Code == ServiceCompartmentCode);
      if (ServiceCompartment != null)
      {
        var Dto = new DtoServiceCompartmentCached()
        {
          Code = ServiceCompartment.Code,
          CompartmentDefinitionResourceId = ServiceCompartment.CompartmentDefinitionResourceId,
          CompartmentDefinitionResourceVersion = ServiceCompartment.CompartmentDefinitionResourceVersion,
          Id = ServiceCompartment.Id
        };
        return Dto;
      }
      return null;
    }

    public DtoServiceCompartmentResourceCached GetServiceCompartmentResourceParameterListForCache(string ServiceCompartmentCode, string Resource)
    {
      IQueryable<_ServiceCompartmentResource> ServiceCompartmentResource = IPyroDbContext.ServiceCompartmentResource.Where(x => x.ServiceCompartment.Code == ServiceCompartmentCode && x.Code == Resource);
      var List = new List<DtoServiceCompartmentResourceCached>();
      var dbList = ServiceCompartmentResource.ToList();
      if (dbList.Count > 0)
      {
        var ListItem = new DtoServiceCompartmentResourceCached()
        {
          CompartmentCode = dbList[0].ServiceCompartment.Code,
          ResourceName = dbList[0].Code,
          ParamList = new List<DtoServiceCompartmentParameterCached>()
        };
        dbList.ForEach(x => ListItem.ParamList.Add(new DtoServiceCompartmentParameterCached() { Param = x.Param }));
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
