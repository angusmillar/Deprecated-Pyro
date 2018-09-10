using Pyro.Common.ServiceRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Pyro.Test.IntergrationTest;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Global;
using Pyro.Common.Logging;
using Pyro.Common.ServiceSearchParameter;

namespace Pyro.Test.CommonTestSetup
{
  public static class TestSetupMocks
  {
    public static IDtoRootUrlStore GetIDtoRootUrlStore()
    {      
      Mock<IDtoRootUrlStore> MokIDtoRootUrlStore = new Mock<IDtoRootUrlStore>();
      MokIDtoRootUrlStore.Setup(x => x.Id).Returns(1);
      MokIDtoRootUrlStore.Setup(x => x.IsServersPrimaryUrlRoot).Returns(true);
      //MokIDtoRootUrlStore.Setup(x => x.RootUri).Returns(new Uri(StaticTestData.FhirEndpoint()));
      MokIDtoRootUrlStore.Setup(x => x.Url).Returns(StaticTestData.FhirEndpoint());
      return MokIDtoRootUrlStore.Object;
    }
    public static IRequestMetaFactory GetIRequestMetaFactory()
    {
      Mock<IRequestMetaFactory> MokIRequestMetaFactory = new Mock<IRequestMetaFactory>();      
      //Note below lamba () => forces a new instance each time.
      MokIRequestMetaFactory.Setup(x => x.CreateRequestMeta()).Returns(() => new Pyro.Common.RequestMetadata.RequestMeta(GetIPyroRequestUriFactory(), GetIRequestHeaderFactory(), GetISearchParameterGenericFactory()));
      return MokIRequestMetaFactory.Object;
    }

    public static ISearchParameterGenericFactory GetISearchParameterGenericFactory()
    {
      Mock<ISearchParameterGenericFactory> MokISearchParameterGenericFactory = new Mock<ISearchParameterGenericFactory>();
      MokISearchParameterGenericFactory.Setup(x => x.CreateDtoSearchParameterGeneric()).Returns(() => new Pyro.Common.Search.SearchParameterGeneric());
      return MokISearchParameterGenericFactory.Object;
    }

    public static IPrimaryServiceRootCache GetIPrimaryServiceRootCache()
    {      
      Mock<IPrimaryServiceRootCache> MokIPrimaryServiceRootCache = new Mock<IPrimaryServiceRootCache>();
      MokIPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlStoreFromDatabase()).Returns(TestSetupMocks.GetIDtoRootUrlStore());
      MokIPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlFromWebConfig()).Returns(StaticTestData.FhirEndpoint());
      return MokIPrimaryServiceRootCache.Object;
    }

    public static IPyroFhirUriFactory GetIPyroFhirUriFactory()
    {
      Mock<IPyroFhirUriFactory> MokIPyroFhirUriFactory = new Mock<IPyroFhirUriFactory>();
      MokIPyroFhirUriFactory.Setup(x => x.CreateFhirRequestUri()).Returns(() => new PyroFhirUri(TestSetupMocks.GetIPrimaryServiceRootCache()));
      return MokIPyroFhirUriFactory.Object;
    }

    public static IPyroRequestUriFactory GetIPyroRequestUriFactory()
    {
      Mock<IPyroRequestUriFactory> MokIPyroRequestUriFactory = new Mock<IPyroRequestUriFactory>();
      MokIPyroRequestUriFactory.Setup(x => x.CreateFhirRequestUri()).Returns(() => new PyroRequestUri(TestSetupMocks.GetIPrimaryServiceRootCache(), TestSetupMocks.GetIPyroFhirUriFactory().CreateFhirRequestUri()));
      return MokIPyroRequestUriFactory.Object;
    }

    public static IRequestHeaderFactory GetIRequestHeaderFactory()
    {
      Mock<IRequestHeaderFactory> MokIRequestHeaderFactory = new Mock<IRequestHeaderFactory>();
      MokIRequestHeaderFactory.Setup(x => x.CreateRequestHeader()).Returns(() => new RequestHeader());
      return MokIRequestHeaderFactory.Object;
    }

    public static IResourceServiceOutcomeFactory GetIResourceServiceOutcomeFactory()
    {
      Mock<IResourceServiceOutcomeFactory> MokIResourceServiceOutcomeFactory = new Mock<IResourceServiceOutcomeFactory>();
      MokIResourceServiceOutcomeFactory.Setup(x => x.CreateResourceServiceOutcome()).Returns(() => new ResourceServiceOutcome());
      return MokIResourceServiceOutcomeFactory.Object;
    }
    
    public static IGlobalProperties GetIGlobalProperties()
    {
      Mock<IGlobalProperties> MokIGlobalProperties = new Mock<IGlobalProperties>();
      MokIGlobalProperties.Setup(x => x.HIServiceConnectivityActive).Returns(true);
      MokIGlobalProperties.Setup(x => x.NumberOfRecordsPerPageDefault).Returns(50);
      MokIGlobalProperties.Setup(x => x.MaxNumberOfRecordsPerPage).Returns(100);
      MokIGlobalProperties.Setup(x => x.ServiceBaseURL).Returns(StaticTestData.FhirEndpoint());
      return MokIGlobalProperties.Object;
    }
    
    public static ILog GetILog()
    {
      Mock<ILog> MokIGlobalProperties = new Mock<ILog>();
      return MokIGlobalProperties.Object;
    }

    
  }
}
