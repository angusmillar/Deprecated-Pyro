using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search
{
  public class CustomSearchParams : Hl7.Fhir.Rest.SearchParams
  {
    public CustomSearchParams()
    {
      this.Sort = new List<Tuple<string, SortOrder>>();
    }

    public new IList<Tuple<string, SortOrder>> Sort { get; private set; }

    public CustomSearchParams AddSort(string name, string value)
    {
        if (String.IsNullOrEmpty(value))
          throw new FormatException($"Invalid {SEARCH_PARAM_SORT}: value cannot be empty");
        var elements = value.Split(',');
        if (elements.Any(f => String.IsNullOrEmpty(f)))
          throw new FormatException($"Invalid {SEARCH_PARAM_SORT}: must be a list of non-empty element names");
        if (!elements.All(f => Char.IsLetter(f[0]) || f[0] == '-' || f[0] == '_'))
        throw new FormatException($"Invalid {SEARCH_PARAM_SORT}: must be a list of element names, optionally prefixed with '-'");


        addNonEmptySort(elements);

      return this;
    }

    public new static CustomSearchParams FromUriParamList(IEnumerable<Tuple<string, string>> parameters)
    {
      var result = new CustomSearchParams();

      foreach (var parameter in parameters)
      {
        string name = parameter.Item1;
        string value = parameter.Item2;

        if (name == SEARCH_PARAM_SORT)
        {
          result.AddSort(name, value);     
        }
        else
        {
          result.Add(name, value);
        }
      }      
      return result;
    }

    private void addNonEmptySort(string[] elements)
    {
      foreach (var e in elements)
      {
        var newTuple = e[0] == '-' ? Tuple.Create(e.Substring(1), SortOrder.Descending) :
                    Tuple.Create(e, SortOrder.Ascending);
        Sort.Add(newTuple);
      }
    }

  }
}
