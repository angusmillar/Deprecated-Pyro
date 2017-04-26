using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IStringIndexSetter : IIndexSetter
  {
    StringIndex SetFhirString(FhirString FhirString, StringIndex StringIndex);
    StringIndex SetMarkdown(Markdown Markdown, StringIndex StringIndex);
    StringIndex SetAddress(Address Address, StringIndex StringIndex);
    StringIndex SetHumanName(HumanName HumanName, StringIndex StringIndex);
      
  }
}

