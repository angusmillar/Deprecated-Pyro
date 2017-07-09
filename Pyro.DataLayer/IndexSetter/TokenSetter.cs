using System;
using System.Collections.Generic;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.DataLayer.IndexSetter
{
  public class TokenSetter : ITokenSetter
  {
    public TokenSetter() { }
    public IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Code Code)
        {
          SetCode<ResourceCurrentType, ResourceIndexType>(Code, ResourceIndexList);
        }
        else if (Poco.FhirValue is CodeableConcept CodeableConcept)
        {
          SetCodeableConcept<ResourceCurrentType, ResourceIndexType>(CodeableConcept, ResourceIndexList);
        }
        else if (Poco.FhirValue is Coding Coding)
        {
          SetCoding<ResourceCurrentType, ResourceIndexType>(Coding, ResourceIndexList);
        }
        else if (Poco.FhirValue.TypeName == "code")
        {
          if (Poco.Value is string CodeValue)
            SetCodeTypeT<ResourceCurrentType, ResourceIndexType>(CodeValue, ResourceIndexList);
        }
        else if (Poco.FhirValue is ContactPoint ContactPoint)
        {
          SetContactPoint<ResourceCurrentType, ResourceIndexType>(ContactPoint, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirBoolean FhirBoolean)
        {
          SetFhirBoolean<ResourceCurrentType, ResourceIndexType>(FhirBoolean, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetFhirDateTime<ResourceCurrentType, ResourceIndexType>(FhirDateTime, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString<ResourceCurrentType, ResourceIndexType>(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Id Id)
        {
          SetId<ResourceCurrentType, ResourceIndexType>(Id, ResourceIndexList);
        }
        else if (Poco.FhirValue is Identifier Identifier)
        {
          SetIdentifier<ResourceCurrentType, ResourceIndexType>(Identifier, ResourceIndexList);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt<ResourceCurrentType, ResourceIndexType>(PositiveInt, ResourceIndexList);
        }
        else if (Poco.FhirValue is Quantity Quantity)
        {
          SetQuantity<ResourceCurrentType, ResourceIndexType>(Quantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange<ResourceCurrentType, ResourceIndexType>(Range, ResourceIndexList);
        }
        else if (Poco.FhirValue is Location.PositionComponent PositionComponent)
        {
          SePositionComponent<ResourceCurrentType, ResourceIndexType>(PositionComponent, ResourceIndexList);
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
        SetFhirBoolean<ResourceCurrentType, ResourceIndexType>(FhirBool, ResourceIndexList);
      }
      else
      {
        throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
      ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
      return ResourceIndexList;
    }

    private void SetCodeTypeT<ResourceCurrentType, ResourceIndexType>(string CodeValue, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(CodeValue))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = CodeValue;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SePositionComponent<ResourceCurrentType, ResourceIndexType>(Location.PositionComponent PositionComponent, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue && PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Latitude != null && PositionComponent.Latitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = string.Join(":", PositionComponent.Latitude.Value, string.Empty);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (PositionComponent.Longitude != null && PositionComponent.Longitude.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = string.Join(":", string.Empty, PositionComponent.Longitude.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetRange<ResourceCurrentType, ResourceIndexType>(Range range, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      //There is no way to sensibly turn a Range into a Token type, so we just do nothing
      //and ignore setting the index. The reason this method is here is due to some search parameters
      //being a choice type where one of the choices is valid for token, like Boolean, yet others are 
      //not like Range as seen for the 'value' search parameter on the 'Group' resource .        
    }
    private void SetQuantity<ResourceCurrentType, ResourceIndexType>(Quantity Quantity, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (Quantity.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Convert.ToString(Quantity.Value.Value);
        if (!string.IsNullOrWhiteSpace(Quantity.Unit))
        {
          ResourceIndex.System = Quantity.Unit.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetPositiveInt<ResourceCurrentType, ResourceIndexType>(PositiveInt PositiveInt, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (PositiveInt.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Convert.ToString(PositiveInt.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetIdentifier<ResourceCurrentType, ResourceIndexType>(Identifier Identifier, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Identifier.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Identifier.Value.Trim();
        if (!string.IsNullOrWhiteSpace(Identifier.System))
        {
          ResourceIndex.System = Identifier.System.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetId<ResourceCurrentType, ResourceIndexType>(Id Id, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Id.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Id.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirString<ResourceCurrentType, ResourceIndexType>(FhirString FhirString, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = FhirString.Value;
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetFhirDateTime<ResourceCurrentType, ResourceIndexType>(FhirDateTime FhirDateTime, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(FhirDateTime.Value))
      {
        if (Hl7.Fhir.Model.FhirDateTime.IsValidValue(FhirDateTime.Value))
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.Code = FhirDateTime.Value;
          ResourceIndex.System = null;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetFhirBoolean<ResourceCurrentType, ResourceIndexType>(FhirBoolean FhirBoolean, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (FhirBoolean.Value != null)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = FhirBoolean.Value.ToString().ToLower();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetContactPoint<ResourceCurrentType, ResourceIndexType>(ContactPoint ContactPoint, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(ContactPoint.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = ContactPoint.Value.Trim();
        if (ContactPoint.System != null)
        {
          ResourceIndex.System = ContactPoint.System.GetLiteral();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCoding<ResourceCurrentType, ResourceIndexType>(Coding Coding, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Coding.Code))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Coding.Code.Trim();
        if (!string.IsNullOrWhiteSpace(Coding.System))
        {
          ResourceIndex.System = Coding.System.Trim();
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetCodeableConcept<ResourceCurrentType, ResourceIndexType>(CodeableConcept CodeableConcept, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (CodeableConcept.Coding.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(CodeableConcept.Text))
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.Code = CodeableConcept.Text;
        }
      }
      else
      {
        foreach (Coding Code in CodeableConcept.Coding)
        {
          SetCoding<ResourceCurrentType, ResourceIndexType>(Code, ResourceIndexList);
        }
      }
    }
    private void SetCode<ResourceCurrentType, ResourceIndexType>(Code Code, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Code.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Code.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
