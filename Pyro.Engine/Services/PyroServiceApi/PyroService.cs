using System;
using System.Collections.Generic;
using System.Net.Http;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Interfaces.Service;
using System.Data.Entity;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Logging;
using Pyro.Common.Exceptions;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.FhirOperation.BundleTransaction;
using Pyro.Common.Interfaces.Operation;

namespace Pyro.Engine.Services.PyroServiceApi
{
  public class PyroService : IPyroService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceApiServices;
    private readonly IRequestServiceRootValidate IRequestServiceRootValidate;    
    private readonly IMetadataServiceFactory IMetadataServiceFactory;
    private readonly IBundleTransactionOperationFactory IBundleTransactionOperationFactory;
    private readonly IFhirBaseOperationServiceFactory IFhirBaseOperationServiceFactory;
    private readonly IFhirResourceInstanceOperationServiceFactory IFhirResourceInstanceOperationServiceFactory;
    private readonly IFhirResourceOperationServiceFactory IFhirResourceOperationServiceFactory;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly ILog ILog;

    public PyroService(IUnitOfWork IUnitOfWork,
      IResourceServices IResourceApiServices,
      IRequestServiceRootValidate IRequestServiceRootValidate,      
      IMetadataServiceFactory IMetadataServiceFactory,
      IBundleTransactionOperationFactory IBundleTransactionOperationFactory,
      IFhirBaseOperationServiceFactory IFhirBaseOperationServiceFactory,
      IFhirResourceInstanceOperationServiceFactory IFhirResourceInstanceOperationServiceFactory,
      IFhirResourceOperationServiceFactory IFhirResourceOperationServiceFactory,
      IRequestMetaFactory IRequestMetaFactory,
      ILog ILog)
    {
      this.IUnitOfWork = IUnitOfWork;
      this.IResourceApiServices = IResourceApiServices;
      this.IRequestServiceRootValidate = IRequestServiceRootValidate;     
      this.IMetadataServiceFactory = IMetadataServiceFactory;
      this.IBundleTransactionOperationFactory = IBundleTransactionOperationFactory;
      this.IFhirBaseOperationServiceFactory = IFhirBaseOperationServiceFactory;
      this.IFhirResourceInstanceOperationServiceFactory = IFhirResourceInstanceOperationServiceFactory;
      this.IFhirResourceOperationServiceFactory = IFhirResourceOperationServiceFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.ILog = ILog;
    }

    public IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource)
    {      
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IBundleTransactionOperation BundleTransactionOperation = IBundleTransactionOperationFactory.CreateBundleTransactionOperation();
          IResourceServiceOutcome ResourceServiceOutcome = BundleTransactionOperation.Transact(resource, RequestMeta);          
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Base, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Metadata(string BaseRequestUri, HttpRequestMessage Request)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IMetadataService MetadataService = IMetadataServiceFactory.CreateMetadataService();
          IResourceServiceOutcome ResourceServiceOutcome = MetadataService.GetServersConformanceResource(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Metadata, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Get(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          System.Security.Principal.IPrincipal x = System.Threading.Thread.CurrentPrincipal;
          

          IRequestServiceRootValidate.Validate(BaseRequestUri);                             
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetRead(id, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;


          Common.BackgroundTask.TaskPayload.ITaskPayloadHiServiceIHISearch Payload = new Common.BackgroundTask.TaskPayload.TaskPayloadHiServiceIHISearch();
          Payload.PatientId = "ba58c03b-4ff6-4e86-8883-8851f40fb8f7";
          Payload.TaskId = "92e74b38-1bb3-4e0c-b056-7ca7c1bd7810";
          ResourceServiceOutcome.BackgroundTaskList.Add(Payload);

          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Get, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome GetHistory(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, string vid = "")
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetHistory(id, vid, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.History, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Search(string BaseRequestUri, HttpRequestMessage Request, string ResourceName)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetSearch(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Search, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome CompartmentSearch(string BaseRequestUri, HttpRequestMessage Request, string Compartment, string id, string ResourceName)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
           IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetCompartmentSearch(RequestMeta, Compartment, id, ResourceName);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.CompartmentSearch, Request: {Request.RequestUri.OriginalString}" );
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Post(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.Post(resource, RequestMeta, string.Empty);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Post, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, IEnumerable<Tuple<string, string>> FormParameterList)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request, SearchParams.FromUriParamList(FormParameterList));
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetSearch(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.PostFormSearch, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Put(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, Resource resource)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.Put(id, resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Put, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome ConditionalPut(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.ConditionalPut(resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.ConditionalPut, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome Delete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.Delete(id, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.Delete, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }
    
    public IResourceServiceOutcome ConditionalDelete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.ConditionalDelete(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.ConditionalDelete, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome OperationPostBaseWithParameters(string BaseRequestUri, HttpRequestMessage Request, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);         
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);         
          IFhirBaseOperationService FhirBaseOperationService = IFhirBaseOperationServiceFactory.CreateFhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirBaseOperationService.Process(operation, Resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.BaseOperationWithParameters, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome OperationGetBaseWithParameters(string BaseRequestUri, HttpRequestMessage Request, string OperationName)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IFhirBaseOperationService FhirBaseOperationService = IFhirBaseOperationServiceFactory.CreateFhirBaseOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirBaseOperationService.Process(OperationName, null, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.BaseOperationWithOutParameters, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome OperationPostResourceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IFhirResourceOperationService FhirResourceOperationService = IFhirResourceOperationServiceFactory.CreateFhirResourceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceOperationService.Process(operation, Resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.ResourceOperationWithParameters, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome OperationPostResourceInstanceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, string FhirId, Resource Resource = null)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IFhirResourceInstanceOperationService FhirResourceInstanceOperationService = IFhirResourceInstanceOperationServiceFactory.CreateFhirResourceInstanceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceInstanceOperationService.ProcessPost(ResourceName, FhirId, operation, RequestMeta, Resource);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.ResourceInstanceOperationWithParameters, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome OperationGetResourceInstanceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, string FhirId)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IFhirResourceInstanceOperationService FhirResourceInstanceOperationService = IFhirResourceInstanceOperationServiceFactory.CreateFhirResourceInstanceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceInstanceOperationService.ProcessGet(ResourceName, FhirId, operation, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          if (ResourceServiceOutcome.SuccessfulTransaction)
            Transaction.Commit();
          else
            Transaction.Rollback();

          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, $"PyroService.ResourceInstanceOperationWithParameters, Request: {Request.RequestUri.OriginalString}");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

  }
}
