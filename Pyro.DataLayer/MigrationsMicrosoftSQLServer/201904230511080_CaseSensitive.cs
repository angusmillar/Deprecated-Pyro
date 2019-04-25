namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensitive : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ActivityDefinitionIxTok", "ix_Code");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AdverseEventIxTok", "ix_Code");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("dbo.AllergyIntoleranceIxTok", "ix_Code");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentIxTok", "ix_Code");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentResponseIxTok", "ix_Code");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AuditEventIxTok", "ix_Code");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicIxRef", "ix_RefFhirId");
            DropIndex("dbo.BasicIxTok", "ix_Code");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryIxRef", "ix_RefFhirId");
            DropIndex("dbo.BinaryIxTok", "ix_Code");
            DropIndex("dbo.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.BiologicallyDerivedProductIxTok", "ix_Code");
            DropIndex("dbo.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("dbo.BodyStructureIxTok", "ix_Code");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleIxRef", "ix_RefFhirId");
            DropIndex("dbo.BundleIxTok", "ix_Code");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.CapabilityStatementIxTok", "ix_Code");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.CarePlanIxTok", "ix_Code");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("dbo.CareTeamIxTok", "ix_Code");
            DropIndex("dbo.CatalogEntryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CatalogEntryIxRef", "ix_RefFhirId");
            DropIndex("dbo.CatalogEntryIxTok", "ix_Code");
            DropIndex("dbo.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemIxTok", "ix_Code");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimIxTok", "ix_Code");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimResponseIxTok", "ix_Code");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClinicalImpressionIxTok", "ix_Code");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.CodeSystemIxTok", "ix_Code");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationIxTok", "ix_Code");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRequestIxTok", "ix_Code");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompartmentDefinitionIxTok", "ix_Code");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompositionIxTok", "ix_Code");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConceptMapIxTok", "ix_Code");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConditionIxTok", "ix_Code");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConsentIxTok", "ix_Code");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractIxRef", "ix_RefFhirId");
            DropIndex("dbo.ContractIxTok", "ix_Code");
            DropIndex("dbo.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityRequestIxTok", "ix_Code");
            DropIndex("dbo.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityResponseIxTok", "ix_Code");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageIxTok", "ix_Code");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("dbo.DetectedIssueIxTok", "ix_Code");
            DropIndex("dbo.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceDefinitionIxTok", "ix_Code");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceIxTok", "ix_Code");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceMetricIxTok", "ix_Code");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRequestIxTok", "ix_Code");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceUseStatementIxTok", "ix_Code");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.DiagnosticReportIxTok", "ix_Code");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentManifestIxTok", "ix_Code");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentReferenceIxTok", "ix_Code");
            DropIndex("dbo.EffectEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EffectEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("dbo.EffectEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterIxRef", "ix_RefFhirId");
            DropIndex("dbo.EncounterIxTok", "ix_Code");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointIxRef", "ix_RefFhirId");
            DropIndex("dbo.EndpointIxTok", "ix_Code");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentRequestIxTok", "ix_Code");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentResponseIxTok", "ix_Code");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("dbo.EpisodeOfCareIxTok", "ix_Code");
            DropIndex("dbo.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.EventDefinitionIxTok", "ix_Code");
            DropIndex("dbo.EvidenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EvidenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.EvidenceIxTok", "ix_Code");
            DropIndex("dbo.EvidenceVariableRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EvidenceVariableIxRef", "ix_RefFhirId");
            DropIndex("dbo.EvidenceVariableIxTok", "ix_Code");
            DropIndex("dbo.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExampleScenarioIxTok", "ix_Code");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExplanationOfBenefitIxTok", "ix_Code");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("dbo.FamilyMemberHistoryIxTok", "ix_Code");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagIxRef", "ix_RefFhirId");
            DropIndex("dbo.FlagIxTok", "ix_Code");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalIxRef", "ix_RefFhirId");
            DropIndex("dbo.GoalIxTok", "ix_Code");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.GraphDefinitionIxTok", "ix_Code");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.GroupIxTok", "ix_Code");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.GuidanceResponseIxTok", "ix_Code");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.HealthcareServiceIxTok", "ix_Code");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImagingStudyIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationEvaluationIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRecommendationIxTok", "ix_Code");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImplementationGuideIxTok", "ix_Code");
            DropIndex("dbo.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.InsurancePlanIxTok", "ix_Code");
            DropIndex("dbo.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.InvoiceIxTok", "ix_Code");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryIxRef", "ix_RefFhirId");
            DropIndex("dbo.LibraryIxTok", "ix_Code");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageIxRef", "ix_RefFhirId");
            DropIndex("dbo.LinkageIxTok", "ix_Code");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListIxRef", "ix_RefFhirId");
            DropIndex("dbo.ListIxTok", "ix_Code");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationIxRef", "ix_RefFhirId");
            DropIndex("dbo.LocationIxTok", "ix_Code");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureIxTok", "ix_Code");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureReportIxTok", "ix_Code");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaIxRef", "ix_RefFhirId");
            DropIndex("dbo.MediaIxTok", "ix_Code");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationAdministrationIxTok", "ix_Code");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationDispenseIxTok", "ix_Code");
            DropIndex("dbo.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationKnowledgeIxTok", "ix_Code");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationIxTok", "ix_Code");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRequestIxTok", "ix_Code");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationStatementIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductAuthorizationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductContraindicationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIndicationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIngredientIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductInteractionIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductManufacturedIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPackagedIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxTok", "ix_Code");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageDefinitionIxTok", "ix_Code");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageHeaderIxTok", "ix_Code");
            DropIndex("dbo.MolecularSequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MolecularSequenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.MolecularSequenceIxTok", "ix_Code");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.NamingSystemIxTok", "ix_Code");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("dbo.NutritionOrderIxTok", "ix_Code");
            DropIndex("dbo.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationIxTok", "ix_Code");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationDefinitionIxTok", "ix_Code");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationOutcomeIxTok", "ix_Code");
            DropIndex("dbo.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationAffiliationIxTok", "ix_Code");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationIxTok", "ix_Code");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersIxRef", "ix_RefFhirId");
            DropIndex("dbo.ParametersIxTok", "ix_Code");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientIxRef", "ix_RefFhirId");
            DropIndex("dbo.PatientIxTok", "ix_Code");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentNoticeIxTok", "ix_Code");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentReconciliationIxTok", "ix_Code");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.PersonIxTok", "ix_Code");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.PlanDefinitionIxTok", "ix_Code");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerIxTok", "ix_Code");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRoleIxTok", "ix_Code");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcedureIxTok", "ix_Code");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProvenanceIxTok", "ix_Code");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireIxTok", "ix_Code");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireResponseIxTok", "ix_Code");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.RelatedPersonIxTok", "ix_Code");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.RequestGroupIxTok", "ix_Code");
            DropIndex("dbo.ResearchDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ResearchElementDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchElementDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchElementDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchStudyIxTok", "ix_Code");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchSubjectIxTok", "ix_Code");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskAssessmentIxTok", "ix_Code");
            DropIndex("dbo.RiskEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("dbo.ScheduleIxTok", "ix_Code");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("dbo.SearchParameterIxTok", "ix_Code");
            DropIndex("dbo.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.ServiceRequestIxTok", "ix_Code");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotIxRef", "ix_RefFhirId");
            DropIndex("dbo.SlotIxTok", "ix_Code");
            DropIndex("dbo.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenDefinitionIxTok", "ix_Code");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenIxTok", "ix_Code");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureDefinitionIxTok", "ix_Code");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureMapIxTok", "ix_Code");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubscriptionIxTok", "ix_Code");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceIxTok", "ix_Code");
            DropIndex("dbo.SubstanceNucleicAcidRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceNucleicAcidIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceNucleicAcidIxTok", "ix_Code");
            DropIndex("dbo.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstancePolymerIxTok", "ix_Code");
            DropIndex("dbo.SubstanceProteinRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceProteinIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceProteinIxTok", "ix_Code");
            DropIndex("dbo.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceReferenceInformationIxTok", "ix_Code");
            DropIndex("dbo.SubstanceSourceMaterialRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSourceMaterialIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSourceMaterialIxTok", "ix_Code");
            DropIndex("dbo.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSpecificationIxTok", "ix_Code");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyDeliveryIxTok", "ix_Code");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyRequestIxTok", "ix_Code");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskIxRef", "ix_RefFhirId");
            DropIndex("dbo.TaskIxTok", "ix_Code");
            DropIndex("dbo.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("dbo.TerminologyCapabilitiesIxTok", "ix_Code");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestReportIxTok", "ix_Code");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestScriptIxTok", "ix_Code");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("dbo.ValueSetIxTok", "ix_Code");
            DropIndex("dbo.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("dbo.VerificationResultIxTok", "ix_Code");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionIxTok", "ix_Code");
            DropIndex("dbo.AccountIxRef", "ix_RefFhirId");
            DropIndex("dbo.AccountIxTok", "ix_Code");
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
            AlterColumn("dbo.ActivityDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AdverseEventIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AllergyIntoleranceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AuditEventIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BasicIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BinaryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BiologicallyDerivedProductIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BodyStructureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BundleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CapabilityStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CarePlanIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CareTeamIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CatalogEntryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CatalogEntryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CatalogEntryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CatalogEntryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CatalogEntryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClinicalImpressionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CodeSystemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompartmentDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompositionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConceptMapIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConditionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConsentIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ContractIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageEligibilityRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageEligibilityResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DetectedIssueIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceMetricIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceUseStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DiagnosticReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentManifestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentReferenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EncounterIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EndpointIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EpisodeOfCareIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EventDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceVariableRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceVariableRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceVariableIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceVariableIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EvidenceVariableIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExampleScenarioIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExplanationOfBenefitIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FamilyMemberHistoryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FlagIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GoalIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GraphDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GroupIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GuidanceResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.HealthcareServiceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImagingStudyIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationEvaluationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationRecommendationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImplementationGuideIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.InsurancePlanIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.InvoiceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LibraryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LinkageIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ListIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LocationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MediaIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationAdministrationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationDispenseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationKnowledgeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductAuthorizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductContraindicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIndicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIngredientIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductInteractionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductManufacturedIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductPackagedIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageHeaderIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MolecularSequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MolecularSequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MolecularSequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MolecularSequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MolecularSequenceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NamingSystemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NutritionOrderIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationOutcomeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationAffiliationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ParametersIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PatientIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentNoticeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentReconciliationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PersonIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PlanDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerRoleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcedureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProvenanceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RelatedPersonIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RequestGroupIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchStudyIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchSubjectIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RiskAssessmentIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ScheduleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SearchParameterIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ServiceRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SlotIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureMapIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubscriptionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstancePolymerIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceProteinRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceProteinRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceProteinIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceProteinIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceProteinIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceReferenceInformationIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceSpecificationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyDeliveryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TaskIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TerminologyCapabilitiesIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestScriptIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ValueSetIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.VerificationResultIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.VisionPrescriptionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AccountIxTok", "Code", c => c.String(maxLength: 128,
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
            CreateIndex("dbo.ActivityDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AdverseEventIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AllergyIntoleranceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AuditEventIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BasicIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BinaryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BiologicallyDerivedProductIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BodyStructureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BundleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CapabilityStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CarePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CareTeamIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CatalogEntryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CatalogEntryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CatalogEntryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClinicalImpressionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CodeSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompartmentDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompositionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConceptMapIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConditionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConsentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ContractIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DetectedIssueIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceMetricIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceUseStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DiagnosticReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentManifestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentReferenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EffectEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EffectEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EncounterIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EndpointIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EpisodeOfCareIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EventDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EvidenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EvidenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EvidenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EvidenceVariableRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EvidenceVariableIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EvidenceVariableIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExampleScenarioIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExplanationOfBenefitIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FamilyMemberHistoryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FlagIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GoalIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GraphDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GroupIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GuidanceResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.HealthcareServiceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImagingStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationEvaluationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRecommendationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImplementationGuideIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InsurancePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InvoiceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LibraryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LinkageIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ListIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LocationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MediaIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationAdministrationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationDispenseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationKnowledgeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductAuthorizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductContraindicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIndicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIngredientIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductInteractionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductManufacturedIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPackagedIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageHeaderIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MolecularSequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MolecularSequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MolecularSequenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NamingSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NutritionOrderIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationOutcomeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationAffiliationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ParametersIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PatientIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentNoticeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentReconciliationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PersonIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PlanDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRoleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcedureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProvenanceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RelatedPersonIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RequestGroupIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchElementDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchElementDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchElementDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchSubjectIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskAssessmentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RiskEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ScheduleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SearchParameterIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ServiceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SlotIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureMapIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubscriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceNucleicAcidRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceNucleicAcidIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceNucleicAcidIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstancePolymerIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceProteinRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceProteinIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceProteinIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceReferenceInformationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceSourceMaterialRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSourceMaterialIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSourceMaterialIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSpecificationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyDeliveryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TaskIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TerminologyCapabilitiesIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestScriptIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ValueSetIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VerificationResultIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AccountIxTok", "Code", name: "ix_Code");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountIxTok", "ix_Code");
            DropIndex("dbo.AccountIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionIxTok", "ix_Code");
            DropIndex("dbo.VisionPrescriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VerificationResultIxTok", "ix_Code");
            DropIndex("dbo.VerificationResultIxRef", "ix_RefFhirId");
            DropIndex("dbo.VerificationResultRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetIxTok", "ix_Code");
            DropIndex("dbo.ValueSetIxRef", "ix_RefFhirId");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptIxTok", "ix_Code");
            DropIndex("dbo.TestScriptIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportIxTok", "ix_Code");
            DropIndex("dbo.TestReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TerminologyCapabilitiesIxTok", "ix_Code");
            DropIndex("dbo.TerminologyCapabilitiesIxRef", "ix_RefFhirId");
            DropIndex("dbo.TerminologyCapabilitiesRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskIxTok", "ix_Code");
            DropIndex("dbo.TaskIxRef", "ix_RefFhirId");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestIxTok", "ix_Code");
            DropIndex("dbo.SupplyRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryIxTok", "ix_Code");
            DropIndex("dbo.SupplyDeliveryIxRef", "ix_RefFhirId");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSpecificationIxTok", "ix_Code");
            DropIndex("dbo.SubstanceSpecificationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSpecificationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceSourceMaterialIxTok", "ix_Code");
            DropIndex("dbo.SubstanceSourceMaterialIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceSourceMaterialRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceReferenceInformationIxTok", "ix_Code");
            DropIndex("dbo.SubstanceReferenceInformationIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceReferenceInformationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceProteinIxTok", "ix_Code");
            DropIndex("dbo.SubstanceProteinIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceProteinRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstancePolymerIxTok", "ix_Code");
            DropIndex("dbo.SubstancePolymerIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstancePolymerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceNucleicAcidIxTok", "ix_Code");
            DropIndex("dbo.SubstanceNucleicAcidIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceNucleicAcidRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceIxTok", "ix_Code");
            DropIndex("dbo.SubstanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionIxTok", "ix_Code");
            DropIndex("dbo.SubscriptionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapIxTok", "ix_Code");
            DropIndex("dbo.StructureMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionIxTok", "ix_Code");
            DropIndex("dbo.StructureDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenIxTok", "ix_Code");
            DropIndex("dbo.SpecimenIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenDefinitionIxTok", "ix_Code");
            DropIndex("dbo.SpecimenDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.SpecimenDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotIxTok", "ix_Code");
            DropIndex("dbo.SlotIxRef", "ix_RefFhirId");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceRequestIxTok", "ix_Code");
            DropIndex("dbo.ServiceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.ServiceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterIxTok", "ix_Code");
            DropIndex("dbo.SearchParameterIxRef", "ix_RefFhirId");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleIxTok", "ix_Code");
            DropIndex("dbo.ScheduleIxRef", "ix_RefFhirId");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("dbo.RiskEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentIxTok", "ix_Code");
            DropIndex("dbo.RiskAssessmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectIxTok", "ix_Code");
            DropIndex("dbo.ResearchSubjectIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyIxTok", "ix_Code");
            DropIndex("dbo.ResearchStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchElementDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ResearchElementDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchElementDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ResearchDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ResearchDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupIxTok", "ix_Code");
            DropIndex("dbo.RequestGroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonIxTok", "ix_Code");
            DropIndex("dbo.RelatedPersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseIxTok", "ix_Code");
            DropIndex("dbo.QuestionnaireResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireIxTok", "ix_Code");
            DropIndex("dbo.QuestionnaireIxRef", "ix_RefFhirId");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceIxTok", "ix_Code");
            DropIndex("dbo.ProvenanceIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureIxTok", "ix_Code");
            DropIndex("dbo.ProcedureIxRef", "ix_RefFhirId");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleIxTok", "ix_Code");
            DropIndex("dbo.PractitionerRoleIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerIxTok", "ix_Code");
            DropIndex("dbo.PractitionerIxRef", "ix_RefFhirId");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionIxTok", "ix_Code");
            DropIndex("dbo.PlanDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonIxTok", "ix_Code");
            DropIndex("dbo.PersonIxRef", "ix_RefFhirId");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationIxTok", "ix_Code");
            DropIndex("dbo.PaymentReconciliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeIxTok", "ix_Code");
            DropIndex("dbo.PaymentNoticeIxRef", "ix_RefFhirId");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientIxTok", "ix_Code");
            DropIndex("dbo.PatientIxRef", "ix_RefFhirId");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersIxTok", "ix_Code");
            DropIndex("dbo.ParametersIxRef", "ix_RefFhirId");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationIxTok", "ix_Code");
            DropIndex("dbo.OrganizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationAffiliationIxTok", "ix_Code");
            DropIndex("dbo.OrganizationAffiliationIxRef", "ix_RefFhirId");
            DropIndex("dbo.OrganizationAffiliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeIxTok", "ix_Code");
            DropIndex("dbo.OperationOutcomeIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionIxTok", "ix_Code");
            DropIndex("dbo.OperationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationIxTok", "ix_Code");
            DropIndex("dbo.ObservationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ObservationDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ObservationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderIxTok", "ix_Code");
            DropIndex("dbo.NutritionOrderIxRef", "ix_RefFhirId");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemIxTok", "ix_Code");
            DropIndex("dbo.NamingSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MolecularSequenceIxTok", "ix_Code");
            DropIndex("dbo.MolecularSequenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.MolecularSequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderIxTok", "ix_Code");
            DropIndex("dbo.MessageHeaderIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionIxTok", "ix_Code");
            DropIndex("dbo.MessageDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductUndesirableEffectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPharmaceuticalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductPackagedIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductPackagedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductPackagedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductManufacturedIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductManufacturedIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductManufacturedRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductInteractionIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductInteractionIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductInteractionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIngredientIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductIngredientIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIngredientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductIndicationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductIndicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductIndicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductContraindicationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductContraindicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductContraindicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicinalProductAuthorizationIxTok", "ix_Code");
            DropIndex("dbo.MedicinalProductAuthorizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicinalProductAuthorizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementIxTok", "ix_Code");
            DropIndex("dbo.MedicationStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestIxTok", "ix_Code");
            DropIndex("dbo.MedicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationIxTok", "ix_Code");
            DropIndex("dbo.MedicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationKnowledgeIxTok", "ix_Code");
            DropIndex("dbo.MedicationKnowledgeIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationKnowledgeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseIxTok", "ix_Code");
            DropIndex("dbo.MedicationDispenseIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationIxTok", "ix_Code");
            DropIndex("dbo.MedicationAdministrationIxRef", "ix_RefFhirId");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaIxTok", "ix_Code");
            DropIndex("dbo.MediaIxRef", "ix_RefFhirId");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportIxTok", "ix_Code");
            DropIndex("dbo.MeasureReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureIxTok", "ix_Code");
            DropIndex("dbo.MeasureIxRef", "ix_RefFhirId");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationIxTok", "ix_Code");
            DropIndex("dbo.LocationIxRef", "ix_RefFhirId");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListIxTok", "ix_Code");
            DropIndex("dbo.ListIxRef", "ix_RefFhirId");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageIxTok", "ix_Code");
            DropIndex("dbo.LinkageIxRef", "ix_RefFhirId");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryIxTok", "ix_Code");
            DropIndex("dbo.LibraryIxRef", "ix_RefFhirId");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InvoiceIxTok", "ix_Code");
            DropIndex("dbo.InvoiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.InvoiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.InsurancePlanIxTok", "ix_Code");
            DropIndex("dbo.InsurancePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.InsurancePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideIxTok", "ix_Code");
            DropIndex("dbo.ImplementationGuideIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationRecommendationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationEvaluationIxTok", "ix_Code");
            DropIndex("dbo.ImmunizationEvaluationIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImmunizationEvaluationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyIxTok", "ix_Code");
            DropIndex("dbo.ImagingStudyIxRef", "ix_RefFhirId");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceIxTok", "ix_Code");
            DropIndex("dbo.HealthcareServiceIxRef", "ix_RefFhirId");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseIxTok", "ix_Code");
            DropIndex("dbo.GuidanceResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupIxTok", "ix_Code");
            DropIndex("dbo.GroupIxRef", "ix_RefFhirId");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionIxTok", "ix_Code");
            DropIndex("dbo.GraphDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalIxTok", "ix_Code");
            DropIndex("dbo.GoalIxRef", "ix_RefFhirId");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagIxTok", "ix_Code");
            DropIndex("dbo.FlagIxRef", "ix_RefFhirId");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryIxTok", "ix_Code");
            DropIndex("dbo.FamilyMemberHistoryIxRef", "ix_RefFhirId");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitIxTok", "ix_Code");
            DropIndex("dbo.ExplanationOfBenefitIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExampleScenarioIxTok", "ix_Code");
            DropIndex("dbo.ExampleScenarioIxRef", "ix_RefFhirId");
            DropIndex("dbo.ExampleScenarioRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EvidenceVariableIxTok", "ix_Code");
            DropIndex("dbo.EvidenceVariableIxRef", "ix_RefFhirId");
            DropIndex("dbo.EvidenceVariableRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EvidenceIxTok", "ix_Code");
            DropIndex("dbo.EvidenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.EvidenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EventDefinitionIxTok", "ix_Code");
            DropIndex("dbo.EventDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.EventDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareIxTok", "ix_Code");
            DropIndex("dbo.EpisodeOfCareIxRef", "ix_RefFhirId");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseIxTok", "ix_Code");
            DropIndex("dbo.EnrollmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestIxTok", "ix_Code");
            DropIndex("dbo.EnrollmentRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointIxTok", "ix_Code");
            DropIndex("dbo.EndpointIxRef", "ix_RefFhirId");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterIxTok", "ix_Code");
            DropIndex("dbo.EncounterIxRef", "ix_RefFhirId");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EffectEvidenceSynthesisIxTok", "ix_Code");
            DropIndex("dbo.EffectEvidenceSynthesisIxRef", "ix_RefFhirId");
            DropIndex("dbo.EffectEvidenceSynthesisRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceIxTok", "ix_Code");
            DropIndex("dbo.DocumentReferenceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestIxTok", "ix_Code");
            DropIndex("dbo.DocumentManifestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportIxTok", "ix_Code");
            DropIndex("dbo.DiagnosticReportIxRef", "ix_RefFhirId");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementIxTok", "ix_Code");
            DropIndex("dbo.DeviceUseStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestIxTok", "ix_Code");
            DropIndex("dbo.DeviceRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricIxTok", "ix_Code");
            DropIndex("dbo.DeviceMetricIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceIxTok", "ix_Code");
            DropIndex("dbo.DeviceIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceDefinitionIxTok", "ix_Code");
            DropIndex("dbo.DeviceDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.DeviceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueIxTok", "ix_Code");
            DropIndex("dbo.DetectedIssueIxRef", "ix_RefFhirId");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageIxTok", "ix_Code");
            DropIndex("dbo.CoverageIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityResponseIxTok", "ix_Code");
            DropIndex("dbo.CoverageEligibilityResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageEligibilityRequestIxTok", "ix_Code");
            DropIndex("dbo.CoverageEligibilityRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CoverageEligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractIxTok", "ix_Code");
            DropIndex("dbo.ContractIxRef", "ix_RefFhirId");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentIxTok", "ix_Code");
            DropIndex("dbo.ConsentIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionIxTok", "ix_Code");
            DropIndex("dbo.ConditionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapIxTok", "ix_Code");
            DropIndex("dbo.ConceptMapIxRef", "ix_RefFhirId");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionIxTok", "ix_Code");
            DropIndex("dbo.CompositionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionIxTok", "ix_Code");
            DropIndex("dbo.CompartmentDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestIxTok", "ix_Code");
            DropIndex("dbo.CommunicationRequestIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationIxTok", "ix_Code");
            DropIndex("dbo.CommunicationIxRef", "ix_RefFhirId");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemIxTok", "ix_Code");
            DropIndex("dbo.CodeSystemIxRef", "ix_RefFhirId");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionIxTok", "ix_Code");
            DropIndex("dbo.ClinicalImpressionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseIxTok", "ix_Code");
            DropIndex("dbo.ClaimResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimIxTok", "ix_Code");
            DropIndex("dbo.ClaimIxRef", "ix_RefFhirId");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemIxTok", "ix_Code");
            DropIndex("dbo.ChargeItemIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ChargeItemDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ChargeItemDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CatalogEntryIxTok", "ix_Code");
            DropIndex("dbo.CatalogEntryIxRef", "ix_RefFhirId");
            DropIndex("dbo.CatalogEntryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamIxTok", "ix_Code");
            DropIndex("dbo.CareTeamIxRef", "ix_RefFhirId");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanIxTok", "ix_Code");
            DropIndex("dbo.CarePlanIxRef", "ix_RefFhirId");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementIxTok", "ix_Code");
            DropIndex("dbo.CapabilityStatementIxRef", "ix_RefFhirId");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleIxTok", "ix_Code");
            DropIndex("dbo.BundleIxRef", "ix_RefFhirId");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodyStructureIxTok", "ix_Code");
            DropIndex("dbo.BodyStructureIxRef", "ix_RefFhirId");
            DropIndex("dbo.BodyStructureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BiologicallyDerivedProductIxTok", "ix_Code");
            DropIndex("dbo.BiologicallyDerivedProductIxRef", "ix_RefFhirId");
            DropIndex("dbo.BiologicallyDerivedProductRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryIxTok", "ix_Code");
            DropIndex("dbo.BinaryIxRef", "ix_RefFhirId");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicIxTok", "ix_Code");
            DropIndex("dbo.BasicIxRef", "ix_RefFhirId");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventIxTok", "ix_Code");
            DropIndex("dbo.AuditEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseIxTok", "ix_Code");
            DropIndex("dbo.AppointmentResponseIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentIxTok", "ix_Code");
            DropIndex("dbo.AppointmentIxRef", "ix_RefFhirId");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceIxTok", "ix_Code");
            DropIndex("dbo.AllergyIntoleranceIxRef", "ix_RefFhirId");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventIxTok", "ix_Code");
            DropIndex("dbo.AdverseEventIxRef", "ix_RefFhirId");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionIxTok", "ix_Code");
            DropIndex("dbo.ActivityDefinitionIxRef", "ix_RefFhirId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            AlterColumn("dbo.AccountIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
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
            AlterColumn("dbo.VisionPrescriptionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.VerificationResultIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ValueSetIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestScriptIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TerminologyCapabilitiesIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TaskIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyDeliveryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceSpecificationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceSourceMaterialIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceSourceMaterialRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceReferenceInformationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceProteinIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceProteinIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceProteinIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceProteinRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceProteinRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstancePolymerIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceNucleicAcidIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceNucleicAcidRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubscriptionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureMapIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SlotIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ServiceRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SearchParameterIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ScheduleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RiskEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchSubjectIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchStudyIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchElementDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchElementDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RelatedPersonIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProvenanceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcedureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerRoleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PlanDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PersonIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentReconciliationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentNoticeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PatientIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ParametersIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationAffiliationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationOutcomeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NutritionOrderIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NamingSystemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MolecularSequenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MolecularSequenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MolecularSequenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MolecularSequenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MolecularSequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductUndesirableEffectIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductPharmaceuticalIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductPackagedIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductManufacturedIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductInteractionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIngredientIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductIndicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductContraindicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicinalProductAuthorizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationKnowledgeIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationDispenseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationAdministrationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MediaIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LocationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ListIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LinkageIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LibraryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.InvoiceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.InsurancePlanIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImplementationGuideIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationRecommendationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationEvaluationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImagingStudyIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.HealthcareServiceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GuidanceResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GroupIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GraphDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GoalIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FlagIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FamilyMemberHistoryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExplanationOfBenefitIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExampleScenarioIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EvidenceVariableIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceVariableIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceVariableIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceVariableRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceVariableRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EvidenceRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EventDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EpisodeOfCareIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EndpointIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EncounterIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EffectEvidenceSynthesisIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EffectEvidenceSynthesisRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentManifestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DiagnosticReportIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceUseStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceMetricIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DetectedIssueIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageEligibilityResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageEligibilityRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ContractIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConsentIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConditionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConceptMapIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompositionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompartmentDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationRequestIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CodeSystemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClinicalImpressionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CatalogEntryIxTok", "Code", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CatalogEntryIxRef", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CatalogEntryIxRef", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CatalogEntryRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CatalogEntryRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CarePlanIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CapabilityStatementIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BundleIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BodyStructureIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BiologicallyDerivedProductIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BinaryIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BasicIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AuditEventIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResponseIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AllergyIntoleranceIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AdverseEventIxTok", "Code", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ActivityDefinitionIxTok", "Code", c => c.String(maxLength: 128,
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
            CreateIndex("dbo.AccountIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AccountIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.VisionPrescriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VerificationResultIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.VerificationResultIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.VerificationResultRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ValueSetIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TestScriptIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TestReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TerminologyCapabilitiesIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TerminologyCapabilitiesIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TerminologyCapabilitiesRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.TaskIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyDeliveryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSpecificationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceSpecificationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSpecificationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceSourceMaterialIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceSourceMaterialIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceSourceMaterialRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceReferenceInformationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceReferenceInformationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceReferenceInformationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceProteinIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceProteinIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceProteinRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstancePolymerIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstancePolymerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstancePolymerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceNucleicAcidIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceNucleicAcidIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceNucleicAcidRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SubscriptionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SpecimenIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SpecimenDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SpecimenDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SlotIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ServiceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ServiceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.SearchParameterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ScheduleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RiskEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RiskAssessmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchSubjectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchElementDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchElementDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchElementDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ResearchDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RequestGroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.RelatedPersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ProvenanceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcedureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerRoleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PlanDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PersonIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentReconciliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentNoticeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.PatientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ParametersIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OrganizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationAffiliationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OrganizationAffiliationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OrganizationAffiliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationOutcomeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ObservationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ObservationDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ObservationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.NutritionOrderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.NamingSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MolecularSequenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MolecularSequenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MolecularSequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageHeaderIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductUndesirableEffectIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductUndesirableEffectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductPharmaceuticalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPharmaceuticalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductPackagedIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductPackagedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductPackagedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductManufacturedIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductManufacturedIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductManufacturedRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductInteractionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductInteractionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductInteractionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIngredientIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductIngredientIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIngredientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductIndicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductIndicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductIndicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductContraindicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductContraindicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductContraindicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicinalProductAuthorizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicinalProductAuthorizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicinalProductAuthorizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationKnowledgeIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationKnowledgeIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationKnowledgeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationDispenseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationAdministrationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MediaIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LocationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ListIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LinkageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.LibraryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InvoiceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.InvoiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InvoiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.InsurancePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.InsurancePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.InsurancePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImplementationGuideIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationRecommendationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationEvaluationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationEvaluationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImmunizationEvaluationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ImagingStudyIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.HealthcareServiceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GuidanceResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GroupIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GraphDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.GoalIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.FlagIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.FamilyMemberHistoryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ExplanationOfBenefitIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExampleScenarioIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ExampleScenarioIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ExampleScenarioRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EvidenceVariableIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EvidenceVariableIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EvidenceVariableRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EvidenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EvidenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EvidenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EventDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EventDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EventDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EpisodeOfCareIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EndpointIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EncounterIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EffectEvidenceSynthesisIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.EffectEvidenceSynthesisIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.EffectEvidenceSynthesisRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentReferenceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentManifestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DiagnosticReportIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceUseStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceMetricIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DeviceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.DetectedIssueIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageEligibilityResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageEligibilityRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageEligibilityRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CoverageEligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ContractIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConsentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConditionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ConceptMapIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CompositionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CompartmentDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationRequestIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CodeSystemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClinicalImpressionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ChargeItemIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ChargeItemDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ChargeItemDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CatalogEntryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CatalogEntryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CatalogEntryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CareTeamIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CarePlanIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.CapabilityStatementIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BundleIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodyStructureIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BodyStructureIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BodyStructureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BiologicallyDerivedProductIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BiologicallyDerivedProductIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BiologicallyDerivedProductRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BinaryIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.BasicIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AuditEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentResponseIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AllergyIntoleranceIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.AdverseEventIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionIxTok", "Code", name: "ix_Code");
            CreateIndex("dbo.ActivityDefinitionIxRef", "ReferenceFhirId", name: "ix_RefFhirId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
        }
    }
}
