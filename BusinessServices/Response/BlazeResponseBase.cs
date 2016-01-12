using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Response
{
  public abstract class BlazeResponseBase
  {
    public bool HasError
    {
      get
      {
        if (this.OperationOutcome != null)
          return true;
        else
          return false;
      }
    }
    public void AddOperationOutcomeIssue(OperationOutcome.IssueComponent item, System.Net.HttpStatusCode HttpStatusCode)
    {
      this.HttpStatusCode = HttpStatusCode;
      if (this.OperationOutcome == null)
      {
        this.OperationOutcome = new OperationOutcome();
        this.OperationOutcome.Issue = new List<OperationOutcome.IssueComponent>();
      }
      this.OperationOutcome.Issue.Add(item);
    }    
    public System.Net.HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome OperationOutcome { get; set; }
    public BlazeResponseBase()
    {
      this.HttpStatusCode = System.Net.HttpStatusCode.OK;
    }
    public abstract Resource ResourceToReturn();
  }
}
