using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Engine.Interfaces;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Validation
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
