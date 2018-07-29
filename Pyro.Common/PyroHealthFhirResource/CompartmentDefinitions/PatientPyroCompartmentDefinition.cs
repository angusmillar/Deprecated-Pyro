using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CompartmentDefinitions
{
  public class PatientPyroCompartmentDefinition : IPatientPyroCompartmentDefinition
  {    
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
  
    public PatientPyroCompartmentDefinition(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {      
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    private static string ResourceId = "pyro-patient";
    public string GetResourceId()
    {
      return ResourceId;
    }

    private static string CanonicalUrl = "pyro-patient";
    public string GetCanonicalUrl()
    {
      return CanonicalUrl;
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 07, 28, 09, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.CompartmentDefinition GetResource()
    {      
      var LastUpdatedDateTime = new DateTimeOffset(2018, 07, 28, 09, 00, 00, new TimeSpan(8, 0, 0));      

      var ResourceBase = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromXml(CommonResource.PyroPatientCompartmentDefinition);
      FhirModel.CompartmentDefinition Resource = ResourceBase as FhirModel.CompartmentDefinition;
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = $"{IPyroFhirServerCodeSystem.GetSystem()}/CompartmentDefinition/patient";
      Resource.Name = "Base Pyro FHIR server compartment definition for Patient";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Title = "Patient Compartment Definition";
      Resource.Experimental = false;
      Resource.Date = LastUpdatedDateTime.ToString();
      Resource.Publisher = "PyroHealth";
      Resource.Contact = new List<FhirModel.ContactDetail>();
      Resource.Contact.Add(PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail());
      //The rest of the Resource content comes form the base xml file read in.
      return Resource;
    }
    
  }
}
