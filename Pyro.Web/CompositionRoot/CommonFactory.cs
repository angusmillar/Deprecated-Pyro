using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hl7.Fhir.Specification.Source;
using Pyro.Common.Service;
using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Tools.FhirResourceValidation;
using Pyro.DataLayer.DbModel.UnitOfWork;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.Web.CompositionRoot
{
  public class CommonFactory : ICommonFactory
  {
    private readonly SimpleInjector.Container Container;

    public CommonFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IRequestHeader CreateDtoRequestHeaders()
    {
      return Container.GetInstance<IRequestHeader>();
    }

    public IPyroFhirUri CreateFhirRequestUri()
    {
      return Container.GetInstance<IPyroFhirUri>();
    }

    public IPyroRequestUri CreateDtoRequestUri()
    {
      return Container.GetInstance<IPyroRequestUri>();
    }

    public IPyroRequestUri CreateDtoRequestUri(string RequestUri)
    {
      IPyroRequestUri IDtoRequestUri = Container.GetInstance<IPyroRequestUri>();
      IDtoRequestUri.FhirRequestUri = CreateFhirRequestUri();
      IDtoRequestUri.FhirRequestUri.Parse(RequestUri);
      return IDtoRequestUri;
    }

    public IBundleTransactionService CreateBundleTransactionService()
    {
      return Container.GetInstance<IBundleTransactionService>();
    }

    public IMetadataService CreateMetadataService()
    {
      return Container.GetInstance<IMetadataService>();
    }

    public IDeleteHistoryIndexesService CreateDeleteHistoryIndexesService()
    {
      return Container.GetInstance<IDeleteHistoryIndexesService>();
    }

    public IServerSearchParameterService CreateServerSearchParameterService()
    {
      return Container.GetInstance<IServerSearchParameterService>();
    }

    public IServerResourceReportService CreateServerResourceReportService()
    {
      return Container.GetInstance<IServerResourceReportService>();
    }

    public IFhirValidateOperationService CreateFhirValidateOperationService()
    {
      return Container.GetInstance<IFhirValidateOperationService>();
    }

    public IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService()
    {
      return Container.GetInstance<IFhirResourceInstanceOperationService>();
    }

    public IFhirBaseOperationService CreateFhirBaseOperationService()
    {
      return Container.GetInstance<IFhirBaseOperationService>();
    }

    public IFhirResourceOperationService CreateFhirResourceOperationService()
    {
      return Container.GetInstance<IFhirResourceOperationService>();
    }

    //public ISearchParameterService CreateSearchParameterService()
    //{
    //  return Container.GetInstance<ISearchParameterService>();
    //}

    //public ISearchParameterReferance CreateDtoSearchParameterReferance()
    //{
    //  return Container.GetInstance<ISearchParameterReferance>();
    //}

    public List<IResourceResolver> CreateResourceResolverList()
    {
      return Container.GetAllInstances<IResourceResolver>().ToList();
    }

    public IDtoRootUrlStore CreateDtoRootUrlStore()
    {
      return Container.GetInstance<IDtoRootUrlStore>();
    }

    public IDatabaseOperationOutcome CreateDatabaseOperationOutcome()
    {
      return Container.GetInstance<IDatabaseOperationOutcome>();
    }

    public IResourceServiceOutcome CreateResourceServiceOutcome()
    {
      return Container.GetInstance<IResourceServiceOutcome>();
    }

    public IHtmlGenerationSupport CreateFhirNarativeGenerationSupport()
    {
      return Container.GetInstance<IHtmlGenerationSupport>();
    }

    public IConnectathonAnswerService CreateConnectathonAnswerService()
    {
      return Container.GetInstance<IConnectathonAnswerService>();
    }
  }
}