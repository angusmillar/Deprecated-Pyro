using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;
using System.Net;
using System.Net.Http;
using Blaze.Engine.Response;
using Blaze.Engine.CustomException;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Services
{
  public class FhirServiceNegotiator : Interfaces.IFhirServiceNegotiator
  {
    private Interfaces.IResourceServices FhirService = null;

    private Interfaces.IResourceServices GetResourceService(string type)
    {
      if (Fhir.Model.ModelInfo.IsKnownResource(type))
      {
        var ResourceType = Fhir.Model.ModelInfo.GetTypeForResourceName(type);
        if (BlazeImplementation.SupportedFhirResourceTypeDictionary.ContainsKey(ResourceType))
        {
          BlazeImplementation.SupportedFhirResource SupportedResource = BlazeImplementation.SupportedFhirResourceTypeDictionary[ResourceType];
          switch (SupportedResource)
          {
            case BlazeImplementation.SupportedFhirResource.Patient:
              return new PatientResourceServices();
            default:
              {
                var oIssueComponent = new OperationOutcome.IssueComponent();
                oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
                oIssueComponent.Code = OperationOutcome.IssueType.Exception;
                oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_NO_MODULE", String.Format("No module could be found to handle the request for Resource: '{0}'", type));
                oIssueComponent.Details.Text = String.Format("Internal Server Error, The server believes it supports the resource type '{0}' yet has no resource service to act on the resource", type);
                oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
                var oOperationOutcome = new OperationOutcome();
                oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
                throw new BlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
              }
          }
        }
        else
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", type));
          oIssueComponent.Details.Text = String.Format("The Fhir Resource is not currently supported by the Blaze server. Resource type was: {0}", type);
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new BlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
        }
      }
      else
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
        oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", type));
        oIssueComponent.Details.Text = String.Format("The Resource name given '{0}' is not a Resource supported by DSTU2.", type);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        throw new BlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);                     
      }
    }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    public FhirRestResponse Get(string type, string FhirResourceId)
    {
      FhirService = this.GetResourceService(type);  
      return FhirService.Get(FhirResourceId);
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    public FhirRestResponse Get(string type, Uri uri, Fhir.Rest.SearchParams searchParams)
    {     
      FhirService = this.GetResourceService(type); 
      return FhirService.Get(uri, searchParams);
    }

    // Add
    // POST: URL/FhirApi/Patient
    public FhirRestResponse Post(string type, Fhir.Model.Resource FhirResource)
    {
      FhirService = this.GetResourceService(type);
      return FhirService.Post(FhirResource);
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public FhirRestResponse Put(string type, string FhirResourceId, Fhir.Model.Resource FhirResource)
    {     
      FhirService = this.GetResourceService(type);
      return FhirService.Put(FhirResourceId, FhirResource);
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public FhirRestResponse Delete(string type, string FhirResourceId)
    {
      FhirService = this.GetResourceService(type);
      return FhirService.Delete(FhirResourceId);
    }

  }
}
