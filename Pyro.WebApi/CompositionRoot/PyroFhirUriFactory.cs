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

namespace Pyro.WebApi.CompositionRoot
{
  public class PyroFhirUriFactory : IPyroFhirUriFactory
  {
    private readonly SimpleInjector.Container Container;

    public PyroFhirUriFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IPyroFhirUri CreateFhirRequestUri()
    {
      return Container.GetInstance<IPyroFhirUri>();
    }
  }
}