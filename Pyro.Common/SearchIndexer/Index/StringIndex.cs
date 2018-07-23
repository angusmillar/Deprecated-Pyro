using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public class StringIndex : IndexBase, IStringIndex
  { 
    public StringIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
      : base(ServiceSearchParameterLight) { }

    new int ServiceSearchParameterId { get; }

    public string String { get; set; }
  }
}
