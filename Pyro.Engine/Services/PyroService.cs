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

namespace Pyro.Engine.Services
{
  public static class PyroService
  {
    public static IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, Resource resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          ICommonServices oService = FhirServiceNegotiator.GetCommonService();
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestTransactionBundle ResourceServiceRequestTransactionBundle = Common.CommonFactory.GetResourceServiceRequestTransactionBundle(resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders, FhirServiceNegotiator);
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

    public static IResourceServiceOutcome Metadata(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          ICommonServices oService = FhirServiceNegotiator.GetCommonService();
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          var MetadataService = new Pyro.Engine.Services.MetadataService();
          string ApplicationVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Engine.Services.ResourceServices).Assembly.Location).ProductVersion;
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestMetadata ResourceServiceRequestMetadata = Common.CommonFactory.GetResourceServiceRequestMetadata(ApplicationVersion, DtoRootUrlStore, SearchParameterGeneric, oService);
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

    public static IResourceServiceOutcome Get(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceServiceRequestGetRead PyroServiceRequestGetRead = Common.CommonFactory.GetResourceServiceRequestGetRead(id, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = oService.GetRead(PyroServiceRequestGetRead);
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

    public static IResourceServiceOutcome GetHistory(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, string id, string vid = "")
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestGetHistory ResourceServiceRequestGetHistory = Common.CommonFactory.GetResourceServiceRequestGetHistory(id, vid, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.GetHistory(ResourceServiceRequestGetHistory);
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

    public static IResourceServiceOutcome Search(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestGetSearch ResourceServiceRequestGetSearch = Common.CommonFactory.GetResourceServiceRequestGetSearch(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.GetSearch(ResourceServiceRequestGetSearch);
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

    public static IResourceServiceOutcome Post(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestPost ResourceServiceRequestPost = Common.CommonFactory.GetResourceServiceRequestPost(resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = oService.Post(ResourceServiceRequestPost);
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

    public static IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, FormDataCollection FormDataCollection)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Hl7.Fhir.Rest.SearchParams.FromUriParamList(FormDataCollection.GetAsTupleCollection()));
          IResourceServiceRequestGetSearch ResourceServiceRequestGetSearch = Common.CommonFactory.GetResourceServiceRequestGetSearch(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.GetSearch(ResourceServiceRequestGetSearch);
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

    public static IResourceServiceOutcome Put(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, string id, Resource resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceServiceRequestPut ResourceServiceRequestPut = Common.CommonFactory.GetResourceServiceRequestPut(id, resource, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
          IResourceServiceOutcome ResourceServiceOutcome = oService.Put(ResourceServiceRequestPut);
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

    public static IResourceServiceOutcome Delete(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestDelete ResourceServiceRequestDelete = Common.CommonFactory.GetResourceServiceRequestDelete(id, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.Delete(ResourceServiceRequestDelete);
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

    public static IResourceServiceOutcome ConditionalPut(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);    
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestConditionalPut ResourceServiceRequestConditionalPut = Common.CommonFactory.GetResourceServiceRequestConditionalPut(resource, DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.ConditionalPut(ResourceServiceRequestConditionalPut);
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

    public static IResourceServiceOutcome ConditionalDelete(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);      
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IResourceServiceRequestConditionalDelete ResourceServiceRequestConditionalDelete = Common.CommonFactory.GetResourceServiceRequestConditionalDelete(DtoRequestUri, SearchParameterGeneric);
          IResourceServiceOutcome ResourceServiceOutcome = oService.ConditionalDelete(ResourceServiceRequestConditionalDelete);
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

    public static IResourceServiceOutcome ResourceOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string ResourceName, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          IResourceServices oService = FhirServiceNegotiator.GetResourceService(ResourceName);  
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IResourceOperationsServiceRequest ResourceOperationsServiceRequest = Common.CommonFactory.GetResourceOperationsServiceRequest(operation, Resource, oService, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
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

    public static IResourceServiceOutcome BaseOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          ICommonServices oCommonServices = FhirServiceNegotiator.GetCommonService();    
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oCommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IBaseOperationsServiceRequest BaseOperationsServiceRequest = Common.CommonFactory.GetBaseOperationsServiceRequest(operation, Resource, FhirServiceNegotiator, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
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

    public static IResourceServiceOutcome BaseOperationWithOutParameters(string BaseRequestUri, HttpRequestMessage Request, IServiceNegotiator FhirServiceNegotiator, string operation)
    {
      using (DbContextTransaction Transaction = FhirServiceNegotiator.BeginTransaction())
      {
        try
        {
          ICommonServices oCommonServices = FhirServiceNegotiator.GetCommonService();
          IDtoRootUrlStore DtoRootUrlStore = Services.PrimaryServiceRootFactory.Create(oCommonServices, BaseRequestUri);
          IFhirRequestUri FhirRequestUri = Common.CommonFactory.GetFhirRequestUri(DtoRootUrlStore.Url, Request.RequestUri.OriginalString);
          IDtoRequestUri DtoRequestUri = Common.CommonFactory.GetRequestUri(DtoRootUrlStore, FhirRequestUri);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(Request.GetSearchParams());
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(Request.Headers);
          IBaseOperationsServiceRequest BaseOperationsServiceRequest = Common.CommonFactory.GetBaseOperationsServiceRequest(operation, FhirServiceNegotiator, DtoRequestUri, SearchParameterGeneric, RequestHeaders);        
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


  }
}
