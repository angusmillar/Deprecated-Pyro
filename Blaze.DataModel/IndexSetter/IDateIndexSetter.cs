using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDateIndexSetter : IIndexSetter
  {
    DateIndex SetDate(Date Date, DateIndex DateIndex);
      
  }
}

