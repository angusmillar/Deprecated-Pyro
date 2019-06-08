using Pyro.Common.Attributes;

namespace Pyro.Common.Enum
{
  public enum SearchParameterSearchResultParameterType
  {
    [EnumLiteral("_sort")]
    _sort,
    [EnumLiteral("_count")]
    _count,
    [EnumLiteral("_include")]
    _include,
    [EnumLiteral("_revinclude")]
    _revinclude,
    [EnumLiteral("_summary")]
    _summary,
    [EnumLiteral("_total")]
    _total,
    [EnumLiteral("_elements")]
    _elements,
    [EnumLiteral("contained")]
    _contained,
    [EnumLiteral("_containedType")]
    _containedType,
    [EnumLiteral("page")]
    page,
  }
}
