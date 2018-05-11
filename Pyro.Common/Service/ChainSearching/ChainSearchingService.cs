using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Service.ChainSearching
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

    public bool ResolveChain(ISearchParameterReferance SearchParameterReferance)
    {
      bool ChainTargetFound = true;
      if (!SearchParameterReferance.IsChained)
        throw new Exception("Server Error: SearchParameterReferance.IsChained must be true for ChainSearchingService.");

      IEnumerable<string> FhirIdList = null;
      //Work through each chain parameter in reverse
      bool PrimarySearchPerfomed = false;
      for (int i = SearchParameterReferance.ChainedSearchParameterList.Count - 1; i >= 0; i--)
      {
        ISearchParameterBase SearchParameterBase = SearchParameterReferance.ChainedSearchParameterList[i];
        //When the Chained parameter is a parameter for all resource types we need to switch the TypeModifierResource given for the 
        //previous chain parameter or the root parameter 
        //for example 'Observation?subject:Patient._id=FCC-PAT-0001'
        //Here the _id is an all Resource type search parameter so it's SearchParameterBase.Resource = Resource, we need here to refer to the 
        //given SearchParameterReferance.TypeModifierResource as seen in the search string ':Patient'
        //Another example is 'DiagnosticReport?result:Observation.subject:Patient._id=FCC-PAT-00001' where the need to get the previous TypeModifierResource
        //from the list of chain parameters or the root parameter when i = 0.
        //so for this last example we need ':Patient' for the '_id' and ':Observation' for the 'subject'
        string ResourceRequiredForRepository = string.Empty;
        if (i > 0)
        {
          ResourceRequiredForRepository = ResolveResourceTypeFromSearchParameterResourceModifier(SearchParameterBase.Resource, SearchParameterReferance.ChainedSearchParameterList[i-1].TypeModifierResource);
        }
        else
        {
          ResourceRequiredForRepository = ResolveResourceTypeFromSearchParameterResourceModifier(SearchParameterBase.Resource, SearchParameterReferance.TypeModifierResource);
        }
        
        if (!PrimarySearchPerfomed)
        {
          IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceRequiredForRepository));
          PyroSearchParameters SearchParameters = new PyroSearchParameters();
          SearchParameters.SearchParametersList = new List<ISearchParameterBase>() { SearchParameterBase };
          FhirIdList = IResourceRepository.GetResourceFhirIdBySearchNoPaging(SearchParameters);
          PrimarySearchPerfomed = true;
          if (FhirIdList.Count() == 0)
          {
            ChainTargetFound = false;
            break;
          }

        }
        else
        {
          IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceRequiredForRepository));
          string ReferenceResourceTargetName = string.Empty;
          if (string.IsNullOrWhiteSpace(SearchParameterBase.TypeModifierResource))
          {
            ReferenceResourceTargetName = SearchParameterBase.TargetResourceTypeList[0].ResourceType.GetLiteral();
          }
          else
          {
            ReferenceResourceTargetName = SearchParameterBase.TypeModifierResource;
          }
          FhirIdList = IResourceRepository.GetResourceFhirIdByReferanceIndex(FhirIdList, ReferenceResourceTargetName, SearchParameterBase.Id);
          if (FhirIdList.Count() == 0)
          {
            ChainTargetFound = false;
            break;
          }
        }
      }

      if (ChainTargetFound)
      {
        //We use the resource type from the first in the list which was the last above because we Reversed the list in the for each loop above.
        string ResourceType = ResolveResourceTypeFromSearchParameterResourceModifier(SearchParameterReferance.ChainedSearchParameterList[0].Resource, SearchParameterReferance.TypeModifierResource);
        SetSearchParameterValueList(FhirIdList, ResourceType, SearchParameterReferance);
      }
      return ChainTargetFound;
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

    private string ResolveResourceTypeFromSearchParameterResourceModifier(string SerachParameterResource, string TypeModifierResource)
    {
      if (SerachParameterResource == Hl7.Fhir.Model.ResourceType.Resource.GetLiteral())
      {
        return TypeModifierResource;
      }
      return SerachParameterResource;
    }
  }
}
