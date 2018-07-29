using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public class PyroHealth : IPyroHealth
  {
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

    public enum Codes
    {
      [EnumLiteral("PyroHealth")]
      PyroHealth,
      [EnumLiteral("PyroFhirServer")]
      PyroFhirServer,

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
          Codes.PyroHealth,
          new FhirModel.CodeSystem.ConceptDefinitionComponent(){
            Code = Codes.PyroHealth.GetPyroLiteral(),
            Display = "Pyro Health",
            Definition = "The Pyro Health Orginsation.",
          }
        },
        {
          Codes.PyroFhirServer,
          new FhirModel.CodeSystem.ConceptDefinitionComponent(){
            Code = Codes.PyroFhirServer.GetPyroLiteral(),
            Display = "Pyro Fhir Server",
            Definition = "A Pyro FHir Server Instance.",
          }
        },
      };
    }
   
    public PyroHealth(CodeSystems.IPyroFhirServer IPyroFhirServer)
    {
      this.IPyroFhirServerCodeSystem = IPyroFhirServer;    
    }

    private static string ResourceId = "pyro-health";
    public static string System = "https://pyrohealth.net/fhir/CodeSystem/pyro-health";

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

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 07, 26, 18, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.CodeSystem GetResource()
    {      
      var Resource = new FhirModel.CodeSystem();
      Resource.Id = this.GetName();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);      
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = this.GetSystem();
      Resource.Version = "1.00";
      Resource.Name = this.GetName();
      Resource.Title = "The Pyro Health Orginsation CodeSystem";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Experimental = false;
      Resource.DateElement = new FhirModel.FhirDateTime(MasterLastUpdated);
      Resource.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown("List of codes used by the Pyro Health Orginsation to identity the Orginsation's concepts.");
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
