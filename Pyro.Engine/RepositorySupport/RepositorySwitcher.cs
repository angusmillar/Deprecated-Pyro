using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.BusinessEntities.Dto;
using System.Net;

namespace Pyro.Engine.RepositorySupport
{
  static class RepositorySwitcher
  {
    public static IResourceRepository GetRepository(FHIRAllTypes ResourceType, IUnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        case FHIRAllTypes.Patient:
            return UnitOfWork.PatientRepository;
        case FHIRAllTypes.Observation:
          return UnitOfWork.ObservationRepository;
        default:
          {
            string Message = $"The Resource name given: '{ResourceType.GetLiteral()}' has no matching server repository. ";
            var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, Message);
            throw new DtoPyroException(HttpStatusCode.BadRequest, OpOutCome, Message);
          }          
      }      
    }
  }
}

