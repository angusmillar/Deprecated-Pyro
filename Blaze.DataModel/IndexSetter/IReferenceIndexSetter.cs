using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public interface IReferenceIndexSetter : IIndexSetter
  {    
    ReferenceIndex SetResourceReference(ResourceReference ResourceReference);
    ReferenceIndex SetResource(Resource Resource);
    ReferenceIndex SetFhirUri(FhirUri FhirUri);

  }
}

