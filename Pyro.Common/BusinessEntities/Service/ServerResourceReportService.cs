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
      if (string.IsNullOrWhiteSpace(_BaseOpServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");      
      if (_BaseOpServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_BaseOpServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_BaseOpServiceRequest.Resource != null)
        throw new NullReferenceException($"Resource cannot be given for Operation ${Enum.FhirOperationEnum.BaseOperationType.ServerResourceReport.GetPyroLiteral()}.");
      if (_BaseOpServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (_BaseOpServiceRequest.ServiceNegotiator == null)
        throw new NullReferenceException("ServiceNegotiator cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = _BaseOpServiceRequest.SearchParameterGeneric;
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

        var oResourceService = _BaseOpServiceRequest.ServiceNegotiator.GetResourceService(ResourceName);
        int TotalCount = oResourceService.GetTotalCurrentResourceCount();
        
        var TotalCountParameter = new Parameters.ParameterComponent();
        TotalCountParameter.Name = $"TotalCount";
        TotalCountParameter.Value = new FhirDecimal(TotalCount);
        ResourceReportParameter.Part.Add(TotalCountParameter);

        if (TotalCount > 0)
        {
          DateTimeOffset? LastUpdated = oResourceService.GetLastCurrentResourceLastUpdatedValue();
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

  }
}
