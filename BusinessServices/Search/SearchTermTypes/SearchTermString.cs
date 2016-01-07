using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Search.SearchTermTypes
{
  public class SearchTermString : SearchTermBase
  {    
    public SearchTermString()
    {
      this.SearchParameterType = Conformance.SearchParamType.String;
    }
    
    public override bool TryParseValue(string Value)
    {
      this.Values = Value.Split(OrDelimiter);
      if (this.Values.Count() > 1)
        this.HasLogicalOrProperties = true;
      return true;
    }
    public string[] Values { get; set; }
  }
}
