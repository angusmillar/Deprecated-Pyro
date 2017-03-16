using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataModel.Repository;
using Pyro.DataModel.DatabaseModel;

namespace Pyro.DataModel
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private bool _Transactional = false;
    private System.Data.Entity.DbContextTransaction _Trans;

    public void BeginTransaction()
    {
      try
      {
        _Trans = _context.Database.BeginTransaction();
      }
      catch(Exception Exec)
      {
        var Test = Exec.Message;
      }
      _Transactional = true;
    }

    public void CommitTransaction()
    {
      try
      {
        _Trans.Commit();
      }
      catch
      {
        _Trans.Rollback();
        throw new NotImplementedException();

      }
      finally
      {
        _Trans.Dispose();
        _Transactional = false;
      }
    }

    public bool IsTransactional
    {
      get
      {
        return _Transactional;
      }      
    }

    private Pyro.DataModel.DatabaseModel.DatabaseContext _context = null;

    private CommonRepository _CommonRepository;    
    private AccountRepository<Res_Account, Res_Account_History> _AccountRepository;
    private ActivityDefinitionRepository<Res_ActivityDefinition, Res_ActivityDefinition_History> _ActivityDefinitionRepository;
    private AllergyIntoleranceRepository<Res_AllergyIntolerance, Res_AllergyIntolerance_History> _AllergyIntoleranceRepository;
    private AppointmentRepository<Res_Appointment, Res_Appointment_History> _AppointmentRepository;
    private AppointmentResponseRepository<Res_AppointmentResponse, Res_AppointmentResponse_History> _AppointmentResponseRepository;
    private AuditEventRepository<Res_AuditEvent, Res_AuditEvent_History> _AuditEventRepository;
    private BasicRepository<Res_Basic, Res_Basic_History> _BasicRepository;
    private BinaryRepository<Res_Binary, Res_Binary_History> _BinaryRepository;
    private BodySiteRepository<Res_BodySite, Res_BodySite_History> _BodySiteRepository;
    private BundleRepository<Res_Bundle, Res_Bundle_History> _BundleRepository;
    private CarePlanRepository<Res_CarePlan, Res_CarePlan_History> _CarePlanRepository;
    private CareTeamRepository<Res_CareTeam, Res_CareTeam_History> _CareTeamRepository;
    private ClaimRepository<Res_Claim, Res_Claim_History> _ClaimRepository;
    private ClaimResponseRepository<Res_ClaimResponse, Res_ClaimResponse_History> _ClaimResponseRepository;
    private ClinicalImpressionRepository<Res_ClinicalImpression, Res_ClinicalImpression_History> _ClinicalImpressionRepository;
    private CodeSystemRepository<Res_CodeSystem, Res_CodeSystem_History> _CodeSystemRepository;
    private CommunicationRepository<Res_Communication, Res_Communication_History> _CommunicationRepository;
    private CommunicationRequestRepository<Res_CommunicationRequest, Res_CommunicationRequest_History> _CommunicationRequestRepository;
    private CompartmentDefinitionRepository<Res_CompartmentDefinition, Res_CompartmentDefinition_History> _CompartmentDefinitionRepository;
    private CompositionRepository<Res_Composition, Res_Composition_History> _CompositionRepository;
    private ConceptMapRepository<Res_ConceptMap, Res_ConceptMap_History> _ConceptMapRepository;
    private ConditionRepository<Res_Condition, Res_Condition_History> _ConditionRepository;
    private ConformanceRepository<Res_Conformance, Res_Conformance_History> _ConformanceRepository;
    private ConsentRepository<Res_Consent, Res_Consent_History> _ConsentRepository;
    private ContractRepository<Res_Contract, Res_Contract_History> _ContractRepository;
    private CoverageRepository<Res_Coverage, Res_Coverage_History> _CoverageRepository;
    private DataElementRepository<Res_DataElement, Res_DataElement_History> _DataElementRepository;
    private DecisionSupportServiceModuleRepository<Res_DecisionSupportServiceModule, Res_DecisionSupportServiceModule_History> _DecisionSupportServiceModuleRepository;
    private DetectedIssueRepository<Res_DetectedIssue, Res_DetectedIssue_History> _DetectedIssueRepository;
    private DeviceRepository<Res_Device, Res_Device_History> _DeviceRepository;
    private DeviceComponentRepository<Res_DeviceComponent, Res_DeviceComponent_History> _DeviceComponentRepository;
    private DeviceMetricRepository<Res_DeviceMetric, Res_DeviceMetric_History> _DeviceMetricRepository;
    private DeviceUseRequestRepository<Res_DeviceUseRequest, Res_DeviceUseRequest_History> _DeviceUseRequestRepository;
    private DeviceUseStatementRepository<Res_DeviceUseStatement, Res_DeviceUseStatement_History> _DeviceUseStatementRepository;
    private DiagnosticReportRepository<Res_DiagnosticReport, Res_DiagnosticReport_History> _DiagnosticReportRepository;
    private DiagnosticRequestRepository<Res_DiagnosticRequest, Res_DiagnosticRequest_History> _DiagnosticRequestRepository;
    private DocumentManifestRepository<Res_DocumentManifest, Res_DocumentManifest_History> _DocumentManifestRepository;
    private DocumentReferenceRepository<Res_DocumentReference, Res_DocumentReference_History> _DocumentReferenceRepository;
    private EligibilityRequestRepository<Res_EligibilityRequest, Res_EligibilityRequest_History> _EligibilityRequestRepository;
    private EligibilityResponseRepository<Res_EligibilityResponse, Res_EligibilityResponse_History> _EligibilityResponseRepository;
    private EncounterRepository<Res_Encounter, Res_Encounter_History> _EncounterRepository;
    private EndpointRepository<Res_Endpoint, Res_Endpoint_History> _EndpointRepository;
    private EnrollmentRequestRepository<Res_EnrollmentRequest, Res_EnrollmentRequest_History> _EnrollmentRequestRepository;
    private EnrollmentResponseRepository<Res_EnrollmentResponse, Res_EnrollmentResponse_History> _EnrollmentResponseRepository;
    private EpisodeOfCareRepository<Res_EpisodeOfCare, Res_EpisodeOfCare_History> _EpisodeOfCareRepository;
    private ExpansionProfileRepository<Res_ExpansionProfile, Res_ExpansionProfile_History> _ExpansionProfileRepository;
    private ExplanationOfBenefitRepository<Res_ExplanationOfBenefit, Res_ExplanationOfBenefit_History> _ExplanationOfBenefitRepository;
    private FamilyMemberHistoryRepository<Res_FamilyMemberHistory, Res_FamilyMemberHistory_History> _FamilyMemberHistoryRepository;
    private FlagRepository<Res_Flag, Res_Flag_History> _FlagRepository;
    private GoalRepository<Res_Goal, Res_Goal_History> _GoalRepository;
    private GroupRepository<Res_Group, Res_Group_History> _GroupRepository;
    private GuidanceResponseRepository<Res_GuidanceResponse, Res_GuidanceResponse_History> _GuidanceResponseRepository;
    private HealthcareServiceRepository<Res_HealthcareService, Res_HealthcareService_History> _HealthcareServiceRepository;
    private ImagingManifestRepository<Res_ImagingManifest, Res_ImagingManifest_History> _ImagingManifestRepository;
    private ImagingStudyRepository<Res_ImagingStudy, Res_ImagingStudy_History> _ImagingStudyRepository;
    private ImmunizationRepository<Res_Immunization, Res_Immunization_History> _ImmunizationRepository;
    private ImmunizationRecommendationRepository<Res_ImmunizationRecommendation, Res_ImmunizationRecommendation_History> _ImmunizationRecommendationRepository;
    private ImplementationGuideRepository<Res_ImplementationGuide, Res_ImplementationGuide_History> _ImplementationGuideRepository;
    private LibraryRepository<Res_Library, Res_Library_History> _LibraryRepository;
    private LinkageRepository<Res_Linkage, Res_Linkage_History> _LinkageRepository;
    private ListRepository<Res_List, Res_List_History> _ListRepository;
    private LocationRepository<Res_Location, Res_Location_History> _LocationRepository;
    private MeasureRepository<Res_Measure, Res_Measure_History> _MeasureRepository;
    private MeasureReportRepository<Res_MeasureReport, Res_MeasureReport_History> _MeasureReportRepository;
    private MediaRepository<Res_Media, Res_Media_History> _MediaRepository;
    private MedicationRepository<Res_Medication, Res_Medication_History> _MedicationRepository;
    private MedicationAdministrationRepository<Res_MedicationAdministration, Res_MedicationAdministration_History> _MedicationAdministrationRepository;
    private MedicationDispenseRepository<Res_MedicationDispense, Res_MedicationDispense_History> _MedicationDispenseRepository;
    private MedicationOrderRepository<Res_MedicationOrder, Res_MedicationOrder_History> _MedicationOrderRepository;
    private MedicationStatementRepository<Res_MedicationStatement, Res_MedicationStatement_History> _MedicationStatementRepository;
    private MessageHeaderRepository<Res_MessageHeader, Res_MessageHeader_History> _MessageHeaderRepository;
    private NamingSystemRepository<Res_NamingSystem, Res_NamingSystem_History> _NamingSystemRepository;
    private NutritionRequestRepository<Res_NutritionRequest, Res_NutritionRequest_History> _NutritionRequestRepository;
    private ObservationRepository<Res_Observation, Res_Observation_History> _ObservationRepository;
    private OperationDefinitionRepository<Res_OperationDefinition, Res_OperationDefinition_History> _OperationDefinitionRepository;
    private OperationOutcomeRepository<Res_OperationOutcome, Res_OperationOutcome_History> _OperationOutcomeRepository;
    private OrganizationRepository<Res_Organization, Res_Organization_History> _OrganizationRepository;
    private ParametersRepository<Res_Parameters, Res_Parameters_History> _ParametersRepository;
    private PatientRepository<Res_Patient, Res_Patient_History> _PatientRepository;
    private PaymentNoticeRepository<Res_PaymentNotice, Res_PaymentNotice_History> _PaymentNoticeRepository;
    private PaymentReconciliationRepository<Res_PaymentReconciliation, Res_PaymentReconciliation_History> _PaymentReconciliationRepository;
    private PersonRepository<Res_Person, Res_Person_History> _PersonRepository;
    private PlanDefinitionRepository<Res_PlanDefinition, Res_PlanDefinition_History> _PlanDefinitionRepository;
    private PractitionerRepository<Res_Practitioner, Res_Practitioner_History> _PractitionerRepository;
    private PractitionerRoleRepository<Res_PractitionerRole, Res_PractitionerRole_History> _PractitionerRoleRepository;
    private ProcedureRepository<Res_Procedure, Res_Procedure_History> _ProcedureRepository;
    private ProcedureRequestRepository<Res_ProcedureRequest, Res_ProcedureRequest_History> _ProcedureRequestRepository;
    private ProcessRequestRepository<Res_ProcessRequest, Res_ProcessRequest_History> _ProcessRequestRepository;
    private ProcessResponseRepository<Res_ProcessResponse, Res_ProcessResponse_History> _ProcessResponseRepository;
    private ProvenanceRepository<Res_Provenance, Res_Provenance_History> _ProvenanceRepository;
    private QuestionnaireRepository<Res_Questionnaire, Res_Questionnaire_History> _QuestionnaireRepository;
    private QuestionnaireResponseRepository<Res_QuestionnaireResponse, Res_QuestionnaireResponse_History> _QuestionnaireResponseRepository;
    private ReferralRequestRepository<Res_ReferralRequest, Res_ReferralRequest_History> _ReferralRequestRepository;
    private RelatedPersonRepository<Res_RelatedPerson, Res_RelatedPerson_History> _RelatedPersonRepository;
    private RiskAssessmentRepository<Res_RiskAssessment, Res_RiskAssessment_History> _RiskAssessmentRepository;
    private ScheduleRepository<Res_Schedule, Res_Schedule_History> _ScheduleRepository;
    private SearchParameterRepository<Res_SearchParameter, Res_SearchParameter_History> _SearchParameterRepository;
    private SequenceRepository<Res_Sequence, Res_Sequence_History> _SequenceRepository;
    private SlotRepository<Res_Slot, Res_Slot_History> _SlotRepository;
    private SpecimenRepository<Res_Specimen, Res_Specimen_History> _SpecimenRepository;
    private StructureDefinitionRepository<Res_StructureDefinition, Res_StructureDefinition_History> _StructureDefinitionRepository;
    private StructureMapRepository<Res_StructureMap, Res_StructureMap_History> _StructureMapRepository;
    private SubscriptionRepository<Res_Subscription, Res_Subscription_History> _SubscriptionRepository;
    private SubstanceRepository<Res_Substance, Res_Substance_History> _SubstanceRepository;
    private SupplyDeliveryRepository<Res_SupplyDelivery, Res_SupplyDelivery_History> _SupplyDeliveryRepository;
    private SupplyRequestRepository<Res_SupplyRequest, Res_SupplyRequest_History> _SupplyRequestRepository;
    private TaskRepository<Res_Task, Res_Task_History> _TaskRepository;
    private TestScriptRepository<Res_TestScript, Res_TestScript_History> _TestScriptRepository;
    private ValueSetRepository<Res_ValueSet, Res_ValueSet_History> _ValueSetRepository;
    private VisionPrescriptionRepository<Res_VisionPrescription, Res_VisionPrescription_History> _VisionPrescriptionRepository;

    public UnitOfWork()
    {
      _context = new Pyro.DataModel.DatabaseModel.DatabaseContext();            
    }

    public IDtoCommonRepository CommonRepository
    {
      get
      {
        if (this._CommonRepository == null)
          this._CommonRepository = new CommonRepository(_context);
        return _CommonRepository;
      }
    }

    public IResourceRepository AccountRepository
    {
      get
      {
        if (this._AccountRepository == null)
          this._AccountRepository = new AccountRepository<Res_Account, Res_Account_History>(_context);
        return _AccountRepository;
      }
    }

    public IResourceRepository ActivityDefinitionRepository
    {
      get
      {
        if (this._ActivityDefinitionRepository == null)
          this._ActivityDefinitionRepository = new ActivityDefinitionRepository<Res_ActivityDefinition, Res_ActivityDefinition_History>(_context);
        return _ActivityDefinitionRepository;
      }
    }

    public IResourceRepository AllergyIntoleranceRepository
    {
      get
      {
        if (this._AllergyIntoleranceRepository == null)
          this._AllergyIntoleranceRepository = new AllergyIntoleranceRepository<Res_AllergyIntolerance, Res_AllergyIntolerance_History>(_context);
        return _AllergyIntoleranceRepository;
      }
    }

    public IResourceRepository AppointmentRepository
    {
      get
      {
        if (this._AppointmentRepository == null)
          this._AppointmentRepository = new AppointmentRepository<Res_Appointment, Res_Appointment_History>(_context);
        return _AppointmentRepository;
      }
    }

    public IResourceRepository AppointmentResponseRepository
    {
      get
      {
        if (this._AppointmentResponseRepository == null)
          this._AppointmentResponseRepository = new AppointmentResponseRepository<Res_AppointmentResponse, Res_AppointmentResponse_History>(_context);
        return _AppointmentResponseRepository;
      }
    }

    public IResourceRepository AuditEventRepository
    {
      get
      {
        if (this._AuditEventRepository == null)
          this._AuditEventRepository = new AuditEventRepository<Res_AuditEvent, Res_AuditEvent_History>(_context);
        return _AuditEventRepository;
      }
    }

    public IResourceRepository BasicRepository
    {
      get
      {
        if (this._BasicRepository == null)
          this._BasicRepository = new BasicRepository<Res_Basic, Res_Basic_History>(_context);
        return _BasicRepository;
      }
    }

    public IResourceRepository BinaryRepository
    {
      get
      {
        if (this._BinaryRepository == null)
          this._BinaryRepository = new BinaryRepository<Res_Binary, Res_Binary_History>(_context);
        return _BinaryRepository;
      }
    }

    public IResourceRepository BodySiteRepository
    {
      get
      {
        if (this._BodySiteRepository == null)
          this._BodySiteRepository = new BodySiteRepository<Res_BodySite, Res_BodySite_History>(_context);
        return _BodySiteRepository;
      }
    }

    public IResourceRepository BundleRepository
    {
      get
      {
        if (this._BundleRepository == null)
          this._BundleRepository = new BundleRepository<Res_Bundle, Res_Bundle_History>(_context);
        return _BundleRepository;
      }
    }

    public IResourceRepository CarePlanRepository
    {
      get
      {
        if (this._CarePlanRepository == null)
          this._CarePlanRepository = new CarePlanRepository<Res_CarePlan, Res_CarePlan_History>(_context);
        return _CarePlanRepository;
      }
    }

    public IResourceRepository CareTeamRepository
    {
      get
      {
        if (this._CareTeamRepository == null)
          this._CareTeamRepository = new CareTeamRepository<Res_CareTeam, Res_CareTeam_History>(_context);
        return _CareTeamRepository;
      }
    }

    public IResourceRepository ClaimRepository
    {
      get
      {
        if (this._ClaimRepository == null)
          this._ClaimRepository = new ClaimRepository<Res_Claim, Res_Claim_History>(_context);
        return _ClaimRepository;
      }
    }

    public IResourceRepository ClaimResponseRepository
    {
      get
      {
        if (this._ClaimResponseRepository == null)
          this._ClaimResponseRepository = new ClaimResponseRepository<Res_ClaimResponse, Res_ClaimResponse_History>(_context);
        return _ClaimResponseRepository;
      }
    }

    public IResourceRepository ClinicalImpressionRepository
    {
      get
      {
        if (this._ClinicalImpressionRepository == null)
          this._ClinicalImpressionRepository = new ClinicalImpressionRepository<Res_ClinicalImpression, Res_ClinicalImpression_History>(_context);
        return _ClinicalImpressionRepository;
      }
    }

    public IResourceRepository CodeSystemRepository
    {
      get
      {
        if (this._CodeSystemRepository == null)
          this._CodeSystemRepository = new CodeSystemRepository<Res_CodeSystem, Res_CodeSystem_History>(_context);
        return _CodeSystemRepository;
      }
    }

    public IResourceRepository CommunicationRepository
    {
      get
      {
        if (this._CommunicationRepository == null)
          this._CommunicationRepository = new CommunicationRepository<Res_Communication, Res_Communication_History>(_context);
        return _CommunicationRepository;
      }
    }

    public IResourceRepository CommunicationRequestRepository
    {
      get
      {
        if (this._CommunicationRequestRepository == null)
          this._CommunicationRequestRepository = new CommunicationRequestRepository<Res_CommunicationRequest, Res_CommunicationRequest_History>(_context);
        return _CommunicationRequestRepository;
      }
    }

    public IResourceRepository CompartmentDefinitionRepository
    {
      get
      {
        if (this._CompartmentDefinitionRepository == null)
          this._CompartmentDefinitionRepository = new CompartmentDefinitionRepository<Res_CompartmentDefinition, Res_CompartmentDefinition_History>(_context);
        return _CompartmentDefinitionRepository;
      }
    }

    public IResourceRepository CompositionRepository
    {
      get
      {
        if (this._CompositionRepository == null)
          this._CompositionRepository = new CompositionRepository<Res_Composition, Res_Composition_History>(_context);
        return _CompositionRepository;
      }
    }

    public IResourceRepository ConceptMapRepository
    {
      get
      {
        if (this._ConceptMapRepository == null)
          this._ConceptMapRepository = new ConceptMapRepository<Res_ConceptMap, Res_ConceptMap_History>(_context);
        return _ConceptMapRepository;
      }
    }

    public IResourceRepository ConditionRepository
    {
      get
      {
        if (this._ConditionRepository == null)
          this._ConditionRepository = new ConditionRepository<Res_Condition, Res_Condition_History>(_context);
        return _ConditionRepository;
      }
    }

    public IResourceRepository ConformanceRepository
    {
      get
      {
        if (this._ConformanceRepository == null)
          this._ConformanceRepository = new ConformanceRepository<Res_Conformance, Res_Conformance_History>(_context);
        return _ConformanceRepository;
      }
    }

    public IResourceRepository ConsentRepository
    {
      get
      {
        if (this._ConsentRepository == null)
          this._ConsentRepository = new ConsentRepository<Res_Consent, Res_Consent_History>(_context);
        return _ConsentRepository;
      }
    }

    public IResourceRepository ContractRepository
    {
      get
      {
        if (this._ContractRepository == null)
          this._ContractRepository = new ContractRepository<Res_Contract, Res_Contract_History>(_context);
        return _ContractRepository;
      }
    }

    public IResourceRepository CoverageRepository
    {
      get
      {
        if (this._CoverageRepository == null)
          this._CoverageRepository = new CoverageRepository<Res_Coverage, Res_Coverage_History>(_context);
        return _CoverageRepository;
      }
    }

    public IResourceRepository DataElementRepository
    {
      get
      {
        if (this._DataElementRepository == null)
          this._DataElementRepository = new DataElementRepository<Res_DataElement, Res_DataElement_History>(_context);
        return _DataElementRepository;
      }
    }

    public IResourceRepository DecisionSupportServiceModuleRepository
    {
      get
      {
        if (this._DecisionSupportServiceModuleRepository == null)
          this._DecisionSupportServiceModuleRepository = new DecisionSupportServiceModuleRepository<Res_DecisionSupportServiceModule, Res_DecisionSupportServiceModule_History>(_context);
        return _DecisionSupportServiceModuleRepository;
      }
    }

    public IResourceRepository DetectedIssueRepository
    {
      get
      {
        if (this._DetectedIssueRepository == null)
          this._DetectedIssueRepository = new DetectedIssueRepository<Res_DetectedIssue, Res_DetectedIssue_History>(_context);
        return _DetectedIssueRepository;
      }
    }

    public IResourceRepository DeviceRepository
    {
      get
      {
        if (this._DeviceRepository == null)
          this._DeviceRepository = new DeviceRepository<Res_Device, Res_Device_History>(_context);
        return _DeviceRepository;
      }
    }

    public IResourceRepository DeviceComponentRepository
    {
      get
      {
        if (this._DeviceComponentRepository == null)
          this._DeviceComponentRepository = new DeviceComponentRepository<Res_DeviceComponent, Res_DeviceComponent_History>(_context);
        return _DeviceComponentRepository;
      }
    }

    public IResourceRepository DeviceMetricRepository
    {
      get
      {
        if (this._DeviceMetricRepository == null)
          this._DeviceMetricRepository = new DeviceMetricRepository<Res_DeviceMetric, Res_DeviceMetric_History>(_context);
        return _DeviceMetricRepository;
      }
    }

    public IResourceRepository DeviceUseRequestRepository
    {
      get
      {
        if (this._DeviceUseRequestRepository == null)
          this._DeviceUseRequestRepository = new DeviceUseRequestRepository<Res_DeviceUseRequest, Res_DeviceUseRequest_History>(_context);
        return _DeviceUseRequestRepository;
      }
    }

    public IResourceRepository DeviceUseStatementRepository
    {
      get
      {
        if (this._DeviceUseStatementRepository == null)
          this._DeviceUseStatementRepository = new DeviceUseStatementRepository<Res_DeviceUseStatement, Res_DeviceUseStatement_History>(_context);
        return _DeviceUseStatementRepository;
      }
    }

    public IResourceRepository DiagnosticReportRepository
    {
      get
      {
        if (this._DiagnosticReportRepository == null)
          this._DiagnosticReportRepository = new DiagnosticReportRepository<Res_DiagnosticReport, Res_DiagnosticReport_History>(_context);
        return _DiagnosticReportRepository;
      }
    }

    public IResourceRepository DiagnosticRequestRepository
    {
      get
      {
        if (this._DiagnosticRequestRepository == null)
          this._DiagnosticRequestRepository = new DiagnosticRequestRepository<Res_DiagnosticRequest, Res_DiagnosticRequest_History>(_context);
        return _DiagnosticRequestRepository;
      }
    }

    public IResourceRepository DocumentManifestRepository
    {
      get
      {
        if (this._DocumentManifestRepository == null)
          this._DocumentManifestRepository = new DocumentManifestRepository<Res_DocumentManifest, Res_DocumentManifest_History>(_context);
        return _DocumentManifestRepository;
      }
    }

    public IResourceRepository DocumentReferenceRepository
    {
      get
      {
        if (this._DocumentReferenceRepository == null)
          this._DocumentReferenceRepository = new DocumentReferenceRepository<Res_DocumentReference, Res_DocumentReference_History>(_context);
        return _DocumentReferenceRepository;
      }
    }

    public IResourceRepository EligibilityRequestRepository
    {
      get
      {
        if (this._EligibilityRequestRepository == null)
          this._EligibilityRequestRepository = new EligibilityRequestRepository<Res_EligibilityRequest, Res_EligibilityRequest_History>(_context);
        return _EligibilityRequestRepository;
      }
    }

    public IResourceRepository EligibilityResponseRepository
    {
      get
      {
        if (this._EligibilityResponseRepository == null)
          this._EligibilityResponseRepository = new EligibilityResponseRepository<Res_EligibilityResponse, Res_EligibilityResponse_History>(_context);
        return _EligibilityResponseRepository;
      }
    }

    public IResourceRepository EncounterRepository
    {
      get
      {
        if (this._EncounterRepository == null)
          this._EncounterRepository = new EncounterRepository<Res_Encounter, Res_Encounter_History>(_context);
        return _EncounterRepository;
      }
    }

    public IResourceRepository EndpointRepository
    {
      get
      {
        if (this._EndpointRepository == null)
          this._EndpointRepository = new EndpointRepository<Res_Endpoint, Res_Endpoint_History>(_context);
        return _EndpointRepository;
      }
    }

    public IResourceRepository EnrollmentRequestRepository
    {
      get
      {
        if (this._EnrollmentRequestRepository == null)
          this._EnrollmentRequestRepository = new EnrollmentRequestRepository<Res_EnrollmentRequest, Res_EnrollmentRequest_History>(_context);
        return _EnrollmentRequestRepository;
      }
    }

    public IResourceRepository EnrollmentResponseRepository
    {
      get
      {
        if (this._EnrollmentResponseRepository == null)
          this._EnrollmentResponseRepository = new EnrollmentResponseRepository<Res_EnrollmentResponse, Res_EnrollmentResponse_History>(_context);
        return _EnrollmentResponseRepository;
      }
    }

    public IResourceRepository EpisodeOfCareRepository
    {
      get
      {
        if (this._EpisodeOfCareRepository == null)
          this._EpisodeOfCareRepository = new EpisodeOfCareRepository<Res_EpisodeOfCare, Res_EpisodeOfCare_History>(_context);
        return _EpisodeOfCareRepository;
      }
    }

    public IResourceRepository ExpansionProfileRepository
    {
      get
      {
        if (this._ExpansionProfileRepository == null)
          this._ExpansionProfileRepository = new ExpansionProfileRepository<Res_ExpansionProfile, Res_ExpansionProfile_History>(_context);
        return _ExpansionProfileRepository;
      }
    }

    public IResourceRepository ExplanationOfBenefitRepository
    {
      get
      {
        if (this._ExplanationOfBenefitRepository == null)
          this._ExplanationOfBenefitRepository = new ExplanationOfBenefitRepository<Res_ExplanationOfBenefit, Res_ExplanationOfBenefit_History>(_context);
        return _ExplanationOfBenefitRepository;
      }
    }

    public IResourceRepository FamilyMemberHistoryRepository
    {
      get
      {
        if (this._FamilyMemberHistoryRepository == null)
          this._FamilyMemberHistoryRepository = new FamilyMemberHistoryRepository<Res_FamilyMemberHistory, Res_FamilyMemberHistory_History>(_context);
        return _FamilyMemberHistoryRepository;
      }
    }

    public IResourceRepository FlagRepository
    {
      get
      {
        if (this._FlagRepository == null)
          this._FlagRepository = new FlagRepository<Res_Flag, Res_Flag_History>(_context);
        return _FlagRepository;
      }
    }

    public IResourceRepository GoalRepository
    {
      get
      {
        if (this._GoalRepository == null)
          this._GoalRepository = new GoalRepository<Res_Goal, Res_Goal_History>(_context);
        return _GoalRepository;
      }
    }

    public IResourceRepository GroupRepository
    {
      get
      {
        if (this._GroupRepository == null)
          this._GroupRepository = new GroupRepository<Res_Group, Res_Group_History>(_context);
        return _GroupRepository;
      }
    }

    public IResourceRepository GuidanceResponseRepository
    {
      get
      {
        if (this._GuidanceResponseRepository == null)
          this._GuidanceResponseRepository = new GuidanceResponseRepository<Res_GuidanceResponse, Res_GuidanceResponse_History>(_context);
        return _GuidanceResponseRepository;
      }
    }

    public IResourceRepository HealthcareServiceRepository
    {
      get
      {
        if (this._HealthcareServiceRepository == null)
          this._HealthcareServiceRepository = new HealthcareServiceRepository<Res_HealthcareService, Res_HealthcareService_History>(_context);
        return _HealthcareServiceRepository;
      }
    }

    public IResourceRepository ImagingManifestRepository
    {
      get
      {
        if (this._ImagingManifestRepository == null)
          this._ImagingManifestRepository = new ImagingManifestRepository<Res_ImagingManifest, Res_ImagingManifest_History>(_context);
        return _ImagingManifestRepository;
      }
    }

    public IResourceRepository ImagingStudyRepository
    {
      get
      {
        if (this._ImagingStudyRepository == null)
          this._ImagingStudyRepository = new ImagingStudyRepository<Res_ImagingStudy, Res_ImagingStudy_History>(_context);
        return _ImagingStudyRepository;
      }
    }

    public IResourceRepository ImmunizationRepository
    {
      get
      {
        if (this._ImmunizationRepository == null)
          this._ImmunizationRepository = new ImmunizationRepository<Res_Immunization, Res_Immunization_History>(_context);
        return _ImmunizationRepository;
      }
    }

    public IResourceRepository ImmunizationRecommendationRepository
    {
      get
      {
        if (this._ImmunizationRecommendationRepository == null)
          this._ImmunizationRecommendationRepository = new ImmunizationRecommendationRepository<Res_ImmunizationRecommendation, Res_ImmunizationRecommendation_History>(_context);
        return _ImmunizationRecommendationRepository;
      }
    }

    public IResourceRepository ImplementationGuideRepository
    {
      get
      {
        if (this._ImplementationGuideRepository == null)
          this._ImplementationGuideRepository = new ImplementationGuideRepository<Res_ImplementationGuide, Res_ImplementationGuide_History>(_context);
        return _ImplementationGuideRepository;
      }
    }

    public IResourceRepository LibraryRepository
    {
      get
      {
        if (this._LibraryRepository == null)
          this._LibraryRepository = new LibraryRepository<Res_Library, Res_Library_History>(_context);
        return _LibraryRepository;
      }
    }

    public IResourceRepository LinkageRepository
    {
      get
      {
        if (this._LinkageRepository == null)
          this._LinkageRepository = new LinkageRepository<Res_Linkage, Res_Linkage_History>(_context);
        return _LinkageRepository;
      }
    }

    public IResourceRepository ListRepository
    {
      get
      {
        if (this._ListRepository == null)
          this._ListRepository = new ListRepository<Res_List, Res_List_History>(_context);
        return _ListRepository;
      }
    }

    public IResourceRepository LocationRepository
    {
      get
      {
        if (this._LocationRepository == null)
          this._LocationRepository = new LocationRepository<Res_Location, Res_Location_History>(_context);
        return _LocationRepository;
      }
    }

    public IResourceRepository MeasureRepository
    {
      get
      {
        if (this._MeasureRepository == null)
          this._MeasureRepository = new MeasureRepository<Res_Measure, Res_Measure_History>(_context);
        return _MeasureRepository;
      }
    }

    public IResourceRepository MeasureReportRepository
    {
      get
      {
        if (this._MeasureReportRepository == null)
          this._MeasureReportRepository = new MeasureReportRepository<Res_MeasureReport, Res_MeasureReport_History>(_context);
        return _MeasureReportRepository;
      }
    }

    public IResourceRepository MediaRepository
    {
      get
      {
        if (this._MediaRepository == null)
          this._MediaRepository = new MediaRepository<Res_Media, Res_Media_History>(_context);
        return _MediaRepository;
      }
    }

    public IResourceRepository MedicationRepository
    {
      get
      {
        if (this._MedicationRepository == null)
          this._MedicationRepository = new MedicationRepository<Res_Medication, Res_Medication_History>(_context);
        return _MedicationRepository;
      }
    }

    public IResourceRepository MedicationAdministrationRepository
    {
      get
      {
        if (this._MedicationAdministrationRepository == null)
          this._MedicationAdministrationRepository = new MedicationAdministrationRepository<Res_MedicationAdministration, Res_MedicationAdministration_History>(_context);
        return _MedicationAdministrationRepository;
      }
    }

    public IResourceRepository MedicationDispenseRepository
    {
      get
      {
        if (this._MedicationDispenseRepository == null)
          this._MedicationDispenseRepository = new MedicationDispenseRepository<Res_MedicationDispense, Res_MedicationDispense_History>(_context);
        return _MedicationDispenseRepository;
      }
    }

    public IResourceRepository MedicationOrderRepository
    {
      get
      {
        if (this._MedicationOrderRepository == null)
          this._MedicationOrderRepository = new MedicationOrderRepository<Res_MedicationOrder, Res_MedicationOrder_History>(_context);
        return _MedicationOrderRepository;
      }
    }

    public IResourceRepository MedicationStatementRepository
    {
      get
      {
        if (this._MedicationStatementRepository == null)
          this._MedicationStatementRepository = new MedicationStatementRepository<Res_MedicationStatement, Res_MedicationStatement_History>(_context);
        return _MedicationStatementRepository;
      }
    }

    public IResourceRepository MessageHeaderRepository
    {
      get
      {
        if (this._MessageHeaderRepository == null)
          this._MessageHeaderRepository = new MessageHeaderRepository<Res_MessageHeader, Res_MessageHeader_History>(_context);
        return _MessageHeaderRepository;
      }
    }

    public IResourceRepository NamingSystemRepository
    {
      get
      {
        if (this._NamingSystemRepository == null)
          this._NamingSystemRepository = new NamingSystemRepository<Res_NamingSystem, Res_NamingSystem_History>(_context);
        return _NamingSystemRepository;
      }
    }

    public IResourceRepository NutritionRequestRepository
    {
      get
      {
        if (this._NutritionRequestRepository == null)
          this._NutritionRequestRepository = new NutritionRequestRepository<Res_NutritionRequest, Res_NutritionRequest_History>(_context);
        return _NutritionRequestRepository;
      }
    }

    public IResourceRepository ObservationRepository
    {
      get
      {
        if (this._ObservationRepository == null)
          this._ObservationRepository = new ObservationRepository<Res_Observation, Res_Observation_History>(_context);
        return _ObservationRepository;
      }
    }

    public IResourceRepository OperationDefinitionRepository
    {
      get
      {
        if (this._OperationDefinitionRepository == null)
          this._OperationDefinitionRepository = new OperationDefinitionRepository<Res_OperationDefinition, Res_OperationDefinition_History>(_context);
        return _OperationDefinitionRepository;
      }
    }

    public IResourceRepository OperationOutcomeRepository
    {
      get
      {
        if (this._OperationOutcomeRepository == null)
          this._OperationOutcomeRepository = new OperationOutcomeRepository<Res_OperationOutcome, Res_OperationOutcome_History>(_context);
        return _OperationOutcomeRepository;
      }
    }

    public IResourceRepository OrganizationRepository
    {
      get
      {
        if (this._OrganizationRepository == null)
          this._OrganizationRepository = new OrganizationRepository<Res_Organization, Res_Organization_History>(_context);
        return _OrganizationRepository;
      }
    }

    public IResourceRepository ParametersRepository
    {
      get
      {
        if (this._ParametersRepository == null)
          this._ParametersRepository = new ParametersRepository<Res_Parameters, Res_Parameters_History>(_context);
        return _ParametersRepository;
      }
    }

    public IResourceRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new PatientRepository<Res_Patient, Res_Patient_History>(_context);
        return _PatientRepository;
      }
    }

    public IResourceRepository PaymentNoticeRepository
    {
      get
      {
        if (this._PaymentNoticeRepository == null)
          this._PaymentNoticeRepository = new PaymentNoticeRepository<Res_PaymentNotice, Res_PaymentNotice_History>(_context);
        return _PaymentNoticeRepository;
      }
    }

    public IResourceRepository PaymentReconciliationRepository
    {
      get
      {
        if (this._PaymentReconciliationRepository == null)
          this._PaymentReconciliationRepository = new PaymentReconciliationRepository<Res_PaymentReconciliation, Res_PaymentReconciliation_History>(_context);
        return _PaymentReconciliationRepository;
      }
    }

    public IResourceRepository PersonRepository
    {
      get
      {
        if (this._PersonRepository == null)
          this._PersonRepository = new PersonRepository<Res_Person, Res_Person_History>(_context);
        return _PersonRepository;
      }
    }

    public IResourceRepository PlanDefinitionRepository
    {
      get
      {
        if (this._PlanDefinitionRepository == null)
          this._PlanDefinitionRepository = new PlanDefinitionRepository<Res_PlanDefinition, Res_PlanDefinition_History>(_context);
        return _PlanDefinitionRepository;
      }
    }

    public IResourceRepository PractitionerRepository
    {
      get
      {
        if (this._PractitionerRepository == null)
          this._PractitionerRepository = new PractitionerRepository<Res_Practitioner, Res_Practitioner_History>(_context);
        return _PractitionerRepository;
      }
    }

    public IResourceRepository PractitionerRoleRepository
    {
      get
      {
        if (this._PractitionerRoleRepository == null)
          this._PractitionerRoleRepository = new PractitionerRoleRepository<Res_PractitionerRole, Res_PractitionerRole_History>(_context);
        return _PractitionerRoleRepository;
      }
    }

    public IResourceRepository ProcedureRepository
    {
      get
      {
        if (this._ProcedureRepository == null)
          this._ProcedureRepository = new ProcedureRepository<Res_Procedure, Res_Procedure_History>(_context);
        return _ProcedureRepository;
      }
    }

    public IResourceRepository ProcedureRequestRepository
    {
      get
      {
        if (this._ProcedureRequestRepository == null)
          this._ProcedureRequestRepository = new ProcedureRequestRepository<Res_ProcedureRequest, Res_ProcedureRequest_History>(_context);
        return _ProcedureRequestRepository;
      }
    }

    public IResourceRepository ProcessRequestRepository
    {
      get
      {
        if (this._ProcessRequestRepository == null)
          this._ProcessRequestRepository = new ProcessRequestRepository<Res_ProcessRequest, Res_ProcessRequest_History>(_context);
        return _ProcessRequestRepository;
      }
    }

    public IResourceRepository ProcessResponseRepository
    {
      get
      {
        if (this._ProcessResponseRepository == null)
          this._ProcessResponseRepository = new ProcessResponseRepository<Res_ProcessResponse, Res_ProcessResponse_History>(_context);
        return _ProcessResponseRepository;
      }
    }

    public IResourceRepository ProvenanceRepository
    {
      get
      {
        if (this._ProvenanceRepository == null)
          this._ProvenanceRepository = new ProvenanceRepository<Res_Provenance, Res_Provenance_History>(_context);
        return _ProvenanceRepository;
      }
    }

    public IResourceRepository QuestionnaireRepository
    {
      get
      {
        if (this._QuestionnaireRepository == null)
          this._QuestionnaireRepository = new QuestionnaireRepository<Res_Questionnaire, Res_Questionnaire_History>(_context);
        return _QuestionnaireRepository;
      }
    }

    public IResourceRepository QuestionnaireResponseRepository
    {
      get
      {
        if (this._QuestionnaireResponseRepository == null)
          this._QuestionnaireResponseRepository = new QuestionnaireResponseRepository<Res_QuestionnaireResponse, Res_QuestionnaireResponse_History>(_context);
        return _QuestionnaireResponseRepository;
      }
    }

    public IResourceRepository ReferralRequestRepository
    {
      get
      {
        if (this._ReferralRequestRepository == null)
          this._ReferralRequestRepository = new ReferralRequestRepository<Res_ReferralRequest, Res_ReferralRequest_History>(_context);
        return _ReferralRequestRepository;
      }
    }

    public IResourceRepository RelatedPersonRepository
    {
      get
      {
        if (this._RelatedPersonRepository == null)
          this._RelatedPersonRepository = new RelatedPersonRepository<Res_RelatedPerson, Res_RelatedPerson_History>(_context);
        return _RelatedPersonRepository;
      }
    }

    public IResourceRepository RiskAssessmentRepository
    {
      get
      {
        if (this._RiskAssessmentRepository == null)
          this._RiskAssessmentRepository = new RiskAssessmentRepository<Res_RiskAssessment, Res_RiskAssessment_History>(_context);
        return _RiskAssessmentRepository;
      }
    }

    public IResourceRepository ScheduleRepository
    {
      get
      {
        if (this._ScheduleRepository == null)
          this._ScheduleRepository = new ScheduleRepository<Res_Schedule, Res_Schedule_History>(_context);
        return _ScheduleRepository;
      }
    }

    public IResourceRepository SearchParameterRepository
    {
      get
      {
        if (this._SearchParameterRepository == null)
          this._SearchParameterRepository = new SearchParameterRepository<Res_SearchParameter, Res_SearchParameter_History>(_context);
        return _SearchParameterRepository;
      }
    }

    public IResourceRepository SequenceRepository
    {
      get
      {
        if (this._SequenceRepository == null)
          this._SequenceRepository = new SequenceRepository<Res_Sequence, Res_Sequence_History>(_context);
        return _SequenceRepository;
      }
    }

    public IResourceRepository SlotRepository
    {
      get
      {
        if (this._SlotRepository == null)
          this._SlotRepository = new SlotRepository<Res_Slot, Res_Slot_History>(_context);
        return _SlotRepository;
      }
    }

    public IResourceRepository SpecimenRepository
    {
      get
      {
        if (this._SpecimenRepository == null)
          this._SpecimenRepository = new SpecimenRepository<Res_Specimen, Res_Specimen_History>(_context);
        return _SpecimenRepository;
      }
    }

    public IResourceRepository StructureDefinitionRepository
    {
      get
      {
        if (this._StructureDefinitionRepository == null)
          this._StructureDefinitionRepository = new StructureDefinitionRepository<Res_StructureDefinition, Res_StructureDefinition_History>(_context);
        return _StructureDefinitionRepository;
      }
    }

    public IResourceRepository StructureMapRepository
    {
      get
      {
        if (this._StructureMapRepository == null)
          this._StructureMapRepository = new StructureMapRepository<Res_StructureMap, Res_StructureMap_History>(_context);
        return _StructureMapRepository;
      }
    }

    public IResourceRepository SubscriptionRepository
    {
      get
      {
        if (this._SubscriptionRepository == null)
          this._SubscriptionRepository = new SubscriptionRepository<Res_Subscription, Res_Subscription_History>(_context);
        return _SubscriptionRepository;
      }
    }

    public IResourceRepository SubstanceRepository
    {
      get
      {
        if (this._SubstanceRepository == null)
          this._SubstanceRepository = new SubstanceRepository<Res_Substance, Res_Substance_History>(_context);
        return _SubstanceRepository;
      }
    }

    public IResourceRepository SupplyDeliveryRepository
    {
      get
      {
        if (this._SupplyDeliveryRepository == null)
          this._SupplyDeliveryRepository = new SupplyDeliveryRepository<Res_SupplyDelivery, Res_SupplyDelivery_History>(_context);
        return _SupplyDeliveryRepository;
      }
    }

    public IResourceRepository SupplyRequestRepository
    {
      get
      {
        if (this._SupplyRequestRepository == null)
          this._SupplyRequestRepository = new SupplyRequestRepository<Res_SupplyRequest, Res_SupplyRequest_History>(_context);
        return _SupplyRequestRepository;
      }
    }

    public IResourceRepository TaskRepository
    {
      get
      {
        if (this._TaskRepository == null)
          this._TaskRepository = new TaskRepository<Res_Task, Res_Task_History>(_context);
        return _TaskRepository;
      }
    }

    public IResourceRepository TestScriptRepository
    {
      get
      {
        if (this._TestScriptRepository == null)
          this._TestScriptRepository = new TestScriptRepository<Res_TestScript, Res_TestScript_History>(_context);
        return _TestScriptRepository;
      }
    }

    public IResourceRepository ValueSetRepository
    {
      get
      {
        if (this._ValueSetRepository == null)
          this._ValueSetRepository = new ValueSetRepository<Res_ValueSet, Res_ValueSet_History>(_context);
        return _ValueSetRepository;
      }
    }

    public IResourceRepository VisionPrescriptionRepository
    {
      get
      {
        if (this._VisionPrescriptionRepository == null)
          this._VisionPrescriptionRepository = new VisionPrescriptionRepository<Res_VisionPrescription, Res_VisionPrescription_History>(_context);
        return _VisionPrescriptionRepository;
      }
    }


    #region Implementing IDiosposable...

    #region private dispose variable declaration...
    private bool disposed = false;
    #endregion

    /// <summary>
    /// Protected Virtual Dispose method
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          Debug.WriteLine("UnitOfWork is being disposed");
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    /// <summary>
    /// Dispose method
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion

  }
}

