using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Organizations
{
  public class PyroHealth : IPyroHealth
  {
    private readonly CodeSystems.IPyroHealth IPyroHealthCodeSystem;
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

    public PyroHealth(CodeSystems.IPyroHealth IPyroHealthCodeSystem, CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {
      this.IPyroHealthCodeSystem = IPyroHealthCodeSystem;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    private static string ResourceId = "Pyro-Health";

    public string GetName()
    {
      return ResourceId;
    }

    public string GetResourceId()
    {
      return ResourceId;
    }


    public FhirModel.Organization GetOrganization()
    {
      var LastUpdated = new DateTimeOffset(2018, 07, 26, 18, 00, 00, new TimeSpan(8, 0, 0));

      var Resource = new FhirModel.Organization();
      Resource.Id = GetResourceId();

      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = LastUpdated;
      Resource.Identifier = new List<FhirModel.Identifier>()
      {
        IPyroHealthCodeSystem.GetIdentifier(CodeSystems.PyroHealth.Codes.PyroHealth)
      };
      Resource.Active = true;
      Resource.Name = GetResourceId();
      var AngusContactDetails = Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Telecom = AngusContactDetails.Telecom;
      Resource.Endpoint = new List<FhirModel.ResourceReference>()
      {
         new FhirModel.ResourceReference("https://pyrohealth.net/")
      };
      Resource.Contact = new List<FhirModel.Organization.ContactComponent>();
      var ContactComponent = new FhirModel.Organization.ContactComponent();
      Resource.Contact.Add(ContactComponent);
      ContactComponent.Name = new FhirModel.HumanName();
      ContactComponent.Name.Text = AngusContactDetails.Name;
      ContactComponent.Telecom = AngusContactDetails.Telecom;
      
      return Resource;
    }
    
  }
}
