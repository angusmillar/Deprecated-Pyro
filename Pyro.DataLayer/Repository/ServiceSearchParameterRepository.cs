using Hl7.Fhir.Model;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Search;
using Pyro.DataLayer.DbModel.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Interfaces.Repositories;
using System.Data.Entity.Infrastructure;

namespace Pyro.DataLayer.Repository
{
  public class ServiceSearchParameterRepository : BaseRepository, IServiceSearchParameterRepository
  {
    public ServiceSearchParameterRepository(IPyroDbContext IPyroDbContext)
      : base(IPyroDbContext) { }

    // SearchParameterLight Methods =================================================================
    public List<DtoServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType)
    {
      var ReturnList = new List<DtoServiceSearchParameterLight>();

      var DynamicList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Include(c => c.ServiceSearchParameterCompositePivotList)
        .Where(x => x.Resource == ResourceType & x.IsIndexed == true & (x.Status == PublicationStatus.Active || x.Status == PublicationStatus.Draft))
        .Select(x => new { x.Id, x.Name, x.Expression, x.Resource, x.Type, x.TargetResourceTypeList, x.ServiceSearchParameterCompositePivotList }).ToList();

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
          Light.TargetResourceTypeList = PopulateDtoTargetResourceList(x.TargetResourceTypeList);
          Light.CompositeList = PopulateDtoCompositeList(x.ServiceSearchParameterCompositePivotList);          
          ReturnList.Add(Light);
        }
      }
      return ReturnList;
    }

    // SearchParameterHeavy Methods =================================================================
    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyByIsIndexed(bool IsIndexed)
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();

      List<_ServiceSearchParameter> ResourceServiceSearchParameterList;

      ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter
        .Include(x => x.TargetResourceTypeList)
        .Include(x => x.ServiceSearchParameterCompositePivotList)
        .Where(y => y.IsIndexed == IsIndexed).ToList();

      foreach (var x in ResourceServiceSearchParameterList)
      {
        ReturnList.Add(PopulateDtoSearchParameterHeavy(x));
      }     
      return ReturnList;
    }

    public DtoServiceSearchParameterHeavy GetServiceSearchParametersHeavyById(int Id)
    {
      _ServiceSearchParameter ServiceSearchParameter = IPyroDbContext.ServiceSearchParameter
        .Include(x => x.TargetResourceTypeList)
        .Include(x => x.ServiceSearchParameterCompositePivotList)
        .SingleOrDefault(y => y.Id == Id);
      if (ServiceSearchParameter != null)
      {
        return PopulateDtoSearchParameterHeavy(ServiceSearchParameter);
      }
      return null;
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();
      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter
        .Include(x => x.TargetResourceTypeList)
        .Include(x => x.ServiceSearchParameterCompositePivotList)
        .ToList();

      foreach (var x in ResourceServiceSearchParameterList)
      {
        ReturnList.Add(PopulateDtoSearchParameterHeavy(x));
      }
      return ReturnList;
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();
      
      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter
                                                  .Where(x => x.Resource == ResourceType)
                                                  .Include(x => x.TargetResourceTypeList)
                                                  .Include(x => x.ServiceSearchParameterCompositePivotList)
                                                  .ToList();

      foreach (var x in ResourceServiceSearchParameterList)
      {
        ReturnList.Add(PopulateDtoSearchParameterHeavy(x));
      }
      return ReturnList;
    }

    public DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      var DateStamp = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
      ServiceSearchParameterHeavy.CreatedDate = DateStamp;
      ServiceSearchParameterHeavy.CreatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      ServiceSearchParameterHeavy.LastUpdated = DateStamp;
      ServiceSearchParameterHeavy.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;

      var DbSearchParameter = PopulateDbSearchParameter(ServiceSearchParameterHeavy);      
      DbSearchParameter = IPyroDbContext.Set<_ServiceSearchParameter>().Add(DbSearchParameter);
      this.Save();
      ServiceSearchParameterHeavy.Id = DbSearchParameter.Id;      
      return ServiceSearchParameterHeavy;
    }

    public DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      ServiceSearchParameterHeavy.LastUpdated = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
      ServiceSearchParameterHeavy.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      var DbSearchParameter = PopulateDbSearchParameter(ServiceSearchParameterHeavy);      
      DbSearchParameter = UpdateServiceSearchParameters(ServiceSearchParameterHeavy.Id, DbSearchParameter);
      ServiceSearchParameterHeavy.Id = DbSearchParameter.Id;      
      return ServiceSearchParameterHeavy;
    }

    public _ServiceSearchParameter PopulateDbSearchParameter(DtoServiceSearchParameterHeavy DtoServiceSearchParameterHeavy)
    {
      var DbSearchParameter = new _ServiceSearchParameter();
      DbSearchParameter.Description = DtoServiceSearchParameterHeavy.Description;
      DbSearchParameter.Expression = DtoServiceSearchParameterHeavy.Expression;
      DbSearchParameter.IsIndexed = DtoServiceSearchParameterHeavy.IsIndexed;

      DbSearchParameter.LastUpdated = DtoServiceSearchParameterHeavy.LastUpdated;
      DbSearchParameter.LastUpdatedUser = DtoServiceSearchParameterHeavy.LastUpdatedUser;
      DbSearchParameter.CreatedDate = DtoServiceSearchParameterHeavy.CreatedDate;
      DbSearchParameter.CreatedUser = DtoServiceSearchParameterHeavy.CreatedUser;

      DbSearchParameter.Name = DtoServiceSearchParameterHeavy.Name;
      DbSearchParameter.Resource = DtoServiceSearchParameterHeavy.Resource;
      DbSearchParameter.SearchParameterResourceId = DtoServiceSearchParameterHeavy.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = DtoServiceSearchParameterHeavy.SearchParameterResourceVersion;
      DbSearchParameter.Status = DtoServiceSearchParameterHeavy.Status;
      DbSearchParameter.Type = DtoServiceSearchParameterHeavy.Type;
      DbSearchParameter.Url = DtoServiceSearchParameterHeavy.Url;
      DbSearchParameter.XPath = DtoServiceSearchParameterHeavy.XPath;
      DbSearchParameter.TargetResourceTypeList = PopulateDbTargetResourceList(DtoServiceSearchParameterHeavy.TargetResourceTypeList);
      DbSearchParameter.ServiceSearchParameterCompositePivotList = PopulateDbCompositeList(DtoServiceSearchParameterHeavy.CompositeList);
      return DbSearchParameter;
    }

    public DtoServiceSearchParameterHeavy PopulateDtoSearchParameterHeavy(_ServiceSearchParameter DbServiceSearchParameter)
    {
      var Heavy = new DtoServiceSearchParameterHeavy();
      Heavy.Id = DbServiceSearchParameter.Id;
      Heavy.Name = DbServiceSearchParameter.Name;
      Heavy.Expression = DbServiceSearchParameter.Expression;
      Heavy.Resource = DbServiceSearchParameter.Resource;
      Heavy.Type = DbServiceSearchParameter.Type;
      Heavy.Description = DbServiceSearchParameter.Description;
      Heavy.Url = DbServiceSearchParameter.Url;
      Heavy.XPath = DbServiceSearchParameter.XPath;
      Heavy.SearchParameterResourceId = DbServiceSearchParameter.SearchParameterResourceId;
      Heavy.SearchParameterResourceVersion = DbServiceSearchParameter.SearchParameterResourceVersion;
      Heavy.Status = DbServiceSearchParameter.Status;
      Heavy.IsIndexed = DbServiceSearchParameter.IsIndexed;
      Heavy.LastUpdated = DbServiceSearchParameter.LastUpdated;
      Heavy.LastUpdatedUser = DbServiceSearchParameter.LastUpdatedUser;
      Heavy.CreatedDate = DbServiceSearchParameter.CreatedDate;
      Heavy.CreatedUser = DbServiceSearchParameter.CreatedUser;
      Heavy.TargetResourceTypeList = PopulateDtoTargetResourceList(DbServiceSearchParameter.TargetResourceTypeList);
      Heavy.CompositeList = PopulateDtoCompositeList(DbServiceSearchParameter.ServiceSearchParameterCompositePivotList);
      return Heavy;
    }

    // ServiceSearchParameter Methods =================================================================
    private _ServiceSearchParameter GetServiceSearchParameters(string ResourceType, string Name)
    {
      return IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Resource == ResourceType & x.Name == Name);
    }

    private _ServiceSearchParameter UpdateServiceSearchParameters(int Id, _ServiceSearchParameter SearchParameter)
    {
      var DbSearchParameter = IPyroDbContext.ServiceSearchParameter
        .Include(x => x.TargetResourceTypeList)
        .Include(x => x.ServiceSearchParameterCompositePivotList)
        .SingleOrDefault(x => x.Id == Id);

      //We must tell EF to delete each child element not just assign the new list.
      //We could try and work out the difference between the two lists and only Add, Update and Remove as required
      //Yet given this is a very infrequent process with very small numbers it is just easier to delete all 
      // and add the entire new list.
      for (int i = DbSearchParameter.TargetResourceTypeList.Count - 1; i >= 0; i--)
      {
        (IPyroDbContext as IObjectContextAdapter).ObjectContext.DeleteObject(DbSearchParameter.TargetResourceTypeList.ElementAt(i));
      }

      for (int i = DbSearchParameter.ServiceSearchParameterCompositePivotList.Count - 1; i >= 0; i--)
      {
        (IPyroDbContext as IObjectContextAdapter).ObjectContext.DeleteObject(DbSearchParameter.ServiceSearchParameterCompositePivotList.ElementAt(i));
      }

      DbSearchParameter.Description = SearchParameter.Description;
      DbSearchParameter.Expression = SearchParameter.Expression;
      DbSearchParameter.IsIndexed = SearchParameter.IsIndexed;
      DbSearchParameter.LastUpdatedUser = SearchParameter.LastUpdatedUser;
      DbSearchParameter.LastUpdated = SearchParameter.LastUpdated;
      DbSearchParameter.CreatedUser = SearchParameter.CreatedUser;
      DbSearchParameter.CreatedDate = SearchParameter.CreatedDate;
      DbSearchParameter.Name = SearchParameter.Name;
      DbSearchParameter.Resource = SearchParameter.Resource;
      DbSearchParameter.SearchParameterResourceId = SearchParameter.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = SearchParameter.SearchParameterResourceVersion;
      DbSearchParameter.Status = SearchParameter.Status;
      DbSearchParameter.TargetResourceTypeList = SearchParameter.TargetResourceTypeList;
      DbSearchParameter.ServiceSearchParameterCompositePivotList = SearchParameter.ServiceSearchParameterCompositePivotList;
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

    public void DeleteServiceSearchParameters(int Id)
    {
      var Entity = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      if (Entity != null)
      {
        IPyroDbContext.ServiceSearchParameter.Remove(Entity);
        this.Save();
      }
    }

    // Target Resource List =====================================================================

    private List<_ServiceSearchParameterTargetResource> PopulateDbTargetResourceList(List<IServiceSearchParameterTargetResource> TargetResourceList)
    {
      if (TargetResourceList == null || TargetResourceList.Count == 0)
        return null;

      var DbTargetResourceList = new List<_ServiceSearchParameterTargetResource>();

      foreach (var Target in TargetResourceList)
        DbTargetResourceList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });

      return DbTargetResourceList;
    }

    private List<IServiceSearchParameterTargetResource> PopulateDtoTargetResourceList(ICollection<_ServiceSearchParameterTargetResource> DbTargetResourceList)
    {
      var DtoTargetResourceList = new List<IServiceSearchParameterTargetResource>();
      if (DbTargetResourceList == null || DbTargetResourceList.Count == 0)
        return DtoTargetResourceList;
      
      foreach (var Target in DbTargetResourceList)
        DtoTargetResourceList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });

      return DtoTargetResourceList;
    }

    // Composite Methods =====================================================================
    private List<_ServiceSearchParameterCompositePivot> PopulateDbCompositeList(List<DtoServiceSearchParameterComposite> CompositeList)
    {
      if (CompositeList == null || CompositeList.Count == 0)
        return null;

      var ServiceSearchParameterCompositePivotList = new List<_ServiceSearchParameterCompositePivot>();
      foreach (var Composite in CompositeList)
      {
        var DbComposite = new _ServiceSearchParameterCompositePivot()
        {
          Expression = Composite.Expression,
          Url = Composite.Url,
          SequentialOrder = Composite.SequentialOrder,          
          ChildServiceSearchParameterId = Composite.ChildServiceSearchParameterId,          
        };
        ServiceSearchParameterCompositePivotList.Add(DbComposite);
      }
      return ServiceSearchParameterCompositePivotList;
    }

    private List<DtoServiceSearchParameterComposite> PopulateDtoCompositeList(ICollection<_ServiceSearchParameterCompositePivot> DbCompositeList)
    {
      var DtoServiceSearchParameterComposite = new List<DtoServiceSearchParameterComposite>();

      if (DbCompositeList == null || DbCompositeList.Count == 0)
        return DtoServiceSearchParameterComposite;

      foreach (var Composite in DbCompositeList)
      {
        var DtoComposite = new DtoServiceSearchParameterComposite()
        {
          Expression = Composite.Expression,
          Url = Composite.Url,
          SequentialOrder = Composite.SequentialOrder,
          ChildServiceSearchParameterId = Composite.ChildServiceSearchParameterId,
          ParentServiceSearchParameterId = Composite.ParentServiceSearchParameterId,
          Id = Composite.Id          
        };
        DtoServiceSearchParameterComposite.Add(DtoComposite);
      }
      return DtoServiceSearchParameterComposite;
    }

    private List<DtoServiceSearchParameterComposite> GetCompositeListForSearchParameterId(int SearchParameterId)
    {
      var ReturnList = new List<DtoServiceSearchParameterComposite>();
      var CompositeList = IPyroDbContext.ServiceSearchParameterCompositePivot.Where(y => y.Id == SearchParameterId).ToList();
      foreach (var Composite in CompositeList)
      {
        var DtoComposite = new DtoServiceSearchParameterComposite()
        {
          Id = Composite.Id,
          Expression = Composite.Expression,
          Url = Composite.Url,
          SequentialOrder = Composite.SequentialOrder,
          ChildServiceSearchParameterId = Composite.ChildServiceSearchParameterId,
          ParentServiceSearchParameterId = Composite.ParentServiceSearchParameterId
        };
        ReturnList.Add(DtoComposite);
      }
      return ReturnList;
    }

  }
}
