using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.Service
{
  public class ServerResourceReportService : IServerResourceReportService
  {
    private readonly IResourceServices IResourceServices;    
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;

    public ServerResourceReportService(IResourceServices IResourceServices, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory)
    {
      this.IResourceServices = IResourceServices;      
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
    }

    public IResourceServiceOutcome Process(ISearchParameterGeneric SearchParameterGeneric)
    {
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");

      try
      {
        IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

        ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
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
