using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
  public interface IResourceValidationOperationOutcome
  {
    bool HasError { get; }     
    Hl7.Fhir.Model.OperationOutcome FhieOperationOutcome { get; set; }    
    System.Net.HttpStatusCode HttpStatusCode { get; set; }
  }
}
