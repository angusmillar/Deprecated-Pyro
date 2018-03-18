using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Specification.Source;
using Pyro.Common.Service;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.WebApi.CompositionRoot
{
  public class CommonFactory : ICommonFactory
  {
    private readonly SimpleInjector.Container Container;

    public CommonFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }
    
    public IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService()
    {
      return Container.GetInstance<IDeleteHistoryIndexesService>();
    }
    
    public IServerResourceReportService CreateServerResourceReportService()
    {
      return Container.GetInstance<IServerResourceReportService>();
    }

    public IFhirValidateOperationService CreateFhirValidateOperationService()
    {
      return Container.GetInstance<IFhirValidateOperationService>();
    }
    
    public IList<IResourceResolver> CreateResourceResolverList()
    {
      return Container.GetAllInstances<IResourceResolver>().ToList();
    }

    public IHtmlGenerationSupport CreateFhirNarativeGenerationSupport()
    {
      return Container.GetInstance<IHtmlGenerationSupport>();
    }

    public IConnectathonAnswerService CreateConnectathonAnswerService()
    {
      return Container.GetInstance<IConnectathonAnswerService>();
    }

    public IIHISearchOrValidateOperationService CreateIHISearchOrValidateOperationService()
    {
      return Container.GetInstance<IIHISearchOrValidateOperationService>();
    }
    
  }
}