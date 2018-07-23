using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class UriIndex : IndexBase, IUriIndex
  { 
    public UriIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
      : base(ServiceSearchParameterLight) { }

    new int ServiceSearchParameterId { get; }
    public string Uri { get; set; }
  }
}
