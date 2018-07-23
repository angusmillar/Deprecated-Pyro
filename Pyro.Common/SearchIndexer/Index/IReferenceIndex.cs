using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IReferenceIndex : IIndexBase
  {
    new int ServiceSearchParameterId { get; }

    string VersionId { get; set; }
    string FhirId { get; set; }
    string ResourceType { get; set; }    
    string BaseUrl { get; set; }
    bool IsRelativeToServer { get; set; }
  }
}