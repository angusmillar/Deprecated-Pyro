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
  using Pyro.Common.Logging;
  using Pyro.Common.ServiceRoot;
  using Pyro.Common.Interfaces.Dto.Headers;
  using Pyro.Common.BusinessEntities.Dto.Headers;
  using Pyro.Common.Interfaces.UriSupport;
  using Pyro.Common.Interfaces.Dto;
  using Pyro.Common.BusinessEntities.Search;
  using Pyro.Common.BusinessEntities.Service;

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
      container.RegisterConditional(typeof(ILog), context => typeof(Log<>).MakeGenericType(context.Consumer.ImplementationType), Lifestyle.Singleton, context => true);
      container.Register<IGlobalProperties, GlobalProperties>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ICommonFactory, Pyro.Web.CompositionRoot.CommonFactory>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Singleton);

      //Transient
      container.Register<IDtoRequestHeaders, DtoRequestHeaders>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);
      container.Register<IFhirRequestUri, Pyro.Common.BusinessEntities.UriSupport.FhirRequestUriForDi>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);
      container.Register<IDtoRequestUri, Pyro.Common.BusinessEntities.UriSupport.DtoRequestUriForDi>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);
      container.Register<IDtoSearchParameterGeneric, DtoSearchParameterGenericForDi>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);

      container.Register<IBundleTransactionService, BundleTransactionService>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);
      container.Register<IMetadataService, MetadataService>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Transient);




      //Scoped            
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IRequestServiceRootValidate, RequestServiceRootValidate>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IPyroDbContext, PyroDbContext>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IServiceNegotiator, ServiceNegotiator>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IPyroService, PyroService>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<ICommonServices, CommonServices>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(SimpleInjector.Lifestyles.AsyncScopedLifestyle.Scoped);
    }
  }
}