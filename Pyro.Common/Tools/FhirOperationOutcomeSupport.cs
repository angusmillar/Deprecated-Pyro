using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;



namespace Pyro.Common.Tools
{
  public static class FhirOperationOutcomeSupport
  {
    public static OperationOutcome Generate(List<OperationOutcome.IssueComponent> IssueList)
    {
      if (IssueList.Count == 0)
        return null;

      var NarativeTextList = new List<string>();
      var OpOutCome = new OperationOutcome();
      foreach (var Issue in IssueList)
      {
        NarativeTextList.Add(ObtainNarrativeText(Issue));
        OpOutCome.Issue.Add(Issue);
      }
      OpOutCome.Text.Div = GenerateNarrative(NarativeTextList);
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
        Exsisting.Text = new Narrative();
        List<string> MessageList = new List<string>();
        Exsisting.Issue.ForEach(x => MessageList.Add(x.Details.Text));
        Exsisting.Text.Div = AppendNarrative(MessageList);
        return Exsisting;
      }
    }

    public static OperationOutcome Create(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message)
    {
      return Create(IssueSeverity, IssueType, Message, null);
    }

    public static OperationOutcome Create(OperationOutcome.IssueSeverity IssueSeverity, OperationOutcome.IssueType? IssueType, string Message, ICollection<string> Location)
    {
      //Todo: if I need to escape the messages then use this function below!!
      //XhtmlSupport.EncodeToString(Issue.Details.Text);

      var oIssueComponent = new OperationOutcome.IssueComponent();
      oIssueComponent.Severity = IssueSeverity;
      if (IssueType.HasValue)
        oIssueComponent.Code = IssueType.Value;
      oIssueComponent.Details = new CodeableConcept();
      oIssueComponent.Details.Text = Message;
      oIssueComponent.Location = Location;
      var oOperationOutcome = new OperationOutcome();
      oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
      oOperationOutcome.Text = new Narrative();
      oOperationOutcome.Text.Div = ConstructNarrative(Message, oIssueComponent.Severity, IssueType.Value);
      return oOperationOutcome;
    }

    private static string ObtainNarrativeText(OperationOutcome.IssueComponent Issue)
    {
      if (Issue.Details != null && !string.IsNullOrWhiteSpace(Issue.Details.Text))
      {
        return Issue.Details.Text;
      }
      else if (!string.IsNullOrWhiteSpace(Issue.Diagnostics))
      {
        return Issue.Diagnostics;
      }
      else if (Issue.Details != null && Issue.Details.Coding != null && Issue.Details.Coding.Count > 0)
      {
        var Text = new StringBuilder();
        foreach (var item in Issue.Details.Coding)
        {
          if (string.IsNullOrWhiteSpace(item.Display))
            Text.AppendLine(item.Display);
        }
        return Text.ToString();
      }
      else
      {
        throw new Exception("Server Error: No narrative text could be formed for an Operation Outcome.");
      }
    }

    private static string GenerateNarrative(List<string> NarrativeList)
    {
      StringBuilder NarrativeString = new StringBuilder();
      NarrativeString.AppendLine("<div xmlns=\"http://www.w3.org/1999/xhtml\">");
      foreach (var Text in NarrativeList)
      {
        NarrativeString.Append("<p>");
        NarrativeString.Append(System.Security.SecurityElement.Escape(Text.Replace(System.Environment.NewLine, "</br>")));
        NarrativeString.Append("</p>");
      }
      NarrativeString.Append("</div>");
      return NarrativeString.ToString();
    }

    private static string ConstructNarrative(string Message, OperationOutcome.IssueSeverity? IssueSeverity, OperationOutcome.IssueType? IssueType)
    {
      var NarativeSupport = Common.CommonFactory.GetFhirNarativeSupport();

      if (IssueSeverity.HasValue)
        NarativeSupport.NewValuePairList("IssueSeverity", IssueSeverity.Value.GetLiteral(), "Status", 4);
      if (IssueType.HasValue)
        NarativeSupport.AppendValuePairList("IssueType", IssueType.Value.GetLiteral());

      NarativeSupport.NewParagraph(Message, "Message", 4);
      return NarativeSupport.Generate();
    }

    private static string AppendNarrative(ICollection<string> MessageList)
    {
      var XDoc = new XmlDocument();
      var Xroot = XDoc.CreateElement("div");
      var xmlns = XDoc.CreateAttribute("xmlns");
      xmlns.Value = "http://www.w3.org/1999/xhtml";
      Xroot.SetAttributeNode(xmlns);
      XDoc.AppendChild(Xroot);
      foreach (string Message in MessageList)
      {
        var MessageHtml = XDoc.CreateElement("p");
        Xroot.AppendChild(MessageHtml);
        var ReasonTitle = XDoc.CreateElement("b");
        ReasonTitle.AppendChild(XDoc.CreateTextNode("Reason: "));
        MessageHtml.AppendChild(ReasonTitle);
        var normal = MessageHtml.AppendChild(XDoc.CreateTextNode(Message));
        MessageHtml.AppendChild(normal);
      }
      return XDoc.OuterXml;
    }

  }
}
