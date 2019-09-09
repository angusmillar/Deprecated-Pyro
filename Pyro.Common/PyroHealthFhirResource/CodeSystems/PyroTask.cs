using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using NetSystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public class PyroTask : IPyroTask
  {
    public enum Codes
    {      
      [EnumLiteral("LoadFhirDefinitionResources")]
      LoadFhirDefinitionResources,
      [EnumLiteral("SetCompartmentDefinitions")]
      SetCompartmentDefinitions,
      [EnumLiteral("SetSearchParameterDefinitions")]
      SetSearchParameterDefinitions,
      [EnumLiteral("SearchParameterIndexing")]
      SearchParameterIndexing,

    }

    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

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
          Codes.LoadFhirDefinitionResources,
          new FhirModel.CodeSystem.ConceptDefinitionComponent()
          {
              Code = Codes.LoadFhirDefinitionResources.GetPyroLiteral(),
              Display = "Load Fhir Definition Resources",
              Definition = "Fhir Task that loads the FHIR specifications definition resources into the Pyro FHIR Server on first start-up.",
          }          
        },
        {
          Codes.SetCompartmentDefinitions,
          new FhirModel.CodeSystem.ConceptDefinitionComponent()
          {
              Code = Codes.SetCompartmentDefinitions.GetPyroLiteral(),
              Display = "Set Compartment Definitions",
              Definition = "Fhir Task that sets the all the CompartmentDefinitions as active compartments in the Pyro FHIR Server.",
          }
        },
        {
          Codes.SetSearchParameterDefinitions,
          new FhirModel.CodeSystem.ConceptDefinitionComponent()
          {
              Code = Codes.SetSearchParameterDefinitions.GetPyroLiteral(),
              Display = "Set Search Parameter Definitions",
              Definition = "Fhir Task that sets the all the base Search Parameter Definitions as active search indexes in the Pyro FHIR Server.",
          }
        },
        {
          Codes.SearchParameterIndexing,
          new FhirModel.CodeSystem.ConceptDefinitionComponent()
          {
              Code = Codes.SearchParameterIndexing.GetPyroLiteral(),
              Display = "Perform indexing on new or updated search parameter indexes for the FHIR server",
              Definition = "Fhir Task that performs pending indexing for new or updated search indexes.",
          }
        },
      };
    }
    
    public PyroTask(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;      
    }

    private static string ResourceId = "pyro-task";
    public static string System = "https://pyrohealth.net/fhir/CodeSystem/pyro-task";

    public string GetName()
    {
      return ResourceId;
    }

    public string GetResourceId()
    {
      return ResourceId;
    }

    public string GetSystem()
    {
      return System;
    }

    public string GetCode(Codes Code)
    {
      return Code.GetPyroLiteral();
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
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the _CodeDefinitionDictionary for PyroFhirServer CodeSystem");
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
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the _CodeDefinitionDictionary for PyroFhirServer CodeSystem");
      }
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 10, 06, 15, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.CodeSystem GetResource()
    {      
      var Resource = new FhirModel.CodeSystem();
      Resource.Id = "pyro-task";
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = this.GetSystem();
      Resource.Version = "1.00";
      Resource.Name = "PyroTaskCodeSystem";
      Resource.Title = "The Pyro Task CodeSystem";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Experimental = false;
      Resource.DateElement = new FhirModel.FhirDateTime(MasterLastUpdated);
      Resource.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown("List of codes used for Tasks types used and processed by the Pyro Server.");
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
