using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools;
using Pyro.Common.Enum;
using Hl7.Fhir.Utility;
using Pyro.Common.PyroHealthFhirResource.CodeSystems;
using Pyro.Common.ServiceRoot;
using System.Text;

namespace Pyro.Common.FhirOperation.MergePatient
{
  public class MergePatientOperation : IMergePatientOperation
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEventCodeSystem;

    public MergePatientOperation(IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      ISearchParameterServiceFactory ISearchParameterServiceFactory,
      IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEvent)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IPyroHL7V2MessageTypeEventCodeSystem = IPyroHL7V2MessageTypeEvent;
    }

    public IResourceServiceOutcome Process(
          IPyroRequestUri RequestUri,
          ISearchParameterGeneric SearchParameterGeneric,
          Resource Resource)
    {
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      new NotImplementedException();
      return null;
    }



  }
}

