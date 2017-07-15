using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Utility;


namespace Pyro.Common.Tools
{
  public static class FhirOperationOutcomeSupport
  {
    public static OperationOutcome Generate(List<OperationOutcome.IssueComponent> IssueList)
    {
      var NarativeTextList = new List<string>();
      var OpOutCome = new OperationOutcome();
      OpOutCome.Issue = IssueList;
      OpOutCome.Meta = new Meta();
      OpOutCome.Meta.LastUpdated = DateTimeOffset.Now;
      return OpOutCome;
    }

    public static void EscapeOperationOutComeContent(OperationOutcome OpOutCome)
    {
      foreach (OperationOutcome.IssueComponent Issue in OpOutCome.Issue)
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

    public static OperationOutcome.IssueComponent CreateIssue(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message)
    {
      var Issue = new OperationOutcome.IssueComponent();
      Issue.Severity = IssueSeverity;
      Issue.Code = IssueType;
      Issue.Details = new CodeableConcept();
      Issue.Details.Text = Message;
      return Issue;
    }

    public static OperationOutcome Append(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message, OperationOutcome Exsisting = null)
    {
      return Append(IssueSeverity, IssueType, Message, null, Exsisting);
    }

    public static OperationOutcome Append(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message, ICollection<string> Location, OperationOutcome Exsisting = null)
    {
      //Todo: if I need to escape the messages then use this function below!!
      //XhtmlSupport.EncodeToString(Issue.Details.Text);
      if (Exsisting == null)
      {
        return Create(IssueSeverity, IssueType, Message);
      }
      else
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = IssueSeverity;
        if (IssueType.HasValue)
          oIssueComponent.Code = IssueType.Value;
        oIssueComponent.Location = Location;
        oIssueComponent.Details = new CodeableConcept();
        oIssueComponent.Details.Text = Message;
        if (Exsisting.Issue == null)
          Exsisting.Issue = new List<OperationOutcome.IssueComponent>();
        Exsisting.Issue.Add(oIssueComponent);
        return Exsisting;
      }
    }

    public static OperationOutcome Create(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message)
    {
      return Create(IssueSeverity, IssueType, Message, null);
    }

    public static OperationOutcome Create(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message, ICollection<string> Location)
    {
      var oIssueComponent = new OperationOutcome.IssueComponent();
      oIssueComponent.Severity = IssueSeverity;
      if (IssueType.HasValue)
        oIssueComponent.Code = IssueType.Value;
      oIssueComponent.Details = new CodeableConcept();
      oIssueComponent.Details.Text = Message;
      if (Location != null)
        oIssueComponent.Location = Location;
      var oOperationOutcome = new OperationOutcome();
      oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
      return oOperationOutcome;
    }

  }
}
