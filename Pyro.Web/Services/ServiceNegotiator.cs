using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;
using System.Net;
using System.Net.Http;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.Web.Services
{
  /// <summary>
  /// Negotiates the required Resource server based on the Resource name provided 
  /// </summary>
  public class ServiceNegotiator : IServiceNegotiator
  {
    private readonly SimpleInjector.Container _Container = null;
    private IDefaultResourceServices _TransactionalDefaultResourceServices = null;

    public ServiceNegotiator(SimpleInjector.Container Container)
    {
      _Container = Container;
    }

    public void BeginTransaction()
    {
      if (_TransactionalDefaultResourceServices == null)
        _TransactionalDefaultResourceServices = _Container.GetInstance<IDefaultResourceServices>();

      if (!_TransactionalDefaultResourceServices.IsTransactional)
      {
        _TransactionalDefaultResourceServices.BeginTransaction();
      }
      else
      {
        throw new ArgumentException("Attempt to begin Transaction when one already in progress for this context.");
      }
    }

    public void CommitTransaction()
    {
      if (_TransactionalDefaultResourceServices.IsTransactional)
      {
        _TransactionalDefaultResourceServices.CommitTransaction();
      }
      else
      {
        throw new ArgumentException("Attempt to Commit Transaction when context was not transactional.");
      }
    }

    public void RollbackTransaction()
    {
      if (_TransactionalDefaultResourceServices.IsTransactional)
      {
        _TransactionalDefaultResourceServices.RolbackTransaction();
      }
      else
      {
        throw new ArgumentException("Attempt to Rollback Transaction when context was not transactional.");
      }
    }

    public bool IsTransactional
    {
      get
      {
        if (_TransactionalDefaultResourceServices == null)
        {
          return false;
        }
        else
        {
          return _TransactionalDefaultResourceServices.IsTransactional;
        }
      }
    }

    public ICommonServices GetCommonService()
    {
      return _Container.GetInstance<ICommonServices>();
    }

    public IResourceServices GetResourceService(string ResourceName)
    {
      return ResourceService(ResourceName);
    }

    public IResourceServices GetTransactionalResourceService(string ResourceName)
    {
      return TransactionalResourceService(ResourceName);
    }

    public IResourceServicesBase GetResourceServiceBase(string ResourceName)
    {
      return ResourceService(ResourceName) as IResourceServicesBase;
    }

    private IResourceServices TransactionalResourceService(string ResourceName)
    {      
      Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);
      if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
      {
        if (_TransactionalDefaultResourceServices == null)
          _TransactionalDefaultResourceServices = _Container.GetInstance<IDefaultResourceServices>();
        FHIRAllTypes FHIRAllTypes = (FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName);
        _TransactionalDefaultResourceServices.SetCurrentResourceType = FHIRAllTypes;        
        return _TransactionalDefaultResourceServices;
      }
      else
      {
        string ErrorMessage = $"The Resource name given '{ResourceName}' is not a Resource supported by the .net FHIR API Version: {ModelInfo.Version}.";
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, ErrorMessage);
        OpOutCome.Issue[0].Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
        throw new DtoPyroException(HttpStatusCode.BadRequest, OpOutCome, ErrorMessage);
      }
    }

    private IResourceServices ResourceService(string ResourceName)
    {
      Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);
      if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
      {
        //On adding new services remember to register the service interface with simple injector
        IDefaultResourceServices DefaultResourceServices = _Container.GetInstance<IDefaultResourceServices>();
        FHIRAllTypes FHIRAllTypes = (FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName);
        DefaultResourceServices.SetCurrentResourceType = FHIRAllTypes;
        return DefaultResourceServices;
      }
      else
      {
        string Message = $"The Resource name given '{ResourceName}' is not a Resource supported by the .net FHIR API Version: {ModelInfo.Version}.";
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, Message);
        throw new DtoPyroException(HttpStatusCode.BadRequest, OpOutCome, Message);
      }
    }

  }
}
