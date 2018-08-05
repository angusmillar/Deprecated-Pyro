namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ReferenceIndexCaseSensitiveReinstate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ActivityDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ListResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AccountResIndexReference", "ix_ReferenceFhirId");
            AlterColumn("dbo.ActivityDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AccountResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            CreateIndex("dbo.ActivityDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AdverseEventResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AllergyIntoleranceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AuditEventResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BasicResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BinaryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BodySiteResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BundleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CapabilityStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CarePlanResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CareTeamResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ChargeItemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClinicalImpressionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CodeSystemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompartmentDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompositionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConceptMapResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConditionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConsentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ContractResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CoverageResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DataElementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DetectedIssueResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceComponentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceMetricResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceUseStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DiagnosticReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentManifestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentReferenceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EncounterResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EndpointResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EpisodeOfCareResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExpansionProfileResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExplanationOfBenefitResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FamilyMemberHistoryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FlagResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GoalResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GraphDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GroupResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GuidanceResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.HealthcareServiceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingManifestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingStudyResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRecommendationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImplementationGuideResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LibraryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LinkageResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ListResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LocationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MediaResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationAdministrationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationDispenseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageHeaderResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NamingSystemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NutritionOrderResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ObservationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationOutcomeResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OrganizationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ParametersResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PatientResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentNoticeResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentReconciliationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PersonResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PlanDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRoleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProvenanceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ReferralRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RelatedPersonResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RequestGroupResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchStudyResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchSubjectResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RiskAssessmentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ScheduleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SearchParameterResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SequenceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ServiceDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SlotResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SpecimenResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureMapResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubscriptionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubstanceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyDeliveryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TaskResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestScriptResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ValueSetResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.VisionPrescriptionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AccountResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ListResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventResIndexReference", "ix_ReferenceFhirId");
            DropIndex("dbo.ActivityDefinitionResIndexReference", "ix_ReferenceFhirId");
            AlterColumn("dbo.AccountResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionResIndexReference", "ReferenceVersionId", c => c.String(maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionResIndexReference", "ReferenceFhirId", c => c.String(nullable: false, maxLength: 128,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            CreateIndex("dbo.AccountResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.VisionPrescriptionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ValueSetResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestScriptResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TestReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.TaskResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SupplyDeliveryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubstanceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SubscriptionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureMapResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.StructureDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SpecimenResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SlotResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ServiceDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SequenceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.SearchParameterResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ScheduleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RiskAssessmentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchSubjectResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ResearchStudyResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RequestGroupResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.RelatedPersonResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ReferralRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.QuestionnaireResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProvenanceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcessRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ProcedureResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerRoleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PractitionerResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PlanDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PersonResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentReconciliationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PaymentNoticeResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.PatientResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ParametersResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OrganizationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationOutcomeResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.OperationDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ObservationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NutritionOrderResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.NamingSystemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageHeaderResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MessageDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationDispenseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MedicationAdministrationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MediaResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.MeasureResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LocationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ListResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LinkageResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.LibraryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImplementationGuideResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationRecommendationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImmunizationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingStudyResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ImagingManifestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.HealthcareServiceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GuidanceResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GroupResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GraphDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.GoalResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FlagResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.FamilyMemberHistoryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExplanationOfBenefitResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ExpansionProfileResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EpisodeOfCareResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EnrollmentRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EndpointResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EncounterResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.EligibilityRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentReferenceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DocumentManifestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DiagnosticReportResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceUseStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceMetricResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DeviceComponentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DetectedIssueResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.DataElementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CoverageResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ContractResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConsentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConditionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ConceptMapResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompositionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CompartmentDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationRequestResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CommunicationResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CodeSystemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClinicalImpressionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ClaimResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ChargeItemResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CareTeamResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CarePlanResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.CapabilityStatementResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BundleResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BodySiteResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BinaryResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.BasicResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AuditEventResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResponseResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AppointmentResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AllergyIntoleranceResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.AdverseEventResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
            CreateIndex("dbo.ActivityDefinitionResIndexReference", "ReferenceFhirId", name: "ix_ReferenceFhirId");
        }
    }
}
