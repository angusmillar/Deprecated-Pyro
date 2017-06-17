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
  public class ServerResourceReportService : IServerResourceReportService
  {
    private IBaseOperationsServiceRequest _BaseOpServiceRequest;

    internal ServerResourceReportService(IBaseOperationsServiceRequest BaseOpServiceRequest)
    {
      this._BaseOpServiceRequest = BaseOpServiceRequest;
    }

    public IResourceServiceOutcome Process()
    {
      try
      {
        if (_BaseOpServiceRequest.OperationClass == null)
          throw new NullReferenceException("OperationClass cannot be null.");
        if (_BaseOpServiceRequest.OperationClass.Scope == FhirOperationEnum.OperationScope.Base)
          throw new NullReferenceException("OperationClass.Scope must be 'Base' for this operation method.");
        if (_BaseOpServiceRequest.RequestUri == null)
          throw new NullReferenceException("RequestUri cannot be null.");
        if (_BaseOpServiceRequest.RequestHeaders == null)
          throw new NullReferenceException("RequestHeaders cannot be null.");
        if (_BaseOpServiceRequest.Resource != null)
          throw new NullReferenceException($"Resource cannot be given for Operation ${Enum.FhirOperationEnum.OperationType.ServerResourceReport.GetPyroLiteral()}.");
        if (_BaseOpServiceRequest.SearchParameterGeneric == null)
          throw new NullReferenceException("SearchParameterGeneric cannot be null.");
        if (_BaseOpServiceRequest.ResourceServices == null)
          throw new NullReferenceException("ResourceServices cannot be null.");

        IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

        ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
        SearchParametersServiceRequest.CommonServices = null;
        SearchParametersServiceRequest.SearchParameterGeneric = _BaseOpServiceRequest.SearchParameterGeneric;
        var SearchParameterService = new SearchParameterService();
        SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
        SearchParametersServiceRequest.ResourceType = null;
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
          ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          return ResourceServiceOutcome;
        }

        var ReturnParametersResource = new Parameters();
        ReturnParametersResource.Parameter = new List<Parameters.ParameterComponent>();
        foreach (string ResourceName in ModelInfo.SupportedResources)
        {
          var ResourceReportParameter = new Parameters.ParameterComponent();
          ResourceReportParameter.Name = ResourceName;
          ResourceReportParameter.Part = new List<Parameters.ParameterComponent>();
          ReturnParametersResource.Parameter.Add(ResourceReportParameter);

          _BaseOpServiceRequest.ResourceServices.SetCurrentResourceType(ResourceName);
          int TotalCount = _BaseOpServiceRequest.ResourceServices.GetTotalCurrentResourceCount();

          var TotalCountParameter = new Parameters.ParameterComponent();
          TotalCountParameter.Name = $"TotalCount";
          TotalCountParameter.Value = new FhirDecimal(TotalCount);
          ResourceReportParameter.Part.Add(TotalCountParameter);

          if (TotalCount > 0)
          {
            DateTimeOffset? LastUpdated = _BaseOpServiceRequest.ResourceServices.GetLastCurrentResourceLastUpdatedValue();
            if (LastUpdated.HasValue)
            {
              var LastUpdatedParameter = new Parameters.ParameterComponent();
              LastUpdatedParameter.Name = $"LastUpdated";
              LastUpdatedParameter.Value = new FhirDateTime(LastUpdated.Value);
              ResourceReportParameter.Part.Add(LastUpdatedParameter);
            }
          }
        }

        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
        ResourceServiceOutcome.ResourceResult = ReturnParametersResource;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }

      catch (Exception Exec)
      {
        throw new Exception("ServerResourceReport exception thrown", Exec);
      }
    }
  }
}
