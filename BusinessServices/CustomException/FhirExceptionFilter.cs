using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using BusinessEntities;

namespace Blaze.Engine.CustomException
{
  public class FhirExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(HttpActionExecutedContext context)
    {
      HttpResponseMessage response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.ToString());

      if (context.Exception is DtoBlazeException)
      {
        var oDtoBlazeException = (DtoBlazeException)context.Exception;
        if (oDtoBlazeException.OperationOutcome != null)
          response = context.Request.CreateResponse(oDtoBlazeException.HttpStatusCode, oDtoBlazeException.OperationOutcome);
        else
          response = context.Request.CreateResponse(oDtoBlazeException.HttpStatusCode, oDtoBlazeException.Message);
      }
      else if (context.Exception is System.Data.UpdateException)
      {
        if (context.Exception.InnerException is SqlException)
        {
          DtoBlazeException oDtoBlazeException = SqlExceptionSupport.GenerateDtoBlazeException((SqlException)context.Exception.InnerException);
          response = context.Request.CreateResponse(oDtoBlazeException.HttpStatusCode, oDtoBlazeException.OperationOutcome);
        }
      }      
      
      throw new HttpResponseException(response);
    }
  }
}
