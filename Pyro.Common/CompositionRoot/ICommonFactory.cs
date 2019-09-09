using Hl7.Fhir.Specification.Source;
using Pyro.Common.Service.ResourceService;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Tools.HtmlSupport;
using Pyro.Common.FhirOperation.Validate;
using Pyro.Common.FhirOperation.IhiSearch;
using Pyro.Common.FhirOperation.ResourceReport;
using Pyro.Common.FhirOperation.Compartment;
using Pyro.Common.FhirOperation.ConnectathonAnswer;
using Pyro.Common.FhirOperation.ProcessMessage;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    
    IHtmlGenerationSupport CreateFhirNarativeGenerationSupport();        
    IResourceReportOperation CreateResourceReportOperation();
    IFhirValidateOperation CreateFhirValidateOperation();
    IConnectathonAnswerOperation CreateConnectathonAnswerOperation();
    IIHISearchOrValidateOperation CreateIHISearchOrValidateOperation();    
    IList<IResourceResolver> CreateResourceResolverList();
    ICompartmentOperation CreateCompartmentOperation();
    IProcessMessageOperation CreateProcessMessageOperation();

  }
}