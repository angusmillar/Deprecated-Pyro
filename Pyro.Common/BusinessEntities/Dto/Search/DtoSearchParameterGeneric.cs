using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;


namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterGeneric : IDtoSearchParameterGeneric
  {
    public IList<Tuple<string, string>> ParameterList { get; set; }
    public IList<Tuple<string, Hl7.Fhir.Rest.SortOrder>> Sort { get; }
    public int? Count { get; private set; }

    public DtoSearchParameterGeneric() { }
    public DtoSearchParameterGeneric(Hl7.Fhir.Rest.SearchParams SearchParams)
    {
      this.ParameterList = SearchParams.Parameters;
      this.Sort = SearchParams.Sort;
      this.Count = SearchParams.Count;

    }

    public DtoSearchParameterGeneric(string SearchParameterString)
    {
      if (SearchParameterString.Contains("?"))
      {
        SearchParameterString = SearchParameterString.Split('?')[1];
      }
            
      var ValuePairList = System.Web.HttpUtility.ParseQueryString(SearchParameterString);
      this.ParameterList = new List<Tuple<string, string>>();
      
      foreach (string Key in ValuePairList.AllKeys)
      {
        this.ParameterList.Add(new Tuple<string, string>(Key, ValuePairList[Key]));
      }
      
      this.Sort = null;
      this.Count = ValuePairList.Count;

    }
  }
}
