using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface ITokenIndex
  {
    string Code { get; set; }
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    string System { get; set; }
  }
}