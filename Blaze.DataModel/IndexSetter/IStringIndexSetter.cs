using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IStringIndexSetter : IIndexSetter
  {
    	  StringIndex SetFhirString(FhirString FhirString);
	  	  StringIndex SetMarkdown(Markdown Markdown);
	  	  StringIndex SetAnnotation(Annotation Annotation);
	  	  StringIndex SetAddress(Address Address);
	  	  StringIndex SetHumanName(HumanName HumanName);
	    
  }
}

