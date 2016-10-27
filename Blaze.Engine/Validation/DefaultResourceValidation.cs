using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
  public class DefaultResourceValidation : BaseResourceValidation, Interfaces.IResourceValidation
  {

    public IResourceValidationOperationOutcome Validate(Resource Resource)
    {
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = new ResourceValidationOperationOutcome();
      this.ValidateBaseResource(Resource, oResourceValidationOperationOutcome);
      return oResourceValidationOperationOutcome;
    }

  }
}
