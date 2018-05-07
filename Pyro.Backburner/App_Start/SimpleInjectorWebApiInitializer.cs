//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Backburner.App_Start
{
  using SimpleInjector;
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
  using Pyro.DataLayer.Repository;
  using Pyro.DataLayer.IndexSetter;
  using Pyro.Common.Cache;
  using Pyro.Common.BusinessEntities.Dto;
  using Pyro.Common.Tools.FhirNarrative;
  using Pyro.Common.FhirHttpResponse;
  using Pyro.Common.Interfaces.Tools.HtmlSupport;
  using Pyro.Common.CompositionRoot.Concrete;

  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize(Container container)
    {
      container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
      InitializeBackburnerServicesInContainer(container);
      InitializePyroServerServicesInContainer(container);
      container.Verify();
    }

    /// <summary>
    /// Only services that are found in the Pyro.Backburner project
    /// </summary>
    /// <param name="container"></param>
    private static void InitializeBackburnerServicesInContainer(Container container)
    {
      //========================================================================================================
      //=================== Backburner Only ====================================================================            
      //========================================================================================================

      //Lifestyle.Scoped      
      container.Register<ServiceTask.HiService.IIhiSearchService, ServiceTask.HiService.IhiSearchService>(Lifestyle.Scoped);

    }

    /// <summary>
    /// Services that are common to Pyro.WebApi & Pyro.Backburner
    /// (The whole method can be cut & pasted from Pyro.WebApi.App_Start.SimpleInjectorWebApiInitializer class to here and and vice versa)
    /// </summary>
    /// <param name="container"></param>
    private static void InitializePyroServerServicesInContainer(Container container)
    {
      //========================================================================================================
      //=================== Singleton ==========================================================================            
      //========================================================================================================

      container.RegisterConditional(typeof(ILog), context => typeof(Log<>).MakeGenericType(context.Consumer.ImplementationType), Lifestyle.Singleton, context => true);
      container.Register<IGlobalProperties, GlobalProperties>(Lifestyle.Singleton);

      container.Register<Pyro.Common.CompositionRoot.ICommonFactory, CommonFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IDtoRootUrlStoreFactory, DtoRootUrlStoreFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IDatabaseOperationOutcomeFactory, DatabaseOperationOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IPyroFhirUriFactory, PyroFhirUriFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IRequestHeaderFactory, RequestHeaderFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IPyroRequestUriFactory, PyroRequestUriFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IRequestMetaFactory, RequestMetaFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IResourceRepositoryFactory, Pyro.WebApi.CompositionRoot.ResourceRepositoryFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IResourceServiceOutcomeFactory, ResourceServiceOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterGenericFactory, SearchParameterGenericFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterReferanceFactory, SearchParameterReferanceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParameterServiceFactory, SearchParameterServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.ISearchParametersServiceOutcomeFactory, SearchParametersServiceOutcomeFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IMetadataServiceFactory, MetadataServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IBundleTransactionServiceFactory, BundleTransactionServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirBaseOperationServiceFactory, FhirBaseOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceInstanceOperationServiceFactory, FhirResourceInstanceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceOperationServiceFactory, FhirResourceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IServerSearchParameterServiceFactory, ServerSearchParameterServiceFactory>(Lifestyle.Singleton);

      container.Register<Pyro.Identifiers.Australian.MedicareNumber.IMedicareNumberParser, Pyro.Identifiers.Australian.MedicareNumber.MedicareNumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.DepartmentVeteransAffairs.IDVANumberParser, Pyro.Identifiers.Australian.DepartmentVeteransAffairs.DVANumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IIndividualHealthcareIdentifierParser, Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IndividualHealthcareIdentifierParser>(Lifestyle.Singleton);

      //Singleton: Cache      
      container.Register<IApplicationCacheSupport, ApplicationCacheSupport>(Lifestyle.Singleton);
      container.Register<ICacheClear, CacheClear>(Lifestyle.Singleton);

      //Singleton: Automapper      
      container.RegisterSingleton(() => container.GetInstance<Pyro.WebApi.CompositionRoot.MapperProvider>().GetMapper());

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
      container.RegisterConditional(typeof(IIndexSetterFactory<,,,,,,>), typeof(Pyro.WebApi.CompositionRoot.IndexSetterFactory<,,,,,,>), Lifestyle.Scoped, c => !c.Handled);
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
      container.Register<Pyro.Common.CompositionRoot.IResourceServiceFactory, ResourceServiceFactory>(Lifestyle.Scoped);
      container.Register<IRepositorySwitcher, RepositorySwitcher>(Lifestyle.Scoped);
      container.Register<IPyroService, PyroService>(Lifestyle.Scoped);      
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
      container.Register<ICompartmentOperationService, CompartmentOperationService>(Lifestyle.Scoped);

      //Scoped: Cache
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);
      container.Register<Common.Compartment.IServiceCompartmentCache, Common.Compartment.ServiceCompartmentCache>(Lifestyle.Scoped);

      //Scoped: Load all the FHIR Validation Resolvers 
      container.RegisterCollection<IResourceResolver>(new[] { typeof(InternalServerProfileResolver), typeof(AustralianFhirProfileResolver), typeof(ZipSourceResolver) });

      //Scoped: Bellow returns all CommonResourceRepository types to be registered in contaioner
      var CommonResourceRepositoryTypeList = Pyro.DataLayer.DbModel.EntityGenerated.CommonResourceRepositoryTypeList.GetTypeList();
      container.Register(typeof(ICommonResourceRepository<,,,,,,>), CommonResourceRepositoryTypeList.ToArray(), Lifestyle.Scoped);     
      container.Register<IServiceCompartmentRepository, ServiceCompartmentRepository>(Lifestyle.Scoped);
      container.Register<ICompartmentSearchParameterService, CompartmentSearchParameterService>(Lifestyle.Scoped);

      //Scoped Trigger Services
      container.Register<IResourceTriggerService, ResourceTriggerService>(Lifestyle.Scoped);
      container.Register<Pyro.Engine.TriggerServices.ITriggerCompartmentDefinition, Pyro.Engine.TriggerServices.TriggerCompartmentDefinition>(Lifestyle.Scoped);
    }    

  }
}