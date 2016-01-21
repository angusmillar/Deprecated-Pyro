using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Support.ExtensionMethods
{
  public static class OperationOutcomeExtensionMethods
  {
    public static void GenerateNarrative(this OperationOutcome oOperationOutcome)
    {
      if (oOperationOutcome == null)
        throw new NullReferenceException("OperationOutcome cannot be null for extension method GenerateNarrative");
      if (oOperationOutcome.Issue == null)
        throw new NullReferenceException("OperationOutcome.Issue cannot be null for extension method GenerateNarrative");
      if (oOperationOutcome.Issue.Count == 0)
        throw new NullReferenceException("OperationOutcome.Issue.Count cannot be zero for extension method GenerateNarrative");

      string Narrative = string.Empty;
      foreach(var item in oOperationOutcome.Issue)
      {
        if (item.Details != null)
          Narrative += "    " + item.Details.Text;
        else if (String.IsNullOrWhiteSpace(item.Diagnostics))
          Narrative += "    " + item.Diagnostics;
      }
      oOperationOutcome.Text = new Hl7.Fhir.Model.Narrative();
      oOperationOutcome.Text.Status = Hl7.Fhir.Model.Narrative.NarrativeStatus.Generated;      
      oOperationOutcome.Text.Div = Support.XhtmlSupport.EncodeToDiv(Narrative);            
    }
  }
}
