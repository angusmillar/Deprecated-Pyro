using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface ITokenIndexSetter : IIndexSetter
  {
    TokenIndex SetCodeT(Element Element, TokenIndex TokenIndex);
    TokenIndex SetIdentifier(Identifier Identifier, TokenIndex TokenIndex);
    TokenIndex SetCode(Code Code, TokenIndex TokenIndex);
    TokenIndex SetCodeableConcept(CodeableConcept CodeableConcept, TokenIndex TokenIndex);
    TokenIndex SetCoding(Coding Coding, TokenIndex TokenIndex);
    TokenIndex SetFhirString(FhirString FhirString, TokenIndex TokenIndex);
    TokenIndex SetFhirBoolean(FhirBoolean FhirBoolean, TokenIndex TokenIndex);
    TokenIndex SetQuantity(Quantity Quantity, TokenIndex TokenIndex);
    TokenIndex SetRange(Range Range, TokenIndex TokenIndex);
    TokenIndex SetPositionComponent(Hl7.Fhir.Model.Location.PositionComponent PositionComponent, TokenIndex TokenIndex);
    TokenIndex SetId(Id Id, TokenIndex TokenIndex);
    TokenIndex SetContactPoint(ContactPoint ContactPoint, TokenIndex TokenIndex);
    TokenIndex SetFhirDateTime(FhirDateTime FhirDateTime, TokenIndex TokenIndex);
      
  }
}

