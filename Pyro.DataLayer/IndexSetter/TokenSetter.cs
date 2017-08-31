using System;
using System.Collections.Generic;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;

namespace Pyro.DataLayer.IndexSetter
{
  public class TokenSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    ITokenSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    public TokenSetter() { }
    public IList<ResourceIndexBaseType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
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
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
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
      ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
      return ResourceIndexList;
    }

    private void SetCodeTypeT(string CodeValue, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(CodeValue))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = CodeValue;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SePositionComponent(Location.PositionComponent PositionComponent, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue && PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, string.Empty);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = string.Join(":", string.Empty, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetRange(Range range, List<ResourceIndexBaseType> ResourceIndexList)
    {
      //There is no way to sensibly turn a Range into a Token type, so we just do nothing
      //and ignore setting the index. The reason this method is here is due to some search parameters
      //being a choice type where one of the choices is valid for token, like Boolean, yet others are 
      //not like Range as seen for the 'value' search parameter on the 'Group' resource .        
    }
    private void SetQuantity(Quantity Quantity, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (Quantity.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Convert.ToString(Quantity.Value.Value);
        if (!string.IsNullOrWhiteSpace(Quantity.Unit))
        {
          ResourceIndex.System = Quantity.Unit.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetPositiveInt(PositiveInt PositiveInt, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (PositiveInt.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Convert.ToString(PositiveInt.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetIdentifier(Identifier Identifier, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Identifier.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Identifier.Value.Trim();
        if (!string.IsNullOrWhiteSpace(Identifier.System))
        {
          ResourceIndex.System = Identifier.System.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetId(Id Id, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Id.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Id.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirString(FhirString FhirString, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = FhirString.Value;
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirDateTime(FhirDateTime FhirDateTime, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirDateTime.Value))
      {
        if (Hl7.Fhir.Model.FhirDateTime.IsValidValue(FhirDateTime.Value))
        {
          var ResourceIndex = new ResourceIndexBaseType();
          ResourceIndex.Code = FhirDateTime.Value;
          ResourceIndex.System = null;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetFhirBoolean(FhirBoolean FhirBoolean, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (FhirBoolean.Value != null)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = FhirBoolean.Value.ToString().ToLower();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetContactPoint(ContactPoint ContactPoint, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(ContactPoint.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = ContactPoint.Value.Trim();
        if (ContactPoint.System != null)
        {
          ResourceIndex.System = ContactPoint.System.GetLiteral();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCoding(Coding Coding, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Coding.Code))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Coding.Code.Trim();
        if (!string.IsNullOrWhiteSpace(Coding.System))
        {
          ResourceIndex.System = Coding.System.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCodeableConcept(CodeableConcept CodeableConcept, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (CodeableConcept.Coding.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(CodeableConcept.Text))
        {
          var ResourceIndex = new ResourceIndexBaseType();
          ResourceIndex.Code = CodeableConcept.Text;
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
    private void SetCode(Code Code, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Code.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Code = Code.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
