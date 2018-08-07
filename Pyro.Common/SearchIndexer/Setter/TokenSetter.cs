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
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, CodeValue));       
      }
    }
    private void SePositionComponent(Location.PositionComponent PositionComponent, IList<ITokenIndex> ResourceIndexList)
    {
      if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue && PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        string Code = string.Join(":", PositionComponent.Latitude.Value, PositionComponent.Longitude.Value);
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Code));       
      }
      else if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue)
      {
        string Code = string.Join(":", PositionComponent.Latitude.Value, string.Empty);
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Code));       
      }
      else if (PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        string Code = string.Join(":", string.Empty, PositionComponent.Longitude.Value);        
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Code));       
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
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Quantity.Unit, Convert.ToString(Quantity.Value.Value)));
      }
      else if (Quantity.Value.HasValue)
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Convert.ToString(Quantity.Value.Value)));
      }
      else if (!string.IsNullOrWhiteSpace(Quantity.Unit))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Quantity.Unit, null));       
      }
    }
    private void SetPositiveInt(PositiveInt PositiveInt, IList<ITokenIndex> ResourceIndexList)
    {
      if (PositiveInt.Value.HasValue)
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Convert.ToString(PositiveInt.Value)));
      }
    }
    private void SetIdentifier(Identifier Identifier, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Identifier.Value) && !string.IsNullOrWhiteSpace(Identifier.System))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Identifier.System, Identifier.Value));      
      }
      else if (!string.IsNullOrWhiteSpace(Identifier.Value))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Identifier.Value));
      }
      else if (!string.IsNullOrWhiteSpace(Identifier.System))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Identifier.System, null));       
      }
    }
    private void SetId(Id Id, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Id.Value))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Id.Value));       
      }
    }
    private void SetFhirString(FhirString FhirString, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, FhirString.Value));        
      }
    }
    private void SetFhirDateTime(FhirDateTime FhirDateTime, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirDateTime.Value))
      {
        if (Hl7.Fhir.Model.FhirDateTime.IsValidValue(FhirDateTime.Value))
        {
          ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, FhirDateTime.Value));          
        }
      }
    }
    private void SetFhirBoolean(FhirBoolean FhirBoolean, IList<ITokenIndex> ResourceIndexList)
    {
      if (FhirBoolean.Value != null)
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, FhirBoolean.Value.ToString()));        
      }
    }
    private void SetContactPoint(ContactPoint ContactPoint, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(ContactPoint.Value) && (ContactPoint.System != null))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(ContactPoint.System.GetLiteral(), ContactPoint.Value));       
      }
      else if (!string.IsNullOrWhiteSpace(ContactPoint.Value))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, ContactPoint.Value));       
      }
      else if (ContactPoint.System != null)
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(ContactPoint.System.GetLiteral(), null));       
      }
    }
    private void SetCoding(Coding Coding, IList<ITokenIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Coding.Code) && !string.IsNullOrWhiteSpace(Coding.System))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Coding.System, Coding.Code));       
      }
      else if (!string.IsNullOrWhiteSpace(Coding.Code))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Coding.Code));       
      }
      else if (!string.IsNullOrWhiteSpace(Coding.System))
      {
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(Coding.System, null));       
      }
    }
    private void SetCodeableConcept(CodeableConcept CodeableConcept, IList<ITokenIndex> ResourceIndexList)
    {
      if (CodeableConcept.Coding.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(CodeableConcept.Text))
        {
          ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, CodeableConcept.Text));          
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
        ResourceIndexList.Add(SetTokenIndexToLowerCaseTrim(null, Code.Value));
      }
    }


    private TokenIndex SetTokenIndexToLowerCaseTrim(string System, string Code)
    {
      var ResourceIndex = new TokenIndex(_SearchParameter);
      if (!string.IsNullOrWhiteSpace(System))
        ResourceIndex.System = Tools.StringSupport.ToLowerFast(System.Trim());

      if (!string.IsNullOrWhiteSpace(Code))
        ResourceIndex.Code = Tools.StringSupport.ToLowerFast(Code.Trim());

      return ResourceIndex;
    }
  }
}
