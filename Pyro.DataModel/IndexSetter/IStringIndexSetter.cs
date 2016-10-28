using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IStringIndexSetter : IIndexSetter
  {
    StringIndex SetFhirString(FhirString FhirString, StringIndex StringIndex);
    StringIndex SetMarkdown(Markdown Markdown, StringIndex StringIndex);
    StringIndex SetAnnotation(Annotation Annotation, StringIndex StringIndex);
    StringIndex SetAddress(Address Address, StringIndex StringIndex);
    StringIndex SetHumanName(HumanName HumanName, StringIndex StringIndex);
      
  }
}

