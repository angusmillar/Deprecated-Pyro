namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensativeFhirId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AccountResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceFhirId");
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
            AlterColumn("dbo.AccountResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ActivityDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AdverseEventResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AllergyIntoleranceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AuditEventResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BasicResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BinaryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BundleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CapabilityStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CarePlanResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CareTeamResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClinicalImpressionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CodeSystemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompartmentDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompositionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConceptMapResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConditionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConsentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ContractResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CoverageResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DetectedIssueResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceMetricResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceUseStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DiagnosticReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentManifestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentReferenceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EncounterResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EndpointResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EpisodeOfCareResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExplanationOfBenefitResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FamilyMemberHistoryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FlagResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GoalResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GraphDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GroupResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GuidanceResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.HealthcareServiceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImagingStudyResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationRecommendationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImplementationGuideResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LibraryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LinkageResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ListResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LocationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MediaResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationAdministrationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationDispenseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageHeaderResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NamingSystemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NutritionOrderResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationOutcomeResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ParametersResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PatientResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentNoticeResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentReconciliationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PersonResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PlanDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerRoleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcedureResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcessRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcessResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProvenanceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RelatedPersonResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RequestGroupResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchStudyResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchSubjectResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RiskAssessmentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ScheduleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SearchParameterResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SequenceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SlotResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureMapResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubscriptionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyDeliveryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TaskResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestScriptResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ValueSetResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.VisionPrescriptionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AccountResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BodySiteRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodySiteResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DataElementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DataElementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceComponentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceComponentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExpansionProfileRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExpansionProfileResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ReferralRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ReferralRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ServiceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.VisionPrescriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.TaskResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SlotResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.PatientResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MediaResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LocationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ListResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ListRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.GoalResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FlagResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ContractResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BundleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.BasicResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ActivityDefinitionRes", "uq_FhirIdAndVersionId");
            DropIndex("dbo.AccountResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AccountRes", "uq_FhirIdAndVersionId");
            AlterColumn("dbo.VisionPrescriptionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ValueSetResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestScriptResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TestReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.TaskResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SupplyDeliveryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubstanceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SubscriptionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureMapResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.StructureDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SpecimenResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SlotResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ServiceDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.SearchParameterResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ScheduleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RiskAssessmentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchSubjectResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ResearchStudyResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RequestGroupResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.RelatedPersonResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ReferralRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.QuestionnaireResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProvenanceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcessResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcessRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ProcedureRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerRoleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PractitionerResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PlanDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PersonResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentReconciliationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PaymentNoticeResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.PatientResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ParametersResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OrganizationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationOutcomeResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.OperationDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ObservationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NutritionOrderResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.NamingSystemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageHeaderResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MessageDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationDispenseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationAdministrationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MedicationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MediaResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.MeasureResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LocationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ListResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LinkageResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.LibraryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImplementationGuideResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationRecommendationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImmunizationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImagingStudyResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ImagingManifestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GuidanceResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GroupResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GraphDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.GoalResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FlagResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.FamilyMemberHistoryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExplanationOfBenefitResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ExpansionProfileResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EnrollmentRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EndpointResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EncounterResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.EligibilityResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DocumentManifestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DiagnosticReportResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceUseStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceMetricResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DeviceComponentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DetectedIssueResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.DataElementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ContractResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConsentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConditionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ConceptMapResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompositionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CompartmentDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationRequestResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CommunicationResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CodeSystemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClinicalImpressionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ClaimResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ChargeItemResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CareTeamResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CarePlanResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.CapabilityStatementResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BundleResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BodySiteResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "VersionId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "FhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.BasicResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AuditEventResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResponseResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AppointmentResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AllergyIntoleranceResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AdverseEventResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.ActivityDefinitionResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            AlterColumn("dbo.AccountResIndex", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountResIndex", "ReferenceFhirId", c => c.String(maxLength: 128,
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
            CreateIndex("dbo.VisionPrescriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.TaskResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SlotResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ServiceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ReferralRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ReferralRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PersonResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.PatientResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MediaResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LocationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ListResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GroupResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.GoalResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FlagResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ExpansionProfileResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExpansionProfileRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceComponentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceComponentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.DataElementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DataElementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ContractResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BundleResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BodySiteResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BodySiteRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.BasicResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
            CreateIndex("dbo.AccountResIndex", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "uq_FhirIdAndVersionId");
        }
    }
}
