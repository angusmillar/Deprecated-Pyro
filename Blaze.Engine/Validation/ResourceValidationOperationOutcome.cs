using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using System.Net;
using Blaze.Common.Interfaces;

namespace Blaze.Engine.Validation
{
  public class ResourceValidationOperationOutcome : IResourceValidationOperationOutcome
  {
    public bool HasError
    {
      get
      {
        if (this.FhieOperationOutcome == null)
          return false;
        else
          return true;
      }

    }
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhieOperationOutcome { get; set; }
  }
}
