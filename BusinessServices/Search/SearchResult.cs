using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Support.ExtensionMethods;

namespace Blaze.Engine.Search
{
  public class SearchResult : Response.BlazeResponseBase
  {
    public Bundle FhirBundle { get; set; }
    public override Resource ResourceToReturn()
    {
      if (this.HasError)
      {
        this.OperationOutcome.GenerateNarrative();
        return this.OperationOutcome;
      }
      else
      {
        return this.FhirBundle;
      }
    }
  }
}
