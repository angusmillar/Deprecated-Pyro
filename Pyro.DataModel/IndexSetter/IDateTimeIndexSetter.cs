using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IDateTimeIndexSetter : IIndexSetter
  {
    DateTimeIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateTimeIndex DateTimeIndex);
    DateTimeIndex SetInstant(Instant Instant, DateTimeIndex DateTimeIndex);
      
  }
}

