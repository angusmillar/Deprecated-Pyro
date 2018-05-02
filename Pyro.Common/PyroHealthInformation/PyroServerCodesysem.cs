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
  public class PyroServerCodeSystem : Hl7.Fhir.Model.CodeSystem
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

    public PyroServerCodeSystem()
    {
      this.Id = "pyroserver";
      this.Url = "https://pyrohealth.net/CodeSystem/pyroserver";
      this.Version = "1.00";
      this.Name = "PyroServerCodeSystem";
      this.Title = "The Pyro Server CodeSystem";
      this.Status = PublicationStatus.Active;
      this.Experimental = false;
      //When the CodeSystem was last editied
      this.DateElement = new FhirDateTime(new DateTimeOffset(2018, 05, 01, 10, 00, 00, new TimeSpan(8, 0, 0)));
      this.Publisher = "Pyrohealth.net";
      this.Contact = new List<ContactDetail>() { new PyroHealthContactDetailAngusMillar() };
      this.Description = new Markdown("List of codes used throughout the Pyro FHIR Server to identity concepts key to the operation of the server.");
      this.CaseSensitive = true;
      this.Compositional = false;
      this.Count = this.Concept.Count;
      this.Content = CodeSystemContentMode.Complete;
      this.Concept = new List<ConceptDefinitionComponent>()
      {
        new ConceptDefinitionComponent()
        {
           Code = Codes.ActiveCompartment.GetPyroLiteral(),
           Display = "Active Compartment",
           Definition = "Used to indicate that a CompartmentDefinition Resource is used as an active Compartment in the FHIR server.",          
        },
        new ConceptDefinitionComponent()
        {
           Code = Codes.CompartmentDefinition.GetPyroLiteral(),
           Display = "CompartmentDefinition",
           Definition = "A FHIR CompartmentDefinition resource definied for use in a Pyro FHIR server",
        },
        new ConceptDefinitionComponent()
        {
           Code = Codes.HiServiceCallAudit.GetPyroLiteral(),
           Display = "HI Service Call Audit",
           Definition = "An Audit event in response to a web service call made to the Australian Healthcare Identifer Service (HI Service) by a Pyro FHIR server",
        },
        new ConceptDefinitionComponent()
        {
           Code = Codes.ServerInstance.GetPyroLiteral(),
           Display = "Server Instance",
           Definition = "An instance of a Pyro FHIR server",
        },
      };

    }
    
  }

  
}
