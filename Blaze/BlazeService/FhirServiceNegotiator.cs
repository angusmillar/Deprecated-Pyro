using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;
using System.Net;
using System.Net.Http;
using Dip.Interfaces.Services;
using BusinessEntities;
using Hl7.Fhir.Model;

namespace Blaze.BlazeService
{  
  /// <summary>
  /// Negotiates the required Resource server based on the Resource name provided 
  /// </summary>
  public class FhirServiceNegotiator : IFhirServiceNegotiator
  {
    private readonly SimpleInjector.Container _Container = null;

    public FhirServiceNegotiator(SimpleInjector.Container Container)
    {
      _Container = Container;
    }

    public  IBaseResourceServices GetService(string ResourceName)
    {
      if (Fhir.Model.ModelInfo.IsKnownResource(ResourceName))
      {
        var ResourceType = Fhir.Model.ModelInfo.GetTypeForResourceName(ResourceName);
        if (BlazeImplementation.SupportedFhirResourceTypeDictionary.ContainsKey(ResourceType))
        {
          BlazeImplementation.SupportedFhirResource SupportedResource = BlazeImplementation.SupportedFhirResourceTypeDictionary[ResourceType];
          //On adding new services remember to register the service interface with simple injector
          switch (SupportedResource)
          {
            case BlazeImplementation.SupportedFhirResource.Patient:
              return _Container.GetInstance<IPatientResourceServices>();
            case BlazeImplementation.SupportedFhirResource.ValueSet:
              return _Container.GetInstance<IValueSetResourceServices>();              
            default:
              {
                var oIssueComponent = new OperationOutcome.IssueComponent();
                oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
                oIssueComponent.Code = OperationOutcome.IssueType.Exception;
                oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_NO_MODULE", String.Format("No module could be found to handle the request for Resource: '{0}'", ResourceName));
                oIssueComponent.Details.Text = String.Format("Internal Server Error, The server believes it supports the resource type '{0}' yet has no resource service to act on the resource", ResourceName);
                oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
                var oOperationOutcome = new OperationOutcome();
                oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
                throw new DtoBlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
              }
          }
        }
        else
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
          oIssueComponent.Details.Text = String.Format("The Fhir Resource is not currently supported by the Blaze server. Resource type was: {0}", ResourceName);
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new DtoBlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
        }
      }
      else
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
        oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
        oIssueComponent.Details.Text = String.Format("The Resource name given '{0}' is not a Resource supported by DSTU2.", ResourceName);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        throw new DtoBlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);                     
      }
    }

  }
}
