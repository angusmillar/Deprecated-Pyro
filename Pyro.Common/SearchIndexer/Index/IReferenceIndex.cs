using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IReferenceIndex
  {
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    string VersionId { get; set; }
    string FhirId { get; set; }
    string ResourceType { get; set; }    
    string BaseUrl { get; set; }
    bool IsRelativeToServer { get; set; }
  }
}