using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository.Interfaces;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.DataModel.IndexSetter
{
  public interface IReferenceIndexSetter : IIndexSetter
  {
    ReferenceIndex SetResourceReference(ResourceReference ResourceReference, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
    ReferenceIndex SetFhirUri(FhirUri FhirUri, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
    ReferenceIndex SetAttachment(Attachment Attachment, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
    ReferenceIndex SetIdentifier(Identifier Identifier, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository);
      
  }
}

