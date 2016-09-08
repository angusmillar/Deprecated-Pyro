using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDateTimeIndexSetter : IIndexSetter
  {
    DateTimeIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateTimeIndex DateTimeIndex);
    DateTimeIndex SetInstant(Instant Instant, DateTimeIndex DateTimeIndex);
    DateTimeIndex SetFhirString(FhirString FhirString, DateTimeIndex DateTimeIndex);
      
  }
}

