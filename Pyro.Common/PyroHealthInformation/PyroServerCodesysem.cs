using Hl7.Fhir.Model;
using Pyro.Common.PyroHealthInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Attributes;

namespace Pyro.Common.PyroHealthInformation
{
  public class PyroServerCodeSystem
  {
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
    }

   
    public static CodeSystem GetCodeSystem()
    {
      var CodeSys = new CodeSystem();
      CodeSys.Id = "pyroserver";
      CodeSys.Url = "https://pyrohealth.net/CodeSystem/pyroserver";
      CodeSys.Version = "1.00";
      CodeSys.Name = "PyroServerCodeSystem";
      CodeSys.Title = "The Pyro Server CodeSystem";
      CodeSys.Status = PublicationStatus.Active;
      CodeSys.Experimental = false;
      //When the CodeSystem was last editied
      CodeSys.DateElement = new FhirDateTime(new DateTimeOffset(2018, 05, 01, 10, 00, 00, new TimeSpan(8, 0, 0)));
      CodeSys.Publisher = "Pyrohealth.net";
      var AngusContactDetail = Common.PyroHealthInformation.PyroHealthContactDetailAngusMillar.GetContactDetail();
      CodeSys.Contact = new List<ContactDetail>() { AngusContactDetail };
      CodeSys.Description = new Markdown("List of codes used throughout the Pyro FHIR Server to identity concepts key to the operation of the server.");
      CodeSys.CaseSensitive = true;
      CodeSys.Compositional = false;
      CodeSys.Count = CodeSys.Concept.Count;
      CodeSys.Content = CodeSystem.CodeSystemContentMode.Complete;
      CodeSys.Concept = new List<CodeSystem.ConceptDefinitionComponent>()
      {
        new CodeSystem.ConceptDefinitionComponent()
        {
           Code = Codes.ActiveCompartment.GetPyroLiteral(),
           Display = "Active Compartment",
           Definition = "Used to indicate that a CompartmentDefinition Resource is used as an active Compartment in the FHIR server.",
        },
        new CodeSystem.ConceptDefinitionComponent()
        {
           Code = Codes.CompartmentDefinition.GetPyroLiteral(),
           Display = "CompartmentDefinition",
           Definition = "A FHIR CompartmentDefinition resource definied for use in a Pyro FHIR server",
        },
        new CodeSystem.ConceptDefinitionComponent()
        {
           Code = Codes.HiServiceCallAudit.GetPyroLiteral(),
           Display = "HI Service Call Audit",
           Definition = "An Audit event in response to a web service call made to the Australian Healthcare Identifer Service (HI Service) by a Pyro FHIR server",
        },
        new CodeSystem.ConceptDefinitionComponent()
        {
           Code = Codes.ServerInstance.GetPyroLiteral(),
           Display = "Server Instance",
           Definition = "An instance of a Pyro FHIR server",
        },
      };
      return CodeSys;
    }
  }

  
}
