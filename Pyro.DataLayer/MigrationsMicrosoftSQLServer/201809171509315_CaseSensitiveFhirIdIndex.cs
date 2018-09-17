namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensitiveFhirIdIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicIxRef", "ix_RefFhirId");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryIxRef", "ix_RefFhirId");
            DropIndex("dbo.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleIxRef", "ix_RefFhirId");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentIxRef", "ix_RefFhirId");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageIxRef", "ix_RefFhirId");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterIxRef", "ix_RefFhirId");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.EntryDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EntryDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("dbo.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagIxRef", "ix_RefFhirId");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalIxRef", "ix_RefFhirId");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("dbo.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ItemInstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ItemInstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryIxRef", "ix_RefFhirId");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageIxRef", "ix_RefFhirId");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListIxRef", "ix_RefFhirId");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductClinicalsRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductClinicalsIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductDeviceSpecRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductDeviceSpecIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersIxRef", "ix_RefFhirId");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcessRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcessResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("dbo.SequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SequenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskIxRef", "ix_RefFhirId");
            DropIndex("dbo.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("dbo.UserSessionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.UserSessionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("dbo.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.AccountIxRef", "ix_RefFhirId");
            AlterColumn("dbo.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodyStructureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodyStructureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodyStructureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodyStructureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EntryDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EntryDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EntryDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EntryDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EventDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EventDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EventDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EventDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExampleScenarioRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExampleScenarioRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExampleScenarioIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExampleScenarioIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InsurancePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InsurancePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InsurancePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InsurancePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InvoiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InvoiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InvoiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.InvoiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ItemInstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ItemInstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ItemInstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ItemInstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstancePolymerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstancePolymerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstancePolymerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstancePolymerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.UserSessionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.UserSessionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.UserSessionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.UserSessionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VerificationResultRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VerificationResultRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VerificationResultIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VerificationResultIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EntryDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EntryDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ItemInstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ItemInstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductClinicalsRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductClinicalsIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductDeviceSpecRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.UserSessionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.UserSessionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("dbo.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.UserSessionIxRef", "ix_RefFhirId");
            DropIndex("dbo.UserSessionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("dbo.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskIxRef", "ix_RefFhirId");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotIxRef", "ix_RefFhirId");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SequenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.SequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcessResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcessRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientIxRef", "ix_RefFhirId");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersIxRef", "ix_RefFhirId");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductDeviceSpecIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductDeviceSpecRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductClinicalsIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductClinicalsRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaIxRef", "ix_RefFhirId");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationIxRef", "ix_RefFhirId");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListIxRef", "ix_RefFhirId");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageIxRef", "ix_RefFhirId");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryIxRef", "ix_RefFhirId");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ItemInstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ItemInstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalIxRef", "ix_RefFhirId");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagIxRef", "ix_RefFhirId");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EntryDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.EntryDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointIxRef", "ix_RefFhirId");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterIxRef", "ix_RefFhirId");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractIxRef", "ix_RefFhirId");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleIxRef", "ix_RefFhirId");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("dbo.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryIxRef", "ix_RefFhirId");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicIxRef", "ix_RefFhirId");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            AlterColumn("dbo.AccountIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VerificationResultIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VerificationResultIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VerificationResultRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VerificationResultRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserSessionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserSessionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserSessionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserSessionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TerminologyCapabilitiesRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSpecificationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstancePolymerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstancePolymerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstancePolymerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstancePolymerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationAffiliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductUndesirableEffectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPharmaceuticalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductPackagedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductManufacturedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductInteractionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIngredientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductIndicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductDeviceSpecRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductContraindicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductClinicalsRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicinalProductAuthorizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationKnowledgeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ItemInstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ItemInstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ItemInstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ItemInstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InvoiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InvoiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InvoiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InvoiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InsurancePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InsurancePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InsurancePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.InsurancePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationEvaluationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExampleScenarioIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExampleScenarioIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExampleScenarioRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExampleScenarioRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EventDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EventDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EventDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EventDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EntryDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EntryDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EntryDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EntryDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageEligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodyStructureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodyStructureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodyStructureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodyStructureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BiologicallyDerivedProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            CreateIndex("dbo.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.UserSessionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.UserSessionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductDeviceSpecIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductDeviceSpecRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductClinicalsIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductClinicalsRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ItemInstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ItemInstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EntryDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EntryDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
        }
    }
}
