using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Common.BusinessEntities.Dto
{
  public static class DtoEnums
  {
    public enum CrudOperationType { None, Create, Read, Update, Delete };


    //If you add a SearchParameterName here then you also need to add it to the Dictionary below it: "GetSearchParameterNameDictionary"
    public static class Search
    {
      public enum SearchParameterName
      {
        None,
        _Id,
        Active,
        Family,
        Given,
        Name,
        Phonetic,
        Identifier,
        Page,
        Description,
        Code,
        Date,
        Context
      };


      public static Dictionary<string, SearchParameterName> GetSearchParameterNameDictionary()
      {        
        return new Dictionary<string, SearchParameterName>()
      {
        {"_id", SearchParameterName._Id},
        {"active",SearchParameterName.Active},
        {"family",SearchParameterName.Family},
        {"given",SearchParameterName.Given},        
        {"name",SearchParameterName.Name}, 
        {"phonetic",SearchParameterName.Phonetic}, 
        {"identifier",SearchParameterName.Identifier}, 
        {"page",SearchParameterName.Page},
        {"description",SearchParameterName.Description},
        {"code",SearchParameterName.Code},
        {"date",SearchParameterName.Date},
        {"context",SearchParameterName.Context}
      };
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


    }
  }
}
