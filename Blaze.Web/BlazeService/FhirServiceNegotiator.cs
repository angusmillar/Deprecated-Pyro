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

    public ICommonServices GetService()
    {
      return _Container.GetInstance<ICommonServices>();
    }

    public IBaseResourceServices GetService(string ResourceName)
    {
      Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);   
      if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
      { 
        //On adding new services remember to register the service interface with simple injector
        if(ResourceType == typeof(Patient))
        {
          return _Container.GetInstance<IPatientResourceServices>();
        }
        else
        {
          IDefaultResourceServices DefaultResourceServices = _Container.GetInstance<IDefaultResourceServices>();
          FHIRAllTypes FHIRAllTypes = (FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName);
          DefaultResourceServices.SetCurrentResourceType = FHIRAllTypes;
          return DefaultResourceServices;
        }                
      }
      else
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
        oIssueComponent.Code = OperationOutcome.IssueType.Invalid;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
        oIssueComponent.Details.Text = String.Format("The Resource name given '{0}' is not a Resource supported by the .net FHIR API Version: {1}.", ResourceName, ModelInfo.Version);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        throw new DtoBlazeException(HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);
       
      }
      
    }

  }
}
