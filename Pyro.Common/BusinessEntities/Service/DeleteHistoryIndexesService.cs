using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.BusinessEntities.Service
{
  public class DeleteHistoryIndexesService : IDeleteHistoryIndexesService
  {
    private readonly IResourceServices IResourceServices;
    private readonly ICommonFactory ICommonFactory;
    private const string _ParameterName = "ResourceType";

    public DeleteHistoryIndexesService(IResourceServices ResourceServices, ICommonFactory ICommonFactory)
    {
      this.IResourceServices = ResourceServices;
      this.ICommonFactory = ICommonFactory;
    }

    public IResourceServiceOutcome DeleteMany(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      Resource Resource)
    {
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = ICommonFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ICommonFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      List<string> _ResourceList = new List<string>();
      if (Resource != null && Resource is Parameters ParametersResource)
      {
        var DeleteAll = ParametersResource.Parameter.SingleOrDefault(x => x.Name.ToLower() == _ParameterName.ToLower() && x.Value is FhirString a && a.Value == "*");
        if (DeleteAll != null)
        {
          if (ParametersResource.Parameter.Count > 1)
          {
            var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral()} can not have a mixture of ResourceType = * and ResourceType = [ResourceName], only one or the other.");
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
              var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral()} unknown parameter found. Name = {Parameter.Name}, Value = {Parameter.Value}");
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
            Parameters ParametersResult = new Parameters();
            //ParametersResult.Id = ParametersResource.Id + "-Response";
            ParametersResult.Parameter = new List<Parameters.ParameterComponent>();

            foreach (string ResourceName in _ResourceList)
            {
              IResourceServices.SetCurrentResourceType(ResourceName);
              IResourceServiceOutcome ResourceServiceOutcomeDeleteResourceIndex = IResourceServices.DeleteHistoryIndexes(RequestUri, SearchParameterGeneric);
              if (!ResourceServiceOutcomeDeleteResourceIndex.SuccessfulTransaction)
              {
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
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
            ResourceServiceOutcome.ResourceResult = ParametersResult;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = true;
            return ResourceServiceOutcome;
          }
          else
          {
            var Op = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, $"Operation: ${FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral()} No ResourceType were provided for index deleteion.");
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            ResourceServiceOutcome.ResourceResult = Op;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
            ResourceServiceOutcome.SuccessfulTransaction = false;
            return ResourceServiceOutcome;
          }
        }
        catch (Exception Exec)
        {
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

    public IResourceServiceOutcome DeleteSingle(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

      return IResourceServices.DeleteHistoryIndexes(RequestUri, SearchParameterGeneric);
    }
  }
}
