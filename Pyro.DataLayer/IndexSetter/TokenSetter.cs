using System;
using System.Collections.Generic;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.BusinessEntities.Dto;



namespace Pyro.DataLayer.IndexSetter
{
  public static class TokenSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {

    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)      
    {
      ResourceIndexList = new List<ResourceIndexType>();
      ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {        
        if (Poco.FhirValue is Code Code)
        {
          SetCode(Code);
        } 
        else if (Poco.FhirValue is CodeableConcept CodeableConcept)
        {
          SetCodeableConcept(CodeableConcept);
        }
        else if (Poco.FhirValue is Coding Coding)
        {
          SetCoding(Coding);
        } 
        else if (Poco.FhirValue.TypeName == "code")
        {
          if (Poco.Value is string CodeValue)
            SetCodeTypeT(CodeValue);
        }
        else if (Poco.FhirValue is ContactPoint ContactPoint)
        {
          SetContactPoint(ContactPoint);
        }
        else if (Poco.FhirValue is FhirBoolean FhirBoolean)
        {
          SetFhirBoolean(FhirBoolean);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetFhirDateTime(FhirDateTime);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString(FhirString);
        }
        else if (Poco.FhirValue is Id Id)
        {
          SetId(Id);
        }
        else if (Poco.FhirValue is Identifier Identifier)
        {
          SetIdentifier(Identifier);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt(PositiveInt);
        }
        else if (Poco.FhirValue is Quantity Quantity)
        {
          SetQuantity(Quantity);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange(Range);
        }
        else if (Poco.FhirValue is Location.PositionComponent PositionComponent)
        {
          SePositionComponent(PositionComponent);
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
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
        SetFhirBoolean(FhirBool);
      }
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
      ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
      return ResourceIndexList;

    }


    private static void SetCodeTypeT(string CodeValue)
    {
     if (!string.IsNullOrWhiteSpace(CodeValue))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = CodeValue;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SePositionComponent(Location.PositionComponent PositionComponent)       
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

    private static void SetRange(Range range)       
    {
      //There is no way to sensibly turn a Range into a Token type, so we just do nothing
      //and ignore setting the index. The reason this method is here is due to some search parameters
      //being a choice type where one of the choices is valid for token, like Boolean, yet others are 
      //not like Range as seen for the 'value' search parameter on the 'Group' resource .        
    }

    private static void SetQuantity(Quantity Quantity)       
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

    private static void SetPositiveInt(PositiveInt PositiveInt)
    {
      if (PositiveInt.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Convert.ToString(PositiveInt.Value);
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }

    private static void SetIdentifier(Identifier Identifier)       
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

    private static void SetId(Id Id)      
    {
      if (!string.IsNullOrWhiteSpace(Id.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = Id.Value.Trim();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetFhirString(FhirString FhirString)       
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = FhirString.Value;
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }

    private static void SetFhirDateTime(FhirDateTime FhirDateTime)       
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

    private static void SetFhirBoolean(FhirBoolean FhirBoolean)
    {
      if (FhirBoolean.Value != null)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Code = FhirBoolean.Value.ToString().ToLower();
        ResourceIndex.System = null;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }

    private static void SetContactPoint(ContactPoint ContactPoint)       
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

    private static void SetCoding(Coding Coding)
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

    private static void SetCodeableConcept(CodeableConcept CodeableConcept)
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
          SetCoding(Code);
        }
      }
    }

    private static void SetCode(Code Code)       
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
