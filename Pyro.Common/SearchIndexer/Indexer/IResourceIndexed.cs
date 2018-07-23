using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Indexer
{
  public interface IResourceIndexed
  {
    ResourceType ResourceType { get; set; }
    
    string FhirID { get; set; }
    string Key { get; set; }

    List<IQuantityIndex> IndexQuantityList { get; set; }
    List<IReferenceIndex> IndexReferenceList { get; set; }
    List<IDateTimeIndex> IndexDateTimeList { get; set; }
    List<IStringIndex> IndexStringList { get; set; }
    List<ITokenIndex> IndexTokenList { get; set; }
    List<IUriIndex> IndexUriList { get; set; }

    void Index(Resource Resource, PyroSearchParameters DtoSearchParameters = null);
  }
}