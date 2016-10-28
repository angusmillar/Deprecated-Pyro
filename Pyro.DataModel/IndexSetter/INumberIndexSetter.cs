using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface INumberIndexSetter : IIndexSetter
  {
    NumberIndex SetPositiveInt(PositiveInt PositiveInt, NumberIndex NumberIndex);
    NumberIndex SetDuration(Duration Duration, NumberIndex NumberIndex);
    NumberIndex SetInteger(Integer Integer, NumberIndex NumberIndex);
      
  }
}

