using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Hl7.Fhir.Model;

namespace Common.BusinessEntities
{
  public class DtoDataBaseExceptionInfomation
  {
    public HttpStatusCode HttpStatusCode { get; set; }
    public string ErrorMessage { get; set; }
    public OperationOutcome OperationOutcome { get; set; }
  }
}
