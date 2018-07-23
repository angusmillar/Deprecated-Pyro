using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IUriIndex : IIndexBase
  {
    new int ServiceSearchParameterId { get; }

    string Uri { get; set; }
  }
}