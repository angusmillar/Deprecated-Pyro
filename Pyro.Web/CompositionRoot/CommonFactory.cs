using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Web.CompositionRoot
{
  public class CommonFactory : ICommonFactory
  {
    private readonly SimpleInjector.Container Container;

    public CommonFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IDtoRequestHeaders CreateDtoRequestHeaders()
    {
      return Container.GetInstance<IDtoRequestHeaders>();
    }

    public IFhirRequestUri CreateFhirRequestUri()
    {
      return Container.GetInstance<IFhirRequestUri>();
    }

    public IDtoRequestUri CreateDtoRequestUri()
    {
      return Container.GetInstance<IDtoRequestUri>();
    }

    public IDtoRequestUri CreateDtoRequestUri(string RequestUri)
    {
      IDtoRequestUri IDtoRequestUri = Container.GetInstance<IDtoRequestUri>();
      IDtoRequestUri.FhirRequestUri = CreateFhirRequestUri();
      IDtoRequestUri.FhirRequestUri.Parse(RequestUri);
      return IDtoRequestUri;
    }

    public IDtoSearchParameterGeneric CreateDtoSearchParameterGeneric()
    {
      return Container.GetInstance<IDtoSearchParameterGeneric>();
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
  }
}