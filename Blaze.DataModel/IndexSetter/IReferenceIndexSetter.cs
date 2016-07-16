using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IReferenceIndexSetter : IIndexSetter
  {
    	  ReferenceIndex SetResourceReference(ResourceReference ResourceReference);
	  	  ReferenceIndex SetResource(Resource Resource);
	  	  ReferenceIndex SetFhirUri(FhirUri FhirUri);
	    
  }
}

