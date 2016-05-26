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
    public static IResourceValidation GetValidationInstance(FHIRDefinedType FhirResourceType)
    {
      switch (FhirResourceType)
      {
        case FHIRDefinedType.Patient:
          return new PatientResourceValidation();
        case FHIRDefinedType.ValueSet:
          return new ValueSetResourceValidation();
        case FHIRDefinedType.ConceptMap:
          return new ConceptMapResourceValidation();
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(FhirResourceType.ToString(), (int)FhirResourceType, typeof(FHIRDefinedType));
      }
    }
  }
}
