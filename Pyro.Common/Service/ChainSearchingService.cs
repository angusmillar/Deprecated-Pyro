using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.Service
{
  public class ChainSearchingService : IChainSearchingService
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;

    private IResourceRepository IResourceRepository;

    //Constructor for dependency injection
    public ChainSearchingService(IRepositorySwitcher IRepositorySwitcher, IPyroFhirUriFactory IPyroFhirUriFactory)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
    }

    public void ResolveChain(ISearchParameterReferance SearchParameterReferance)
    {
      if (!SearchParameterReferance.IsChained)
        throw new Exception("Server Error: SearchParameterReferance.IsChained must be true for ChainSearchingService.");

      IEnumerable<string> FhirIdList = new List<string>();
      //Work through each chain parameter in reverse
      bool PrimarySearchPerfomed = false;
      foreach (ISearchParameterBase SearchParameterBase in SearchParameterReferance.ChainedSearchParameterList.Reverse<ISearchParameterBase>())
      {
        if (!PrimarySearchPerfomed)
        {
          IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(SearchParameterBase.Resource));
          PyroSearchParameters SearchParameters = new PyroSearchParameters();
          SearchParameters.SearchParametersList = new List<ISearchParameterBase>() { SearchParameterBase };
          IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceBySearch(SearchParameters);
          FhirIdList = DatabaseOperationOutcome.ReturnedResourceList.Select(x => x.FhirId);
          PrimarySearchPerfomed = true;
        }
        else
        {
          IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(SearchParameterBase.Resource));
          PyroSearchParameters SearchParameters = new PyroSearchParameters();
          //Not sure this resource name is correct or even always populated??
          if (string.IsNullOrWhiteSpace(SearchParameterBase.TypeModifierResource))
          {
            SetSearchParameterValueList(FhirIdList, SearchParameterBase.TargetResourceTypeList[0].ResourceType.GetLiteral(), SearchParameterBase);
          }
          else
          {
            SetSearchParameterValueList(FhirIdList, SearchParameterBase.TypeModifierResource, SearchParameterBase);
          }
          SearchParameters.SearchParametersList = new List<ISearchParameterBase>() { SearchParameterBase };
          IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceBySearch(SearchParameters);
          FhirIdList = DatabaseOperationOutcome.ReturnedResourceList.Select(x => x.FhirId);
        }
      }
      //We use the resource type from the first in the list which was the last above because we Reversed the list in the foreach loop above.
      SetSearchParameterValueList(FhirIdList, SearchParameterReferance.ChainedSearchParameterList[0].Resource, SearchParameterReferance);
    }

    private void SetSearchParameterValueList(IEnumerable<string> FhirIdList, string ReferanceResourceName, ISearchParameterBase SearchParameterBase)
    {
      if (SearchParameterBase is SearchParameterReferance Referance)
      {
        Referance.ValueList = new List<SearchParameterReferanceValue>();
        //This adds each FhirId as an 'OR' for the search.
        foreach (string FhirId in FhirIdList)
        {
          var FhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
          if (FhirUri.Parse($"{ReferanceResourceName}/{FhirId}"))
          {
            Referance.ValueList.Add(new SearchParameterReferanceValue() { FhirRequestUri = FhirUri, IsMissing = false });
          }
          else
          {
            throw new Exception($"Server Error: can not parse server constructed FHIR URI of '{Referance.ChainedSearchParameterList[0].Resource}/{FhirId}'");
          }
        }
      }
      else
      {
        throw new Exception($"Server Error: Cannot cast Chained search parameter as expected to SearchParameterReferance, type was {SearchParameterBase.GetType().ToString()}");
      }
    }
  }
}
