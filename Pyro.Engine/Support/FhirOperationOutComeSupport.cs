using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Support
{
  public static class FhirOperationOutComeSupport
  {
    public static void EscapeOperationOutComeContent(OperationOutcome OpOutCome)
    {
      foreach(OperationOutcome.IssueComponent Issue in OpOutCome.Issue)
      {
        Issue.Diagnostics = XhtmlSupport.EncodeToString(Issue.Diagnostics);
        
        if (Issue.Details != null)
        {
          Issue.Details.Text = XhtmlSupport.EncodeToString(Issue.Details.Text);
          foreach (Coding Code in Issue.Details.Coding)
          {
            Code.Display = XhtmlSupport.EncodeToString(Code.Display);
          }
        }
        var EscapedLocation = new List<string>();
        if (Issue.Location != null)
        {
          foreach (var Location in Issue.Location)
          {
            EscapedLocation.Add(XhtmlSupport.EncodeToString(Location));
          }
          Issue.Location = EscapedLocation;
        }
       }
    }
  }
}
