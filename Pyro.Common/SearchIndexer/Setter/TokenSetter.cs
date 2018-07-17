using System;
using System.Collections.Generic;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class TokenSetter : ITokenSetter
  {
    private IServiceSearchParameterLight _SearchParameter;
    public TokenSetter() { }
    public IList<ITokenIndex> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      _SearchParameter = SearchParameter;

      var ResourceIndexList = new List<ITokenIndex>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Code Code)
        {
          SetCode(Code, ResourceIndexList);
        }
        else if (Poco.FhirValue is CodeableConcept CodeableConcept)
        {
          SetCodeableConcept(CodeableConcept, ResourceIndexList);
        }
        else if (Poco.FhirValue is Coding Coding)
        {
          SetCoding(Coding, ResourceIndexList);
        }
        else if (Poco.FhirValue.TypeName == "code")
        {
          if (Poco.Value is string CodeValue)
            SetCodeTypeT(CodeValue, ResourceIndexList);
        }
        else if (Poco.FhirValue is ContactPoint ContactPoint)
        {
          SetContactPoint(ContactPoint, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirBoolean FhirBoolean)
        {
          SetFhirBoolean(FhirBoolean, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetFhirDateTime(FhirDateTime, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Id Id)
        {
          SetId(Id, ResourceIndexList);
        }
        else if (Poco.FhirValue is Identifier Identifier)
        {
          SetIdentifier(Identifier, ResourceIndexList);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt(PositiveInt, ResourceIndexList);
        }
        else if (Poco.FhirValue is Quantity Quantity)
        {
          SetQuantity(Quantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange(Range, ResourceIndexList);
        }
        else if (Poco.FhirValue is Location.PositionComponent PositionComponent)
        {
          SePositionComponent(PositionComponent, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }        
        return ResourceIndexList;
      }
      else if (oElement.Value is Hl7.FhirPath.ConstantValue ConstantValue)
      {
        var FhirString = new FhirString(ConstantValue.ToString());
      }
      else if (oElement.Value is bool Bool)
      {
        var FhirBool = new FhirBoolean(Bool);
        SetFhirBoolean(FhirBool, ResourceIndexList);
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
      
      return ResourceIndexList;
    }

    private void SetCodeTypeT(string CodeValue, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(CodeValue))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = CodeValue;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SePositionComponent(Location.PositionComponent PositionComponent, IList<ITokenIndex> ResourceIndexList)
    {
      if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue && PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, string.Empty);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = string.Join(":", string.Empty, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetRange(Range range, IList<ITokenIndex> ResourceIndexList)
    {
      //There is no way to sensibly turn a Range into a Token type, so we just do nothing
      //and ignore setting the index. The reason this method is here is due to some search parameters
      //being a choice type where one of the choices is valid for token, like Boolean, yet others are 
      //not like Range as seen for the 'value' search parameter on the 'Group' resource .        
    }
    private void SetQuantity(Quantity Quantity, IList<ITokenIndex> ResourceIndexList)
    {
      if (Quantity.Value.HasValue && !string.IsNullOrWhiteSpace(Quantity.Unit))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Convert.ToString(Quantity.Value.Value);
        ResourceIndex.System = Quantity.Unit.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (Quantity.Value.HasValue)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Convert.ToString(Quantity.Value.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(Quantity.Unit))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = null;
        ResourceIndex.System = Quantity.Unit.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetPositiveInt(PositiveInt PositiveInt, IList<ITokenIndex> ResourceIndexList)
    {
      if (PositiveInt.Value.HasValue)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Convert.ToString(PositiveInt.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetIdentifier(Identifier Identifier, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Identifier.Value) && !string.IsNullOrWhiteSpace(Identifier.System))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Identifier.Value.Trim();
        ResourceIndex.System = Identifier.System.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(Identifier.Value))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Identifier.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(Identifier.System))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = null;
        ResourceIndex.System = Identifier.System.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetId(Id Id, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Id.Value))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Id.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirString(FhirString FhirString, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = FhirString.Value;
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirDateTime(FhirDateTime FhirDateTime, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirDateTime.Value))
      {
        if (Hl7.Fhir.Model.FhirDateTime.IsValidValue(FhirDateTime.Value))
        {
          var ResourceIndex = new TokenIndex(_SearchParameter);
          ResourceIndex.Code = FhirDateTime.Value;
          ResourceIndex.System = null;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetFhirBoolean(FhirBoolean FhirBoolean, IList<ITokenIndex> ResourceIndexList)
    {
      if (FhirBoolean.Value != null)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = FhirBoolean.Value.ToString().ToLower();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetContactPoint(ContactPoint ContactPoint, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(ContactPoint.Value) && (ContactPoint.System != null))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = ContactPoint.Value.Trim();
        ResourceIndex.System = ContactPoint.System.GetLiteral();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(ContactPoint.Value))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = ContactPoint.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (ContactPoint.System != null)
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = null;
        ResourceIndex.System = ContactPoint.System.GetLiteral();
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCoding(Coding Coding, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Coding.Code) && !string.IsNullOrWhiteSpace(Coding.System))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Coding.Code.Trim();
        ResourceIndex.System = Coding.System.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(Coding.Code))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Coding.Code.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (!string.IsNullOrWhiteSpace(Coding.System))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = null;
        ResourceIndex.System = Coding.System.Trim();
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCodeableConcept(CodeableConcept CodeableConcept, IList<ITokenIndex> ResourceIndexList)
    {
      if (CodeableConcept.Coding.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(CodeableConcept.Text))
        {
          var ResourceIndex = new TokenIndex(_SearchParameter);
          ResourceIndex.Code = CodeableConcept.Text;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
      else
      {
        foreach (Coding Code in CodeableConcept.Coding)
        {
          SetCoding(Code, ResourceIndexList);
        }
      }
    }
    private void SetCode(Code Code, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Code.Value))
      {
        var ResourceIndex = new TokenIndex(_SearchParameter);
        ResourceIndex.Code = Code.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
