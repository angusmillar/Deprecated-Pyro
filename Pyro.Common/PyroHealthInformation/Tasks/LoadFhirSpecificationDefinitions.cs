using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using Pyro.Common.Tools.FhirTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.Tasks
{
  public class LoadFhirSpecificationDefinitions : ILoadFhirSpecificationDefinitions
  {
    private readonly Devices.IPyroFhirServer IPyroFhirServerDevice;
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly CodeSystems.IPyroTask IPyroTask;   
    private readonly Organizations.IPyroHealth IPyroHealthOrg;
    private readonly IGlobalProperties IGlobalProperties;

    public LoadFhirSpecificationDefinitions(Devices.IPyroFhirServer IPyroFhirServerDevice, 
      CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem, 
      CodeSystems.IPyroTask IPyroTask,      
      IGlobalProperties IGlobalProperties, 
      Organizations.IPyroHealth IPyroHealthOrg)
    {
      this.IPyroFhirServerDevice = IPyroFhirServerDevice;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.IPyroTask = IPyroTask;      
      this.IGlobalProperties = IGlobalProperties;
      this.IPyroHealthOrg = IPyroHealthOrg;
    }

    private static string ResourceId = "Load-Fhir-Specification-Definitions";

    public string GetName()
    {
      return ResourceId;
    }

    public string GetResourceId()
    {
      return ResourceId;
    }


    public FhirModel.Task GetTask()
    {
      var LastUpdated = new DateTimeOffset(2018, 07, 27, 16, 37, 00, new TimeSpan(8, 0, 0));

      var Resource = new FhirModel.Task();
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);      
      Resource.Meta.LastUpdated = LastUpdated;
      Resource.Identifier = new List<FhirModel.Identifier>()
      {
        IPyroFhirServerCodeSystem.GetIdentifier(PyroHealthInformation.CodeSystems.PyroFhirServer.Codes.ServerStartupTask)
      };

      //Task.Definition =??
      Resource.Status = FhirModel.Task.TaskStatus.Ready;
      Resource.Intent = FhirModel.RequestIntent.Order;
      Resource.Priority = FhirModel.RequestPriority.Asap;

      Resource.Code = new FhirModel.CodeableConcept();
      
      FhirModel.Coding LoadFhirSpecResourcesTaskCoding = new FhirModel.Coding(IPyroTask.GetSystem(), IPyroTask.GetCode(CodeSystems.PyroTask.Codes.LoadFhirSpecResources));
      Resource.Code.Coding.Add(LoadFhirSpecResourcesTaskCoding);

      Resource.Description = "This task is used by the Pyro FHIR Server to load all the FHIR specification definition resource into the FHIR server instance on the first ever startup.";

      Resource.Focus = new FhirModel.ResourceReference($"{FhirModel.ResourceType.Device.GetLiteral()}/{IPyroFhirServerDevice.GetResourceId()}");
      FhirModel.ResourceReference ServerManagingOrginationReferrence;
      FhirModel.ResourceReference PyroHealthOrgReference = new FhirModel.ResourceReference($"{FhirModel.ResourceType.Organization.GetLiteral()}/{IPyroHealthOrg.GetOrganization().Id}");
      if (string.IsNullOrWhiteSpace(IGlobalProperties.ThisServersManagingOrganizationResource))
      {
        ServerManagingOrginationReferrence = PyroHealthOrgReference;
      }
      else
      {
        ServerManagingOrginationReferrence = new FhirModel.ResourceReference(IGlobalProperties.ThisServersManagingOrganizationResource);
      }
      Resource.For = ServerManagingOrginationReferrence;
      Resource.AuthoredOn = new FhirModel.FhirDateTime(LastUpdated).ToString();
      Resource.LastModified = new FhirModel.FhirDateTime(LastUpdated).ToString();
      Resource.Requester = new FhirModel.Task.RequesterComponent();
      Resource.Requester.OnBehalfOf = ServerManagingOrginationReferrence;
      Resource.Requester.Agent = PyroHealthOrgReference;
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

      Resource.Reason = new FhirModel.CodeableConcept() { Text = "To Load the FHIR Specification base resources into the FHIR server instance" };

      Resource.Restriction = new FhirModel.Task.RestrictionComponent() { Repetitions = 0 };
      
      return Resource;
    }

  }
}
