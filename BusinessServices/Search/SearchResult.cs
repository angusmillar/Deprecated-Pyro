using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Search
{
  public class SearchResult
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
    public Bundle FhirBundle { get; set; }

    public SearchResult()
    {
      this.ErrorMessageList = new List<string>();
    }
  }
}
