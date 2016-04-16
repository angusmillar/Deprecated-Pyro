[assembly: WebActivator.PostApplicationStartMethod(typeof(Blaze.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Blaze.App_Start
{
  using System.Web.Http;
  using SimpleInjector;
  using SimpleInjector.Integration.WebApi;
  using Common.Interfaces.Repositories;
  using Common.Interfaces.Services;
  using Common.Interfaces;
  using DataModel;
  

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
      container.Register<IUnitOfWork, DataModel.UnitOfWork>(Lifestyle.Scoped);      
      //container.Register<IUnitOfWork, DataModel.UnitOfWork>(Lifestyle.Scoped);      
      container.Register<IFhirServiceNegotiator, Blaze.BlazeService.FhirServiceNegotiator>(Lifestyle.Singleton);      
      container.Register<IPatientResourceServices, Blaze.Engine.Services.PatientResourceServices>(Lifestyle.Scoped);
      //container.Register<IValueSetResourceServices, Blaze.Engine.Services.ValueSetResourceServices>(Lifestyle.Scoped);
      //container.Register<IConceptMapResourceServices, Blaze.Engine.Services.ConceptMapResourceServices>(Lifestyle.Scoped);
      container.Register<IDefaultResourceServices, Blaze.Engine.Services.DefaultResourceServices>(Lifestyle.Scoped);            

    }
  }
}