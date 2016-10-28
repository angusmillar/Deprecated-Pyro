using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository.Interfaces;
using Pyro.Common.Interfaces.UriSupport;


namespace Pyro.DataModel.IndexSetter
{
  public interface IIndexSetter
  {
    ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null);
  }
}
