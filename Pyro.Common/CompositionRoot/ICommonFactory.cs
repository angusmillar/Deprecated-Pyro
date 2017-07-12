using Hl7.Fhir.Specification.Source;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.ITools;

namespace Pyro.Common.CompositionRoot
{
  public interface ICommonFactory
  {
    //IResourceRepository CreateCommonResourceRepository<ResourceCurrentType, ResourceIndexType>(FHIRAllTypes FHIRAllTypes);
    //ICommonResourceRepository<ResourceCurrentType, ResourceIndexType> CreateCommonResourceRepository<ResourceCurrentType, ResourceIndexType>();

    //Reused objects
    IDtoRequestHeaders CreateDtoRequestHeaders();
    IFhirRequestUri CreateFhirRequestUri();
    IDtoRequestUri CreateDtoRequestUri();
    IDtoRequestUri CreateDtoRequestUri(string RequestUri);
    IDtoSearchParameterGeneric CreateDtoSearchParameterGeneric();
    ISearchParameterService CreateSearchParameterService();
    ISearchParametersServiceOutcome CreateSearchParametersServiceOutcome();
    IDtoSearchParameterReferance CreateDtoSearchParameterReferance();
    IDtoRootUrlStore CreateDtoRootUrlStore();
    IDatabaseOperationOutcome CreateDatabaseOperationOutcome();
    IResourceServiceOutcome CreateResourceServiceOutcome();
    IFhirNarativeGenerationSupport CreateFhirNarativeGenerationSupport();

    //Services
    IBundleTransactionService CreateBundleTransactionService();
    IMetadataService CreateMetadataService();
    IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService();
    IServerSearchParameterService CreateServerSearchParameterService();
    IServerResourceReportService CreateServerResourceReportService();
    IFhirValidateOperationService CreateFhirValidateOperationService();

    IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService();
    IFhirBaseOperationService CreateFhirBaseOperationService();
    IFhirResourceOperationService CreateFhirResourceOperationService();

    List<IResourceResolver> CreateResourceResolverList();



  }
}