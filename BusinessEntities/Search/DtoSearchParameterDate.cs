using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace BusinessEntities.Search
{
  public class DtoSearchParameterDate : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterDate()
      : base()
    {      
      this.SearchParameterType = SearchParamType.Number;
    }
    #endregion

    public override bool TryParseValue(string Value)
    {
      DateTimeOffset DateTime;
      if (DateTimeOffset.TryParse(Value, out DateTime))
      {
        this.Value = DateTime;
        return true;
      }
      else
      {
        return false;
      }
    }

    public DateTimeOffset Value { get; set; }

  }
}
