using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository.Interfaces;
using Blaze.Common.Interfaces.UriSupport;


namespace Blaze.DataModel.IndexSetter
{
  public interface IIndexSetter
  {
    ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null);
  }
}
