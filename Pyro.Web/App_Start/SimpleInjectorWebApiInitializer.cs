[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Pyro.Web.App_Start
{
  using System.Web.Http;
  using SimpleInjector;
  using SimpleInjector.Integration.WebApi;
  using Pyro.Common.Interfaces.Repositories;
  using Pyro.Common.Interfaces.Services;
  using Pyro.Common.Interfaces;
  using Pyro.DataModel;


  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize()
    {
      var container = new Container();
      container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

      InitializeContainer(container);

      container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

      container.Verify();

      GlobalConfiguration.Configuration.DependencyResolver =
          new SimpleInjectorWebApiDependencyResolver(container);
    }

    private static void InitializeContainer(Container container)
    {
      //Register interfaces with simple injector
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<IFhirServiceNegotiator, Services.FhirServiceNegotiator>(Lifestyle.Singleton);
      container.Register<IPatientResourceServices, Pyro.Engine.Services.PatientResourceServices>(Lifestyle.Scoped);
      container.Register<IDefaultResourceServices, Pyro.Engine.Services.DefaultResourceServices>(Lifestyle.Scoped);
      container.Register<ICommonServices, Pyro.Engine.Services.CommonServices>(Lifestyle.Scoped);

    }
  }
}