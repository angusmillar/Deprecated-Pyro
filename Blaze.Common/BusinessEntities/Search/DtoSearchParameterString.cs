using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterString : DtoSearchParameterBase
  {
     #region Constructor
    public DtoSearchParameterString()
      : base()
    {      
      this.SearchParameterType = SearchParamType.String;      
    }
    #endregion
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
