using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.Common.Tools.FhirNarrative
{
  public class FhirResourceNarrative : IFhirResourceNarrative
  {
    private readonly IHtmlGenerationSupport IHtmlGenerationSupport;
    public FhirResourceNarrative(IHtmlGenerationSupport IHtmlGenerationSupport)
    {
      this.IHtmlGenerationSupport = IHtmlGenerationSupport;
    }

    public void CreateNarrative(OperationOutcome value)
    {
      if (value.Text == null || string.IsNullOrWhiteSpace(value.Text.Div))
      {
        int IssueCounter = 0;
        foreach (var Issue in value.Issue)
        {
          IssueCounter++;
          IHtmlGenerationSupport.NewValuePairList("", "", "OperationOutcome Issue: " + IssueCounter.ToString(), 4);
          if (Issue.Severity.HasValue)
            IHtmlGenerationSupport.AppendValuePairList("Severity", Issue.Severity.Value.GetLiteral());
          if (Issue.Code.HasValue)
            IHtmlGenerationSupport.AppendValuePairList("Type", Issue.Code.GetLiteral());
          if (Issue.Details != null)
          {
            if (!string.IsNullOrWhiteSpace(Issue.Details.Text))
            {
              IHtmlGenerationSupport.AppendValuePairList("Detail Text", Issue.Details.Text);
            }
            if (Issue.Details.Coding != null)
            {
              foreach (var Code in Issue.Details.Coding)
              {
                if (!string.IsNullOrWhiteSpace(Code.Display))
                {
                  IHtmlGenerationSupport.AppendValuePairList("Code Display", $"{Code.Display}");
                }

                if (!string.IsNullOrWhiteSpace(Code.Code) && !string.IsNullOrWhiteSpace(Code.System))
                {
                  IHtmlGenerationSupport.AppendValuePairList("Code & System", $"{Code.Code} : {Code.System}");
                }
                else if (!string.IsNullOrWhiteSpace(Code.Code))
                {
                  IHtmlGenerationSupport.AppendValuePairList("Code", $"{Code.Code}");
                }

              }
            }
          }

          if (!string.IsNullOrWhiteSpace(Issue.Diagnostics))
            IHtmlGenerationSupport.AppendValuePairList("Diagnostics", Issue.Diagnostics);
          if (Issue.Location != null && Issue.Location.Count() > 0)
          {
            foreach (var Loc in Issue.Location)
              IHtmlGenerationSupport.AppendValuePairList("Location", Loc);
          }
          if (Issue.Expression != null && Issue.Expression.Count() > 0)
          {
            foreach (var Exp in Issue.Location)
              IHtmlGenerationSupport.AppendValuePairList("Expression", Exp);
          }
        }
        value.Text = new Narrative();
        value.Text.Div = IHtmlGenerationSupport.Generate();
        value.Text.Status = Narrative.NarrativeStatus.Generated;
      }
    }

  }
}
