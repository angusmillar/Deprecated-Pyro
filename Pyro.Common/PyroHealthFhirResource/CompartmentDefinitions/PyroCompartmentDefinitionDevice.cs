using System;
using System.Collections.Generic;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CompartmentDefinitions
{
  public class PyroCompartmentDefinitionDevice : IPyroCompartmentDefinitionDevice
  {    
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
  
    public PyroCompartmentDefinitionDevice(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {      
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    private static string ResourceId = "pyro-device";
    public string GetResourceId()
    {
      return ResourceId;
    }
   
    public string GetCanonicalUrl()
    {
      return Elements.PyroHealthCanonicalUrl.CanonicalUrlBuild($"CompartmentDefinition/{GetResourceId()}");
    }

    //If you wish to update the Compartments in the server you need to not only chnage this datetime to update the 
    //CompartmentDefinition resource in the servers but also the Task that sets the CompartmentDefinition Compartments as Active
    //That Task is foud here: Pyro.Common.PyroHealthFhirResource.Tasks.SetCompartmentDefinitions
    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 09, 17, 14, 00, 00, new TimeSpan(8, 0, 0));
    
    public FhirModel.CompartmentDefinition GetResource()
    { 
      var ResourceBase = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromXml(CommonResource.PyroCompartmentDefinitionDevice);
      FhirModel.CompartmentDefinition Resource = ResourceBase as FhirModel.CompartmentDefinition;
      Resource.Id = GetResourceId();
      Resource.Status = FhirModel.PublicationStatus.Active;
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = GetCanonicalUrl();
      Resource.Contact = new List<FhirModel.ContactDetail>();
      Resource.Contact.Add(PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail());
      //The rest of the Resource content comes form the base xml file read in.
      return Resource;
    }
    
  }
}
