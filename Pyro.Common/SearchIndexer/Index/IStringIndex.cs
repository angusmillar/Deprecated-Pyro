using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IStringIndex : IIndexBase
  {
    new int ServiceSearchParameterId { get; }

    string String { get; set; }
  }
}