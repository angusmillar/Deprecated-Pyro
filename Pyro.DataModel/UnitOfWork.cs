using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Blaze.Common.Interfaces.Repositories;
using Blaze.DataModel.Repository;

namespace Blaze.DataModel
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private Blaze.DataModel.DatabaseModel.DatabaseContext _context = null;

    private CommonRepository _CommonRepository;    
    private AccountRepository _AccountRepository;
    private ActivityDefinitionRepository _ActivityDefinitionRepository;
    private AllergyIntoleranceRepository _AllergyIntoleranceRepository;
    private AppointmentRepository _AppointmentRepository;
    private AppointmentResponseRepository _AppointmentResponseRepository;
    private AuditEventRepository _AuditEventRepository;
    private BasicRepository _BasicRepository;
    private BinaryRepository _BinaryRepository;
    private BodySiteRepository _BodySiteRepository;
    private BundleRepository _BundleRepository;
    private CarePlanRepository _CarePlanRepository;
    private CareTeamRepository _CareTeamRepository;
    private ClaimRepository _ClaimRepository;
    private ClaimResponseRepository _ClaimResponseRepository;
    private ClinicalImpressionRepository _ClinicalImpressionRepository;
    private CodeSystemRepository _CodeSystemRepository;
    private CommunicationRepository _CommunicationRepository;
    private CommunicationRequestRepository _CommunicationRequestRepository;
    private CompartmentDefinitionRepository _CompartmentDefinitionRepository;
    private CompositionRepository _CompositionRepository;
    private ConceptMapRepository _ConceptMapRepository;
    private ConditionRepository _ConditionRepository;
    private ConformanceRepository _ConformanceRepository;
    private ConsentRepository _ConsentRepository;
    private ContractRepository _ContractRepository;
    private CoverageRepository _CoverageRepository;
    private DataElementRepository _DataElementRepository;
    private DecisionSupportServiceModuleRepository _DecisionSupportServiceModuleRepository;
    private DetectedIssueRepository _DetectedIssueRepository;
    private DeviceRepository _DeviceRepository;
    private DeviceComponentRepository _DeviceComponentRepository;
    private DeviceMetricRepository _DeviceMetricRepository;
    private DeviceUseRequestRepository _DeviceUseRequestRepository;
    private DeviceUseStatementRepository _DeviceUseStatementRepository;
    private DiagnosticReportRepository _DiagnosticReportRepository;
    private DiagnosticRequestRepository _DiagnosticRequestRepository;
    private DocumentManifestRepository _DocumentManifestRepository;
    private DocumentReferenceRepository _DocumentReferenceRepository;
    private EligibilityRequestRepository _EligibilityRequestRepository;
    private EligibilityResponseRepository _EligibilityResponseRepository;
    private EncounterRepository _EncounterRepository;
    private EndpointRepository _EndpointRepository;
    private EnrollmentRequestRepository _EnrollmentRequestRepository;
    private EnrollmentResponseRepository _EnrollmentResponseRepository;
    private EpisodeOfCareRepository _EpisodeOfCareRepository;
    private ExpansionProfileRepository _ExpansionProfileRepository;
    private ExplanationOfBenefitRepository _ExplanationOfBenefitRepository;
    private FamilyMemberHistoryRepository _FamilyMemberHistoryRepository;
    private FlagRepository _FlagRepository;
    private GoalRepository _GoalRepository;
    private GroupRepository _GroupRepository;
    private GuidanceResponseRepository _GuidanceResponseRepository;
    private HealthcareServiceRepository _HealthcareServiceRepository;
    private ImagingManifestRepository _ImagingManifestRepository;
    private ImagingStudyRepository _ImagingStudyRepository;
    private ImmunizationRepository _ImmunizationRepository;
    private ImmunizationRecommendationRepository _ImmunizationRecommendationRepository;
    private ImplementationGuideRepository _ImplementationGuideRepository;
    private LibraryRepository _LibraryRepository;
    private LinkageRepository _LinkageRepository;
    private ListRepository _ListRepository;
    private LocationRepository _LocationRepository;
    private MeasureRepository _MeasureRepository;
    private MeasureReportRepository _MeasureReportRepository;
    private MediaRepository _MediaRepository;
    private MedicationRepository _MedicationRepository;
    private MedicationAdministrationRepository _MedicationAdministrationRepository;
    private MedicationDispenseRepository _MedicationDispenseRepository;
    private MedicationOrderRepository _MedicationOrderRepository;
    private MedicationStatementRepository _MedicationStatementRepository;
    private MessageHeaderRepository _MessageHeaderRepository;
    private NamingSystemRepository _NamingSystemRepository;
    private NutritionRequestRepository _NutritionRequestRepository;
    private ObservationRepository _ObservationRepository;
    private OperationDefinitionRepository _OperationDefinitionRepository;
    private OperationOutcomeRepository _OperationOutcomeRepository;
    private OrganizationRepository _OrganizationRepository;
    private ParametersRepository _ParametersRepository;
    private PatientRepository _PatientRepository;
    private PaymentNoticeRepository _PaymentNoticeRepository;
    private PaymentReconciliationRepository _PaymentReconciliationRepository;
    private PersonRepository _PersonRepository;
    private PlanDefinitionRepository _PlanDefinitionRepository;
    private PractitionerRepository _PractitionerRepository;
    private PractitionerRoleRepository _PractitionerRoleRepository;
    private ProcedureRepository _ProcedureRepository;
    private ProcedureRequestRepository _ProcedureRequestRepository;
    private ProcessRequestRepository _ProcessRequestRepository;
    private ProcessResponseRepository _ProcessResponseRepository;
    private ProvenanceRepository _ProvenanceRepository;
    private QuestionnaireRepository _QuestionnaireRepository;
    private QuestionnaireResponseRepository _QuestionnaireResponseRepository;
    private ReferralRequestRepository _ReferralRequestRepository;
    private RelatedPersonRepository _RelatedPersonRepository;
    private RiskAssessmentRepository _RiskAssessmentRepository;
    private ScheduleRepository _ScheduleRepository;
    private SearchParameterRepository _SearchParameterRepository;
    private SequenceRepository _SequenceRepository;
    private SlotRepository _SlotRepository;
    private SpecimenRepository _SpecimenRepository;
    private StructureDefinitionRepository _StructureDefinitionRepository;
    private StructureMapRepository _StructureMapRepository;
    private SubscriptionRepository _SubscriptionRepository;
    private SubstanceRepository _SubstanceRepository;
    private SupplyDeliveryRepository _SupplyDeliveryRepository;
    private SupplyRequestRepository _SupplyRequestRepository;
    private TaskRepository _TaskRepository;
    private TestScriptRepository _TestScriptRepository;
    private ValueSetRepository _ValueSetRepository;
    private VisionPrescriptionRepository _VisionPrescriptionRepository;

    public UnitOfWork()
    {
      _context = new Blaze.DataModel.DatabaseModel.DatabaseContext();
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
          this._AccountRepository = new AccountRepository(_context);
        return _AccountRepository;
      }
    }

    public IResourceRepository ActivityDefinitionRepository
    {
      get
      {
        if (this._ActivityDefinitionRepository == null)
          this._ActivityDefinitionRepository = new ActivityDefinitionRepository(_context);
        return _ActivityDefinitionRepository;
      }
    }

    public IResourceRepository AllergyIntoleranceRepository
    {
      get
      {
        if (this._AllergyIntoleranceRepository == null)
          this._AllergyIntoleranceRepository = new AllergyIntoleranceRepository(_context);
        return _AllergyIntoleranceRepository;
      }
    }

    public IResourceRepository AppointmentRepository
    {
      get
      {
        if (this._AppointmentRepository == null)
          this._AppointmentRepository = new AppointmentRepository(_context);
        return _AppointmentRepository;
      }
    }

    public IResourceRepository AppointmentResponseRepository
    {
      get
      {
        if (this._AppointmentResponseRepository == null)
          this._AppointmentResponseRepository = new AppointmentResponseRepository(_context);
        return _AppointmentResponseRepository;
      }
    }

    public IResourceRepository AuditEventRepository
    {
      get
      {
        if (this._AuditEventRepository == null)
          this._AuditEventRepository = new AuditEventRepository(_context);
        return _AuditEventRepository;
      }
    }

    public IResourceRepository BasicRepository
    {
      get
      {
        if (this._BasicRepository == null)
          this._BasicRepository = new BasicRepository(_context);
        return _BasicRepository;
      }
    }

    public IResourceRepository BinaryRepository
    {
      get
      {
        if (this._BinaryRepository == null)
          this._BinaryRepository = new BinaryRepository(_context);
        return _BinaryRepository;
      }
    }

    public IResourceRepository BodySiteRepository
    {
      get
      {
        if (this._BodySiteRepository == null)
          this._BodySiteRepository = new BodySiteRepository(_context);
        return _BodySiteRepository;
      }
    }

    public IResourceRepository BundleRepository
    {
      get
      {
        if (this._BundleRepository == null)
          this._BundleRepository = new BundleRepository(_context);
        return _BundleRepository;
      }
    }

    public IResourceRepository CarePlanRepository
    {
      get
      {
        if (this._CarePlanRepository == null)
          this._CarePlanRepository = new CarePlanRepository(_context);
        return _CarePlanRepository;
      }
    }

    public IResourceRepository CareTeamRepository
    {
      get
      {
        if (this._CareTeamRepository == null)
          this._CareTeamRepository = new CareTeamRepository(_context);
        return _CareTeamRepository;
      }
    }

    public IResourceRepository ClaimRepository
    {
      get
      {
        if (this._ClaimRepository == null)
          this._ClaimRepository = new ClaimRepository(_context);
        return _ClaimRepository;
      }
    }

    public IResourceRepository ClaimResponseRepository
    {
      get
      {
        if (this._ClaimResponseRepository == null)
          this._ClaimResponseRepository = new ClaimResponseRepository(_context);
        return _ClaimResponseRepository;
      }
    }

    public IResourceRepository ClinicalImpressionRepository
    {
      get
      {
        if (this._ClinicalImpressionRepository == null)
          this._ClinicalImpressionRepository = new ClinicalImpressionRepository(_context);
        return _ClinicalImpressionRepository;
      }
    }

    public IResourceRepository CodeSystemRepository
    {
      get
      {
        if (this._CodeSystemRepository == null)
          this._CodeSystemRepository = new CodeSystemRepository(_context);
        return _CodeSystemRepository;
      }
    }

    public IResourceRepository CommunicationRepository
    {
      get
      {
        if (this._CommunicationRepository == null)
          this._CommunicationRepository = new CommunicationRepository(_context);
        return _CommunicationRepository;
      }
    }

    public IResourceRepository CommunicationRequestRepository
    {
      get
      {
        if (this._CommunicationRequestRepository == null)
          this._CommunicationRequestRepository = new CommunicationRequestRepository(_context);
        return _CommunicationRequestRepository;
      }
    }

    public IResourceRepository CompartmentDefinitionRepository
    {
      get
      {
        if (this._CompartmentDefinitionRepository == null)
          this._CompartmentDefinitionRepository = new CompartmentDefinitionRepository(_context);
        return _CompartmentDefinitionRepository;
      }
    }

    public IResourceRepository CompositionRepository
    {
      get
      {
        if (this._CompositionRepository == null)
          this._CompositionRepository = new CompositionRepository(_context);
        return _CompositionRepository;
      }
    }

    public IResourceRepository ConceptMapRepository
    {
      get
      {
        if (this._ConceptMapRepository == null)
          this._ConceptMapRepository = new ConceptMapRepository(_context);
        return _ConceptMapRepository;
      }
    }

    public IResourceRepository ConditionRepository
    {
      get
      {
        if (this._ConditionRepository == null)
          this._ConditionRepository = new ConditionRepository(_context);
        return _ConditionRepository;
      }
    }

    public IResourceRepository ConformanceRepository
    {
      get
      {
        if (this._ConformanceRepository == null)
          this._ConformanceRepository = new ConformanceRepository(_context);
        return _ConformanceRepository;
      }
    }

    public IResourceRepository ConsentRepository
    {
      get
      {
        if (this._ConsentRepository == null)
          this._ConsentRepository = new ConsentRepository(_context);
        return _ConsentRepository;
      }
    }

    public IResourceRepository ContractRepository
    {
      get
      {
        if (this._ContractRepository == null)
          this._ContractRepository = new ContractRepository(_context);
        return _ContractRepository;
      }
    }

    public IResourceRepository CoverageRepository
    {
      get
      {
        if (this._CoverageRepository == null)
          this._CoverageRepository = new CoverageRepository(_context);
        return _CoverageRepository;
      }
    }

    public IResourceRepository DataElementRepository
    {
      get
      {
        if (this._DataElementRepository == null)
          this._DataElementRepository = new DataElementRepository(_context);
        return _DataElementRepository;
      }
    }

    public IResourceRepository DecisionSupportServiceModuleRepository
    {
      get
      {
        if (this._DecisionSupportServiceModuleRepository == null)
          this._DecisionSupportServiceModuleRepository = new DecisionSupportServiceModuleRepository(_context);
        return _DecisionSupportServiceModuleRepository;
      }
    }

    public IResourceRepository DetectedIssueRepository
    {
      get
      {
        if (this._DetectedIssueRepository == null)
          this._DetectedIssueRepository = new DetectedIssueRepository(_context);
        return _DetectedIssueRepository;
      }
    }

    public IResourceRepository DeviceRepository
    {
      get
      {
        if (this._DeviceRepository == null)
          this._DeviceRepository = new DeviceRepository(_context);
        return _DeviceRepository;
      }
    }

    public IResourceRepository DeviceComponentRepository
    {
      get
      {
        if (this._DeviceComponentRepository == null)
          this._DeviceComponentRepository = new DeviceComponentRepository(_context);
        return _DeviceComponentRepository;
      }
    }

    public IResourceRepository DeviceMetricRepository
    {
      get
      {
        if (this._DeviceMetricRepository == null)
          this._DeviceMetricRepository = new DeviceMetricRepository(_context);
        return _DeviceMetricRepository;
      }
    }

    public IResourceRepository DeviceUseRequestRepository
    {
      get
      {
        if (this._DeviceUseRequestRepository == null)
          this._DeviceUseRequestRepository = new DeviceUseRequestRepository(_context);
        return _DeviceUseRequestRepository;
      }
    }

    public IResourceRepository DeviceUseStatementRepository
    {
      get
      {
        if (this._DeviceUseStatementRepository == null)
          this._DeviceUseStatementRepository = new DeviceUseStatementRepository(_context);
        return _DeviceUseStatementRepository;
      }
    }

    public IResourceRepository DiagnosticReportRepository
    {
      get
      {
        if (this._DiagnosticReportRepository == null)
          this._DiagnosticReportRepository = new DiagnosticReportRepository(_context);
        return _DiagnosticReportRepository;
      }
    }

    public IResourceRepository DiagnosticRequestRepository
    {
      get
      {
        if (this._DiagnosticRequestRepository == null)
          this._DiagnosticRequestRepository = new DiagnosticRequestRepository(_context);
        return _DiagnosticRequestRepository;
      }
    }

    public IResourceRepository DocumentManifestRepository
    {
      get
      {
        if (this._DocumentManifestRepository == null)
          this._DocumentManifestRepository = new DocumentManifestRepository(_context);
        return _DocumentManifestRepository;
      }
    }

    public IResourceRepository DocumentReferenceRepository
    {
      get
      {
        if (this._DocumentReferenceRepository == null)
          this._DocumentReferenceRepository = new DocumentReferenceRepository(_context);
        return _DocumentReferenceRepository;
      }
    }

    public IResourceRepository EligibilityRequestRepository
    {
      get
      {
        if (this._EligibilityRequestRepository == null)
          this._EligibilityRequestRepository = new EligibilityRequestRepository(_context);
        return _EligibilityRequestRepository;
      }
    }

    public IResourceRepository EligibilityResponseRepository
    {
      get
      {
        if (this._EligibilityResponseRepository == null)
          this._EligibilityResponseRepository = new EligibilityResponseRepository(_context);
        return _EligibilityResponseRepository;
      }
    }

    public IResourceRepository EncounterRepository
    {
      get
      {
        if (this._EncounterRepository == null)
          this._EncounterRepository = new EncounterRepository(_context);
        return _EncounterRepository;
      }
    }

    public IResourceRepository EndpointRepository
    {
      get
      {
        if (this._EndpointRepository == null)
          this._EndpointRepository = new EndpointRepository(_context);
        return _EndpointRepository;
      }
    }

    public IResourceRepository EnrollmentRequestRepository
    {
      get
      {
        if (this._EnrollmentRequestRepository == null)
          this._EnrollmentRequestRepository = new EnrollmentRequestRepository(_context);
        return _EnrollmentRequestRepository;
      }
    }

    public IResourceRepository EnrollmentResponseRepository
    {
      get
      {
        if (this._EnrollmentResponseRepository == null)
          this._EnrollmentResponseRepository = new EnrollmentResponseRepository(_context);
        return _EnrollmentResponseRepository;
      }
    }

    public IResourceRepository EpisodeOfCareRepository
    {
      get
      {
        if (this._EpisodeOfCareRepository == null)
          this._EpisodeOfCareRepository = new EpisodeOfCareRepository(_context);
        return _EpisodeOfCareRepository;
      }
    }

    public IResourceRepository ExpansionProfileRepository
    {
      get
      {
        if (this._ExpansionProfileRepository == null)
          this._ExpansionProfileRepository = new ExpansionProfileRepository(_context);
        return _ExpansionProfileRepository;
      }
    }

    public IResourceRepository ExplanationOfBenefitRepository
    {
      get
      {
        if (this._ExplanationOfBenefitRepository == null)
          this._ExplanationOfBenefitRepository = new ExplanationOfBenefitRepository(_context);
        return _ExplanationOfBenefitRepository;
      }
    }

    public IResourceRepository FamilyMemberHistoryRepository
    {
      get
      {
        if (this._FamilyMemberHistoryRepository == null)
          this._FamilyMemberHistoryRepository = new FamilyMemberHistoryRepository(_context);
        return _FamilyMemberHistoryRepository;
      }
    }

    public IResourceRepository FlagRepository
    {
      get
      {
        if (this._FlagRepository == null)
          this._FlagRepository = new FlagRepository(_context);
        return _FlagRepository;
      }
    }

    public IResourceRepository GoalRepository
    {
      get
      {
        if (this._GoalRepository == null)
          this._GoalRepository = new GoalRepository(_context);
        return _GoalRepository;
      }
    }

    public IResourceRepository GroupRepository
    {
      get
      {
        if (this._GroupRepository == null)
          this._GroupRepository = new GroupRepository(_context);
        return _GroupRepository;
      }
    }

    public IResourceRepository GuidanceResponseRepository
    {
      get
      {
        if (this._GuidanceResponseRepository == null)
          this._GuidanceResponseRepository = new GuidanceResponseRepository(_context);
        return _GuidanceResponseRepository;
      }
    }

    public IResourceRepository HealthcareServiceRepository
    {
      get
      {
        if (this._HealthcareServiceRepository == null)
          this._HealthcareServiceRepository = new HealthcareServiceRepository(_context);
        return _HealthcareServiceRepository;
      }
    }

    public IResourceRepository ImagingManifestRepository
    {
      get
      {
        if (this._ImagingManifestRepository == null)
          this._ImagingManifestRepository = new ImagingManifestRepository(_context);
        return _ImagingManifestRepository;
      }
    }

    public IResourceRepository ImagingStudyRepository
    {
      get
      {
        if (this._ImagingStudyRepository == null)
          this._ImagingStudyRepository = new ImagingStudyRepository(_context);
        return _ImagingStudyRepository;
      }
    }

    public IResourceRepository ImmunizationRepository
    {
      get
      {
        if (this._ImmunizationRepository == null)
          this._ImmunizationRepository = new ImmunizationRepository(_context);
        return _ImmunizationRepository;
      }
    }

    public IResourceRepository ImmunizationRecommendationRepository
    {
      get
      {
        if (this._ImmunizationRecommendationRepository == null)
          this._ImmunizationRecommendationRepository = new ImmunizationRecommendationRepository(_context);
        return _ImmunizationRecommendationRepository;
      }
    }

    public IResourceRepository ImplementationGuideRepository
    {
      get
      {
        if (this._ImplementationGuideRepository == null)
          this._ImplementationGuideRepository = new ImplementationGuideRepository(_context);
        return _ImplementationGuideRepository;
      }
    }

    public IResourceRepository LibraryRepository
    {
      get
      {
        if (this._LibraryRepository == null)
          this._LibraryRepository = new LibraryRepository(_context);
        return _LibraryRepository;
      }
    }

    public IResourceRepository LinkageRepository
    {
      get
      {
        if (this._LinkageRepository == null)
          this._LinkageRepository = new LinkageRepository(_context);
        return _LinkageRepository;
      }
    }

    public IResourceRepository ListRepository
    {
      get
      {
        if (this._ListRepository == null)
          this._ListRepository = new ListRepository(_context);
        return _ListRepository;
      }
    }

    public IResourceRepository LocationRepository
    {
      get
      {
        if (this._LocationRepository == null)
          this._LocationRepository = new LocationRepository(_context);
        return _LocationRepository;
      }
    }

    public IResourceRepository MeasureRepository
    {
      get
      {
        if (this._MeasureRepository == null)
          this._MeasureRepository = new MeasureRepository(_context);
        return _MeasureRepository;
      }
    }

    public IResourceRepository MeasureReportRepository
    {
      get
      {
        if (this._MeasureReportRepository == null)
          this._MeasureReportRepository = new MeasureReportRepository(_context);
        return _MeasureReportRepository;
      }
    }

    public IResourceRepository MediaRepository
    {
      get
      {
        if (this._MediaRepository == null)
          this._MediaRepository = new MediaRepository(_context);
        return _MediaRepository;
      }
    }

    public IResourceRepository MedicationRepository
    {
      get
      {
        if (this._MedicationRepository == null)
          this._MedicationRepository = new MedicationRepository(_context);
        return _MedicationRepository;
      }
    }

    public IResourceRepository MedicationAdministrationRepository
    {
      get
      {
        if (this._MedicationAdministrationRepository == null)
          this._MedicationAdministrationRepository = new MedicationAdministrationRepository(_context);
        return _MedicationAdministrationRepository;
      }
    }

    public IResourceRepository MedicationDispenseRepository
    {
      get
      {
        if (this._MedicationDispenseRepository == null)
          this._MedicationDispenseRepository = new MedicationDispenseRepository(_context);
        return _MedicationDispenseRepository;
      }
    }

    public IResourceRepository MedicationOrderRepository
    {
      get
      {
        if (this._MedicationOrderRepository == null)
          this._MedicationOrderRepository = new MedicationOrderRepository(_context);
        return _MedicationOrderRepository;
      }
    }

    public IResourceRepository MedicationStatementRepository
    {
      get
      {
        if (this._MedicationStatementRepository == null)
          this._MedicationStatementRepository = new MedicationStatementRepository(_context);
        return _MedicationStatementRepository;
      }
    }

    public IResourceRepository MessageHeaderRepository
    {
      get
      {
        if (this._MessageHeaderRepository == null)
          this._MessageHeaderRepository = new MessageHeaderRepository(_context);
        return _MessageHeaderRepository;
      }
    }

    public IResourceRepository NamingSystemRepository
    {
      get
      {
        if (this._NamingSystemRepository == null)
          this._NamingSystemRepository = new NamingSystemRepository(_context);
        return _NamingSystemRepository;
      }
    }

    public IResourceRepository NutritionRequestRepository
    {
      get
      {
        if (this._NutritionRequestRepository == null)
          this._NutritionRequestRepository = new NutritionRequestRepository(_context);
        return _NutritionRequestRepository;
      }
    }

    public IResourceRepository ObservationRepository
    {
      get
      {
        if (this._ObservationRepository == null)
          this._ObservationRepository = new ObservationRepository(_context);
        return _ObservationRepository;
      }
    }

    public IResourceRepository OperationDefinitionRepository
    {
      get
      {
        if (this._OperationDefinitionRepository == null)
          this._OperationDefinitionRepository = new OperationDefinitionRepository(_context);
        return _OperationDefinitionRepository;
      }
    }

    public IResourceRepository OperationOutcomeRepository
    {
      get
      {
        if (this._OperationOutcomeRepository == null)
          this._OperationOutcomeRepository = new OperationOutcomeRepository(_context);
        return _OperationOutcomeRepository;
      }
    }

    public IResourceRepository OrganizationRepository
    {
      get
      {
        if (this._OrganizationRepository == null)
          this._OrganizationRepository = new OrganizationRepository(_context);
        return _OrganizationRepository;
      }
    }

    public IResourceRepository ParametersRepository
    {
      get
      {
        if (this._ParametersRepository == null)
          this._ParametersRepository = new ParametersRepository(_context);
        return _ParametersRepository;
      }
    }

    public IResourceRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new PatientRepository(_context);
        return _PatientRepository;
      }
    }

    public IResourceRepository PaymentNoticeRepository
    {
      get
      {
        if (this._PaymentNoticeRepository == null)
          this._PaymentNoticeRepository = new PaymentNoticeRepository(_context);
        return _PaymentNoticeRepository;
      }
    }

    public IResourceRepository PaymentReconciliationRepository
    {
      get
      {
        if (this._PaymentReconciliationRepository == null)
          this._PaymentReconciliationRepository = new PaymentReconciliationRepository(_context);
        return _PaymentReconciliationRepository;
      }
    }

    public IResourceRepository PersonRepository
    {
      get
      {
        if (this._PersonRepository == null)
          this._PersonRepository = new PersonRepository(_context);
        return _PersonRepository;
      }
    }

    public IResourceRepository PlanDefinitionRepository
    {
      get
      {
        if (this._PlanDefinitionRepository == null)
          this._PlanDefinitionRepository = new PlanDefinitionRepository(_context);
        return _PlanDefinitionRepository;
      }
    }

    public IResourceRepository PractitionerRepository
    {
      get
      {
        if (this._PractitionerRepository == null)
          this._PractitionerRepository = new PractitionerRepository(_context);
        return _PractitionerRepository;
      }
    }

    public IResourceRepository PractitionerRoleRepository
    {
      get
      {
        if (this._PractitionerRoleRepository == null)
          this._PractitionerRoleRepository = new PractitionerRoleRepository(_context);
        return _PractitionerRoleRepository;
      }
    }

    public IResourceRepository ProcedureRepository
    {
      get
      {
        if (this._ProcedureRepository == null)
          this._ProcedureRepository = new ProcedureRepository(_context);
        return _ProcedureRepository;
      }
    }

    public IResourceRepository ProcedureRequestRepository
    {
      get
      {
        if (this._ProcedureRequestRepository == null)
          this._ProcedureRequestRepository = new ProcedureRequestRepository(_context);
        return _ProcedureRequestRepository;
      }
    }

    public IResourceRepository ProcessRequestRepository
    {
      get
      {
        if (this._ProcessRequestRepository == null)
          this._ProcessRequestRepository = new ProcessRequestRepository(_context);
        return _ProcessRequestRepository;
      }
    }

    public IResourceRepository ProcessResponseRepository
    {
      get
      {
        if (this._ProcessResponseRepository == null)
          this._ProcessResponseRepository = new ProcessResponseRepository(_context);
        return _ProcessResponseRepository;
      }
    }

    public IResourceRepository ProvenanceRepository
    {
      get
      {
        if (this._ProvenanceRepository == null)
          this._ProvenanceRepository = new ProvenanceRepository(_context);
        return _ProvenanceRepository;
      }
    }

    public IResourceRepository QuestionnaireRepository
    {
      get
      {
        if (this._QuestionnaireRepository == null)
          this._QuestionnaireRepository = new QuestionnaireRepository(_context);
        return _QuestionnaireRepository;
      }
    }

    public IResourceRepository QuestionnaireResponseRepository
    {
      get
      {
        if (this._QuestionnaireResponseRepository == null)
          this._QuestionnaireResponseRepository = new QuestionnaireResponseRepository(_context);
        return _QuestionnaireResponseRepository;
      }
    }

    public IResourceRepository ReferralRequestRepository
    {
      get
      {
        if (this._ReferralRequestRepository == null)
          this._ReferralRequestRepository = new ReferralRequestRepository(_context);
        return _ReferralRequestRepository;
      }
    }

    public IResourceRepository RelatedPersonRepository
    {
      get
      {
        if (this._RelatedPersonRepository == null)
          this._RelatedPersonRepository = new RelatedPersonRepository(_context);
        return _RelatedPersonRepository;
      }
    }

    public IResourceRepository RiskAssessmentRepository
    {
      get
      {
        if (this._RiskAssessmentRepository == null)
          this._RiskAssessmentRepository = new RiskAssessmentRepository(_context);
        return _RiskAssessmentRepository;
      }
    }

    public IResourceRepository ScheduleRepository
    {
      get
      {
        if (this._ScheduleRepository == null)
          this._ScheduleRepository = new ScheduleRepository(_context);
        return _ScheduleRepository;
      }
    }

    public IResourceRepository SearchParameterRepository
    {
      get
      {
        if (this._SearchParameterRepository == null)
          this._SearchParameterRepository = new SearchParameterRepository(_context);
        return _SearchParameterRepository;
      }
    }

    public IResourceRepository SequenceRepository
    {
      get
      {
        if (this._SequenceRepository == null)
          this._SequenceRepository = new SequenceRepository(_context);
        return _SequenceRepository;
      }
    }

    public IResourceRepository SlotRepository
    {
      get
      {
        if (this._SlotRepository == null)
          this._SlotRepository = new SlotRepository(_context);
        return _SlotRepository;
      }
    }

    public IResourceRepository SpecimenRepository
    {
      get
      {
        if (this._SpecimenRepository == null)
          this._SpecimenRepository = new SpecimenRepository(_context);
        return _SpecimenRepository;
      }
    }

    public IResourceRepository StructureDefinitionRepository
    {
      get
      {
        if (this._StructureDefinitionRepository == null)
          this._StructureDefinitionRepository = new StructureDefinitionRepository(_context);
        return _StructureDefinitionRepository;
      }
    }

    public IResourceRepository StructureMapRepository
    {
      get
      {
        if (this._StructureMapRepository == null)
          this._StructureMapRepository = new StructureMapRepository(_context);
        return _StructureMapRepository;
      }
    }

    public IResourceRepository SubscriptionRepository
    {
      get
      {
        if (this._SubscriptionRepository == null)
          this._SubscriptionRepository = new SubscriptionRepository(_context);
        return _SubscriptionRepository;
      }
    }

    public IResourceRepository SubstanceRepository
    {
      get
      {
        if (this._SubstanceRepository == null)
          this._SubstanceRepository = new SubstanceRepository(_context);
        return _SubstanceRepository;
      }
    }

    public IResourceRepository SupplyDeliveryRepository
    {
      get
      {
        if (this._SupplyDeliveryRepository == null)
          this._SupplyDeliveryRepository = new SupplyDeliveryRepository(_context);
        return _SupplyDeliveryRepository;
      }
    }

    public IResourceRepository SupplyRequestRepository
    {
      get
      {
        if (this._SupplyRequestRepository == null)
          this._SupplyRequestRepository = new SupplyRequestRepository(_context);
        return _SupplyRequestRepository;
      }
    }

    public IResourceRepository TaskRepository
    {
      get
      {
        if (this._TaskRepository == null)
          this._TaskRepository = new TaskRepository(_context);
        return _TaskRepository;
      }
    }

    public IResourceRepository TestScriptRepository
    {
      get
      {
        if (this._TestScriptRepository == null)
          this._TestScriptRepository = new TestScriptRepository(_context);
        return _TestScriptRepository;
      }
    }

    public IResourceRepository ValueSetRepository
    {
      get
      {
        if (this._ValueSetRepository == null)
          this._ValueSetRepository = new ValueSetRepository(_context);
        return _ValueSetRepository;
      }
    }

    public IResourceRepository VisionPrescriptionRepository
    {
      get
      {
        if (this._VisionPrescriptionRepository == null)
          this._VisionPrescriptionRepository = new VisionPrescriptionRepository(_context);
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

