using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDateIndexSetter : IIndexSetter
  {
        DateIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateIndex DateIndex);
        DateIndex SetInstant(Instant Instant, DateIndex DateIndex);
        DateIndex SetDate(Date Date, DateIndex DateIndex);
        DateIndex SetFhirString(FhirString FhirString, DateIndex DateIndex);
      
  }
}

