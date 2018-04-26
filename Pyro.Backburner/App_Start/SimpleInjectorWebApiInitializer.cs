//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Backburner.App_Start
{
  //using System.Web.Http;
  using SimpleInjector;
  //using SimpleInjector.Integration.WebApi;
  //using Pyro.WebApi.Services;
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
  using Pyro.Common.RequestMetadata;
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
  using Pyro.Backburner.ServiceTaskLaunch;

  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize(Container container)
    {
      container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
      InitializeContainer(container);
      container.Verify();
    }

    private static void InitializeContainer(Container container)
    {
      //========================================================================================================
      //=================== Backburner ==========================================================================            
      //========================================================================================================
      
      //Lifestyle.Scoped      
      container.Register<ServiceTask.HiService.IIhiSearchService, ServiceTask.HiService.IhiSearchService>(Lifestyle.Scoped);
      

      //========================================================================================================
      //=================== Singleton ==========================================================================            
      //========================================================================================================

      container.RegisterConditional(typeof(ILog), context => typeof(Log<>).MakeGenericType(context.Consumer.ImplementationType), Lifestyle.Singleton, context => true);
      container.Register<IGlobalProperties, GlobalProperties>(Lifestyle.Singleton);
      //container.Register<IFhirExceptionFilter, FhirExceptionFilter>(Lifestyle.Transient);

      container.Register<Pyro.Common.CompositionRoot.ICommonFactory, Pyro.Backburner.CompositionRoot2.CommonFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IDtoRootUrlStoreFactory, Pyro.Backburner.CompositionRoot2.DtoRootUrlStoreFactory>(Lifestyle.Singleton);            
      container.Register<Pyro.Common.CompositionRoot.IDatabaseOperationOutcomeFactory, Pyro.Backburner.CompositionRoot2.DatabaseOperationOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IPyroFhirUriFactory, Pyro.Backburner.CompositionRoot2.PyroFhirUriFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IRequestHeaderFactory, Pyro.Backburner.CompositionRoot2.RequestHeaderFactory>(Lifestyle.Singleton);      
      container.Register<Pyro.Common.CompositionRoot.IPyroRequestUriFactory, Pyro.Backburner.CompositionRoot2.PyroRequestUriFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IRequestMetaFactory, Pyro.Backburner.CompositionRoot2.RequestMetaFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IResourceRepositoryFactory, Pyro.Backburner.CompositionRoot2.ResourceRepositoryFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IResourceServiceOutcomeFactory, Pyro.Backburner.CompositionRoot2.ResourceServiceOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterGenericFactory, Pyro.Backburner.CompositionRoot2.SearchParameterGenericFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterReferanceFactory, Pyro.Backburner.CompositionRoot2.SearchParameterReferanceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterServiceFactory, Pyro.Backburner.CompositionRoot2.SearchParameterServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParametersServiceOutcomeFactory, Pyro.Backburner.CompositionRoot2.SearchParametersServiceOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IMetadataServiceFactory, Pyro.Backburner.CompositionRoot2.MetadataServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IBundleTransactionServiceFactory, Pyro.Backburner.CompositionRoot2.BundleTransactionServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirBaseOperationServiceFactory, Pyro.Backburner.CompositionRoot2.FhirBaseOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceInstanceOperationServiceFactory, Pyro.Backburner.CompositionRoot2.FhirResourceInstanceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceOperationServiceFactory, Pyro.Backburner.CompositionRoot2.FhirResourceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IServerSearchParameterServiceFactory, Pyro.Backburner.CompositionRoot2.ServerSearchParameterServiceFactory>(Lifestyle.Singleton);
      container.Register<IResourceTriggerService, ResourceTriggerService>(Lifestyle.Singleton);

      container.Register<Pyro.Identifiers.Australian.MedicareNumber.IMedicareNumberParser, Pyro.Identifiers.Australian.MedicareNumber.MedicareNumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.DepartmentVeteransAffairs.IDVANumberParser, Pyro.Identifiers.Australian.DepartmentVeteransAffairs.DVANumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IIndividualHealthcareIdentifierParser, Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IndividualHealthcareIdentifierParser>(Lifestyle.Singleton);

      //Singleton: Cache      
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(Lifestyle.Singleton);
      container.Register<ICacheClear, CacheClear>(Lifestyle.Singleton);

      //Singleton: Automapper      
      container.RegisterSingleton(() => container.GetInstance<CompositionRoot2.MapperProvider>().GetMapper());


      //========================================================================================================
      //=================== Transient ==========================================================================            
      //========================================================================================================      
      container.Register<IFhirResourceNarrative, FhirResourceNarrative>(Lifestyle.Transient);
      container.Register<IHtmlGenerationSupport, HtmlGenerationSupport>(Lifestyle.Transient);

      container.Register<IDtoRootUrlStore, DtoRootUrlStore>(Lifestyle.Transient);
      container.Register<IRequestHeader, RequestHeader>(Lifestyle.Transient);
      container.Register<IPyroFhirUri, PyroFhirUri>(Lifestyle.Transient);
      container.Register<IPyroRequestUri, PyroRequestUri>(Lifestyle.Transient);      
      container.Register<IFhirRestResponse, FhirRestResponse>(Lifestyle.Transient);
      container.Register<IRequestMeta, RequestMeta>(Lifestyle.Transient);
       
      container.Register<IBundleTransactionService, BundleTransactionService>(Lifestyle.Transient);
      container.Register<IMetadataService, MetadataService>(Lifestyle.Transient);

      container.Register<ISearchParameterService, SearchParameterService>(Lifestyle.Transient);
      container.Register<ISearchParameterGeneric, SearchParameterGeneric>(Lifestyle.Transient);
      container.Register<ISearchParameterReferance, SearchParameterReferance>(Lifestyle.Transient);
      container.Register<ISearchParametersServiceOutcome, SearchParametersServiceOutcome>(Lifestyle.Transient);
      container.Register<IDatabaseOperationOutcome, DtoDatabaseOperationOutcome>(Lifestyle.Transient);
      container.Register<IResourceServiceOutcome, ResourceServiceOutcome>(Lifestyle.Transient);

      //========================================================================================================
      //=================== Scoped =============================================================================            
      //========================================================================================================
      container.RegisterConditional(typeof(IIndexSetterFactory<,,,,,,>), typeof(Pyro.Backburner.CompositionRoot2.IndexSetterFactory<,,,,,,>), Lifestyle.Scoped, c => !c.Handled);
      container.RegisterConditional(typeof(IReferenceSetter<,,,,,,>), typeof(ReferenceSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(INumberSetter<,,,,,,>), typeof(NumberSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IDateTimeSetter<,,,,,,>), typeof(DateTimeSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IQuantitySetter<,,,,,,>), typeof(QuantitySetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IStringSetter<,,,,,,>), typeof(StringSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(ITokenSetter<,,,,,,>), typeof(TokenSetter<,,,,,,>), c => !c.Handled);
      container.RegisterConditional(typeof(IUriSetter<,,,,,,>), typeof(UriSetter<,,,,,,>), c => !c.Handled);


      container.Register<IPyroDbContext, PyroDbContext>(Lifestyle.Scoped);
      container.Register<IRequestServiceRootValidate, RequestServiceRootValidate>(Lifestyle.Scoped);
      container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
      container.Register<Pyro.Common.CompositionRoot.IResourceServiceFactory, Pyro.Backburner.CompositionRoot2.ResourceServiceFactory>(Lifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(Lifestyle.Scoped);
      container.Register<IPyroService, PyroService>(Lifestyle.Scoped);
      container.Register<ICommonServices, CommonServices>(Lifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(Lifestyle.Scoped);
      container.Register<ISearchParameterFactory, SearchParameterFactory>(Lifestyle.Scoped);
      container.Register<IIncludeService, IncludeService>(Lifestyle.Scoped);
      container.Register<IChainSearchingService, ChainSearchingService>(Lifestyle.Scoped);
      container.Register<Pyro.ADHA.Api.IIhiSearchValidateConfig, Pyro.Common.ADHA.Api.IhiSearchValidateConfig>(Lifestyle.Scoped);
      container.Register<Pyro.ADHA.Api.IHiServiceApi, Pyro.ADHA.Api.HiServiceApi>(Lifestyle.Scoped);


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
      container.Register<IIHISearchOrValidateOperationService, IHISearchOrValidateOperationService>(Lifestyle.Scoped);      

      //Scoped: Cache
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);

      //Scoped: Load all the FHIR Validation Resolvers 
      container.RegisterCollection<IResourceResolver>(new[] { typeof(InternalServerProfileResolver), typeof(AustralianFhirProfileResolver), typeof(ZipSourceResolver) });

      //Scoped: Bellow returns all CommonResourceRepository types to be registered in contaioner
      var CommonResourceRepositoryTypeList = Pyro.DataLayer.DbModel.EntityGenerated.CommonResourceRepositoryTypeList.GetTypeList();
      container.Register(typeof(ICommonResourceRepository<,,,,,,>), CommonResourceRepositoryTypeList.ToArray(), Lifestyle.Scoped);
      container.Register<ICommonRepository, CommonRepository>(Lifestyle.Scoped);
      container.Register<IServiceCompartmentRepository, ServiceCompartmentRepository>(Lifestyle.Scoped);
      container.Register<ICompartmentSearchParameterService, CompartmentSearchParameterService>(Lifestyle.Scoped);
    }
  }
}