using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Support.ExtensionMethods;

namespace Blaze.Engine.Search
{
  public class SearchTerms : Response.BlazeResponseBase
  {
    public Hl7.Fhir.Model.ResourceType ResourceTarget { get; set; }
    public List<SearchTermTypes.SearchTermBase> SearchTermList { get; set; }
    public override Resource ResourceToReturn()
    {
      if (this.HasError)
      {
        this.OperationOutcome.GenerateNarrative();
        return this.OperationOutcome;
      }
      else
      {
        return null;
      }
    }
  }
}
