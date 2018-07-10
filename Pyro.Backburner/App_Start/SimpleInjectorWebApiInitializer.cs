//[assembly: WebActivator.PostApplicationStartMethod(typeof(Pyro.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Pyro.Backburner.App_Start
{
  using Hl7.Fhir.Specification.Source;
  using Pyro.Common.Cache;
  using Pyro.Common.CompositionRoot.Concrete;
  using Pyro.Common.DtoEntity;
  using Pyro.Common.Enum;
  using Pyro.Common.FhirHttpResponse;
  using Pyro.Common.FhirOperation.BundleTransaction;
  using Pyro.Common.FhirOperation.Compartment;
  using Pyro.Common.FhirOperation.ConnectathonAnswer;
  using Pyro.Common.FhirOperation.DeleteHistoryIndexes;
  using Pyro.Common.FhirOperation.IhiSearch;
  using Pyro.Common.FhirOperation.ResourceReport;
  using Pyro.Common.FhirOperation.ServerSearchParameter;
  using Pyro.Common.FhirOperation.Validate;
  using Pyro.Common.Global;
  using Pyro.Common.Interfaces.Operation;
  using Pyro.Common.Interfaces.Repositories;
  using Pyro.Common.Interfaces.Service;
  using Pyro.Common.Interfaces.Tools.HtmlSupport;
  using Pyro.Common.Logging;
  using Pyro.Common.RequestMetadata;
  using Pyro.Common.Search;
  using Pyro.Common.Search.SearchParameterEntity;
  using Pyro.Common.Service.CompartmentSearchParameter;
  using Pyro.Common.Service.Include;
  using Pyro.Common.Service.ResourceService;
  using Pyro.Common.Service.SearchParameters;
  using Pyro.Common.Service.Smart;
  using Pyro.Common.Service.Trigger;
  using Pyro.Common.Service.Trigger.TriggerServices;
  using Pyro.Common.ServiceRoot;
  using Pyro.Common.ServiceSearchParameter;
  using Pyro.Common.Tools;
  using Pyro.Common.Tools.FhirNarrative;
  using Pyro.Common.Tools.FhirResourceValidation;
  using Pyro.Common.Tools.Headers;
  using Pyro.Common.Tools.UriSupport;
  using Pyro.DataLayer.DbModel.DatabaseContext;
  using Pyro.DataLayer.DbModel.UnitOfWork;
  using Pyro.DataLayer.IndexSetter;
  using Pyro.DataLayer.Repository;
  using Pyro.Engine.Operation;
  using Pyro.Engine.Services.Metadata;
  using Pyro.Engine.Services.PyroServiceApi;
  using Pyro.Engine.Services.Resources;
  using Pyro.Engine.Services.ServiceBaseUrl;
  using Pyro.Engine.Services.ServiceConfiguration;
  using Pyro.Engine.Services.ServiceSearchParameter;
  using SimpleInjector;

  public static class SimpleInjectorWebApiInitializer
  {
    private static PyroProject.PyroProjectType ProjectType = PyroProject.PyroProjectType.Backburner;

    /// <summary>Initialise the container and register it as Web API Dependency Resolver.</summary>
    public static void Initialize(Container container)
    {
      container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
      InitializeBackburnerServicesInContainer(container);
      InitializePyroServerServicesInContainer(container);
      InitializeConditionalServicesInContainer(container);      
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
      container.Register<ServiceTask.FhirApiDiscovery.IFhirApiDiscoveryService, ServiceTask.FhirApiDiscovery.FhirApiDiscoveryService>(Lifestyle.Scoped);
      

    }

    /// <summary>
    /// Services that are Conditional on which Project is runnning. For instance a different concreate implementation maybe used for the same Interface    
    /// </summary>    
    private static void InitializeConditionalServicesInContainer(Container container)
    {
      switch (ProjectType)
      {
        case PyroProject.PyroProjectType.FhirApi:
          {
            container.Register<IGlobalProperties, GlobalProperties>(Lifestyle.Singleton);
          }
          break;
        case PyroProject.PyroProjectType.Backburner:
          {
            container.Register<IGlobalProperties, DbGlobalProperties>(Lifestyle.Scoped);
          }
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(ProjectType.GetPyroLiteral(), (int)ProjectType, typeof(PyroProject.PyroProjectType));
      }
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
      container.Register<IServiceConfigurationService, ServiceConfigurationService>(Lifestyle.Scoped);
      container.Register<IServiceConfigurationRepository, ServiceConfigurationRepository>(Lifestyle.Scoped);

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
      container.Register<Pyro.Common.CompositionRoot.IBundleTransactionOperationFactory, BundleTransactionOperationFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirBaseOperationServiceFactory, FhirBaseOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceInstanceOperationServiceFactory, FhirResourceInstanceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IFhirResourceOperationServiceFactory, FhirResourceOperationServiceFactory>(Lifestyle.Singleton);
      container.Register<Pyro.Common.CompositionRoot.IServerSearchParameterServiceFactory, ServerSearchParameterServiceFactory>(Lifestyle.Singleton);

      container.Register<Pyro.Identifiers.Australian.MedicareNumber.IMedicareNumberParser, Pyro.Identifiers.Australian.MedicareNumber.MedicareNumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.DepartmentVeteransAffairs.IDVANumberParser, Pyro.Identifiers.Australian.DepartmentVeteransAffairs.DVANumberParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IIndividualHealthcareIdentifierParser, Pyro.Identifiers.Australian.NationalHealthcareIdentifier.IndividualHealthcareIdentifierParser>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Support.StandardsInformation.Australian.INationalHealthcareIdentifierInfo, Pyro.Identifiers.Support.StandardsInformation.Australian.NationalHealthcareIdentifierInfo>(Lifestyle.Singleton);
      container.Register<Pyro.Identifiers.Support.StandardsInformation.Australian.IMedicareNumberInfo, Pyro.Identifiers.Support.StandardsInformation.Australian.MedicareNumberInfo>(Lifestyle.Singleton);
      container.Register<Pyro.Common.Tools.Paging.IPagingSupport, Pyro.Common.Tools.Paging.PagingSupport>(Lifestyle.Scoped);


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

      container.Register<IBundleTransactionOperation, BundleTransactionOperation>(Lifestyle.Transient);
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
      container.Register<IServiceSearchParameterService, ServiceSearchParameterService>(Lifestyle.Scoped);
      container.Register<IServicePrimaryBaseUrlService, ServiceBaseUrlService>(Lifestyle.Scoped);
      container.Register<IResourceServices, ResourceServices>(Lifestyle.Scoped);
      container.Register<ISmartScopeService, SmartScopeService>(Lifestyle.Scoped);
      container.Register<ISearchParameterFactory, SearchParameterFactory>(Lifestyle.Scoped);
      container.Register<IIncludeService, IncludeService>(Lifestyle.Scoped);      
      container.Register<Pyro.ADHA.Api.IIhiSearchValidateConfig, Pyro.Common.ADHA.Api.IhiSearchValidateConfig>(Lifestyle.Scoped);
      container.Register<Pyro.ADHA.Api.IHiServiceApi, Pyro.ADHA.Api.HiServiceApi>(Lifestyle.Scoped);


      //Scoped: Operations Locator 
      container.Register<IFhirBaseOperationService, FhirBaseOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceInstanceOperationService, FhirResourceInstanceOperationService>(Lifestyle.Scoped);
      container.Register<IFhirResourceOperationService, FhirResourceOperationService>(Lifestyle.Scoped);
      //Scoped: Operations
      container.Register<IDeleteHistoryIndexesOperation, DeleteHistoryIndexesOperation>(Lifestyle.Scoped);
      container.Register<IServerSearchParameterOperation, ServerSearchParameterOperation>(Lifestyle.Scoped);
      container.Register<IResourceReportOperation, ResourceReportOperation>(Lifestyle.Scoped);
      container.Register<IFhirValidateOperation, FhirValidateOperation>(Lifestyle.Scoped);
      container.Register<IFhirValidationSupport, FhirValidationSupport>(Lifestyle.Scoped);
      container.Register<IConnectathonAnswerOperation, ConnectathonAnswerOperation>(Lifestyle.Scoped);
      container.Register<IIHISearchOrValidateOperation, IHISearchOrValidateOperation>(Lifestyle.Scoped);
      container.Register<ICompartmentOperation, CompartmentOperation>(Lifestyle.Scoped);

      //Scoped: Cache
      container.Register<IPrimaryServiceRootCache, PrimaryServiceRootCache>(Lifestyle.Scoped);
      container.Register<IServiceSearchParameterCache, ServiceSearchParameterCache>(Lifestyle.Scoped);
      container.Register<Common.Compartment.IServiceCompartmentCache, Common.Compartment.ServiceCompartmentCache>(Lifestyle.Scoped);
      container.Register<Common.FhirRelease.IFhirReleaseCache, Common.FhirRelease.FhirReleaseCache>(Lifestyle.Scoped);

      //Scoped: Load all the FHIR Validation Resolvers 
      container.RegisterCollection<IResourceResolver>(new[] { typeof(InternalServerProfileResolver), typeof(AustralianFhirProfileResolver), typeof(ZipSourceResolver) });

      //Scoped: Bellow returns all CommonResourceRepository types to be registered in contaioner
      var CommonResourceRepositoryTypeList = Pyro.DataLayer.DbModel.EntityGenerated.CommonResourceRepositoryTypeList.GetTypeList();
      container.Register(typeof(ICommonResourceRepository<,,,,,,>), CommonResourceRepositoryTypeList.ToArray(), Lifestyle.Scoped);

      container.Register<Pyro.DataLayer.Repository.Interfaces.IServiceBaseUrlRepository, ServiceBaseUrlRepository>(Lifestyle.Scoped);
      container.Register<IServicePrimaryBaseUrlRepository, ServiceBaseUrlRepository>(Lifestyle.Scoped);

      container.Register<IServiceSearchParameterRepository, ServiceSearchParameterRepository>(Lifestyle.Scoped);
      container.Register<IServiceCompartmentRepository, ServiceCompartmentRepository>(Lifestyle.Scoped);
      container.Register<ICompartmentSearchParameterService, CompartmentSearchParameterService>(Lifestyle.Scoped);
      container.Register<IFhirReleaseRepository, FhirReleaseRepository>(Lifestyle.Scoped);

      //Scoped Trigger Services
      container.Register<IResourceTriggerService, ResourceTriggerService>(Lifestyle.Scoped);
      container.Register<ITriggerCompartmentDefinition, TriggerCompartmentDefinition>(Lifestyle.Scoped);
    }
  }
}