using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IDateIndexSetter : IIndexSetter
  {
    DateIndex SetDate(Date Date, DateIndex DateIndex);
      
  }
}

