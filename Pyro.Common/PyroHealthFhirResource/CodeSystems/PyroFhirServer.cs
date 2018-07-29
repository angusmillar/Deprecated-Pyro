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
  public class PyroFhirServer : IPyroFhirServer
  {
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
        _CodeDefinitionDictionary = value;
      }
    }
    
    private void BuildCodeDefinitionDictionary()
    {
      _Dictionary = new Dictionary<Codes, FhirModel.CodeSystem.ConceptDefinitionComponent>()
          {
            {
              Codes.ActiveCompartment,
              new FhirModel.CodeSystem.ConceptDefinitionComponent(){
                Code = Codes.ActiveCompartment.GetPyroLiteral(),
                Display = "Active Compartment",
                Definition = "Used to indicate that a CompartmentDefinition Resource is used as an active Compartment in the FHIR server.",
              }
            },
            {
              Codes.CompartmentDefinition,
              new FhirModel.CodeSystem.ConceptDefinitionComponent()
              {
                 Code = Codes.CompartmentDefinition.GetPyroLiteral(),
                 Display = "CompartmentDefinition",
                 Definition = "A FHIR CompartmentDefinition resource definied for use in a Pyro FHIR server",
              }
            },
            {
              Codes.HiServiceCallAudit,
              new FhirModel.CodeSystem.ConceptDefinitionComponent()
              {
                 Code = Codes.HiServiceCallAudit.GetPyroLiteral(),
                 Display = "HI Service Call Audit",
                 Definition = "An Audit event in response to a web service call made to the Australian Healthcare Identifer Service (HI Service) by a Pyro FHIR server",
              }
            },
            {
              Codes.ServerInstance,
              new FhirModel.CodeSystem.ConceptDefinitionComponent()
              {
                 Code = Codes.ServerInstance.GetPyroLiteral(),
                 Display = "Server Instance",
                 Definition = "An instance of a Pyro FHIR server",
              }
            },
            {
              Codes.Protected,
              new FhirModel.CodeSystem.ConceptDefinitionComponent()
              {
                 Code = Codes.Protected.GetPyroLiteral(),
                 Display = "Protected Resource",
                 Definition = "Protected entities and resource can not be updated or deleted",
              }
            },
            {
              Codes.ServerStartupTask,
              new FhirModel.CodeSystem.ConceptDefinitionComponent()
              {
                 Code = Codes.ServerStartupTask.GetPyroLiteral(),
                 Display = "Server Startup Task",
                 Definition = "FHIR Task to be run on the start-up of the Pyro FHIR Server",
              }
            },
          };
    }
    
    public PyroFhirServer(){ }

    public enum Codes
    {
      [EnumLiteral("ActiveCompartment")]
      ActiveCompartment,
      [EnumLiteral("CompartmentDefinition")]
      CompartmentDefinition,
      [EnumLiteral("HiServiceCallAudit")]
      HiServiceCallAudit,
      [EnumLiteral("ServerInstance")]
      ServerInstance,
      [EnumLiteral("Protected")]
      Protected,
      [EnumLiteral("ServerStartupTask")]
      ServerStartupTask,
    }

    private static string ResourceId = "pyrofhirserver";
    public static string System = "https://pyrohealth.net/fhir/CodeSystem/pyrofhirserver";

    public string GetSystem()
    {
      return System;
    }

    public string GetName()
    {
      return ResourceId;
    }

    public string GetResourceId()
    {
      return ResourceId;
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
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the CodeDefinitionDictionary for PyroFhirServer CodeSystem");
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
        throw new Exception($"Internal Server Error: Enum {Code.ToString()} is not registered in the CodeDefinitionDictionary for PyroFhirServer CodeSystem");
      }
    }

    public string GetCode(Codes Code)
    {
      return Code.GetPyroLiteral();
    }

    public void SetProtectedMetaTag(FhirModel.Resource Resource)
    {
      if (Resource.Meta == null)
        Resource.Meta = new FhirModel.Meta();
      if (Resource.Meta.Tag == null)
        Resource.Meta.Tag = new List<FhirModel.Coding>();

      var ProotectedCodes = Resource.Meta.Tag.Where(x => x.System == GetSystem() && x.Code == GetCode(Codes.Protected));
      if (ProotectedCodes.Count() == 0)
      {
        Resource.Meta.Tag.Add(GetCoding(Codes.Protected));
      }
      else if(ProotectedCodes.Count() > 1)
      {
        //Remove the many replace with just one
        Resource.Meta.Tag.RemoveAll(x => x.System == GetSystem() && x.Code == GetCode(Codes.Protected));
        Resource.Meta.Tag.Add(GetCoding(Codes.Protected));
      }      
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 07, 06, 10, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.CodeSystem GetResource()
    {      
      var Resource = new FhirModel.CodeSystem();
      Resource.Id = "pyrofhirserver";
      SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;           
      Resource.Url = this.GetSystem();
      Resource.Version = "1.00";
      Resource.Name = "PyroFHIRServerCodeSystem";
      Resource.Title = "The Pyro Server CodeSystem";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Experimental = false;
      Resource.DateElement = new FhirModel.FhirDateTime(MasterLastUpdated);
      Resource.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown("List of codes used throughout the Pyro FHIR Server to identity concepts key to the operation of the server.");
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
