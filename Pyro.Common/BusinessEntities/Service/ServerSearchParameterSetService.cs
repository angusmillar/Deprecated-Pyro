  using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ServerSearchParameterSetService
  {
    public IBaseOperationsServiceRequest _ServiceRequest;
    private const string _ParameterName = "ResourceType";
    private List<string> _ResourceList;

    internal ServerSearchParameterSetService(IBaseOperationsServiceRequest ServiceRequest)
    {
      this._ServiceRequest = ServiceRequest;
    }
    public IResourceServiceOutcome Process()
    { 
      //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      throw new NotImplementedException();



      if (string.IsNullOrWhiteSpace(_ServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_ServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (_ServiceRequest.ServiceNegotiator == null)
        throw new NullReferenceException("ServiceNegotiator cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = _ServiceRequest.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }


      if (_ServiceRequest.Resource != null && _ServiceRequest.Resource is SearchParameter SearchParameterResource)
      {

      
        try
        {
            //_ServiceRequest.ServiceNegotiator.BeginTransaction();
           //   IResourceServiceOutcome ResourceServiceOutcomeDeleteResourceIndex = ResourceService.DeleteHistoryIndexes(ResourceServiceDeleteHistoryIndexesRequest);
            //_ServiceRequest.ServiceNegotiator.CommitTransaction();
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      //      ResourceServiceOutcome.ResourceResult = ParametersResult;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = true;
            return ResourceServiceOutcome;
        }
        catch (Exception Exec)
        {
          //_ServiceRequest.ServiceNegotiator.RollbackTransaction();
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, Exec.Message);
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.ResourceResult = OpOutCome;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = false;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Resource given on the operation must be a Parameter type FHIR resource.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.ResourceResult = OpOutCome;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
    }
  }
}
