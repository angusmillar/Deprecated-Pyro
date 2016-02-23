 
 
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using DataModel.BlazeDbModel2;

//This is an Auto generated file do not change it's contents!!.

namespace DataModel.BlazeDbModel2
{
  public class BlazeDbContext: DbContext
  {
    public BlazeDbContext()
      : base("BlazeConnectionString")
    {
      Database.SetInitializer<BlazeDbContext>(new CreateDatabaseIfNotExists<BlazeDbContext>());
      //Database.SetInitializer<BlazeDbContext>(new DropCreateDatabaseAlways<BlazeDbContext>());       
    }

    public DbSet<Resource_Account> Resource_Account { get; set; }
    public DbSet<Resource_Account_Search_identifier> Resource_Account_Search_identifier { get; set; }

    public DbSet<Resource_AllergyIntolerance> Resource_AllergyIntolerance { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_identifier> Resource_AllergyIntolerance_Search_identifier { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_manifestation> Resource_AllergyIntolerance_Search_manifestation { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_onset> Resource_AllergyIntolerance_Search_onset { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_route> Resource_AllergyIntolerance_Search_route { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_severity> Resource_AllergyIntolerance_Search_severity { get; set; }
    public DbSet<Resource_AllergyIntolerance_Search_substance> Resource_AllergyIntolerance_Search_substance { get; set; }

    public DbSet<Resource_Appointment> Resource_Appointment { get; set; }
    public DbSet<Resource_Appointment_Search_actor> Resource_Appointment_Search_actor { get; set; }
    public DbSet<Resource_Appointment_Search_identifier> Resource_Appointment_Search_identifier { get; set; }
    public DbSet<Resource_Appointment_Search_location> Resource_Appointment_Search_location { get; set; }
    public DbSet<Resource_Appointment_Search_part_status> Resource_Appointment_Search_part_status { get; set; }
    public DbSet<Resource_Appointment_Search_patient> Resource_Appointment_Search_patient { get; set; }
    public DbSet<Resource_Appointment_Search_practitioner> Resource_Appointment_Search_practitioner { get; set; }

    public DbSet<Resource_AppointmentResponse> Resource_AppointmentResponse { get; set; }
    public DbSet<Resource_AppointmentResponse_Search_identifier> Resource_AppointmentResponse_Search_identifier { get; set; }

    public DbSet<Resource_AuditEvent> Resource_AuditEvent { get; set; }
    public DbSet<Resource_AuditEvent_Search_address> Resource_AuditEvent_Search_address { get; set; }
    public DbSet<Resource_AuditEvent_Search_altid> Resource_AuditEvent_Search_altid { get; set; }
    public DbSet<Resource_AuditEvent_Search_desc> Resource_AuditEvent_Search_desc { get; set; }
    public DbSet<Resource_AuditEvent_Search_identity> Resource_AuditEvent_Search_identity { get; set; }
    public DbSet<Resource_AuditEvent_Search_name> Resource_AuditEvent_Search_name { get; set; }
    public DbSet<Resource_AuditEvent_Search_object_type> Resource_AuditEvent_Search_object_type { get; set; }
    public DbSet<Resource_AuditEvent_Search_participant> Resource_AuditEvent_Search_participant { get; set; }
    public DbSet<Resource_AuditEvent_Search_patient> Resource_AuditEvent_Search_patient { get; set; }
    public DbSet<Resource_AuditEvent_Search_policy> Resource_AuditEvent_Search_policy { get; set; }
    public DbSet<Resource_AuditEvent_Search_reference> Resource_AuditEvent_Search_reference { get; set; }
    public DbSet<Resource_AuditEvent_Search_subtype> Resource_AuditEvent_Search_subtype { get; set; }
    public DbSet<Resource_AuditEvent_Search_user> Resource_AuditEvent_Search_user { get; set; }

    public DbSet<Resource_Basic> Resource_Basic { get; set; }
    public DbSet<Resource_Basic_Search_identifier> Resource_Basic_Search_identifier { get; set; }

    public DbSet<Resource_Binary> Resource_Binary { get; set; }

    public DbSet<Resource_BodySite> Resource_BodySite { get; set; }
    public DbSet<Resource_BodySite_Search_identifier> Resource_BodySite_Search_identifier { get; set; }

    public DbSet<Resource_Bundle> Resource_Bundle { get; set; }

    public DbSet<Resource_CarePlan> Resource_CarePlan { get; set; }
    public DbSet<Resource_CarePlan_Search_activitycode> Resource_CarePlan_Search_activitycode { get; set; }
    public DbSet<Resource_CarePlan_Search_activitydate> Resource_CarePlan_Search_activitydate { get; set; }
    public DbSet<Resource_CarePlan_Search_activityreference> Resource_CarePlan_Search_activityreference { get; set; }
    public DbSet<Resource_CarePlan_Search_condition> Resource_CarePlan_Search_condition { get; set; }
    public DbSet<Resource_CarePlan_Search_goal> Resource_CarePlan_Search_goal { get; set; }
    public DbSet<Resource_CarePlan_Search_participant> Resource_CarePlan_Search_participant { get; set; }
    public DbSet<Resource_CarePlan_Search_performer> Resource_CarePlan_Search_performer { get; set; }
    public DbSet<Resource_CarePlan_Search_relatedcode> Resource_CarePlan_Search_relatedcode { get; set; }
    public DbSet<Resource_CarePlan_Search_relatedplan> Resource_CarePlan_Search_relatedplan { get; set; }
    public DbSet<Resource_CarePlan_Search_related> Resource_CarePlan_Search_related { get; set; }

    public DbSet<Resource_Claim> Resource_Claim { get; set; }
    public DbSet<Resource_Claim_Search_identifier> Resource_Claim_Search_identifier { get; set; }

    public DbSet<Resource_ClaimResponse> Resource_ClaimResponse { get; set; }
    public DbSet<Resource_ClaimResponse_Search_identifier> Resource_ClaimResponse_Search_identifier { get; set; }

    public DbSet<Resource_ClinicalImpression> Resource_ClinicalImpression { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_action> Resource_ClinicalImpression_Search_action { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_finding> Resource_ClinicalImpression_Search_finding { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_investigation> Resource_ClinicalImpression_Search_investigation { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_plan> Resource_ClinicalImpression_Search_plan { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_problem> Resource_ClinicalImpression_Search_problem { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_resolved> Resource_ClinicalImpression_Search_resolved { get; set; }
    public DbSet<Resource_ClinicalImpression_Search_ruledout> Resource_ClinicalImpression_Search_ruledout { get; set; }

    public DbSet<Resource_Communication> Resource_Communication { get; set; }
    public DbSet<Resource_Communication_Search_identifier> Resource_Communication_Search_identifier { get; set; }
    public DbSet<Resource_Communication_Search_medium> Resource_Communication_Search_medium { get; set; }
    public DbSet<Resource_Communication_Search_recipient> Resource_Communication_Search_recipient { get; set; }

    public DbSet<Resource_CommunicationRequest> Resource_CommunicationRequest { get; set; }
    public DbSet<Resource_CommunicationRequest_Search_identifier> Resource_CommunicationRequest_Search_identifier { get; set; }
    public DbSet<Resource_CommunicationRequest_Search_medium> Resource_CommunicationRequest_Search_medium { get; set; }
    public DbSet<Resource_CommunicationRequest_Search_recipient> Resource_CommunicationRequest_Search_recipient { get; set; }

    public DbSet<Resource_Composition> Resource_Composition { get; set; }
    public DbSet<Resource_Composition_Search_attester> Resource_Composition_Search_attester { get; set; }
    public DbSet<Resource_Composition_Search_author> Resource_Composition_Search_author { get; set; }
    public DbSet<Resource_Composition_Search_context> Resource_Composition_Search_context { get; set; }
    public DbSet<Resource_Composition_Search_entry> Resource_Composition_Search_entry { get; set; }
    public DbSet<Resource_Composition_Search_period> Resource_Composition_Search_period { get; set; }
    public DbSet<Resource_Composition_Search_section> Resource_Composition_Search_section { get; set; }

    public DbSet<Resource_ConceptMap> Resource_ConceptMap { get; set; }
    public DbSet<Resource_ConceptMap_Search_context> Resource_ConceptMap_Search_context { get; set; }
    public DbSet<Resource_ConceptMap_Search_dependson> Resource_ConceptMap_Search_dependson { get; set; }
    public DbSet<Resource_ConceptMap_Search_product> Resource_ConceptMap_Search_product { get; set; }
    public DbSet<Resource_ConceptMap_Search_sourcecode> Resource_ConceptMap_Search_sourcecode { get; set; }
    public DbSet<Resource_ConceptMap_Search_sourcesystem> Resource_ConceptMap_Search_sourcesystem { get; set; }
    public DbSet<Resource_ConceptMap_Search_targetcode> Resource_ConceptMap_Search_targetcode { get; set; }
    public DbSet<Resource_ConceptMap_Search_targetsystem> Resource_ConceptMap_Search_targetsystem { get; set; }

    public DbSet<Resource_Condition> Resource_Condition { get; set; }
    public DbSet<Resource_Condition_Search_body_site> Resource_Condition_Search_body_site { get; set; }
    public DbSet<Resource_Condition_Search_evidence> Resource_Condition_Search_evidence { get; set; }
    public DbSet<Resource_Condition_Search_identifier> Resource_Condition_Search_identifier { get; set; }

    public DbSet<Resource_Conformance> Resource_Conformance { get; set; }
    public DbSet<Resource_Conformance_Search_event> Resource_Conformance_Search_event { get; set; }
    public DbSet<Resource_Conformance_Search_format> Resource_Conformance_Search_format { get; set; }
    public DbSet<Resource_Conformance_Search_mode> Resource_Conformance_Search_mode { get; set; }
    public DbSet<Resource_Conformance_Search_profile> Resource_Conformance_Search_profile { get; set; }
    public DbSet<Resource_Conformance_Search_resource> Resource_Conformance_Search_resource { get; set; }
    public DbSet<Resource_Conformance_Search_security> Resource_Conformance_Search_security { get; set; }
    public DbSet<Resource_Conformance_Search_supported_profile> Resource_Conformance_Search_supported_profile { get; set; }

    public DbSet<Resource_Contract> Resource_Contract { get; set; }
    public DbSet<Resource_Contract_Search_actor> Resource_Contract_Search_actor { get; set; }
    public DbSet<Resource_Contract_Search_patient> Resource_Contract_Search_patient { get; set; }
    public DbSet<Resource_Contract_Search_signer> Resource_Contract_Search_signer { get; set; }
    public DbSet<Resource_Contract_Search_subject> Resource_Contract_Search_subject { get; set; }

    public DbSet<Resource_Coverage> Resource_Coverage { get; set; }
    public DbSet<Resource_Coverage_Search_identifier> Resource_Coverage_Search_identifier { get; set; }

    public DbSet<Resource_DataElement> Resource_DataElement { get; set; }
    public DbSet<Resource_DataElement_Search_code> Resource_DataElement_Search_code { get; set; }
    public DbSet<Resource_DataElement_Search_context> Resource_DataElement_Search_context { get; set; }
    public DbSet<Resource_DataElement_Search_description> Resource_DataElement_Search_description { get; set; }
    public DbSet<Resource_DataElement_Search_identifier> Resource_DataElement_Search_identifier { get; set; }

    public DbSet<Resource_DetectedIssue> Resource_DetectedIssue { get; set; }
    public DbSet<Resource_DetectedIssue_Search_implicated> Resource_DetectedIssue_Search_implicated { get; set; }

    public DbSet<Resource_Device> Resource_Device { get; set; }
    public DbSet<Resource_Device_Search_identifier> Resource_Device_Search_identifier { get; set; }

    public DbSet<Resource_DeviceComponent> Resource_DeviceComponent { get; set; }

    public DbSet<Resource_DeviceMetric> Resource_DeviceMetric { get; set; }

    public DbSet<Resource_DeviceUseRequest> Resource_DeviceUseRequest { get; set; }

    public DbSet<Resource_DeviceUseStatement> Resource_DeviceUseStatement { get; set; }

    public DbSet<Resource_DiagnosticOrder> Resource_DiagnosticOrder { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_actor> Resource_DiagnosticOrder_Search_actor { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_bodysite> Resource_DiagnosticOrder_Search_bodysite { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_code> Resource_DiagnosticOrder_Search_code { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_event_date> Resource_DiagnosticOrder_Search_event_date { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_event_status> Resource_DiagnosticOrder_Search_event_status { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_identifier> Resource_DiagnosticOrder_Search_identifier { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_item_date> Resource_DiagnosticOrder_Search_item_date { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_item_past_status> Resource_DiagnosticOrder_Search_item_past_status { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_item_status> Resource_DiagnosticOrder_Search_item_status { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_specimen> Resource_DiagnosticOrder_Search_specimen { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_event_status_date> Resource_DiagnosticOrder_Search_event_status_date { get; set; }
    public DbSet<Resource_DiagnosticOrder_Search_item_status_date> Resource_DiagnosticOrder_Search_item_status_date { get; set; }

    public DbSet<Resource_DiagnosticReport> Resource_DiagnosticReport { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_diagnosis> Resource_DiagnosticReport_Search_diagnosis { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_identifier> Resource_DiagnosticReport_Search_identifier { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_image> Resource_DiagnosticReport_Search_image { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_request> Resource_DiagnosticReport_Search_request { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_result> Resource_DiagnosticReport_Search_result { get; set; }
    public DbSet<Resource_DiagnosticReport_Search_specimen> Resource_DiagnosticReport_Search_specimen { get; set; }

    public DbSet<Resource_DocumentManifest> Resource_DocumentManifest { get; set; }
    public DbSet<Resource_DocumentManifest_Search_author> Resource_DocumentManifest_Search_author { get; set; }
    public DbSet<Resource_DocumentManifest_Search_content_ref> Resource_DocumentManifest_Search_content_ref { get; set; }
    public DbSet<Resource_DocumentManifest_Search_identifier> Resource_DocumentManifest_Search_identifier { get; set; }
    public DbSet<Resource_DocumentManifest_Search_recipient> Resource_DocumentManifest_Search_recipient { get; set; }
    public DbSet<Resource_DocumentManifest_Search_related_id> Resource_DocumentManifest_Search_related_id { get; set; }
    public DbSet<Resource_DocumentManifest_Search_related_ref> Resource_DocumentManifest_Search_related_ref { get; set; }

    public DbSet<Resource_DocumentReference> Resource_DocumentReference { get; set; }
    public DbSet<Resource_DocumentReference_Search_author> Resource_DocumentReference_Search_author { get; set; }
    public DbSet<Resource_DocumentReference_Search_event> Resource_DocumentReference_Search_event { get; set; }
    public DbSet<Resource_DocumentReference_Search_format> Resource_DocumentReference_Search_format { get; set; }
    public DbSet<Resource_DocumentReference_Search_identifier> Resource_DocumentReference_Search_identifier { get; set; }
    public DbSet<Resource_DocumentReference_Search_language> Resource_DocumentReference_Search_language { get; set; }
    public DbSet<Resource_DocumentReference_Search_location> Resource_DocumentReference_Search_location { get; set; }
    public DbSet<Resource_DocumentReference_Search_related_id> Resource_DocumentReference_Search_related_id { get; set; }
    public DbSet<Resource_DocumentReference_Search_related_ref> Resource_DocumentReference_Search_related_ref { get; set; }
    public DbSet<Resource_DocumentReference_Search_relatesto> Resource_DocumentReference_Search_relatesto { get; set; }
    public DbSet<Resource_DocumentReference_Search_relation> Resource_DocumentReference_Search_relation { get; set; }
    public DbSet<Resource_DocumentReference_Search_securitylabel> Resource_DocumentReference_Search_securitylabel { get; set; }
    public DbSet<Resource_DocumentReference_Search_relationship> Resource_DocumentReference_Search_relationship { get; set; }

    public DbSet<Resource_EligibilityRequest> Resource_EligibilityRequest { get; set; }
    public DbSet<Resource_EligibilityRequest_Search_identifier> Resource_EligibilityRequest_Search_identifier { get; set; }

    public DbSet<Resource_EligibilityResponse> Resource_EligibilityResponse { get; set; }
    public DbSet<Resource_EligibilityResponse_Search_identifier> Resource_EligibilityResponse_Search_identifier { get; set; }

    public DbSet<Resource_Encounter> Resource_Encounter { get; set; }
    public DbSet<Resource_Encounter_Search_condition> Resource_Encounter_Search_condition { get; set; }
    public DbSet<Resource_Encounter_Search_episodeofcare> Resource_Encounter_Search_episodeofcare { get; set; }
    public DbSet<Resource_Encounter_Search_identifier> Resource_Encounter_Search_identifier { get; set; }
    public DbSet<Resource_Encounter_Search_incomingreferral> Resource_Encounter_Search_incomingreferral { get; set; }
    public DbSet<Resource_Encounter_Search_indication> Resource_Encounter_Search_indication { get; set; }
    public DbSet<Resource_Encounter_Search_location> Resource_Encounter_Search_location { get; set; }
    public DbSet<Resource_Encounter_Search_location_period> Resource_Encounter_Search_location_period { get; set; }
    public DbSet<Resource_Encounter_Search_participant> Resource_Encounter_Search_participant { get; set; }
    public DbSet<Resource_Encounter_Search_participant_type> Resource_Encounter_Search_participant_type { get; set; }
    public DbSet<Resource_Encounter_Search_practitioner> Resource_Encounter_Search_practitioner { get; set; }
    public DbSet<Resource_Encounter_Search_procedure> Resource_Encounter_Search_procedure { get; set; }
    public DbSet<Resource_Encounter_Search_reason> Resource_Encounter_Search_reason { get; set; }
    public DbSet<Resource_Encounter_Search_special_arrangement> Resource_Encounter_Search_special_arrangement { get; set; }
    public DbSet<Resource_Encounter_Search_type> Resource_Encounter_Search_type { get; set; }

    public DbSet<Resource_EnrollmentRequest> Resource_EnrollmentRequest { get; set; }
    public DbSet<Resource_EnrollmentRequest_Search_identifier> Resource_EnrollmentRequest_Search_identifier { get; set; }

    public DbSet<Resource_EnrollmentResponse> Resource_EnrollmentResponse { get; set; }
    public DbSet<Resource_EnrollmentResponse_Search_identifier> Resource_EnrollmentResponse_Search_identifier { get; set; }

    public DbSet<Resource_EpisodeOfCare> Resource_EpisodeOfCare { get; set; }
    public DbSet<Resource_EpisodeOfCare_Search_condition> Resource_EpisodeOfCare_Search_condition { get; set; }
    public DbSet<Resource_EpisodeOfCare_Search_identifier> Resource_EpisodeOfCare_Search_identifier { get; set; }
    public DbSet<Resource_EpisodeOfCare_Search_incomingreferral> Resource_EpisodeOfCare_Search_incomingreferral { get; set; }
    public DbSet<Resource_EpisodeOfCare_Search_team_member> Resource_EpisodeOfCare_Search_team_member { get; set; }
    public DbSet<Resource_EpisodeOfCare_Search_type> Resource_EpisodeOfCare_Search_type { get; set; }

    public DbSet<Resource_ExplanationOfBenefit> Resource_ExplanationOfBenefit { get; set; }
    public DbSet<Resource_ExplanationOfBenefit_Search_identifier> Resource_ExplanationOfBenefit_Search_identifier { get; set; }

    public DbSet<Resource_FamilyMemberHistory> Resource_FamilyMemberHistory { get; set; }
    public DbSet<Resource_FamilyMemberHistory_Search_code> Resource_FamilyMemberHistory_Search_code { get; set; }
    public DbSet<Resource_FamilyMemberHistory_Search_identifier> Resource_FamilyMemberHistory_Search_identifier { get; set; }

    public DbSet<Resource_Flag> Resource_Flag { get; set; }

    public DbSet<Resource_Goal> Resource_Goal { get; set; }
    public DbSet<Resource_Goal_Search_category> Resource_Goal_Search_category { get; set; }
    public DbSet<Resource_Goal_Search_identifier> Resource_Goal_Search_identifier { get; set; }

    public DbSet<Resource_Group> Resource_Group { get; set; }
    public DbSet<Resource_Group_Search_characteristic> Resource_Group_Search_characteristic { get; set; }
    public DbSet<Resource_Group_Search_exclude> Resource_Group_Search_exclude { get; set; }
    public DbSet<Resource_Group_Search_identifier> Resource_Group_Search_identifier { get; set; }
    public DbSet<Resource_Group_Search_member> Resource_Group_Search_member { get; set; }
    public DbSet<Resource_Group_Search_value> Resource_Group_Search_value { get; set; }
    public DbSet<Resource_Group_Search_characteristic_value> Resource_Group_Search_characteristic_value { get; set; }

    public DbSet<Resource_HealthcareService> Resource_HealthcareService { get; set; }
    public DbSet<Resource_HealthcareService_Search_characteristic> Resource_HealthcareService_Search_characteristic { get; set; }
    public DbSet<Resource_HealthcareService_Search_identifier> Resource_HealthcareService_Search_identifier { get; set; }
    public DbSet<Resource_HealthcareService_Search_programname> Resource_HealthcareService_Search_programname { get; set; }
    public DbSet<Resource_HealthcareService_Search_servicetype> Resource_HealthcareService_Search_servicetype { get; set; }

    public DbSet<Resource_ImagingObjectSelection> Resource_ImagingObjectSelection { get; set; }
    public DbSet<Resource_ImagingObjectSelection_Search_selected_study> Resource_ImagingObjectSelection_Search_selected_study { get; set; }

    public DbSet<Resource_ImagingStudy> Resource_ImagingStudy { get; set; }
    public DbSet<Resource_ImagingStudy_Search_bodysite> Resource_ImagingStudy_Search_bodysite { get; set; }
    public DbSet<Resource_ImagingStudy_Search_dicom_class> Resource_ImagingStudy_Search_dicom_class { get; set; }
    public DbSet<Resource_ImagingStudy_Search_modality> Resource_ImagingStudy_Search_modality { get; set; }
    public DbSet<Resource_ImagingStudy_Search_order> Resource_ImagingStudy_Search_order { get; set; }
    public DbSet<Resource_ImagingStudy_Search_series> Resource_ImagingStudy_Search_series { get; set; }
    public DbSet<Resource_ImagingStudy_Search_uid> Resource_ImagingStudy_Search_uid { get; set; }

    public DbSet<Resource_Immunization> Resource_Immunization { get; set; }
    public DbSet<Resource_Immunization_Search_dose_sequence> Resource_Immunization_Search_dose_sequence { get; set; }
    public DbSet<Resource_Immunization_Search_identifier> Resource_Immunization_Search_identifier { get; set; }
    public DbSet<Resource_Immunization_Search_reaction> Resource_Immunization_Search_reaction { get; set; }
    public DbSet<Resource_Immunization_Search_reaction_date> Resource_Immunization_Search_reaction_date { get; set; }
    public DbSet<Resource_Immunization_Search_reason> Resource_Immunization_Search_reason { get; set; }
    public DbSet<Resource_Immunization_Search_reason_not_given> Resource_Immunization_Search_reason_not_given { get; set; }

    public DbSet<Resource_ImmunizationRecommendation> Resource_ImmunizationRecommendation { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_date> Resource_ImmunizationRecommendation_Search_date { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_dose_number> Resource_ImmunizationRecommendation_Search_dose_number { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_dose_sequence> Resource_ImmunizationRecommendation_Search_dose_sequence { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_identifier> Resource_ImmunizationRecommendation_Search_identifier { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_information> Resource_ImmunizationRecommendation_Search_information { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_status> Resource_ImmunizationRecommendation_Search_status { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_support> Resource_ImmunizationRecommendation_Search_support { get; set; }
    public DbSet<Resource_ImmunizationRecommendation_Search_vaccine_type> Resource_ImmunizationRecommendation_Search_vaccine_type { get; set; }

    public DbSet<Resource_ImplementationGuide> Resource_ImplementationGuide { get; set; }
    public DbSet<Resource_ImplementationGuide_Search_context> Resource_ImplementationGuide_Search_context { get; set; }
    public DbSet<Resource_ImplementationGuide_Search_dependency> Resource_ImplementationGuide_Search_dependency { get; set; }

    public DbSet<Resource_List> Resource_List { get; set; }
    public DbSet<Resource_List_Search_item> Resource_List_Search_item { get; set; }

    public DbSet<Resource_Location> Resource_Location { get; set; }
    public DbSet<Resource_Location_Search_identifier> Resource_Location_Search_identifier { get; set; }

    public DbSet<Resource_Media> Resource_Media { get; set; }
    public DbSet<Resource_Media_Search_identifier> Resource_Media_Search_identifier { get; set; }

    public DbSet<Resource_Medication> Resource_Medication { get; set; }
    public DbSet<Resource_Medication_Search_content> Resource_Medication_Search_content { get; set; }
    public DbSet<Resource_Medication_Search_ingredient> Resource_Medication_Search_ingredient { get; set; }

    public DbSet<Resource_MedicationAdministration> Resource_MedicationAdministration { get; set; }
    public DbSet<Resource_MedicationAdministration_Search_device> Resource_MedicationAdministration_Search_device { get; set; }
    public DbSet<Resource_MedicationAdministration_Search_identifier> Resource_MedicationAdministration_Search_identifier { get; set; }

    public DbSet<Resource_MedicationDispense> Resource_MedicationDispense { get; set; }
    public DbSet<Resource_MedicationDispense_Search_prescription> Resource_MedicationDispense_Search_prescription { get; set; }
    public DbSet<Resource_MedicationDispense_Search_receiver> Resource_MedicationDispense_Search_receiver { get; set; }
    public DbSet<Resource_MedicationDispense_Search_responsibleparty> Resource_MedicationDispense_Search_responsibleparty { get; set; }

    public DbSet<Resource_MedicationOrder> Resource_MedicationOrder { get; set; }
    public DbSet<Resource_MedicationOrder_Search_identifier> Resource_MedicationOrder_Search_identifier { get; set; }

    public DbSet<Resource_MedicationStatement> Resource_MedicationStatement { get; set; }
    public DbSet<Resource_MedicationStatement_Search_identifier> Resource_MedicationStatement_Search_identifier { get; set; }

    public DbSet<Resource_MessageHeader> Resource_MessageHeader { get; set; }
    public DbSet<Resource_MessageHeader_Search_data> Resource_MessageHeader_Search_data { get; set; }
    public DbSet<Resource_MessageHeader_Search_destination> Resource_MessageHeader_Search_destination { get; set; }
    public DbSet<Resource_MessageHeader_Search_destination_uri> Resource_MessageHeader_Search_destination_uri { get; set; }
    public DbSet<Resource_MessageHeader_Search_target> Resource_MessageHeader_Search_target { get; set; }

    public DbSet<Resource_NamingSystem> Resource_NamingSystem { get; set; }
    public DbSet<Resource_NamingSystem_Search_contact> Resource_NamingSystem_Search_contact { get; set; }
    public DbSet<Resource_NamingSystem_Search_context> Resource_NamingSystem_Search_context { get; set; }
    public DbSet<Resource_NamingSystem_Search_id_type> Resource_NamingSystem_Search_id_type { get; set; }
    public DbSet<Resource_NamingSystem_Search_period> Resource_NamingSystem_Search_period { get; set; }
    public DbSet<Resource_NamingSystem_Search_telecom> Resource_NamingSystem_Search_telecom { get; set; }
    public DbSet<Resource_NamingSystem_Search_value> Resource_NamingSystem_Search_value { get; set; }

    public DbSet<Resource_NutritionOrder> Resource_NutritionOrder { get; set; }
    public DbSet<Resource_NutritionOrder_Search_identifier> Resource_NutritionOrder_Search_identifier { get; set; }
    public DbSet<Resource_NutritionOrder_Search_oraldiet> Resource_NutritionOrder_Search_oraldiet { get; set; }
    public DbSet<Resource_NutritionOrder_Search_supplement> Resource_NutritionOrder_Search_supplement { get; set; }

    public DbSet<Resource_Observation> Resource_Observation { get; set; }
    public DbSet<Resource_Observation_Search_component_code> Resource_Observation_Search_component_code { get; set; }
    public DbSet<Resource_Observation_Search_component_data_absent_reason> Resource_Observation_Search_component_data_absent_reason { get; set; }
    public DbSet<Resource_Observation_Search_component_value_concept> Resource_Observation_Search_component_value_concept { get; set; }
    public DbSet<Resource_Observation_Search_component_value_quantity> Resource_Observation_Search_component_value_quantity { get; set; }
    public DbSet<Resource_Observation_Search_component_value_string> Resource_Observation_Search_component_value_string { get; set; }
    public DbSet<Resource_Observation_Search_identifier> Resource_Observation_Search_identifier { get; set; }
    public DbSet<Resource_Observation_Search_performer> Resource_Observation_Search_performer { get; set; }
    public DbSet<Resource_Observation_Search_related_target> Resource_Observation_Search_related_target { get; set; }
    public DbSet<Resource_Observation_Search_related_type> Resource_Observation_Search_related_type { get; set; }
    public DbSet<Resource_Observation_Search_code_value> Resource_Observation_Search_code_value { get; set; }
    public DbSet<Resource_Observation_Search_component_code_value> Resource_Observation_Search_component_code_value { get; set; }
    public DbSet<Resource_Observation_Search_related> Resource_Observation_Search_related { get; set; }

    public DbSet<Resource_OperationDefinition> Resource_OperationDefinition { get; set; }
    public DbSet<Resource_OperationDefinition_Search_profile> Resource_OperationDefinition_Search_profile { get; set; }
    public DbSet<Resource_OperationDefinition_Search_type> Resource_OperationDefinition_Search_type { get; set; }

    public DbSet<Resource_OperationOutcome> Resource_OperationOutcome { get; set; }

    public DbSet<Resource_Order> Resource_Order { get; set; }
    public DbSet<Resource_Order_Search_detail> Resource_Order_Search_detail { get; set; }
    public DbSet<Resource_Order_Search_identifier> Resource_Order_Search_identifier { get; set; }

    public DbSet<Resource_OrderResponse> Resource_OrderResponse { get; set; }
    public DbSet<Resource_OrderResponse_Search_fulfillment> Resource_OrderResponse_Search_fulfillment { get; set; }
    public DbSet<Resource_OrderResponse_Search_identifier> Resource_OrderResponse_Search_identifier { get; set; }

    public DbSet<Resource_Organization> Resource_Organization { get; set; }
    public DbSet<Resource_Organization_Search_address> Resource_Organization_Search_address { get; set; }
    public DbSet<Resource_Organization_Search_address_city> Resource_Organization_Search_address_city { get; set; }
    public DbSet<Resource_Organization_Search_address_country> Resource_Organization_Search_address_country { get; set; }
    public DbSet<Resource_Organization_Search_address_postalcode> Resource_Organization_Search_address_postalcode { get; set; }
    public DbSet<Resource_Organization_Search_address_state> Resource_Organization_Search_address_state { get; set; }
    public DbSet<Resource_Organization_Search_address_use> Resource_Organization_Search_address_use { get; set; }
    public DbSet<Resource_Organization_Search_identifier> Resource_Organization_Search_identifier { get; set; }

    public DbSet<Resource_Parameters> Resource_Parameters { get; set; }

    public DbSet<Resource_Patient> Resource_Patient { get; set; }
    public DbSet<Resource_Patient_Search_address> Resource_Patient_Search_address { get; set; }
    public DbSet<Resource_Patient_Search_address_city> Resource_Patient_Search_address_city { get; set; }
    public DbSet<Resource_Patient_Search_address_country> Resource_Patient_Search_address_country { get; set; }
    public DbSet<Resource_Patient_Search_address_postalcode> Resource_Patient_Search_address_postalcode { get; set; }
    public DbSet<Resource_Patient_Search_address_state> Resource_Patient_Search_address_state { get; set; }
    public DbSet<Resource_Patient_Search_address_use> Resource_Patient_Search_address_use { get; set; }
    public DbSet<Resource_Patient_Search_careprovider> Resource_Patient_Search_careprovider { get; set; }
    public DbSet<Resource_Patient_Search_family> Resource_Patient_Search_family { get; set; }
    public DbSet<Resource_Patient_Search_given> Resource_Patient_Search_given { get; set; }
    public DbSet<Resource_Patient_Search_identifier> Resource_Patient_Search_identifier { get; set; }
    public DbSet<Resource_Patient_Search_language> Resource_Patient_Search_language { get; set; }
    public DbSet<Resource_Patient_Search_link> Resource_Patient_Search_link { get; set; }
    public DbSet<Resource_Patient_Search_name> Resource_Patient_Search_name { get; set; }
    public DbSet<Resource_Patient_Search_phonetic> Resource_Patient_Search_phonetic { get; set; }
    public DbSet<Resource_Patient_Search_telecom> Resource_Patient_Search_telecom { get; set; }

    public DbSet<Resource_PaymentNotice> Resource_PaymentNotice { get; set; }
    public DbSet<Resource_PaymentNotice_Search_identifier> Resource_PaymentNotice_Search_identifier { get; set; }

    public DbSet<Resource_PaymentReconciliation> Resource_PaymentReconciliation { get; set; }
    public DbSet<Resource_PaymentReconciliation_Search_identifier> Resource_PaymentReconciliation_Search_identifier { get; set; }

    public DbSet<Resource_Person> Resource_Person { get; set; }
    public DbSet<Resource_Person_Search_address> Resource_Person_Search_address { get; set; }
    public DbSet<Resource_Person_Search_address_city> Resource_Person_Search_address_city { get; set; }
    public DbSet<Resource_Person_Search_address_country> Resource_Person_Search_address_country { get; set; }
    public DbSet<Resource_Person_Search_address_postalcode> Resource_Person_Search_address_postalcode { get; set; }
    public DbSet<Resource_Person_Search_address_state> Resource_Person_Search_address_state { get; set; }
    public DbSet<Resource_Person_Search_address_use> Resource_Person_Search_address_use { get; set; }
    public DbSet<Resource_Person_Search_identifier> Resource_Person_Search_identifier { get; set; }
    public DbSet<Resource_Person_Search_link> Resource_Person_Search_link { get; set; }
    public DbSet<Resource_Person_Search_name> Resource_Person_Search_name { get; set; }
    public DbSet<Resource_Person_Search_patient> Resource_Person_Search_patient { get; set; }
    public DbSet<Resource_Person_Search_phonetic> Resource_Person_Search_phonetic { get; set; }
    public DbSet<Resource_Person_Search_practitioner> Resource_Person_Search_practitioner { get; set; }
    public DbSet<Resource_Person_Search_relatedperson> Resource_Person_Search_relatedperson { get; set; }
    public DbSet<Resource_Person_Search_telecom> Resource_Person_Search_telecom { get; set; }

    public DbSet<Resource_Practitioner> Resource_Practitioner { get; set; }
    public DbSet<Resource_Practitioner_Search_address> Resource_Practitioner_Search_address { get; set; }
    public DbSet<Resource_Practitioner_Search_address_city> Resource_Practitioner_Search_address_city { get; set; }
    public DbSet<Resource_Practitioner_Search_address_country> Resource_Practitioner_Search_address_country { get; set; }
    public DbSet<Resource_Practitioner_Search_address_postalcode> Resource_Practitioner_Search_address_postalcode { get; set; }
    public DbSet<Resource_Practitioner_Search_address_state> Resource_Practitioner_Search_address_state { get; set; }
    public DbSet<Resource_Practitioner_Search_address_use> Resource_Practitioner_Search_address_use { get; set; }
    public DbSet<Resource_Practitioner_Search_communication> Resource_Practitioner_Search_communication { get; set; }
    public DbSet<Resource_Practitioner_Search_family> Resource_Practitioner_Search_family { get; set; }
    public DbSet<Resource_Practitioner_Search_given> Resource_Practitioner_Search_given { get; set; }
    public DbSet<Resource_Practitioner_Search_identifier> Resource_Practitioner_Search_identifier { get; set; }
    public DbSet<Resource_Practitioner_Search_location> Resource_Practitioner_Search_location { get; set; }
    public DbSet<Resource_Practitioner_Search_organization> Resource_Practitioner_Search_organization { get; set; }
    public DbSet<Resource_Practitioner_Search_role> Resource_Practitioner_Search_role { get; set; }
    public DbSet<Resource_Practitioner_Search_specialty> Resource_Practitioner_Search_specialty { get; set; }
    public DbSet<Resource_Practitioner_Search_telecom> Resource_Practitioner_Search_telecom { get; set; }

    public DbSet<Resource_Procedure> Resource_Procedure { get; set; }
    public DbSet<Resource_Procedure_Search_identifier> Resource_Procedure_Search_identifier { get; set; }
    public DbSet<Resource_Procedure_Search_performer> Resource_Procedure_Search_performer { get; set; }

    public DbSet<Resource_ProcedureRequest> Resource_ProcedureRequest { get; set; }
    public DbSet<Resource_ProcedureRequest_Search_identifier> Resource_ProcedureRequest_Search_identifier { get; set; }

    public DbSet<Resource_ProcessRequest> Resource_ProcessRequest { get; set; }
    public DbSet<Resource_ProcessRequest_Search_identifier> Resource_ProcessRequest_Search_identifier { get; set; }

    public DbSet<Resource_ProcessResponse> Resource_ProcessResponse { get; set; }
    public DbSet<Resource_ProcessResponse_Search_identifier> Resource_ProcessResponse_Search_identifier { get; set; }

    public DbSet<Resource_Provenance> Resource_Provenance { get; set; }
    public DbSet<Resource_Provenance_Search_agent> Resource_Provenance_Search_agent { get; set; }
    public DbSet<Resource_Provenance_Search_entity> Resource_Provenance_Search_entity { get; set; }
    public DbSet<Resource_Provenance_Search_entitytype> Resource_Provenance_Search_entitytype { get; set; }
    public DbSet<Resource_Provenance_Search_patient> Resource_Provenance_Search_patient { get; set; }
    public DbSet<Resource_Provenance_Search_sigtype> Resource_Provenance_Search_sigtype { get; set; }
    public DbSet<Resource_Provenance_Search_target> Resource_Provenance_Search_target { get; set; }
    public DbSet<Resource_Provenance_Search_userid> Resource_Provenance_Search_userid { get; set; }

    public DbSet<Resource_Questionnaire> Resource_Questionnaire { get; set; }
    public DbSet<Resource_Questionnaire_Search_code> Resource_Questionnaire_Search_code { get; set; }
    public DbSet<Resource_Questionnaire_Search_identifier> Resource_Questionnaire_Search_identifier { get; set; }

    public DbSet<Resource_QuestionnaireResponse> Resource_QuestionnaireResponse { get; set; }

    public DbSet<Resource_ReferralRequest> Resource_ReferralRequest { get; set; }
    public DbSet<Resource_ReferralRequest_Search_recipient> Resource_ReferralRequest_Search_recipient { get; set; }

    public DbSet<Resource_RelatedPerson> Resource_RelatedPerson { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address> Resource_RelatedPerson_Search_address { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address_city> Resource_RelatedPerson_Search_address_city { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address_country> Resource_RelatedPerson_Search_address_country { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address_postalcode> Resource_RelatedPerson_Search_address_postalcode { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address_state> Resource_RelatedPerson_Search_address_state { get; set; }
    public DbSet<Resource_RelatedPerson_Search_address_use> Resource_RelatedPerson_Search_address_use { get; set; }
    public DbSet<Resource_RelatedPerson_Search_identifier> Resource_RelatedPerson_Search_identifier { get; set; }
    public DbSet<Resource_RelatedPerson_Search_telecom> Resource_RelatedPerson_Search_telecom { get; set; }

    public DbSet<Resource_RiskAssessment> Resource_RiskAssessment { get; set; }

    public DbSet<Resource_Schedule> Resource_Schedule { get; set; }
    public DbSet<Resource_Schedule_Search_identifier> Resource_Schedule_Search_identifier { get; set; }
    public DbSet<Resource_Schedule_Search_type> Resource_Schedule_Search_type { get; set; }

    public DbSet<Resource_SearchParameter> Resource_SearchParameter { get; set; }
    public DbSet<Resource_SearchParameter_Search_target> Resource_SearchParameter_Search_target { get; set; }

    public DbSet<Resource_Slot> Resource_Slot { get; set; }
    public DbSet<Resource_Slot_Search_identifier> Resource_Slot_Search_identifier { get; set; }

    public DbSet<Resource_Specimen> Resource_Specimen { get; set; }
    public DbSet<Resource_Specimen_Search_container> Resource_Specimen_Search_container { get; set; }
    public DbSet<Resource_Specimen_Search_container_id> Resource_Specimen_Search_container_id { get; set; }
    public DbSet<Resource_Specimen_Search_identifier> Resource_Specimen_Search_identifier { get; set; }
    public DbSet<Resource_Specimen_Search_parent> Resource_Specimen_Search_parent { get; set; }

    public DbSet<Resource_StructureDefinition> Resource_StructureDefinition { get; set; }
    public DbSet<Resource_StructureDefinition_Search_base_path> Resource_StructureDefinition_Search_base_path { get; set; }
    public DbSet<Resource_StructureDefinition_Search_code> Resource_StructureDefinition_Search_code { get; set; }
    public DbSet<Resource_StructureDefinition_Search_context> Resource_StructureDefinition_Search_context { get; set; }
    public DbSet<Resource_StructureDefinition_Search_ext_context> Resource_StructureDefinition_Search_ext_context { get; set; }
    public DbSet<Resource_StructureDefinition_Search_identifier> Resource_StructureDefinition_Search_identifier { get; set; }
    public DbSet<Resource_StructureDefinition_Search_path> Resource_StructureDefinition_Search_path { get; set; }
    public DbSet<Resource_StructureDefinition_Search_valueset> Resource_StructureDefinition_Search_valueset { get; set; }

    public DbSet<Resource_Subscription> Resource_Subscription { get; set; }
    public DbSet<Resource_Subscription_Search_contact> Resource_Subscription_Search_contact { get; set; }
    public DbSet<Resource_Subscription_Search_tag> Resource_Subscription_Search_tag { get; set; }

    public DbSet<Resource_Substance> Resource_Substance { get; set; }
    public DbSet<Resource_Substance_Search_category> Resource_Substance_Search_category { get; set; }
    public DbSet<Resource_Substance_Search_container_identifier> Resource_Substance_Search_container_identifier { get; set; }
    public DbSet<Resource_Substance_Search_expiry> Resource_Substance_Search_expiry { get; set; }
    public DbSet<Resource_Substance_Search_identifier> Resource_Substance_Search_identifier { get; set; }
    public DbSet<Resource_Substance_Search_quantity> Resource_Substance_Search_quantity { get; set; }
    public DbSet<Resource_Substance_Search_substance> Resource_Substance_Search_substance { get; set; }

    public DbSet<Resource_SupplyDelivery> Resource_SupplyDelivery { get; set; }
    public DbSet<Resource_SupplyDelivery_Search_receiver> Resource_SupplyDelivery_Search_receiver { get; set; }

    public DbSet<Resource_SupplyRequest> Resource_SupplyRequest { get; set; }
    public DbSet<Resource_SupplyRequest_Search_supplier> Resource_SupplyRequest_Search_supplier { get; set; }

    public DbSet<Resource_TestScript> Resource_TestScript { get; set; }
    public DbSet<Resource_TestScript_Search_testscript_capability> Resource_TestScript_Search_testscript_capability { get; set; }
    public DbSet<Resource_TestScript_Search_testscript_setup_capability> Resource_TestScript_Search_testscript_setup_capability { get; set; }
    public DbSet<Resource_TestScript_Search_testscript_test_capability> Resource_TestScript_Search_testscript_test_capability { get; set; }

    public DbSet<Resource_ValueSet> Resource_ValueSet { get; set; }
    public DbSet<Resource_ValueSet_Search_code> Resource_ValueSet_Search_code { get; set; }
    public DbSet<Resource_ValueSet_Search_context> Resource_ValueSet_Search_context { get; set; }
    public DbSet<Resource_ValueSet_Search_reference> Resource_ValueSet_Search_reference { get; set; }

    public DbSet<Resource_VisionPrescription> Resource_VisionPrescription { get; set; }
    public DbSet<Resource_VisionPrescription_Search_identifier> Resource_VisionPrescription_Search_identifier { get; set; }


    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      Mb.Conventions.Remove<PluralizingTableNameConvention>();

      //Account Resource
      Mb.Entity<Resource_Account>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Account>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Account>().Property(x => x.balance_Quantity).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.balance_System).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.balance_Code).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.owner_FhirId).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.owner_Type).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.owner_Url).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.period_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Account>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Account>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Account_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Account_Search_identifier>().HasRequired(x => x.Resource_Account);
      Mb.Entity<Resource_Account_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Account_Search_identifier>().Property(x => x.System).IsOptional();

      //AllergyIntolerance Resource
      Mb.Entity<Resource_AllergyIntolerance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.criticality_Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.criticality_System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.last_date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.recorder_FhirId).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.recorder_Type).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.recorder_Url).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.reporter_FhirId).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.reporter_Type).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.reporter_Url).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.substance_Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.substance_System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_identifier>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance_Search_manifestation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_manifestation>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_manifestation>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_manifestation>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance_Search_onset>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_onset>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_onset>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_route>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_route>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_route>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_route>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance_Search_severity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_severity>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_severity>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_severity>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AllergyIntolerance_Search_substance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_substance>().HasRequired(x => x.Resource_AllergyIntolerance);
      Mb.Entity<Resource_AllergyIntolerance_Search_substance>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AllergyIntolerance_Search_substance>().Property(x => x.System).IsOptional();

      //Appointment Resource
      Mb.Entity<Resource_Appointment>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Appointment>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Appointment>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Appointment>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Appointment>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Appointment>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Appointment_Search_actor>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_actor>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_actor>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Appointment_Search_actor>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Appointment_Search_actor>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Appointment_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_identifier>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Appointment_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Appointment_Search_location>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_location>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_location>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Appointment_Search_location>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Appointment_Search_location>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Appointment_Search_part_status>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_part_status>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_part_status>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Appointment_Search_part_status>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Appointment_Search_patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_patient>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_patient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Appointment_Search_patient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Appointment_Search_patient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Appointment_Search_practitioner>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Appointment_Search_practitioner>().HasRequired(x => x.Resource_Appointment);
      Mb.Entity<Resource_Appointment_Search_practitioner>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Appointment_Search_practitioner>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Appointment_Search_practitioner>().Property(x => x.Url).IsOptional();

      //AppointmentResponse Resource
      Mb.Entity<Resource_AppointmentResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.actor_FhirId).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.actor_Type).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.actor_Url).IsOptional();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.appointment_FhirId).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.appointment_Type).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.appointment_Url).IsOptional();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.part_status_Code).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.part_status_System).IsOptional();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.practitioner_FhirId).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.practitioner_Type).IsRequired();
      Mb.Entity<Resource_AppointmentResponse>().Property(x => x.practitioner_Url).IsOptional();
      Mb.Entity<Resource_AppointmentResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AppointmentResponse_Search_identifier>().HasRequired(x => x.Resource_AppointmentResponse);
      Mb.Entity<Resource_AppointmentResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AppointmentResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //AuditEvent Resource
      Mb.Entity<Resource_AuditEvent>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_AuditEvent>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_AuditEvent>().Property(x => x.action_Code).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.action_System).IsOptional();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.site_Code).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.site_System).IsOptional();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.source_Code).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.source_System).IsOptional();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_AuditEvent>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_address>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_address>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_address>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_altid>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_altid>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_altid>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_altid>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_desc>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_desc>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_desc>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_identity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_identity>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_identity>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_identity>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_name>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_name>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_name>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_object_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_object_type>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_object_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_object_type>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_participant>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_participant>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_participant>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_participant>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_participant>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_patient>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_patient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_patient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_patient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_policy>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_policy>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_policy>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_reference>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_reference>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_reference>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_reference>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_reference>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_subtype>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_subtype>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_subtype>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_subtype>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_AuditEvent_Search_user>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_user>().HasRequired(x => x.Resource_AuditEvent);
      Mb.Entity<Resource_AuditEvent_Search_user>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_AuditEvent_Search_user>().Property(x => x.System).IsOptional();

      //Basic Resource
      Mb.Entity<Resource_Basic>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Basic>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Basic>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_Basic>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Basic>().Property(x => x.created_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Basic>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Basic>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Basic_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Basic_Search_identifier>().HasRequired(x => x.Resource_Basic);
      Mb.Entity<Resource_Basic_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Basic_Search_identifier>().Property(x => x.System).IsOptional();

      //Binary Resource
      Mb.Entity<Resource_Binary>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Binary>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Binary>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Binary>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Binary>().Property(x => x.contenttype_Code).IsRequired();
      Mb.Entity<Resource_Binary>().Property(x => x.contenttype_System).IsOptional();

      //BodySite Resource
      Mb.Entity<Resource_BodySite>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_BodySite>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_BodySite>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_BodySite>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_BodySite>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_BodySite>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_BodySite>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_BodySite>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_BodySite>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_BodySite_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_BodySite_Search_identifier>().HasRequired(x => x.Resource_BodySite);
      Mb.Entity<Resource_BodySite_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_BodySite_Search_identifier>().Property(x => x.System).IsOptional();

      //Bundle Resource
      Mb.Entity<Resource_Bundle>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Bundle>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Bundle>().Property(x => x.composition_FhirId).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.composition_Type).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.composition_Url).IsOptional();
      Mb.Entity<Resource_Bundle>().Property(x => x.message_FhirId).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.message_Type).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.message_Url).IsOptional();
      Mb.Entity<Resource_Bundle>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Bundle>().Property(x => x.type_System).IsOptional();

      //CarePlan Resource
      Mb.Entity<Resource_CarePlan>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_CarePlan>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_CarePlan>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_CarePlan>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_CarePlan>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_activitycode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activitycode>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_activitycode>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activitycode>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_activitydate>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activitydate>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_activitydate>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activityreference>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activityreference>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_activityreference>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activityreference>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_activityreference>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_condition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_condition>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_condition>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_condition>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_condition>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_goal>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_goal>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_goal>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_goal>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_goal>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_participant>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_participant>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_participant>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_participant>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_participant>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_performer>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_performer>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_performer>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_performer>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_performer>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_relatedcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_relatedcode>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_relatedcode>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_relatedcode>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_relatedplan>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_relatedplan>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_relatedplan>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_relatedplan>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_relatedplan>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_related>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_related>().HasRequired(x => x.Resource_CarePlan);
      Mb.Entity<Resource_CarePlan_Search_related>().Property(x => x.relatedcodeCode).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_related>().Property(x => x.relatedcodeSystem).IsOptional();
      Mb.Entity<Resource_CarePlan_Search_related>().Property(x => x.relatedplanFhirId).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_related>().Property(x => x.relatedplanType).IsRequired();
      Mb.Entity<Resource_CarePlan_Search_related>().Property(x => x.relatedplanUrl).IsOptional();

      //Claim Resource
      Mb.Entity<Resource_Claim>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Claim>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Claim>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Claim>().Property(x => x.priority_Code).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.priority_System).IsOptional();
      Mb.Entity<Resource_Claim>().Property(x => x.provider_FhirId).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.provider_Type).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.provider_Url).IsOptional();
      Mb.Entity<Resource_Claim>().Property(x => x.use_Code).IsRequired();
      Mb.Entity<Resource_Claim>().Property(x => x.use_System).IsOptional();
      Mb.Entity<Resource_Claim_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Claim_Search_identifier>().HasRequired(x => x.Resource_Claim);
      Mb.Entity<Resource_Claim_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Claim_Search_identifier>().Property(x => x.System).IsOptional();

      //ClaimResponse Resource
      Mb.Entity<Resource_ClaimResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClaimResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ClaimResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ClaimResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ClaimResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClaimResponse_Search_identifier>().HasRequired(x => x.Resource_ClaimResponse);
      Mb.Entity<Resource_ClaimResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ClaimResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //ClinicalImpression Resource
      Mb.Entity<Resource_ClinicalImpression>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.assessor_FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.assessor_Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.assessor_Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.previous_FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.previous_Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.previous_Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.trigger_FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.trigger_Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.trigger_Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.trigger_code_Code).IsRequired();
      Mb.Entity<Resource_ClinicalImpression>().Property(x => x.trigger_code_System).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_action>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_action>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_action>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_action>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_action>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_finding>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_finding>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_finding>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_finding>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_investigation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_investigation>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_investigation>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_investigation>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_investigation>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_plan>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_plan>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_plan>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_plan>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_plan>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_problem>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_problem>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_problem>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_problem>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_problem>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_resolved>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_resolved>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_resolved>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_resolved>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ClinicalImpression_Search_ruledout>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_ruledout>().HasRequired(x => x.Resource_ClinicalImpression);
      Mb.Entity<Resource_ClinicalImpression_Search_ruledout>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ClinicalImpression_Search_ruledout>().Property(x => x.System).IsOptional();

      //Communication Resource
      Mb.Entity<Resource_Communication>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Communication>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Communication>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.received_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.request_FhirId).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.request_Type).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.request_Url).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.sender_FhirId).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.sender_Type).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.sender_Url).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.sent_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Communication>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Communication>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Communication_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Communication_Search_identifier>().HasRequired(x => x.Resource_Communication);
      Mb.Entity<Resource_Communication_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Communication_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Communication_Search_medium>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Communication_Search_medium>().HasRequired(x => x.Resource_Communication);
      Mb.Entity<Resource_Communication_Search_medium>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Communication_Search_medium>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Communication_Search_recipient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Communication_Search_recipient>().HasRequired(x => x.Resource_Communication);
      Mb.Entity<Resource_Communication_Search_recipient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Communication_Search_recipient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Communication_Search_recipient>().Property(x => x.Url).IsOptional();

      //CommunicationRequest Resource
      Mb.Entity<Resource_CommunicationRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.priority_Code).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.priority_System).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.requested_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.requester_FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.requester_Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.requester_Url).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.sender_FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.sender_Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.sender_Url).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_CommunicationRequest>().Property(x => x.time_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_identifier>().HasRequired(x => x.Resource_CommunicationRequest);
      Mb.Entity<Resource_CommunicationRequest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_CommunicationRequest_Search_medium>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_medium>().HasRequired(x => x.Resource_CommunicationRequest);
      Mb.Entity<Resource_CommunicationRequest_Search_medium>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_medium>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_CommunicationRequest_Search_recipient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_recipient>().HasRequired(x => x.Resource_CommunicationRequest);
      Mb.Entity<Resource_CommunicationRequest_Search_recipient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_recipient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_CommunicationRequest_Search_recipient>().Property(x => x.Url).IsOptional();

      //Composition Resource
      Mb.Entity<Resource_Composition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Composition>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Composition>().Property(x => x.class_Code).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.class_System).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.confidentiality_Code).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.confidentiality_System).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Composition>().Property(x => x.title_String).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Composition>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Composition_Search_attester>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_attester>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_attester>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Composition_Search_attester>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Composition_Search_attester>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Composition_Search_author>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_author>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_author>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Composition_Search_author>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Composition_Search_author>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Composition_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_context>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Composition_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Composition_Search_entry>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_entry>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_entry>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Composition_Search_entry>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Composition_Search_entry>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Composition_Search_period>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_period>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_period>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Composition_Search_section>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Composition_Search_section>().HasRequired(x => x.Resource_Composition);
      Mb.Entity<Resource_Composition_Search_section>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Composition_Search_section>().Property(x => x.System).IsOptional();

      //ConceptMap Resource
      Mb.Entity<Resource_ConceptMap>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ConceptMap>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ConceptMap>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.sourceuri_FhirId).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.sourceuri_Type).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.sourceuri_Url).IsOptional();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.target_FhirId).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.target_Type).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.target_Url).IsOptional();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_ConceptMap>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_ConceptMap_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_context>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ConceptMap_Search_dependson>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_dependson>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_dependson>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_product>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_product>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_product>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_sourcecode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_sourcecode>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_sourcecode>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_sourcecode>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ConceptMap_Search_sourcesystem>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_sourcesystem>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_sourcesystem>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_targetcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_targetcode>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_targetcode>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_targetcode>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ConceptMap_Search_targetsystem>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ConceptMap_Search_targetsystem>().HasRequired(x => x.Resource_ConceptMap);
      Mb.Entity<Resource_ConceptMap_Search_targetsystem>().Property(x => x.Uri).IsRequired();

      //Condition Resource
      Mb.Entity<Resource_Condition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Condition>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Condition>().Property(x => x.asserter_FhirId).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.asserter_Type).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.asserter_Url).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.clinicalstatus_Code).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.clinicalstatus_System).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.date_recorded_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.onset_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.onset_info_String).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.severity_Code).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.severity_System).IsOptional();
      Mb.Entity<Resource_Condition>().Property(x => x.stage_Code).IsRequired();
      Mb.Entity<Resource_Condition>().Property(x => x.stage_System).IsOptional();
      Mb.Entity<Resource_Condition_Search_body_site>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Condition_Search_body_site>().HasRequired(x => x.Resource_Condition);
      Mb.Entity<Resource_Condition_Search_body_site>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Condition_Search_body_site>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Condition_Search_evidence>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Condition_Search_evidence>().HasRequired(x => x.Resource_Condition);
      Mb.Entity<Resource_Condition_Search_evidence>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Condition_Search_evidence>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Condition_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Condition_Search_identifier>().HasRequired(x => x.Resource_Condition);
      Mb.Entity<Resource_Condition_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Condition_Search_identifier>().Property(x => x.System).IsOptional();

      //Conformance Resource
      Mb.Entity<Resource_Conformance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Conformance>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Conformance>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.fhirversion_Code).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.fhirversion_System).IsOptional();
      Mb.Entity<Resource_Conformance>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.software_String).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Conformance>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_Conformance>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_event>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_event>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_event>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Conformance_Search_event>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_format>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_format>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_format>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Conformance_Search_format>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_mode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_mode>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_mode>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Conformance_Search_mode>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_profile>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_profile>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_profile>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Conformance_Search_profile>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Conformance_Search_profile>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Conformance_Search_resource>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_resource>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_resource>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Conformance_Search_resource>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_security>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_security>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_security>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Conformance_Search_security>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Conformance_Search_supported_profile>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Conformance_Search_supported_profile>().HasRequired(x => x.Resource_Conformance);
      Mb.Entity<Resource_Conformance_Search_supported_profile>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Conformance_Search_supported_profile>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Conformance_Search_supported_profile>().Property(x => x.Url).IsOptional();

      //Contract Resource
      Mb.Entity<Resource_Contract>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Contract>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Contract>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Contract>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Contract>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_Contract>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_Contract_Search_actor>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Contract_Search_actor>().HasRequired(x => x.Resource_Contract);
      Mb.Entity<Resource_Contract_Search_actor>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Contract_Search_actor>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Contract_Search_actor>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Contract_Search_patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Contract_Search_patient>().HasRequired(x => x.Resource_Contract);
      Mb.Entity<Resource_Contract_Search_patient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Contract_Search_patient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Contract_Search_patient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Contract_Search_signer>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Contract_Search_signer>().HasRequired(x => x.Resource_Contract);
      Mb.Entity<Resource_Contract_Search_signer>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Contract_Search_signer>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Contract_Search_signer>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Contract_Search_subject>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Contract_Search_subject>().HasRequired(x => x.Resource_Contract);
      Mb.Entity<Resource_Contract_Search_subject>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Contract_Search_subject>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Contract_Search_subject>().Property(x => x.Url).IsOptional();

      //Coverage Resource
      Mb.Entity<Resource_Coverage>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Coverage>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Coverage>().Property(x => x.dependent_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.dependent_System).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.group_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.group_System).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.issuer_FhirId).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.issuer_Type).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.issuer_Url).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.plan_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.plan_System).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.sequence_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.sequence_System).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.subplan_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.subplan_System).IsOptional();
      Mb.Entity<Resource_Coverage>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Coverage>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Coverage_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Coverage_Search_identifier>().HasRequired(x => x.Resource_Coverage);
      Mb.Entity<Resource_Coverage_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Coverage_Search_identifier>().Property(x => x.System).IsOptional();

      //DataElement Resource
      Mb.Entity<Resource_DataElement>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DataElement>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DataElement>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_DataElement>().Property(x => x.stringency_Code).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.stringency_System).IsOptional();
      Mb.Entity<Resource_DataElement>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_DataElement>().Property(x => x.version_String).IsRequired();
      Mb.Entity<Resource_DataElement_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DataElement_Search_code>().HasRequired(x => x.Resource_DataElement);
      Mb.Entity<Resource_DataElement_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DataElement_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DataElement_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DataElement_Search_context>().HasRequired(x => x.Resource_DataElement);
      Mb.Entity<Resource_DataElement_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DataElement_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DataElement_Search_description>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DataElement_Search_description>().HasRequired(x => x.Resource_DataElement);
      Mb.Entity<Resource_DataElement_Search_description>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_DataElement_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DataElement_Search_identifier>().HasRequired(x => x.Resource_DataElement);
      Mb.Entity<Resource_DataElement_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DataElement_Search_identifier>().Property(x => x.System).IsOptional();

      //DetectedIssue Resource
      Mb.Entity<Resource_DetectedIssue>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DetectedIssue>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DetectedIssue_Search_implicated>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DetectedIssue_Search_implicated>().HasRequired(x => x.Resource_DetectedIssue);
      Mb.Entity<Resource_DetectedIssue_Search_implicated>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DetectedIssue_Search_implicated>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DetectedIssue_Search_implicated>().Property(x => x.Url).IsOptional();

      //Device Resource
      Mb.Entity<Resource_Device>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Device>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Device>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_Device>().Property(x => x.manufacturer_String).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.model_String).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_Device>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Device>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Device>().Property(x => x.udi_String).IsRequired();
      Mb.Entity<Resource_Device>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_Device_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Device_Search_identifier>().HasRequired(x => x.Resource_Device);
      Mb.Entity<Resource_Device_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Device_Search_identifier>().Property(x => x.System).IsOptional();

      //DeviceComponent Resource
      Mb.Entity<Resource_DeviceComponent>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.parent_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.parent_Type).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.parent_Url).IsOptional();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_DeviceComponent>().Property(x => x.type_System).IsOptional();

      //DeviceMetric Resource
      Mb.Entity<Resource_DeviceMetric>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.parent_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.parent_Type).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.parent_Url).IsOptional();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_DeviceMetric>().Property(x => x.type_System).IsOptional();

      //DeviceUseRequest Resource
      Mb.Entity<Resource_DeviceUseRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.device_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.device_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.device_Url).IsOptional();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseRequest>().Property(x => x.subject_Url).IsOptional();

      //DeviceUseStatement Resource
      Mb.Entity<Resource_DeviceUseStatement>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.device_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.device_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.device_Url).IsOptional();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DeviceUseStatement>().Property(x => x.subject_Url).IsOptional();

      //DiagnosticOrder Resource
      Mb.Entity<Resource_DiagnosticOrder>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.orderer_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.orderer_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.orderer_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_actor>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_actor>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_actor>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_actor>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_actor>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_bodysite>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_bodysite>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_bodysite>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_bodysite>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_code>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_date>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_event_date>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_identifier>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_date>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_item_date>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_past_status>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_past_status>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_item_past_status>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_past_status>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_specimen>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_specimen>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_specimen>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_specimen>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_specimen>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status_date>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status_date>().Property(x => x.event_statusCode).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status_date>().Property(x => x.event_statusSystem).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_event_status_date>().Property(x => x.event_dateDateTimeOffset).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status_date>().HasRequired(x => x.Resource_DiagnosticOrder);
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status_date>().Property(x => x.item_past_statusCode).IsRequired();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status_date>().Property(x => x.item_past_statusSystem).IsOptional();
      Mb.Entity<Resource_DiagnosticOrder_Search_item_status_date>().Property(x => x.item_dateDateTimeOffset).IsRequired();

      //DiagnosticReport Resource
      Mb.Entity<Resource_DiagnosticReport>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.issued_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.performer_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.performer_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.performer_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_diagnosis>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_diagnosis>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_diagnosis>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_diagnosis>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_identifier>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_image>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_image>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_image>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_image>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_image>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_request>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_request>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_request>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_request>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_request>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_result>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_result>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_result>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_result>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_result>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DiagnosticReport_Search_specimen>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_specimen>().HasRequired(x => x.Resource_DiagnosticReport);
      Mb.Entity<Resource_DiagnosticReport_Search_specimen>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_specimen>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DiagnosticReport_Search_specimen>().Property(x => x.Url).IsOptional();

      //DocumentManifest Resource
      Mb.Entity<Resource_DocumentManifest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.created_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.source_Uri).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_DocumentManifest>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_author>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_author>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_author>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_author>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_author>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_content_ref>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_content_ref>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_content_ref>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_content_ref>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_content_ref>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_identifier>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_recipient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_recipient>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_recipient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_recipient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_recipient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_related_id>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_related_id>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_related_id>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_related_id>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentManifest_Search_related_ref>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_related_ref>().HasRequired(x => x.Resource_DocumentManifest);
      Mb.Entity<Resource_DocumentManifest_Search_related_ref>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_related_ref>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentManifest_Search_related_ref>().Property(x => x.Url).IsOptional();

      //DocumentReference Resource
      Mb.Entity<Resource_DocumentReference>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_DocumentReference>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_DocumentReference>().Property(x => x.authenticator_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.authenticator_Type).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.authenticator_Url).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.class_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.class_System).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.created_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.custodian_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.custodian_Type).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.custodian_Url).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.facility_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.facility_System).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.indexed_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.period_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.setting_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.setting_System).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_DocumentReference>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_author>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_author>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_author>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_author>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_author>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_event>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_event>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_event>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_event>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_format>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_format>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_format>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_format>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_identifier>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_language>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_language>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_language>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_language>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_location>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_location>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_location>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_id>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_id>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_related_id>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_id>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_related_ref>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_ref>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_related_ref>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_ref>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_related_ref>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_relatesto>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relatesto>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_relatesto>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relatesto>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relatesto>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_relation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relation>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_relation>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relation>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_securitylabel>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_securitylabel>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_securitylabel>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_securitylabel>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().HasRequired(x => x.Resource_DocumentReference);
      Mb.Entity<Resource_DocumentReference_Search_relationship>().Property(x => x.relationCode).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().Property(x => x.relationSystem).IsOptional();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().Property(x => x.relatestoFhirId).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().Property(x => x.relatestoType).IsRequired();
      Mb.Entity<Resource_DocumentReference_Search_relationship>().Property(x => x.relatestoUrl).IsOptional();

      //EligibilityRequest Resource
      Mb.Entity<Resource_EligibilityRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EligibilityRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_EligibilityRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_EligibilityRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_EligibilityRequest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EligibilityRequest_Search_identifier>().HasRequired(x => x.Resource_EligibilityRequest);
      Mb.Entity<Resource_EligibilityRequest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EligibilityRequest_Search_identifier>().Property(x => x.System).IsOptional();

      //EligibilityResponse Resource
      Mb.Entity<Resource_EligibilityResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EligibilityResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_EligibilityResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_EligibilityResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_EligibilityResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EligibilityResponse_Search_identifier>().HasRequired(x => x.Resource_EligibilityResponse);
      Mb.Entity<Resource_EligibilityResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EligibilityResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //Encounter Resource
      Mb.Entity<Resource_Encounter>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Encounter>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Encounter>().Property(x => x.appointment_FhirId).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.appointment_Type).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.appointment_Url).IsOptional();
      Mb.Entity<Resource_Encounter>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.length_Number).IsRequired();       
      Mb.Entity<Resource_Encounter>().Property(x => x.part_of_FhirId).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.part_of_Type).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.part_of_Url).IsOptional();
      Mb.Entity<Resource_Encounter>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Encounter>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Encounter>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Encounter_Search_condition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_condition>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_condition>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_condition>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_condition>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_episodeofcare>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_episodeofcare>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_episodeofcare>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_episodeofcare>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_episodeofcare>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_identifier>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Encounter_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Encounter_Search_incomingreferral>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_incomingreferral>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_incomingreferral>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_incomingreferral>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_incomingreferral>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_indication>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_indication>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_indication>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_indication>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_indication>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_location>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_location>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_location>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_location>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_location>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_location_period>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_location_period>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_location_period>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_participant>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_participant_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant_type>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_participant_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Encounter_Search_participant_type>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Encounter_Search_practitioner>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_practitioner>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_practitioner>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_practitioner>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_practitioner>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_procedure>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_procedure>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_procedure>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Encounter_Search_procedure>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Encounter_Search_procedure>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Encounter_Search_reason>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_reason>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_reason>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Encounter_Search_reason>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Encounter_Search_special_arrangement>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_special_arrangement>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_special_arrangement>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Encounter_Search_special_arrangement>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Encounter_Search_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Encounter_Search_type>().HasRequired(x => x.Resource_Encounter);
      Mb.Entity<Resource_Encounter_Search_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Encounter_Search_type>().Property(x => x.System).IsOptional();

      //EnrollmentRequest Resource
      Mb.Entity<Resource_EnrollmentRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_EnrollmentRequest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest_Search_identifier>().HasRequired(x => x.Resource_EnrollmentRequest);
      Mb.Entity<Resource_EnrollmentRequest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EnrollmentRequest_Search_identifier>().Property(x => x.System).IsOptional();

      //EnrollmentResponse Resource
      Mb.Entity<Resource_EnrollmentResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EnrollmentResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_EnrollmentResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_EnrollmentResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_EnrollmentResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EnrollmentResponse_Search_identifier>().HasRequired(x => x.Resource_EnrollmentResponse);
      Mb.Entity<Resource_EnrollmentResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EnrollmentResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //EpisodeOfCare Resource
      Mb.Entity<Resource_EpisodeOfCare>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.care_manager_FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.care_manager_Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.care_manager_Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare_Search_condition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_condition>().HasRequired(x => x.Resource_EpisodeOfCare);
      Mb.Entity<Resource_EpisodeOfCare_Search_condition>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_condition>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_condition>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_identifier>().HasRequired(x => x.Resource_EpisodeOfCare);
      Mb.Entity<Resource_EpisodeOfCare_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare_Search_incomingreferral>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_incomingreferral>().HasRequired(x => x.Resource_EpisodeOfCare);
      Mb.Entity<Resource_EpisodeOfCare_Search_incomingreferral>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_incomingreferral>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_incomingreferral>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare_Search_team_member>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_team_member>().HasRequired(x => x.Resource_EpisodeOfCare);
      Mb.Entity<Resource_EpisodeOfCare_Search_team_member>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_team_member>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_team_member>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_EpisodeOfCare_Search_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_type>().HasRequired(x => x.Resource_EpisodeOfCare);
      Mb.Entity<Resource_EpisodeOfCare_Search_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_EpisodeOfCare_Search_type>().Property(x => x.System).IsOptional();

      //ExplanationOfBenefit Resource
      Mb.Entity<Resource_ExplanationOfBenefit>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ExplanationOfBenefit>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ExplanationOfBenefit>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ExplanationOfBenefit>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ExplanationOfBenefit_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ExplanationOfBenefit_Search_identifier>().HasRequired(x => x.Resource_ExplanationOfBenefit);
      Mb.Entity<Resource_ExplanationOfBenefit_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ExplanationOfBenefit_Search_identifier>().Property(x => x.System).IsOptional();

      //FamilyMemberHistory Resource
      Mb.Entity<Resource_FamilyMemberHistory>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.gender_Code).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.gender_System).IsOptional();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.relationship_Code).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory>().Property(x => x.relationship_System).IsOptional();
      Mb.Entity<Resource_FamilyMemberHistory_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory_Search_code>().HasRequired(x => x.Resource_FamilyMemberHistory);
      Mb.Entity<Resource_FamilyMemberHistory_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_FamilyMemberHistory_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory_Search_identifier>().HasRequired(x => x.Resource_FamilyMemberHistory);
      Mb.Entity<Resource_FamilyMemberHistory_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_FamilyMemberHistory_Search_identifier>().Property(x => x.System).IsOptional();

      //Flag Resource
      Mb.Entity<Resource_Flag>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Flag>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Flag>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_Flag>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Flag>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Flag>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Flag>().Property(x => x.subject_Url).IsOptional();

      //Goal Resource
      Mb.Entity<Resource_Goal>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Goal>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Goal>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Goal>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Goal>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Goal>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Goal>().Property(x => x.targetdate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Goal_Search_category>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Goal_Search_category>().HasRequired(x => x.Resource_Goal);
      Mb.Entity<Resource_Goal_Search_category>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Goal_Search_category>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Goal_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Goal_Search_identifier>().HasRequired(x => x.Resource_Goal);
      Mb.Entity<Resource_Goal_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Goal_Search_identifier>().Property(x => x.System).IsOptional();

      //Group Resource
      Mb.Entity<Resource_Group>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Group>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Group>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Group>().Property(x => x.actual_Code).IsRequired();
      Mb.Entity<Resource_Group>().Property(x => x.actual_System).IsOptional();
      Mb.Entity<Resource_Group>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Group>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Group>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Group>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Group_Search_characteristic>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_characteristic>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_characteristic>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Group_Search_characteristic>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Group_Search_exclude>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_exclude>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_exclude>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Group_Search_exclude>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Group_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_identifier>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Group_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Group_Search_member>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_member>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_member>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Group_Search_member>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Group_Search_member>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Group_Search_value>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_value>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_value>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Group_Search_value>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Group_Search_characteristic_value>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Group_Search_characteristic_value>().HasRequired(x => x.Resource_Group);
      Mb.Entity<Resource_Group_Search_characteristic_value>().Property(x => x.characteristicCode).IsRequired();
      Mb.Entity<Resource_Group_Search_characteristic_value>().Property(x => x.characteristicSystem).IsOptional();
      Mb.Entity<Resource_Group_Search_characteristic_value>().Property(x => x.valueCode).IsRequired();
      Mb.Entity<Resource_Group_Search_characteristic_value>().Property(x => x.valueSystem).IsOptional();

      //HealthcareService Resource
      Mb.Entity<Resource_HealthcareService>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_HealthcareService>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_HealthcareService>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.servicecategory_Code).IsRequired();
      Mb.Entity<Resource_HealthcareService>().Property(x => x.servicecategory_System).IsOptional();
      Mb.Entity<Resource_HealthcareService_Search_characteristic>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_characteristic>().HasRequired(x => x.Resource_HealthcareService);
      Mb.Entity<Resource_HealthcareService_Search_characteristic>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_characteristic>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_HealthcareService_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_identifier>().HasRequired(x => x.Resource_HealthcareService);
      Mb.Entity<Resource_HealthcareService_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_HealthcareService_Search_programname>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_programname>().HasRequired(x => x.Resource_HealthcareService);
      Mb.Entity<Resource_HealthcareService_Search_programname>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_servicetype>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_servicetype>().HasRequired(x => x.Resource_HealthcareService);
      Mb.Entity<Resource_HealthcareService_Search_servicetype>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_HealthcareService_Search_servicetype>().Property(x => x.System).IsOptional();

      //ImagingObjectSelection Resource
      Mb.Entity<Resource_ImagingObjectSelection>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.authoring_time_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.identifier_Uri).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.title_Code).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection>().Property(x => x.title_System).IsOptional();
      Mb.Entity<Resource_ImagingObjectSelection_Search_selected_study>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingObjectSelection_Search_selected_study>().HasRequired(x => x.Resource_ImagingObjectSelection);
      Mb.Entity<Resource_ImagingObjectSelection_Search_selected_study>().Property(x => x.Uri).IsRequired();

      //ImagingStudy Resource
      Mb.Entity<Resource_ImagingStudy>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.accession_Code).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.accession_System).IsOptional();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.started_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ImagingStudy>().Property(x => x.study_Uri).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_bodysite>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_bodysite>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_bodysite>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_bodysite>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ImagingStudy_Search_dicom_class>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_dicom_class>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_dicom_class>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_modality>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_modality>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_modality>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_modality>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ImagingStudy_Search_order>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_order>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_order>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_order>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_order>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ImagingStudy_Search_series>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_series>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_series>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_uid>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImagingStudy_Search_uid>().HasRequired(x => x.Resource_ImagingStudy);
      Mb.Entity<Resource_ImagingStudy_Search_uid>().Property(x => x.Uri).IsRequired();

      //Immunization Resource
      Mb.Entity<Resource_Immunization>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Immunization>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Immunization>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.lot_number_String).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.manufacturer_FhirId).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.manufacturer_Type).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.manufacturer_Url).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.notgiven_Code).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.notgiven_System).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.performer_FhirId).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.performer_Type).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.performer_Url).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.requester_FhirId).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.requester_Type).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.requester_Url).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Immunization>().Property(x => x.vaccine_code_Code).IsRequired();
      Mb.Entity<Resource_Immunization>().Property(x => x.vaccine_code_System).IsOptional();
      Mb.Entity<Resource_Immunization_Search_dose_sequence>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_dose_sequence>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_dose_sequence>().Property(x => x.Number).IsRequired();       
      Mb.Entity<Resource_Immunization_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_identifier>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Immunization_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Immunization_Search_reaction>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reaction>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_reaction>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reaction>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reaction>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Immunization_Search_reaction_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reaction_date>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_reaction_date>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reason>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reason>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_reason>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reason>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Immunization_Search_reason_not_given>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reason_not_given>().HasRequired(x => x.Resource_Immunization);
      Mb.Entity<Resource_Immunization_Search_reason_not_given>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Immunization_Search_reason_not_given>().Property(x => x.System).IsOptional();

      //ImmunizationRecommendation Resource
      Mb.Entity<Resource_ImmunizationRecommendation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_date>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_date>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_date>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_number>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_number>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_number>().Property(x => x.Number).IsRequired();       
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_sequence>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_sequence>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_dose_sequence>().Property(x => x.Number).IsRequired();       
      Mb.Entity<Resource_ImmunizationRecommendation_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_identifier>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_information>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_information>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_information>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_information>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_information>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_status>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_status>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_status>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_status>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_support>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_support>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_support>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_support>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_support>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_vaccine_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_vaccine_type>().HasRequired(x => x.Resource_ImmunizationRecommendation);
      Mb.Entity<Resource_ImmunizationRecommendation_Search_vaccine_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImmunizationRecommendation_Search_vaccine_type>().Property(x => x.System).IsOptional();

      //ImplementationGuide Resource
      Mb.Entity<Resource_ImplementationGuide>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.experimental_Code).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.experimental_System).IsOptional();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_ImplementationGuide>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_ImplementationGuide_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImplementationGuide_Search_context>().HasRequired(x => x.Resource_ImplementationGuide);
      Mb.Entity<Resource_ImplementationGuide_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ImplementationGuide_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ImplementationGuide_Search_dependency>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ImplementationGuide_Search_dependency>().HasRequired(x => x.Resource_ImplementationGuide);
      Mb.Entity<Resource_ImplementationGuide_Search_dependency>().Property(x => x.Uri).IsRequired();

      //List Resource
      Mb.Entity<Resource_List>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_List>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_List>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.empty_reason_Code).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.empty_reason_System).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.notes_String).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_List>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_List>().Property(x => x.title_String).IsRequired();
      Mb.Entity<Resource_List_Search_item>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_List_Search_item>().HasRequired(x => x.Resource_List);
      Mb.Entity<Resource_List_Search_item>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_List_Search_item>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_List_Search_item>().Property(x => x.Url).IsOptional();

      //Location Resource
      Mb.Entity<Resource_Location>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Location>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Location>().Property(x => x.address_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_city_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_country_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_postalcode_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_state_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_use_Code).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.address_use_System).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.near_Code).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.near_System).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.near_distance_Code).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.near_distance_System).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.partof_FhirId).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.partof_Type).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.partof_Url).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Location>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Location>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Location_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Location_Search_identifier>().HasRequired(x => x.Resource_Location);
      Mb.Entity<Resource_Location_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Location_Search_identifier>().Property(x => x.System).IsOptional();

      //Media Resource
      Mb.Entity<Resource_Media>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Media>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Media>().Property(x => x.created_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.operator_FhirId).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.operator_Type).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.operator_Url).IsOptional();
      Mb.Entity<Resource_Media>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Media>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Media>().Property(x => x.subtype_Code).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.subtype_System).IsOptional();
      Mb.Entity<Resource_Media>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Media>().Property(x => x.view_Code).IsRequired();
      Mb.Entity<Resource_Media>().Property(x => x.view_System).IsOptional();
      Mb.Entity<Resource_Media_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Media_Search_identifier>().HasRequired(x => x.Resource_Media);
      Mb.Entity<Resource_Media_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Media_Search_identifier>().Property(x => x.System).IsOptional();

      //Medication Resource
      Mb.Entity<Resource_Medication>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Medication>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Medication>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Medication>().Property(x => x.container_Code).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.container_System).IsOptional();
      Mb.Entity<Resource_Medication>().Property(x => x.form_Code).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.form_System).IsOptional();
      Mb.Entity<Resource_Medication>().Property(x => x.manufacturer_FhirId).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.manufacturer_Type).IsRequired();
      Mb.Entity<Resource_Medication>().Property(x => x.manufacturer_Url).IsOptional();
      Mb.Entity<Resource_Medication_Search_content>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Medication_Search_content>().HasRequired(x => x.Resource_Medication);
      Mb.Entity<Resource_Medication_Search_content>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Medication_Search_content>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Medication_Search_content>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Medication_Search_ingredient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Medication_Search_ingredient>().HasRequired(x => x.Resource_Medication);
      Mb.Entity<Resource_Medication_Search_ingredient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Medication_Search_ingredient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Medication_Search_ingredient>().Property(x => x.Url).IsOptional();

      //MedicationAdministration Resource
      Mb.Entity<Resource_MedicationAdministration>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.effectivetime_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.medication_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.medication_Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.medication_Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.notgiven_Code).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.notgiven_System).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.practitioner_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.practitioner_Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.practitioner_Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.prescription_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.prescription_Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.prescription_Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_MedicationAdministration>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_MedicationAdministration_Search_device>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationAdministration_Search_device>().HasRequired(x => x.Resource_MedicationAdministration);
      Mb.Entity<Resource_MedicationAdministration_Search_device>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MedicationAdministration_Search_device>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MedicationAdministration_Search_device>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_MedicationAdministration_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationAdministration_Search_identifier>().HasRequired(x => x.Resource_MedicationAdministration);
      Mb.Entity<Resource_MedicationAdministration_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_MedicationAdministration_Search_identifier>().Property(x => x.System).IsOptional();

      //MedicationDispense Resource
      Mb.Entity<Resource_MedicationDispense>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.destination_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.destination_Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.destination_Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.dispenser_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.dispenser_Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.dispenser_Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.medication_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.medication_Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.medication_Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.whenhandedover_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MedicationDispense>().Property(x => x.whenprepared_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_prescription>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_prescription>().HasRequired(x => x.Resource_MedicationDispense);
      Mb.Entity<Resource_MedicationDispense_Search_prescription>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_prescription>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_prescription>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense_Search_receiver>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_receiver>().HasRequired(x => x.Resource_MedicationDispense);
      Mb.Entity<Resource_MedicationDispense_Search_receiver>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_receiver>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_receiver>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_MedicationDispense_Search_responsibleparty>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_responsibleparty>().HasRequired(x => x.Resource_MedicationDispense);
      Mb.Entity<Resource_MedicationDispense_Search_responsibleparty>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_responsibleparty>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MedicationDispense_Search_responsibleparty>().Property(x => x.Url).IsOptional();

      //MedicationOrder Resource
      Mb.Entity<Resource_MedicationOrder>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.datewritten_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.medication_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.medication_Type).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.medication_Url).IsOptional();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.prescriber_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.prescriber_Type).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.prescriber_Url).IsOptional();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_MedicationOrder>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_MedicationOrder_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationOrder_Search_identifier>().HasRequired(x => x.Resource_MedicationOrder);
      Mb.Entity<Resource_MedicationOrder_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_MedicationOrder_Search_identifier>().Property(x => x.System).IsOptional();

      //MedicationStatement Resource
      Mb.Entity<Resource_MedicationStatement>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.effectivedate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.medication_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.medication_Type).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.medication_Url).IsOptional();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_MedicationStatement>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_MedicationStatement_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MedicationStatement_Search_identifier>().HasRequired(x => x.Resource_MedicationStatement);
      Mb.Entity<Resource_MedicationStatement_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_MedicationStatement_Search_identifier>().Property(x => x.System).IsOptional();

      //MessageHeader Resource
      Mb.Entity<Resource_MessageHeader>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_MessageHeader>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_MessageHeader>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.enterer_FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.enterer_Type).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.enterer_Url).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.event_Code).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.event_System).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.receiver_FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.receiver_Type).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.receiver_Url).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.response_id_Code).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.response_id_System).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.responsible_FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.responsible_Type).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.responsible_Url).IsOptional();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.source_String).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.source_uri_Uri).IsRequired();
      Mb.Entity<Resource_MessageHeader>().Property(x => x.timestamp_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_data>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_data>().HasRequired(x => x.Resource_MessageHeader);
      Mb.Entity<Resource_MessageHeader_Search_data>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_data>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_data>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_MessageHeader_Search_destination>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_destination>().HasRequired(x => x.Resource_MessageHeader);
      Mb.Entity<Resource_MessageHeader_Search_destination>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_destination_uri>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_destination_uri>().HasRequired(x => x.Resource_MessageHeader);
      Mb.Entity<Resource_MessageHeader_Search_destination_uri>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_target>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_target>().HasRequired(x => x.Resource_MessageHeader);
      Mb.Entity<Resource_MessageHeader_Search_target>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_target>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_MessageHeader_Search_target>().Property(x => x.Url).IsOptional();

      //NamingSystem Resource
      Mb.Entity<Resource_NamingSystem>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_NamingSystem>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_NamingSystem>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.kind_Code).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.kind_System).IsOptional();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.replaced_by_FhirId).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.replaced_by_Type).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.replaced_by_Url).IsOptional();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.responsible_String).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_NamingSystem>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_NamingSystem_Search_contact>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_contact>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_contact>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_context>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_NamingSystem_Search_id_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_id_type>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_id_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_id_type>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_NamingSystem_Search_period>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_period>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_period>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_telecom>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_telecom>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_telecom>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_telecom>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_NamingSystem_Search_value>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NamingSystem_Search_value>().HasRequired(x => x.Resource_NamingSystem);
      Mb.Entity<Resource_NamingSystem_Search_value>().Property(x => x.String).IsRequired();

      //NutritionOrder Resource
      Mb.Entity<Resource_NutritionOrder>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.additive_Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.additive_System).IsOptional();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.datetime_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.formula_Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.formula_System).IsOptional();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.provider_FhirId).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.provider_Type).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.provider_Url).IsOptional();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_NutritionOrder_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_identifier>().HasRequired(x => x.Resource_NutritionOrder);
      Mb.Entity<Resource_NutritionOrder_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_NutritionOrder_Search_oraldiet>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_oraldiet>().HasRequired(x => x.Resource_NutritionOrder);
      Mb.Entity<Resource_NutritionOrder_Search_oraldiet>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_oraldiet>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_NutritionOrder_Search_supplement>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_supplement>().HasRequired(x => x.Resource_NutritionOrder);
      Mb.Entity<Resource_NutritionOrder_Search_supplement>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_NutritionOrder_Search_supplement>().Property(x => x.System).IsOptional();

      //Observation Resource
      Mb.Entity<Resource_Observation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Observation>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Observation>().Property(x => x.category_Code).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.category_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.data_absent_reason_Code).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.data_absent_reason_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.device_FhirId).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.device_Type).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.device_Url).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.specimen_FhirId).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.specimen_Type).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.specimen_Url).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.value_concept_Code).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.value_concept_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.value_date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.value_quantity_Quantity).IsRequired();
      Mb.Entity<Resource_Observation>().Property(x => x.value_quantity_System).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.value_quantity_Code).IsOptional();
      Mb.Entity<Resource_Observation>().Property(x => x.value_string_String).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_data_absent_reason>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_data_absent_reason>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_data_absent_reason>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_data_absent_reason>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_value_concept>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_value_concept>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_value_concept>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_value_concept>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_value_quantity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_value_quantity>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_value_quantity>().Property(x => x.Quantity).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_value_quantity>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_value_quantity>().Property(x => x.Code).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_value_string>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_value_string>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_value_string>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Observation_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_identifier>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Observation_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_performer>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_performer>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_performer>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Observation_Search_performer>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Observation_Search_performer>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Observation_Search_related_target>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_related_target>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_related_target>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Observation_Search_related_target>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Observation_Search_related_target>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Observation_Search_related_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_related_type>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_related_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Observation_Search_related_type>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Observation_Search_code_value>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_code_value>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.codeCode).IsRequired();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.codeSystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_conceptCode).IsRequired();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_conceptSystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_dateDateTimeOffset).IsRequired();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_quantityQuantity).IsRequired();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_quantitySystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_quantityCode).IsOptional();
      Mb.Entity<Resource_Observation_Search_code_value>().Property(x => x.value_stringString).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code_value>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code_value>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_codeCode).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_codeSystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_conceptCode).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_conceptSystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_quantityQuantity).IsRequired();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_quantitySystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_quantityCode).IsOptional();
      Mb.Entity<Resource_Observation_Search_component_code_value>().Property(x => x.component_value_stringString).IsRequired();
      Mb.Entity<Resource_Observation_Search_related>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Observation_Search_related>().HasRequired(x => x.Resource_Observation);
      Mb.Entity<Resource_Observation_Search_related>().Property(x => x.related_typeCode).IsRequired();
      Mb.Entity<Resource_Observation_Search_related>().Property(x => x.related_typeSystem).IsOptional();
      Mb.Entity<Resource_Observation_Search_related>().Property(x => x.related_targetFhirId).IsRequired();
      Mb.Entity<Resource_Observation_Search_related>().Property(x => x.related_targetType).IsRequired();
      Mb.Entity<Resource_Observation_Search_related>().Property(x => x.related_targetUrl).IsOptional();

      //OperationDefinition Resource
      Mb.Entity<Resource_OperationDefinition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.base_FhirId).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.base_Type).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.base_Url).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.instance_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.instance_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.kind_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.kind_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.system_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.system_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_OperationDefinition_Search_profile>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OperationDefinition_Search_profile>().HasRequired(x => x.Resource_OperationDefinition);
      Mb.Entity<Resource_OperationDefinition_Search_profile>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_OperationDefinition_Search_profile>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_OperationDefinition_Search_profile>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_OperationDefinition_Search_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OperationDefinition_Search_type>().HasRequired(x => x.Resource_OperationDefinition);
      Mb.Entity<Resource_OperationDefinition_Search_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_OperationDefinition_Search_type>().Property(x => x.System).IsOptional();

      //OperationOutcome Resource
      Mb.Entity<Resource_OperationOutcome>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OperationOutcome>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_OperationOutcome>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_OperationOutcome>().Property(x => x.XmlBlob).IsRequired();      

      //Order Resource
      Mb.Entity<Resource_Order>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Order>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Order>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Order>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_Order>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Order>().Property(x => x.target_FhirId).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.target_Type).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.target_Url).IsOptional();
      Mb.Entity<Resource_Order>().Property(x => x.when_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.when_code_Code).IsRequired();
      Mb.Entity<Resource_Order>().Property(x => x.when_code_System).IsOptional();
      Mb.Entity<Resource_Order_Search_detail>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Order_Search_detail>().HasRequired(x => x.Resource_Order);
      Mb.Entity<Resource_Order_Search_detail>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Order_Search_detail>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Order_Search_detail>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Order_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Order_Search_identifier>().HasRequired(x => x.Resource_Order);
      Mb.Entity<Resource_Order_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Order_Search_identifier>().Property(x => x.System).IsOptional();

      //OrderResponse Resource
      Mb.Entity<Resource_OrderResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_OrderResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_OrderResponse>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.request_FhirId).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.request_Type).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.request_Url).IsOptional();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.who_FhirId).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.who_Type).IsRequired();
      Mb.Entity<Resource_OrderResponse>().Property(x => x.who_Url).IsOptional();
      Mb.Entity<Resource_OrderResponse_Search_fulfillment>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OrderResponse_Search_fulfillment>().HasRequired(x => x.Resource_OrderResponse);
      Mb.Entity<Resource_OrderResponse_Search_fulfillment>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_OrderResponse_Search_fulfillment>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_OrderResponse_Search_fulfillment>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_OrderResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_OrderResponse_Search_identifier>().HasRequired(x => x.Resource_OrderResponse);
      Mb.Entity<Resource_OrderResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_OrderResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //Organization Resource
      Mb.Entity<Resource_Organization>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Organization>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Organization>().Property(x => x.active_Code).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.active_System).IsOptional();
      Mb.Entity<Resource_Organization>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.partof_FhirId).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.partof_Type).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.partof_Url).IsOptional();
      Mb.Entity<Resource_Organization>().Property(x => x.phonetic_String).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Organization>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Organization_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_city>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_city>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address_city>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_country>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_country>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address_country>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_postalcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_postalcode>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address_postalcode>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_state>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_state>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address_state>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_use>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_use>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_address_use>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Organization_Search_address_use>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Organization_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Organization_Search_identifier>().HasRequired(x => x.Resource_Organization);
      Mb.Entity<Resource_Organization_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Organization_Search_identifier>().Property(x => x.System).IsOptional();

      //Parameters Resource
      Mb.Entity<Resource_Parameters>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Parameters>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Parameters>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Parameters>().Property(x => x.XmlBlob).IsRequired();      

      //Patient Resource
      Mb.Entity<Resource_Patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Patient>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Patient>().Property(x => x.active_Code).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.active_System).IsOptional();
      Mb.Entity<Resource_Patient>().Property(x => x.animal_breed_Code).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.animal_breed_System).IsOptional();
      Mb.Entity<Resource_Patient>().Property(x => x.animal_species_Code).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.animal_species_System).IsOptional();
      Mb.Entity<Resource_Patient>().Property(x => x.birthdate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.deathdate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.deceased_Code).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.deceased_System).IsOptional();
      Mb.Entity<Resource_Patient>().Property(x => x.gender_Code).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.gender_System).IsOptional();
      Mb.Entity<Resource_Patient>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_Patient>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_Patient_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_city>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_city>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address_city>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_country>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_country>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address_country>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_postalcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_postalcode>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address_postalcode>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_state>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_state>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address_state>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_use>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_use>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_address_use>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Patient_Search_address_use>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Patient_Search_careprovider>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_careprovider>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_careprovider>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Patient_Search_careprovider>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Patient_Search_careprovider>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Patient_Search_family>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_family>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_family>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_given>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_given>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_given>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_identifier>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Patient_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Patient_Search_language>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_language>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_language>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Patient_Search_language>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Patient_Search_link>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_link>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_link>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Patient_Search_link>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Patient_Search_link>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Patient_Search_name>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_name>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_name>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_phonetic>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_phonetic>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_phonetic>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Patient_Search_telecom>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Patient_Search_telecom>().HasRequired(x => x.Resource_Patient);
      Mb.Entity<Resource_Patient_Search_telecom>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Patient_Search_telecom>().Property(x => x.System).IsOptional();

      //PaymentNotice Resource
      Mb.Entity<Resource_PaymentNotice>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_PaymentNotice>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_PaymentNotice>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_PaymentNotice>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_PaymentNotice_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_PaymentNotice_Search_identifier>().HasRequired(x => x.Resource_PaymentNotice);
      Mb.Entity<Resource_PaymentNotice_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_PaymentNotice_Search_identifier>().Property(x => x.System).IsOptional();

      //PaymentReconciliation Resource
      Mb.Entity<Resource_PaymentReconciliation>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_PaymentReconciliation>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_PaymentReconciliation>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_PaymentReconciliation>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_PaymentReconciliation_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_PaymentReconciliation_Search_identifier>().HasRequired(x => x.Resource_PaymentReconciliation);
      Mb.Entity<Resource_PaymentReconciliation_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_PaymentReconciliation_Search_identifier>().Property(x => x.System).IsOptional();

      //Person Resource
      Mb.Entity<Resource_Person>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Person>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Person>().Property(x => x.birthdate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.gender_Code).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.gender_System).IsOptional();
      Mb.Entity<Resource_Person>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_Person>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_Person_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_address_city>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address_city>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address_city>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_address_country>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address_country>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address_country>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_address_postalcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address_postalcode>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address_postalcode>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_address_state>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address_state>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address_state>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_address_use>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_address_use>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_address_use>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Person_Search_address_use>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Person_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_identifier>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Person_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Person_Search_link>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_link>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_link>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Person_Search_link>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Person_Search_link>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Person_Search_name>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_name>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_name>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_patient>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_patient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Person_Search_patient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Person_Search_patient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Person_Search_phonetic>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_phonetic>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_phonetic>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Person_Search_practitioner>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_practitioner>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_practitioner>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Person_Search_practitioner>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Person_Search_practitioner>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Person_Search_relatedperson>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_relatedperson>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_relatedperson>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Person_Search_relatedperson>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Person_Search_relatedperson>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Person_Search_telecom>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Person_Search_telecom>().HasRequired(x => x.Resource_Person);
      Mb.Entity<Resource_Person_Search_telecom>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Person_Search_telecom>().Property(x => x.System).IsOptional();

      //Practitioner Resource
      Mb.Entity<Resource_Practitioner>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Practitioner>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Practitioner>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Practitioner>().Property(x => x.gender_Code).IsRequired();
      Mb.Entity<Resource_Practitioner>().Property(x => x.gender_System).IsOptional();
      Mb.Entity<Resource_Practitioner>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_Practitioner>().Property(x => x.phonetic_String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_city>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_city>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address_city>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_country>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_country>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address_country>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_postalcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_postalcode>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address_postalcode>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_state>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_state>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address_state>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_use>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_use>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_address_use>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_address_use>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_communication>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_communication>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_communication>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_communication>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_family>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_family>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_family>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_given>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_given>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_given>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_identifier>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_location>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_location>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_location>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_location>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_location>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_organization>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_organization>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_organization>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_organization>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_organization>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_role>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_role>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_role>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_role>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_specialty>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_specialty>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_specialty>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_specialty>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Practitioner_Search_telecom>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_telecom>().HasRequired(x => x.Resource_Practitioner);
      Mb.Entity<Resource_Practitioner_Search_telecom>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Practitioner_Search_telecom>().Property(x => x.System).IsOptional();

      //Procedure Resource
      Mb.Entity<Resource_Procedure>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Procedure>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Procedure>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Procedure>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_Procedure>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_Procedure>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Procedure>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Procedure>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Procedure_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Procedure_Search_identifier>().HasRequired(x => x.Resource_Procedure);
      Mb.Entity<Resource_Procedure_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Procedure_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Procedure_Search_performer>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Procedure_Search_performer>().HasRequired(x => x.Resource_Procedure);
      Mb.Entity<Resource_Procedure_Search_performer>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Procedure_Search_performer>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Procedure_Search_performer>().Property(x => x.Url).IsOptional();

      //ProcedureRequest Resource
      Mb.Entity<Resource_ProcedureRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.orderer_FhirId).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.orderer_Type).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.orderer_Url).IsOptional();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.performer_FhirId).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.performer_Type).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.performer_Url).IsOptional();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_ProcedureRequest>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_ProcedureRequest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcedureRequest_Search_identifier>().HasRequired(x => x.Resource_ProcedureRequest);
      Mb.Entity<Resource_ProcedureRequest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ProcedureRequest_Search_identifier>().Property(x => x.System).IsOptional();

      //ProcessRequest Resource
      Mb.Entity<Resource_ProcessRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.action_Code).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.action_System).IsOptional();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.provider_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.provider_Type).IsRequired();
      Mb.Entity<Resource_ProcessRequest>().Property(x => x.provider_Url).IsOptional();
      Mb.Entity<Resource_ProcessRequest_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcessRequest_Search_identifier>().HasRequired(x => x.Resource_ProcessRequest);
      Mb.Entity<Resource_ProcessRequest_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ProcessRequest_Search_identifier>().Property(x => x.System).IsOptional();

      //ProcessResponse Resource
      Mb.Entity<Resource_ProcessResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.organization_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.organization_Type).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.organization_Url).IsOptional();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.request_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.request_Type).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.request_Url).IsOptional();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestorganization_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestorganization_Type).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestorganization_Url).IsOptional();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestprovider_FhirId).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestprovider_Type).IsRequired();
      Mb.Entity<Resource_ProcessResponse>().Property(x => x.requestprovider_Url).IsOptional();
      Mb.Entity<Resource_ProcessResponse_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ProcessResponse_Search_identifier>().HasRequired(x => x.Resource_ProcessResponse);
      Mb.Entity<Resource_ProcessResponse_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ProcessResponse_Search_identifier>().Property(x => x.System).IsOptional();

      //Provenance Resource
      Mb.Entity<Resource_Provenance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Provenance>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Provenance>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Provenance>().Property(x => x.end_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Provenance>().Property(x => x.location_FhirId).IsRequired();
      Mb.Entity<Resource_Provenance>().Property(x => x.location_Type).IsRequired();
      Mb.Entity<Resource_Provenance>().Property(x => x.location_Url).IsOptional();
      Mb.Entity<Resource_Provenance>().Property(x => x.start_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Provenance_Search_agent>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_agent>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_agent>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Provenance_Search_agent>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Provenance_Search_agent>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Provenance_Search_entity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_entity>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_entity>().Property(x => x.Uri).IsRequired();
      Mb.Entity<Resource_Provenance_Search_entitytype>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_entitytype>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_entitytype>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Provenance_Search_entitytype>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Provenance_Search_patient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_patient>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_patient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Provenance_Search_patient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Provenance_Search_patient>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Provenance_Search_sigtype>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_sigtype>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_sigtype>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Provenance_Search_sigtype>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Provenance_Search_target>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_target>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_target>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Provenance_Search_target>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Provenance_Search_target>().Property(x => x.Url).IsOptional();
      Mb.Entity<Resource_Provenance_Search_userid>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Provenance_Search_userid>().HasRequired(x => x.Resource_Provenance);
      Mb.Entity<Resource_Provenance_Search_userid>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Provenance_Search_userid>().Property(x => x.System).IsOptional();

      //Questionnaire Resource
      Mb.Entity<Resource_Questionnaire>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Questionnaire>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Questionnaire>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.title_String).IsRequired();
      Mb.Entity<Resource_Questionnaire>().Property(x => x.version_String).IsRequired();
      Mb.Entity<Resource_Questionnaire_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Questionnaire_Search_code>().HasRequired(x => x.Resource_Questionnaire);
      Mb.Entity<Resource_Questionnaire_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Questionnaire_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Questionnaire_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Questionnaire_Search_identifier>().HasRequired(x => x.Resource_Questionnaire);
      Mb.Entity<Resource_Questionnaire_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Questionnaire_Search_identifier>().Property(x => x.System).IsOptional();

      //QuestionnaireResponse Resource
      Mb.Entity<Resource_QuestionnaireResponse>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.author_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.author_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.author_Url).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.authored_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.questionnaire_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.questionnaire_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.questionnaire_Url).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_QuestionnaireResponse>().Property(x => x.subject_Url).IsOptional();

      //ReferralRequest Resource
      Mb.Entity<Resource_ReferralRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.priority_Code).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.priority_System).IsOptional();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.requester_FhirId).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.requester_Type).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.requester_Url).IsOptional();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.specialty_Code).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.specialty_System).IsOptional();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_ReferralRequest>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_ReferralRequest_Search_recipient>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ReferralRequest_Search_recipient>().HasRequired(x => x.Resource_ReferralRequest);
      Mb.Entity<Resource_ReferralRequest_Search_recipient>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_ReferralRequest_Search_recipient>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_ReferralRequest_Search_recipient>().Property(x => x.Url).IsOptional();

      //RelatedPerson Resource
      Mb.Entity<Resource_RelatedPerson>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.birthdate_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.gender_Code).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.gender_System).IsOptional();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_RelatedPerson>().Property(x => x.phonetic_String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_city>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_city>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address_city>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_country>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_country>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address_country>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_postalcode>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_postalcode>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address_postalcode>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_state>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_state>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address_state>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_use>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_use>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_address_use>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_address_use>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_RelatedPerson_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_identifier>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_RelatedPerson_Search_telecom>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_telecom>().HasRequired(x => x.Resource_RelatedPerson);
      Mb.Entity<Resource_RelatedPerson_Search_telecom>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_RelatedPerson_Search_telecom>().Property(x => x.System).IsOptional();

      //RiskAssessment Resource
      Mb.Entity<Resource_RiskAssessment>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.condition_FhirId).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.condition_Type).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.condition_Url).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.method_Code).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.method_System).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.performer_FhirId).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.performer_Type).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.performer_Url).IsOptional();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_RiskAssessment>().Property(x => x.subject_Url).IsOptional();

      //Schedule Resource
      Mb.Entity<Resource_Schedule>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Schedule>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Schedule>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Schedule>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Schedule>().Property(x => x.actor_FhirId).IsRequired();
      Mb.Entity<Resource_Schedule>().Property(x => x.actor_Type).IsRequired();
      Mb.Entity<Resource_Schedule>().Property(x => x.actor_Url).IsOptional();
      Mb.Entity<Resource_Schedule>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Schedule_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Schedule_Search_identifier>().HasRequired(x => x.Resource_Schedule);
      Mb.Entity<Resource_Schedule_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Schedule_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Schedule_Search_type>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Schedule_Search_type>().HasRequired(x => x.Resource_Schedule);
      Mb.Entity<Resource_Schedule_Search_type>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Schedule_Search_type>().Property(x => x.System).IsOptional();

      //SearchParameter Resource
      Mb.Entity<Resource_SearchParameter>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_SearchParameter>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_SearchParameter>().Property(x => x.base_Code).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.base_System).IsOptional();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_SearchParameter>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_SearchParameter_Search_target>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SearchParameter_Search_target>().HasRequired(x => x.Resource_SearchParameter);
      Mb.Entity<Resource_SearchParameter_Search_target>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_SearchParameter_Search_target>().Property(x => x.System).IsOptional();

      //Slot Resource
      Mb.Entity<Resource_Slot>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Slot>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Slot>().Property(x => x.fb_type_Code).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.fb_type_System).IsOptional();
      Mb.Entity<Resource_Slot>().Property(x => x.schedule_FhirId).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.schedule_Type).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.schedule_Url).IsOptional();
      Mb.Entity<Resource_Slot>().Property(x => x.slot_type_Code).IsRequired();
      Mb.Entity<Resource_Slot>().Property(x => x.slot_type_System).IsOptional();
      Mb.Entity<Resource_Slot>().Property(x => x.start_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Slot_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Slot_Search_identifier>().HasRequired(x => x.Resource_Slot);
      Mb.Entity<Resource_Slot_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Slot_Search_identifier>().Property(x => x.System).IsOptional();

      //Specimen Resource
      Mb.Entity<Resource_Specimen>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Specimen>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Specimen>().Property(x => x.accession_Code).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.accession_System).IsOptional();
      Mb.Entity<Resource_Specimen>().Property(x => x.bodysite_Code).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.bodysite_System).IsOptional();
      Mb.Entity<Resource_Specimen>().Property(x => x.collected_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.collector_FhirId).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.collector_Type).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.collector_Url).IsOptional();
      Mb.Entity<Resource_Specimen>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_Specimen>().Property(x => x.subject_FhirId).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.subject_Type).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.subject_Url).IsOptional();
      Mb.Entity<Resource_Specimen>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Specimen>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Specimen_Search_container>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Specimen_Search_container>().HasRequired(x => x.Resource_Specimen);
      Mb.Entity<Resource_Specimen_Search_container>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Specimen_Search_container>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Specimen_Search_container_id>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Specimen_Search_container_id>().HasRequired(x => x.Resource_Specimen);
      Mb.Entity<Resource_Specimen_Search_container_id>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Specimen_Search_container_id>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Specimen_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Specimen_Search_identifier>().HasRequired(x => x.Resource_Specimen);
      Mb.Entity<Resource_Specimen_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Specimen_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Specimen_Search_parent>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Specimen_Search_parent>().HasRequired(x => x.Resource_Specimen);
      Mb.Entity<Resource_Specimen_Search_parent>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Specimen_Search_parent>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Specimen_Search_parent>().Property(x => x.Url).IsOptional();

      //StructureDefinition Resource
      Mb.Entity<Resource_StructureDefinition>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.abstract_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.abstract_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.base_Uri).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.context_type_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.context_type_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.display_String).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.experimental_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.experimental_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.kind_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.kind_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_base_path>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_base_path>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_base_path>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_base_path>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_code>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_context>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_ext_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_ext_context>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_ext_context>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_identifier>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_path>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_path>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_path>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_path>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_StructureDefinition_Search_valueset>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_valueset>().HasRequired(x => x.Resource_StructureDefinition);
      Mb.Entity<Resource_StructureDefinition_Search_valueset>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_valueset>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_StructureDefinition_Search_valueset>().Property(x => x.Url).IsOptional();

      //Subscription Resource
      Mb.Entity<Resource_Subscription>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Subscription>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Subscription>().Property(x => x.criteria_String).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.payload_String).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_Subscription>().Property(x => x.type_Code).IsRequired();
      Mb.Entity<Resource_Subscription>().Property(x => x.type_System).IsOptional();
      Mb.Entity<Resource_Subscription>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_Subscription_Search_contact>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Subscription_Search_contact>().HasRequired(x => x.Resource_Subscription);
      Mb.Entity<Resource_Subscription_Search_contact>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Subscription_Search_contact>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Subscription_Search_tag>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Subscription_Search_tag>().HasRequired(x => x.Resource_Subscription);
      Mb.Entity<Resource_Subscription_Search_tag>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Subscription_Search_tag>().Property(x => x.System).IsOptional();

      //Substance Resource
      Mb.Entity<Resource_Substance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_Substance>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_Substance>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_Substance>().Property(x => x.code_Code).IsRequired();
      Mb.Entity<Resource_Substance>().Property(x => x.code_System).IsOptional();
      Mb.Entity<Resource_Substance_Search_category>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_category>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_category>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Substance_Search_category>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Substance_Search_container_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_container_identifier>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_container_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Substance_Search_container_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Substance_Search_expiry>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_expiry>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_expiry>().Property(x => x.DateTimeOffset).IsRequired();
      Mb.Entity<Resource_Substance_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_identifier>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_Substance_Search_identifier>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Substance_Search_quantity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_quantity>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_quantity>().Property(x => x.Quantity).IsRequired();
      Mb.Entity<Resource_Substance_Search_quantity>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_Substance_Search_quantity>().Property(x => x.Code).IsOptional();
      Mb.Entity<Resource_Substance_Search_substance>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_Substance_Search_substance>().HasRequired(x => x.Resource_Substance);
      Mb.Entity<Resource_Substance_Search_substance>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_Substance_Search_substance>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_Substance_Search_substance>().Property(x => x.Url).IsOptional();

      //SupplyDelivery Resource
      Mb.Entity<Resource_SupplyDelivery>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.supplier_FhirId).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.supplier_Type).IsRequired();
      Mb.Entity<Resource_SupplyDelivery>().Property(x => x.supplier_Url).IsOptional();
      Mb.Entity<Resource_SupplyDelivery_Search_receiver>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SupplyDelivery_Search_receiver>().HasRequired(x => x.Resource_SupplyDelivery);
      Mb.Entity<Resource_SupplyDelivery_Search_receiver>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_SupplyDelivery_Search_receiver>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_SupplyDelivery_Search_receiver>().Property(x => x.Url).IsOptional();

      //SupplyRequest Resource
      Mb.Entity<Resource_SupplyRequest>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.kind_Code).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.kind_System).IsOptional();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.source_FhirId).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.source_Type).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.source_Url).IsOptional();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_SupplyRequest>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_SupplyRequest_Search_supplier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_SupplyRequest_Search_supplier>().HasRequired(x => x.Resource_SupplyRequest);
      Mb.Entity<Resource_SupplyRequest_Search_supplier>().Property(x => x.FhirId).IsRequired();
      Mb.Entity<Resource_SupplyRequest_Search_supplier>().Property(x => x.Type).IsRequired();
      Mb.Entity<Resource_SupplyRequest_Search_supplier>().Property(x => x.Url).IsOptional();

      //TestScript Resource
      Mb.Entity<Resource_TestScript>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_TestScript>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_TestScript>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_TestScript>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_TestScript>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_TestScript>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_TestScript>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_TestScript>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_TestScript>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_capability>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_capability>().HasRequired(x => x.Resource_TestScript);
      Mb.Entity<Resource_TestScript_Search_testscript_capability>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_setup_capability>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_setup_capability>().HasRequired(x => x.Resource_TestScript);
      Mb.Entity<Resource_TestScript_Search_testscript_setup_capability>().Property(x => x.String).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_test_capability>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_TestScript_Search_testscript_test_capability>().HasRequired(x => x.Resource_TestScript);
      Mb.Entity<Resource_TestScript_Search_testscript_test_capability>().Property(x => x.String).IsRequired();

      //ValueSet Resource
      Mb.Entity<Resource_ValueSet>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_ValueSet>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_ValueSet>().Property(x => x.date_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.description_String).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.expansion_Uri).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.identifier_Code).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.identifier_System).IsOptional();
      Mb.Entity<Resource_ValueSet>().Property(x => x.name_String).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.publisher_String).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.status_Code).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.status_System).IsOptional();
      Mb.Entity<Resource_ValueSet>().Property(x => x.system_Uri).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.url_Uri).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.version_Code).IsRequired();
      Mb.Entity<Resource_ValueSet>().Property(x => x.version_System).IsOptional();
      Mb.Entity<Resource_ValueSet_Search_code>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ValueSet_Search_code>().HasRequired(x => x.Resource_ValueSet);
      Mb.Entity<Resource_ValueSet_Search_code>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ValueSet_Search_code>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ValueSet_Search_context>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ValueSet_Search_context>().HasRequired(x => x.Resource_ValueSet);
      Mb.Entity<Resource_ValueSet_Search_context>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_ValueSet_Search_context>().Property(x => x.System).IsOptional();
      Mb.Entity<Resource_ValueSet_Search_reference>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_ValueSet_Search_reference>().HasRequired(x => x.Resource_ValueSet);
      Mb.Entity<Resource_ValueSet_Search_reference>().Property(x => x.Uri).IsRequired();

      //VisionPrescription Resource
      Mb.Entity<Resource_VisionPrescription>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.Received).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.XmlBlob).IsRequired();      
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.datewritten_DateTimeOffset).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.encounter_FhirId).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.encounter_Type).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.encounter_Url).IsOptional();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.patient_FhirId).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.patient_Type).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.patient_Url).IsOptional();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.prescriber_FhirId).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.prescriber_Type).IsRequired();
      Mb.Entity<Resource_VisionPrescription>().Property(x => x.prescriber_Url).IsOptional();
      Mb.Entity<Resource_VisionPrescription_Search_identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Mb.Entity<Resource_VisionPrescription_Search_identifier>().HasRequired(x => x.Resource_VisionPrescription);
      Mb.Entity<Resource_VisionPrescription_Search_identifier>().Property(x => x.Code).IsRequired();
      Mb.Entity<Resource_VisionPrescription_Search_identifier>().Property(x => x.System).IsOptional();

    }
  }
}

