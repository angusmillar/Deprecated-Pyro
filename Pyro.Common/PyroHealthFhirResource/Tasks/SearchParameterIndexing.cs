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
  public class SearchParameterIndexing : ISearchParameterIndexing
  {
    private readonly Devices.IPyroFhirServer IPyroFhirServerDevice;
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly CodeSystems.IPyroTask IPyroTask;   
    private readonly Organizations.IPyroHealth IPyroHealthOrg;
    private readonly IGlobalProperties IGlobalProperties;

    public SearchParameterIndexing(Devices.IPyroFhirServer IPyroFhirServerDevice, 
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
      _ResourceId = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
    }
    
    private string _ResourceId;
    
    public string GetResourceId()
    {
      return _ResourceId;
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 10, 06, 16, 47, 00, new TimeSpan(8, 0, 0));

    public FhirModel.Task GetResource()
    {      
      var Resource = new FhirModel.Task();
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);      
      Resource.Meta.LastUpdated = MasterLastUpdated;
      
      //Task.Definition =??
      Resource.Status = FhirModel.Task.TaskStatus.Ready;
      Resource.Intent = FhirModel.Task.TaskIntent.Order;
      Resource.Priority = FhirModel.RequestPriority.Asap;

      Resource.Code = new FhirModel.CodeableConcept();
      
      FhirModel.Coding LoadFhirSpecResourcesTaskCoding = new FhirModel.Coding(IPyroTask.GetSystem(), IPyroTask.GetCode(CodeSystems.PyroTask.Codes.SearchParameterIndexing));
      Resource.Code.Coding.Add(LoadFhirSpecResourcesTaskCoding);

      Resource.Description = "This task is created to instigate a set of server indexes to be " +
          "created or updated based on a call to the operation 'server-indexes-index'. The task is created by this call and processed by a separate out of band service.";

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
      var DateTimeNow = DateTimeOffset.Now;
      Resource.AuthoredOn = new FhirModel.FhirDateTime(DateTimeNow).ToString();
      Resource.LastModified = new FhirModel.FhirDateTime(DateTimeNow).ToString();
      Resource.Requester = PyroHealthOrgReference;

      Resource.PerformerType = new List<FhirModel.CodeableConcept>();      
      var PerformerTypeCodeableConcept = new FhirModel.CodeableConcept();
      Resource.PerformerType.Add(PerformerTypeCodeableConcept);
      PerformerTypeCodeableConcept.Coding = new List<FhirModel.Coding>();
      var PerformerTypeCoding = new FhirModel.Coding();
      PerformerTypeCodeableConcept.Coding.Add(PerformerTypeCoding);
      PerformerTypeCoding.System = "http://hl7.org/fhir/task-performer-type";
      PerformerTypeCoding.Code = "performer";
      PerformerTypeCoding.Display = "Performer";

      Resource.Owner = PyroHealthOrgReference;
      Resource.ReasonCode = new FhirModel.CodeableConcept() { Text = "A FHIR Server indexing action is required." };
      Resource.Restriction = new FhirModel.Task.RestrictionComponent() { Repetitions = 0 };
      
      return Resource;
    }

  }
}
