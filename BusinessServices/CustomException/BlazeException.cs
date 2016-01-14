using System;
using System.Net;
using Hl7.Fhir.Model;

namespace Blaze.Engine.CustomException
{
  public class BlazeException : Exception
  {
    public HttpStatusCode HttpStatusCode;
    public OperationOutcome OperationOutcome;

    public BlazeException(HttpStatusCode statuscode, OperationOutcome OperationOutcome, string message)
      : base(message)
    {
      this.HttpStatusCode = statuscode;
      this.OperationOutcome = OperationOutcome;
    }

    public BlazeException(HttpStatusCode statuscode, OperationOutcome OperationOutcome, string message, Exception inner)
      : base(message, inner)
    {
      this.HttpStatusCode = statuscode;
      this.OperationOutcome = OperationOutcome;
    }
  }
}
