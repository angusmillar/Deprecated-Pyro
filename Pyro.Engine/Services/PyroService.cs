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

    public PyroService(IResourceServices IResourceServices, IRequestServiceRootValidate IRequestServiceRootValidate)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestServiceRootValidate = IRequestServiceRootValidate;
    }

    public IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IDtoRootUrlStore DtoRootUrlStore = IRequestServiceRootValidate.Validate(BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestTransactionBundle ResourceServiceRequestTransactionBundle = Common.CommonFactory.GetResourceServiceRequestTransactionBundle(resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders, IResourceServices);
          IBundleTransactionService BundleTransactionService = Common.CommonFactory.GetBundleTransactionService(ResourceServiceRequestTransactionBundle);
          IResourceServiceOutcome ResourceServiceOutcome = BundleTransactionService.Transact();
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
          var MetadataService = new Pyro.Engine.Services.MetadataService();
          string ApplicationVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Engine.Services.ResourceServices).Assembly.Location).ProductVersion;
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestMetadata ResourceServiceRequestMetadata = Common.CommonFactory.GetResourceServiceRequestMetadata(ApplicationVersion, DtoRootUrlStore, SearchParameterGeneric, IResourceServices);
          IResourceServiceOutcome ResourceServiceOutcome = MetadataService.GetServersConformanceResource(ResourceServiceRequestMetadata);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceServiceRequestGetRead PyroServiceRequestGetRead = Common.CommonFactory.GetResourceServiceRequestGetRead(id, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(PyroServiceRequestGetRead);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestGetHistory ResourceServiceRequestGetHistory = Common.CommonFactory.GetResourceServiceRequestGetHistory(id, vid, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetHistory(ResourceServiceRequestGetHistory);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestGetSearch ResourceServiceRequestGetSearch = Common.CommonFactory.GetResourceServiceRequestGetSearch(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(ResourceServiceRequestGetSearch);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestPost ResourceServiceRequestPost = Common.CommonFactory.GetResourceServiceRequestPost(resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Post(ResourceServiceRequestPost);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Hl7.Fhir.Rest.SearchParams.FromUriParamList(FormDataCollection.GetAsTupleCollection()));
          IResourceServiceRequestGetSearch ResourceServiceRequestGetSearch = Common.CommonFactory.GetResourceServiceRequestGetSearch(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(ResourceServiceRequestGetSearch);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceServiceRequestPut ResourceServiceRequestPut = Common.CommonFactory.GetResourceServiceRequestPut(id, resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Put(ResourceServiceRequestPut);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestDelete ResourceServiceRequestDelete = Common.CommonFactory.GetResourceServiceRequestDelete(id, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Delete(ResourceServiceRequestDelete);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestConditionalPut ResourceServiceRequestConditionalPut = Common.CommonFactory.GetResourceServiceRequestConditionalPut(resource, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalPut(ResourceServiceRequestConditionalPut);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestConditionalDelete ResourceServiceRequestConditionalDelete = Common.CommonFactory.GetResourceServiceRequestConditionalDelete(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalDelete(ResourceServiceRequestConditionalDelete);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IBaseOperationsServiceRequest BaseOperationsServiceRequest = Common.CommonFactory.GetBaseOperationsServiceRequest(operation, null, Resource, IResourceServices, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          var OperationService = new Engine.Services.FhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = OperationService.Process(BaseOperationsServiceRequest);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IBaseOperationsServiceRequest BaseOperationsServiceRequest = Common.CommonFactory.GetBaseOperationsServiceRequest(OperationName, null, IResourceServices, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          var OperationService = new Engine.Services.FhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = OperationService.Process(BaseOperationsServiceRequest);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceOperationsServiceRequest ResourceOperationsServiceRequest = Common.CommonFactory.GetResourceOperationsServiceRequest(operation, null, Resource, IResourceServices, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          var OperationService = new Engine.Services.FhirResourceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = OperationService.Process(ResourceOperationsServiceRequest);
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
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceOperationsServiceRequest ResourceInstanceOperationsServiceRequest = Common.CommonFactory.GetResourceOperationsServiceRequest(operation, null, Resource, IResourceServices, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          var OperationService = new Engine.Services.FhirResourceInstanceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = OperationService.Process(ResourceInstanceOperationsServiceRequest);
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
