using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Search.SearchTermTypes
{
  public class SearchTermNumber : SearchTermBase
  {
    public SearchTermNumber() : base()
    {      
      this.SearchParameterType = SearchParamType.Number;
      
    }

    public override bool TryParseValue(string Value)
    {
      
      double TempDouble;
      List<double> TempDoubleList = new List<double>();
      foreach (var item in Value.Split(OrDelimiter))
      {
        if (Double.TryParse(Value, out TempDouble))
        {
          TempDoubleList.Add(TempDouble);          
        }
        else
        {
          return false;
        }
      }

      if (TempDoubleList.Count() > 1)
        this.HasLogicalOrProperties = true;      
      
      this.Values = TempDoubleList.ToArray();
      return true;
    }

    public double[] Values { get; set; }
  }
}
