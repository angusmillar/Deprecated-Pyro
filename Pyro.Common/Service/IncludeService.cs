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

namespace Pyro.Common.Service
{
  public class IncludeService : IIncludeService
  {
    private IResourceRepository IResourceRepository;
    private readonly IRepositorySwitcher IRepositorySwitcher;

    //Constructor for dependency injection
    public IncludeService(IRepositorySwitcher IRepositorySwitcher)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
    }

    public List<DtoResource> ResolveIncludeResourceList(List<SearchParameterInclude> IncludeList, List<DtoResource> SourceInputResourceList, bool Recursive = false)
    {
      if (IncludeList == null)
        throw new NullReferenceException("IncludeList cannot be null");

      if (SourceInputResourceList == null)
        throw new NullReferenceException("SearchResourceList cannot be null");

      var TotalResourceList = new List<DtoResource>();
      TotalResourceList.AddRange(SourceInputResourceList);

      var IncludeResourceList = new List<DtoResource>();
      var CacheResourceIDsAlreadyCollected = new HashSet<string>();
      var RecursiveIncludeList = IncludeList.Where(x => x.IsRecurse == true).ToList();

      //Add all the source resources to the Cache list as their is no reason to get them again as they are in the bundle list
      TotalResourceList.ForEach(x => CacheResourceIDsAlreadyCollected.Add($"{x.ResourceType.GetLiteral()}-{x.FhirId}"));

      //First Pass uses non-recursive includes and recursive includes      
      IncludeResourceList = GetIncludes(IncludeList, TotalResourceList, CacheResourceIDsAlreadyCollected);
      TotalResourceList.AddRange(IncludeResourceList);

      int CurrentIncludeCount = 0;
      while (CurrentIncludeCount < CacheResourceIDsAlreadyCollected.Count() && RecursiveIncludeList.Count > 0)
      {
        CurrentIncludeCount = CacheResourceIDsAlreadyCollected.Count();
        IncludeResourceList = GetIncludes(RecursiveIncludeList, IncludeResourceList, CacheResourceIDsAlreadyCollected);
        TotalResourceList.AddRange(IncludeResourceList);
        //IncludeResourceList.Clear();
      }
      return TotalResourceList;
    }

    private List<DtoResource> GetIncludes(List<SearchParameterInclude> IncludeList, List<DtoResource> CurrentScourceResourceList, HashSet<string> CacheResourceIDsAlreadyCollected)
    {
      var ReturnResourceList = new List<DtoResource>();
      foreach (var Resource in CurrentScourceResourceList)
      {
        //Now process each include
        foreach (var include in IncludeList)
        {
          if (Resource.ResourceType.Value == include.SourceResourceType)
          {
            IResourceRepository = IRepositorySwitcher.GetRepository(Resource.ResourceType.Value);
            //SetCurrentResourceType(Resource.ResourceType.Value);

            //We only want to get the include target Resources
            if (include.SearchParameterTargetResourceType.HasValue)
            {
              //Get the Search parameter Ids where the search parameter target list can contain the include's Resource target type
              int[] IdArray = include.SearchParameterList.Where(z => z.TargetResourceTypeList.Any(c => c.ResourceType.GetLiteral() == include.SearchParameterTargetResourceType.Value.GetLiteral())).Select(x => x.Id).ToArray();
              //Now only get the FhirId of the resources that have Search Index References that have these include target resource
              string[] FhirIdList = IResourceRepository.GetResourceFhirIdByResourceIdAndIndexReferance2(Resource.Id, IdArray, include.SearchParameterTargetResourceType.Value.GetLiteral());
              //Set the repository to the include's target resource in order to get the include resources
              IResourceRepository = IRepositorySwitcher.GetRepository(include.SearchParameterTargetResourceType.Value);
              //SetCurrentResourceType(include.SearchParameterTargetResourceType.Value);
              //Get each as long as it is not already gotten based on CacheResourceIDsAlreadyCollected list
              foreach (string FhirId in FhirIdList)
              {
                AddIncludeResourceInstance(ReturnResourceList, CacheResourceIDsAlreadyCollected, FhirId);
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
                  //SetCurrentResourceType(Resource.ResourceType.Value);
                  string[] FhirIdList = IResourceRepository.GetResourceFhirIdByResourceIdAndIndexReferance2(Resource.Id, new int[] { IncludeItemSearchParameter.Id }, SearchParameterResourceTarget.ResourceType.GetLiteral());
                  if (FhirIdList.Count() > 0)
                  {
                    //Switch to SearchParameterResourceTarget resource repository to get the include resource if found
                    IResourceRepository = IRepositorySwitcher.GetRepository(ResourceNameResolutionSupport.GetResourceFhirAllType(SearchParameterResourceTarget.ResourceType));
                    //SetCurrentResourceType(SearchParameterResourceTarget.ResourceType);
                    foreach (string FhirId in FhirIdList)
                    {
                      //Don't source the same resource again from the Database if we already have it
                      AddIncludeResourceInstance(ReturnResourceList, CacheResourceIDsAlreadyCollected, FhirId);
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

    private void AddIncludeResourceInstance(List<DtoResource> IncludeResourceList, HashSet<string> CacheResourceIDsAlreadyCollected, string FhirId)
    {
      //Don't source the same resource again from the Database if we already have it        
      if (!CacheResourceIDsAlreadyCollected.Contains($"{IResourceRepository.RepositoryResourceType.GetLiteral()}-{FhirId}"))
      {
        IDatabaseOperationOutcome DatabaseOperationOutcomeIncludes = IResourceRepository.GetResourceByFhirID(FhirId, true, false);
        var DtoIncludeResourceList = new List<Common.BusinessEntities.Dto.DtoIncludeResource>();
        DatabaseOperationOutcomeIncludes.ReturnedResourceList.ForEach(x => DtoIncludeResourceList.Add(new Common.BusinessEntities.Dto.DtoIncludeResource(x)));
        IncludeResourceList.AddRange(DtoIncludeResourceList);
        CacheResourceIDsAlreadyCollected.Add($"{IResourceRepository.RepositoryResourceType.GetLiteral()}-{FhirId}");
      }
    }

  }
}
