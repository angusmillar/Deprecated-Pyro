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
  using Pyro.Common.Service;
  using Pyro.DataLayer.DbModel.UnitOfWork;
  using Pyro.DataLayer.DbModel.DatabaseContext;
  using Pyro.Common.Global;
  using Pyro.Common.Interfaces.ITools;
  using Pyro.Common.Tools;
  using Pyro.Common.Logging;
  using Pyro.Common.ServiceRoot;
  using Pyro.Common.Tools.Headers;
  using Pyro.Common.Tools.UriSupport;
  using Pyro.Common.Interfaces.Dto;
  using Pyro.Common.Search;
  using Pyro.Common.ServiceSearchParameter;
  using Pyro.Common.Tools.FhirResourceValidation;
  using Hl7.Fhir.Specification.Source;
  using Pyro.DataLayer.Repository.Interfaces;
  using Pyro.DataLayer.Repository;
  using Pyro.DataLayer.IndexSetter;
  using Pyro.Common.Cache;
  using Pyro.Common.BusinessEntities.Dto;
  using Pyro.Common.Tools.FhirNarrative;
  using Pyro.Common.FhirHttpResponse;
  using Pyro.Common.Interfaces.Tools.HtmlSupport;
  using Pyro.Common.Exceptions;

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
      //========================================================================================================
      //=================== Singleton ==========================================================================            
      //========================================================================================================

      container.RegisterConditional(typeof(ILog), context => typeof(Log<>).MakeGenericType(context.Consumer.ImplementationType), Lifestyle.Singleton, context => true);
      container.Register<IGlobalProperties, GlobalProperties>(Lifestyle.Singleton);
      container.Register<IFhirExceptionFilter, FhirExceptionFilter>(Lifestyle.Transient);

      container.Register<Pyro.Common.CompositionRoot.ICommonFactory, Pyro.Web.CompositionRoot.CommonFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParametersServiceOutcomeFactory, Pyro.Web.CompositionRoot.SearchParametersServiceOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterGenericFactory, Pyro.Web.CompositionRoot.SearchParameterGenericFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterReferanceFactory, Pyro.Web.CompositionRoot.SearchParameterReferanceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterServiceFactory, Pyro.Web.CompositionRoot.SearchParameterServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IPyroFhirUriFactory, Pyro.Web.CompositionRoot.PyroFhirUriFactory>(Lifestyle.Singleton);


      container.Register<Pyro.Common.CompositionRoot.IResourceRepositoryFactory, Pyro.Web.CompositionRoot.ResourceRepositoryFactory>(Lifestyle.Singleton);

      //Singleton: Cache      
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(Lifestyle.Singleton);
      container.Register<ICacheClear, CacheClear>(Lifestyle.Singleton);


      //========================================================================================================
      //=================== Transient ==========================================================================            
      //========================================================================================================      
      container.Register<IFhirResourceNarrative, FhirResourceNarrative>(Lifestyle.Transient);
      container.Register<IHtmlGenerationSupport, HtmlGenerationSupport>(Lifestyle.Transient);

      container.Register<IRequestHeader, RequestHeader>(Lifestyle.Transient);
      container.Register<IPyroFhirUri, PyroFhirUri>(Lifestyle.Transient);
      container.Register<IPyroRequestUri, PyroRequestUri>(Lifestyle.Transient);
      container.Register<IDtoRootUrlStore, DtoRootUrlStore>(Lifestyle.Transient);
      container.Register<IFhirRestResponse, FhirRestResponse>(Lifestyle.Transient);

      container.Register<IBundleTransactionService, BundleTransactionService>(Lifestyle.Transient);
      container.Register<IMetadataService, MetadataService>(Lifestyle.Transient);

      container.Register<ISearchParameterService, SearchParameterService>(Lifestyle.Transient);
      container.Register<ISearchParameterGeneric, SearchParameterGeneric>(Lifestyle.Transient);
      container.Register<ISearchParameterReferance, SearchParameterReferance>(Lifestyle.Transient);
      container.Register<ISearchParametersServiceOutcome, SearchParametersServiceOutcome>(Lifestyle.Transient);
      container.Register<IDatabaseOperationOutcome, DtoDatabaseOperationOutcome>(Lifestyle.Transient);
      container.Register<IResourceServiceOutcome, ResourceServiceOutcome>(Lifestyle.Transient);

      //Transient: Index Setters
      container.RegisterConditional(typeof(IIndexSetterFactory<,,,,,,>), typeof(Pyro.Web.CompositionRoot.IndexSetterFactory<,,,,,,>), Lifestyle.Scoped, c => !c.Handled);
      container.RegisterConditional(typeof(IReferenceSetter<,,,,,,>), typeof(ReferenceSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(INumberSetter<,,,,,,>), typeof(NumberSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IDateTimeSetter<,,,,,,>), typeof(DateTimeSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IQuantitySetter<,,,,,,>), typeof(QuantitySetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IStringSetter<,,,,,,>), typeof(StringSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(ITokenSetter<,,,,,,>), typeof(TokenSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IUriSetter<,,,,,,>), typeof(UriSetter<,,,,,,>), c => !c.Handled);

      //========================================================================================================
      //=================== Scoped =============================================================================            
      //========================================================================================================
      container.Register<IRequestServiceRootValidate, RequestServiceRootValidate>(Lifestyle.Scoped);
      container.Register<IPyroDbContext, PyroDbContext>(Lifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<IServiceNegotiator, ServiceNegotiator>(Lifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(Lifestyle.Scoped);
      container.Register<IPyroService, PyroService>(Lifestyle.Scoped);
      container.Register<ICommonServices, CommonServices>(Lifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(Lifestyle.Scoped);
      container.Register<ISearchParameterFactory, SearchParameterFactory>(Lifestyle.Scoped);
      container.Register<IIncludeService, IncludeService>(Lifestyle.Scoped);

      //Scoped: Operations Locator 
      container.Register<IFhirBaseOperationService, FhirBaseOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceInstanceOperationService, FhirResourceInstanceOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceOperationService, FhirResourceOperationService>(Lifestyle.Scoped);
      //Scoped: Operations
      container.Register<IDeleteHistoryIndexesService, DeleteHistoryIndexesService>(Lifestyle.Scoped);
      container.Register<IServerSearchParameterService, ServerSearchParameterService>(Lifestyle.Scoped);
      container.Register<IServerResourceReportService, ServerResourceReportService>(Lifestyle.Scoped);
      container.Register<IFhirValidateOperationService, FhirValidateOperationService>(Lifestyle.Scoped);
      container.Register<IFhirValidationSupport, FhirValidationSupport>(Lifestyle.Scoped);
      container.Register<IConnectathonAnswerService, ConnectathonAnswerService>(Lifestyle.Scoped);

      //Scoped: Cache
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);

      //Scoped: Load all the FHIR Validation Resolvers 
      container.RegisterCollection<IResourceResolver>(new[] { typeof(InternalServerProfileResolver), typeof(AustralianFhirProfileResolver), typeof(ZipSourceResolver) });

      //Scoped: Bellow returns all CommonResourceRepository types to be registered in contaioner
      var CommonResourceRepositoryTypeList = Pyro.DataLayer.DbModel.EntityGenerated.CommonResourceRepositoryTypeList.GetTypeList();
      container.Register(typeof(ICommonResourceRepository<,,,,,,>), CommonResourceRepositoryTypeList.ToArray(), Lifestyle.Scoped);
      container.Register<ICommonRepository, CommonRepository>(Lifestyle.Scoped);

    }
  }
}