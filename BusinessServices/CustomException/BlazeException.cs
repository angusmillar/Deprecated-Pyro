using System;
using System.Net;

namespace Blaze.Engine.CustomException
{
  public class BlazeException : Exception
  {
    public HttpStatusCode StatusCode;

    public BlazeException(HttpStatusCode statuscode, string message)
      : base(message)
    {
      this.StatusCode = statuscode;
    }

    public BlazeException(HttpStatusCode statuscode, string message, Exception inner)
      : base(message, inner)
    {
      this.StatusCode = statuscode;
    }
  }
}
