using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities;

namespace Blaze
{
  public static class BlazeImplementation
  {
    public static Dictionary<Type, DtoEnums.SupportedFhirResource> SupportedFhirResourceTypeDictionary =
            new Dictionary<Type, DtoEnums.SupportedFhirResource>()
            {
                { typeof(Patient),DtoEnums.SupportedFhirResource.Patient },  
                { typeof(ValueSet),DtoEnums.SupportedFhirResource.ValueSet }  
            };

    
  }
}
