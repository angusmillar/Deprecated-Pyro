using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface ITokenIndexSetter : IIndexSetter
  {
    TokenIndex SetIdentifier(Identifier Identifier);
    TokenIndex SetCode(Code Code);
    TokenIndex SetCodeableConcept(CodeableConcept CodeableConcept);
    TokenIndex SetCoding(Coding Coding);
    TokenIndex SetFhirString(FhirString FhirString);
    TokenIndex SetPositiveInt(PositiveInt PositiveInt);
    TokenIndex SetFhirBoolean(FhirBoolean FhirBoolean);
    TokenIndex SetQuantity(Quantity Quantity);
    TokenIndex SetRange(Range Range);
    //TokenIndex SetPositionComponent(PositionComponent PositionComponent);
    TokenIndex SetId(Id Id);
    TokenIndex SetContactPoint(ContactPoint ContactPoint);
    TokenIndex SetFhirDateTime(FhirDateTime FhirDateTime);

  }
}

