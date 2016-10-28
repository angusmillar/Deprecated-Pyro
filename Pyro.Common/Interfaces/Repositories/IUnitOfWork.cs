using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IUnitOfWork
  {
    IDtoCommonRepository CommonRepository { get; }
    IResourceRepository AccountRepository { get; }    
    IResourceRepository ActivityDefinitionRepository { get; }    
    IResourceRepository AllergyIntoleranceRepository { get; }    
    IResourceRepository AppointmentRepository { get; }    
    IResourceRepository AppointmentResponseRepository { get; }    
    IResourceRepository AuditEventRepository { get; }    
    IResourceRepository BasicRepository { get; }    
    IResourceRepository BinaryRepository { get; }    
    IResourceRepository BodySiteRepository { get; }    
    IResourceRepository BundleRepository { get; }    
    IResourceRepository CarePlanRepository { get; }    
    IResourceRepository CareTeamRepository { get; }    
    IResourceRepository ClaimRepository { get; }    
    IResourceRepository ClaimResponseRepository { get; }    
    IResourceRepository ClinicalImpressionRepository { get; }    
    IResourceRepository CodeSystemRepository { get; }    
    IResourceRepository CommunicationRepository { get; }    
    IResourceRepository CommunicationRequestRepository { get; }    
    IResourceRepository CompartmentDefinitionRepository { get; }    
    IResourceRepository CompositionRepository { get; }    
    IResourceRepository ConceptMapRepository { get; }    
    IResourceRepository ConditionRepository { get; }    
    IResourceRepository ConformanceRepository { get; }    
    IResourceRepository ConsentRepository { get; }    
    IResourceRepository ContractRepository { get; }    
    IResourceRepository CoverageRepository { get; }    
    IResourceRepository DataElementRepository { get; }    
    IResourceRepository DecisionSupportServiceModuleRepository { get; }    
    IResourceRepository DetectedIssueRepository { get; }    
    IResourceRepository DeviceRepository { get; }    
    IResourceRepository DeviceComponentRepository { get; }    
    IResourceRepository DeviceMetricRepository { get; }    
    IResourceRepository DeviceUseRequestRepository { get; }    
    IResourceRepository DeviceUseStatementRepository { get; }    
    IResourceRepository DiagnosticReportRepository { get; }    
    IResourceRepository DiagnosticRequestRepository { get; }    
    IResourceRepository DocumentManifestRepository { get; }    
    IResourceRepository DocumentReferenceRepository { get; }    
    IResourceRepository EligibilityRequestRepository { get; }    
    IResourceRepository EligibilityResponseRepository { get; }    
    IResourceRepository EncounterRepository { get; }    
    IResourceRepository EndpointRepository { get; }    
    IResourceRepository EnrollmentRequestRepository { get; }    
    IResourceRepository EnrollmentResponseRepository { get; }    
    IResourceRepository EpisodeOfCareRepository { get; }    
    IResourceRepository ExpansionProfileRepository { get; }    
    IResourceRepository ExplanationOfBenefitRepository { get; }    
    IResourceRepository FamilyMemberHistoryRepository { get; }    
    IResourceRepository FlagRepository { get; }    
    IResourceRepository GoalRepository { get; }    
    IResourceRepository GroupRepository { get; }    
    IResourceRepository GuidanceResponseRepository { get; }    
    IResourceRepository HealthcareServiceRepository { get; }    
    IResourceRepository ImagingManifestRepository { get; }    
    IResourceRepository ImagingStudyRepository { get; }    
    IResourceRepository ImmunizationRepository { get; }    
    IResourceRepository ImmunizationRecommendationRepository { get; }    
    IResourceRepository ImplementationGuideRepository { get; }    
    IResourceRepository LibraryRepository { get; }    
    IResourceRepository LinkageRepository { get; }    
    IResourceRepository ListRepository { get; }    
    IResourceRepository LocationRepository { get; }    
    IResourceRepository MeasureRepository { get; }    
    IResourceRepository MeasureReportRepository { get; }    
    IResourceRepository MediaRepository { get; }    
    IResourceRepository MedicationRepository { get; }    
    IResourceRepository MedicationAdministrationRepository { get; }    
    IResourceRepository MedicationDispenseRepository { get; }    
    IResourceRepository MedicationOrderRepository { get; }    
    IResourceRepository MedicationStatementRepository { get; }    
    IResourceRepository MessageHeaderRepository { get; }    
    IResourceRepository NamingSystemRepository { get; }    
    IResourceRepository NutritionRequestRepository { get; }    
    IResourceRepository ObservationRepository { get; }    
    IResourceRepository OperationDefinitionRepository { get; }    
    IResourceRepository OperationOutcomeRepository { get; }    
    IResourceRepository OrganizationRepository { get; }    
    IResourceRepository ParametersRepository { get; }    
    IResourceRepository PatientRepository { get; }    
    IResourceRepository PaymentNoticeRepository { get; }    
    IResourceRepository PaymentReconciliationRepository { get; }    
    IResourceRepository PersonRepository { get; }    
    IResourceRepository PlanDefinitionRepository { get; }    
    IResourceRepository PractitionerRepository { get; }    
    IResourceRepository PractitionerRoleRepository { get; }    
    IResourceRepository ProcedureRepository { get; }    
    IResourceRepository ProcedureRequestRepository { get; }    
    IResourceRepository ProcessRequestRepository { get; }    
    IResourceRepository ProcessResponseRepository { get; }    
    IResourceRepository ProvenanceRepository { get; }    
    IResourceRepository QuestionnaireRepository { get; }    
    IResourceRepository QuestionnaireResponseRepository { get; }    
    IResourceRepository ReferralRequestRepository { get; }    
    IResourceRepository RelatedPersonRepository { get; }    
    IResourceRepository RiskAssessmentRepository { get; }    
    IResourceRepository ScheduleRepository { get; }    
    IResourceRepository SearchParameterRepository { get; }    
    IResourceRepository SequenceRepository { get; }    
    IResourceRepository SlotRepository { get; }    
    IResourceRepository SpecimenRepository { get; }    
    IResourceRepository StructureDefinitionRepository { get; }    
    IResourceRepository StructureMapRepository { get; }    
    IResourceRepository SubscriptionRepository { get; }    
    IResourceRepository SubstanceRepository { get; }    
    IResourceRepository SupplyDeliveryRepository { get; }    
    IResourceRepository SupplyRequestRepository { get; }    
    IResourceRepository TaskRepository { get; }    
    IResourceRepository TestScriptRepository { get; }    
    IResourceRepository ValueSetRepository { get; }    
    IResourceRepository VisionPrescriptionRepository { get; }    
  }
}

