using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Extentions;
using Pyro.Common.Service;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.Headers;
using System.Data.Entity;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Logging;
using Pyro.Common.Exceptions;
using Pyro.Common.Search;
using Pyro.Engine.Interfaces;
using Pyro.Common.RequestMetadata;

namespace Pyro.Engine.Services
{
  public class PyroService : IPyroService
  {
    private IResourceServices IResourceServices;
    private readonly IRequestServiceRootValidate IRequestServiceRootValidate;
    private readonly ICommonFactory ICommonFactory;    
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly ILog ILog;

    public PyroService(IResourceServices IResourceServices,
      IRequestServiceRootValidate IRequestServiceRootValidate,
      ICommonFactory ICommonFactory,            
      IRequestMetaFactory IRequestMetaFactory,
      ILog ILog)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestServiceRootValidate = IRequestServiceRootValidate;
      this.ICommonFactory = ICommonFactory;      
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.ILog = ILog;
    }

    public IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IBundleTransactionService BundleTransactionService = ICommonFactory.CreateBundleTransactionService();
          IResourceServiceOutcome ResourceServiceOutcome = BundleTransactionService.Transact(resource, RequestMeta);          
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
          ILog.Error(Exec, "PyroService.Base");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);         
          IMetadataService MetadataService = ICommonFactory.CreateMetadataService();
          IResourceServiceOutcome ResourceServiceOutcome = MetadataService.GetServersConformanceResource(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Metadata");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(id, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Get");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetHistory(id, vid, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.History");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Search");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Post(resource, RequestMeta, string.Empty);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Post");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }

    public IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, IEnumerable<Tuple<string, string>> FormParameterList)
    {
      using (DbContextTransaction Transaction = IResourceServices.BeginTransaction())
      {
        try
        {
          IResourceServices.SetCurrentResourceType(ResourceName);          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request, SearchParams.FromUriParamList(FormParameterList));
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.PostFormSearch");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Put(id, resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Put");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalPut(resource, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.ConditionalPut");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Delete(id, RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.Delete");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IResourceServices.SetCurrentResourceType(ResourceName);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.ConditionalDelete(RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          Transaction.Commit();
          return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ILog.Error(Exec, "PyroService.ConditionalDelete");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);         
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);         
          IFhirBaseOperationService FhirBaseOperationService = ICommonFactory.CreateFhirBaseOperationService();
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
          ILog.Error(Exec, "PyroService.BaseOperationWithParameters");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);
          IFhirBaseOperationService FhirBaseOperationService = ICommonFactory.CreateFhirBaseOperationService();
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
          ILog.Error(Exec, "PyroService.BaseOperationWithOutParameters");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IFhirResourceOperationService FhirResourceOperationService = ICommonFactory.CreateFhirResourceOperationService();
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
          ILog.Error(Exec, "PyroService.ResourceOperationWithParameters");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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
          IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(Request);          
          IFhirResourceInstanceOperationService FhirResourceInstanceOperationService = ICommonFactory.CreateFhirResourceInstanceOperationService();
          IResourceServiceOutcome ResourceServiceOutcome = FhirResourceInstanceOperationService.Process(operation, Resource, RequestMeta);
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
          ILog.Error(Exec, "PyroService.ResourceInstanceOperationWithParameters");
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
            Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
    }
    
  }
}
