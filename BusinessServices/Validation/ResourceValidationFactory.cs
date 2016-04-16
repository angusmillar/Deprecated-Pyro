using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Interfaces;
using Common.BusinessEntities;

namespace Blaze.Engine.Validation
{
  public static class ResourceValidationFactory
  {
    public static IResourceValidation GetValidationInstance(DtoEnums.SupportedFhirResource SupportedFhirResource)
    {
      switch (SupportedFhirResource)
      {
        case DtoEnums.SupportedFhirResource.Patient:
          return new PatientResourceValidation();
        case DtoEnums.SupportedFhirResource.ValueSet:
          return new ValueSetResourceValidation();
        case DtoEnums.SupportedFhirResource.ConceptMap:
          return new ConceptMapResourceValidation();
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SupportedFhirResource.ToString(), (int)SupportedFhirResource,typeof(DtoEnums.SupportedFhirResource));
      }
    }
  }
}
