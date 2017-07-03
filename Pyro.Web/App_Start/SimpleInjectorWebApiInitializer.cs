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
  using Pyro.Common.ServiceSearchParameter;

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
      container.Register<IGlobalProperties, GlobalProperties>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ICommonFactory, Pyro.Web.CompositionRoot.CommonFactory>(Lifestyle.Singleton);

      //Transient
      container.Register<IDtoRequestHeaders, DtoRequestHeaders>(Lifestyle.Transient);
      container.Register<IFhirRequestUri, Pyro.Common.BusinessEntities.UriSupport.FhirRequestUriForDi>(Lifestyle.Transient);
      container.Register<IDtoRequestUri, Pyro.Common.BusinessEntities.UriSupport.DtoRequestUriForDi>(Lifestyle.Transient);
      container.Register<IDtoSearchParameterGeneric, DtoSearchParameterGenericForDi>(Lifestyle.Transient);

      container.Register<IBundleTransactionService, BundleTransactionService>(Lifestyle.Transient);
      container.Register<IMetadataService, MetadataService>(Lifestyle.Transient);
      container.Register<ISearchParameterService, SearchParameterService>(Lifestyle.Transient);
      container.Register<IDtoSearchParameterReferance, DtoSearchParameterReferance>(Lifestyle.Transient);


      //Scoped      
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(Lifestyle.Scoped);
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);

      container.Register<IRequestServiceRootValidate, RequestServiceRootValidate>(Lifestyle.Scoped);
      container.Register<IPyroDbContext, PyroDbContext>(Lifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<IServiceNegotiator, ServiceNegotiator>(Lifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(Lifestyle.Scoped);
      container.Register<IPyroService, PyroService>(Lifestyle.Scoped);
      container.Register<ICommonServices, CommonServices>(Lifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(Lifestyle.Scoped);

      container.Register<ISearchParameterFactory, SearchParameterFactory>(Lifestyle.Scoped);

      //Scoped Operations Locator 
      container.Register<IFhirBaseOperationService, FhirBaseOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceInstanceOperationService, FhirResourceInstanceOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceOperationService, FhirResourceOperationService>(Lifestyle.Scoped);
      //Scoped Operations
      container.Register<IDeleteHistoryIndexesService, DeleteHistoryIndexesService>(Lifestyle.Scoped);
      container.Register<IServerSearchParameterService, ServerSearchParameterService>(Lifestyle.Scoped);
      container.Register<IServerResourceReportService, ServerResourceReportService>(Lifestyle.Scoped);
      container.Register<IFhirValidateOperationService, FhirValidateOperationService>(Lifestyle.Scoped);



    }
  }
}