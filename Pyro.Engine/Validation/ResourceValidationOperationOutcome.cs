using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using System.Net;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.Validation
{
  public class ResourceValidationOperationOutcome : IResourceValidationOperationOutcome
  {
    public bool HasError
    {
      get
      {
        if (this.FhirOperationOutcome == null)
          return false;
        else
          return true;
      }

    }
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
  }
}
