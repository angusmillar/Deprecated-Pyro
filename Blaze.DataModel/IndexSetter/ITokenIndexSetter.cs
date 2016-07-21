using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface ITokenIndexSetter : IIndexSetter
  {
        TokenIndex SetIdentifier(Identifier Identifier, TokenIndex TokenIndex);
        TokenIndex SetCode(Code Code, TokenIndex TokenIndex);
        TokenIndex SetCodeableConcept(CodeableConcept CodeableConcept, TokenIndex TokenIndex);
        TokenIndex SetCoding(Coding Coding, TokenIndex TokenIndex);
        TokenIndex SetFhirString(FhirString FhirString, TokenIndex TokenIndex);
        TokenIndex SetPositiveInt(PositiveInt PositiveInt, TokenIndex TokenIndex);
        TokenIndex SetFhirBoolean(FhirBoolean FhirBoolean, TokenIndex TokenIndex);
        TokenIndex SetQuantity(Quantity Quantity, TokenIndex TokenIndex);
        QuantityRangeIndex SetRange(Range Range, QuantityRangeIndex QuantityRangeIndex);
        //TokenIndex SetPositionComponent(PositionComponent PositionComponent, TokenIndex TokenIndex);
        TokenIndex SetId(Id Id, TokenIndex TokenIndex);
        TokenIndex SetContactPoint(ContactPoint ContactPoint, TokenIndex TokenIndex);
        TokenIndex SetFhirDateTime(FhirDateTime FhirDateTime, TokenIndex TokenIndex);
      
  }
}

