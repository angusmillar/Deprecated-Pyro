using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Search.SearchTermTypes;

namespace Blaze.Engine.Search
{
  class SearchUriValidator
  {
    public static SearchTerms Validate(ResourceType ResourceType, SearchParams SearchParameter)
    {
      var Result = new SearchTerms();
      Result.ResourceTarget = ResourceType;      
      ParseToSupportedSearchTerms(SearchParameter, Result);
      return Result;
    }

    private static void ParseToSupportedSearchTerms(SearchParams SearchParameter, SearchTerms Result)
    {
      var oInboundSearchTermList = new List<SearchTermBase>();
      var oSupportedSearchTermList = Search.SupportedSearchTerm.GetSupportedTermList(Result.ResourceTarget);
      var oSearchTermNameDictionary = Support.EnumSupport.GetSearchTermNameDictionary();

      foreach (var Parameter in SearchParameter.Parameters)
      {
        var SearchTermName = Support.EnumSupport.SearchTermName.None;
        var SearchParameterName = Parameter.Item1.Split(':')[0];
        if (oSearchTermNameDictionary.ContainsKey(SearchParameterName))
        {
          SearchTermName = oSearchTermNameDictionary[SearchParameterName];

          var oSupportedSearchTerm = oSupportedSearchTermList.SingleOrDefault(x => x.Name == SearchTermName);
          if (oSupportedSearchTerm != null)
          {
            var oSearchTerm = SearchTermBase.CreateSearchTerm(oSupportedSearchTerm.Resource, SearchTermName, Parameter, oSupportedSearchTerm.SearchParameterType);
            ValidateSearchTermSupported(oSupportedSearchTerm, oSearchTerm, Result.ErrorMessageList);
            oInboundSearchTermList.Add(oSearchTerm);
          }
          else
          {
            Result.ErrorMessageList.Add(String.Format("Unsupported search Term for the resource '{0}' found in URL, term was: {1}={2}", Result.ResourceTarget.ToString(), Parameter.Item1, Parameter.Item2));
          }
        }
        else
        {
          Result.ErrorMessageList.Add(String.Format("Unsupported search Term found in URL, term was: {0}={1}", Parameter.Item1, Parameter.Item2));
        }
      }

      Result.SearchTermList = oInboundSearchTermList;
    }
    private static List<string> ValidateSearchTermSupported(SupportedSearchTerm oSupported, SearchTermBase oInboundSearch, List<string> ErrorMessageList)
    {
      if (oInboundSearch.Modifier != SearchModifierType.None)
      {
        if (!oSupported.ModifierList.Contains(oInboundSearch.Modifier))
        {
          ErrorMessageList.Add(String.Format("Unsupported search Modifier found in URL, Modifier was: '{0}' in parameter '{1}'.", oInboundSearch.Modifier.ToString(), oInboundSearch.RawValue));
        }
      }

      if (oInboundSearch.Prefix != SearchPrefixType.None)
      {
        if (!oSupported.PrefixList.Contains(oInboundSearch.Prefix))
        {
          ErrorMessageList.Add(String.Format("Unsupported search Prefix found in URL, Prefix was: '{0}' in parameter '{1}'.", oInboundSearch.Prefix.ToString(), oInboundSearch.RawValue));
        }
      }

      if (oInboundSearch.TypeModifierResource != null)
      {
        if (oSupported.TypeModifierResourceList.Contains((Hl7.Fhir.Model.ResourceType)oInboundSearch.TypeModifierResource))
        {
          ErrorMessageList.Add(String.Format("Unsupported search, the 'Resource' type found in the 'Type[]' Modifier is not supported. 'Resource' type was: '{0}' in parameter '{1}'.", oInboundSearch.TypeModifierResource.ToString(), oInboundSearch.RawValue));
        }
      }

      return ErrorMessageList;
    }
  }
}
