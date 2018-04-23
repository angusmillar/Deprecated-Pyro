using Hl7.Fhir.Specification.Source;
using Pyro.Common.Service;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    
    IHtmlGenerationSupport CreateFhirNarativeGenerationSupport();    
    IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService();    
    IServerResourceReportService CreateServerResourceReportService();
    IFhirValidateOperationService CreateFhirValidateOperationService();
    IConnectathonAnswerService CreateConnectathonAnswerService();
    IIHISearchOrValidateOperationService CreateIHISearchOrValidateOperationService();    
    IList<IResourceResolver> CreateResourceResolverList();
    ICompartmentOperationService CreateCompartmentOperationService();

  }
}