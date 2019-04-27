namespace Pyro.DataLayer.MigrationsPostgre
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensitive : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.AccountRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ActivityDefinitionIxTok", "ix_Code");
            DropIndex("public.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("public.AdverseEventIxTok", "ix_Code");
            DropIndex("public.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("public.AllergyIntoleranceIxTok", "ix_Code");
            DropIndex("public.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("public.AppointmentIxTok", "ix_Code");
            DropIndex("public.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("public.AppointmentResponseIxTok", "ix_Code");
            DropIndex("public.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("public.AuditEventIxTok", "ix_Code");
            DropIndex("public.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BasicIxRef", "ix_RefFhirId");
            DropIndex("public.BasicIxTok", "ix_Code");
            DropIndex("public.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BinaryIxRef", "ix_RefFhirId");
            DropIndex("public.BinaryIxTok", "ix_Code");
            DropIndex("public.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("public.BiologicallyDerivedProductIxTok", "ix_Code");
            DropIndex("public.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("public.BodyStructureIxTok", "ix_Code");
            DropIndex("public.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BundleIxRef", "ix_RefFhirId");
            DropIndex("public.BundleIxTok", "ix_Code");
            DropIndex("public.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("public.CapabilityStatementIxTok", "ix_Code");
            DropIndex("public.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("public.CarePlanIxTok", "ix_Code");
            DropIndex("public.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("public.CareTeamIxTok", "ix_Code");
            DropIndex("public.CatalogEntryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CatalogEntryIxRef", "ix_RefFhirId");
            DropIndex("public.CatalogEntryIxTok", "ix_Code");
            DropIndex("public.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ChargeItemDefinitionIxTok", "ix_Code");
            DropIndex("public.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("public.ChargeItemIxTok", "ix_Code");
            DropIndex("public.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClaimIxRef", "ix_RefFhirId");
            DropIndex("public.ClaimIxTok", "ix_Code");
            DropIndex("public.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("public.ClaimResponseIxTok", "ix_Code");
            DropIndex("public.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("public.ClinicalImpressionIxTok", "ix_Code");
            DropIndex("public.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("public.CodeSystemIxTok", "ix_Code");
            DropIndex("public.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("public.CommunicationIxTok", "ix_Code");
            DropIndex("public.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("public.CommunicationRequestIxTok", "ix_Code");
            DropIndex("public.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.CompartmentDefinitionIxTok", "ix_Code");
            DropIndex("public.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CompositionIxRef", "ix_RefFhirId");
            DropIndex("public.CompositionIxTok", "ix_Code");
            DropIndex("public.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("public.ConceptMapIxTok", "ix_Code");
            DropIndex("public.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConditionIxRef", "ix_RefFhirId");
            DropIndex("public.ConditionIxTok", "ix_Code");
            DropIndex("public.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConsentIxRef", "ix_RefFhirId");
            DropIndex("public.ConsentIxTok", "ix_Code");
            DropIndex("public.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ContractIxRef", "ix_RefFhirId");
            DropIndex("public.ContractIxTok", "ix_Code");
            DropIndex("public.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageEligibilityRequestIxTok", "ix_Code");
            DropIndex("public.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageEligibilityResponseIxTok", "ix_Code");
            DropIndex("public.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageIxTok", "ix_Code");
            DropIndex("public.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("public.DetectedIssueIxTok", "ix_Code");
            DropIndex("public.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceDefinitionIxTok", "ix_Code");
            DropIndex("public.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceIxTok", "ix_Code");
            DropIndex("public.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceMetricIxTok", "ix_Code");
            DropIndex("public.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceRequestIxTok", "ix_Code");
            DropIndex("public.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceUseStatementIxTok", "ix_Code");
            DropIndex("public.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("public.DiagnosticReportIxTok", "ix_Code");
            DropIndex("public.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("public.DocumentManifestIxTok", "ix_Code");
            DropIndex("public.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("public.DocumentReferenceIxTok", "ix_Code");
            DropIndex("public.EffectEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EffectEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("public.EffectEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("public.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EncounterIxRef", "ix_RefFhirId");
            DropIndex("public.EncounterIxTok", "ix_Code");
            DropIndex("public.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EndpointIxRef", "ix_RefFhirId");
            DropIndex("public.EndpointIxTok", "ix_Code");
            DropIndex("public.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("public.EnrollmentRequestIxTok", "ix_Code");
            DropIndex("public.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("public.EnrollmentResponseIxTok", "ix_Code");
            DropIndex("public.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("public.EpisodeOfCareIxTok", "ix_Code");
            DropIndex("public.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.EventDefinitionIxTok", "ix_Code");
            DropIndex("public.EvidenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EvidenceIxRef", "ix_RefFhirId");
            DropIndex("public.EvidenceIxTok", "ix_Code");
            DropIndex("public.EvidenceVariableRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EvidenceVariableIxRef", "ix_RefFhirId");
            DropIndex("public.EvidenceVariableIxTok", "ix_Code");
            DropIndex("public.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("public.ExampleScenarioIxTok", "ix_Code");
            DropIndex("public.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("public.ExplanationOfBenefitIxTok", "ix_Code");
            DropIndex("public.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("public.FamilyMemberHistoryIxTok", "ix_Code");
            DropIndex("public.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("public.FlagIxRef", "ix_RefFhirId");
            DropIndex("public.FlagIxTok", "ix_Code");
            DropIndex("public.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GoalIxRef", "ix_RefFhirId");
            DropIndex("public.GoalIxTok", "ix_Code");
            DropIndex("public.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.GraphDefinitionIxTok", "ix_Code");
            DropIndex("public.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GroupIxRef", "ix_RefFhirId");
            DropIndex("public.GroupIxTok", "ix_Code");
            DropIndex("public.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("public.GuidanceResponseIxTok", "ix_Code");
            DropIndex("public.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("public.HealthcareServiceIxTok", "ix_Code");
            DropIndex("public.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("public.ImagingStudyIxTok", "ix_Code");
            DropIndex("public.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationEvaluationIxTok", "ix_Code");
            DropIndex("public.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationIxTok", "ix_Code");
            DropIndex("public.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationRecommendationIxTok", "ix_Code");
            DropIndex("public.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("public.ImplementationGuideIxTok", "ix_Code");
            DropIndex("public.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("public.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("public.InsurancePlanIxTok", "ix_Code");
            DropIndex("public.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("public.InvoiceIxTok", "ix_Code");
            DropIndex("public.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LibraryIxRef", "ix_RefFhirId");
            DropIndex("public.LibraryIxTok", "ix_Code");
            DropIndex("public.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LinkageIxRef", "ix_RefFhirId");
            DropIndex("public.LinkageIxTok", "ix_Code");
            DropIndex("public.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ListIxRef", "ix_RefFhirId");
            DropIndex("public.ListIxTok", "ix_Code");
            DropIndex("public.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LocationIxRef", "ix_RefFhirId");
            DropIndex("public.LocationIxTok", "ix_Code");
            DropIndex("public.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MeasureIxRef", "ix_RefFhirId");
            DropIndex("public.MeasureIxTok", "ix_Code");
            DropIndex("public.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("public.MeasureReportIxTok", "ix_Code");
            DropIndex("public.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MediaIxRef", "ix_RefFhirId");
            DropIndex("public.MediaIxTok", "ix_Code");
            DropIndex("public.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationAdministrationIxTok", "ix_Code");
            DropIndex("public.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationDispenseIxTok", "ix_Code");
            DropIndex("public.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationKnowledgeIxTok", "ix_Code");
            DropIndex("public.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationIxTok", "ix_Code");
            DropIndex("public.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationRequestIxTok", "ix_Code");
            DropIndex("public.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationStatementIxTok", "ix_Code");
            DropIndex("public.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductAuthorizationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductContraindicationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductIndicationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductIngredientIxTok", "ix_Code");
            DropIndex("public.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductInteractionIxTok", "ix_Code");
            DropIndex("public.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductIxTok", "ix_Code");
            DropIndex("public.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductManufacturedIxTok", "ix_Code");
            DropIndex("public.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductPackagedIxTok", "ix_Code");
            DropIndex("public.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductPharmaceuticalIxTok", "ix_Code");
            DropIndex("public.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductUndesirableEffectIxTok", "ix_Code");
            DropIndex("public.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.MessageDefinitionIxTok", "ix_Code");
            DropIndex("public.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("public.MessageHeaderIxTok", "ix_Code");
            DropIndex("public.MolecularSequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MolecularSequenceIxRef", "ix_RefFhirId");
            DropIndex("public.MolecularSequenceIxTok", "ix_Code");
            DropIndex("public.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("public.NamingSystemIxTok", "ix_Code");
            DropIndex("public.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("public.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("public.NutritionOrderIxTok", "ix_Code");
            DropIndex("public.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ObservationDefinitionIxTok", "ix_Code");
            DropIndex("public.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ObservationIxRef", "ix_RefFhirId");
            DropIndex("public.ObservationIxTok", "ix_Code");
            DropIndex("public.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.OperationDefinitionIxTok", "ix_Code");
            DropIndex("public.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("public.OperationOutcomeIxTok", "ix_Code");
            DropIndex("public.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("public.OrganizationAffiliationIxTok", "ix_Code");
            DropIndex("public.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("public.OrganizationIxTok", "ix_Code");
            DropIndex("public.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ParametersIxRef", "ix_RefFhirId");
            DropIndex("public.ParametersIxTok", "ix_Code");
            DropIndex("public.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PatientIxRef", "ix_RefFhirId");
            DropIndex("public.PatientIxTok", "ix_Code");
            DropIndex("public.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("public.PaymentNoticeIxTok", "ix_Code");
            DropIndex("public.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("public.PaymentReconciliationIxTok", "ix_Code");
            DropIndex("public.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PersonIxRef", "ix_RefFhirId");
            DropIndex("public.PersonIxTok", "ix_Code");
            DropIndex("public.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.PlanDefinitionIxTok", "ix_Code");
            DropIndex("public.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("public.PractitionerIxTok", "ix_Code");
            DropIndex("public.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("public.PractitionerRoleIxTok", "ix_Code");
            DropIndex("public.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("public.ProcedureIxTok", "ix_Code");
            DropIndex("public.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("public.ProvenanceIxTok", "ix_Code");
            DropIndex("public.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("public.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("public.QuestionnaireIxTok", "ix_Code");
            DropIndex("public.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("public.QuestionnaireResponseIxTok", "ix_Code");
            DropIndex("public.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("public.RelatedPersonIxTok", "ix_Code");
            DropIndex("public.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("public.RequestGroupIxTok", "ix_Code");
            DropIndex("public.ResearchDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchDefinitionIxTok", "ix_Code");
            DropIndex("public.ResearchElementDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchElementDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchElementDefinitionIxTok", "ix_Code");
            DropIndex("public.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchStudyIxTok", "ix_Code");
            DropIndex("public.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchSubjectIxTok", "ix_Code");
            DropIndex("public.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("public.RiskAssessmentIxTok", "ix_Code");
            DropIndex("public.RiskEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RiskEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("public.RiskEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("public.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("public.ScheduleIxTok", "ix_Code");
            DropIndex("public.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("public.SearchParameterIxTok", "ix_Code");
            DropIndex("public.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("public.ServiceRequestIxTok", "ix_Code");
            DropIndex("public.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SlotIxRef", "ix_RefFhirId");
            DropIndex("public.SlotIxTok", "ix_Code");
            DropIndex("public.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.SpecimenDefinitionIxTok", "ix_Code");
            DropIndex("public.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("public.SpecimenIxTok", "ix_Code");
            DropIndex("public.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.StructureDefinitionIxTok", "ix_Code");
            DropIndex("public.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("public.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("public.StructureMapIxTok", "ix_Code");
            DropIndex("public.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("public.SubscriptionIxTok", "ix_Code");
            DropIndex("public.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceIxTok", "ix_Code");
            DropIndex("public.SubstanceNucleicAcidRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceNucleicAcidIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceNucleicAcidIxTok", "ix_Code");
            DropIndex("public.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("public.SubstancePolymerIxTok", "ix_Code");
            DropIndex("public.SubstanceProteinRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceProteinIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceProteinIxTok", "ix_Code");
            DropIndex("public.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceReferenceInformationIxTok", "ix_Code");
            DropIndex("public.SubstanceSourceMaterialRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceSourceMaterialIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceSourceMaterialIxTok", "ix_Code");
            DropIndex("public.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceSpecificationIxTok", "ix_Code");
            DropIndex("public.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("public.SupplyDeliveryIxTok", "ix_Code");
            DropIndex("public.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("public.SupplyRequestIxTok", "ix_Code");
            DropIndex("public.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TaskIxRef", "ix_RefFhirId");
            DropIndex("public.TaskIxTok", "ix_Code");
            DropIndex("public.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("public.TerminologyCapabilitiesIxTok", "ix_Code");
            DropIndex("public.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TestReportIxRef", "ix_RefFhirId");
            DropIndex("public.TestReportIxTok", "ix_Code");
            DropIndex("public.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("public.TestScriptIxTok", "ix_Code");
            DropIndex("public.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("public.ValueSetIxTok", "ix_Code");
            DropIndex("public.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("public.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("public.VerificationResultIxTok", "ix_Code");
            DropIndex("public.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("public.VisionPrescriptionIxTok", "ix_Code");
            DropIndex("public.AccountIxRef", "ix_RefFhirId");
            DropIndex("public.AccountIxTok", "ix_Code");
            AlterColumn("public.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AccountRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ActivityDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AdverseEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AdverseEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AdverseEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AdverseEventIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AllergyIntoleranceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AppointmentResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AuditEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AuditEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AuditEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AuditEventIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BasicRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BasicIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BasicIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BasicIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BinaryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BinaryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BinaryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BinaryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BodyStructureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BodyStructureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BodyStructureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BodyStructureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BodyStructureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BundleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BundleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BundleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.BundleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CapabilityStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CapabilityStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CapabilityStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CapabilityStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CarePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CarePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CarePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CarePlanIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CareTeamRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CareTeamIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CareTeamIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CareTeamIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CatalogEntryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CatalogEntryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CatalogEntryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CatalogEntryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CatalogEntryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ChargeItemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClaimResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClinicalImpressionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CodeSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CodeSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CodeSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CodeSystemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CommunicationRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompartmentDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompositionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompositionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompositionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CompositionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConceptMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConceptMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConceptMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConceptMapIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConditionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConditionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConditionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConditionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConsentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConsentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConsentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ConsentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ContractRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ContractIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ContractIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ContractIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.CoverageIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DetectedIssueRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DetectedIssueIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DetectedIssueIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DetectedIssueIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceMetricRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceMetricIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceMetricIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceMetricIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceUseStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DiagnosticReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DiagnosticReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DiagnosticReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DiagnosticReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentManifestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentManifestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentManifestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentReferenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentReferenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentReferenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.DocumentReferenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EncounterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EncounterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EncounterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EncounterIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EndpointRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EndpointIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EndpointIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EndpointIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EpisodeOfCareRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EventDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EventDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EventDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EventDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EventDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceVariableRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceVariableRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceVariableIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceVariableIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.EvidenceVariableIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExampleScenarioRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExampleScenarioRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExampleScenarioIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExampleScenarioIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExampleScenarioIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FlagRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FlagIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FlagIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.FlagIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GoalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GoalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GoalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GoalIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GraphDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GraphDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GraphDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GraphDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GroupIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GuidanceResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GuidanceResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GuidanceResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.GuidanceResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.HealthcareServiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.HealthcareServiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.HealthcareServiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.HealthcareServiceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImagingStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImagingStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImagingStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImagingStudyIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImplementationGuideRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImplementationGuideIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImplementationGuideIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ImplementationGuideIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InsurancePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InsurancePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InsurancePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InsurancePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InsurancePlanIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InvoiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InvoiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InvoiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InvoiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.InvoiceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LibraryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LibraryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LibraryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LibraryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LinkageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LinkageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LinkageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LinkageIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ListRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ListIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ListIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ListIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LocationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LocationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LocationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.LocationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MeasureReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MediaRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MediaIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MediaIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MediaIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationAdministrationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationDispenseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationDispenseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationDispenseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationDispenseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationKnowledgeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationKnowledgeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicationStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageHeaderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageHeaderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageHeaderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MessageHeaderIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MolecularSequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MolecularSequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MolecularSequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MolecularSequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.MolecularSequenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NamingSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NamingSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NamingSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NamingSystemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NutritionOrderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NutritionOrderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NutritionOrderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.NutritionOrderIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ObservationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationOutcomeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationOutcomeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationOutcomeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OperationOutcomeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationAffiliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationAffiliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.OrganizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ParametersRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ParametersIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ParametersIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ParametersIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PatientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PatientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PatientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PatientIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentNoticeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentNoticeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentNoticeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentNoticeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentReconciliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PersonIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PlanDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PlanDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PlanDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PlanDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRoleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRoleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRoleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.PractitionerRoleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProcedureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProcedureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProcedureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProcedureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProvenanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProvenanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProvenanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ProvenanceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RelatedPersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RelatedPersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RelatedPersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RelatedPersonIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RequestGroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RequestGroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RequestGroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RequestGroupIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchStudyIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchSubjectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchSubjectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchSubjectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ResearchSubjectIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskAssessmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskAssessmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskAssessmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskAssessmentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ScheduleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ScheduleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ScheduleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ScheduleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SearchParameterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SearchParameterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SearchParameterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SearchParameterIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ServiceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ServiceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ServiceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ServiceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ServiceRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SlotRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SlotIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SlotIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SlotIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SpecimenIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.StructureMapIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubscriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubscriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubscriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubscriptionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstancePolymerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstancePolymerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstancePolymerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstancePolymerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstancePolymerIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceProteinRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceProteinRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceProteinIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceProteinIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceProteinIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSpecificationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSpecificationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyDeliveryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.SupplyRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TaskRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TaskIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TaskIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TaskIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestScriptRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestScriptIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestScriptIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.TestScriptIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ValueSetRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ValueSetIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ValueSetIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.ValueSetIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VerificationResultRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VerificationResultRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VerificationResultIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VerificationResultIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VerificationResultIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VisionPrescriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AccountIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AccountIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("public.AccountIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            CreateIndex("public.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ActivityDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ActivityDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AdverseEventIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AllergyIntoleranceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AppointmentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AppointmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AuditEventIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BasicIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BinaryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BiologicallyDerivedProductIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BodyStructureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BundleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CapabilityStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CarePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CareTeamIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CatalogEntryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CatalogEntryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CatalogEntryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ChargeItemDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ChargeItemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClaimIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClaimResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClinicalImpressionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CodeSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CommunicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CommunicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CompartmentDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CompositionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConceptMapIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConditionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConsentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ContractIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageEligibilityRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageEligibilityResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DetectedIssueIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceMetricIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceUseStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DiagnosticReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DocumentManifestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DocumentReferenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EffectEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EffectEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EncounterIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EndpointIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EnrollmentRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EnrollmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EpisodeOfCareIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EventDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EvidenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EvidenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EvidenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EvidenceVariableRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EvidenceVariableIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EvidenceVariableIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ExampleScenarioIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ExplanationOfBenefitIxTok", "Code", name: "ix_Code");
            CreateIndex("public.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.FamilyMemberHistoryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.FlagIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GoalIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GraphDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GroupIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GuidanceResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.HealthcareServiceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImagingStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationEvaluationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationRecommendationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImplementationGuideIxTok", "Code", name: "ix_Code");
            CreateIndex("public.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.InsurancePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("public.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.InvoiceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LibraryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LinkageIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ListIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LocationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MeasureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MeasureReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MediaIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationAdministrationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationDispenseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationKnowledgeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductAuthorizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductContraindicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductIndicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductIngredientIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductInteractionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductManufacturedIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductPackagedIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductPharmaceuticalIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductUndesirableEffectIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MessageDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MessageHeaderIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MolecularSequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MolecularSequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MolecularSequenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.NamingSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.NutritionOrderIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ObservationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ObservationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OperationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OperationOutcomeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OrganizationAffiliationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OrganizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ParametersIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PatientIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PaymentNoticeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PaymentReconciliationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PersonIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PlanDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PractitionerIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PractitionerRoleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ProcedureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ProvenanceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.QuestionnaireIxTok", "Code", name: "ix_Code");
            CreateIndex("public.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.QuestionnaireResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RelatedPersonIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RequestGroupIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchElementDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchElementDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchElementDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchSubjectIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RiskAssessmentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RiskEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RiskEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ScheduleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SearchParameterIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ServiceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SlotIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SpecimenDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SpecimenIxTok", "Code", name: "ix_Code");
            CreateIndex("public.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.StructureDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.StructureMapIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubscriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceNucleicAcidRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceNucleicAcidIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceNucleicAcidIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstancePolymerIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceProteinRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceProteinIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceProteinIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceReferenceInformationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceSourceMaterialRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceSourceMaterialIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceSourceMaterialIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceSpecificationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SupplyDeliveryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SupplyRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TaskIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TerminologyCapabilitiesIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TestReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TestScriptIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ValueSetIxTok", "Code", name: "ix_Code");
            CreateIndex("public.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.VerificationResultIxTok", "Code", name: "ix_Code");
            CreateIndex("public.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.VisionPrescriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AccountIxTok", "Code", name: "ix_Code");
        }
        
        public override void Down()
        {
            DropIndex("public.AccountIxTok", "ix_Code");
            DropIndex("public.AccountIxRef", "ix_RefFhirId");
            DropIndex("public.VisionPrescriptionIxTok", "ix_Code");
            DropIndex("public.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("public.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.VerificationResultIxTok", "ix_Code");
            DropIndex("public.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("public.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ValueSetIxTok", "ix_Code");
            DropIndex("public.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("public.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TestScriptIxTok", "ix_Code");
            DropIndex("public.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("public.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TestReportIxTok", "ix_Code");
            DropIndex("public.TestReportIxRef", "ix_RefFhirId");
            DropIndex("public.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TerminologyCapabilitiesIxTok", "ix_Code");
            DropIndex("public.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("public.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("public.TaskIxTok", "ix_Code");
            DropIndex("public.TaskIxRef", "ix_RefFhirId");
            DropIndex("public.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SupplyRequestIxTok", "ix_Code");
            DropIndex("public.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("public.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SupplyDeliveryIxTok", "ix_Code");
            DropIndex("public.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("public.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceSpecificationIxTok", "ix_Code");
            DropIndex("public.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceSourceMaterialIxTok", "ix_Code");
            DropIndex("public.SubstanceSourceMaterialIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceSourceMaterialRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceReferenceInformationIxTok", "ix_Code");
            DropIndex("public.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceProteinIxTok", "ix_Code");
            DropIndex("public.SubstanceProteinIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceProteinRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstancePolymerIxTok", "ix_Code");
            DropIndex("public.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("public.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceNucleicAcidIxTok", "ix_Code");
            DropIndex("public.SubstanceNucleicAcidIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceNucleicAcidRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubstanceIxTok", "ix_Code");
            DropIndex("public.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("public.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SubscriptionIxTok", "ix_Code");
            DropIndex("public.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("public.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.StructureMapIxTok", "ix_Code");
            DropIndex("public.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("public.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("public.StructureDefinitionIxTok", "ix_Code");
            DropIndex("public.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SpecimenIxTok", "ix_Code");
            DropIndex("public.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("public.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SpecimenDefinitionIxTok", "ix_Code");
            DropIndex("public.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SlotIxTok", "ix_Code");
            DropIndex("public.SlotIxRef", "ix_RefFhirId");
            DropIndex("public.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ServiceRequestIxTok", "ix_Code");
            DropIndex("public.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("public.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.SearchParameterIxTok", "ix_Code");
            DropIndex("public.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("public.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ScheduleIxTok", "ix_Code");
            DropIndex("public.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("public.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RiskEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("public.RiskEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("public.RiskEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RiskAssessmentIxTok", "ix_Code");
            DropIndex("public.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("public.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchSubjectIxTok", "ix_Code");
            DropIndex("public.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchStudyIxTok", "ix_Code");
            DropIndex("public.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchElementDefinitionIxTok", "ix_Code");
            DropIndex("public.ResearchElementDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchElementDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ResearchDefinitionIxTok", "ix_Code");
            DropIndex("public.ResearchDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ResearchDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RequestGroupIxTok", "ix_Code");
            DropIndex("public.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("public.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("public.RelatedPersonIxTok", "ix_Code");
            DropIndex("public.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("public.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("public.QuestionnaireResponseIxTok", "ix_Code");
            DropIndex("public.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("public.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.QuestionnaireIxTok", "ix_Code");
            DropIndex("public.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("public.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ProvenanceIxTok", "ix_Code");
            DropIndex("public.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("public.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ProcedureIxTok", "ix_Code");
            DropIndex("public.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("public.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PractitionerRoleIxTok", "ix_Code");
            DropIndex("public.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("public.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PractitionerIxTok", "ix_Code");
            DropIndex("public.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("public.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PlanDefinitionIxTok", "ix_Code");
            DropIndex("public.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PersonIxTok", "ix_Code");
            DropIndex("public.PersonIxRef", "ix_RefFhirId");
            DropIndex("public.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PaymentReconciliationIxTok", "ix_Code");
            DropIndex("public.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("public.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PaymentNoticeIxTok", "ix_Code");
            DropIndex("public.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("public.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.PatientIxTok", "ix_Code");
            DropIndex("public.PatientIxRef", "ix_RefFhirId");
            DropIndex("public.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ParametersIxTok", "ix_Code");
            DropIndex("public.ParametersIxRef", "ix_RefFhirId");
            DropIndex("public.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OrganizationIxTok", "ix_Code");
            DropIndex("public.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("public.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OrganizationAffiliationIxTok", "ix_Code");
            DropIndex("public.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("public.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OperationOutcomeIxTok", "ix_Code");
            DropIndex("public.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("public.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.OperationDefinitionIxTok", "ix_Code");
            DropIndex("public.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ObservationIxTok", "ix_Code");
            DropIndex("public.ObservationIxRef", "ix_RefFhirId");
            DropIndex("public.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ObservationDefinitionIxTok", "ix_Code");
            DropIndex("public.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.NutritionOrderIxTok", "ix_Code");
            DropIndex("public.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("public.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("public.NamingSystemIxTok", "ix_Code");
            DropIndex("public.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("public.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MolecularSequenceIxTok", "ix_Code");
            DropIndex("public.MolecularSequenceIxRef", "ix_RefFhirId");
            DropIndex("public.MolecularSequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MessageHeaderIxTok", "ix_Code");
            DropIndex("public.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("public.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MessageDefinitionIxTok", "ix_Code");
            DropIndex("public.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductUndesirableEffectIxTok", "ix_Code");
            DropIndex("public.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductPharmaceuticalIxTok", "ix_Code");
            DropIndex("public.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductPackagedIxTok", "ix_Code");
            DropIndex("public.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductManufacturedIxTok", "ix_Code");
            DropIndex("public.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIxTok", "ix_Code");
            DropIndex("public.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductInteractionIxTok", "ix_Code");
            DropIndex("public.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIngredientIxTok", "ix_Code");
            DropIndex("public.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductIndicationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductContraindicationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicinalProductAuthorizationIxTok", "ix_Code");
            DropIndex("public.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationStatementIxTok", "ix_Code");
            DropIndex("public.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationRequestIxTok", "ix_Code");
            DropIndex("public.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationIxTok", "ix_Code");
            DropIndex("public.MedicationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationKnowledgeIxTok", "ix_Code");
            DropIndex("public.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationDispenseIxTok", "ix_Code");
            DropIndex("public.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MedicationAdministrationIxTok", "ix_Code");
            DropIndex("public.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("public.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MediaIxTok", "ix_Code");
            DropIndex("public.MediaIxRef", "ix_RefFhirId");
            DropIndex("public.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MeasureReportIxTok", "ix_Code");
            DropIndex("public.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("public.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.MeasureIxTok", "ix_Code");
            DropIndex("public.MeasureIxRef", "ix_RefFhirId");
            DropIndex("public.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LocationIxTok", "ix_Code");
            DropIndex("public.LocationIxRef", "ix_RefFhirId");
            DropIndex("public.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ListIxTok", "ix_Code");
            DropIndex("public.ListIxRef", "ix_RefFhirId");
            DropIndex("public.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LinkageIxTok", "ix_Code");
            DropIndex("public.LinkageIxRef", "ix_RefFhirId");
            DropIndex("public.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("public.LibraryIxTok", "ix_Code");
            DropIndex("public.LibraryIxRef", "ix_RefFhirId");
            DropIndex("public.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.InvoiceIxTok", "ix_Code");
            DropIndex("public.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("public.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.InsurancePlanIxTok", "ix_Code");
            DropIndex("public.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("public.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImplementationGuideIxTok", "ix_Code");
            DropIndex("public.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("public.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationRecommendationIxTok", "ix_Code");
            DropIndex("public.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationIxTok", "ix_Code");
            DropIndex("public.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImmunizationEvaluationIxTok", "ix_Code");
            DropIndex("public.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("public.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ImagingStudyIxTok", "ix_Code");
            DropIndex("public.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("public.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("public.HealthcareServiceIxTok", "ix_Code");
            DropIndex("public.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("public.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GuidanceResponseIxTok", "ix_Code");
            DropIndex("public.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("public.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GroupIxTok", "ix_Code");
            DropIndex("public.GroupIxRef", "ix_RefFhirId");
            DropIndex("public.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GraphDefinitionIxTok", "ix_Code");
            DropIndex("public.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.GoalIxTok", "ix_Code");
            DropIndex("public.GoalIxRef", "ix_RefFhirId");
            DropIndex("public.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("public.FlagIxTok", "ix_Code");
            DropIndex("public.FlagIxRef", "ix_RefFhirId");
            DropIndex("public.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("public.FamilyMemberHistoryIxTok", "ix_Code");
            DropIndex("public.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("public.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ExplanationOfBenefitIxTok", "ix_Code");
            DropIndex("public.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("public.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ExampleScenarioIxTok", "ix_Code");
            DropIndex("public.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("public.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EvidenceVariableIxTok", "ix_Code");
            DropIndex("public.EvidenceVariableIxRef", "ix_RefFhirId");
            DropIndex("public.EvidenceVariableRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EvidenceIxTok", "ix_Code");
            DropIndex("public.EvidenceIxRef", "ix_RefFhirId");
            DropIndex("public.EvidenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EventDefinitionIxTok", "ix_Code");
            DropIndex("public.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EpisodeOfCareIxTok", "ix_Code");
            DropIndex("public.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("public.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EnrollmentResponseIxTok", "ix_Code");
            DropIndex("public.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("public.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EnrollmentRequestIxTok", "ix_Code");
            DropIndex("public.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("public.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EndpointIxTok", "ix_Code");
            DropIndex("public.EndpointIxRef", "ix_RefFhirId");
            DropIndex("public.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EncounterIxTok", "ix_Code");
            DropIndex("public.EncounterIxRef", "ix_RefFhirId");
            DropIndex("public.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("public.EffectEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("public.EffectEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("public.EffectEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DocumentReferenceIxTok", "ix_Code");
            DropIndex("public.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("public.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DocumentManifestIxTok", "ix_Code");
            DropIndex("public.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("public.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DiagnosticReportIxTok", "ix_Code");
            DropIndex("public.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("public.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceUseStatementIxTok", "ix_Code");
            DropIndex("public.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceRequestIxTok", "ix_Code");
            DropIndex("public.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceMetricIxTok", "ix_Code");
            DropIndex("public.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceIxTok", "ix_Code");
            DropIndex("public.DeviceIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DeviceDefinitionIxTok", "ix_Code");
            DropIndex("public.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.DetectedIssueIxTok", "ix_Code");
            DropIndex("public.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("public.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageIxTok", "ix_Code");
            DropIndex("public.CoverageIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageEligibilityResponseIxTok", "ix_Code");
            DropIndex("public.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CoverageEligibilityRequestIxTok", "ix_Code");
            DropIndex("public.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("public.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ContractIxTok", "ix_Code");
            DropIndex("public.ContractIxRef", "ix_RefFhirId");
            DropIndex("public.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConsentIxTok", "ix_Code");
            DropIndex("public.ConsentIxRef", "ix_RefFhirId");
            DropIndex("public.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConditionIxTok", "ix_Code");
            DropIndex("public.ConditionIxRef", "ix_RefFhirId");
            DropIndex("public.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ConceptMapIxTok", "ix_Code");
            DropIndex("public.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("public.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CompositionIxTok", "ix_Code");
            DropIndex("public.CompositionIxRef", "ix_RefFhirId");
            DropIndex("public.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CompartmentDefinitionIxTok", "ix_Code");
            DropIndex("public.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CommunicationRequestIxTok", "ix_Code");
            DropIndex("public.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("public.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CommunicationIxTok", "ix_Code");
            DropIndex("public.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("public.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CodeSystemIxTok", "ix_Code");
            DropIndex("public.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("public.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClinicalImpressionIxTok", "ix_Code");
            DropIndex("public.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("public.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClaimResponseIxTok", "ix_Code");
            DropIndex("public.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("public.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ClaimIxTok", "ix_Code");
            DropIndex("public.ClaimIxRef", "ix_RefFhirId");
            DropIndex("public.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ChargeItemIxTok", "ix_Code");
            DropIndex("public.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("public.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ChargeItemDefinitionIxTok", "ix_Code");
            DropIndex("public.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CatalogEntryIxTok", "ix_Code");
            DropIndex("public.CatalogEntryIxRef", "ix_RefFhirId");
            DropIndex("public.CatalogEntryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CareTeamIxTok", "ix_Code");
            DropIndex("public.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("public.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CarePlanIxTok", "ix_Code");
            DropIndex("public.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("public.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("public.CapabilityStatementIxTok", "ix_Code");
            DropIndex("public.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("public.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BundleIxTok", "ix_Code");
            DropIndex("public.BundleIxRef", "ix_RefFhirId");
            DropIndex("public.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BodyStructureIxTok", "ix_Code");
            DropIndex("public.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("public.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BiologicallyDerivedProductIxTok", "ix_Code");
            DropIndex("public.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("public.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BinaryIxTok", "ix_Code");
            DropIndex("public.BinaryIxRef", "ix_RefFhirId");
            DropIndex("public.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("public.BasicIxTok", "ix_Code");
            DropIndex("public.BasicIxRef", "ix_RefFhirId");
            DropIndex("public.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AuditEventIxTok", "ix_Code");
            DropIndex("public.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("public.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AppointmentResponseIxTok", "ix_Code");
            DropIndex("public.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("public.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AppointmentIxTok", "ix_Code");
            DropIndex("public.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("public.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AllergyIntoleranceIxTok", "ix_Code");
            DropIndex("public.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("public.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AdverseEventIxTok", "ix_Code");
            DropIndex("public.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("public.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("public.ActivityDefinitionIxTok", "ix_Code");
            DropIndex("public.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("public.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("public.AccountRes", "uq_FhirIdAndVersionId");
            AlterColumn("public.AccountIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AccountIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AccountIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VisionPrescriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VisionPrescriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VerificationResultIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VerificationResultIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VerificationResultIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VerificationResultRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.VerificationResultRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ValueSetIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ValueSetIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ValueSetIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ValueSetRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestScriptIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestScriptIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestScriptIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestScriptRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TerminologyCapabilitiesRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TaskIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TaskIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TaskIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TaskRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyDeliveryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyDeliveryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSpecificationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSpecificationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSpecificationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceSourceMaterialRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceReferenceInformationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceProteinIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceProteinIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceProteinIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceProteinRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceProteinRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstancePolymerIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstancePolymerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstancePolymerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstancePolymerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstancePolymerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceNucleicAcidRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubscriptionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubscriptionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubscriptionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubscriptionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureMapIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SpecimenDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SlotIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SlotIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SlotIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SlotRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ServiceRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ServiceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ServiceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ServiceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ServiceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SearchParameterIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SearchParameterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SearchParameterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SearchParameterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ScheduleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ScheduleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ScheduleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ScheduleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskAssessmentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskAssessmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskAssessmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskAssessmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchSubjectIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchSubjectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchSubjectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchSubjectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchStudyIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchElementDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ResearchDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RequestGroupIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RequestGroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RequestGroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RequestGroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RelatedPersonIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RelatedPersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RelatedPersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RelatedPersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProvenanceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProvenanceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProvenanceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProvenanceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProcedureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProcedureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProcedureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProcedureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRoleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRoleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRoleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRoleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PlanDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PlanDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PlanDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PlanDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PersonIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PersonIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PersonIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PersonRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentReconciliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentReconciliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentNoticeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentNoticeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentNoticeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentNoticeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PatientIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PatientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PatientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PatientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ParametersIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ParametersIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ParametersIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ParametersRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationAffiliationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationAffiliationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OrganizationAffiliationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationOutcomeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationOutcomeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationOutcomeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationOutcomeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ObservationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NutritionOrderIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NutritionOrderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NutritionOrderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NutritionOrderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NamingSystemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NamingSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NamingSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NamingSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MolecularSequenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MolecularSequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MolecularSequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MolecularSequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MolecularSequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageHeaderIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageHeaderIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageHeaderIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageHeaderRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductUndesirableEffectRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPharmaceuticalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductPackagedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductManufacturedRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductInteractionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIngredientRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductIndicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductContraindicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicinalProductAuthorizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationKnowledgeIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationKnowledgeRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationKnowledgeRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationDispenseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationDispenseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationDispenseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationDispenseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationAdministrationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationAdministrationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MediaIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MediaIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MediaIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MediaRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LocationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LocationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LocationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LocationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ListIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ListIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ListIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ListRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LinkageIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LinkageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LinkageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LinkageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LibraryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LibraryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LibraryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LibraryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InvoiceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InvoiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InvoiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InvoiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InvoiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InsurancePlanIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InsurancePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InsurancePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InsurancePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.InsurancePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImplementationGuideIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImplementationGuideIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImplementationGuideIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImplementationGuideRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImmunizationEvaluationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImagingStudyIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImagingStudyIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImagingStudyIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImagingStudyRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.HealthcareServiceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.HealthcareServiceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.HealthcareServiceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.HealthcareServiceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GuidanceResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GuidanceResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GuidanceResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GuidanceResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GroupIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GroupIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GroupIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GroupRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GraphDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GraphDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GraphDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GraphDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GoalIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GoalIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GoalIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GoalRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FlagIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FlagIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FlagIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FlagRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExampleScenarioIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExampleScenarioIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExampleScenarioIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExampleScenarioRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ExampleScenarioRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceVariableIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceVariableIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceVariableIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceVariableRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceVariableRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EvidenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EventDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EventDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EventDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EventDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EventDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EpisodeOfCareIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EpisodeOfCareRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EndpointIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EndpointIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EndpointIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EndpointRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EncounterIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EncounterIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EncounterIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EncounterRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.EffectEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentReferenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentReferenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentReferenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentReferenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentManifestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentManifestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentManifestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DiagnosticReportIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DiagnosticReportIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DiagnosticReportIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DiagnosticReportRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceUseStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceUseStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceMetricIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceMetricIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceMetricIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceMetricRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DeviceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DetectedIssueIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DetectedIssueIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DetectedIssueIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DetectedIssueRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CoverageEligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ContractIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ContractIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ContractIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ContractRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConsentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConsentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConsentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConsentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConditionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConditionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConditionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConditionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConceptMapIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConceptMapIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConceptMapIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConceptMapRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompositionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompositionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompositionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompositionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompartmentDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompartmentDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRequestIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRequestIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRequestIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CodeSystemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CodeSystemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CodeSystemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CodeSystemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClinicalImpressionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClinicalImpressionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ChargeItemDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CatalogEntryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CatalogEntryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CatalogEntryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CatalogEntryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CatalogEntryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CareTeamIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CareTeamIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CareTeamIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CareTeamRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CarePlanIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CarePlanIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CarePlanIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CarePlanRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CapabilityStatementIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CapabilityStatementIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CapabilityStatementIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CapabilityStatementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BundleIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BundleIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BundleIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BundleRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BodyStructureIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BodyStructureIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BodyStructureIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BodyStructureRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BodyStructureRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BiologicallyDerivedProductRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BinaryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BinaryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BinaryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BinaryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BasicIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BasicIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BasicIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BasicRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AuditEventIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AuditEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AuditEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AuditEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentResponseIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentResponseIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentResponseIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AllergyIntoleranceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AllergyIntoleranceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AdverseEventIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AdverseEventIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AdverseEventIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AdverseEventRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ActivityDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ActivityDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AccountRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("public.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            CreateIndex("public.AccountIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.VisionPrescriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.VerificationResultIxTok", "Code", name: "ix_Code");
            CreateIndex("public.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ValueSetIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TestScriptIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TestReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TerminologyCapabilitiesIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.TaskIxTok", "Code", name: "ix_Code");
            CreateIndex("public.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SupplyRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SupplyDeliveryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceSpecificationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceSourceMaterialIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceSourceMaterialIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceSourceMaterialRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceReferenceInformationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceProteinIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceProteinIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceProteinRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstancePolymerIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceNucleicAcidIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceNucleicAcidIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceNucleicAcidRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubstanceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SubscriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.StructureMapIxTok", "Code", name: "ix_Code");
            CreateIndex("public.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.StructureDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SpecimenIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SpecimenDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SlotIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ServiceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.SearchParameterIxTok", "Code", name: "ix_Code");
            CreateIndex("public.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ScheduleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RiskEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RiskEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RiskAssessmentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchSubjectIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchElementDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchElementDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchElementDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ResearchDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ResearchDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ResearchDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RequestGroupIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.RelatedPersonIxTok", "Code", name: "ix_Code");
            CreateIndex("public.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.QuestionnaireResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.QuestionnaireIxTok", "Code", name: "ix_Code");
            CreateIndex("public.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ProvenanceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ProcedureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PractitionerRoleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PractitionerIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PlanDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PersonIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PaymentReconciliationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PaymentNoticeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.PatientIxTok", "Code", name: "ix_Code");
            CreateIndex("public.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ParametersIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OrganizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OrganizationAffiliationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OperationOutcomeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.OperationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ObservationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ObservationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.NutritionOrderIxTok", "Code", name: "ix_Code");
            CreateIndex("public.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.NamingSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MolecularSequenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MolecularSequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MolecularSequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MessageHeaderIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MessageDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductUndesirableEffectIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductPharmaceuticalIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductPackagedIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductManufacturedIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductInteractionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIngredientIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductIndicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductContraindicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicinalProductAuthorizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationKnowledgeIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationDispenseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MedicationAdministrationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MediaIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MeasureReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.MeasureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LocationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ListIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LinkageIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.LibraryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.InvoiceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.InsurancePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("public.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImplementationGuideIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationRecommendationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImmunizationEvaluationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ImagingStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.HealthcareServiceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GuidanceResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GroupIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GraphDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.GoalIxTok", "Code", name: "ix_Code");
            CreateIndex("public.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.FlagIxTok", "Code", name: "ix_Code");
            CreateIndex("public.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.FamilyMemberHistoryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ExplanationOfBenefitIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ExampleScenarioIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EvidenceVariableIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EvidenceVariableIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EvidenceVariableRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EvidenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EvidenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EvidenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EventDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EpisodeOfCareIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EnrollmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EnrollmentRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EndpointIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EncounterIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.EffectEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("public.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.EffectEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DocumentReferenceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DocumentManifestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DiagnosticReportIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceUseStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceMetricIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DeviceDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.DetectedIssueIxTok", "Code", name: "ix_Code");
            CreateIndex("public.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageEligibilityResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CoverageEligibilityRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ContractIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConsentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConditionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ConceptMapIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CompositionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CompartmentDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CommunicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CommunicationIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CodeSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClinicalImpressionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClaimResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ClaimIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ChargeItemIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ChargeItemDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CatalogEntryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CatalogEntryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CatalogEntryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CareTeamIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CarePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.CapabilityStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("public.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BundleIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BodyStructureIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BiologicallyDerivedProductIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BinaryIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.BasicIxTok", "Code", name: "ix_Code");
            CreateIndex("public.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AuditEventIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AppointmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AppointmentIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AllergyIntoleranceIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AdverseEventIxTok", "Code", name: "ix_Code");
            CreateIndex("public.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.ActivityDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("public.ActivityDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("public.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("public.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
        }
    }
}
