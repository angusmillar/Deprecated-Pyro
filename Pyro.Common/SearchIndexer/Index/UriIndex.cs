using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class UriIndex : IUriIndex
  { 
    public UriIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }

    public string Uri { get; set; }
  }
}
