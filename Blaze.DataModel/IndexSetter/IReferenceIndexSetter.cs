using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.Repository.Interfaces;

namespace Blaze.DataModel.IndexSetter
{
  public interface IReferenceIndexSetter : IIndexSetter
  {
    ReferenceIndex SetResourceReference(ResourceReference ResourceReference, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
    // ReferenceIndex SetResource(Resource Resource, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, CommonRepository CommonRepository);
    ReferenceIndex SetFhirUri(FhirUri FhirUri, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);

  }
}

