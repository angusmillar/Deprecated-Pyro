using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Common.Enum
{
  public static partial class FhirSearchEnum
  {
    public enum SearchPrefixType
    {
      None,
      Equal,
      NotEqual,
      Greater,
      Less,
      GreaterOrEqual,
      LessOrEqual,
      StartsAfter,
      EndsBefore,
      Approximately
    }
    public static Dictionary<string, SearchPrefixType> GetSearchPrefixTypeDictionary()
    {
      return new Dictionary<string, SearchPrefixType>()
      {
        {"ap", SearchPrefixType.Approximately},
        {"eb", SearchPrefixType.EndsBefore},
        {"eq", SearchPrefixType.Equal},
        {"gt", SearchPrefixType.Greater},
        {"ge", SearchPrefixType.GreaterOrEqual},
        {"lt", SearchPrefixType.Less},
        {"le", SearchPrefixType.LessOrEqual},
        {"ne", SearchPrefixType.NotEqual},
        {"sa", SearchPrefixType.StartsAfter}
      };
    }

    public enum SearchModifierType
    {
      None,
      Missing,
      Exact,
      Contains,
      Text,
      Type,
      Below,
      Above,
      In,
      NotIn
    }



  }
}
