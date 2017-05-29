namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensitive_FHIR_Id : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BasicRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BinaryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BundleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompositionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConditionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConsentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ContractRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CoverageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DataElementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EncounterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EndpointRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FlagRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GoalRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LibraryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LinkageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ListRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LocationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MediaRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ObservationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ParametersRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PatientRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SequenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SlotRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TaskRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.VisionPrescriptionRes", "UQ_FhirIdAndVersionId");
            AlterColumn("dbo.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DataElementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            AlterColumn("dbo.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: null, newValue: "True")
                    },
                }));
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BodySiteRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DataElementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceComponentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ExpansionProfileRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ReferralRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VisionPrescriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TaskRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SlotRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SequenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PatientRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ParametersRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ObservationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MediaRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LocationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ListRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LinkageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LibraryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GoalRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FlagRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EndpointRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EncounterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DataElementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CoverageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ContractRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConsentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConditionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompositionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BundleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BinaryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BasicRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AccountRes", "UQ_FhirIdAndVersionId");
            AlterColumn("dbo.VisionPrescriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ValueSetRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestScriptRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TestReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.TaskRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SupplyDeliveryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubstanceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SubscriptionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureMapRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.StructureDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SpecimenRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SlotRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ServiceDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SequenceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.SearchParameterRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ScheduleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RiskAssessmentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchSubjectRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ResearchStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RequestGroupRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.RelatedPersonRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ReferralRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.QuestionnaireRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProvenanceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcessRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProcedureRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRoleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PractitionerRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PlanDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PersonRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentReconciliationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PaymentNoticeRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.PatientRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ParametersRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OrganizationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationOutcomeRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.OperationDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ObservationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NutritionOrderRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.NamingSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageHeaderRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MessageDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationDispenseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationAdministrationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MedicationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MediaRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.MeasureRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LocationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ListRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LinkageRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.LibraryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImplementationGuideRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRecommendationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImmunizationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingStudyRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ImagingManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.HealthcareServiceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GuidanceResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GroupRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GraphDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.GoalRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FlagRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.FamilyMemberHistoryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExplanationOfBenefitRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ExpansionProfileRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EpisodeOfCareRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EnrollmentRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EndpointRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EncounterRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.EligibilityRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentReferenceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DocumentManifestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DiagnosticReportRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceUseStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceMetricRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceComponentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DeviceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DetectedIssueRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.DataElementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CoverageRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ContractRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConsentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConditionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ConceptMapRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompositionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CompartmentDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRequestRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CommunicationRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CodeSystemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClinicalImpressionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ClaimRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ChargeItemRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CareTeamRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CarePlanRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.CapabilityStatementRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BundleRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BodySiteRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BinaryRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.BasicRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AuditEventRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentResponseRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AppointmentRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AllergyIntoleranceRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AdverseEventRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.ActivityDefinitionRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            AlterColumn("dbo.AccountRes", "FhirId", c => c.String(nullable: false, maxLength: 400,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "CaseSensitive",
                        new AnnotationValues(oldValue: "True", newValue: null)
                    },
                }));
            CreateIndex("dbo.VisionPrescriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ValueSetRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TestScriptRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TestReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.TaskRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SupplyDeliveryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SubstanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SubscriptionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.StructureMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.StructureDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SpecimenRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SlotRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ServiceDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SequenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.SearchParameterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ScheduleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RiskAssessmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchSubjectRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ResearchStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RequestGroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.RelatedPersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ReferralRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.QuestionnaireRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProvenanceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcessRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ProcedureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRoleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PractitionerRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PlanDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PersonRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentReconciliationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PaymentNoticeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.PatientRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ParametersRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OrganizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OperationOutcomeRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.OperationDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ObservationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.NutritionOrderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.NamingSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MessageHeaderRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MessageDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationDispenseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationAdministrationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MedicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MediaRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.MeasureRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LocationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ListRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LinkageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.LibraryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImplementationGuideRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRecommendationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImmunizationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingStudyRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ImagingManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.HealthcareServiceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GuidanceResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GroupRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GraphDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.GoalRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.FlagRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.FamilyMemberHistoryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ExplanationOfBenefitRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ExpansionProfileRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EpisodeOfCareRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EnrollmentRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EndpointRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EncounterRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.EligibilityRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentReferenceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DocumentManifestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DiagnosticReportRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceUseStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceMetricRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceComponentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DeviceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DetectedIssueRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.DataElementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CoverageRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ContractRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConsentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConditionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ConceptMapRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CompositionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CompartmentDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRequestRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CommunicationRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CodeSystemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClinicalImpressionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ClaimRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ChargeItemRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CareTeamRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CarePlanRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.CapabilityStatementRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BundleRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BodySiteRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BinaryRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.BasicRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AuditEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentResponseRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AppointmentRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AllergyIntoleranceRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AdverseEventRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.ActivityDefinitionRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
            CreateIndex("dbo.AccountRes", new[] { "FhirId", "VersionId" }, unique: true, name: "UQ_FhirIdAndVersionId");
        }
    }
}
