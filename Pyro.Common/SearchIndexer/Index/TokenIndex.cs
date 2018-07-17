using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class TokenIndex : ITokenIndex
  { 
    public TokenIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }

    public string Code { get; set; }
    public string System { get; set; }
  }
}
