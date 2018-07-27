using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.CodeSystems
{
  public class PyroTask : IPyroTask
  {
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

    private Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent> _CodeDefinitionDictionary;

    public enum Codes
    {
      [EnumLiteral("LoadFhirSpecResources")]
      LoadFhirSpecResources,
    }

    public PyroTask(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;

      _CodeDefinitionDictionary = new Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent>()
      {
        {
          Codes.LoadFhirSpecResources,
          new FhirModel.CodeSystem.ConceptDefinitionComponent()
          {
              Code = Codes.LoadFhirSpecResources.GetPyroLiteral(),
              Display = "Load Fhir Spec Resources",
              Definition = "Fhir Task that Loads the FHIR specifications Resources into the Pyro FHIR Server on first start-up.",
          }
        },

      };

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

    public FhirModel.CodeSystem GetCodeSystem()
    {
      var CodeSystemUpdateDate = new DateTimeOffset(2018, 07, 24, 10, 00, 00, new TimeSpan(8, 0, 0));
      var Resource = new FhirModel.CodeSystem();
      Resource.Id = "pyro-task";
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = CodeSystemUpdateDate;
      Resource.Url = this.GetSystem();
      Resource.Version = "1.00";
      Resource.Name = "PyroTaskCodeSystem";
      Resource.Title = "The Pyro Task CodeSystem";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Experimental = false;
      Resource.DateElement = new FhirModel.FhirDateTime(CodeSystemUpdateDate);
      Resource.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthInformation.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
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
