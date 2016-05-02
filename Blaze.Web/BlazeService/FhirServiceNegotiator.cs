using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;
using System.Net;
using System.Net.Http;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Web.BlazeService
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

    public IBaseResourceServices GetService(string ResourceName)
    {
      if (Fhir.Model.ModelInfo.IsKnownResource(ResourceName))
      {
        var ResourceType = Fhir.Model.ModelInfo.GetTypeForResourceName(ResourceName);                
        if (DtoEnums.GetBlazeSupportedResorceType_ByTypeOf_FhirResourceDictionary.ContainsKey(ResourceType))
        {
          DtoEnums.SupportedFhirResource SupportedResource = DtoEnums.GetBlazeSupportedResorceType_ByTypeOf_FhirResourceDictionary[ResourceType];
          //On adding new services remember to register the service interface with simple injector
          switch (SupportedResource)
          {
            case DtoEnums.SupportedFhirResource.Patient:
              return _Container.GetInstance<IPatientResourceServices>();
            case DtoEnums.SupportedFhirResource.ValueSet:
              return _Container.GetInstance<IValueSetResourceServices>();
            case DtoEnums.SupportedFhirResource.ConceptMap:
              return _Container.GetInstance<IConceptMapResourceServices>();
            default:
              {
                IDefaultResourceServices DefaultResourceServices = _Container.GetInstance<IDefaultResourceServices>();
                DefaultResourceServices.SetCurrentResourceType = SupportedResource;
                return DefaultResourceServices;
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
