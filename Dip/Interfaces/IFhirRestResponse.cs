using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Interfaces
{
  public interface IFhirRestResponse
  {
    string ErrorMessage { get; set; }
    string FhirResourceId { get; set; }
    System.Net.Http.HttpResponseMessage GetHttpResponseMessage(System.Net.Http.HttpRequestMessage request);
    DateTimeOffset? LastModified { get; set; }
    Hl7.Fhir.Model.Resource Resource { get; set; }
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
    int Version { get; set; }
  }
}
