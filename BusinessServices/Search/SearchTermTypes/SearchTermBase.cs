using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Hl7.Fhir.Model;

//string input = @"aaa;bb;cccc\;dd\;eee\\;ff\\;ggg\\\;hhh";
//var res = Regex.Split (input, @"(?<!($|[^\\])(\\\\)*?\\);");

namespace Blaze.Engine.Search.SearchTermTypes
{
  public enum SearchPrefixType { None, Equal, NotEqual, Greater, Less, GreaterOrEqual, LessOrEqual, StartsAfter, EndsBefore, Approximately }
  public enum SearchModifierType { None, Missing, Exact, Contains, Text, Type, Below, Above, In, NotIn }
  
  public abstract class SearchTermBase
  {
    protected const char OrDelimiter = ',';

    public Support.EnumSupport.SearchTermName Name { get; set; }
    public ResourceType Resource { get; set; }
    public string RawValue { get; set; }

    //Change from re-base DSTU2.1
    //public SearchParamType SearchParameterType { get; set; }
    public SearchParamType SearchParameterType { get; set; }

    public SearchModifierType Modifier { get; set; }
    public ResourceType? TypeModifierResource { get; set; }
    public SearchPrefixType Prefix { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public abstract bool TryParseValue(string Value);

    public SearchTermBase()
    {
      this.HasLogicalOrProperties = false;
    }

    public static SearchTermBase CreateSearchTerm(ResourceType Resource, Support.EnumSupport.SearchTermName SearchTermName,
                  Tuple<string, string> Parameter,
                  SearchParamType SearchParameterType)
    {
      SearchTermBase oSearchTerm = InitalizeSearchTerm(SearchParameterType);
      oSearchTerm.Resource = Resource;
      oSearchTerm.Name = SearchTermName;
      oSearchTerm.RawValue = Parameter.Item1 + '=' + Parameter.Item2;
      oSearchTerm.SearchParameterType = SearchParameterType;
      ParseModifier(Parameter.Item1, oSearchTerm);
      string Value = ParsePrefix(Parameter.Item2, oSearchTerm);
      if (!oSearchTerm.TryParseValue(Value))
        throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.Forbidden, "unable to parse the given search parameter value for parameter = value: " + oSearchTerm.RawValue);
      return oSearchTerm;
    }

    private static void ParseModifierType(SearchTermBase SearchTerm, string value)
    {
      switch (value)
      {
        case "above":
          SearchTerm.Modifier = SearchModifierType.Above;
          break;
        case "below":
          SearchTerm.Modifier = SearchModifierType.Below;
          break;
        case "contains":
          SearchTerm.Modifier = SearchModifierType.Contains;
          break;
        case "exact":
          SearchTerm.Modifier = SearchModifierType.Exact;
          break;
        case "in":
          SearchTerm.Modifier = SearchModifierType.In;
          break;
        case "missing":
          SearchTerm.Modifier = SearchModifierType.Missing;
          break;
        case "notin":
          SearchTerm.Modifier = SearchModifierType.NotIn;
          break;
        case "text":
          SearchTerm.Modifier = SearchModifierType.Text;
          break;
        default:
          {
            if (value.Contains('[') && value.Contains(']'))
            {
              char[] delimiters = { '[', ']' };
              var ResourceName = value.Split(delimiters)[1];
              if (ModelInfo.IsKnownResource(ResourceName))
              {
                var ResourceTypeDictionary = Support.EnumSupport.GetResourceTypeDictionary();
                if (ResourceTypeDictionary.ContainsKey(ResourceName))
                  SearchTerm.Resource = ResourceTypeDictionary[(ResourceName)];
              }
              SearchTerm.Modifier = SearchModifierType.Type;
            }
            else
              SearchTerm.Modifier = SearchModifierType.None;
          }
          break;
      }
    }
    private static SearchTermBase InitalizeSearchTerm(SearchParamType SearchParameterType)
    {
      SearchTermBase oSearchTerm = null;
      switch (SearchParameterType)
      {
        case SearchParamType.Composite:
          break;
        case SearchParamType.Date:
          break;
        case SearchParamType.Number:
          oSearchTerm = new SearchTermNumber();
          break;
        case SearchParamType.Quantity:
          break;
        case SearchParamType.Reference:
          break;
        case SearchParamType.String:
          oSearchTerm = new SearchTermString();
          break;
        case SearchParamType.Token:
          break;
        case SearchParamType.Uri:
          break;
        default:
          break;
      }
      return oSearchTerm;
    }
    private static void ParseModifier(string Name, SearchTermBase oSearchTerm)
    {
      if (Name.Contains(':'))
      {
        ParseModifierType(oSearchTerm, Name.Split(':')[1]);
      }
      else
      {
        oSearchTerm.Modifier = SearchModifierType.None;
        oSearchTerm.TypeModifierResource = null;
      }
    }
    private static string ParsePrefix(string Value, SearchTermBase oSearchTerm)
    {
      if (oSearchTerm.SearchParameterType == SearchParamType.Date ||
        oSearchTerm.SearchParameterType == SearchParamType.Number ||
        oSearchTerm.SearchParameterType == SearchParamType.Quantity)
      {
        if (Value.Length > 2)
        {
          //Are the first two char Alpha characters 
          if (Regex.IsMatch(Value.Substring(0, 2), @"^[a-zA-Z]+$"))
          {
            var SearchPrefixTypeDictionary = Support.EnumSupport.GetSearchPrefixTypeDictionary();
            if (SearchPrefixTypeDictionary.ContainsKey(Value.Substring(0, 2)))
            {
              oSearchTerm.Prefix = SearchPrefixTypeDictionary[Value.Substring(0, 2)];
              Value = Value.Substring(2);
            }
          }
          else
          {
            oSearchTerm.Prefix = SearchPrefixType.None;
          }
        }
      }
      return Value;
    }

  }
}
