using System.Collections.Generic;
using Hl7.Fhir.ElementModel;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Setter
{
  public interface IDateTimeSetter
  {
    IList<IDateTimeIndex> Set(ITypedElement oElement, IServiceSearchParameterLight SearchParameter);
  }
}