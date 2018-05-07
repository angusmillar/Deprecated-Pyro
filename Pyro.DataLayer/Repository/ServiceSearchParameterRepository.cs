using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Search;
using Pyro.DataLayer.DbModel.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.DataLayer.Repository
{
  public class ServiceSearchParameterRepository : BaseRepository, IServiceSearchParameterRepository
  {    
    public ServiceSearchParameterRepository(IPyroDbContext IPyroDbContext) 
      : base(IPyroDbContext){ }

    public List<DtoServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType)
    {
      var ReturnList = new List<DtoServiceSearchParameterLight>();

      var DynamicList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList)
        .Where(x => x.Resource == ResourceType & x.IsIndexed == true & x.Status == PublicationStatus.Active)
        .Select(x => new { x.Id, x.Name, x.Expression, x.Resource, x.Type, x.TargetResourceTypeList }).ToList();

      if (DynamicList != null)
      {
        foreach (var x in DynamicList)
        {
          var Light = new DtoServiceSearchParameterLight();
          Light.Id = x.Id;
          Light.Name = x.Name;
          Light.Expression = x.Expression;
          Light.Type = x.Type;
          Light.Resource = x.Resource;
          Light.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
          if (x.TargetResourceTypeList != null)
          {
            foreach (var Target in x.TargetResourceTypeList)
              Light.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
          }
          ReturnList.Add(Light);
        }
      }
      return ReturnList;
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();

      List<_ServiceSearchParameter> ResourceServiceSearchParameterList;
      if (CustomOnly)
      {
        ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.SearchParameterResourceId != null).ToList();
      }
      else
      {
        ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      }

      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Where(x => x.Resource == ResourceType).Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;

    }

    public DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      var DbSearchParameter = new _ServiceSearchParameter();
      DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
      DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
      DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
      DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
      DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
      DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
      DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
      DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
      DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
      if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
      {
        DbSearchParameter.TargetResourceTypeList = new List<_ServiceSearchParameterTargetResource>();
        foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
          DbSearchParameter.TargetResourceTypeList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
      }
      _ServiceSearchParameter value = AddServiceSearchParameters(DbSearchParameter);
      ServiceSearchParameterHeavy.Id = value.Id;
      this.Save();
      return ServiceSearchParameterHeavy;
    }

    public DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      var DbSearchParameter = new _ServiceSearchParameter();
      DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
      DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
      DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
      DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
      DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
      DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
      DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
      DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
      DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
      if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
      {
        DbSearchParameter.TargetResourceTypeList = new List<_ServiceSearchParameterTargetResource>();
        foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
          DbSearchParameter.TargetResourceTypeList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
      }
      _ServiceSearchParameter value = UpdateServiceSearchParameters(ServiceSearchParameterHeavy.Id, DbSearchParameter);
      ServiceSearchParameterHeavy.Id = value.Id;
      return ServiceSearchParameterHeavy;
    }

    public void DeleteServiceSearchParameters(int Id)
    {
      var Entity = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      if (Entity != null)
      {
        IPyroDbContext.ServiceSearchParameter.Remove(Entity);
        this.Save();
      }
    }

    private _ServiceSearchParameter AddServiceSearchParameters(_ServiceSearchParameter ServiceSearchParameter)
    {
      ServiceSearchParameter = IPyroDbContext.Set<_ServiceSearchParameter>().Add(ServiceSearchParameter);
      this.Save();
      return ServiceSearchParameter;
    }

    private _ServiceSearchParameter GetServiceSearchParameters(string ResourceType, string Name)
    {
      return IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Resource == ResourceType & x.Name == Name);
    }

    private _ServiceSearchParameter UpdateServiceSearchParameters(int Id, _ServiceSearchParameter SearchParameter)
    {
      var DbSearchParameter = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      DbSearchParameter.Description = SearchParameter.Description;
      DbSearchParameter.Expression = SearchParameter.Expression;
      DbSearchParameter.IsIndexed = SearchParameter.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = SearchParameter.Name;
      DbSearchParameter.Resource = SearchParameter.Resource;
      DbSearchParameter.SearchParameterResourceId = SearchParameter.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = SearchParameter.SearchParameterResourceVersion;
      DbSearchParameter.Status = SearchParameter.Status;
      DbSearchParameter.TargetResourceTypeList = SearchParameter.TargetResourceTypeList;
      DbSearchParameter.Type = SearchParameter.Type;
      DbSearchParameter.Url = SearchParameter.Url;
      DbSearchParameter.XPath = SearchParameter.XPath;
      IPyroDbContext.Entry(DbSearchParameter).State = EntityState.Modified;
      this.Save();
      return DbSearchParameter;
    }

    private List<_ServiceSearchParameter> GetAllServiceSearchParameters()
    {
      return IPyroDbContext.ServiceSearchParameter.ToList();
    }

  }
}
