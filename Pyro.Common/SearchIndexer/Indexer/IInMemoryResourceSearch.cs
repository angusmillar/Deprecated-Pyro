using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Indexer
{
  public interface IInMemoryResourceSearch
  {
    List<IResourceIndexed> SearchResourceList(ICollection<Resource> ResourceList, PyroSearchParameters DtoSearchParameters);
    List<IResourceIndexed> SearchKeyedResourceList(Dictionary<string, Resource> ResourceDictonary, PyroSearchParameters DtoSearchParameters);
    void LoadResourceList(ICollection<Resource> ResourceList);
    List<IResourceIndexed> SearchLoadedResources(PyroSearchParameters DtoSearchParameters);    
  }
}