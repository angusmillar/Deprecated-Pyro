using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Blaze.Engine.CustomException;

namespace Blaze.Engine.CustomException
{
  public class FhirExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(HttpActionExecutedContext context)
    {
      HttpResponseMessage response;

      if (context.Exception is BlazeException)
      {
        var e = (BlazeException)context.Exception;
        response = context.Request.CreateResponse(e.StatusCode, e.Message);
      }      
      else
      {
        response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
      }

      throw new HttpResponseException(response);
    }
  }
}
