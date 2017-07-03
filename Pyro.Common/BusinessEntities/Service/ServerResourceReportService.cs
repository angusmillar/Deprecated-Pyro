using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ServerResourceReportService : IServerResourceReportService
  {
    private readonly IResourceServices IResourceServices;

    public ServerResourceReportService(IResourceServices IResourceServices)
    {
      this.IResourceServices = IResourceServices;
    }

    public IResourceServiceOutcome Process(IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");

      try
      {
        IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

        ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
        SearchParametersServiceRequest.CommonServices = null;
        SearchParametersServiceRequest.SearchParameterGeneric = SearchParameterGeneric;
        var SearchParameterService = new SearchParameterService();
        SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
        SearchParametersServiceRequest.ResourceType = null;
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
          ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
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

          IResourceServices.SetCurrentResourceType(ResourceName);
          int TotalCount = IResourceServices.GetTotalCurrentResourceCount();

          var TotalCountParameter = new Parameters.ParameterComponent();
          TotalCountParameter.Name = $"TotalCount";
          TotalCountParameter.Value = new FhirDecimal(TotalCount);
          ResourceReportParameter.Part.Add(TotalCountParameter);

          if (TotalCount > 0)
          {
            DateTimeOffset? LastUpdated = IResourceServices.GetLastCurrentResourceLastUpdatedValue();
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
