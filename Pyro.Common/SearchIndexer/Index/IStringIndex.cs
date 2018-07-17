using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IStringIndex
  {
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    string String { get; set; }
  }
}