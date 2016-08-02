using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository.Interfaces;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public interface IReferenceIndexSetter : IIndexSetter
  {
    ReferenceIndex SetResourceReference(ResourceReference ResourceReference, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
    ReferenceIndex SetFhirUri(FhirUri FhirUri, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
      
  }
}

