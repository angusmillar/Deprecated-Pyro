using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface ITokenIndex : IIndexBase
  {
    new int ServiceSearchParameterId { get; }

    string Code { get; set; }    
    string System { get; set; }    
  }
}