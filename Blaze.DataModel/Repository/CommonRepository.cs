using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Blaze.DataModel.DatabaseModel;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.DataModel.Repository
{
  public class CommonRepository : BaseRepository, ICommonRepository
  {
    #region Constructor
    public CommonRepository(DataModel.DatabaseModel.DatabaseContext Context)
    {
      _Context = Context;
    }
    #endregion

    public DtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      Blaze_RootUrlStore ExsistingPrimaryRootURL = this.GetPrimaryBlaze_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;        
      }
      Blaze_RootUrlStore ExsistingNonPrimaryRootURL = this.GetBlaze_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;        
      }
      else
      {
        Blaze_RootUrlStore Blaze_RootUrlStore = new Blaze_RootUrlStore();
        Blaze_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Blaze_RootUrlStore.RootUrl = RootUrl;
        _Context.Set<Blaze_RootUrlStore>().Add(Blaze_RootUrlStore);        
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public DtoRootUrlStore GetPrimaryRootUrlStore()
    {
      DtoRootUrlStore DtoRootUrlStore = null;
      Blaze_RootUrlStore Blaze_RootUrlStore = this.GetPrimaryBlaze_RootUrlStore();      
      if (Blaze_RootUrlStore != null)
      {
        DtoRootUrlStore = new DtoRootUrlStore();
        DtoRootUrlStore.Blaze_RootUrlStoreID = Blaze_RootUrlStore.Blaze_RootUrlStoreID;
        DtoRootUrlStore.RootUrl = Blaze_RootUrlStore.RootUrl;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = Blaze_RootUrlStore.IsServersPrimaryUrlRoot;
      }
      return DtoRootUrlStore;
    }

    /// <summary>
    /// Gets the RootUrlStore Instance if found or creates a new instance if not found 
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    public Blaze_RootUrlStore GetAndOrAddBlaze_RootUrlStore(string ServiceRootUrl)
    {
      Blaze_RootUrlStore Blaze_RootUrlStore = this.GetBlaze_RootUrlStore(ServiceRootUrl);
      if (Blaze_RootUrlStore == null)
      {
        Blaze_RootUrlStore = new Blaze_RootUrlStore();
        Blaze_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Blaze_RootUrlStore.RootUrl = ServiceRootUrl;
        return Blaze_RootUrlStore;
      }
      else
      {
        return Blaze_RootUrlStore;
      }
    }

    protected Blaze_RootUrlStore GetPrimaryBlaze_RootUrlStore()
    {
      return _Context.Blaze_RootUrlStore.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    /// <summary>
    /// Get a RootUrlStore by Url string
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    protected Blaze_RootUrlStore GetBlaze_RootUrlStore(string ServiceRootUrl)
    {
      return _Context.Blaze_RootUrlStore.SingleOrDefault(x => x.RootUrl == ServiceRootUrl);
    }

    protected T DbGet<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      T ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected IEnumerable<T> DbGetALL<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      IEnumerable<T> ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().Where(predicate);
      return ResourceEntity;
    }

    protected void DbAddEntity<T>(T Entity) where T : class
    {
      _Context.Set<T>().Add(Entity);
      this.Save();
    }

    protected T DbQueryEntityWithInclude<T>(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> IncludeList) where T : class
    {
      T ResourceEntity = null;

      IQueryable<T> query = _Context.Set<T>();

      //Apply includes
      foreach (Expression<Func<T, object>> include in IncludeList)
        query = query.Include<T, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

  }
}
