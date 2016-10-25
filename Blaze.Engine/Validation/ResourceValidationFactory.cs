using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Interfaces;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Validation
{
  public static class ResourceValidationFactory
  {
    public static IResourceValidation GetValidationInstance(FHIRAllTypes FhirResourceType)
    {
      switch (FhirResourceType)
      {
        case FHIRAllTypes.Patient:
          return new PatientResourceValidation();
        case FHIRAllTypes.ValueSet:
          return new ValueSetResourceValidation();
        case FHIRAllTypes.ConceptMap:
          return new ConceptMapResourceValidation();
        default:
          return new DefaultResourceValidation();
          
      }
    }
  }
}
