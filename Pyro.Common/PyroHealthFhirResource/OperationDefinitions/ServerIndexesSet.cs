using Pyro.Common.Global;
using System;
using System.Collections.Generic;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.OperationDefinitions
{
  //This class represents the creation of a FHIR OperationDefinitions resource where that   
  public class ServerIndexesSet : IPyroOperationDefinition, IServerIndexesSet
  {    
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
   
    public ServerIndexesSet(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {    
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    public static string ResourceId = "server-indexes-set";
    public static string CanonicalUrl = "https://pyrohealth.net/fhir/OperationDefinition/server-indexes-set";
    
    public string GetCanonicalUrl()
    {
      return CanonicalUrl;
    }

    public string GetResourceId()
    {
      return ResourceId;
    }

    public DateTimeOffset MasterLastUpdated => new DateTimeOffset(2018, 10, 16, 18, 00, 00, new TimeSpan(8, 0, 0));

    public FhirModel.OperationDefinition GetResource()
    {      
      var Resource = new FhirModel.OperationDefinition();
      Resource.Id = GetResourceId();
      IPyroFhirServerCodeSystem.SetProtectedMetaTag(Resource);
      Resource.Meta.LastUpdated = MasterLastUpdated;
      Resource.Url = CanonicalUrl;
      Resource.Version = "1.00";
      Resource.Name = "Server Indexes Set";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Kind = FhirModel.OperationDefinition.OperationKind.Operation;
      Resource.Date = (new Hl7.Fhir.Model.FhirDateTime(MasterLastUpdated)).Value;
      Resource.Publisher = "PyroHealth";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown() { Value = "FHIR Server operation to index the SearchParameter resources that have been set via the operation $server-indexes-set. This operation sets off a background task that works through all the server&apos;s FHIR resources indexing the new SearchParameters that have been set." };
      Resource.Code = "server-indexes-set";
      Resource.Comment = new FhirModel.Markdown() { Value = "This operation searches for any modified or new search indexes that have been earlier set in the server by calling the operation $server-indexes-set. The operation will set off a background task to perform the work of indexing these search parameters. The operation will return immediately a Task resource that has been created and loaded into the server by this call. The Task manages the background process work. You can monitor the progress of the background work by inspecting the Task resource. For instance, perform a Get on its resource Id. The Task status will be set to In-Progress and then Completed once finished. This operation requires no parameter resource to run." };
      Resource.System = true;
      Resource.Type = false;
      Resource.Instance = false;
      Resource.Parameter = new List<FhirModel.OperationDefinition.ParameterComponent>()
      {       
        new FhirModel.OperationDefinition.ParameterComponent()
        {
           Name = "BackgroundIndexingTask",
           Use = FhirModel.OperationParameterUse.Out,
           Min = 1,
           Max = "1",
           Documentation = "The FHIR Task that manages the background worker process and reports it progress.",
           Type = FhirModel.FHIRAllTypes.Task,
        }
      };

      return Resource;
    }

  }
}
