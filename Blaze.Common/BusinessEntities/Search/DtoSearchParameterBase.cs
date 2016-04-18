using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;

namespace Blaze.Common.BusinessEntities.Search
{
  public enum SearchPrefixType { None, Equal, NotEqual, Greater, Less, GreaterOrEqual, LessOrEqual, StartsAfter, EndsBefore, Approximately }
  public enum SearchModifierType { None, Missing, Exact, Contains, Text, Type, Below, Above, In, NotIn }

  public abstract class DtoSearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public DtoEnums.Search.SearchParameterName Name { get; set; }
    public DtoEnums.SupportedFhirResource Resource { get; set; }
    public string RawValue { get; set; }
    public SearchParamType SearchParameterType { get; set; }
    public SearchModifierType Modifier { get; set; }
    public ResourceType? TypeModifierResource { get; set; }
    public SearchPrefixType Prefix { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public abstract bool TryParseValue(string Value);
    public DtoSearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
    }
  }
}
