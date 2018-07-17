using System.Collections.Generic;
using Hl7.Fhir.ElementModel;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Setter
{
  public interface IReferenceSetter
  {
    IList<IReferenceIndex> Set(IElementNavigator oElement, IServiceSearchParameterLight SearchParameter);
  }
}