using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Linq;
using System.Collections.Generic;
using FhirModel = Hl7.Fhir.Model;
using NetSystem = System;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public class PyroHL7V2MessageTypeEvent : IPyroHL7V2MessageTypeEvent
  {
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

    public PyroHL7V2MessageTypeEvent(CodeSystems.IPyroFhirServer IPyroFhirServer)
    {
      this.IPyroFhirServerCodeSystem = IPyroFhirServer;
    }

    public enum Codes
    {
      [EnumLiteral("ADTA01")]
      ADTA01,
      [EnumLiteral("ADTA08")]
      ADTA08,
      [EnumLiteral("ADTA03")]
      ADTA03,
    }
    private Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent> _Dictionary;
    private Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent> _CodeDefinitionDictionary
    {
      get
      {
        if (_Dictionary == null)
        {
          BuildCodeDefinitionDictionary();
        }
        return _Dictionary;
      }
      set
      {
        _Dictionary = value;
      }
    }
    private void BuildCodeDefinitionDictionary()
    {
      _Dictionary = new Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent>()
      {
        {
          Codes.ADTA01,
          new FhirModel.CodeSystem.ConceptDefinitionComponent(){
            Code = Codes.ADTA01.GetPyroLiteral(),
            Display = "ADT^A01",
            Definition = "Admit / visit notification",
          }
        },
        {
          Codes.ADTA08,
          new FhirModel.CodeSystem.ConceptDefinitionComponent(){
            Code = Codes.ADTA08.GetPyroLiteral(),
            Display = "ADT^A08",
            Definition = "Update patient information",
          }
        },
        {
          Codes.ADTA03,
          new FhirModel.CodeSystem.ConceptDefinitionComponent(){
            Code = Codes.ADTA03.GetPyroLiteral(),
            Display = "ADT^A03",
            Definition = "Discharge/end visit",
          }
        },
      };
    }

    private static string ResourceId = "hl7-v2-message-type-event";
    public static string System = "https://pyrohealth.net/fhir/CodeSystem/hl7-v2-message-type-event";

    public string GetName()
    {
      return ResourceId;
    }

    public string GetResourceId()
    {
      return ResourceId;
    }

    public string GetCode(Codes Code)
    {
      return Code.GetPyroLiteral();
    }

    public string GetSystem()
    {
      return System;
    }

    public FhirModel.Coding GetCoding(Codes Code)
    {
      if (_CodeDefinitionDictionary.ContainsKey(Code))
      {
        var Def = _CodeDefinitionDictionary[Code];
        return new FhirModel.Coding() { Code = Def.Code, Display = Def.Display, System = GetSystem() };
      }
      else
      {
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the _CodeDefinitionDictionary for {this.GetName()} CodeSystem");
      }
    }
    public bool HasCode(string Code)
    {
      foreach (Codes Codes in NetSystem.Enum.GetValues(typeof(Codes)).Cast<Codes>())
      {
        if (Codes.GetPyroLiteral() == Code)
          return true;
      }
      return false;
    }

    public FhirModel.Identifier GetIdentifier(Codes Code)
    {
      if (_CodeDefinitionDictionary.ContainsKey(Code))
      {
        var Def = _CodeDefinitionDictionary[Code];
        return new FhirModel.Identifier()
        {
          System = this.GetSystem(),
          Value = this.GetCode(Code),
          Use = FhirModel.Identifier.IdentifierUse.Official
        };
      }
      else
      {
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the _CodeDefinitionDictionary for {this.GetName()} CodeSystem");
      }
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2019, 10, 10, 18, 30, 00, new TimeSpan(10, 0, 0));

    public FhirModel.CodeSystem GetResource()
    {
      var Resource = new FhirModel.CodeSystem();
      Resource.Id = this.GetName();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = this.GetSystem();
      Resource.Version = "1.00";
      Resource.Name = this.GetName();
      Resource.Title = "The HL7 V2 Message Type and Event CodeSystem";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Experimental = false;
      Resource.DateElement = new FhirModel.FhirDateTime(MasterLastUpdated);
      Resource.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown($"List of codes used by the Pyro FHIR server ${FhirOperationEnum.OperationType.ProcessMessage} base operations for the MessageHeader eventCoding property.");
      Resource.CaseSensitive = true;
      Resource.Compositional = false;
      Resource.Count = Resource.Concept.Count;
      Resource.Content = FhirModel.CodeSystem.CodeSystemContentMode.Complete;
      Resource.Concept = new List<FhirModel.CodeSystem.ConceptDefinitionComponent>();
      foreach (var Definition in _CodeDefinitionDictionary.Values)
      {
        Resource.Concept.Add(Definition);
      }
      return Resource;
    }


  }

}
