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
      IDtoRootUrlStore ExsistingPrimaryRootURL = this.GetPrimaryPyro_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
        ExsistingPrimaryRootURL.LastUpdated = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        ExsistingPrimaryRootURL.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      }
      IDtoRootUrlStore ExsistingNonPrimaryRootURL = this.GetPyro_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
        ExsistingNonPrimaryRootURL.LastUpdated = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        ExsistingNonPrimaryRootURL.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
      }
      else
      {
        _ServiceBaseUrl Pyro_RootUrlStore = new _ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Pyro_RootUrlStore.Url = StringSupport.ToLowerFast(RootUrl.StripHttp());
        Pyro_RootUrlStore.LastUpdated = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        Pyro_RootUrlStore.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        Pyro_RootUrlStore.CreatedDate = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        Pyro_RootUrlStore.CreatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStore()
    {
      IDtoRootUrlStore DtoRootUrlStore = null;
      IDtoRootUrlStore oServiceBaseUrl = GetPrimaryPyro_RootUrlStore();
      if (oServiceBaseUrl != null)
      {
        DtoRootUrlStore = IDtoRootUrlStoreFactory.CreateDtoRootUrlStore();
        DtoRootUrlStore.Id = oServiceBaseUrl.Id;
        DtoRootUrlStore.Url = oServiceBaseUrl.Url;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = oServiceBaseUrl.IsServersPrimaryUrlRoot;
        DtoRootUrlStore.LastUpdated = oServiceBaseUrl.LastUpdated;
        DtoRootUrlStore.LastUpdatedUser = oServiceBaseUrl.LastUpdatedUser;
        DtoRootUrlStore.CreatedDate = oServiceBaseUrl.CreatedDate;
        DtoRootUrlStore.CreatedUser = oServiceBaseUrl.CreatedUser;
      }
      return DtoRootUrlStore;
    }

    /// <summary>
    /// Gets the ServiceBaseUrl Instance if found or creates a new instance if not found 
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    public IDtoRootUrlStore GetAndOrAddService_RootUrlStore(string ServiceRootUrl)
    {      
      IDtoRootUrlStore Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        var Pyro_RootUrlStoreDb = new _ServiceBaseUrl();
        Pyro_RootUrlStoreDb.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStoreDb.Url = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
        Pyro_RootUrlStoreDb = IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStoreDb);
        var DateStamp = Common.Tools.DateTimeSupport.UTCDateTimeNow();
        Pyro_RootUrlStoreDb.LastUpdated = DateStamp;
        Pyro_RootUrlStoreDb.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        Pyro_RootUrlStoreDb.CreatedDate = DateStamp;
        Pyro_RootUrlStoreDb.CreatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        this.Save();
        return Pyro_RootUrlStoreDb;
      }
      else
      {
        return Pyro_RootUrlStore;
      }
    }

    private IDtoRootUrlStore GetPrimaryPyro_RootUrlStore()
    {
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    private IDtoRootUrlStore GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());          
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.Url == ServiceRootUrl);
    }
  }
}
