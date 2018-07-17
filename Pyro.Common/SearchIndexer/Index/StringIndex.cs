using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class StringIndex : IStringIndex
  { 

    public StringIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }

    public string String { get; set; }
  }
}
