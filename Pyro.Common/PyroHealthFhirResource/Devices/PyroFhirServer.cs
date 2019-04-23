using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Devices
{
  //This class represents the creation of a FHIR Device resource where that 
  //device is the Pyro Fhir Server its self as a device
  public class PyroFhirServer : IPyroFhirServer
  {
    private readonly IGlobalProperties IGlobalProperties;
    private readonly CodeSystems.IPyroHealth IPyroHealthCodeSystem;
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly Organizations.IPyroHealth IPyroHealthOrg;

    public PyroFhirServer(IGlobalProperties IGlobalProperties, 
      Organizations.IPyroHealth IPyroHealthOrg, 
      CodeSystems.IPyroHealth IPyroHealthCodeSystem, 
      CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {
      this.IGlobalProperties = IGlobalProperties;
      this.IPyroHealthOrg = IPyroHealthOrg;
      this.IPyroHealthCodeSystem = IPyroHealthCodeSystem;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    private static string ResourceId = "Pyro-Fhir-Server";
    
    public string GetResourceId()
    {
      return ResourceId;
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 07, 26, 18, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.Device GetResource()
    {            
      var ManufactureDate = new DateTimeOffset(2017, 10, 17, 6, 00, 00, new TimeSpan(8, 0, 0));
     
      var Resource = new FhirModel.Device();
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Identifier = new List<FhirModel.Identifier>()
      {
        IPyroHealthCodeSystem.GetIdentifier(CodeSystems.PyroHealth.Codes.PyroFhirServer)
      };
      Resource.Status = FhirModel.Device.FHIRDeviceStatus.Active;
      Resource.Type = new FhirModel.CodeableConcept();
      Resource.Type.Coding = new List<FhirModel.Coding>()
      {
        new FhirModel.Coding("http://snomed.info/sct", "129465004", "Medical record")
      };
      Resource.Manufacturer = "Pyro Health";
      Resource.ManufactureDate = ManufactureDate.ToString();      
      Resource.Version = new List<FhirModel.Device.VersionComponent>()
      {
        new FhirModel.Device.VersionComponent()
        {
           Value =$"V{IGlobalProperties.ApplicationVersionInfo}"
        }
      };
      if (string.IsNullOrWhiteSpace(IGlobalProperties.ThisServersManagingOrganizationResource))
      {
        Resource.Owner = new FhirModel.ResourceReference($"{FhirModel.ResourceType.Organization.GetLiteral()}/{IPyroHealthOrg.GetResourceId()}");
      }
      else
      {
        Resource.Owner = new FhirModel.ResourceReference(IGlobalProperties.ThisServersManagingOrganizationResource);
      }
      Resource.Url = IGlobalProperties.ServiceBaseURL;
      Resource.Note = new List<FhirModel.Annotation>();
      var Annotation = new FhirModel.Annotation();
      Annotation.Text = new FhirModel.Markdown("This device is a Medical Record FHIR server.");
      return Resource;
    }
    
  }
}
