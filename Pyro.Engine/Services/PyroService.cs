using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Extentions;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using System.Data.Entity;
using Pyro.Common.ServiceRoot;

namespace Pyro.Engine.Services
{
  public class PyroService : IPyroService
  {
    private IResourceServices IResourceServices;
    private readonly IRequestServiceRootValidate IRequestServiceRootValidate;
    private readonly Pyro.Common.CompositionRoot.ICommonFactory ICommonFactory;

    public PyroService(IResourceServices IResourceServices,
      IRequestServiceRootValidate IRequestServiceRootValidate,
      Pyro.Common.CompositionRoot.ICommonFactory ICommonFactory)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestServiceRootValidate = IRequestServiceRootValidate;
      this.ICommonFactory = ICommonFactory;
    }

    public IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IBundleTransactionService BundleTransactionService = ICommonFactory.CreateBundleTransactionService();
          IResourceServiceOutcome ResourceServiceOutcome = BundleTransactionService.Transact(resource, DtoRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Metadata(string BaseRequestUri, HttpRequestMessage Request)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IMetadataService MetadataService = ICommonFactory.CreateMetadataService();
          IResourceServiceOutcome ResourceServiceOutcome = MetadataService.GetServersConformanceResource(SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Get(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(id, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome GetHistory(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, string vid = "")
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetHistory(id, vid, DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Search(string BaseRequestUri, HttpRequestMessage Request, string ResourceName)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          //Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Post(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Post(resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders, string.Empty);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, FormDataCollection FormDataCollection)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Put(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Put(id, resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Delete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Delete(id, DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome ConditionalPut(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalPut(resource, DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome ConditionalDelete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalDelete(DtoRequestUri, SearchParameterGeneric);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome BaseOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IFhirBaseOperationService FhirBaseOperationService = ICommonFactory.CreateFhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirBaseOperationService.Process(operation, DtoRequestUri, SearchParameterGeneric, RequestHeaders, Resource);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome BaseOperationWithOutParameters(string BaseRequestUri, HttpRequestMessage Request, string OperationName)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IFhirBaseOperationService FhirBaseOperationService = ICommonFactory.CreateFhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirBaseOperationService.Process(OperationName, DtoRequestUri, SearchParameterGeneric, RequestHeaders, null);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome ResourceOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IFhirResourceOperationService FhirResourceOperationService = ICommonFactory.CreateFhirResourceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceOperationService.Process(operation, DtoRequestUri, SearchParameterGeneric, RequestHeaders, Resource);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome ResourceInstanceOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource, string FhirId)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IDtoRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(Request.RequestUri.OriginalString);
          IDtoRequestHeaders RequestHeaders = ICommonFactory.CreateDtoRequestHeaders().Parse(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = ICommonFactory.CreateDtoSearchParameterGeneric().Parse(Request.GetSearchParams());
          IFhirResourceInstanceOperationService FhirResourceInstanceOperationService = ICommonFactory.CreateFhirResourceInstanceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceInstanceOperationService.Process(operation, Resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          ResourceServiceOutcome.SummaryType = SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }
  }
}
