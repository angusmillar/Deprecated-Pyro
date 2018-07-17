using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IUriIndex
  {
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    string Uri { get; set; }
  }
}