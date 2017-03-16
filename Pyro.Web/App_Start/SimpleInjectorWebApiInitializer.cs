//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Web.App_Start
{
  using System.Web.Http;
  using SimpleInjector;
  using SimpleInjector.Integration.WebApi;
  using Pyro.Common.Interfaces.Repositories;
  using Pyro.Common.Interfaces.Service;
  using Pyro.DataModel;


  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize(HttpConfiguration configuration)
    {
      var container = new Container();
      container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

      InitializeContainer(container);

      container.RegisterWebApiControllers(configuration);

      container.Verify();

      configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

    }

    private static void InitializeContainer(Container container)
    {
      //Register interfaces with simple injector
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<IServiceNegotiator, Services.ServiceNegotiator>(Lifestyle.Singleton);      
      container.Register<IDefaultResourceServices, Pyro.Engine.Services.DefaultResourceServices>(Lifestyle.Scoped);
      container.Register<ICommonServices, Pyro.Engine.Services.CommonServices>(Lifestyle.Scoped);
    }
  }
}