namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
  using Hl7.Fhir.Model;
  using Pyro.DataLayer.DbModel.DatabaseContext;
  using Pyro.DataLayer.DbModel.EntityBase;
  using Pyro.DataLayer.DbModel.EntityGenerated;
  using System;
  using System.Data.Entity.Migrations;
  using System.Linq;

  public partial class ConversionXMLBlobtoGZipResourceColumn : DbMigration
  {
    //This Migration was manumaly created to convert the old string XMLBlob coloum to a new byte[] Resource coloum where the contents is ZGipped
    //The older XMLBlob column is set to Null and will remain as long as this migration is required.
    public override void Up()
    {
      ProcessResourceType<AccountRes, AccountResIndexString, AccountResIndexToken, AccountResIndexUri, AccountResIndexReference, AccountResIndexQuantity, AccountResIndexDateTime>("Account");
      ProcessResourceType<ActivityDefinitionRes, ActivityDefinitionResIndexString, ActivityDefinitionResIndexToken, ActivityDefinitionResIndexUri, ActivityDefinitionResIndexReference, ActivityDefinitionResIndexQuantity, ActivityDefinitionResIndexDateTime>("ActivityDefinition");
      ProcessResourceType<AdverseEventRes, AdverseEventResIndexString, AdverseEventResIndexToken, AdverseEventResIndexUri, AdverseEventResIndexReference, AdverseEventResIndexQuantity, AdverseEventResIndexDateTime>("AdverseEvent");
      ProcessResourceType<AllergyIntoleranceRes, AllergyIntoleranceResIndexString, AllergyIntoleranceResIndexToken, AllergyIntoleranceResIndexUri, AllergyIntoleranceResIndexReference, AllergyIntoleranceResIndexQuantity, AllergyIntoleranceResIndexDateTime>("AllergyIntolerance");
      ProcessResourceType<AppointmentRes, AppointmentResIndexString, AppointmentResIndexToken, AppointmentResIndexUri, AppointmentResIndexReference, AppointmentResIndexQuantity, AppointmentResIndexDateTime>("Appointment");
      ProcessResourceType<AppointmentResponseRes, AppointmentResponseResIndexString, AppointmentResponseResIndexToken, AppointmentResponseResIndexUri, AppointmentResponseResIndexReference, AppointmentResponseResIndexQuantity, AppointmentResponseResIndexDateTime>("AppointmentResponse");
      ProcessResourceType<AuditEventRes, AuditEventResIndexString, AuditEventResIndexToken, AuditEventResIndexUri, AuditEventResIndexReference, AuditEventResIndexQuantity, AuditEventResIndexDateTime>("AuditEvent");
      ProcessResourceType<BasicRes, BasicResIndexString, BasicResIndexToken, BasicResIndexUri, BasicResIndexReference, BasicResIndexQuantity, BasicResIndexDateTime>("Basic");
      ProcessResourceType<BinaryRes, BinaryResIndexString, BinaryResIndexToken, BinaryResIndexUri, BinaryResIndexReference, BinaryResIndexQuantity, BinaryResIndexDateTime>("Binary");
      //ProcessResourceType<BodySiteRes, BodySiteResIndexString, BodySiteResIndexToken, BodySiteResIndexUri, BodySiteResIndexReference, BodySiteResIndexQuantity, BodySiteResIndexDateTime>("BodySite");
      ProcessResourceType<BundleRes, BundleResIndexString, BundleResIndexToken, BundleResIndexUri, BundleResIndexReference, BundleResIndexQuantity, BundleResIndexDateTime>("Bundle");
      ProcessResourceType<CapabilityStatementRes, CapabilityStatementResIndexString, CapabilityStatementResIndexToken, CapabilityStatementResIndexUri, CapabilityStatementResIndexReference, CapabilityStatementResIndexQuantity, CapabilityStatementResIndexDateTime>("CapabilityStatement");
      ProcessResourceType<CarePlanRes, CarePlanResIndexString, CarePlanResIndexToken, CarePlanResIndexUri, CarePlanResIndexReference, CarePlanResIndexQuantity, CarePlanResIndexDateTime>("CarePlan");
      ProcessResourceType<CareTeamRes, CareTeamResIndexString, CareTeamResIndexToken, CareTeamResIndexUri, CareTeamResIndexReference, CareTeamResIndexQuantity, CareTeamResIndexDateTime>("CareTeam");
      ProcessResourceType<ChargeItemRes, ChargeItemResIndexString, ChargeItemResIndexToken, ChargeItemResIndexUri, ChargeItemResIndexReference, ChargeItemResIndexQuantity, ChargeItemResIndexDateTime>("ChargeItem");
      ProcessResourceType<ClaimRes, ClaimResIndexString, ClaimResIndexToken, ClaimResIndexUri, ClaimResIndexReference, ClaimResIndexQuantity, ClaimResIndexDateTime>("Claim");
      ProcessResourceType<ClaimResponseRes, ClaimResponseResIndexString, ClaimResponseResIndexToken, ClaimResponseResIndexUri, ClaimResponseResIndexReference, ClaimResponseResIndexQuantity, ClaimResponseResIndexDateTime>("ClaimResponse");
      ProcessResourceType<ClinicalImpressionRes, ClinicalImpressionResIndexString, ClinicalImpressionResIndexToken, ClinicalImpressionResIndexUri, ClinicalImpressionResIndexReference, ClinicalImpressionResIndexQuantity, ClinicalImpressionResIndexDateTime>("ClinicalImpression");
      ProcessResourceType<CodeSystemRes, CodeSystemResIndexString, CodeSystemResIndexToken, CodeSystemResIndexUri, CodeSystemResIndexReference, CodeSystemResIndexQuantity, CodeSystemResIndexDateTime>("CodeSystem");
      ProcessResourceType<CommunicationRes, CommunicationResIndexString, CommunicationResIndexToken, CommunicationResIndexUri, CommunicationResIndexReference, CommunicationResIndexQuantity, CommunicationResIndexDateTime>("Communication");
      ProcessResourceType<CommunicationRequestRes, CommunicationRequestResIndexString, CommunicationRequestResIndexToken, CommunicationRequestResIndexUri, CommunicationRequestResIndexReference, CommunicationRequestResIndexQuantity, CommunicationRequestResIndexDateTime>("CommunicationRequest");
      ProcessResourceType<CompartmentDefinitionRes, CompartmentDefinitionResIndexString, CompartmentDefinitionResIndexToken, CompartmentDefinitionResIndexUri, CompartmentDefinitionResIndexReference, CompartmentDefinitionResIndexQuantity, CompartmentDefinitionResIndexDateTime>("CompartmentDefinition");
      ProcessResourceType<CompositionRes, CompositionResIndexString, CompositionResIndexToken, CompositionResIndexUri, CompositionResIndexReference, CompositionResIndexQuantity, CompositionResIndexDateTime>("Composition");
      ProcessResourceType<ConceptMapRes, ConceptMapResIndexString, ConceptMapResIndexToken, ConceptMapResIndexUri, ConceptMapResIndexReference, ConceptMapResIndexQuantity, ConceptMapResIndexDateTime>("ConceptMap");
      ProcessResourceType<ConditionRes, ConditionResIndexString, ConditionResIndexToken, ConditionResIndexUri, ConditionResIndexReference, ConditionResIndexQuantity, ConditionResIndexDateTime>("Condition");
      ProcessResourceType<ConsentRes, ConsentResIndexString, ConsentResIndexToken, ConsentResIndexUri, ConsentResIndexReference, ConsentResIndexQuantity, ConsentResIndexDateTime>("Consent");
      ProcessResourceType<ContractRes, ContractResIndexString, ContractResIndexToken, ContractResIndexUri, ContractResIndexReference, ContractResIndexQuantity, ContractResIndexDateTime>("Contract");
      ProcessResourceType<CoverageRes, CoverageResIndexString, CoverageResIndexToken, CoverageResIndexUri, CoverageResIndexReference, CoverageResIndexQuantity, CoverageResIndexDateTime>("Coverage");
     // ProcessResourceType<DataElementRes, DataElementResIndexString, DataElementResIndexToken, DataElementResIndexUri, DataElementResIndexReference, DataElementResIndexQuantity, DataElementResIndexDateTime>("DataElement");
      ProcessResourceType<DetectedIssueRes, DetectedIssueResIndexString, DetectedIssueResIndexToken, DetectedIssueResIndexUri, DetectedIssueResIndexReference, DetectedIssueResIndexQuantity, DetectedIssueResIndexDateTime>("DetectedIssue");
      ProcessResourceType<DeviceRes, DeviceResIndexString, DeviceResIndexToken, DeviceResIndexUri, DeviceResIndexReference, DeviceResIndexQuantity, DeviceResIndexDateTime>("Device");
     // ProcessResourceType<DeviceComponentRes, DeviceComponentResIndexString, DeviceComponentResIndexToken, DeviceComponentResIndexUri, DeviceComponentResIndexReference, DeviceComponentResIndexQuantity, DeviceComponentResIndexDateTime>("DeviceComponent");
      ProcessResourceType<DeviceMetricRes, DeviceMetricResIndexString, DeviceMetricResIndexToken, DeviceMetricResIndexUri, DeviceMetricResIndexReference, DeviceMetricResIndexQuantity, DeviceMetricResIndexDateTime>("DeviceMetric");
      ProcessResourceType<DeviceRequestRes, DeviceRequestResIndexString, DeviceRequestResIndexToken, DeviceRequestResIndexUri, DeviceRequestResIndexReference, DeviceRequestResIndexQuantity, DeviceRequestResIndexDateTime>("DeviceRequest");
      ProcessResourceType<DeviceUseStatementRes, DeviceUseStatementResIndexString, DeviceUseStatementResIndexToken, DeviceUseStatementResIndexUri, DeviceUseStatementResIndexReference, DeviceUseStatementResIndexQuantity, DeviceUseStatementResIndexDateTime>("DeviceUseStatement");
      ProcessResourceType<DiagnosticReportRes, DiagnosticReportResIndexString, DiagnosticReportResIndexToken, DiagnosticReportResIndexUri, DiagnosticReportResIndexReference, DiagnosticReportResIndexQuantity, DiagnosticReportResIndexDateTime>("DiagnosticReport");
      ProcessResourceType<DocumentManifestRes, DocumentManifestResIndexString, DocumentManifestResIndexToken, DocumentManifestResIndexUri, DocumentManifestResIndexReference, DocumentManifestResIndexQuantity, DocumentManifestResIndexDateTime>("DocumentManifest");
      ProcessResourceType<DocumentReferenceRes, DocumentReferenceResIndexString, DocumentReferenceResIndexToken, DocumentReferenceResIndexUri, DocumentReferenceResIndexReference, DocumentReferenceResIndexQuantity, DocumentReferenceResIndexDateTime>("DocumentReference");
     // ProcessResourceType<EligibilityRequestRes, EligibilityRequestResIndexString, EligibilityRequestResIndexToken, EligibilityRequestResIndexUri, EligibilityRequestResIndexReference, EligibilityRequestResIndexQuantity, EligibilityRequestResIndexDateTime>("EligibilityRequest");
     // ProcessResourceType<EligibilityResponseRes, EligibilityResponseResIndexString, EligibilityResponseResIndexToken, EligibilityResponseResIndexUri, EligibilityResponseResIndexReference, EligibilityResponseResIndexQuantity, EligibilityResponseResIndexDateTime>("EligibilityResponse");
      ProcessResourceType<EncounterRes, EncounterResIndexString, EncounterResIndexToken, EncounterResIndexUri, EncounterResIndexReference, EncounterResIndexQuantity, EncounterResIndexDateTime>("Encounter");
      ProcessResourceType<EndpointRes, EndpointResIndexString, EndpointResIndexToken, EndpointResIndexUri, EndpointResIndexReference, EndpointResIndexQuantity, EndpointResIndexDateTime>("Endpoint");
      ProcessResourceType<EnrollmentRequestRes, EnrollmentRequestResIndexString, EnrollmentRequestResIndexToken, EnrollmentRequestResIndexUri, EnrollmentRequestResIndexReference, EnrollmentRequestResIndexQuantity, EnrollmentRequestResIndexDateTime>("EnrollmentRequest");
      ProcessResourceType<EnrollmentResponseRes, EnrollmentResponseResIndexString, EnrollmentResponseResIndexToken, EnrollmentResponseResIndexUri, EnrollmentResponseResIndexReference, EnrollmentResponseResIndexQuantity, EnrollmentResponseResIndexDateTime>("EnrollmentResponse");
      ProcessResourceType<EpisodeOfCareRes, EpisodeOfCareResIndexString, EpisodeOfCareResIndexToken, EpisodeOfCareResIndexUri, EpisodeOfCareResIndexReference, EpisodeOfCareResIndexQuantity, EpisodeOfCareResIndexDateTime>("EpisodeOfCare");
     // ProcessResourceType<ExpansionProfileRes, ExpansionProfileResIndexString, ExpansionProfileResIndexToken, ExpansionProfileResIndexUri, ExpansionProfileResIndexReference, ExpansionProfileResIndexQuantity, ExpansionProfileResIndexDateTime>("ExpansionProfile");
      ProcessResourceType<ExplanationOfBenefitRes, ExplanationOfBenefitResIndexString, ExplanationOfBenefitResIndexToken, ExplanationOfBenefitResIndexUri, ExplanationOfBenefitResIndexReference, ExplanationOfBenefitResIndexQuantity, ExplanationOfBenefitResIndexDateTime>("ExplanationOfBenefit");
      ProcessResourceType<FamilyMemberHistoryRes, FamilyMemberHistoryResIndexString, FamilyMemberHistoryResIndexToken, FamilyMemberHistoryResIndexUri, FamilyMemberHistoryResIndexReference, FamilyMemberHistoryResIndexQuantity, FamilyMemberHistoryResIndexDateTime>("FamilyMemberHistory");
      ProcessResourceType<FlagRes, FlagResIndexString, FlagResIndexToken, FlagResIndexUri, FlagResIndexReference, FlagResIndexQuantity, FlagResIndexDateTime>("Flag");
      ProcessResourceType<GoalRes, GoalResIndexString, GoalResIndexToken, GoalResIndexUri, GoalResIndexReference, GoalResIndexQuantity, GoalResIndexDateTime>("Goal");
      ProcessResourceType<GraphDefinitionRes, GraphDefinitionResIndexString, GraphDefinitionResIndexToken, GraphDefinitionResIndexUri, GraphDefinitionResIndexReference, GraphDefinitionResIndexQuantity, GraphDefinitionResIndexDateTime>("GraphDefinition");
      ProcessResourceType<GroupRes, GroupResIndexString, GroupResIndexToken, GroupResIndexUri, GroupResIndexReference, GroupResIndexQuantity, GroupResIndexDateTime>("Group");
      ProcessResourceType<GuidanceResponseRes, GuidanceResponseResIndexString, GuidanceResponseResIndexToken, GuidanceResponseResIndexUri, GuidanceResponseResIndexReference, GuidanceResponseResIndexQuantity, GuidanceResponseResIndexDateTime>("GuidanceResponse");
      ProcessResourceType<HealthcareServiceRes, HealthcareServiceResIndexString, HealthcareServiceResIndexToken, HealthcareServiceResIndexUri, HealthcareServiceResIndexReference, HealthcareServiceResIndexQuantity, HealthcareServiceResIndexDateTime>("HealthcareService");
     // ProcessResourceType<ImagingManifestRes, ImagingManifestResIndexString, ImagingManifestResIndexToken, ImagingManifestResIndexUri, ImagingManifestResIndexReference, ImagingManifestResIndexQuantity, ImagingManifestResIndexDateTime>("ImagingManifest");
      ProcessResourceType<ImagingStudyRes, ImagingStudyResIndexString, ImagingStudyResIndexToken, ImagingStudyResIndexUri, ImagingStudyResIndexReference, ImagingStudyResIndexQuantity, ImagingStudyResIndexDateTime>("ImagingStudy");
      ProcessResourceType<ImmunizationRes, ImmunizationResIndexString, ImmunizationResIndexToken, ImmunizationResIndexUri, ImmunizationResIndexReference, ImmunizationResIndexQuantity, ImmunizationResIndexDateTime>("Immunization");
      ProcessResourceType<ImmunizationRecommendationRes, ImmunizationRecommendationResIndexString, ImmunizationRecommendationResIndexToken, ImmunizationRecommendationResIndexUri, ImmunizationRecommendationResIndexReference, ImmunizationRecommendationResIndexQuantity, ImmunizationRecommendationResIndexDateTime>("ImmunizationRecommendation");
      ProcessResourceType<ImplementationGuideRes, ImplementationGuideResIndexString, ImplementationGuideResIndexToken, ImplementationGuideResIndexUri, ImplementationGuideResIndexReference, ImplementationGuideResIndexQuantity, ImplementationGuideResIndexDateTime>("ImplementationGuide");
      ProcessResourceType<LibraryRes, LibraryResIndexString, LibraryResIndexToken, LibraryResIndexUri, LibraryResIndexReference, LibraryResIndexQuantity, LibraryResIndexDateTime>("Library");
      ProcessResourceType<LinkageRes, LinkageResIndexString, LinkageResIndexToken, LinkageResIndexUri, LinkageResIndexReference, LinkageResIndexQuantity, LinkageResIndexDateTime>("Linkage");
      ProcessResourceType<ListRes, ListResIndexString, ListResIndexToken, ListResIndexUri, ListResIndexReference, ListResIndexQuantity, ListResIndexDateTime>("List");
      ProcessResourceType<LocationRes, LocationResIndexString, LocationResIndexToken, LocationResIndexUri, LocationResIndexReference, LocationResIndexQuantity, LocationResIndexDateTime>("Location");
      ProcessResourceType<MeasureRes, MeasureResIndexString, MeasureResIndexToken, MeasureResIndexUri, MeasureResIndexReference, MeasureResIndexQuantity, MeasureResIndexDateTime>("Measure");
      ProcessResourceType<MeasureReportRes, MeasureReportResIndexString, MeasureReportResIndexToken, MeasureReportResIndexUri, MeasureReportResIndexReference, MeasureReportResIndexQuantity, MeasureReportResIndexDateTime>("MeasureReport");
      ProcessResourceType<MediaRes, MediaResIndexString, MediaResIndexToken, MediaResIndexUri, MediaResIndexReference, MediaResIndexQuantity, MediaResIndexDateTime>("Media");
      ProcessResourceType<MedicationRes, MedicationResIndexString, MedicationResIndexToken, MedicationResIndexUri, MedicationResIndexReference, MedicationResIndexQuantity, MedicationResIndexDateTime>("Medication");
      ProcessResourceType<MedicationAdministrationRes, MedicationAdministrationResIndexString, MedicationAdministrationResIndexToken, MedicationAdministrationResIndexUri, MedicationAdministrationResIndexReference, MedicationAdministrationResIndexQuantity, MedicationAdministrationResIndexDateTime>("MedicationAdministration");
      ProcessResourceType<MedicationDispenseRes, MedicationDispenseResIndexString, MedicationDispenseResIndexToken, MedicationDispenseResIndexUri, MedicationDispenseResIndexReference, MedicationDispenseResIndexQuantity, MedicationDispenseResIndexDateTime>("MedicationDispense");
      ProcessResourceType<MedicationRequestRes, MedicationRequestResIndexString, MedicationRequestResIndexToken, MedicationRequestResIndexUri, MedicationRequestResIndexReference, MedicationRequestResIndexQuantity, MedicationRequestResIndexDateTime>("MedicationRequest");
      ProcessResourceType<MedicationStatementRes, MedicationStatementResIndexString, MedicationStatementResIndexToken, MedicationStatementResIndexUri, MedicationStatementResIndexReference, MedicationStatementResIndexQuantity, MedicationStatementResIndexDateTime>("MedicationStatement");
      ProcessResourceType<MessageDefinitionRes, MessageDefinitionResIndexString, MessageDefinitionResIndexToken, MessageDefinitionResIndexUri, MessageDefinitionResIndexReference, MessageDefinitionResIndexQuantity, MessageDefinitionResIndexDateTime>("MessageDefinition");
      ProcessResourceType<MessageHeaderRes, MessageHeaderResIndexString, MessageHeaderResIndexToken, MessageHeaderResIndexUri, MessageHeaderResIndexReference, MessageHeaderResIndexQuantity, MessageHeaderResIndexDateTime>("MessageHeader");
      ProcessResourceType<NamingSystemRes, NamingSystemResIndexString, NamingSystemResIndexToken, NamingSystemResIndexUri, NamingSystemResIndexReference, NamingSystemResIndexQuantity, NamingSystemResIndexDateTime>("NamingSystem");
      ProcessResourceType<NutritionOrderRes, NutritionOrderResIndexString, NutritionOrderResIndexToken, NutritionOrderResIndexUri, NutritionOrderResIndexReference, NutritionOrderResIndexQuantity, NutritionOrderResIndexDateTime>("NutritionOrder");
      ProcessResourceType<ObservationRes, ObservationResIndexString, ObservationResIndexToken, ObservationResIndexUri, ObservationResIndexReference, ObservationResIndexQuantity, ObservationResIndexDateTime>("Observation");
      ProcessResourceType<OperationDefinitionRes, OperationDefinitionResIndexString, OperationDefinitionResIndexToken, OperationDefinitionResIndexUri, OperationDefinitionResIndexReference, OperationDefinitionResIndexQuantity, OperationDefinitionResIndexDateTime>("OperationDefinition");
      ProcessResourceType<OperationOutcomeRes, OperationOutcomeResIndexString, OperationOutcomeResIndexToken, OperationOutcomeResIndexUri, OperationOutcomeResIndexReference, OperationOutcomeResIndexQuantity, OperationOutcomeResIndexDateTime>("OperationOutcome");
      ProcessResourceType<OrganizationRes, OrganizationResIndexString, OrganizationResIndexToken, OrganizationResIndexUri, OrganizationResIndexReference, OrganizationResIndexQuantity, OrganizationResIndexDateTime>("Organization");
      ProcessResourceType<ParametersRes, ParametersResIndexString, ParametersResIndexToken, ParametersResIndexUri, ParametersResIndexReference, ParametersResIndexQuantity, ParametersResIndexDateTime>("Parameters");
      ProcessResourceType<PatientRes, PatientResIndexString, PatientResIndexToken, PatientResIndexUri, PatientResIndexReference, PatientResIndexQuantity, PatientResIndexDateTime>("Patient");
      ProcessResourceType<PaymentNoticeRes, PaymentNoticeResIndexString, PaymentNoticeResIndexToken, PaymentNoticeResIndexUri, PaymentNoticeResIndexReference, PaymentNoticeResIndexQuantity, PaymentNoticeResIndexDateTime>("PaymentNotice");
      ProcessResourceType<PaymentReconciliationRes, PaymentReconciliationResIndexString, PaymentReconciliationResIndexToken, PaymentReconciliationResIndexUri, PaymentReconciliationResIndexReference, PaymentReconciliationResIndexQuantity, PaymentReconciliationResIndexDateTime>("PaymentReconciliation");
      ProcessResourceType<PersonRes, PersonResIndexString, PersonResIndexToken, PersonResIndexUri, PersonResIndexReference, PersonResIndexQuantity, PersonResIndexDateTime>("Person");
      ProcessResourceType<PlanDefinitionRes, PlanDefinitionResIndexString, PlanDefinitionResIndexToken, PlanDefinitionResIndexUri, PlanDefinitionResIndexReference, PlanDefinitionResIndexQuantity, PlanDefinitionResIndexDateTime>("PlanDefinition");
      ProcessResourceType<PractitionerRes, PractitionerResIndexString, PractitionerResIndexToken, PractitionerResIndexUri, PractitionerResIndexReference, PractitionerResIndexQuantity, PractitionerResIndexDateTime>("Practitioner");
      ProcessResourceType<PractitionerRoleRes, PractitionerRoleResIndexString, PractitionerRoleResIndexToken, PractitionerRoleResIndexUri, PractitionerRoleResIndexReference, PractitionerRoleResIndexQuantity, PractitionerRoleResIndexDateTime>("PractitionerRole");
      ProcessResourceType<ProcedureRes, ProcedureResIndexString, ProcedureResIndexToken, ProcedureResIndexUri, ProcedureResIndexReference, ProcedureResIndexQuantity, ProcedureResIndexDateTime>("Procedure");
      //ProcessResourceType<ProcedureRequestRes, ProcedureRequestResIndexString, ProcedureRequestResIndexToken, ProcedureRequestResIndexUri, ProcedureRequestResIndexReference, ProcedureRequestResIndexQuantity, ProcedureRequestResIndexDateTime>("ProcedureRequest");
      ProcessResourceType<ProcessRequestRes, ProcessRequestResIndexString, ProcessRequestResIndexToken, ProcessRequestResIndexUri, ProcessRequestResIndexReference, ProcessRequestResIndexQuantity, ProcessRequestResIndexDateTime>("ProcessRequest");
      ProcessResourceType<ProcessResponseRes, ProcessResponseResIndexString, ProcessResponseResIndexToken, ProcessResponseResIndexUri, ProcessResponseResIndexReference, ProcessResponseResIndexQuantity, ProcessResponseResIndexDateTime>("ProcessResponse");
      ProcessResourceType<ProvenanceRes, ProvenanceResIndexString, ProvenanceResIndexToken, ProvenanceResIndexUri, ProvenanceResIndexReference, ProvenanceResIndexQuantity, ProvenanceResIndexDateTime>("Provenance");
      ProcessResourceType<QuestionnaireRes, QuestionnaireResIndexString, QuestionnaireResIndexToken, QuestionnaireResIndexUri, QuestionnaireResIndexReference, QuestionnaireResIndexQuantity, QuestionnaireResIndexDateTime>("Questionnaire");
      ProcessResourceType<QuestionnaireResponseRes, QuestionnaireResponseResIndexString, QuestionnaireResponseResIndexToken, QuestionnaireResponseResIndexUri, QuestionnaireResponseResIndexReference, QuestionnaireResponseResIndexQuantity, QuestionnaireResponseResIndexDateTime>("QuestionnaireResponse");
     // ProcessResourceType<ReferralRequestRes, ReferralRequestResIndexString, ReferralRequestResIndexToken, ReferralRequestResIndexUri, ReferralRequestResIndexReference, ReferralRequestResIndexQuantity, ReferralRequestResIndexDateTime>("ReferralRequest");
      ProcessResourceType<RelatedPersonRes, RelatedPersonResIndexString, RelatedPersonResIndexToken, RelatedPersonResIndexUri, RelatedPersonResIndexReference, RelatedPersonResIndexQuantity, RelatedPersonResIndexDateTime>("RelatedPerson");
      ProcessResourceType<RequestGroupRes, RequestGroupResIndexString, RequestGroupResIndexToken, RequestGroupResIndexUri, RequestGroupResIndexReference, RequestGroupResIndexQuantity, RequestGroupResIndexDateTime>("RequestGroup");
      ProcessResourceType<ResearchStudyRes, ResearchStudyResIndexString, ResearchStudyResIndexToken, ResearchStudyResIndexUri, ResearchStudyResIndexReference, ResearchStudyResIndexQuantity, ResearchStudyResIndexDateTime>("ResearchStudy");
      ProcessResourceType<ResearchSubjectRes, ResearchSubjectResIndexString, ResearchSubjectResIndexToken, ResearchSubjectResIndexUri, ResearchSubjectResIndexReference, ResearchSubjectResIndexQuantity, ResearchSubjectResIndexDateTime>("ResearchSubject");
      ProcessResourceType<RiskAssessmentRes, RiskAssessmentResIndexString, RiskAssessmentResIndexToken, RiskAssessmentResIndexUri, RiskAssessmentResIndexReference, RiskAssessmentResIndexQuantity, RiskAssessmentResIndexDateTime>("RiskAssessment");
      ProcessResourceType<ScheduleRes, ScheduleResIndexString, ScheduleResIndexToken, ScheduleResIndexUri, ScheduleResIndexReference, ScheduleResIndexQuantity, ScheduleResIndexDateTime>("Schedule");
      ProcessResourceType<SearchParameterRes, SearchParameterResIndexString, SearchParameterResIndexToken, SearchParameterResIndexUri, SearchParameterResIndexReference, SearchParameterResIndexQuantity, SearchParameterResIndexDateTime>("SearchParameter");
      ProcessResourceType<SequenceRes, SequenceResIndexString, SequenceResIndexToken, SequenceResIndexUri, SequenceResIndexReference, SequenceResIndexQuantity, SequenceResIndexDateTime>("Sequence");
     // ProcessResourceType<ServiceDefinitionRes, ServiceDefinitionResIndexString, ServiceDefinitionResIndexToken, ServiceDefinitionResIndexUri, ServiceDefinitionResIndexReference, ServiceDefinitionResIndexQuantity, ServiceDefinitionResIndexDateTime>("ServiceDefinition");
      ProcessResourceType<SlotRes, SlotResIndexString, SlotResIndexToken, SlotResIndexUri, SlotResIndexReference, SlotResIndexQuantity, SlotResIndexDateTime>("Slot");
      ProcessResourceType<SpecimenRes, SpecimenResIndexString, SpecimenResIndexToken, SpecimenResIndexUri, SpecimenResIndexReference, SpecimenResIndexQuantity, SpecimenResIndexDateTime>("Specimen");
      ProcessResourceType<StructureDefinitionRes, StructureDefinitionResIndexString, StructureDefinitionResIndexToken, StructureDefinitionResIndexUri, StructureDefinitionResIndexReference, StructureDefinitionResIndexQuantity, StructureDefinitionResIndexDateTime>("StructureDefinition");
      ProcessResourceType<StructureMapRes, StructureMapResIndexString, StructureMapResIndexToken, StructureMapResIndexUri, StructureMapResIndexReference, StructureMapResIndexQuantity, StructureMapResIndexDateTime>("StructureMap");
      ProcessResourceType<SubscriptionRes, SubscriptionResIndexString, SubscriptionResIndexToken, SubscriptionResIndexUri, SubscriptionResIndexReference, SubscriptionResIndexQuantity, SubscriptionResIndexDateTime>("Subscription");
      ProcessResourceType<SubstanceRes, SubstanceResIndexString, SubstanceResIndexToken, SubstanceResIndexUri, SubstanceResIndexReference, SubstanceResIndexQuantity, SubstanceResIndexDateTime>("Substance");
      ProcessResourceType<SupplyDeliveryRes, SupplyDeliveryResIndexString, SupplyDeliveryResIndexToken, SupplyDeliveryResIndexUri, SupplyDeliveryResIndexReference, SupplyDeliveryResIndexQuantity, SupplyDeliveryResIndexDateTime>("SupplyDelivery");
      ProcessResourceType<SupplyRequestRes, SupplyRequestResIndexString, SupplyRequestResIndexToken, SupplyRequestResIndexUri, SupplyRequestResIndexReference, SupplyRequestResIndexQuantity, SupplyRequestResIndexDateTime>("SupplyRequest");
      ProcessResourceType<TaskRes, TaskResIndexString, TaskResIndexToken, TaskResIndexUri, TaskResIndexReference, TaskResIndexQuantity, TaskResIndexDateTime>("Task");
      ProcessResourceType<TestReportRes, TestReportResIndexString, TestReportResIndexToken, TestReportResIndexUri, TestReportResIndexReference, TestReportResIndexQuantity, TestReportResIndexDateTime>("TestReport");
      ProcessResourceType<TestScriptRes, TestScriptResIndexString, TestScriptResIndexToken, TestScriptResIndexUri, TestScriptResIndexReference, TestScriptResIndexQuantity, TestScriptResIndexDateTime>("TestScript");
      ProcessResourceType<ValueSetRes, ValueSetResIndexString, ValueSetResIndexToken, ValueSetResIndexUri, ValueSetResIndexReference, ValueSetResIndexQuantity, ValueSetResIndexDateTime>("ValueSet");
      ProcessResourceType<VisionPrescriptionRes, VisionPrescriptionResIndexString, VisionPrescriptionResIndexToken, VisionPrescriptionResIndexUri, VisionPrescriptionResIndexReference, VisionPrescriptionResIndexQuantity, VisionPrescriptionResIndexDateTime>("VisionPrescription");
    }

    private void ProcessResourceType<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(string ResourceName)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      try
      {
        Hl7.Fhir.Serialization.FhirXmlSerializer FhirXmlSerializer = new Hl7.Fhir.Serialization.FhirXmlSerializer();

        bool Running = true;
        while (Running)
        {
          IPyroDbContext context = new MsSqlContext();
          var Query = context.Set<ResCurrentType>().Where(x => x.XmlBlob != null && x.IsDeleted == false && x.Resource == null).Take(200).ToList();
          if (Query == null || Query.Count == 0)
          {
            Running = false;
          }
          else
          {
            foreach (var ResourceEntity in Query)
            {
              if (!string.IsNullOrWhiteSpace(ResourceEntity.XmlBlob))
              {
                Resource Res = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromXml(ResourceEntity.XmlBlob);
                byte[] ResBytes = FhirXmlSerializer.SerializeToBytes(Res);
                ResourceEntity.Resource = Common.Tools.GZip.GZipper.Compress(ResBytes);
                ResourceEntity.XmlBlob = null;
                context.Set<ResCurrentType>().AddOrUpdate(ResourceEntity);
              }
            }
            context.SaveChanges();
            context.Dispose();
          }
        }
      }
      catch (Exception Exec)
      {
        throw new Exception($"The Resource Type {ResourceName}", Exec);
      }
    }

    public override void Down()
    {
    }
  }
}
