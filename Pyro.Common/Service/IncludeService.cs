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
    private List<DtoResource> SourceResourceList;

    //Constructor for dependency injection
    public IncludeService(IRepositorySwitcher IRepositorySwitcher)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
    }

    public List<DtoResource> ResolveIncludeResourceList(List<SearchParameterInclude> IncludeList, List<DtoResource> SourceResourceList, bool Recursive = false)
    {
      if (IncludeList == null)
        throw new NullReferenceException("IncludeList cannot be null");

      if (SourceResourceList == null)
        throw new NullReferenceException("SearchResourceList cannot be null");

      this.SourceResourceList = SourceResourceList;
      var IncludeResourceList = new List<DtoResource>();

      HashSet<string> CacheResourceIDsAlreadyCollected = null;

      IEnumerable<SearchParameterInclude> IncludeListToProcess = null;
      if (Recursive)
      {
        IncludeListToProcess = IncludeList.Where(x => x.IsRecurse);
      }
      else
      {
        CacheResourceIDsAlreadyCollected = new HashSet<string>();
        //Add all the source resources to the Cache list as their is no reason to get them again as they are in the bundle list
        SourceResourceList.ForEach(x => CacheResourceIDsAlreadyCollected.Add($"{x.ResourceType.GetLiteral()}-{x.FhirId}"));
        IncludeListToProcess = IncludeList;
      }

      foreach (var Resource in SourceResourceList)
      {
        //Only add when not recursive as this adds the source resource from initial search
        if (!Recursive)
          IncludeResourceList.Add(Resource);

        //Now process each include
        foreach (var include in IncludeListToProcess)
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
                AddIncludeResourceInstance(IncludeResourceList, CacheResourceIDsAlreadyCollected, FhirId);
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
                      AddIncludeResourceInstance(IncludeResourceList, CacheResourceIDsAlreadyCollected, FhirId);
                    }
                  }
                }
              }
            }
          }
        }
      }
      return IncludeResourceList;
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
