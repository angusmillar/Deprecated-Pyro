using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Hl7.Fhir.Model;

namespace Common.BusinessEntities
{  
  public class DtoBlazeException : Exception
  {
    public HttpStatusCode HttpStatusCode;
    public OperationOutcome OperationOutcome;

    public DtoBlazeException(HttpStatusCode statuscode, OperationOutcome OperationOutcome, string message)
      : base(message)
    {
      this.HttpStatusCode = statuscode;
      this.OperationOutcome = OperationOutcome;
    }

    public DtoBlazeException(HttpStatusCode statuscode, OperationOutcome OperationOutcome, string message, Exception inner)
      : base(message, inner)
    {
      this.HttpStatusCode = statuscode;
      this.OperationOutcome = OperationOutcome;
    }
  }
}
