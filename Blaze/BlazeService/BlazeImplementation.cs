using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.BlazeService
{
  public static class BlazeImplementation
  {
    public static Dictionary<Type, SupportedFhirResource> SupportedFhirResourceTypeDictionary =
            new Dictionary<Type,SupportedFhirResource>()
            {
                { typeof(Patient),SupportedFhirResource.Patient },               
            };

    public enum SupportedFhirResource
    {
      Patient
    };
  }
}
