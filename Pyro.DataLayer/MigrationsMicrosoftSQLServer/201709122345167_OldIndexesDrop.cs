namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class OldIndexesDrop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AccountResIndex", "ResourceId", "dbo.AccountRes");
            DropForeignKey("dbo.AccountResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ResourceId", "dbo.ActivityDefinitionRes");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AdverseEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AdverseEventResIndex", "ResourceId", "dbo.AdverseEventRes");
            DropForeignKey("dbo.AdverseEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ResourceId", "dbo.AllergyIntoleranceRes");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AppointmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AppointmentResIndex", "ResourceId", "dbo.AppointmentRes");
            DropForeignKey("dbo.AppointmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ResourceId", "dbo.AppointmentResponseRes");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AuditEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AuditEventResIndex", "ResourceId", "dbo.AuditEventRes");
            DropForeignKey("dbo.AuditEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BasicResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BasicResIndex", "ResourceId", "dbo.BasicRes");
            DropForeignKey("dbo.BasicResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BinaryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BinaryResIndex", "ResourceId", "dbo.BinaryRes");
            DropForeignKey("dbo.BinaryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BodySiteResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BodySiteResIndex", "ResourceId", "dbo.BodySiteRes");
            DropForeignKey("dbo.BodySiteResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BundleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BundleResIndex", "ResourceId", "dbo.BundleRes");
            DropForeignKey("dbo.BundleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ResourceId", "dbo.CapabilityStatementRes");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CarePlanResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CarePlanResIndex", "ResourceId", "dbo.CarePlanRes");
            DropForeignKey("dbo.CarePlanResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CareTeamResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CareTeamResIndex", "ResourceId", "dbo.CareTeamRes");
            DropForeignKey("dbo.CareTeamResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ChargeItemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ChargeItemResIndex", "ResourceId", "dbo.ChargeItemRes");
            DropForeignKey("dbo.ChargeItemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClaimResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClaimResIndex", "ResourceId", "dbo.ClaimRes");
            DropForeignKey("dbo.ClaimResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClaimResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClaimResponseResIndex", "ResourceId", "dbo.ClaimResponseRes");
            DropForeignKey("dbo.ClaimResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ResourceId", "dbo.ClinicalImpressionRes");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CodeSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CodeSystemResIndex", "ResourceId", "dbo.CodeSystemRes");
            DropForeignKey("dbo.CodeSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CommunicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CommunicationResIndex", "ResourceId", "dbo.CommunicationRes");
            DropForeignKey("dbo.CommunicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ResourceId", "dbo.CommunicationRequestRes");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ResourceId", "dbo.CompartmentDefinitionRes");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CompositionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CompositionResIndex", "ResourceId", "dbo.CompositionRes");
            DropForeignKey("dbo.CompositionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConceptMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConceptMapResIndex", "ResourceId", "dbo.ConceptMapRes");
            DropForeignKey("dbo.ConceptMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConditionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConditionResIndex", "ResourceId", "dbo.ConditionRes");
            DropForeignKey("dbo.ConditionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConsentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConsentResIndex", "ResourceId", "dbo.ConsentRes");
            DropForeignKey("dbo.ConsentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ContractResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ContractResIndex", "ResourceId", "dbo.ContractRes");
            DropForeignKey("dbo.ContractResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CoverageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CoverageResIndex", "ResourceId", "dbo.CoverageRes");
            DropForeignKey("dbo.CoverageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DataElementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DataElementResIndex", "ResourceId", "dbo.DataElementRes");
            DropForeignKey("dbo.DataElementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DetectedIssueResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DetectedIssueResIndex", "ResourceId", "dbo.DetectedIssueRes");
            DropForeignKey("dbo.DetectedIssueResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceResIndex", "ResourceId", "dbo.DeviceRes");
            DropForeignKey("dbo.DeviceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceComponentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceComponentResIndex", "ResourceId", "dbo.DeviceComponentRes");
            DropForeignKey("dbo.DeviceComponentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceMetricResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceMetricResIndex", "ResourceId", "dbo.DeviceMetricRes");
            DropForeignKey("dbo.DeviceMetricResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceRequestResIndex", "ResourceId", "dbo.DeviceRequestRes");
            DropForeignKey("dbo.DeviceRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ResourceId", "dbo.DeviceUseStatementRes");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ResourceId", "dbo.DiagnosticReportRes");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DocumentManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DocumentManifestResIndex", "ResourceId", "dbo.DocumentManifestRes");
            DropForeignKey("dbo.DocumentManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ResourceId", "dbo.DocumentReferenceRes");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ResourceId", "dbo.EligibilityRequestRes");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ResourceId", "dbo.EligibilityResponseRes");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EncounterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EncounterResIndex", "ResourceId", "dbo.EncounterRes");
            DropForeignKey("dbo.EncounterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EndpointResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EndpointResIndex", "ResourceId", "dbo.EndpointRes");
            DropForeignKey("dbo.EndpointResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ResourceId", "dbo.EnrollmentRequestRes");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ResourceId", "dbo.EnrollmentResponseRes");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ResourceId", "dbo.EpisodeOfCareRes");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ResourceId", "dbo.ExpansionProfileRes");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ResourceId", "dbo.ExplanationOfBenefitRes");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ResourceId", "dbo.FamilyMemberHistoryRes");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.FlagResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.FlagResIndex", "ResourceId", "dbo.FlagRes");
            DropForeignKey("dbo.FlagResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GoalResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GoalResIndex", "ResourceId", "dbo.GoalRes");
            DropForeignKey("dbo.GoalResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ResourceId", "dbo.GraphDefinitionRes");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GroupResIndex", "ResourceId", "dbo.GroupRes");
            DropForeignKey("dbo.GroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ResourceId", "dbo.GuidanceResponseRes");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ResourceId", "dbo.HealthcareServiceRes");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImagingManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImagingManifestResIndex", "ResourceId", "dbo.ImagingManifestRes");
            DropForeignKey("dbo.ImagingManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImagingStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImagingStudyResIndex", "ResourceId", "dbo.ImagingStudyRes");
            DropForeignKey("dbo.ImagingStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImmunizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImmunizationResIndex", "ResourceId", "dbo.ImmunizationRes");
            DropForeignKey("dbo.ImmunizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ResourceId", "dbo.ImmunizationRecommendationRes");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ResourceId", "dbo.ImplementationGuideRes");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LibraryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LibraryResIndex", "ResourceId", "dbo.LibraryRes");
            DropForeignKey("dbo.LibraryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LinkageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LinkageResIndex", "ResourceId", "dbo.LinkageRes");
            DropForeignKey("dbo.LinkageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ListResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ListResIndex", "ResourceId", "dbo.ListRes");
            DropForeignKey("dbo.ListResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LocationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LocationResIndex", "ResourceId", "dbo.LocationRes");
            DropForeignKey("dbo.LocationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MeasureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MeasureResIndex", "ResourceId", "dbo.MeasureRes");
            DropForeignKey("dbo.MeasureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MeasureReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MeasureReportResIndex", "ResourceId", "dbo.MeasureReportRes");
            DropForeignKey("dbo.MeasureReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MediaResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MediaResIndex", "ResourceId", "dbo.MediaRes");
            DropForeignKey("dbo.MediaResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationResIndex", "ResourceId", "dbo.MedicationRes");
            DropForeignKey("dbo.MedicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ResourceId", "dbo.MedicationAdministrationRes");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ResourceId", "dbo.MedicationDispenseRes");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationRequestResIndex", "ResourceId", "dbo.MedicationRequestRes");
            DropForeignKey("dbo.MedicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationStatementResIndex", "ResourceId", "dbo.MedicationStatementRes");
            DropForeignKey("dbo.MedicationStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ResourceId", "dbo.MessageDefinitionRes");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MessageHeaderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MessageHeaderResIndex", "ResourceId", "dbo.MessageHeaderRes");
            DropForeignKey("dbo.MessageHeaderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.NamingSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.NamingSystemResIndex", "ResourceId", "dbo.NamingSystemRes");
            DropForeignKey("dbo.NamingSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.NutritionOrderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.NutritionOrderResIndex", "ResourceId", "dbo.NutritionOrderRes");
            DropForeignKey("dbo.NutritionOrderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ObservationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ObservationResIndex", "ResourceId", "dbo.ObservationRes");
            DropForeignKey("dbo.ObservationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ResourceId", "dbo.OperationDefinitionRes");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ResourceId", "dbo.OperationOutcomeRes");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OrganizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OrganizationResIndex", "ResourceId", "dbo.OrganizationRes");
            DropForeignKey("dbo.OrganizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ParametersResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ParametersResIndex", "ResourceId", "dbo.ParametersRes");
            DropForeignKey("dbo.ParametersResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PatientResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PatientResIndex", "ResourceId", "dbo.PatientRes");
            DropForeignKey("dbo.PatientResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ResourceId", "dbo.PaymentNoticeRes");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ResourceId", "dbo.PaymentReconciliationRes");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PersonResIndex", "ResourceId", "dbo.PersonRes");
            DropForeignKey("dbo.PersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ResourceId", "dbo.PlanDefinitionRes");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PractitionerResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PractitionerResIndex", "ResourceId", "dbo.PractitionerRes");
            DropForeignKey("dbo.PractitionerResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ResourceId", "dbo.PractitionerRoleRes");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcedureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcedureResIndex", "ResourceId", "dbo.ProcedureRes");
            DropForeignKey("dbo.ProcedureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ResourceId", "dbo.ProcedureRequestRes");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcessRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcessRequestResIndex", "ResourceId", "dbo.ProcessRequestRes");
            DropForeignKey("dbo.ProcessRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcessResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcessResponseResIndex", "ResourceId", "dbo.ProcessResponseRes");
            DropForeignKey("dbo.ProcessResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProvenanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProvenanceResIndex", "ResourceId", "dbo.ProvenanceRes");
            DropForeignKey("dbo.ProvenanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.QuestionnaireResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.QuestionnaireResIndex", "ResourceId", "dbo.QuestionnaireRes");
            DropForeignKey("dbo.QuestionnaireResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ResourceId", "dbo.QuestionnaireResponseRes");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ReferralRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ReferralRequestResIndex", "ResourceId", "dbo.ReferralRequestRes");
            DropForeignKey("dbo.ReferralRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RelatedPersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RelatedPersonResIndex", "ResourceId", "dbo.RelatedPersonRes");
            DropForeignKey("dbo.RelatedPersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RequestGroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RequestGroupResIndex", "ResourceId", "dbo.RequestGroupRes");
            DropForeignKey("dbo.RequestGroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ResearchStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ResearchStudyResIndex", "ResourceId", "dbo.ResearchStudyRes");
            DropForeignKey("dbo.ResearchStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ResourceId", "dbo.ResearchSubjectRes");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ResourceId", "dbo.RiskAssessmentRes");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ScheduleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ScheduleResIndex", "ResourceId", "dbo.ScheduleRes");
            DropForeignKey("dbo.ScheduleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SearchParameterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SearchParameterResIndex", "ResourceId", "dbo.SearchParameterRes");
            DropForeignKey("dbo.SearchParameterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SequenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SequenceResIndex", "ResourceId", "dbo.SequenceRes");
            DropForeignKey("dbo.SequenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ResourceId", "dbo.ServiceDefinitionRes");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SlotResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SlotResIndex", "ResourceId", "dbo.SlotRes");
            DropForeignKey("dbo.SlotResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SpecimenResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SpecimenResIndex", "ResourceId", "dbo.SpecimenRes");
            DropForeignKey("dbo.SpecimenResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ResourceId", "dbo.StructureDefinitionRes");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.StructureMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.StructureMapResIndex", "ResourceId", "dbo.StructureMapRes");
            DropForeignKey("dbo.StructureMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SubscriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SubscriptionResIndex", "ResourceId", "dbo.SubscriptionRes");
            DropForeignKey("dbo.SubscriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SubstanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SubstanceResIndex", "ResourceId", "dbo.SubstanceRes");
            DropForeignKey("dbo.SubstanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ResourceId", "dbo.SupplyDeliveryRes");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SupplyRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SupplyRequestResIndex", "ResourceId", "dbo.SupplyRequestRes");
            DropForeignKey("dbo.SupplyRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TaskResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TaskResIndex", "ResourceId", "dbo.TaskRes");
            DropForeignKey("dbo.TaskResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TestReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TestReportResIndex", "ResourceId", "dbo.TestReportRes");
            DropForeignKey("dbo.TestReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TestScriptResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TestScriptResIndex", "ResourceId", "dbo.TestScriptRes");
            DropForeignKey("dbo.TestScriptResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ValueSetResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ValueSetResIndex", "ResourceId", "dbo.ValueSetRes");
            DropForeignKey("dbo.ValueSetResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ResourceId", "dbo.VisionPrescriptionRes");
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropIndex("dbo.AccountResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AccountResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AccountResIndex", "ix_Uri");
            DropIndex("dbo.AccountResIndex", "ix_System");
            DropIndex("dbo.AccountResIndex", "ix_Code");
            DropIndex("dbo.AccountResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AccountResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AccountResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AccountResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_System");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_Code");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ActivityDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AdverseEventResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AdverseEventResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AdverseEventResIndex", "ix_Uri");
            DropIndex("dbo.AdverseEventResIndex", "ix_System");
            DropIndex("dbo.AdverseEventResIndex", "ix_Code");
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AdverseEventResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AdverseEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_Uri");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_System");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_Code");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AllergyIntoleranceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AppointmentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AppointmentResIndex", "ix_Uri");
            DropIndex("dbo.AppointmentResIndex", "ix_System");
            DropIndex("dbo.AppointmentResIndex", "ix_Code");
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AppointmentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AppointmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_Uri");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_System");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_Code");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AppointmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AuditEventResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AuditEventResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AuditEventResIndex", "ix_Uri");
            DropIndex("dbo.AuditEventResIndex", "ix_System");
            DropIndex("dbo.AuditEventResIndex", "ix_Code");
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AuditEventResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AuditEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BasicResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BasicResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BasicResIndex", "ix_Uri");
            DropIndex("dbo.BasicResIndex", "ix_System");
            DropIndex("dbo.BasicResIndex", "ix_Code");
            DropIndex("dbo.BasicResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BasicResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BasicResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BinaryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BinaryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BinaryResIndex", "ix_Uri");
            DropIndex("dbo.BinaryResIndex", "ix_System");
            DropIndex("dbo.BinaryResIndex", "ix_Code");
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BinaryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BinaryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BodySiteResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BodySiteResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BodySiteResIndex", "ix_Uri");
            DropIndex("dbo.BodySiteResIndex", "ix_System");
            DropIndex("dbo.BodySiteResIndex", "ix_Code");
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BodySiteResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BodySiteResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BundleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BundleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BundleResIndex", "ix_Uri");
            DropIndex("dbo.BundleResIndex", "ix_System");
            DropIndex("dbo.BundleResIndex", "ix_Code");
            DropIndex("dbo.BundleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BundleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BundleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CapabilityStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_Uri");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_System");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_Code");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CapabilityStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CarePlanResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CarePlanResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CarePlanResIndex", "ix_Uri");
            DropIndex("dbo.CarePlanResIndex", "ix_System");
            DropIndex("dbo.CarePlanResIndex", "ix_Code");
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CarePlanResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CarePlanResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CareTeamResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CareTeamResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CareTeamResIndex", "ix_Uri");
            DropIndex("dbo.CareTeamResIndex", "ix_System");
            DropIndex("dbo.CareTeamResIndex", "ix_Code");
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CareTeamResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CareTeamResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ChargeItemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ChargeItemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ChargeItemResIndex", "ix_Uri");
            DropIndex("dbo.ChargeItemResIndex", "ix_System");
            DropIndex("dbo.ChargeItemResIndex", "ix_Code");
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ChargeItemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ChargeItemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClaimResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClaimResIndex", "ix_Uri");
            DropIndex("dbo.ClaimResIndex", "ix_System");
            DropIndex("dbo.ClaimResIndex", "ix_Code");
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClaimResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClaimResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClaimResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClaimResponseResIndex", "ix_Uri");
            DropIndex("dbo.ClaimResponseResIndex", "ix_System");
            DropIndex("dbo.ClaimResponseResIndex", "ix_Code");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClaimResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_Uri");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_System");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_Code");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClinicalImpressionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CodeSystemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CodeSystemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CodeSystemResIndex", "ix_Uri");
            DropIndex("dbo.CodeSystemResIndex", "ix_System");
            DropIndex("dbo.CodeSystemResIndex", "ix_Code");
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CodeSystemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CodeSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CommunicationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CommunicationResIndex", "ix_Uri");
            DropIndex("dbo.CommunicationResIndex", "ix_System");
            DropIndex("dbo.CommunicationResIndex", "ix_Code");
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CommunicationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CommunicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_Uri");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_System");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_Code");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CommunicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_System");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_Code");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CompartmentDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompositionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CompositionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CompositionResIndex", "ix_Uri");
            DropIndex("dbo.CompositionResIndex", "ix_System");
            DropIndex("dbo.CompositionResIndex", "ix_Code");
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CompositionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CompositionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConceptMapResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConceptMapResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConceptMapResIndex", "ix_Uri");
            DropIndex("dbo.ConceptMapResIndex", "ix_System");
            DropIndex("dbo.ConceptMapResIndex", "ix_Code");
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConceptMapResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConceptMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConditionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConditionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConditionResIndex", "ix_Uri");
            DropIndex("dbo.ConditionResIndex", "ix_System");
            DropIndex("dbo.ConditionResIndex", "ix_Code");
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConditionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConditionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConsentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConsentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConsentResIndex", "ix_Uri");
            DropIndex("dbo.ConsentResIndex", "ix_System");
            DropIndex("dbo.ConsentResIndex", "ix_Code");
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConsentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConsentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ContractResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ContractResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ContractResIndex", "ix_Uri");
            DropIndex("dbo.ContractResIndex", "ix_System");
            DropIndex("dbo.ContractResIndex", "ix_Code");
            DropIndex("dbo.ContractResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ContractResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ContractResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CoverageResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CoverageResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CoverageResIndex", "ix_Uri");
            DropIndex("dbo.CoverageResIndex", "ix_System");
            DropIndex("dbo.CoverageResIndex", "ix_Code");
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CoverageResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CoverageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DataElementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DataElementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DataElementResIndex", "ix_Uri");
            DropIndex("dbo.DataElementResIndex", "ix_System");
            DropIndex("dbo.DataElementResIndex", "ix_Code");
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DataElementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DataElementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DetectedIssueResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DetectedIssueResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DetectedIssueResIndex", "ix_Uri");
            DropIndex("dbo.DetectedIssueResIndex", "ix_System");
            DropIndex("dbo.DetectedIssueResIndex", "ix_Code");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DetectedIssueResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceResIndex", "ix_Uri");
            DropIndex("dbo.DeviceResIndex", "ix_System");
            DropIndex("dbo.DeviceResIndex", "ix_Code");
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceComponentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceComponentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceComponentResIndex", "ix_Uri");
            DropIndex("dbo.DeviceComponentResIndex", "ix_System");
            DropIndex("dbo.DeviceComponentResIndex", "ix_Code");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceComponentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceMetricResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceMetricResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceMetricResIndex", "ix_Uri");
            DropIndex("dbo.DeviceMetricResIndex", "ix_System");
            DropIndex("dbo.DeviceMetricResIndex", "ix_Code");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceMetricResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceRequestResIndex", "ix_Uri");
            DropIndex("dbo.DeviceRequestResIndex", "ix_System");
            DropIndex("dbo.DeviceRequestResIndex", "ix_Code");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_Uri");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_System");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_Code");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceUseStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DiagnosticReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_Uri");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_System");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_Code");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DiagnosticReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentManifestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DocumentManifestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DocumentManifestResIndex", "ix_Uri");
            DropIndex("dbo.DocumentManifestResIndex", "ix_System");
            DropIndex("dbo.DocumentManifestResIndex", "ix_Code");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DocumentManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentReferenceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_Uri");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_System");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_Code");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DocumentReferenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_Uri");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_System");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_Code");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EligibilityRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_Uri");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_System");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_Code");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EligibilityResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EncounterResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EncounterResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EncounterResIndex", "ix_Uri");
            DropIndex("dbo.EncounterResIndex", "ix_System");
            DropIndex("dbo.EncounterResIndex", "ix_Code");
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EncounterResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EncounterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EndpointResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EndpointResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EndpointResIndex", "ix_Uri");
            DropIndex("dbo.EndpointResIndex", "ix_System");
            DropIndex("dbo.EndpointResIndex", "ix_Code");
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EndpointResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EndpointResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_Uri");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_System");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_Code");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EnrollmentRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_Uri");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_System");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_Code");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EnrollmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_Uri");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_System");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_Code");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EpisodeOfCareResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExpansionProfileResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_Uri");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_System");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_Code");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ExpansionProfileResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_Uri");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_System");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_Code");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_Uri");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_System");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_Code");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FlagResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.FlagResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.FlagResIndex", "ix_Uri");
            DropIndex("dbo.FlagResIndex", "ix_System");
            DropIndex("dbo.FlagResIndex", "ix_Code");
            DropIndex("dbo.FlagResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.FlagResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.FlagResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GoalResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GoalResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GoalResIndex", "ix_Uri");
            DropIndex("dbo.GoalResIndex", "ix_System");
            DropIndex("dbo.GoalResIndex", "ix_Code");
            DropIndex("dbo.GoalResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GoalResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GoalResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GraphDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_System");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_Code");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GraphDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GroupResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GroupResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GroupResIndex", "ix_Uri");
            DropIndex("dbo.GroupResIndex", "ix_System");
            DropIndex("dbo.GroupResIndex", "ix_Code");
            DropIndex("dbo.GroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GroupResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GuidanceResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_Uri");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_System");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_Code");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GuidanceResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.HealthcareServiceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_Uri");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_System");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_Code");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.HealthcareServiceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingManifestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImagingManifestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImagingManifestResIndex", "ix_Uri");
            DropIndex("dbo.ImagingManifestResIndex", "ix_System");
            DropIndex("dbo.ImagingManifestResIndex", "ix_Code");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImagingManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingStudyResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImagingStudyResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImagingStudyResIndex", "ix_Uri");
            DropIndex("dbo.ImagingStudyResIndex", "ix_System");
            DropIndex("dbo.ImagingStudyResIndex", "ix_Code");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImagingStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImmunizationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImmunizationResIndex", "ix_Uri");
            DropIndex("dbo.ImmunizationResIndex", "ix_System");
            DropIndex("dbo.ImmunizationResIndex", "ix_Code");
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImmunizationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImmunizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_Uri");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_System");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_Code");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImplementationGuideResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_Uri");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_System");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_Code");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImplementationGuideResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LibraryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LibraryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LibraryResIndex", "ix_Uri");
            DropIndex("dbo.LibraryResIndex", "ix_System");
            DropIndex("dbo.LibraryResIndex", "ix_Code");
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LibraryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LibraryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LinkageResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LinkageResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LinkageResIndex", "ix_Uri");
            DropIndex("dbo.LinkageResIndex", "ix_System");
            DropIndex("dbo.LinkageResIndex", "ix_Code");
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LinkageResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LinkageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ListResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ListResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ListResIndex", "ix_Uri");
            DropIndex("dbo.ListResIndex", "ix_System");
            DropIndex("dbo.ListResIndex", "ix_Code");
            DropIndex("dbo.ListResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ListResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ListResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ListResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LocationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LocationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LocationResIndex", "ix_Uri");
            DropIndex("dbo.LocationResIndex", "ix_System");
            DropIndex("dbo.LocationResIndex", "ix_Code");
            DropIndex("dbo.LocationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LocationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LocationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MeasureResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MeasureResIndex", "ix_Uri");
            DropIndex("dbo.MeasureResIndex", "ix_System");
            DropIndex("dbo.MeasureResIndex", "ix_Code");
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MeasureResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MeasureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MeasureReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MeasureReportResIndex", "ix_Uri");
            DropIndex("dbo.MeasureReportResIndex", "ix_System");
            DropIndex("dbo.MeasureReportResIndex", "ix_Code");
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MeasureReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MeasureReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MediaResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MediaResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MediaResIndex", "ix_Uri");
            DropIndex("dbo.MediaResIndex", "ix_System");
            DropIndex("dbo.MediaResIndex", "ix_Code");
            DropIndex("dbo.MediaResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MediaResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MediaResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationResIndex", "ix_Uri");
            DropIndex("dbo.MedicationResIndex", "ix_System");
            DropIndex("dbo.MedicationResIndex", "ix_Code");
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_Uri");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_System");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_Code");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationAdministrationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationDispenseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_Uri");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_System");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_Code");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationDispenseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationRequestResIndex", "ix_Uri");
            DropIndex("dbo.MedicationRequestResIndex", "ix_System");
            DropIndex("dbo.MedicationRequestResIndex", "ix_Code");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationStatementResIndex", "ix_Uri");
            DropIndex("dbo.MedicationStatementResIndex", "ix_System");
            DropIndex("dbo.MedicationStatementResIndex", "ix_Code");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_System");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_Code");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MessageDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageHeaderResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MessageHeaderResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MessageHeaderResIndex", "ix_Uri");
            DropIndex("dbo.MessageHeaderResIndex", "ix_System");
            DropIndex("dbo.MessageHeaderResIndex", "ix_Code");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MessageHeaderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NamingSystemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.NamingSystemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.NamingSystemResIndex", "ix_Uri");
            DropIndex("dbo.NamingSystemResIndex", "ix_System");
            DropIndex("dbo.NamingSystemResIndex", "ix_Code");
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.NamingSystemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.NamingSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NutritionOrderResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.NutritionOrderResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.NutritionOrderResIndex", "ix_Uri");
            DropIndex("dbo.NutritionOrderResIndex", "ix_System");
            DropIndex("dbo.NutritionOrderResIndex", "ix_Code");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.NutritionOrderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ObservationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ObservationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ObservationResIndex", "ix_Uri");
            DropIndex("dbo.ObservationResIndex", "ix_System");
            DropIndex("dbo.ObservationResIndex", "ix_Code");
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ObservationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ObservationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_System");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_Code");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OperationDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationOutcomeResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_Uri");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_System");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_Code");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OperationOutcomeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OrganizationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OrganizationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OrganizationResIndex", "ix_Uri");
            DropIndex("dbo.OrganizationResIndex", "ix_System");
            DropIndex("dbo.OrganizationResIndex", "ix_Code");
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OrganizationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OrganizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ParametersResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ParametersResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ParametersResIndex", "ix_Uri");
            DropIndex("dbo.ParametersResIndex", "ix_System");
            DropIndex("dbo.ParametersResIndex", "ix_Code");
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ParametersResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ParametersResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PatientResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PatientResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PatientResIndex", "ix_Uri");
            DropIndex("dbo.PatientResIndex", "ix_System");
            DropIndex("dbo.PatientResIndex", "ix_Code");
            DropIndex("dbo.PatientResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PatientResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PatientResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentNoticeResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_Uri");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_System");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_Code");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PaymentNoticeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_Uri");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_System");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_Code");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PaymentReconciliationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PersonResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PersonResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PersonResIndex", "ix_Uri");
            DropIndex("dbo.PersonResIndex", "ix_System");
            DropIndex("dbo.PersonResIndex", "ix_Code");
            DropIndex("dbo.PersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PersonResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PlanDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_System");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_Code");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PlanDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PractitionerResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PractitionerResIndex", "ix_Uri");
            DropIndex("dbo.PractitionerResIndex", "ix_System");
            DropIndex("dbo.PractitionerResIndex", "ix_Code");
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PractitionerResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PractitionerResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerRoleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_Uri");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_System");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_Code");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PractitionerRoleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcedureResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcedureResIndex", "ix_Uri");
            DropIndex("dbo.ProcedureResIndex", "ix_System");
            DropIndex("dbo.ProcedureResIndex", "ix_Code");
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcedureResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcedureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_Uri");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_System");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_Code");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcedureRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcessRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcessRequestResIndex", "ix_Uri");
            DropIndex("dbo.ProcessRequestResIndex", "ix_System");
            DropIndex("dbo.ProcessRequestResIndex", "ix_Code");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcessRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcessResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcessResponseResIndex", "ix_Uri");
            DropIndex("dbo.ProcessResponseResIndex", "ix_System");
            DropIndex("dbo.ProcessResponseResIndex", "ix_Code");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcessResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProvenanceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProvenanceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProvenanceResIndex", "ix_Uri");
            DropIndex("dbo.ProvenanceResIndex", "ix_System");
            DropIndex("dbo.ProvenanceResIndex", "ix_Code");
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProvenanceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProvenanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.QuestionnaireResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.QuestionnaireResIndex", "ix_Uri");
            DropIndex("dbo.QuestionnaireResIndex", "ix_System");
            DropIndex("dbo.QuestionnaireResIndex", "ix_Code");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.QuestionnaireResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_Uri");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_System");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_Code");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.QuestionnaireResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ReferralRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ReferralRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ReferralRequestResIndex", "ix_Uri");
            DropIndex("dbo.ReferralRequestResIndex", "ix_System");
            DropIndex("dbo.ReferralRequestResIndex", "ix_Code");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ReferralRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RelatedPersonResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RelatedPersonResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RelatedPersonResIndex", "ix_Uri");
            DropIndex("dbo.RelatedPersonResIndex", "ix_System");
            DropIndex("dbo.RelatedPersonResIndex", "ix_Code");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RelatedPersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RequestGroupResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RequestGroupResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RequestGroupResIndex", "ix_Uri");
            DropIndex("dbo.RequestGroupResIndex", "ix_System");
            DropIndex("dbo.RequestGroupResIndex", "ix_Code");
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RequestGroupResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RequestGroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchStudyResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ResearchStudyResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ResearchStudyResIndex", "ix_Uri");
            DropIndex("dbo.ResearchStudyResIndex", "ix_System");
            DropIndex("dbo.ResearchStudyResIndex", "ix_Code");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ResearchStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchSubjectResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_Uri");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_System");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_Code");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ResearchSubjectResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RiskAssessmentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_Uri");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_System");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_Code");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RiskAssessmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ScheduleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ScheduleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ScheduleResIndex", "ix_Uri");
            DropIndex("dbo.ScheduleResIndex", "ix_System");
            DropIndex("dbo.ScheduleResIndex", "ix_Code");
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ScheduleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ScheduleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SearchParameterResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SearchParameterResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SearchParameterResIndex", "ix_Uri");
            DropIndex("dbo.SearchParameterResIndex", "ix_System");
            DropIndex("dbo.SearchParameterResIndex", "ix_Code");
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SearchParameterResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SearchParameterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SequenceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SequenceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SequenceResIndex", "ix_Uri");
            DropIndex("dbo.SequenceResIndex", "ix_System");
            DropIndex("dbo.SequenceResIndex", "ix_Code");
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SequenceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SequenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_System");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_Code");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ServiceDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SlotResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SlotResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SlotResIndex", "ix_Uri");
            DropIndex("dbo.SlotResIndex", "ix_System");
            DropIndex("dbo.SlotResIndex", "ix_Code");
            DropIndex("dbo.SlotResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SlotResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SlotResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SpecimenResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SpecimenResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SpecimenResIndex", "ix_Uri");
            DropIndex("dbo.SpecimenResIndex", "ix_System");
            DropIndex("dbo.SpecimenResIndex", "ix_Code");
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SpecimenResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SpecimenResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_System");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_Code");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.StructureDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureMapResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.StructureMapResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.StructureMapResIndex", "ix_Uri");
            DropIndex("dbo.StructureMapResIndex", "ix_System");
            DropIndex("dbo.StructureMapResIndex", "ix_Code");
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.StructureMapResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.StructureMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubscriptionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SubscriptionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SubscriptionResIndex", "ix_Uri");
            DropIndex("dbo.SubscriptionResIndex", "ix_System");
            DropIndex("dbo.SubscriptionResIndex", "ix_Code");
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SubscriptionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SubscriptionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubstanceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SubstanceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SubstanceResIndex", "ix_Uri");
            DropIndex("dbo.SubstanceResIndex", "ix_System");
            DropIndex("dbo.SubstanceResIndex", "ix_Code");
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SubstanceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SubstanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_Uri");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_System");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_Code");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SupplyDeliveryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SupplyRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SupplyRequestResIndex", "ix_Uri");
            DropIndex("dbo.SupplyRequestResIndex", "ix_System");
            DropIndex("dbo.SupplyRequestResIndex", "ix_Code");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SupplyRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TaskResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TaskResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TaskResIndex", "ix_Uri");
            DropIndex("dbo.TaskResIndex", "ix_System");
            DropIndex("dbo.TaskResIndex", "ix_Code");
            DropIndex("dbo.TaskResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TaskResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TaskResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TestReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TestReportResIndex", "ix_Uri");
            DropIndex("dbo.TestReportResIndex", "ix_System");
            DropIndex("dbo.TestReportResIndex", "ix_Code");
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TestReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TestReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestScriptResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TestScriptResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TestScriptResIndex", "ix_Uri");
            DropIndex("dbo.TestScriptResIndex", "ix_System");
            DropIndex("dbo.TestScriptResIndex", "ix_Code");
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TestScriptResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TestScriptResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ValueSetResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ValueSetResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ValueSetResIndex", "ix_Uri");
            DropIndex("dbo.ValueSetResIndex", "ix_System");
            DropIndex("dbo.ValueSetResIndex", "ix_Code");
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ValueSetResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ValueSetResIndex", new[] { "ResourceId" });
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_Uri");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_System");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_Code");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.VisionPrescriptionResIndex", new[] { "ResourceId" });
            DropTable("dbo.AccountResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ActivityDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.AdverseEventResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.AllergyIntoleranceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.AppointmentResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.AppointmentResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.AuditEventResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.BasicResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.BinaryResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.BodySiteResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.BundleResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CapabilityStatementResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CarePlanResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CareTeamResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ChargeItemResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ClaimResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ClaimResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ClinicalImpressionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CodeSystemResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CommunicationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CommunicationRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CompartmentDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CompositionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ConceptMapResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ConditionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ConsentResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ContractResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.CoverageResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DataElementResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DetectedIssueResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DeviceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DeviceComponentResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DeviceMetricResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DeviceRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DeviceUseStatementResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DiagnosticReportResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DocumentManifestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.DocumentReferenceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EligibilityRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EligibilityResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EncounterResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EndpointResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EnrollmentRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EnrollmentResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.EpisodeOfCareResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ExpansionProfileResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ExplanationOfBenefitResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.FamilyMemberHistoryResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.FlagResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.GoalResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.GraphDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.GroupResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.GuidanceResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.HealthcareServiceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ImagingManifestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ImagingStudyResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ImmunizationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ImmunizationRecommendationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ImplementationGuideResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.LibraryResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.LinkageResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ListResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.LocationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MeasureResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MeasureReportResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MediaResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MedicationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MedicationAdministrationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MedicationDispenseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MedicationRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MedicationStatementResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MessageDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.MessageHeaderResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.NamingSystemResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.NutritionOrderResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ObservationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.OperationDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.OperationOutcomeResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.OrganizationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ParametersResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PatientResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PaymentNoticeResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PaymentReconciliationResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PersonResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PlanDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PractitionerResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.PractitionerRoleResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ProcedureResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ProcedureRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ProcessRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ProcessResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ProvenanceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.QuestionnaireResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.QuestionnaireResponseResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ReferralRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.RelatedPersonResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.RequestGroupResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ResearchStudyResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ResearchSubjectResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.RiskAssessmentResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ScheduleResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SearchParameterResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SequenceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ServiceDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SlotResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SpecimenResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.StructureDefinitionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.StructureMapResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SubscriptionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SubstanceResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SupplyDeliveryResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.SupplyRequestResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.TaskResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.TestReportResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.TestScriptResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.ValueSetResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
            DropTable("dbo.VisionPrescriptionResIndex",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ReferenceFhirId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                    {
                        "ReferenceVersionId",
                        new Dictionary<string, object>
                        {
                            { "CaseSensitive", "True" },
                        }
                    },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VisionPrescriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValueSetResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestScriptResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplyRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplyDeliveryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubstanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StructureMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StructureDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecimenResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SlotResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SequenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchParameterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskAssessmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchSubjectResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestGroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelatedPersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReferralRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProvenanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcessResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcessRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcedureRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcedureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PractitionerRoleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PractitionerResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentReconciliationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentNoticeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParametersResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationOutcomeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObservationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NutritionOrderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NamingSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageHeaderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicationStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicationDispenseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicationAdministrationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MediaResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasureReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinkageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibraryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImplementationGuideResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImmunizationRecommendationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImmunizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImagingStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImagingManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HealthcareServiceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuidanceResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GraphDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoalResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlagResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyMemberHistoryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExplanationOfBenefitResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpansionProfileResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EpisodeOfCareResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EndpointResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EncounterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EligibilityResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EligibilityRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentReferenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiagnosticReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceUseStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceMetricResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceComponentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetectedIssueResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataElementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoverageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConditionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConceptMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompositionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompartmentDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommunicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommunicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClinicalImpressionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClaimResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClaimResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChargeItemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CareTeamResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarePlanResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CapabilityStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BundleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BodySiteResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BinaryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BasicResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllergyIntoleranceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdverseEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 450),
                        Code = c.String(maxLength: 128),
                        Unit = c.String(maxLength: 450),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 450),
                        CodeHigh = c.String(maxLength: 128),
                        UnitHigh = c.String(maxLength: 64),
                        ReferenceFhirId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CaseSensitive",
                                    new AnnotationValues(oldValue: null, newValue: "True")
                                },
                            }),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.VisionPrescriptionResIndex", "ResourceId");
            CreateIndex("dbo.VisionPrescriptionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.VisionPrescriptionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.VisionPrescriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.VisionPrescriptionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.VisionPrescriptionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.VisionPrescriptionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.VisionPrescriptionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.VisionPrescriptionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ValueSetResIndex", "ResourceId");
            CreateIndex("dbo.ValueSetResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ValueSetResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ValueSetResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ValueSetResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ValueSetResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ValueSetResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ValueSetResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ValueSetResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.TestScriptResIndex", "ResourceId");
            CreateIndex("dbo.TestScriptResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.TestScriptResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.TestScriptResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestScriptResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.TestScriptResIndex", "System", name: "ix_System");
            CreateIndex("dbo.TestScriptResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.TestScriptResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.TestScriptResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.TestReportResIndex", "ResourceId");
            CreateIndex("dbo.TestReportResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.TestReportResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.TestReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestReportResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.TestReportResIndex", "System", name: "ix_System");
            CreateIndex("dbo.TestReportResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.TestReportResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.TestReportResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.TaskResIndex", "ResourceId");
            CreateIndex("dbo.TaskResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.TaskResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.TaskResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TaskResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.TaskResIndex", "System", name: "ix_System");
            CreateIndex("dbo.TaskResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.TaskResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.TaskResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SupplyRequestResIndex", "ResourceId");
            CreateIndex("dbo.SupplyRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SupplyRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SupplyRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SupplyRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SupplyRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SupplyRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ResourceId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SupplyDeliveryResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SupplyDeliveryResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SupplyDeliveryResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SupplyDeliveryResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SubstanceResIndex", "ResourceId");
            CreateIndex("dbo.SubstanceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SubstanceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SubstanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubstanceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SubstanceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SubstanceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SubstanceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SubstanceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SubscriptionResIndex", "ResourceId");
            CreateIndex("dbo.SubscriptionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SubscriptionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SubscriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubscriptionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SubscriptionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SubscriptionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SubscriptionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SubscriptionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.StructureMapResIndex", "ResourceId");
            CreateIndex("dbo.StructureMapResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.StructureMapResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.StructureMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureMapResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureMapResIndex", "System", name: "ix_System");
            CreateIndex("dbo.StructureMapResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.StructureMapResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.StructureMapResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.StructureDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.StructureDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.StructureDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.StructureDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.StructureDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.StructureDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.StructureDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.StructureDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SpecimenResIndex", "ResourceId");
            CreateIndex("dbo.SpecimenResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SpecimenResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SpecimenResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SpecimenResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SpecimenResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SpecimenResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SpecimenResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SpecimenResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SlotResIndex", "ResourceId");
            CreateIndex("dbo.SlotResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SlotResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SlotResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SlotResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SlotResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SlotResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SlotResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SlotResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ServiceDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ServiceDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ServiceDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ServiceDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SequenceResIndex", "ResourceId");
            CreateIndex("dbo.SequenceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SequenceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SequenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SequenceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SequenceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SequenceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SequenceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SequenceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.SearchParameterResIndex", "ResourceId");
            CreateIndex("dbo.SearchParameterResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.SearchParameterResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.SearchParameterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SearchParameterResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.SearchParameterResIndex", "System", name: "ix_System");
            CreateIndex("dbo.SearchParameterResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.SearchParameterResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.SearchParameterResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ScheduleResIndex", "ResourceId");
            CreateIndex("dbo.ScheduleResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ScheduleResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ScheduleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ScheduleResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ScheduleResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ScheduleResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ScheduleResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ScheduleResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.RiskAssessmentResIndex", "ResourceId");
            CreateIndex("dbo.RiskAssessmentResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.RiskAssessmentResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.RiskAssessmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RiskAssessmentResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.RiskAssessmentResIndex", "System", name: "ix_System");
            CreateIndex("dbo.RiskAssessmentResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.RiskAssessmentResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.RiskAssessmentResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ResearchSubjectResIndex", "ResourceId");
            CreateIndex("dbo.ResearchSubjectResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ResearchSubjectResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ResearchSubjectResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchSubjectResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchSubjectResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ResearchSubjectResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ResearchSubjectResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ResearchSubjectResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ResearchStudyResIndex", "ResourceId");
            CreateIndex("dbo.ResearchStudyResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ResearchStudyResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ResearchStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchStudyResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ResearchStudyResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ResearchStudyResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ResearchStudyResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ResearchStudyResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.RequestGroupResIndex", "ResourceId");
            CreateIndex("dbo.RequestGroupResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.RequestGroupResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.RequestGroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RequestGroupResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.RequestGroupResIndex", "System", name: "ix_System");
            CreateIndex("dbo.RequestGroupResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.RequestGroupResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.RequestGroupResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.RelatedPersonResIndex", "ResourceId");
            CreateIndex("dbo.RelatedPersonResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.RelatedPersonResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.RelatedPersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RelatedPersonResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.RelatedPersonResIndex", "System", name: "ix_System");
            CreateIndex("dbo.RelatedPersonResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.RelatedPersonResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.RelatedPersonResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ReferralRequestResIndex", "ResourceId");
            CreateIndex("dbo.ReferralRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ReferralRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ReferralRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ReferralRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ReferralRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ReferralRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ReferralRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ReferralRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ResourceId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.QuestionnaireResIndex", "ResourceId");
            CreateIndex("dbo.QuestionnaireResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.QuestionnaireResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.QuestionnaireResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.QuestionnaireResIndex", "System", name: "ix_System");
            CreateIndex("dbo.QuestionnaireResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.QuestionnaireResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.QuestionnaireResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ProvenanceResIndex", "ResourceId");
            CreateIndex("dbo.ProvenanceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ProvenanceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ProvenanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProvenanceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ProvenanceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ProvenanceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ProvenanceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ProvenanceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ProcessResponseResIndex", "ResourceId");
            CreateIndex("dbo.ProcessResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ProcessResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ProcessResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcessResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ProcessResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ProcessResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ProcessResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ProcessRequestResIndex", "ResourceId");
            CreateIndex("dbo.ProcessRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ProcessRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ProcessRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcessRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ProcessRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ProcessRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ProcessRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ProcedureRequestResIndex", "ResourceId");
            CreateIndex("dbo.ProcedureRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ProcedureRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ProcedureRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcedureRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ProcedureRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ProcedureRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ProcedureRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ProcedureResIndex", "ResourceId");
            CreateIndex("dbo.ProcedureResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ProcedureResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ProcedureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ProcedureResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ProcedureResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ProcedureResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ProcedureResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PractitionerRoleResIndex", "ResourceId");
            CreateIndex("dbo.PractitionerRoleResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PractitionerRoleResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PractitionerRoleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRoleResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerRoleResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PractitionerRoleResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PractitionerRoleResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PractitionerRoleResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PractitionerResIndex", "ResourceId");
            CreateIndex("dbo.PractitionerResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PractitionerResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PractitionerResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PractitionerResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PractitionerResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PractitionerResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PractitionerResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PlanDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.PlanDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PlanDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PlanDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PlanDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PlanDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PlanDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PlanDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PlanDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PersonResIndex", "ResourceId");
            CreateIndex("dbo.PersonResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PersonResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PersonResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PersonResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PersonResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PersonResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PersonResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ResourceId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentReconciliationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PaymentReconciliationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PaymentReconciliationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PaymentReconciliationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PaymentNoticeResIndex", "ResourceId");
            CreateIndex("dbo.PaymentNoticeResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PaymentNoticeResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PaymentNoticeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentNoticeResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PaymentNoticeResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PaymentNoticeResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PaymentNoticeResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PaymentNoticeResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.PatientResIndex", "ResourceId");
            CreateIndex("dbo.PatientResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.PatientResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.PatientResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PatientResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.PatientResIndex", "System", name: "ix_System");
            CreateIndex("dbo.PatientResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.PatientResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.PatientResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ParametersResIndex", "ResourceId");
            CreateIndex("dbo.ParametersResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ParametersResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ParametersResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ParametersResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ParametersResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ParametersResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ParametersResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ParametersResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.OrganizationResIndex", "ResourceId");
            CreateIndex("dbo.OrganizationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.OrganizationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.OrganizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OrganizationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.OrganizationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.OrganizationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.OrganizationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.OrganizationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.OperationOutcomeResIndex", "ResourceId");
            CreateIndex("dbo.OperationOutcomeResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.OperationOutcomeResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.OperationOutcomeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationOutcomeResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationOutcomeResIndex", "System", name: "ix_System");
            CreateIndex("dbo.OperationOutcomeResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.OperationOutcomeResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.OperationOutcomeResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.OperationDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.OperationDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.OperationDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.OperationDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.OperationDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.OperationDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.OperationDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.OperationDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ObservationResIndex", "ResourceId");
            CreateIndex("dbo.ObservationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ObservationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ObservationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ObservationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ObservationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ObservationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ObservationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ObservationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.NutritionOrderResIndex", "ResourceId");
            CreateIndex("dbo.NutritionOrderResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.NutritionOrderResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.NutritionOrderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NutritionOrderResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.NutritionOrderResIndex", "System", name: "ix_System");
            CreateIndex("dbo.NutritionOrderResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.NutritionOrderResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.NutritionOrderResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.NamingSystemResIndex", "ResourceId");
            CreateIndex("dbo.NamingSystemResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.NamingSystemResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.NamingSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NamingSystemResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.NamingSystemResIndex", "System", name: "ix_System");
            CreateIndex("dbo.NamingSystemResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.NamingSystemResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.NamingSystemResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MessageHeaderResIndex", "ResourceId");
            CreateIndex("dbo.MessageHeaderResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MessageHeaderResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MessageHeaderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageHeaderResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageHeaderResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MessageHeaderResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MessageHeaderResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MessageHeaderResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MessageDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.MessageDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MessageDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MessageDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MessageDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MessageDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MessageDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MessageDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MedicationStatementResIndex", "ResourceId");
            CreateIndex("dbo.MedicationStatementResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MedicationStatementResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MedicationStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationStatementResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationStatementResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MedicationStatementResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MedicationStatementResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MedicationStatementResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MedicationRequestResIndex", "ResourceId");
            CreateIndex("dbo.MedicationRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MedicationRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MedicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MedicationRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MedicationRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MedicationRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MedicationDispenseResIndex", "ResourceId");
            CreateIndex("dbo.MedicationDispenseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MedicationDispenseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MedicationDispenseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationDispenseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationDispenseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MedicationDispenseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MedicationDispenseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MedicationDispenseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ResourceId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationAdministrationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MedicationAdministrationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MedicationAdministrationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MedicationAdministrationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MedicationResIndex", "ResourceId");
            CreateIndex("dbo.MedicationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MedicationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MedicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MedicationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MedicationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MedicationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MedicationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MediaResIndex", "ResourceId");
            CreateIndex("dbo.MediaResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MediaResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MediaResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MediaResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MediaResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MediaResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MediaResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MediaResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MeasureReportResIndex", "ResourceId");
            CreateIndex("dbo.MeasureReportResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MeasureReportResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MeasureReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureReportResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureReportResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MeasureReportResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MeasureReportResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MeasureReportResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.MeasureResIndex", "ResourceId");
            CreateIndex("dbo.MeasureResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.MeasureResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.MeasureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.MeasureResIndex", "System", name: "ix_System");
            CreateIndex("dbo.MeasureResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.MeasureResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.MeasureResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.LocationResIndex", "ResourceId");
            CreateIndex("dbo.LocationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.LocationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.LocationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LocationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.LocationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.LocationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.LocationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.LocationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ListResIndex", "ResourceId");
            CreateIndex("dbo.ListResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ListResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ListResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ListResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ListResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ListResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ListResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ListResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.LinkageResIndex", "ResourceId");
            CreateIndex("dbo.LinkageResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.LinkageResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.LinkageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LinkageResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.LinkageResIndex", "System", name: "ix_System");
            CreateIndex("dbo.LinkageResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.LinkageResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.LinkageResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.LibraryResIndex", "ResourceId");
            CreateIndex("dbo.LibraryResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.LibraryResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.LibraryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LibraryResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.LibraryResIndex", "System", name: "ix_System");
            CreateIndex("dbo.LibraryResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.LibraryResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.LibraryResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ImplementationGuideResIndex", "ResourceId");
            CreateIndex("dbo.ImplementationGuideResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ImplementationGuideResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ImplementationGuideResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImplementationGuideResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ImplementationGuideResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ImplementationGuideResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ImplementationGuideResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ImplementationGuideResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ResourceId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ImmunizationResIndex", "ResourceId");
            CreateIndex("dbo.ImmunizationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ImmunizationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ImmunizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ImmunizationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ImmunizationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ImmunizationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ImmunizationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ImagingStudyResIndex", "ResourceId");
            CreateIndex("dbo.ImagingStudyResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ImagingStudyResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ImagingStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingStudyResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ImagingStudyResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ImagingStudyResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ImagingStudyResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ImagingStudyResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ImagingManifestResIndex", "ResourceId");
            CreateIndex("dbo.ImagingManifestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ImagingManifestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ImagingManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingManifestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ImagingManifestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ImagingManifestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ImagingManifestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ImagingManifestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.HealthcareServiceResIndex", "ResourceId");
            CreateIndex("dbo.HealthcareServiceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.HealthcareServiceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.HealthcareServiceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.HealthcareServiceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.HealthcareServiceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.HealthcareServiceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.HealthcareServiceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.HealthcareServiceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.GuidanceResponseResIndex", "ResourceId");
            CreateIndex("dbo.GuidanceResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.GuidanceResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.GuidanceResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GuidanceResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.GuidanceResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.GuidanceResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.GuidanceResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.GuidanceResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.GroupResIndex", "ResourceId");
            CreateIndex("dbo.GroupResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.GroupResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.GroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GroupResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.GroupResIndex", "System", name: "ix_System");
            CreateIndex("dbo.GroupResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.GroupResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.GroupResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.GraphDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.GraphDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.GraphDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.GraphDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GraphDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.GraphDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.GraphDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.GraphDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.GraphDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.GoalResIndex", "ResourceId");
            CreateIndex("dbo.GoalResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.GoalResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.GoalResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GoalResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.GoalResIndex", "System", name: "ix_System");
            CreateIndex("dbo.GoalResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.GoalResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.GoalResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.FlagResIndex", "ResourceId");
            CreateIndex("dbo.FlagResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.FlagResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.FlagResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FlagResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.FlagResIndex", "System", name: "ix_System");
            CreateIndex("dbo.FlagResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.FlagResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.FlagResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ResourceId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "System", name: "ix_System");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ResourceId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ExpansionProfileResIndex", "ResourceId");
            CreateIndex("dbo.ExpansionProfileResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ExpansionProfileResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ExpansionProfileResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExpansionProfileResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ExpansionProfileResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ExpansionProfileResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ExpansionProfileResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ExpansionProfileResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ResourceId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EpisodeOfCareResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EpisodeOfCareResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EpisodeOfCareResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EpisodeOfCareResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ResourceId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EnrollmentResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EnrollmentResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EnrollmentResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ResourceId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EnrollmentRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EnrollmentRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EnrollmentRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EnrollmentRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EndpointResIndex", "ResourceId");
            CreateIndex("dbo.EndpointResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EndpointResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EndpointResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EndpointResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EndpointResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EndpointResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EndpointResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EndpointResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EncounterResIndex", "ResourceId");
            CreateIndex("dbo.EncounterResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EncounterResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EncounterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EncounterResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EncounterResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EncounterResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EncounterResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EncounterResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EligibilityResponseResIndex", "ResourceId");
            CreateIndex("dbo.EligibilityResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EligibilityResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EligibilityResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EligibilityResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EligibilityResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EligibilityResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EligibilityResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.EligibilityRequestResIndex", "ResourceId");
            CreateIndex("dbo.EligibilityRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.EligibilityRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.EligibilityRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.EligibilityRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.EligibilityRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.EligibilityRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.EligibilityRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DocumentReferenceResIndex", "ResourceId");
            CreateIndex("dbo.DocumentReferenceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DocumentReferenceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DocumentReferenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentReferenceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentReferenceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DocumentReferenceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DocumentReferenceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DocumentReferenceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DocumentManifestResIndex", "ResourceId");
            CreateIndex("dbo.DocumentManifestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DocumentManifestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DocumentManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentManifestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DocumentManifestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DocumentManifestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DocumentManifestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DocumentManifestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DiagnosticReportResIndex", "ResourceId");
            CreateIndex("dbo.DiagnosticReportResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DiagnosticReportResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DiagnosticReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DiagnosticReportResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DiagnosticReportResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DiagnosticReportResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DiagnosticReportResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DiagnosticReportResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ResourceId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceUseStatementResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DeviceUseStatementResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DeviceUseStatementResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DeviceUseStatementResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DeviceRequestResIndex", "ResourceId");
            CreateIndex("dbo.DeviceRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DeviceRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DeviceRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DeviceRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DeviceRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DeviceRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DeviceMetricResIndex", "ResourceId");
            CreateIndex("dbo.DeviceMetricResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DeviceMetricResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DeviceMetricResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceMetricResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceMetricResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DeviceMetricResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DeviceMetricResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DeviceMetricResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DeviceComponentResIndex", "ResourceId");
            CreateIndex("dbo.DeviceComponentResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DeviceComponentResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DeviceComponentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceComponentResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceComponentResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DeviceComponentResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DeviceComponentResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DeviceComponentResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DeviceResIndex", "ResourceId");
            CreateIndex("dbo.DeviceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DeviceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DeviceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DeviceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DeviceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DeviceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DeviceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DetectedIssueResIndex", "ResourceId");
            CreateIndex("dbo.DetectedIssueResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DetectedIssueResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DetectedIssueResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DetectedIssueResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DetectedIssueResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DetectedIssueResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DetectedIssueResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DetectedIssueResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.DataElementResIndex", "ResourceId");
            CreateIndex("dbo.DataElementResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.DataElementResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.DataElementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DataElementResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.DataElementResIndex", "System", name: "ix_System");
            CreateIndex("dbo.DataElementResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.DataElementResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.DataElementResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CoverageResIndex", "ResourceId");
            CreateIndex("dbo.CoverageResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CoverageResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CoverageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CoverageResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CoverageResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CoverageResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CoverageResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CoverageResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ContractResIndex", "ResourceId");
            CreateIndex("dbo.ContractResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ContractResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ContractResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ContractResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ContractResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ContractResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ContractResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ContractResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ConsentResIndex", "ResourceId");
            CreateIndex("dbo.ConsentResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ConsentResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ConsentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConsentResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ConsentResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ConsentResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ConsentResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ConsentResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ConditionResIndex", "ResourceId");
            CreateIndex("dbo.ConditionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ConditionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ConditionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConditionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ConditionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ConditionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ConditionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ConditionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ConceptMapResIndex", "ResourceId");
            CreateIndex("dbo.ConceptMapResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ConceptMapResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ConceptMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConceptMapResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ConceptMapResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ConceptMapResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ConceptMapResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ConceptMapResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CompositionResIndex", "ResourceId");
            CreateIndex("dbo.CompositionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CompositionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CompositionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompositionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CompositionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CompositionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CompositionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CompositionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CommunicationRequestResIndex", "ResourceId");
            CreateIndex("dbo.CommunicationRequestResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CommunicationRequestResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CommunicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRequestResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationRequestResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CommunicationRequestResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CommunicationRequestResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CommunicationRequestResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CommunicationResIndex", "ResourceId");
            CreateIndex("dbo.CommunicationResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CommunicationResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CommunicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CommunicationResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CommunicationResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CommunicationResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CommunicationResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CodeSystemResIndex", "ResourceId");
            CreateIndex("dbo.CodeSystemResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CodeSystemResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CodeSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CodeSystemResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CodeSystemResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CodeSystemResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CodeSystemResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CodeSystemResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ResourceId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ClinicalImpressionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ClinicalImpressionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ClinicalImpressionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ClinicalImpressionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ClaimResponseResIndex", "ResourceId");
            CreateIndex("dbo.ClaimResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ClaimResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ClaimResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ClaimResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ClaimResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ClaimResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ClaimResIndex", "ResourceId");
            CreateIndex("dbo.ClaimResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ClaimResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ClaimResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ClaimResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ClaimResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ClaimResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ClaimResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ChargeItemResIndex", "ResourceId");
            CreateIndex("dbo.ChargeItemResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ChargeItemResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ChargeItemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ChargeItemResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ChargeItemResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ChargeItemResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ChargeItemResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ChargeItemResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CareTeamResIndex", "ResourceId");
            CreateIndex("dbo.CareTeamResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CareTeamResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CareTeamResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CareTeamResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CareTeamResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CareTeamResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CareTeamResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CareTeamResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CarePlanResIndex", "ResourceId");
            CreateIndex("dbo.CarePlanResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CarePlanResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CarePlanResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CarePlanResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CarePlanResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CarePlanResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CarePlanResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CarePlanResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.CapabilityStatementResIndex", "ResourceId");
            CreateIndex("dbo.CapabilityStatementResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.CapabilityStatementResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.CapabilityStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CapabilityStatementResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.CapabilityStatementResIndex", "System", name: "ix_System");
            CreateIndex("dbo.CapabilityStatementResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.CapabilityStatementResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.CapabilityStatementResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.BundleResIndex", "ResourceId");
            CreateIndex("dbo.BundleResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.BundleResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.BundleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BundleResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.BundleResIndex", "System", name: "ix_System");
            CreateIndex("dbo.BundleResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.BundleResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.BundleResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.BodySiteResIndex", "ResourceId");
            CreateIndex("dbo.BodySiteResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.BodySiteResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.BodySiteResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BodySiteResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.BodySiteResIndex", "System", name: "ix_System");
            CreateIndex("dbo.BodySiteResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.BodySiteResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.BodySiteResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.BinaryResIndex", "ResourceId");
            CreateIndex("dbo.BinaryResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.BinaryResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.BinaryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BinaryResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.BinaryResIndex", "System", name: "ix_System");
            CreateIndex("dbo.BinaryResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.BinaryResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.BinaryResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.BasicResIndex", "ResourceId");
            CreateIndex("dbo.BasicResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.BasicResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.BasicResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BasicResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.BasicResIndex", "System", name: "ix_System");
            CreateIndex("dbo.BasicResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.BasicResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.BasicResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AuditEventResIndex", "ResourceId");
            CreateIndex("dbo.AuditEventResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AuditEventResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AuditEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AuditEventResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AuditEventResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AuditEventResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AuditEventResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AuditEventResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AppointmentResponseResIndex", "ResourceId");
            CreateIndex("dbo.AppointmentResponseResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AppointmentResponseResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AppointmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResponseResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentResponseResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AppointmentResponseResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AppointmentResponseResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AppointmentResponseResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AppointmentResIndex", "ResourceId");
            CreateIndex("dbo.AppointmentResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AppointmentResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AppointmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AppointmentResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AppointmentResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AppointmentResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AppointmentResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ResourceId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AdverseEventResIndex", "ResourceId");
            CreateIndex("dbo.AdverseEventResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AdverseEventResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AdverseEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AdverseEventResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AdverseEventResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AdverseEventResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AdverseEventResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AdverseEventResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ResourceId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.ActivityDefinitionResIndex", "System", name: "ix_System");
            CreateIndex("dbo.ActivityDefinitionResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.ActivityDefinitionResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.ActivityDefinitionResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            CreateIndex("dbo.AccountResIndex", "ResourceId");
            CreateIndex("dbo.AccountResIndex", "ServiceSearchParameterId", name: "ix_ServiceSearchParameterId");
            CreateIndex("dbo.AccountResIndex", "ReferenceServiceBaseUrlId", name: "ix_ReferenceServiceBaseUrlId");
            CreateIndex("dbo.AccountResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AccountResIndex", "Code", name: "ix_Code");
            CreateIndex("dbo.AccountResIndex", "System", name: "ix_System");
            CreateIndex("dbo.AccountResIndex", "Uri", name: "ix_Uri");
            CreateIndex("dbo.AccountResIndex", "DateTimeOffsetHigh", name: "ix_DateTimeOffsetHigh");
            CreateIndex("dbo.AccountResIndex", "DateTimeOffsetLow", name: "ix_DateTimeOffsetLow");
            AddForeignKey("dbo.VisionPrescriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VisionPrescriptionResIndex", "ResourceId", "dbo.VisionPrescriptionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VisionPrescriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ValueSetResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ValueSetResIndex", "ResourceId", "dbo.ValueSetRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ValueSetResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.TestScriptResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestScriptResIndex", "ResourceId", "dbo.TestScriptRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestScriptResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.TestReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestReportResIndex", "ResourceId", "dbo.TestReportRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.TaskResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TaskResIndex", "ResourceId", "dbo.TaskRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TaskResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SupplyRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyRequestResIndex", "ResourceId", "dbo.SupplyRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SupplyDeliveryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyDeliveryResIndex", "ResourceId", "dbo.SupplyDeliveryRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyDeliveryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SubstanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubstanceResIndex", "ResourceId", "dbo.SubstanceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubstanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SubscriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubscriptionResIndex", "ResourceId", "dbo.SubscriptionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubscriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.StructureMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StructureMapResIndex", "ResourceId", "dbo.StructureMapRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StructureMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.StructureDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StructureDefinitionResIndex", "ResourceId", "dbo.StructureDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StructureDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SpecimenResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpecimenResIndex", "ResourceId", "dbo.SpecimenRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpecimenResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SlotResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SlotResIndex", "ResourceId", "dbo.SlotRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SlotResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ServiceDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceDefinitionResIndex", "ResourceId", "dbo.ServiceDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SequenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SequenceResIndex", "ResourceId", "dbo.SequenceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SequenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.SearchParameterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SearchParameterResIndex", "ResourceId", "dbo.SearchParameterRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SearchParameterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ScheduleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ScheduleResIndex", "ResourceId", "dbo.ScheduleRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ScheduleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.RiskAssessmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RiskAssessmentResIndex", "ResourceId", "dbo.RiskAssessmentRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RiskAssessmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ResearchSubjectResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchSubjectResIndex", "ResourceId", "dbo.ResearchSubjectRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchSubjectResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ResearchStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchStudyResIndex", "ResourceId", "dbo.ResearchStudyRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.RequestGroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RequestGroupResIndex", "ResourceId", "dbo.RequestGroupRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RequestGroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.RelatedPersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RelatedPersonResIndex", "ResourceId", "dbo.RelatedPersonRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RelatedPersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ReferralRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReferralRequestResIndex", "ResourceId", "dbo.ReferralRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReferralRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.QuestionnaireResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionnaireResponseResIndex", "ResourceId", "dbo.QuestionnaireResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionnaireResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.QuestionnaireResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionnaireResIndex", "ResourceId", "dbo.QuestionnaireRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionnaireResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ProvenanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProvenanceResIndex", "ResourceId", "dbo.ProvenanceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProvenanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ProcessResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcessResponseResIndex", "ResourceId", "dbo.ProcessResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcessResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ProcessRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcessRequestResIndex", "ResourceId", "dbo.ProcessRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcessRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ProcedureRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcedureRequestResIndex", "ResourceId", "dbo.ProcedureRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcedureRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ProcedureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcedureResIndex", "ResourceId", "dbo.ProcedureRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcedureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PractitionerRoleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PractitionerRoleResIndex", "ResourceId", "dbo.PractitionerRoleRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PractitionerRoleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PractitionerResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PractitionerResIndex", "ResourceId", "dbo.PractitionerRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PractitionerResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PlanDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanDefinitionResIndex", "ResourceId", "dbo.PlanDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonResIndex", "ResourceId", "dbo.PersonRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PaymentReconciliationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaymentReconciliationResIndex", "ResourceId", "dbo.PaymentReconciliationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaymentReconciliationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PaymentNoticeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaymentNoticeResIndex", "ResourceId", "dbo.PaymentNoticeRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaymentNoticeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.PatientResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientResIndex", "ResourceId", "dbo.PatientRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ParametersResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParametersResIndex", "ResourceId", "dbo.ParametersRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParametersResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.OrganizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationResIndex", "ResourceId", "dbo.OrganizationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.OperationOutcomeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OperationOutcomeResIndex", "ResourceId", "dbo.OperationOutcomeRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OperationOutcomeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.OperationDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OperationDefinitionResIndex", "ResourceId", "dbo.OperationDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OperationDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ObservationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ObservationResIndex", "ResourceId", "dbo.ObservationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ObservationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.NutritionOrderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NutritionOrderResIndex", "ResourceId", "dbo.NutritionOrderRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NutritionOrderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.NamingSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NamingSystemResIndex", "ResourceId", "dbo.NamingSystemRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NamingSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MessageHeaderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MessageHeaderResIndex", "ResourceId", "dbo.MessageHeaderRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MessageHeaderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MessageDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MessageDefinitionResIndex", "ResourceId", "dbo.MessageDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MessageDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MedicationStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationStatementResIndex", "ResourceId", "dbo.MedicationStatementRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MedicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationRequestResIndex", "ResourceId", "dbo.MedicationRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MedicationDispenseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationDispenseResIndex", "ResourceId", "dbo.MedicationDispenseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationDispenseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MedicationAdministrationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationAdministrationResIndex", "ResourceId", "dbo.MedicationAdministrationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationAdministrationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MedicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationResIndex", "ResourceId", "dbo.MedicationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MediaResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MediaResIndex", "ResourceId", "dbo.MediaRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MediaResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MeasureReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeasureReportResIndex", "ResourceId", "dbo.MeasureReportRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeasureReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.MeasureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeasureResIndex", "ResourceId", "dbo.MeasureRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeasureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.LocationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LocationResIndex", "ResourceId", "dbo.LocationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LocationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ListResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ListResIndex", "ResourceId", "dbo.ListRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ListResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.LinkageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LinkageResIndex", "ResourceId", "dbo.LinkageRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LinkageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.LibraryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LibraryResIndex", "ResourceId", "dbo.LibraryRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LibraryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ImplementationGuideResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImplementationGuideResIndex", "ResourceId", "dbo.ImplementationGuideRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImplementationGuideResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ImmunizationRecommendationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImmunizationRecommendationResIndex", "ResourceId", "dbo.ImmunizationRecommendationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImmunizationRecommendationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ImmunizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImmunizationResIndex", "ResourceId", "dbo.ImmunizationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImmunizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ImagingStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImagingStudyResIndex", "ResourceId", "dbo.ImagingStudyRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImagingStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ImagingManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImagingManifestResIndex", "ResourceId", "dbo.ImagingManifestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImagingManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.HealthcareServiceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HealthcareServiceResIndex", "ResourceId", "dbo.HealthcareServiceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HealthcareServiceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.GuidanceResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GuidanceResponseResIndex", "ResourceId", "dbo.GuidanceResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GuidanceResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.GroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupResIndex", "ResourceId", "dbo.GroupRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.GraphDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GraphDefinitionResIndex", "ResourceId", "dbo.GraphDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GraphDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.GoalResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoalResIndex", "ResourceId", "dbo.GoalRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoalResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.FlagResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FlagResIndex", "ResourceId", "dbo.FlagRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FlagResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.FamilyMemberHistoryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FamilyMemberHistoryResIndex", "ResourceId", "dbo.FamilyMemberHistoryRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FamilyMemberHistoryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ExplanationOfBenefitResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExplanationOfBenefitResIndex", "ResourceId", "dbo.ExplanationOfBenefitRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExplanationOfBenefitResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ExpansionProfileResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExpansionProfileResIndex", "ResourceId", "dbo.ExpansionProfileRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExpansionProfileResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EpisodeOfCareResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EpisodeOfCareResIndex", "ResourceId", "dbo.EpisodeOfCareRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EpisodeOfCareResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EnrollmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentResponseResIndex", "ResourceId", "dbo.EnrollmentResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EnrollmentRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentRequestResIndex", "ResourceId", "dbo.EnrollmentRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EndpointResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EndpointResIndex", "ResourceId", "dbo.EndpointRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EndpointResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EncounterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EncounterResIndex", "ResourceId", "dbo.EncounterRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EncounterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EligibilityResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EligibilityResponseResIndex", "ResourceId", "dbo.EligibilityResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EligibilityResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.EligibilityRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EligibilityRequestResIndex", "ResourceId", "dbo.EligibilityRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EligibilityRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DocumentReferenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentReferenceResIndex", "ResourceId", "dbo.DocumentReferenceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentReferenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DocumentManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentManifestResIndex", "ResourceId", "dbo.DocumentManifestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DiagnosticReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DiagnosticReportResIndex", "ResourceId", "dbo.DiagnosticReportRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DiagnosticReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DeviceUseStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceUseStatementResIndex", "ResourceId", "dbo.DeviceUseStatementRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceUseStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DeviceRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceRequestResIndex", "ResourceId", "dbo.DeviceRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DeviceMetricResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMetricResIndex", "ResourceId", "dbo.DeviceMetricRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceMetricResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DeviceComponentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceComponentResIndex", "ResourceId", "dbo.DeviceComponentRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceComponentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DeviceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceResIndex", "ResourceId", "dbo.DeviceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeviceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DetectedIssueResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetectedIssueResIndex", "ResourceId", "dbo.DetectedIssueRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetectedIssueResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.DataElementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DataElementResIndex", "ResourceId", "dbo.DataElementRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DataElementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CoverageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoverageResIndex", "ResourceId", "dbo.CoverageRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoverageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ContractResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContractResIndex", "ResourceId", "dbo.ContractRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContractResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ConsentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConsentResIndex", "ResourceId", "dbo.ConsentRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConsentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ConditionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConditionResIndex", "ResourceId", "dbo.ConditionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConditionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ConceptMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConceptMapResIndex", "ResourceId", "dbo.ConceptMapRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConceptMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CompositionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompositionResIndex", "ResourceId", "dbo.CompositionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompositionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CompartmentDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompartmentDefinitionResIndex", "ResourceId", "dbo.CompartmentDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompartmentDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CommunicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunicationRequestResIndex", "ResourceId", "dbo.CommunicationRequestRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CommunicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunicationResIndex", "ResourceId", "dbo.CommunicationRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CodeSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CodeSystemResIndex", "ResourceId", "dbo.CodeSystemRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CodeSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ClinicalImpressionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClinicalImpressionResIndex", "ResourceId", "dbo.ClinicalImpressionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClinicalImpressionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ClaimResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClaimResponseResIndex", "ResourceId", "dbo.ClaimResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClaimResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ClaimResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClaimResIndex", "ResourceId", "dbo.ClaimRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClaimResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ChargeItemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChargeItemResIndex", "ResourceId", "dbo.ChargeItemRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChargeItemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CareTeamResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CareTeamResIndex", "ResourceId", "dbo.CareTeamRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CareTeamResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CarePlanResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CarePlanResIndex", "ResourceId", "dbo.CarePlanRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CarePlanResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.CapabilityStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CapabilityStatementResIndex", "ResourceId", "dbo.CapabilityStatementRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CapabilityStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.BundleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BundleResIndex", "ResourceId", "dbo.BundleRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BundleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.BodySiteResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BodySiteResIndex", "ResourceId", "dbo.BodySiteRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BodySiteResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.BinaryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BinaryResIndex", "ResourceId", "dbo.BinaryRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BinaryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.BasicResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BasicResIndex", "ResourceId", "dbo.BasicRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BasicResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AuditEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AuditEventResIndex", "ResourceId", "dbo.AuditEventRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AuditEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AppointmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppointmentResponseResIndex", "ResourceId", "dbo.AppointmentResponseRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppointmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AppointmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppointmentResIndex", "ResourceId", "dbo.AppointmentRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppointmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AllergyIntoleranceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AllergyIntoleranceResIndex", "ResourceId", "dbo.AllergyIntoleranceRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AllergyIntoleranceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AdverseEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdverseEventResIndex", "ResourceId", "dbo.AdverseEventRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdverseEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.ActivityDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ActivityDefinitionResIndex", "ResourceId", "dbo.ActivityDefinitionRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ActivityDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
            AddForeignKey("dbo.AccountResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AccountResIndex", "ResourceId", "dbo.AccountRes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AccountResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl", "Id");
        }
    }
}
