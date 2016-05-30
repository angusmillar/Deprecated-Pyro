using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
  public class DefaultResourceValidation : Interfaces.IResourceValidation
  {

    public IResourceValidationOperationOutcome Validate(Resource Resource)
    {
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();

      //StartChecking the Patient Resource

      
      //ToDo: What do we need to check as a base resource?

      return oResourceValidationOperationOutcome;
    }

  }
}
