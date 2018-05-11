using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Tools;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.Repository.Interfaces;
using System.Linq;

namespace Pyro.DataLayer.Repository
{
  public class ServiceBaseUrlRepository : BaseRepository, IServicePrimaryBaseUrlRepository, IServiceBaseUrlRepository
  {
    private readonly IDtoRootUrlStoreFactory IDtoRootUrlStoreFactory;
    public ServiceBaseUrlRepository(IPyroDbContext IPyroDbContext, IDtoRootUrlStoreFactory IDtoRootUrlStoreFactory)
      : base (IPyroDbContext)
    {
      this.IDtoRootUrlStoreFactory = IDtoRootUrlStoreFactory;
    }

    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      RootUrl = StringSupport.ToLowerFast(RootUrl.StripHttp());
      _ServiceBaseUrl ExsistingPrimaryRootURL = this.GetPrimaryPyro_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
      }
      _ServiceBaseUrl ExsistingNonPrimaryRootURL = this.GetPyro_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
      }
      else
      {
        _ServiceBaseUrl Pyro_RootUrlStore = new _ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Pyro_RootUrlStore.Url = RootUrl;
        IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStore()
    {
      IDtoRootUrlStore DtoRootUrlStore = null;
      _ServiceBaseUrl oServiceBaseUrl = GetPrimaryPyro_RootUrlStore();
      if (oServiceBaseUrl != null)
      {
        DtoRootUrlStore = IDtoRootUrlStoreFactory.CreateDtoRootUrlStore();
        DtoRootUrlStore.Id = oServiceBaseUrl.Id;
        DtoRootUrlStore.Url = oServiceBaseUrl.Url;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = oServiceBaseUrl.IsServersPrimaryUrlRoot;
      }
      return DtoRootUrlStore;
    }

    /// <summary>
    /// Gets the ServiceBaseUrl Instance if found or creates a new instance if not found 
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    public _ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      _ServiceBaseUrl Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        Pyro_RootUrlStore = new _ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStore.Url = ServiceRootUrl;
        Pyro_RootUrlStore = IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStore);
        this.Save();
        return Pyro_RootUrlStore;
      }
      else
      {
        return Pyro_RootUrlStore;
      }
    }

    private _ServiceBaseUrl GetPrimaryPyro_RootUrlStore()
    {
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    private _ServiceBaseUrl GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.Url == ServiceRootUrl);
    }
  }
}
