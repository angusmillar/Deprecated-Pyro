using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Engine.Search
{
  public class SearchTerms
  {    
    public List<string> ErrorMessageList { get; set; }
    public bool HasError
    {
      get
      {
        if (this.ErrorMessageList.Count > 0)
          return true;
        else
          return false;
      }
    }
    public Hl7.Fhir.Model.ResourceType ResourceTarget { get; set; }
    public List<SearchTermTypes.SearchTermBase> SearchTermList { get; set; }    

    public SearchTerms()
    {
      this.ErrorMessageList = new List<string>();
    }
  }
}
