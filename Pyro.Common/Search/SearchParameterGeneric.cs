using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;

namespace Pyro.Common.Search
{
  public class SearchParameterGeneric : ISearchParameterGeneric
  {
    public IList<Tuple<string, string>> ParameterList { get; set; }
    public IList<Tuple<string, Hl7.Fhir.Rest.SortOrder>> Sort { get; private set; }
    public int? Count { get; private set; }
    public SummaryType? SummaryType { get; private set; }
    public IList<Tuple<string, string>> Include { get; set; }
    public IList<Tuple<string, string>> RevInclude { get; set; }

    public SearchParameterGeneric() { }
    public ISearchParameterGeneric Parse(Hl7.Fhir.Rest.SearchParams SearchParams)
    {
      this.ParameterList = new List<Tuple<string, string>>();

      //We need to go through the SearchParams.Parameters and pull out the 
      //includes. This is because the API correctly pulls out the normal '_includes'
      //into it's set property yet '_includes:recurse' incorrectly are placed in the 
      //SearchParams.Parameters list.

      if (SearchParams.Include != null && SearchParams.Include.Count > 0)
      {
        if (this.Include == null)
          this.Include = new List<Tuple<string, string>>();
        foreach (var Inc in SearchParams.Include)
        {
          this.Include.Add(new Tuple<string, string>(SearchParams.SEARCH_PARAM_INCLUDE, Inc.Trim()));
        }
      }

      if (SearchParams.RevInclude != null && SearchParams.RevInclude.Count > 0)
      {
        if (this.RevInclude == null)
          this.RevInclude = new List<Tuple<string, string>>();
        foreach (var Inc in SearchParams.RevInclude)
        {
          this.RevInclude.Add(new Tuple<string, string>(SearchParams.SEARCH_PARAM_REVINCLUDE, Inc.Trim()));
        }
      }



      foreach (var Para in SearchParams.Parameters)
      {
        bool IsNoramlParameter = true;
        if (ParseIncludeSearchParameters(Para.Item1, Para.Item2) != null)
        {
          if (this.Include == null)
            this.Include = new List<Tuple<string, string>>();
          this.Include.Add(ParseIncludeSearchParameters(Para.Item1, Para.Item2));
          IsNoramlParameter = false;
        }

        if (ParseRevIncludeSearchParameters(Para.Item1, Para.Item2) != null)
        {
          if (this.RevInclude == null)
            this.RevInclude = new List<Tuple<string, string>>();
          this.RevInclude.Add(ParseRevIncludeSearchParameters(Para.Item1, Para.Item2));
          IsNoramlParameter = false;
        }
        //Add parameters left to the main search parameter list
        if (IsNoramlParameter)
          this.ParameterList.Add(Para);
      }

      this.Sort = SearchParams.Sort;
      this.Count = SearchParams.Count;
      this.SummaryType = SearchParams.Summary;
      return this;
    }
    public ISearchParameterGeneric Parse(string SearchParameterString)
    {
      this.ParameterList = new List<Tuple<string, string>>();
      if (!string.IsNullOrWhiteSpace(SearchParameterString))
      {
        if (SearchParameterString.Contains("?"))
        {
          SearchParameterString = SearchParameterString.Split('?')[1];
        }

        var DecodeURl = System.Web.HttpUtility.UrlDecode(SearchParameterString);
        foreach (string SerachItem in DecodeURl.Split('&'))
        {
          var SearchValueArray = SerachItem.Split('=');
          if (SearchValueArray.Count() == 2)
          {
            //Check for _count, will always only use the last if many.
            if (SearchValueArray[0].ToLower().Trim() == SearchParams.SEARCH_PARAM_COUNT)
            {
              int CountInt;
              if (int.TryParse(SearchValueArray[1].Trim(), out CountInt))
              {
                this.Count = CountInt;
              }
              else
              {
                this.Count = null;
              }
            }
            else if (ParseIncludeSearchParameters(SearchValueArray[0], SearchValueArray[1]) != null)
            {
              this.Include.Add(ParseIncludeSearchParameters(SearchValueArray[0], SearchValueArray[1]));
            }
            else if (ParseRevIncludeSearchParameters(SearchValueArray[0], SearchValueArray[1]) != null)
            {
              this.RevInclude.Add(ParseRevIncludeSearchParameters(SearchValueArray[0], SearchValueArray[1]));
            }
            else if (SearchValueArray[0].ToLower().Trim() == SearchParams.SEARCH_PARAM_SORT)
            {
              //ToDo: need to parse out the sort string?
              this.Sort = null;
            }
            else if (SearchValueArray[0].ToLower().Trim() == SearchParams.SEARCH_PARAM_SUMMARY)
            {
              string SummaryValue = SearchValueArray[1].ToLower().Trim();
              if (SummaryValue == Hl7.Fhir.Rest.SummaryType.True.GetLiteral())
              {
                this.SummaryType = Hl7.Fhir.Rest.SummaryType.True;
              }
              else if (SummaryValue == Hl7.Fhir.Rest.SummaryType.Count.GetLiteral())
              {
                this.SummaryType = Hl7.Fhir.Rest.SummaryType.Count;
              }
              else if (SummaryValue == Hl7.Fhir.Rest.SummaryType.Data.GetLiteral())
              {
                this.SummaryType = Hl7.Fhir.Rest.SummaryType.Data;
              }
              else if (SummaryValue == Hl7.Fhir.Rest.SummaryType.False.GetLiteral())
              {
                this.SummaryType = Hl7.Fhir.Rest.SummaryType.False;
              }
              else if (SummaryValue == Hl7.Fhir.Rest.SummaryType.Text.GetLiteral())
              {
                this.SummaryType = Hl7.Fhir.Rest.SummaryType.Text;
              }
              else
              {
                this.SummaryType = null;
              }
            }
            else
            {
              this.ParameterList.Add(new Tuple<string, string>(SearchValueArray[0].Trim(), SearchValueArray[1].Trim()));
            }
          }
        }
      }
      return this;
    }

    private Tuple<string, string> ParseIncludeSearchParameters(string Key, string Value)
    {
      if (Key.ToLower().Trim() == SearchParams.SEARCH_PARAM_INCLUDE ||
          Key.ToLower().Trim() == $"{SearchParams.SEARCH_PARAM_INCLUDE}:recurse")
      {
        //Check for _include, will capture all
        if (this.Include == null)
          this.Include = new List<Tuple<string, string>>();
        return new Tuple<string, string>(Key.Trim(), Value.Trim());
      }
      return null;
    }

    private Tuple<string, string> ParseRevIncludeSearchParameters(string Key, string Value)
    {
      if (Key.ToLower().Trim() == SearchParams.SEARCH_PARAM_REVINCLUDE ||
        Key.ToLower().Trim() == $"{SearchParams.SEARCH_PARAM_REVINCLUDE}:recurse")
      {
        //Check for _RevInclude, will capture all
        if (this.RevInclude == null)
          this.RevInclude = new List<Tuple<string, string>>();
        return new Tuple<string, string>(Key.Trim(), Value.Trim());
      }
      return null;
    }

  }
}
