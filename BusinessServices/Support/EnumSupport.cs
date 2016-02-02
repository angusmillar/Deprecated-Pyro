using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities;

namespace Blaze.Engine.Support
{
  public static class EnumSupport
  {

    public enum SearchTermName
    {
      None,
      _Id,
      Active,
      Family,
      Given,
      Name,
      Phonetic,
      Identifier,
      Page
    };

    public static Dictionary<string, SearchTermName> GetSearchTermNameDictionary()
    {
      return new Dictionary<string, SearchTermName>()
      {
        {"_id",SearchTermName._Id},
        {"active",SearchTermName.Active},
        {"family",SearchTermName.Family},
        {"given",SearchTermName.Given},        
        {"name",SearchTermName.Name}, 
        {"phonetic",SearchTermName.Phonetic}, 
        {"identifier",SearchTermName.Identifier}, 
        {"page",SearchTermName.Page}
      };
    }

    public static Dictionary<string, Search.SearchTermTypes.SearchPrefixType> GetSearchPrefixTypeDictionary()
    {
      return new Dictionary<string, Search.SearchTermTypes.SearchPrefixType>()
      {
        {"ap", Search.SearchTermTypes.SearchPrefixType.Approximately},
        {"eb", Search.SearchTermTypes.SearchPrefixType.EndsBefore},
        {"eq", Search.SearchTermTypes.SearchPrefixType.Equal},
        {"gt", Search.SearchTermTypes.SearchPrefixType.Greater},
        {"ge", Search.SearchTermTypes.SearchPrefixType.GreaterOrEqual},
        {"lt", Search.SearchTermTypes.SearchPrefixType.Less},
        {"le", Search.SearchTermTypes.SearchPrefixType.LessOrEqual},
        {"ne", Search.SearchTermTypes.SearchPrefixType.NotEqual},
        {"sa", Search.SearchTermTypes.SearchPrefixType.StartsAfter}
      };
    }

    


  }
}
