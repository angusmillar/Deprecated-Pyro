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
  public class DeleteManyHistoryIndexesService : IDeleteManyHistoryIndexesService
  {
    public IBaseOperationsServiceRequest _ServiceRequest;
    private const string _ParameterName = "ResourceType";
    private List<string> _ResourceList;

    internal DeleteManyHistoryIndexesService(IBaseOperationsServiceRequest ServiceRequest)
    {
      this._ServiceRequest = ServiceRequest;
    }     
    public IResourceServiceOutcome Process()
    {
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
      
      
      if (_ServiceRequest.Resource != null && _ServiceRequest.Resource is Parameters ParametersResource)
      {                
        var DeleteAll = ParametersResource.Parameter.SingleOrDefault(x => x.Name.ToLower() == _ParameterName.ToLower() && x.Value is FhirString a && a.Value == "*");
        if (DeleteAll != null)
        {
          if (ParametersResource.Parameter.Count > 1)
          {
            var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.BaseOperationType.DeleteHistoryIndexes.GetPyroLiteral()} can not have a mixture of ResourceType = * and ResourceType = [ResourceName], only one or the other.");
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            ResourceServiceOutcome.ResourceResult = Op;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = false;
            return ResourceServiceOutcome;
          }
          //Loop through and Delete all resource indexes
          _ResourceList = ModelInfo.SupportedResources;
        }
        else
        {
          //Collect from the parameters the Resources to have indexes deleted from 
          _ResourceList = new List<string>();
          foreach (var Parameter in ParametersResource.Parameter)
          {
            if (Parameter.Name.Trim().ToLower() == _ParameterName.ToLower() && Parameter.Value is FhirString ParamValue && ModelInfo.IsKnownResource(ParamValue.Value.Trim()))
            {
              _ResourceList.Add(ParamValue.Value.Trim());
            }
            else
            {
              var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.BaseOperationType.DeleteHistoryIndexes.GetPyroLiteral()} unknown parameter found. Name = {Parameter.Name}, Value = {Parameter.Value}");
              ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
              ResourceServiceOutcome.ResourceResult = Op;
              ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
              ResourceServiceOutcome.SuccessfulTransaction = false;
              return ResourceServiceOutcome;
            }
          }            
        }

        try
        {
          if (_ResourceList.Count > 0)
          {
            _ServiceRequest.ServiceNegotiator.BeginTransaction();
            Parameters ParametersResult = new Parameters();
            ParametersResult.Id = ParametersResource.Id + "-Response";
            ParametersResult.Parameter = new List<Parameters.ParameterComponent>();

            foreach (string ResourceName in _ResourceList)
            {
              var ResourceService = _ServiceRequest.ServiceNegotiator.GetResourceService(ResourceName);
              var ResourceServiceDeleteHistoryIndexesRequest = Common.CommonFactory.GetResourceServiceDeleteHistoryIndexesRequest();
              ResourceServiceDeleteHistoryIndexesRequest.RequestUri = _ServiceRequest.RequestUri;
              ResourceServiceDeleteHistoryIndexesRequest.SearchParameterGeneric = _ServiceRequest.SearchParameterGeneric;
              IResourceServiceOutcome ResourceServiceOutcomeDeleteResourceIndex = ResourceService.DeleteHistoryIndexes(ResourceServiceDeleteHistoryIndexesRequest);
              if (!ResourceServiceOutcomeDeleteResourceIndex.SuccessfulTransaction)
              {
                _ServiceRequest.ServiceNegotiator.RollbackTransaction();         
                return ResourceServiceOutcomeDeleteResourceIndex;
              }
              else
              {
                if (ResourceServiceOutcomeDeleteResourceIndex.ResourceResult is Parameters Param)
                {
                  ParametersResult.Parameter.AddRange(Param.Parameter);
                }
              }
            }
            _ServiceRequest.ServiceNegotiator.CommitTransaction();
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
            ResourceServiceOutcome.ResourceResult = ParametersResult;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = true;
            return ResourceServiceOutcome;
          }
          else
          {
            var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.BaseOperationType.DeleteHistoryIndexes.GetPyroLiteral()} No ResourceType were provided for index deleteion.");
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            ResourceServiceOutcome.ResourceResult = Op;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = false;
            return ResourceServiceOutcome;
          }
        }
        catch(Exception Exec)
        {
          _ServiceRequest.ServiceNegotiator.RollbackTransaction();
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
