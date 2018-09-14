using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using Pyro.Common.Tools.FhirTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Tasks
{
  public class SetCompartmentDefinitions : ISetCompartmentDefinitions
  {
    private readonly Devices.IPyroFhirServer IPyroFhirServerDevice;
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly CodeSystems.IPyroTask IPyroTask;   
    private readonly Organizations.IPyroHealth IPyroHealthOrg;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ICompartmentDefinition ICompartmentDefinition;

    public SetCompartmentDefinitions(Devices.IPyroFhirServer IPyroFhirServerDevice, 
      ICompartmentDefinition ICompartmentDefinition, 
      CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem, 
      CodeSystems.IPyroTask IPyroTask,      
      IGlobalProperties IGlobalProperties, 
      Organizations.IPyroHealth IPyroHealthOrg)
    {
      this.IPyroFhirServerDevice = IPyroFhirServerDevice;
      this.ICompartmentDefinition = ICompartmentDefinition;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.IPyroTask = IPyroTask;      
      this.IGlobalProperties = IGlobalProperties;
      this.IPyroHealthOrg = IPyroHealthOrg;
    }
    
    private static string ResourceId = "set-compartment-definitions";
    
    public string GetResourceId()
    {
      return ResourceId;
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 07, 30, 18, 05, 00, new TimeSpan(8, 0, 0));

    public FhirModel.Task GetResource()
    {
      var Resource = new FhirModel.Task();
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);      
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Identifier = new List<FhirModel.Identifier>()
      {
        IPyroFhirServerCodeSystem.GetIdentifier(PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ServerStartupTask)
      };

      //Task.Definition =??
      Resource.Status = FhirModel.Task.TaskStatus.Ready;
      Resource.Intent = FhirModel.Task.TaskIntent.Order;
      Resource.Priority = FhirModel.RequestPriority.Asap;

      Resource.Code = new FhirModel.CodeableConcept();
      
      FhirModel.Coding TaskCodingType = new FhirModel.Coding(IPyroTask.GetSystem(), IPyroTask.GetCode(CodeSystems.PyroTask.Codes.SetCompartmentDefinitions));
      Resource.Code.Coding.Add(TaskCodingType);

      Resource.Description = "This task is used by the Pyro FHIR Server to load set CompartmentDefinition resource as active compartments in the FHIR server instance on the first ever startup.";

      Resource.Focus = new FhirModel.ResourceReference($"{FhirModel.ResourceType.Device.GetLiteral()}/{IPyroFhirServerDevice.GetResourceId()}");
      FhirModel.ResourceReference ServerManagingOrginationReferrence;
      FhirModel.ResourceReference PyroHealthOrgReference = new FhirModel.ResourceReference($"{FhirModel.ResourceType.Organization.GetLiteral()}/{IPyroHealthOrg.GetResourceId()}");
      if (string.IsNullOrWhiteSpace(IGlobalProperties.ThisServersManagingOrganizationResource))
      {
        ServerManagingOrginationReferrence = PyroHealthOrgReference;
      }
      else
      {
        ServerManagingOrginationReferrence = new FhirModel.ResourceReference(IGlobalProperties.ThisServersManagingOrganizationResource);
      }
      Resource.For = ServerManagingOrginationReferrence;
      Resource.AuthoredOn = new FhirModel.FhirDateTime(MasterLastUpdated).ToString();
      Resource.LastModified = new FhirModel.FhirDateTime(MasterLastUpdated).ToString();
      Resource.Requester = PyroHealthOrgReference;
      //Change STU3 to R4
      //Resource.Requester = new FhirModel.Task.RequesterComponent();
      //Resource.Requester.OnBehalfOf = ServerManagingOrginationReferrence;
      //Resource.Requester.Agent = PyroHealthOrgReference;
      Resource.PerformerType = new List<FhirModel.CodeableConcept>();
      
      var PerformerTypeCodeableConcept = new FhirModel.CodeableConcept();
      Resource.PerformerType.Add(PerformerTypeCodeableConcept);
      PerformerTypeCodeableConcept.Coding = new List<FhirModel.Coding>();
      var PerformerTypeCoding = new FhirModel.Coding();
      PerformerTypeCodeableConcept.Coding.Add(PerformerTypeCoding);
      PerformerTypeCoding.System = "http://hl7.org/fhir/task-performer-type";
      PerformerTypeCoding.Code = "scheduler";
      PerformerTypeCoding.Display = "Scheduler";

      Resource.Owner = PyroHealthOrgReference;

      Resource.ReasonCode = new FhirModel.CodeableConcept() { Text = "Set active compartments into the FHIR server instance" };

      Resource.Restriction = new FhirModel.Task.RestrictionComponent() { Repetitions = 0 };
      
      return Resource;
    }

  }
}
