using Pyro.Common.Global;
using System;
using System.Collections.Generic;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.OperationDefinitions
{
  //This class represents the creation of a FHIR OperationDefinitions resource where that   
  public class ServerIndexesIndex : IPyroOperationDefinition, IServerIndexesIndex
  {    
    private readonly CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
   
    public ServerIndexesIndex(CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {    
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    public static string ResourceId = "server-indexes-index";
    public static string CanonicalUrl = "https://pyrohealth.net/fhir/OperationDefinition/server-indexes-index";
    
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
      Resource.Name = "Server Indexes Index";
      Resource.Status = FhirModel.PublicationStatus.Active;
      Resource.Kind = FhirModel.OperationDefinition.OperationKind.Operation;
      Resource.Date = (new Hl7.Fhir.Model.FhirDateTime(MasterLastUpdated)).Value;
      Resource.Publisher = "PyroHealth";
      var AngusContactDetail = Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      Resource.Contact = new List<FhirModel.ContactDetail>() { AngusContactDetail };
      Resource.Description = new FhirModel.Markdown() { Value = "FHIR Server operation to set a FHIR SearchParameter resource in placed to become an active search index in the Pyro FHIR Server" };
      Resource.Code = "server-indexes-set";
      Resource.Comment = new FhirModel.Markdown() { Value = "This operation loads or sets a FHIR SearchParameter resource into the Pyro FHIR Server search parameter index table in preparation to be processed. Once set the operation named $server-indexes-index is required to be called to perform the resource indexing to make the new search parameter available for clients to search upon via the server&apos;s FHIR API. This is how custom search parameters can be added to the server." };
      Resource.System = true;
      Resource.Type = false;
      Resource.Instance = false;
      Resource.Parameter = new List<FhirModel.OperationDefinition.ParameterComponent>()
      {
        new FhirModel.OperationDefinition.ParameterComponent()
        {
           Name = "SearchParameter",
           Use = FhirModel.OperationParameterUse.In,
           Min = 1,
           Max = "*",
           Documentation = "The SearchParameter resource Reference where that resource and reference must be located within the same server instance to that where the operation is being called. The reference can be relative or absolute, however, absolute references must be to the same server instance that the operation is being called against.",
           Type = FhirModel.FHIRAllTypes.Reference,
        },
        new FhirModel.OperationDefinition.ParameterComponent()
        {
           Name = "SearchParameterRegisteredForIndexing",
           Use = FhirModel.OperationParameterUse.Out,
           Min = 1,
           Max = "*",
           Documentation = "The SearchParameter resource instance that has been set in the server&apos;s search parameter index table for indexing.",
           Type = FhirModel.FHIRAllTypes.SearchParameter,
        }
      };

      return Resource;
    }

  }
}
