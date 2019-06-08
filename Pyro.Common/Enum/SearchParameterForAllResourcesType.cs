using Pyro.Common.Attributes;

namespace Pyro.Common.Enum
{
  public enum SearchParameterForAllResourcesType
  {
    [EnumLiteral("_id")]
    _id,
    [EnumLiteral("_lastUpdated")]
    _lastUpdated,
    [EnumLiteral("_tag")]
    _tag,
    [EnumLiteral("_profile")]
    _profile,
    [EnumLiteral("_security")]
    _security,
    [EnumLiteral("_text")]
    _text,
    [EnumLiteral("_content")]
    _content,
    [EnumLiteral("_list")]
    _list,
    [EnumLiteral("_has")]
    _has,
    [EnumLiteral("_type")]
    _type,        
  }
}
