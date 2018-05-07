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
  public class IncludeService : IIncludeService
  {
    private IResourceRepository IResourceRepository;
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly ICommonFactory ICommonFactory;
    private readonly ISearchParameterFactory ISearchParameterFactory;
    //private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    //private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly ICompartmentSearchParameterService ICompartmentSearchParameterService;

    private readonly int MaxRecursionDepth = 20; //This should really be in the Server config e.g (GlobalProperties)?
    private string _Compartment = string.Empty;
    private string _CompartmentId = string.Empty;
    //Constructor for dependency injection
    public IncludeService(IRepositorySwitcher IRepositorySwitcher, ICommonFactory ICommonFactory, ISearchParameterFactory ISearchParameterFactory, ICompartmentSearchParameterService ICompartmentSearchParameterService)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.ICommonFactory = ICommonFactory;
      this.ISearchParameterFactory = ISearchParameterFactory;
      //this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
      this.ICompartmentSearchParameterService = ICompartmentSearchParameterService;
      //this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
    }

    public List<DtoResource> ResolveIncludeResourceList(List<SearchParameterInclude> IncludeList, List<DtoResource> SourceInputResourceList, string Compartment = "", string CompartmentId = "")
    {
      if (IncludeList == null)
        throw new NullReferenceException("IncludeList cannot be null");

      if (SourceInputResourceList == null)
        throw new NullReferenceException("SearchResourceList cannot be null");

      this._Compartment = Compartment;
      this._CompartmentId = CompartmentId;

      var TotalResourceList = new List<DtoResource>();
      TotalResourceList.AddRange(SourceInputResourceList);

      var IncludeResourceList = new List<DtoResource>();
      var RecursiveIncludeList = new List<SearchParameterInclude>();
      var CacheResourceIDsAlreadyCollected = new HashSet<string>();

      RecursiveIncludeList = IncludeList.Where(x => x.IsRecurse == true).ToList();

      //Add all the source resources to the Cache list as their is no reason to get them again as they are in the bundle list
      TotalResourceList.ForEach(x => CacheResourceIDsAlreadyCollected.Add($"{x.ResourceType.GetLiteral()}-{x.FhirId}"));

      //First Pass uses non-recursive includes and recursive includes      
      IncludeResourceList.AddRange(GetIncludes(IncludeList.Where(x => x.Type == SearchParameterInclude.IncludeType.Include).ToList(), TotalResourceList, CacheResourceIDsAlreadyCollected));
      IncludeResourceList.AddRange(GetRevIncludes(IncludeList.Where(x => x.Type == SearchParameterInclude.IncludeType.RevInclude).ToList(), TotalResourceList, CacheResourceIDsAlreadyCollected));

      TotalResourceList.AddRange(IncludeResourceList);

      int CurrentIncludeCount = 0;
      int RecursionDepthCounter = 0;
      var TempResourceList = new List<DtoResource>();
      while (CurrentIncludeCount < CacheResourceIDsAlreadyCollected.Count() && RecursiveIncludeList.Count > 0 && RecursionDepthCounter < MaxRecursionDepth)
      {
        CurrentIncludeCount = CacheResourceIDsAlreadyCollected.Count();
        TempResourceList.Clear();
        TempResourceList.AddRange(GetIncludes(RecursiveIncludeList.Where(x => x.Type == SearchParameterInclude.IncludeType.Include).ToList(), IncludeResourceList, CacheResourceIDsAlreadyCollected));
        TempResourceList.AddRange(GetRevIncludes(RecursiveIncludeList.Where(x => x.Type == SearchParameterInclude.IncludeType.RevInclude).ToList(), IncludeResourceList, CacheResourceIDsAlreadyCollected));
        TotalResourceList.AddRange(TempResourceList);
        RecursionDepthCounter++;
      }
      return TotalResourceList;
    }

    private List<DtoResource> GetIncludes(List<SearchParameterInclude> IncludeList, List<DtoResource> CurrentScourceResourceList, HashSet<string> CacheResourceIDsAlreadyCollected)
    {
      var ReturnResourceList = new List<DtoResource>();
      if (IncludeList == null || IncludeList.Count == 0)
        return ReturnResourceList;

      if (CurrentScourceResourceList == null || CurrentScourceResourceList.Count == 0)
        return ReturnResourceList;

      foreach (var Resource in CurrentScourceResourceList)
      {
        //Now process each include
        foreach (var include in IncludeList)
        {
          if (Resource.ResourceType.Value == include.SourceResourceType)
          {
            IResourceRepository = IRepositorySwitcher.GetRepository(Resource.ResourceType.Value);            

            //We only want to get the include target Resources
            if (include.SearchParameterTargetResourceType.HasValue)
            {
              //Get the Search parameter Ids where the search parameter target list can contain the include's Resource target type
              int[] IdArray = include.SearchParameterList.Where(z => z.TargetResourceTypeList.Any(c => c.ResourceType.GetLiteral() == include.SearchParameterTargetResourceType.Value.GetLiteral())).Select(x => x.Id).ToArray();
              //Now only get the FhirId of the resources that have Search Index References that have these include target resource
              string[] FhirIdList = IResourceRepository.GetResourceFhirIdByResourceIdAndIndexReferance(Resource.Id, IdArray, include.SearchParameterTargetResourceType.Value.GetLiteral());
              //Set the repository to the include's target resource in order to get the include resources
              IResourceRepository = IRepositorySwitcher.GetRepository(include.SearchParameterTargetResourceType.Value);              
              //Get each as long as it is not already gotten based on CacheResourceIDsAlreadyCollected list
              foreach (string FhirId in FhirIdList)
              {
                AddIncludeResourceInstanceForIncludes(ReturnResourceList, CacheResourceIDsAlreadyCollected, FhirId);
              }
            }
            else
            {
              //There is no include target so try and get all
              foreach (var IncludeItemSearchParameter in include.SearchParameterList)
              {
                foreach (var SearchParameterResourceTarget in IncludeItemSearchParameter.TargetResourceTypeList)
                {
                  //Switch source resource repository to get reference FhirIds
                  IResourceRepository = IRepositorySwitcher.GetRepository(Resource.ResourceType.Value);                  
                  string[] FhirIdList = IResourceRepository.GetResourceFhirIdByResourceIdAndIndexReferance(Resource.Id, new int[] { IncludeItemSearchParameter.Id }, SearchParameterResourceTarget.ResourceType.GetLiteral());
                  if (FhirIdList.Count() > 0)
                  {
                    //Switch to SearchParameterResourceTarget resource repository to get the include resource if found
                    IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(SearchParameterResourceTarget.ResourceType));                    
                    foreach (string FhirId in FhirIdList)
                    {
                      //Don't source the same resource again from the Database if we already have it
                      AddIncludeResourceInstanceForIncludes(ReturnResourceList, CacheResourceIDsAlreadyCollected, FhirId);
                    }
                  }
                }
              }
            }
          }
        }
      }
      return ReturnResourceList;
    }

    private List<DtoResource> GetRevIncludes(List<SearchParameterInclude> RevIncludeList, List<DtoResource> CurrentScourceResourceList, HashSet<string> CacheResourceIDsAlreadyCollected)
    {
      var ReturnResourceList = new List<DtoResource>();

      if (RevIncludeList == null || RevIncludeList.Count == 0)
        return ReturnResourceList;

      if (CurrentScourceResourceList == null || CurrentScourceResourceList.Count == 0)
        return ReturnResourceList;

      foreach (var Resource in CurrentScourceResourceList)
      {
        //Now process each include
        foreach (var RevInclude in RevIncludeList)
        {
          PyroSearchParameters SearchParameters = new PyroSearchParameters();
          SearchParameters.SearchParametersList = new List<ISearchParameterBase>();

          //Does the include have a target Resource type
          if (RevInclude.SearchParameterTargetResourceType.HasValue)
          {
            //Is the target Resource type of the include == to the current Resource we are targeting
            if (Resource.ResourceType.Value == RevInclude.SearchParameterTargetResourceType.Value)
            {
              IResourceRepository = IRepositorySwitcher.GetRepository(RevInclude.SourceResourceType);
              foreach (DtoServiceSearchParameterLight p in RevInclude.SearchParameterList)
              {
                //Check the current search Parameter has a Target == to the Resource we are targeting
                if (p.TargetResourceTypeList.Any(x => x.ResourceType.GetLiteral() == Resource.ResourceType.Value.GetLiteral()))
                {
                  //Construct the search parameter string
                  var ParameterString = new Tuple<string, string>(p.Name, $"{RevInclude.SearchParameterTargetResourceType.GetLiteral()}/{Resource.FhirId}");
                  ISearchParameterBase SearchParam = ISearchParameterFactory.CreateSearchParameter(p, ParameterString);
                  SearchParameters.SearchParametersList.Clear();
                  SearchParameters.SearchParametersList.Add(SearchParam);
                  //Get from the database and only add if we don't already have it
                  AddIncludeResourceInstanceForRevIncludes(ReturnResourceList, CacheResourceIDsAlreadyCollected, SearchParameters);
                }
              }
            }
          }
          else
          {
            foreach (DtoServiceSearchParameterLight p in RevInclude.SearchParameterList)
            {
              if (p.TargetResourceTypeList.Any(x => x.ResourceType.GetLiteral() == Resource.ResourceType.Value.GetLiteral()))
              {
                IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(p.Resource));
                //Construct the search parameter string                
                var ParameterString = new Tuple<string, string>(p.Name, $"{Resource.ResourceType.Value.GetLiteral()}/{Resource.FhirId}");
                ISearchParameterBase SearchParam = ISearchParameterFactory.CreateSearchParameter(p, ParameterString);
                SearchParameters.SearchParametersList.Clear();
                SearchParameters.SearchParametersList.Add(SearchParam);
                //Get from the database and only add if we don't already have it
                AddIncludeResourceInstanceForRevIncludes(ReturnResourceList, CacheResourceIDsAlreadyCollected, SearchParameters);
              }
            }
          }
        }
      }
      return ReturnResourceList;
    }

    private void AddIncludeResourceInstanceForRevIncludes(List<DtoResource> IncludeResourceList, HashSet<string> CacheResourceIDsAlreadyCollected, PyroSearchParameters SearchParameters)
    {
      
      //Here we need to add compartment search, if we have a Compartment and id
      IDatabaseOperationOutcome DatabaseOperationOutcomeIncludes = null;
      if (!string.IsNullOrWhiteSpace(this._Compartment) && !string.IsNullOrWhiteSpace(this._CompartmentId))
      {        
        PyroSearchParameters CompartmentSearchParameter = ICompartmentSearchParameterService.GetSearchParameters(this._Compartment, this._CompartmentId, IResourceRepository.RepositoryResourceType.GetLiteral());
        DatabaseOperationOutcomeIncludes = IResourceRepository.GetResourceByCompartmentSearch(CompartmentSearchParameter, SearchParameters, true);
      }
      else
      {
        DatabaseOperationOutcomeIncludes = IResourceRepository.GetResourceBySearch(SearchParameters, true);
      }

      //Don't source the same resource again from the Database if we already have it        
      if (DatabaseOperationOutcomeIncludes.ReturnedResourceList != null)
      {
        foreach (var Resource in DatabaseOperationOutcomeIncludes.ReturnedResourceList)
        {
          if (!CacheResourceIDsAlreadyCollected.Contains($"{Resource.ResourceType.Value.GetLiteral()}-{Resource.FhirId}"))
          {
            IncludeResourceList.Add(Resource);
            CacheResourceIDsAlreadyCollected.Add($"{Resource.ResourceType.Value.GetLiteral()}-{Resource.FhirId}");
          }
        }
      }
    }

    private void AddIncludeResourceInstanceForIncludes(List<DtoResource> IncludeResourceList, HashSet<string> CacheResourceIDsAlreadyCollected, string FhirId)
    {
      //Don't source the same resource again from the Database if we already have it        
      if (!CacheResourceIDsAlreadyCollected.Contains($"{IResourceRepository.RepositoryResourceType.GetLiteral()}-{FhirId}"))
      {
        IDatabaseOperationOutcome DatabaseOperationOutcomeIncludes = null;
        //Here we need to add compartment search, if we have a Compartment and id
        if (!string.IsNullOrWhiteSpace(this._Compartment) && !string.IsNullOrWhiteSpace(this._CompartmentId))
        {
          //Here we need create a search parameter for _id={FhirId)
          var IdSearchParameter = ServiceSearchParameterFactory.BaseResourceSearchParameters().SingleOrDefault(x => x.Name == "_id");
          var IdParameterString = new Tuple<string, string>(IdSearchParameter.Name, FhirId);
          ISearchParameterBase SearchParam = ISearchParameterFactory.CreateSearchParameter(IdSearchParameter, IdParameterString);
          PyroSearchParameters FhirIdSearchParameter = new PyroSearchParameters();
          FhirIdSearchParameter.SearchParametersList = new List<ISearchParameterBase>();          
          FhirIdSearchParameter.SearchParametersList.Add(SearchParam);

          //And now the Compartmnet Search parameters
          PyroSearchParameters CompartmentSearchParameter = ICompartmentSearchParameterService.GetSearchParameters(this._Compartment, this._CompartmentId, IResourceRepository.RepositoryResourceType.GetLiteral());          
          DatabaseOperationOutcomeIncludes = IResourceRepository.GetResourceByCompartmentSearch(CompartmentSearchParameter, FhirIdSearchParameter, true);
        }
        else
        {
          DatabaseOperationOutcomeIncludes = IResourceRepository.GetResourceByFhirID(FhirId, true, false);          
        }

        var DtoIncludeResourceList = new List<Common.BusinessEntities.Dto.DtoIncludeResource>();
        DatabaseOperationOutcomeIncludes.ReturnedResourceList.ForEach(x => DtoIncludeResourceList.Add(new Common.BusinessEntities.Dto.DtoIncludeResource(x)));
        IncludeResourceList.AddRange(DtoIncludeResourceList);
        CacheResourceIDsAlreadyCollected.Add($"{IResourceRepository.RepositoryResourceType.GetLiteral()}-{FhirId}");
      }
    }

  }
}
