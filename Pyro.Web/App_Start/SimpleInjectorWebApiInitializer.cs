//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Web.App_Start
{
  using System.Web.Http;
  using SimpleInjector;
  using SimpleInjector.Integration.WebApi;
  using Pyro.Common.Interfaces.Repositories;
  using Pyro.Common.Interfaces.Service;
  using Pyro.DataLayer.DbModel.UnitOfWork;


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
      container.Register<Common.BusinessEntities.Global.IGlobalProperties, Common.BusinessEntities.Global.GlobalProperties>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Singleton);
      container.Register<IUnitOfWork, UnitOfWork>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IServiceNegotiator, Services.ServiceNegotiator>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IResourceServices, Pyro.Engine.Services.ResourceServices>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
    }
  }
}