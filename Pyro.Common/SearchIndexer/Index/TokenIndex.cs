using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class TokenIndex : IndexBase, ITokenIndex
  { 
    public TokenIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
      : base(ServiceSearchParameterLight) { }

    new int ServiceSearchParameterId { get; }

    public string Code { get; set; }
    public string System { get; set; }
  }
}
