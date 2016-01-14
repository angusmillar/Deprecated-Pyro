using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Support.ExtensionMethods;


namespace Blaze.Engine.Validation
{
  public class ValidationResult : Response.BlazeResponseBase
  {
    public override Hl7.Fhir.Model.Resource ResourceToReturn()
    {
      if (this.HasError)
      {        
        this.OperationOutcome.GenerateNarrative();
        return this.OperationOutcome;
      }
      return null;      
    }
  }
}
