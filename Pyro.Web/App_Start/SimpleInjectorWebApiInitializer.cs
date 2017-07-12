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
  using Pyro.Common.Tools.FhirResourceValidation;
  using Hl7.Fhir.Specification.Source;
  using System.Linq;
  using Pyro.DataLayer.DbModel.EntityGenerated;
  using Pyro.DataLayer.DbModel.EntityBase;
  using Pyro.DataLayer.Repository.Interfaces;
  using Pyro.DataLayer.Repository;
  using Pyro.DataLayer.IndexSetter;
  using Pyro.Web.Formatters;
  using Pyro.Common.Cache;
  using Pyro.Common.BusinessEntities.Dto;

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
      container.Register<Pyro.Common.CompositionRoot.IResourceRepositoryFactory, Pyro.Web.CompositionRoot.ResourceRepositoryFactory>(Lifestyle.Singleton);

      //Singleton: Cache      
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(Lifestyle.Singleton);
      container.Register<ICacheClear, CacheClear>(Lifestyle.Singleton);

      //Singleton: Index Setters
      container.Register<IIndexSetterFactory, Pyro.Web.CompositionRoot.IndexSetterFactory>(Lifestyle.Singleton);
      container.Register<IReferenceSetter, ReferenceSetter>(Lifestyle.Scoped);
      container.Register<INumberSetter, NumberSetter>(Lifestyle.Singleton);
      container.Register<IDateTimeSetter, DateTimeSetter>(Lifestyle.Singleton);
      container.Register<IQuantitySetter, QuantitySetter>(Lifestyle.Singleton);
      container.Register<IStringSetter, StringSetter>(Lifestyle.Singleton);
      container.Register<ITokenSetter, TokenSetter>(Lifestyle.Singleton);
      container.Register<IUriSetter, UriSetter>(Lifestyle.Singleton);



      //Transient
      container.Register<IDtoRequestHeaders, DtoRequestHeaders>(Lifestyle.Transient);
      container.Register<IFhirRequestUri, Pyro.Common.BusinessEntities.UriSupport.FhirRequestUri>(Lifestyle.Transient);
      container.Register<IDtoRequestUri, Pyro.Common.BusinessEntities.UriSupport.DtoRequestUri>(Lifestyle.Transient);
      container.Register<IDtoRootUrlStore, DtoRootUrlStore>(Lifestyle.Transient);


      container.Register<IBundleTransactionService, BundleTransactionService>(Lifestyle.Transient);
      container.Register<IMetadataService, MetadataService>(Lifestyle.Transient);

      container.Register<ISearchParameterService, SearchParameterService>(Lifestyle.Transient);
      container.Register<IDtoSearchParameterGeneric, DtoSearchParameterGenericForDi>(Lifestyle.Transient);
      container.Register<IDtoSearchParameterReferance, DtoSearchParameterReferance>(Lifestyle.Transient);
      container.Register<ISearchParametersServiceOutcome, SearchParametersServiceOutcome>(Lifestyle.Transient);

      container.Register<IFhirNarativeGenerationSupport, FhirNarativeGenerationSupport>(Lifestyle.Transient);
      container.Register<IDatabaseOperationOutcome, DtoDatabaseOperationOutcome>(Lifestyle.Transient);





      //Scoped            
      container.Register<IRequestServiceRootValidate, RequestServiceRootValidate>(Lifestyle.Scoped);
      container.Register<IPyroDbContext, PyroDbContext>(Lifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<IServiceNegotiator, ServiceNegotiator>(Lifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(Lifestyle.Scoped);
      container.Register<IPyroService, PyroService>(Lifestyle.Scoped);
      container.Register<ICommonServices, CommonServices>(Lifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(Lifestyle.Scoped);

      container.Register<ISearchParameterFactory, SearchParameterFactory>(Lifestyle.Scoped);

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

      //Scoped: Cache
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);

      //Scoped: Load all the FHIR Validation Resolvers 
      container.RegisterCollection<IResourceResolver>(new[] { typeof(InternalServerProfileResolver), typeof(AustralianFhirProfileResolver), typeof(ZipSourceResolver) });


      //container.Register<IPatientRes, PatientRes>(Lifestyle.Scoped);
      //container.Register<IPatientResIndex, PatientResIndex>(Lifestyle.Scoped);


      //Bellow returns all CommonResourceRepository types to be registered in contaioner
      var CommonResourceRepositoryTypeList = Pyro.DataLayer.DbModel.EntityGenerated.CommonResourceRepositoryTypeList.GetTypeList();
      container.Register(typeof(ICommonResourceRepository<,>), CommonResourceRepositoryTypeList.ToArray(), Lifestyle.Scoped);
      container.Register<ICommonRepository, CommonRepository>(Lifestyle.Scoped);

    }
  }
}