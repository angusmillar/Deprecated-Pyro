namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CaseSensitive_FHIR_Id_And_Version : DbMigration
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
