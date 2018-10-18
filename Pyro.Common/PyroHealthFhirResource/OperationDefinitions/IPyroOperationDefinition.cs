using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthFhirResource.OperationDefinitions
{
  public interface IPyroOperationDefinition : IPyroResource
  {   
    Hl7.Fhir.Model.OperationDefinition GetResource();
    string GetCanonicalUrl();
  }
}
