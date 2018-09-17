using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hl7.Fhir.Model.ModelInfo;

namespace Pyro.Common.Tools.FhirSpecCorrections
{
  public class FhirSpecificationCorrections : IFhirSpecificationCorrections
  {
    private string CorrectedAuditEventPatientExpression = "AuditEvent.entity.what.where(reference.startsWith('Patient/') or reference.contains('/Patient/')) | AuditEvent.agent.who.where(reference.startsWith('Patient/') or reference.contains('/Patient/'))";

    public void SearchParameterCorrections(SearchParamDefinition SearchParamDefinition)
    {
      if (SearchParamDefinition.Name == "patient" && SearchParamDefinition.Resource == ResourceType.AuditEvent.GetLiteral())
      {
        SearchParamDefinition.Expression = CorrectedAuditEventPatientExpression;
      }
    }


    public void SearchParameterCorrections(SearchParameter SearchParameter)
    {
      //################################################################################################
      //This is an correction to the FHIR specification SearchParameter definitions found in the  
      //definitions.xml.zip file required for STU3, I believe it is fixed in R4 and it should be removed once tested that it is not hit.
      string IncorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/Observation-code";
      string CorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/clinical-code";
      var BrokenComponetList = SearchParameter.Component.Where(z => z.Definition == IncorrectCanonicalUrl);
      foreach (var BrokenComponet in BrokenComponetList)
      {
        BrokenComponet.Definition = CorrectCanonicalUrl;
      }

      //################################################################################################
      //This FHIRPath expression fails to work and yet this correct does work, issues found in FHRI R4 3.5.0.
      //The old Expression was :
      //Expression = AuditEvent.agent.who.where(resolve() is Patient) | AuditEvent.entity.what.where(resolve() is Patient)
      if (SearchParameter.Name == "patient" && SearchParameter.Base.Contains(ResourceType.AuditEvent))
      {
        SearchParameter.Expression = CorrectedAuditEventPatientExpression;
      }
    }
  }
}
