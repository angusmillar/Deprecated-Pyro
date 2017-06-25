//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Web.App_Start
{
  using System.Web.Http;
  using SimpleInjector;
  using SimpleInjector.Integration.WebApi;
  using Pyro.Web.Services;
  using Pyro.Engine.Services;
  using Pyro.Common.Interfaces.Repositories;
  using Pyro.Common.Interfaces.Service;
  using Pyro.DataLayer.DbModel.UnitOfWork;
  using Pyro.DataLayer.DbModel.DatabaseContext;
  using Pyro.Common.BusinessEntities.Global;
  using Pyro.Common.Interfaces.ITools;
  using Pyro.Common.Tools;


  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize(HttpConfiguration configuration)
    {
      var container = new Container();
      container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

      InitializeContainer(container);

      container.RegisterWebApiControllers(configuration);

      container.Verify();

      configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

    }

    private static void InitializeContainer(Container container)
    {
      //Singleton
      container.Register<IGlobalProperties, GlobalProperties>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Singleton);

      //Scoped      
      container.Register<IPyroDbContext, PyroDbContext>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IServiceNegotiator, ServiceNegotiator>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IPyroService, PyroService>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
    }
  }
}