 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This is an Auto generated file do not change it's contents!!.

namespace DataModel.BlazeDbModel2
{

  public class Resource_Account
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public decimal balance_Quantity {get; set;}     
    public string balance_System {get; set;}     
    public string balance_Code {get; set;}     
    public string name_String {get; set;}                  
    public string owner_FhirId {get; set;}     
    public string owner_Type {get; set;}     
    public string owner_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset period_DateTimeOffset {get; set;}              
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Account_Search_identifier> identifier_List { get; set; }   

    public Resource_Account()
    {
      this.identifier_List = new HashSet<Resource_Account_Search_identifier>();
    }
  }
  
  public class Resource_Account_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Account Resource_Account { get; set; }                     
  }

  public class Resource_AllergyIntolerance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string criticality_Code {get; set;}                  
    public string criticality_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public DateTimeOffset last_date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string recorder_FhirId {get; set;}     
    public string recorder_Type {get; set;}     
    public string recorder_Url {get; set;}     
    public string reporter_FhirId {get; set;}     
    public string reporter_Type {get; set;}     
    public string reporter_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string substance_Code {get; set;}                  
    public string substance_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_AllergyIntolerance_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_AllergyIntolerance_Search_manifestation> manifestation_List { get; set; }   
    public ICollection<Resource_AllergyIntolerance_Search_onset> onset_List { get; set; }   
    public ICollection<Resource_AllergyIntolerance_Search_route> route_List { get; set; }   
    public ICollection<Resource_AllergyIntolerance_Search_severity> severity_List { get; set; }   
    public ICollection<Resource_AllergyIntolerance_Search_substance> substance_List { get; set; }   

    public Resource_AllergyIntolerance()
    {
      this.identifier_List = new HashSet<Resource_AllergyIntolerance_Search_identifier>();
      this.manifestation_List = new HashSet<Resource_AllergyIntolerance_Search_manifestation>();
      this.onset_List = new HashSet<Resource_AllergyIntolerance_Search_onset>();
      this.route_List = new HashSet<Resource_AllergyIntolerance_Search_route>();
      this.severity_List = new HashSet<Resource_AllergyIntolerance_Search_severity>();
      this.substance_List = new HashSet<Resource_AllergyIntolerance_Search_substance>();
    }
  }
  
  public class Resource_AllergyIntolerance_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }
  
  public class Resource_AllergyIntolerance_Search_manifestation
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }
  
  public class Resource_AllergyIntolerance_Search_onset
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }
  
  public class Resource_AllergyIntolerance_Search_route
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }
  
  public class Resource_AllergyIntolerance_Search_severity
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }
  
  public class Resource_AllergyIntolerance_Search_substance
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AllergyIntolerance Resource_AllergyIntolerance { get; set; }                     
  }

  public class Resource_Appointment
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_Appointment_Search_actor> actor_List { get; set; }   
    public ICollection<Resource_Appointment_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Appointment_Search_location> location_List { get; set; }   
    public ICollection<Resource_Appointment_Search_part_status> part_status_List { get; set; }   
    public ICollection<Resource_Appointment_Search_patient> patient_List { get; set; }   
    public ICollection<Resource_Appointment_Search_practitioner> practitioner_List { get; set; }   

    public Resource_Appointment()
    {
      this.actor_List = new HashSet<Resource_Appointment_Search_actor>();
      this.identifier_List = new HashSet<Resource_Appointment_Search_identifier>();
      this.location_List = new HashSet<Resource_Appointment_Search_location>();
      this.part_status_List = new HashSet<Resource_Appointment_Search_part_status>();
      this.patient_List = new HashSet<Resource_Appointment_Search_patient>();
      this.practitioner_List = new HashSet<Resource_Appointment_Search_practitioner>();
    }
  }
  
  public class Resource_Appointment_Search_actor
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }
  
  public class Resource_Appointment_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }
  
  public class Resource_Appointment_Search_location
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }
  
  public class Resource_Appointment_Search_part_status
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }
  
  public class Resource_Appointment_Search_patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }
  
  public class Resource_Appointment_Search_practitioner
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Appointment Resource_Appointment { get; set; }                     
  }

  public class Resource_AppointmentResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string actor_FhirId {get; set;}     
    public string actor_Type {get; set;}     
    public string actor_Url {get; set;}     
    public string appointment_FhirId {get; set;}     
    public string appointment_Type {get; set;}     
    public string appointment_Url {get; set;}     
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string part_status_Code {get; set;}                  
    public string part_status_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string practitioner_FhirId {get; set;}     
    public string practitioner_Type {get; set;}     
    public string practitioner_Url {get; set;}     

    public ICollection<Resource_AppointmentResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_AppointmentResponse()
    {
      this.identifier_List = new HashSet<Resource_AppointmentResponse_Search_identifier>();
    }
  }
  
  public class Resource_AppointmentResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AppointmentResponse Resource_AppointmentResponse { get; set; }                     
  }

  public class Resource_AuditEvent
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string action_Code {get; set;}                  
    public string action_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string site_Code {get; set;}                  
    public string site_System {get; set;}                
    public string source_Code {get; set;}                  
    public string source_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_AuditEvent_Search_address> address_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_altid> altid_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_desc> desc_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_identity> identity_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_name> name_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_object_type> object_type_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_participant> participant_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_patient> patient_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_policy> policy_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_reference> reference_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_subtype> subtype_List { get; set; }   
    public ICollection<Resource_AuditEvent_Search_user> user_List { get; set; }   

    public Resource_AuditEvent()
    {
      this.address_List = new HashSet<Resource_AuditEvent_Search_address>();
      this.altid_List = new HashSet<Resource_AuditEvent_Search_altid>();
      this.desc_List = new HashSet<Resource_AuditEvent_Search_desc>();
      this.identity_List = new HashSet<Resource_AuditEvent_Search_identity>();
      this.name_List = new HashSet<Resource_AuditEvent_Search_name>();
      this.object_type_List = new HashSet<Resource_AuditEvent_Search_object_type>();
      this.participant_List = new HashSet<Resource_AuditEvent_Search_participant>();
      this.patient_List = new HashSet<Resource_AuditEvent_Search_patient>();
      this.policy_List = new HashSet<Resource_AuditEvent_Search_policy>();
      this.reference_List = new HashSet<Resource_AuditEvent_Search_reference>();
      this.subtype_List = new HashSet<Resource_AuditEvent_Search_subtype>();
      this.user_List = new HashSet<Resource_AuditEvent_Search_user>();
    }
  }
  
  public class Resource_AuditEvent_Search_address
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_altid
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_desc
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_identity
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_name
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_object_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_participant
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_policy
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_reference
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_subtype
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }
  
  public class Resource_AuditEvent_Search_user
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_AuditEvent Resource_AuditEvent { get; set; }                     
  }

  public class Resource_Basic
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset created_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_Basic_Search_identifier> identifier_List { get; set; }   

    public Resource_Basic()
    {
      this.identifier_List = new HashSet<Resource_Basic_Search_identifier>();
    }
  }
  
  public class Resource_Basic_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Basic Resource_Basic { get; set; }                     
  }

  public class Resource_Binary
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string contenttype_Code {get; set;}                  
    public string contenttype_System {get; set;}                


    public Resource_Binary()
    {
    }
  }

  public class Resource_BodySite
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Resource_BodySite_Search_identifier> identifier_List { get; set; }   

    public Resource_BodySite()
    {
      this.identifier_List = new HashSet<Resource_BodySite_Search_identifier>();
    }
  }
  
  public class Resource_BodySite_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_BodySite Resource_BodySite { get; set; }                     
  }

  public class Resource_Bundle
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string composition_FhirId {get; set;}     
    public string composition_Type {get; set;}     
    public string composition_Url {get; set;}     
    public string message_FhirId {get; set;}     
    public string message_Type {get; set;}     
    public string message_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                


    public Resource_Bundle()
    {
    }
  }

  public class Resource_CarePlan
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_CarePlan_Search_activitycode> activitycode_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_activitydate> activitydate_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_activityreference> activityreference_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_condition> condition_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_goal> goal_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_participant> participant_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_performer> performer_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_relatedcode> relatedcode_List { get; set; }   
    public ICollection<Resource_CarePlan_Search_relatedplan> relatedplan_List { get; set; }   

    public Resource_CarePlan()
    {
      this.activitycode_List = new HashSet<Resource_CarePlan_Search_activitycode>();
      this.activitydate_List = new HashSet<Resource_CarePlan_Search_activitydate>();
      this.activityreference_List = new HashSet<Resource_CarePlan_Search_activityreference>();
      this.condition_List = new HashSet<Resource_CarePlan_Search_condition>();
      this.goal_List = new HashSet<Resource_CarePlan_Search_goal>();
      this.participant_List = new HashSet<Resource_CarePlan_Search_participant>();
      this.performer_List = new HashSet<Resource_CarePlan_Search_performer>();
      this.relatedcode_List = new HashSet<Resource_CarePlan_Search_relatedcode>();
      this.relatedplan_List = new HashSet<Resource_CarePlan_Search_relatedplan>();
    }
  }
  
  public class Resource_CarePlan_Search_activitycode
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_activitydate
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_activityreference
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_condition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_goal
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_participant
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_performer
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_relatedcode
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }
  
  public class Resource_CarePlan_Search_relatedplan
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CarePlan Resource_CarePlan { get; set; }                     
  }

  public class Resource_Claim
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string priority_Code {get; set;}                  
    public string priority_System {get; set;}                
    public string provider_FhirId {get; set;}     
    public string provider_Type {get; set;}     
    public string provider_Url {get; set;}     
    public string use_Code {get; set;}                  
    public string use_System {get; set;}                

    public ICollection<Resource_Claim_Search_identifier> identifier_List { get; set; }   

    public Resource_Claim()
    {
      this.identifier_List = new HashSet<Resource_Claim_Search_identifier>();
    }
  }
  
  public class Resource_Claim_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Claim Resource_Claim { get; set; }                     
  }

  public class Resource_ClaimResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_ClaimResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_ClaimResponse()
    {
      this.identifier_List = new HashSet<Resource_ClaimResponse_Search_identifier>();
    }
  }
  
  public class Resource_ClaimResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ClaimResponse Resource_ClaimResponse { get; set; }                     
  }

  public class Resource_ClinicalImpression
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string assessor_FhirId {get; set;}     
    public string assessor_Type {get; set;}     
    public string assessor_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string previous_FhirId {get; set;}     
    public string previous_Type {get; set;}     
    public string previous_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_ClinicalImpression_Search_action> action_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_finding> finding_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_investigation> investigation_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_plan> plan_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_problem> problem_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_resolved> resolved_List { get; set; }   
    public ICollection<Resource_ClinicalImpression_Search_ruledout> ruledout_List { get; set; }   

    public Resource_ClinicalImpression()
    {
      this.action_List = new HashSet<Resource_ClinicalImpression_Search_action>();
      this.finding_List = new HashSet<Resource_ClinicalImpression_Search_finding>();
      this.investigation_List = new HashSet<Resource_ClinicalImpression_Search_investigation>();
      this.plan_List = new HashSet<Resource_ClinicalImpression_Search_plan>();
      this.problem_List = new HashSet<Resource_ClinicalImpression_Search_problem>();
      this.resolved_List = new HashSet<Resource_ClinicalImpression_Search_resolved>();
      this.ruledout_List = new HashSet<Resource_ClinicalImpression_Search_ruledout>();
    }
  }
  
  public class Resource_ClinicalImpression_Search_action
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_finding
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_investigation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_plan
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_problem
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_resolved
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }
  
  public class Resource_ClinicalImpression_Search_ruledout
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ClinicalImpression Resource_ClinicalImpression { get; set; }                     
  }

  public class Resource_Communication
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset received_DateTimeOffset {get; set;}              
    public string request_FhirId {get; set;}     
    public string request_Type {get; set;}     
    public string request_Url {get; set;}     
    public string sender_FhirId {get; set;}     
    public string sender_Type {get; set;}     
    public string sender_Url {get; set;}     
    public DateTimeOffset sent_DateTimeOffset {get; set;}              
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_Communication_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Communication_Search_medium> medium_List { get; set; }   
    public ICollection<Resource_Communication_Search_recipient> recipient_List { get; set; }   

    public Resource_Communication()
    {
      this.identifier_List = new HashSet<Resource_Communication_Search_identifier>();
      this.medium_List = new HashSet<Resource_Communication_Search_medium>();
      this.recipient_List = new HashSet<Resource_Communication_Search_recipient>();
    }
  }
  
  public class Resource_Communication_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Communication Resource_Communication { get; set; }                     
  }
  
  public class Resource_Communication_Search_medium
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Communication Resource_Communication { get; set; }                     
  }
  
  public class Resource_Communication_Search_recipient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Communication Resource_Communication { get; set; }                     
  }

  public class Resource_CommunicationRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string priority_Code {get; set;}                  
    public string priority_System {get; set;}                
    public DateTimeOffset requested_DateTimeOffset {get; set;}              
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string sender_FhirId {get; set;}     
    public string sender_Type {get; set;}     
    public string sender_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_CommunicationRequest_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_CommunicationRequest_Search_medium> medium_List { get; set; }   
    public ICollection<Resource_CommunicationRequest_Search_recipient> recipient_List { get; set; }   

    public Resource_CommunicationRequest()
    {
      this.identifier_List = new HashSet<Resource_CommunicationRequest_Search_identifier>();
      this.medium_List = new HashSet<Resource_CommunicationRequest_Search_medium>();
      this.recipient_List = new HashSet<Resource_CommunicationRequest_Search_recipient>();
    }
  }
  
  public class Resource_CommunicationRequest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_CommunicationRequest Resource_CommunicationRequest { get; set; }                     
  }
  
  public class Resource_CommunicationRequest_Search_medium
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_CommunicationRequest Resource_CommunicationRequest { get; set; }                     
  }
  
  public class Resource_CommunicationRequest_Search_recipient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_CommunicationRequest Resource_CommunicationRequest { get; set; }                     
  }

  public class Resource_Composition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string class_Code {get; set;}                  
    public string class_System {get; set;}                
    public string confidentiality_Code {get; set;}                  
    public string confidentiality_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string title_String {get; set;}                  
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Composition_Search_attester> attester_List { get; set; }   
    public ICollection<Resource_Composition_Search_author> author_List { get; set; }   
    public ICollection<Resource_Composition_Search_context> context_List { get; set; }   
    public ICollection<Resource_Composition_Search_entry> entry_List { get; set; }   
    public ICollection<Resource_Composition_Search_period> period_List { get; set; }   
    public ICollection<Resource_Composition_Search_section> section_List { get; set; }   

    public Resource_Composition()
    {
      this.attester_List = new HashSet<Resource_Composition_Search_attester>();
      this.author_List = new HashSet<Resource_Composition_Search_author>();
      this.context_List = new HashSet<Resource_Composition_Search_context>();
      this.entry_List = new HashSet<Resource_Composition_Search_entry>();
      this.period_List = new HashSet<Resource_Composition_Search_period>();
      this.section_List = new HashSet<Resource_Composition_Search_section>();
    }
  }
  
  public class Resource_Composition_Search_attester
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }
  
  public class Resource_Composition_Search_author
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }
  
  public class Resource_Composition_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }
  
  public class Resource_Composition_Search_entry
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }
  
  public class Resource_Composition_Search_period
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }
  
  public class Resource_Composition_Search_section
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Composition Resource_Composition { get; set; }                     
  }

  public class Resource_ConceptMap
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_ConceptMap_Search_context> context_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_dependson> dependson_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_product> product_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_sourcecode> sourcecode_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_sourcesystem> sourcesystem_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_targetcode> targetcode_List { get; set; }   
    public ICollection<Resource_ConceptMap_Search_targetsystem> targetsystem_List { get; set; }   

    public Resource_ConceptMap()
    {
      this.context_List = new HashSet<Resource_ConceptMap_Search_context>();
      this.dependson_List = new HashSet<Resource_ConceptMap_Search_dependson>();
      this.product_List = new HashSet<Resource_ConceptMap_Search_product>();
      this.sourcecode_List = new HashSet<Resource_ConceptMap_Search_sourcecode>();
      this.sourcesystem_List = new HashSet<Resource_ConceptMap_Search_sourcesystem>();
      this.targetcode_List = new HashSet<Resource_ConceptMap_Search_targetcode>();
      this.targetsystem_List = new HashSet<Resource_ConceptMap_Search_targetsystem>();
    }
  }
  
  public class Resource_ConceptMap_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_dependson
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_product
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_sourcecode
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_sourcesystem
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_targetcode
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }
  
  public class Resource_ConceptMap_Search_targetsystem
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ConceptMap Resource_ConceptMap { get; set; }                     
  }

  public class Resource_Condition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string asserter_FhirId {get; set;}     
    public string asserter_Type {get; set;}     
    public string asserter_Url {get; set;}     
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string clinicalstatus_Code {get; set;}                  
    public string clinicalstatus_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset date_recorded_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string severity_Code {get; set;}                  
    public string severity_System {get; set;}                
    public string stage_Code {get; set;}                  
    public string stage_System {get; set;}                

    public ICollection<Resource_Condition_Search_body_site> body_site_List { get; set; }   
    public ICollection<Resource_Condition_Search_evidence> evidence_List { get; set; }   
    public ICollection<Resource_Condition_Search_identifier> identifier_List { get; set; }   

    public Resource_Condition()
    {
      this.body_site_List = new HashSet<Resource_Condition_Search_body_site>();
      this.evidence_List = new HashSet<Resource_Condition_Search_evidence>();
      this.identifier_List = new HashSet<Resource_Condition_Search_identifier>();
    }
  }
  
  public class Resource_Condition_Search_body_site
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Condition Resource_Condition { get; set; }                     
  }
  
  public class Resource_Condition_Search_evidence
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Condition Resource_Condition { get; set; }                     
  }
  
  public class Resource_Condition_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Condition Resource_Condition { get; set; }                     
  }

  public class Resource_Conformance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string fhirversion_Code {get; set;}                  
    public string fhirversion_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string software_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_Conformance_Search_event> event_List { get; set; }   
    public ICollection<Resource_Conformance_Search_format> format_List { get; set; }   
    public ICollection<Resource_Conformance_Search_mode> mode_List { get; set; }   
    public ICollection<Resource_Conformance_Search_profile> profile_List { get; set; }   
    public ICollection<Resource_Conformance_Search_resource> resource_List { get; set; }   
    public ICollection<Resource_Conformance_Search_security> security_List { get; set; }   
    public ICollection<Resource_Conformance_Search_supported_profile> supported_profile_List { get; set; }   

    public Resource_Conformance()
    {
      this.event_List = new HashSet<Resource_Conformance_Search_event>();
      this.format_List = new HashSet<Resource_Conformance_Search_format>();
      this.mode_List = new HashSet<Resource_Conformance_Search_mode>();
      this.profile_List = new HashSet<Resource_Conformance_Search_profile>();
      this.resource_List = new HashSet<Resource_Conformance_Search_resource>();
      this.security_List = new HashSet<Resource_Conformance_Search_security>();
      this.supported_profile_List = new HashSet<Resource_Conformance_Search_supported_profile>();
    }
  }
  
  public class Resource_Conformance_Search_event
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_format
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_mode
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_profile
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_resource
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_security
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }
  
  public class Resource_Conformance_Search_supported_profile
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Conformance Resource_Conformance { get; set; }                     
  }

  public class Resource_Contract
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                

    public ICollection<Resource_Contract_Search_actor> actor_List { get; set; }   
    public ICollection<Resource_Contract_Search_patient> patient_List { get; set; }   
    public ICollection<Resource_Contract_Search_signer> signer_List { get; set; }   
    public ICollection<Resource_Contract_Search_subject> subject_List { get; set; }   

    public Resource_Contract()
    {
      this.actor_List = new HashSet<Resource_Contract_Search_actor>();
      this.patient_List = new HashSet<Resource_Contract_Search_patient>();
      this.signer_List = new HashSet<Resource_Contract_Search_signer>();
      this.subject_List = new HashSet<Resource_Contract_Search_subject>();
    }
  }
  
  public class Resource_Contract_Search_actor
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Contract Resource_Contract { get; set; }                     
  }
  
  public class Resource_Contract_Search_patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Contract Resource_Contract { get; set; }                     
  }
  
  public class Resource_Contract_Search_signer
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Contract Resource_Contract { get; set; }                     
  }
  
  public class Resource_Contract_Search_subject
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Contract Resource_Contract { get; set; }                     
  }

  public class Resource_Coverage
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string dependent_Code {get; set;}                  
    public string dependent_System {get; set;}                
    public string group_Code {get; set;}                  
    public string group_System {get; set;}                
    public string issuer_FhirId {get; set;}     
    public string issuer_Type {get; set;}     
    public string issuer_Url {get; set;}     
    public string plan_Code {get; set;}                  
    public string plan_System {get; set;}                
    public string sequence_Code {get; set;}                  
    public string sequence_System {get; set;}                
    public string subplan_Code {get; set;}                  
    public string subplan_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Coverage_Search_identifier> identifier_List { get; set; }   

    public Resource_Coverage()
    {
      this.identifier_List = new HashSet<Resource_Coverage_Search_identifier>();
    }
  }
  
  public class Resource_Coverage_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Coverage Resource_Coverage { get; set; }                     
  }

  public class Resource_DataElement
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string stringency_Code {get; set;}                  
    public string stringency_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_String {get; set;}                  

    public ICollection<Resource_DataElement_Search_code> code_List { get; set; }   
    public ICollection<Resource_DataElement_Search_context> context_List { get; set; }   
    public ICollection<Resource_DataElement_Search_description> description_List { get; set; }   
    public ICollection<Resource_DataElement_Search_identifier> identifier_List { get; set; }   

    public Resource_DataElement()
    {
      this.code_List = new HashSet<Resource_DataElement_Search_code>();
      this.context_List = new HashSet<Resource_DataElement_Search_context>();
      this.description_List = new HashSet<Resource_DataElement_Search_description>();
      this.identifier_List = new HashSet<Resource_DataElement_Search_identifier>();
    }
  }
  
  public class Resource_DataElement_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DataElement Resource_DataElement { get; set; }                     
  }
  
  public class Resource_DataElement_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DataElement Resource_DataElement { get; set; }                     
  }
  
  public class Resource_DataElement_Search_description
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_DataElement Resource_DataElement { get; set; }                     
  }
  
  public class Resource_DataElement_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DataElement Resource_DataElement { get; set; }                     
  }

  public class Resource_DetectedIssue
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Resource_DetectedIssue_Search_implicated> implicated_List { get; set; }   

    public Resource_DetectedIssue()
    {
      this.implicated_List = new HashSet<Resource_DetectedIssue_Search_implicated>();
    }
  }
  
  public class Resource_DetectedIssue_Search_implicated
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DetectedIssue Resource_DetectedIssue { get; set; }                     
  }

  public class Resource_Device
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string manufacturer_String {get; set;}                  
    public string model_String {get; set;}                  
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string udi_String {get; set;}                  
    public string url_Uri {get; set;}     

    public ICollection<Resource_Device_Search_identifier> identifier_List { get; set; }   

    public Resource_Device()
    {
      this.identifier_List = new HashSet<Resource_Device_Search_identifier>();
    }
  }
  
  public class Resource_Device_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Device Resource_Device { get; set; }                     
  }

  public class Resource_DeviceComponent
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string parent_FhirId {get; set;}     
    public string parent_Type {get; set;}     
    public string parent_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                


    public Resource_DeviceComponent()
    {
    }
  }

  public class Resource_DeviceMetric
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string parent_FhirId {get; set;}     
    public string parent_Type {get; set;}     
    public string parent_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                


    public Resource_DeviceMetric()
    {
    }
  }

  public class Resource_DeviceUseRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string device_FhirId {get; set;}     
    public string device_Type {get; set;}     
    public string device_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Resource_DeviceUseRequest()
    {
    }
  }

  public class Resource_DeviceUseStatement
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string device_FhirId {get; set;}     
    public string device_Type {get; set;}     
    public string device_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Resource_DeviceUseStatement()
    {
    }
  }

  public class Resource_DiagnosticOrder
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string orderer_FhirId {get; set;}     
    public string orderer_Type {get; set;}     
    public string orderer_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_DiagnosticOrder_Search_actor> actor_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_bodysite> bodysite_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_code> code_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_event_date> event_date_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_event_status> event_status_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_item_date> item_date_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_item_past_status> item_past_status_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_item_status> item_status_List { get; set; }   
    public ICollection<Resource_DiagnosticOrder_Search_specimen> specimen_List { get; set; }   

    public Resource_DiagnosticOrder()
    {
      this.actor_List = new HashSet<Resource_DiagnosticOrder_Search_actor>();
      this.bodysite_List = new HashSet<Resource_DiagnosticOrder_Search_bodysite>();
      this.code_List = new HashSet<Resource_DiagnosticOrder_Search_code>();
      this.event_date_List = new HashSet<Resource_DiagnosticOrder_Search_event_date>();
      this.event_status_List = new HashSet<Resource_DiagnosticOrder_Search_event_status>();
      this.identifier_List = new HashSet<Resource_DiagnosticOrder_Search_identifier>();
      this.item_date_List = new HashSet<Resource_DiagnosticOrder_Search_item_date>();
      this.item_past_status_List = new HashSet<Resource_DiagnosticOrder_Search_item_past_status>();
      this.item_status_List = new HashSet<Resource_DiagnosticOrder_Search_item_status>();
      this.specimen_List = new HashSet<Resource_DiagnosticOrder_Search_specimen>();
    }
  }
  
  public class Resource_DiagnosticOrder_Search_actor
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_bodysite
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_event_date
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_event_status
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_item_date
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_item_past_status
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_item_status
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }
  
  public class Resource_DiagnosticOrder_Search_specimen
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticOrder Resource_DiagnosticOrder { get; set; }                     
  }

  public class Resource_DiagnosticReport
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public DateTimeOffset issued_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_DiagnosticReport_Search_diagnosis> diagnosis_List { get; set; }   
    public ICollection<Resource_DiagnosticReport_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_DiagnosticReport_Search_image> image_List { get; set; }   
    public ICollection<Resource_DiagnosticReport_Search_request> request_List { get; set; }   
    public ICollection<Resource_DiagnosticReport_Search_result> result_List { get; set; }   
    public ICollection<Resource_DiagnosticReport_Search_specimen> specimen_List { get; set; }   

    public Resource_DiagnosticReport()
    {
      this.diagnosis_List = new HashSet<Resource_DiagnosticReport_Search_diagnosis>();
      this.identifier_List = new HashSet<Resource_DiagnosticReport_Search_identifier>();
      this.image_List = new HashSet<Resource_DiagnosticReport_Search_image>();
      this.request_List = new HashSet<Resource_DiagnosticReport_Search_request>();
      this.result_List = new HashSet<Resource_DiagnosticReport_Search_result>();
      this.specimen_List = new HashSet<Resource_DiagnosticReport_Search_specimen>();
    }
  }
  
  public class Resource_DiagnosticReport_Search_diagnosis
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }
  
  public class Resource_DiagnosticReport_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }
  
  public class Resource_DiagnosticReport_Search_image
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }
  
  public class Resource_DiagnosticReport_Search_request
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }
  
  public class Resource_DiagnosticReport_Search_result
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }
  
  public class Resource_DiagnosticReport_Search_specimen
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DiagnosticReport Resource_DiagnosticReport { get; set; }                     
  }

  public class Resource_DocumentManifest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset created_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_Uri {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_DocumentManifest_Search_author> author_List { get; set; }   
    public ICollection<Resource_DocumentManifest_Search_content_ref> content_ref_List { get; set; }   
    public ICollection<Resource_DocumentManifest_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_DocumentManifest_Search_recipient> recipient_List { get; set; }   
    public ICollection<Resource_DocumentManifest_Search_related_id> related_id_List { get; set; }   
    public ICollection<Resource_DocumentManifest_Search_related_ref> related_ref_List { get; set; }   

    public Resource_DocumentManifest()
    {
      this.author_List = new HashSet<Resource_DocumentManifest_Search_author>();
      this.content_ref_List = new HashSet<Resource_DocumentManifest_Search_content_ref>();
      this.identifier_List = new HashSet<Resource_DocumentManifest_Search_identifier>();
      this.recipient_List = new HashSet<Resource_DocumentManifest_Search_recipient>();
      this.related_id_List = new HashSet<Resource_DocumentManifest_Search_related_id>();
      this.related_ref_List = new HashSet<Resource_DocumentManifest_Search_related_ref>();
    }
  }
  
  public class Resource_DocumentManifest_Search_author
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }
  
  public class Resource_DocumentManifest_Search_content_ref
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }
  
  public class Resource_DocumentManifest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }
  
  public class Resource_DocumentManifest_Search_recipient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }
  
  public class Resource_DocumentManifest_Search_related_id
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }
  
  public class Resource_DocumentManifest_Search_related_ref
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentManifest Resource_DocumentManifest { get; set; }                     
  }

  public class Resource_DocumentReference
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string authenticator_FhirId {get; set;}     
    public string authenticator_Type {get; set;}     
    public string authenticator_Url {get; set;}     
    public string class_Code {get; set;}                  
    public string class_System {get; set;}                
    public DateTimeOffset created_DateTimeOffset {get; set;}              
    public string custodian_FhirId {get; set;}     
    public string custodian_Type {get; set;}     
    public string custodian_Url {get; set;}     
    public string description_String {get; set;}                  
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string facility_Code {get; set;}                  
    public string facility_System {get; set;}                
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public DateTimeOffset indexed_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset period_DateTimeOffset {get; set;}              
    public string setting_Code {get; set;}                  
    public string setting_System {get; set;}                
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_DocumentReference_Search_author> author_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_event> event_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_format> format_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_language> language_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_location> location_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_related_id> related_id_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_related_ref> related_ref_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_relatesto> relatesto_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_relation> relation_List { get; set; }   
    public ICollection<Resource_DocumentReference_Search_securitylabel> securitylabel_List { get; set; }   

    public Resource_DocumentReference()
    {
      this.author_List = new HashSet<Resource_DocumentReference_Search_author>();
      this.event_List = new HashSet<Resource_DocumentReference_Search_event>();
      this.format_List = new HashSet<Resource_DocumentReference_Search_format>();
      this.identifier_List = new HashSet<Resource_DocumentReference_Search_identifier>();
      this.language_List = new HashSet<Resource_DocumentReference_Search_language>();
      this.location_List = new HashSet<Resource_DocumentReference_Search_location>();
      this.related_id_List = new HashSet<Resource_DocumentReference_Search_related_id>();
      this.related_ref_List = new HashSet<Resource_DocumentReference_Search_related_ref>();
      this.relatesto_List = new HashSet<Resource_DocumentReference_Search_relatesto>();
      this.relation_List = new HashSet<Resource_DocumentReference_Search_relation>();
      this.securitylabel_List = new HashSet<Resource_DocumentReference_Search_securitylabel>();
    }
  }
  
  public class Resource_DocumentReference_Search_author
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_event
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_format
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_language
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_location
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_related_id
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_related_ref
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_relatesto
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_relation
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }
  
  public class Resource_DocumentReference_Search_securitylabel
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_DocumentReference Resource_DocumentReference { get; set; }                     
  }

  public class Resource_EligibilityRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_EligibilityRequest_Search_identifier> identifier_List { get; set; }   

    public Resource_EligibilityRequest()
    {
      this.identifier_List = new HashSet<Resource_EligibilityRequest_Search_identifier>();
    }
  }
  
  public class Resource_EligibilityRequest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EligibilityRequest Resource_EligibilityRequest { get; set; }                     
  }

  public class Resource_EligibilityResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_EligibilityResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_EligibilityResponse()
    {
      this.identifier_List = new HashSet<Resource_EligibilityResponse_Search_identifier>();
    }
  }
  
  public class Resource_EligibilityResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EligibilityResponse Resource_EligibilityResponse { get; set; }                     
  }

  public class Resource_Encounter
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string appointment_FhirId {get; set;}     
    public string appointment_Type {get; set;}     
    public string appointment_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public decimal length_Number {get; set;}                  
    public string part_of_FhirId {get; set;}     
    public string part_of_Type {get; set;}     
    public string part_of_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_Encounter_Search_condition> condition_List { get; set; }   
    public ICollection<Resource_Encounter_Search_episodeofcare> episodeofcare_List { get; set; }   
    public ICollection<Resource_Encounter_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Encounter_Search_incomingreferral> incomingreferral_List { get; set; }   
    public ICollection<Resource_Encounter_Search_indication> indication_List { get; set; }   
    public ICollection<Resource_Encounter_Search_location> location_List { get; set; }   
    public ICollection<Resource_Encounter_Search_location_period> location_period_List { get; set; }   
    public ICollection<Resource_Encounter_Search_participant> participant_List { get; set; }   
    public ICollection<Resource_Encounter_Search_participant_type> participant_type_List { get; set; }   
    public ICollection<Resource_Encounter_Search_practitioner> practitioner_List { get; set; }   
    public ICollection<Resource_Encounter_Search_procedure> procedure_List { get; set; }   
    public ICollection<Resource_Encounter_Search_reason> reason_List { get; set; }   
    public ICollection<Resource_Encounter_Search_special_arrangement> special_arrangement_List { get; set; }   
    public ICollection<Resource_Encounter_Search_type> type_List { get; set; }   

    public Resource_Encounter()
    {
      this.condition_List = new HashSet<Resource_Encounter_Search_condition>();
      this.episodeofcare_List = new HashSet<Resource_Encounter_Search_episodeofcare>();
      this.identifier_List = new HashSet<Resource_Encounter_Search_identifier>();
      this.incomingreferral_List = new HashSet<Resource_Encounter_Search_incomingreferral>();
      this.indication_List = new HashSet<Resource_Encounter_Search_indication>();
      this.location_List = new HashSet<Resource_Encounter_Search_location>();
      this.location_period_List = new HashSet<Resource_Encounter_Search_location_period>();
      this.participant_List = new HashSet<Resource_Encounter_Search_participant>();
      this.participant_type_List = new HashSet<Resource_Encounter_Search_participant_type>();
      this.practitioner_List = new HashSet<Resource_Encounter_Search_practitioner>();
      this.procedure_List = new HashSet<Resource_Encounter_Search_procedure>();
      this.reason_List = new HashSet<Resource_Encounter_Search_reason>();
      this.special_arrangement_List = new HashSet<Resource_Encounter_Search_special_arrangement>();
      this.type_List = new HashSet<Resource_Encounter_Search_type>();
    }
  }
  
  public class Resource_Encounter_Search_condition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_episodeofcare
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_incomingreferral
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_indication
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_location
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_location_period
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_participant
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_participant_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_practitioner
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_procedure
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_reason
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_special_arrangement
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }
  
  public class Resource_Encounter_Search_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Encounter Resource_Encounter { get; set; }                     
  }

  public class Resource_EnrollmentRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_EnrollmentRequest_Search_identifier> identifier_List { get; set; }   

    public Resource_EnrollmentRequest()
    {
      this.identifier_List = new HashSet<Resource_EnrollmentRequest_Search_identifier>();
    }
  }
  
  public class Resource_EnrollmentRequest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EnrollmentRequest Resource_EnrollmentRequest { get; set; }                     
  }

  public class Resource_EnrollmentResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_EnrollmentResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_EnrollmentResponse()
    {
      this.identifier_List = new HashSet<Resource_EnrollmentResponse_Search_identifier>();
    }
  }
  
  public class Resource_EnrollmentResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EnrollmentResponse Resource_EnrollmentResponse { get; set; }                     
  }

  public class Resource_EpisodeOfCare
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string care_manager_FhirId {get; set;}     
    public string care_manager_Type {get; set;}     
    public string care_manager_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_EpisodeOfCare_Search_condition> condition_List { get; set; }   
    public ICollection<Resource_EpisodeOfCare_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_EpisodeOfCare_Search_incomingreferral> incomingreferral_List { get; set; }   
    public ICollection<Resource_EpisodeOfCare_Search_team_member> team_member_List { get; set; }   
    public ICollection<Resource_EpisodeOfCare_Search_type> type_List { get; set; }   

    public Resource_EpisodeOfCare()
    {
      this.condition_List = new HashSet<Resource_EpisodeOfCare_Search_condition>();
      this.identifier_List = new HashSet<Resource_EpisodeOfCare_Search_identifier>();
      this.incomingreferral_List = new HashSet<Resource_EpisodeOfCare_Search_incomingreferral>();
      this.team_member_List = new HashSet<Resource_EpisodeOfCare_Search_team_member>();
      this.type_List = new HashSet<Resource_EpisodeOfCare_Search_type>();
    }
  }
  
  public class Resource_EpisodeOfCare_Search_condition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_EpisodeOfCare Resource_EpisodeOfCare { get; set; }                     
  }
  
  public class Resource_EpisodeOfCare_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EpisodeOfCare Resource_EpisodeOfCare { get; set; }                     
  }
  
  public class Resource_EpisodeOfCare_Search_incomingreferral
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_EpisodeOfCare Resource_EpisodeOfCare { get; set; }                     
  }
  
  public class Resource_EpisodeOfCare_Search_team_member
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_EpisodeOfCare Resource_EpisodeOfCare { get; set; }                     
  }
  
  public class Resource_EpisodeOfCare_Search_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_EpisodeOfCare Resource_EpisodeOfCare { get; set; }                     
  }

  public class Resource_ExplanationOfBenefit
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_ExplanationOfBenefit_Search_identifier> identifier_List { get; set; }   

    public Resource_ExplanationOfBenefit()
    {
      this.identifier_List = new HashSet<Resource_ExplanationOfBenefit_Search_identifier>();
    }
  }
  
  public class Resource_ExplanationOfBenefit_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ExplanationOfBenefit Resource_ExplanationOfBenefit { get; set; }                     
  }

  public class Resource_FamilyMemberHistory
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string relationship_Code {get; set;}                  
    public string relationship_System {get; set;}                

    public ICollection<Resource_FamilyMemberHistory_Search_code> code_List { get; set; }   
    public ICollection<Resource_FamilyMemberHistory_Search_identifier> identifier_List { get; set; }   

    public Resource_FamilyMemberHistory()
    {
      this.code_List = new HashSet<Resource_FamilyMemberHistory_Search_code>();
      this.identifier_List = new HashSet<Resource_FamilyMemberHistory_Search_identifier>();
    }
  }
  
  public class Resource_FamilyMemberHistory_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_FamilyMemberHistory Resource_FamilyMemberHistory { get; set; }                     
  }
  
  public class Resource_FamilyMemberHistory_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_FamilyMemberHistory Resource_FamilyMemberHistory { get; set; }                     
  }

  public class Resource_Flag
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Resource_Flag()
    {
    }
  }

  public class Resource_Goal
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_Goal_Search_category> category_List { get; set; }   
    public ICollection<Resource_Goal_Search_identifier> identifier_List { get; set; }   

    public Resource_Goal()
    {
      this.category_List = new HashSet<Resource_Goal_Search_category>();
      this.identifier_List = new HashSet<Resource_Goal_Search_identifier>();
    }
  }
  
  public class Resource_Goal_Search_category
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Goal Resource_Goal { get; set; }                     
  }
  
  public class Resource_Goal_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Goal Resource_Goal { get; set; }                     
  }

  public class Resource_Group
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string actual_Code {get; set;}                  
    public string actual_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Group_Search_characteristic> characteristic_List { get; set; }   
    public ICollection<Resource_Group_Search_exclude> exclude_List { get; set; }   
    public ICollection<Resource_Group_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Group_Search_member> member_List { get; set; }   
    public ICollection<Resource_Group_Search_value> value_List { get; set; }   

    public Resource_Group()
    {
      this.characteristic_List = new HashSet<Resource_Group_Search_characteristic>();
      this.exclude_List = new HashSet<Resource_Group_Search_exclude>();
      this.identifier_List = new HashSet<Resource_Group_Search_identifier>();
      this.member_List = new HashSet<Resource_Group_Search_member>();
      this.value_List = new HashSet<Resource_Group_Search_value>();
    }
  }
  
  public class Resource_Group_Search_characteristic
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Group Resource_Group { get; set; }                     
  }
  
  public class Resource_Group_Search_exclude
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Group Resource_Group { get; set; }                     
  }
  
  public class Resource_Group_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Group Resource_Group { get; set; }                     
  }
  
  public class Resource_Group_Search_member
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Group Resource_Group { get; set; }                     
  }
  
  public class Resource_Group_Search_value
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Group Resource_Group { get; set; }                     
  }

  public class Resource_HealthcareService
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string name_String {get; set;}                  
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string servicecategory_Code {get; set;}                  
    public string servicecategory_System {get; set;}                

    public ICollection<Resource_HealthcareService_Search_characteristic> characteristic_List { get; set; }   
    public ICollection<Resource_HealthcareService_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_HealthcareService_Search_programname> programname_List { get; set; }   
    public ICollection<Resource_HealthcareService_Search_servicetype> servicetype_List { get; set; }   

    public Resource_HealthcareService()
    {
      this.characteristic_List = new HashSet<Resource_HealthcareService_Search_characteristic>();
      this.identifier_List = new HashSet<Resource_HealthcareService_Search_identifier>();
      this.programname_List = new HashSet<Resource_HealthcareService_Search_programname>();
      this.servicetype_List = new HashSet<Resource_HealthcareService_Search_servicetype>();
    }
  }
  
  public class Resource_HealthcareService_Search_characteristic
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_HealthcareService Resource_HealthcareService { get; set; }                     
  }
  
  public class Resource_HealthcareService_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_HealthcareService Resource_HealthcareService { get; set; }                     
  }
  
  public class Resource_HealthcareService_Search_programname
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_HealthcareService Resource_HealthcareService { get; set; }                     
  }
  
  public class Resource_HealthcareService_Search_servicetype
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_HealthcareService Resource_HealthcareService { get; set; }                     
  }

  public class Resource_ImagingObjectSelection
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset authoring_time_DateTimeOffset {get; set;}              
    public string identifier_Uri {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string title_Code {get; set;}                  
    public string title_System {get; set;}                

    public ICollection<Resource_ImagingObjectSelection_Search_selected_study> selected_study_List { get; set; }   

    public Resource_ImagingObjectSelection()
    {
      this.selected_study_List = new HashSet<Resource_ImagingObjectSelection_Search_selected_study>();
    }
  }
  
  public class Resource_ImagingObjectSelection_Search_selected_study
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ImagingObjectSelection Resource_ImagingObjectSelection { get; set; }                     
  }

  public class Resource_ImagingStudy
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string accession_Code {get; set;}                  
    public string accession_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset started_DateTimeOffset {get; set;}              
    public string study_Uri {get; set;}     

    public ICollection<Resource_ImagingStudy_Search_bodysite> bodysite_List { get; set; }   
    public ICollection<Resource_ImagingStudy_Search_dicom_class> dicom_class_List { get; set; }   
    public ICollection<Resource_ImagingStudy_Search_modality> modality_List { get; set; }   
    public ICollection<Resource_ImagingStudy_Search_order> order_List { get; set; }   
    public ICollection<Resource_ImagingStudy_Search_series> series_List { get; set; }   
    public ICollection<Resource_ImagingStudy_Search_uid> uid_List { get; set; }   

    public Resource_ImagingStudy()
    {
      this.bodysite_List = new HashSet<Resource_ImagingStudy_Search_bodysite>();
      this.dicom_class_List = new HashSet<Resource_ImagingStudy_Search_dicom_class>();
      this.modality_List = new HashSet<Resource_ImagingStudy_Search_modality>();
      this.order_List = new HashSet<Resource_ImagingStudy_Search_order>();
      this.series_List = new HashSet<Resource_ImagingStudy_Search_series>();
      this.uid_List = new HashSet<Resource_ImagingStudy_Search_uid>();
    }
  }
  
  public class Resource_ImagingStudy_Search_bodysite
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }
  
  public class Resource_ImagingStudy_Search_dicom_class
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }
  
  public class Resource_ImagingStudy_Search_modality
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }
  
  public class Resource_ImagingStudy_Search_order
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }
  
  public class Resource_ImagingStudy_Search_series
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }
  
  public class Resource_ImagingStudy_Search_uid
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ImagingStudy Resource_ImagingStudy { get; set; }                     
  }

  public class Resource_Immunization
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string lot_number_String {get; set;}                  
    public string manufacturer_FhirId {get; set;}     
    public string manufacturer_Type {get; set;}     
    public string manufacturer_Url {get; set;}     
    public string notgiven_Code {get; set;}                  
    public string notgiven_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string vaccine_code_Code {get; set;}                  
    public string vaccine_code_System {get; set;}                

    public ICollection<Resource_Immunization_Search_dose_sequence> dose_sequence_List { get; set; }   
    public ICollection<Resource_Immunization_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Immunization_Search_reaction> reaction_List { get; set; }   
    public ICollection<Resource_Immunization_Search_reaction_date> reaction_date_List { get; set; }   
    public ICollection<Resource_Immunization_Search_reason> reason_List { get; set; }   
    public ICollection<Resource_Immunization_Search_reason_not_given> reason_not_given_List { get; set; }   

    public Resource_Immunization()
    {
      this.dose_sequence_List = new HashSet<Resource_Immunization_Search_dose_sequence>();
      this.identifier_List = new HashSet<Resource_Immunization_Search_identifier>();
      this.reaction_List = new HashSet<Resource_Immunization_Search_reaction>();
      this.reaction_date_List = new HashSet<Resource_Immunization_Search_reaction_date>();
      this.reason_List = new HashSet<Resource_Immunization_Search_reason>();
      this.reason_not_given_List = new HashSet<Resource_Immunization_Search_reason_not_given>();
    }
  }
  
  public class Resource_Immunization_Search_dose_sequence
  {
    public int Id {get; set;}
    public decimal Number {get; set;}                  
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }
  
  public class Resource_Immunization_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }
  
  public class Resource_Immunization_Search_reaction
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }
  
  public class Resource_Immunization_Search_reaction_date
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }
  
  public class Resource_Immunization_Search_reason
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }
  
  public class Resource_Immunization_Search_reason_not_given
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Immunization Resource_Immunization { get; set; }                     
  }

  public class Resource_ImmunizationRecommendation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Resource_ImmunizationRecommendation_Search_date> date_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_dose_number> dose_number_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_dose_sequence> dose_sequence_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_information> information_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_status> status_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_support> support_List { get; set; }   
    public ICollection<Resource_ImmunizationRecommendation_Search_vaccine_type> vaccine_type_List { get; set; }   

    public Resource_ImmunizationRecommendation()
    {
      this.date_List = new HashSet<Resource_ImmunizationRecommendation_Search_date>();
      this.dose_number_List = new HashSet<Resource_ImmunizationRecommendation_Search_dose_number>();
      this.dose_sequence_List = new HashSet<Resource_ImmunizationRecommendation_Search_dose_sequence>();
      this.identifier_List = new HashSet<Resource_ImmunizationRecommendation_Search_identifier>();
      this.information_List = new HashSet<Resource_ImmunizationRecommendation_Search_information>();
      this.status_List = new HashSet<Resource_ImmunizationRecommendation_Search_status>();
      this.support_List = new HashSet<Resource_ImmunizationRecommendation_Search_support>();
      this.vaccine_type_List = new HashSet<Resource_ImmunizationRecommendation_Search_vaccine_type>();
    }
  }
  
  public class Resource_ImmunizationRecommendation_Search_date
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_dose_number
  {
    public int Id {get; set;}
    public decimal Number {get; set;}                  
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_dose_sequence
  {
    public int Id {get; set;}
    public decimal Number {get; set;}                  
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_information
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_status
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_support
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }
  
  public class Resource_ImmunizationRecommendation_Search_vaccine_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImmunizationRecommendation Resource_ImmunizationRecommendation { get; set; }                     
  }

  public class Resource_ImplementationGuide
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string experimental_Code {get; set;}                  
    public string experimental_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_ImplementationGuide_Search_context> context_List { get; set; }   
    public ICollection<Resource_ImplementationGuide_Search_dependency> dependency_List { get; set; }   

    public Resource_ImplementationGuide()
    {
      this.context_List = new HashSet<Resource_ImplementationGuide_Search_context>();
      this.dependency_List = new HashSet<Resource_ImplementationGuide_Search_dependency>();
    }
  }
  
  public class Resource_ImplementationGuide_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ImplementationGuide Resource_ImplementationGuide { get; set; }                     
  }
  
  public class Resource_ImplementationGuide_Search_dependency
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ImplementationGuide Resource_ImplementationGuide { get; set; }                     
  }

  public class Resource_List
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string empty_reason_Code {get; set;}                  
    public string empty_reason_System {get; set;}                
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string notes_String {get; set;}                  
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string title_String {get; set;}                  

    public ICollection<Resource_List_Search_item> item_List { get; set; }   

    public Resource_List()
    {
      this.item_List = new HashSet<Resource_List_Search_item>();
    }
  }
  
  public class Resource_List_Search_item
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_List Resource_List { get; set; }                     
  }

  public class Resource_Location
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string address_String {get; set;}                  
    public string address_city_String {get; set;}                  
    public string address_country_String {get; set;}                  
    public string address_postalcode_String {get; set;}                  
    public string address_state_String {get; set;}                  
    public string address_use_Code {get; set;}                  
    public string address_use_System {get; set;}                
    public string name_String {get; set;}                  
    public string near_Code {get; set;}                  
    public string near_System {get; set;}                
    public string near_distance_Code {get; set;}                  
    public string near_distance_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string partof_FhirId {get; set;}     
    public string partof_Type {get; set;}     
    public string partof_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Location_Search_identifier> identifier_List { get; set; }   

    public Resource_Location()
    {
      this.identifier_List = new HashSet<Resource_Location_Search_identifier>();
    }
  }
  
  public class Resource_Location_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Location Resource_Location { get; set; }                     
  }

  public class Resource_Media
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset created_DateTimeOffset {get; set;}              
    public string operator_FhirId {get; set;}     
    public string operator_Type {get; set;}     
    public string operator_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string subtype_Code {get; set;}                  
    public string subtype_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string view_Code {get; set;}                  
    public string view_System {get; set;}                

    public ICollection<Resource_Media_Search_identifier> identifier_List { get; set; }   

    public Resource_Media()
    {
      this.identifier_List = new HashSet<Resource_Media_Search_identifier>();
    }
  }
  
  public class Resource_Media_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Media Resource_Media { get; set; }                     
  }

  public class Resource_Medication
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string container_Code {get; set;}                  
    public string container_System {get; set;}                
    public string form_Code {get; set;}                  
    public string form_System {get; set;}                
    public string manufacturer_FhirId {get; set;}     
    public string manufacturer_Type {get; set;}     
    public string manufacturer_Url {get; set;}     

    public ICollection<Resource_Medication_Search_content> content_List { get; set; }   
    public ICollection<Resource_Medication_Search_ingredient> ingredient_List { get; set; }   

    public Resource_Medication()
    {
      this.content_List = new HashSet<Resource_Medication_Search_content>();
      this.ingredient_List = new HashSet<Resource_Medication_Search_ingredient>();
    }
  }
  
  public class Resource_Medication_Search_content
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Medication Resource_Medication { get; set; }                     
  }
  
  public class Resource_Medication_Search_ingredient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Medication Resource_Medication { get; set; }                     
  }

  public class Resource_MedicationAdministration
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string notgiven_Code {get; set;}                  
    public string notgiven_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string practitioner_FhirId {get; set;}     
    public string practitioner_Type {get; set;}     
    public string practitioner_Url {get; set;}     
    public string prescription_FhirId {get; set;}     
    public string prescription_Type {get; set;}     
    public string prescription_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_MedicationAdministration_Search_device> device_List { get; set; }   
    public ICollection<Resource_MedicationAdministration_Search_identifier> identifier_List { get; set; }   

    public Resource_MedicationAdministration()
    {
      this.device_List = new HashSet<Resource_MedicationAdministration_Search_device>();
      this.identifier_List = new HashSet<Resource_MedicationAdministration_Search_identifier>();
    }
  }
  
  public class Resource_MedicationAdministration_Search_device
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MedicationAdministration Resource_MedicationAdministration { get; set; }                     
  }
  
  public class Resource_MedicationAdministration_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_MedicationAdministration Resource_MedicationAdministration { get; set; }                     
  }

  public class Resource_MedicationDispense
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string destination_FhirId {get; set;}     
    public string destination_Type {get; set;}     
    public string destination_Url {get; set;}     
    public string dispenser_FhirId {get; set;}     
    public string dispenser_Type {get; set;}     
    public string dispenser_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public DateTimeOffset whenhandedover_DateTimeOffset {get; set;}              
    public DateTimeOffset whenprepared_DateTimeOffset {get; set;}              

    public ICollection<Resource_MedicationDispense_Search_prescription> prescription_List { get; set; }   
    public ICollection<Resource_MedicationDispense_Search_receiver> receiver_List { get; set; }   
    public ICollection<Resource_MedicationDispense_Search_responsibleparty> responsibleparty_List { get; set; }   

    public Resource_MedicationDispense()
    {
      this.prescription_List = new HashSet<Resource_MedicationDispense_Search_prescription>();
      this.receiver_List = new HashSet<Resource_MedicationDispense_Search_receiver>();
      this.responsibleparty_List = new HashSet<Resource_MedicationDispense_Search_responsibleparty>();
    }
  }
  
  public class Resource_MedicationDispense_Search_prescription
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MedicationDispense Resource_MedicationDispense { get; set; }                     
  }
  
  public class Resource_MedicationDispense_Search_receiver
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MedicationDispense Resource_MedicationDispense { get; set; }                     
  }
  
  public class Resource_MedicationDispense_Search_responsibleparty
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MedicationDispense Resource_MedicationDispense { get; set; }                     
  }

  public class Resource_MedicationOrder
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset datewritten_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string prescriber_FhirId {get; set;}     
    public string prescriber_Type {get; set;}     
    public string prescriber_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_MedicationOrder_Search_identifier> identifier_List { get; set; }   

    public Resource_MedicationOrder()
    {
      this.identifier_List = new HashSet<Resource_MedicationOrder_Search_identifier>();
    }
  }
  
  public class Resource_MedicationOrder_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_MedicationOrder Resource_MedicationOrder { get; set; }                     
  }

  public class Resource_MedicationStatement
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_MedicationStatement_Search_identifier> identifier_List { get; set; }   

    public Resource_MedicationStatement()
    {
      this.identifier_List = new HashSet<Resource_MedicationStatement_Search_identifier>();
    }
  }
  
  public class Resource_MedicationStatement_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_MedicationStatement Resource_MedicationStatement { get; set; }                     
  }

  public class Resource_MessageHeader
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string enterer_FhirId {get; set;}     
    public string enterer_Type {get; set;}     
    public string enterer_Url {get; set;}     
    public string event_Code {get; set;}                  
    public string event_System {get; set;}                
    public string receiver_FhirId {get; set;}     
    public string receiver_Type {get; set;}     
    public string receiver_Url {get; set;}     
    public string response_id_Code {get; set;}                  
    public string response_id_System {get; set;}                
    public string responsible_FhirId {get; set;}     
    public string responsible_Type {get; set;}     
    public string responsible_Url {get; set;}     
    public string source_String {get; set;}                  
    public string source_uri_Uri {get; set;}     
    public DateTimeOffset timestamp_DateTimeOffset {get; set;}              

    public ICollection<Resource_MessageHeader_Search_data> data_List { get; set; }   
    public ICollection<Resource_MessageHeader_Search_destination> destination_List { get; set; }   
    public ICollection<Resource_MessageHeader_Search_destination_uri> destination_uri_List { get; set; }   
    public ICollection<Resource_MessageHeader_Search_target> target_List { get; set; }   

    public Resource_MessageHeader()
    {
      this.data_List = new HashSet<Resource_MessageHeader_Search_data>();
      this.destination_List = new HashSet<Resource_MessageHeader_Search_destination>();
      this.destination_uri_List = new HashSet<Resource_MessageHeader_Search_destination_uri>();
      this.target_List = new HashSet<Resource_MessageHeader_Search_target>();
    }
  }
  
  public class Resource_MessageHeader_Search_data
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MessageHeader Resource_MessageHeader { get; set; }                     
  }
  
  public class Resource_MessageHeader_Search_destination
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_MessageHeader Resource_MessageHeader { get; set; }                     
  }
  
  public class Resource_MessageHeader_Search_destination_uri
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_MessageHeader Resource_MessageHeader { get; set; }                     
  }
  
  public class Resource_MessageHeader_Search_target
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_MessageHeader Resource_MessageHeader { get; set; }                     
  }

  public class Resource_NamingSystem
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string kind_Code {get; set;}                  
    public string kind_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string replaced_by_FhirId {get; set;}     
    public string replaced_by_Type {get; set;}     
    public string replaced_by_Url {get; set;}     
    public string responsible_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_NamingSystem_Search_contact> contact_List { get; set; }   
    public ICollection<Resource_NamingSystem_Search_context> context_List { get; set; }   
    public ICollection<Resource_NamingSystem_Search_id_type> id_type_List { get; set; }   
    public ICollection<Resource_NamingSystem_Search_period> period_List { get; set; }   
    public ICollection<Resource_NamingSystem_Search_telecom> telecom_List { get; set; }   
    public ICollection<Resource_NamingSystem_Search_value> value_List { get; set; }   

    public Resource_NamingSystem()
    {
      this.contact_List = new HashSet<Resource_NamingSystem_Search_contact>();
      this.context_List = new HashSet<Resource_NamingSystem_Search_context>();
      this.id_type_List = new HashSet<Resource_NamingSystem_Search_id_type>();
      this.period_List = new HashSet<Resource_NamingSystem_Search_period>();
      this.telecom_List = new HashSet<Resource_NamingSystem_Search_telecom>();
      this.value_List = new HashSet<Resource_NamingSystem_Search_value>();
    }
  }
  
  public class Resource_NamingSystem_Search_contact
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }
  
  public class Resource_NamingSystem_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }
  
  public class Resource_NamingSystem_Search_id_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }
  
  public class Resource_NamingSystem_Search_period
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }
  
  public class Resource_NamingSystem_Search_telecom
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }
  
  public class Resource_NamingSystem_Search_value
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_NamingSystem Resource_NamingSystem { get; set; }                     
  }

  public class Resource_NutritionOrder
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string additive_Code {get; set;}                  
    public string additive_System {get; set;}                
    public DateTimeOffset datetime_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string formula_Code {get; set;}                  
    public string formula_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string provider_FhirId {get; set;}     
    public string provider_Type {get; set;}     
    public string provider_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_NutritionOrder_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_NutritionOrder_Search_oraldiet> oraldiet_List { get; set; }   
    public ICollection<Resource_NutritionOrder_Search_supplement> supplement_List { get; set; }   

    public Resource_NutritionOrder()
    {
      this.identifier_List = new HashSet<Resource_NutritionOrder_Search_identifier>();
      this.oraldiet_List = new HashSet<Resource_NutritionOrder_Search_oraldiet>();
      this.supplement_List = new HashSet<Resource_NutritionOrder_Search_supplement>();
    }
  }
  
  public class Resource_NutritionOrder_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NutritionOrder Resource_NutritionOrder { get; set; }                     
  }
  
  public class Resource_NutritionOrder_Search_oraldiet
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NutritionOrder Resource_NutritionOrder { get; set; }                     
  }
  
  public class Resource_NutritionOrder_Search_supplement
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_NutritionOrder Resource_NutritionOrder { get; set; }                     
  }

  public class Resource_Observation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string category_Code {get; set;}                  
    public string category_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string data_absent_reason_Code {get; set;}                  
    public string data_absent_reason_System {get; set;}                
    public string device_FhirId {get; set;}     
    public string device_Type {get; set;}     
    public string device_Url {get; set;}     
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string specimen_FhirId {get; set;}     
    public string specimen_Type {get; set;}     
    public string specimen_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_Observation_Search_component_code> component_code_List { get; set; }   
    public ICollection<Resource_Observation_Search_component_data_absent_reason> component_data_absent_reason_List { get; set; }   
    public ICollection<Resource_Observation_Search_component_value_concept> component_value_concept_List { get; set; }   
    public ICollection<Resource_Observation_Search_component_value_quantity> component_value_quantity_List { get; set; }   
    public ICollection<Resource_Observation_Search_component_value_string> component_value_string_List { get; set; }   
    public ICollection<Resource_Observation_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Observation_Search_performer> performer_List { get; set; }   
    public ICollection<Resource_Observation_Search_related_target> related_target_List { get; set; }   
    public ICollection<Resource_Observation_Search_related_type> related_type_List { get; set; }   

    public Resource_Observation()
    {
      this.component_code_List = new HashSet<Resource_Observation_Search_component_code>();
      this.component_data_absent_reason_List = new HashSet<Resource_Observation_Search_component_data_absent_reason>();
      this.component_value_concept_List = new HashSet<Resource_Observation_Search_component_value_concept>();
      this.component_value_quantity_List = new HashSet<Resource_Observation_Search_component_value_quantity>();
      this.component_value_string_List = new HashSet<Resource_Observation_Search_component_value_string>();
      this.identifier_List = new HashSet<Resource_Observation_Search_identifier>();
      this.performer_List = new HashSet<Resource_Observation_Search_performer>();
      this.related_target_List = new HashSet<Resource_Observation_Search_related_target>();
      this.related_type_List = new HashSet<Resource_Observation_Search_related_type>();
    }
  }
  
  public class Resource_Observation_Search_component_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_component_data_absent_reason
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_component_value_concept
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_component_value_quantity
  {
    public int Id {get; set;}
    public decimal Quantity {get; set;}     
    public string System {get; set;}     
    public string Code {get; set;}     
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_component_value_string
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_performer
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_related_target
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }
  
  public class Resource_Observation_Search_related_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Observation Resource_Observation { get; set; }                     
  }

  public class Resource_OperationDefinition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string base_FhirId {get; set;}     
    public string base_Type {get; set;}     
    public string base_Url {get; set;}     
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string instance_Code {get; set;}                  
    public string instance_System {get; set;}                
    public string kind_Code {get; set;}                  
    public string kind_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string system_Code {get; set;}                  
    public string system_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_OperationDefinition_Search_profile> profile_List { get; set; }   
    public ICollection<Resource_OperationDefinition_Search_type> type_List { get; set; }   

    public Resource_OperationDefinition()
    {
      this.profile_List = new HashSet<Resource_OperationDefinition_Search_profile>();
      this.type_List = new HashSet<Resource_OperationDefinition_Search_type>();
    }
  }
  
  public class Resource_OperationDefinition_Search_profile
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_OperationDefinition Resource_OperationDefinition { get; set; }                     
  }
  
  public class Resource_OperationDefinition_Search_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_OperationDefinition Resource_OperationDefinition { get; set; }                     
  }

  public class Resource_OperationOutcome
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    


    public Resource_OperationOutcome()
    {
    }
  }

  public class Resource_Order
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string target_FhirId {get; set;}     
    public string target_Type {get; set;}     
    public string target_Url {get; set;}     
    public DateTimeOffset when_DateTimeOffset {get; set;}              
    public string when_code_Code {get; set;}                  
    public string when_code_System {get; set;}                

    public ICollection<Resource_Order_Search_detail> detail_List { get; set; }   
    public ICollection<Resource_Order_Search_identifier> identifier_List { get; set; }   

    public Resource_Order()
    {
      this.detail_List = new HashSet<Resource_Order_Search_detail>();
      this.identifier_List = new HashSet<Resource_Order_Search_identifier>();
    }
  }
  
  public class Resource_Order_Search_detail
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Order Resource_Order { get; set; }                     
  }
  
  public class Resource_Order_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Order Resource_Order { get; set; }                     
  }

  public class Resource_OrderResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string request_FhirId {get; set;}     
    public string request_Type {get; set;}     
    public string request_Url {get; set;}     
    public string who_FhirId {get; set;}     
    public string who_Type {get; set;}     
    public string who_Url {get; set;}     

    public ICollection<Resource_OrderResponse_Search_fulfillment> fulfillment_List { get; set; }   
    public ICollection<Resource_OrderResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_OrderResponse()
    {
      this.fulfillment_List = new HashSet<Resource_OrderResponse_Search_fulfillment>();
      this.identifier_List = new HashSet<Resource_OrderResponse_Search_identifier>();
    }
  }
  
  public class Resource_OrderResponse_Search_fulfillment
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_OrderResponse Resource_OrderResponse { get; set; }                     
  }
  
  public class Resource_OrderResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_OrderResponse Resource_OrderResponse { get; set; }                     
  }

  public class Resource_Organization
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string active_Code {get; set;}                  
    public string active_System {get; set;}                
    public string name_String {get; set;}                  
    public string partof_FhirId {get; set;}     
    public string partof_Type {get; set;}     
    public string partof_Url {get; set;}     
    public string phonetic_String {get; set;}                  
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Organization_Search_address> address_List { get; set; }   
    public ICollection<Resource_Organization_Search_address_city> address_city_List { get; set; }   
    public ICollection<Resource_Organization_Search_address_country> address_country_List { get; set; }   
    public ICollection<Resource_Organization_Search_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Resource_Organization_Search_address_state> address_state_List { get; set; }   
    public ICollection<Resource_Organization_Search_address_use> address_use_List { get; set; }   
    public ICollection<Resource_Organization_Search_identifier> identifier_List { get; set; }   

    public Resource_Organization()
    {
      this.address_List = new HashSet<Resource_Organization_Search_address>();
      this.address_city_List = new HashSet<Resource_Organization_Search_address_city>();
      this.address_country_List = new HashSet<Resource_Organization_Search_address_country>();
      this.address_postalcode_List = new HashSet<Resource_Organization_Search_address_postalcode>();
      this.address_state_List = new HashSet<Resource_Organization_Search_address_state>();
      this.address_use_List = new HashSet<Resource_Organization_Search_address_use>();
      this.identifier_List = new HashSet<Resource_Organization_Search_identifier>();
    }
  }
  
  public class Resource_Organization_Search_address
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_address_city
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_address_country
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_address_postalcode
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_address_state
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_address_use
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }
  
  public class Resource_Organization_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Organization Resource_Organization { get; set; }                     
  }

  public class Resource_Parameters
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    


    public Resource_Parameters()
    {
    }
  }

  public class Resource_Patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string active_Code {get; set;}                  
    public string active_System {get; set;}                
    public string animal_breed_Code {get; set;}                  
    public string animal_breed_System {get; set;}                
    public string animal_species_Code {get; set;}                  
    public string animal_species_System {get; set;}                
    public DateTimeOffset birthdate_DateTimeOffset {get; set;}              
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     

    public ICollection<Resource_Patient_Search_address> address_List { get; set; }   
    public ICollection<Resource_Patient_Search_address_city> address_city_List { get; set; }   
    public ICollection<Resource_Patient_Search_address_country> address_country_List { get; set; }   
    public ICollection<Resource_Patient_Search_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Resource_Patient_Search_address_state> address_state_List { get; set; }   
    public ICollection<Resource_Patient_Search_address_use> address_use_List { get; set; }   
    public ICollection<Resource_Patient_Search_careprovider> careprovider_List { get; set; }   
    public ICollection<Resource_Patient_Search_family> family_List { get; set; }   
    public ICollection<Resource_Patient_Search_given> given_List { get; set; }   
    public ICollection<Resource_Patient_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Patient_Search_language> language_List { get; set; }   
    public ICollection<Resource_Patient_Search_link> link_List { get; set; }   
    public ICollection<Resource_Patient_Search_name> name_List { get; set; }   
    public ICollection<Resource_Patient_Search_phonetic> phonetic_List { get; set; }   
    public ICollection<Resource_Patient_Search_telecom> telecom_List { get; set; }   

    public Resource_Patient()
    {
      this.address_List = new HashSet<Resource_Patient_Search_address>();
      this.address_city_List = new HashSet<Resource_Patient_Search_address_city>();
      this.address_country_List = new HashSet<Resource_Patient_Search_address_country>();
      this.address_postalcode_List = new HashSet<Resource_Patient_Search_address_postalcode>();
      this.address_state_List = new HashSet<Resource_Patient_Search_address_state>();
      this.address_use_List = new HashSet<Resource_Patient_Search_address_use>();
      this.careprovider_List = new HashSet<Resource_Patient_Search_careprovider>();
      this.family_List = new HashSet<Resource_Patient_Search_family>();
      this.given_List = new HashSet<Resource_Patient_Search_given>();
      this.identifier_List = new HashSet<Resource_Patient_Search_identifier>();
      this.language_List = new HashSet<Resource_Patient_Search_language>();
      this.link_List = new HashSet<Resource_Patient_Search_link>();
      this.name_List = new HashSet<Resource_Patient_Search_name>();
      this.phonetic_List = new HashSet<Resource_Patient_Search_phonetic>();
      this.telecom_List = new HashSet<Resource_Patient_Search_telecom>();
    }
  }
  
  public class Resource_Patient_Search_address
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_address_city
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_address_country
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_address_postalcode
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_address_state
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_address_use
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_careprovider
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_family
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_given
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_language
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_link
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_name
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_phonetic
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }
  
  public class Resource_Patient_Search_telecom
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Patient Resource_Patient { get; set; }                     
  }

  public class Resource_PaymentNotice
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_PaymentNotice_Search_identifier> identifier_List { get; set; }   

    public Resource_PaymentNotice()
    {
      this.identifier_List = new HashSet<Resource_PaymentNotice_Search_identifier>();
    }
  }
  
  public class Resource_PaymentNotice_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_PaymentNotice Resource_PaymentNotice { get; set; }                     
  }

  public class Resource_PaymentReconciliation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Resource_PaymentReconciliation_Search_identifier> identifier_List { get; set; }   

    public Resource_PaymentReconciliation()
    {
      this.identifier_List = new HashSet<Resource_PaymentReconciliation_Search_identifier>();
    }
  }
  
  public class Resource_PaymentReconciliation_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_PaymentReconciliation Resource_PaymentReconciliation { get; set; }                     
  }

  public class Resource_Person
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset birthdate_DateTimeOffset {get; set;}              
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     

    public ICollection<Resource_Person_Search_address> address_List { get; set; }   
    public ICollection<Resource_Person_Search_address_city> address_city_List { get; set; }   
    public ICollection<Resource_Person_Search_address_country> address_country_List { get; set; }   
    public ICollection<Resource_Person_Search_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Resource_Person_Search_address_state> address_state_List { get; set; }   
    public ICollection<Resource_Person_Search_address_use> address_use_List { get; set; }   
    public ICollection<Resource_Person_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Person_Search_link> link_List { get; set; }   
    public ICollection<Resource_Person_Search_name> name_List { get; set; }   
    public ICollection<Resource_Person_Search_patient> patient_List { get; set; }   
    public ICollection<Resource_Person_Search_phonetic> phonetic_List { get; set; }   
    public ICollection<Resource_Person_Search_practitioner> practitioner_List { get; set; }   
    public ICollection<Resource_Person_Search_relatedperson> relatedperson_List { get; set; }   
    public ICollection<Resource_Person_Search_telecom> telecom_List { get; set; }   

    public Resource_Person()
    {
      this.address_List = new HashSet<Resource_Person_Search_address>();
      this.address_city_List = new HashSet<Resource_Person_Search_address_city>();
      this.address_country_List = new HashSet<Resource_Person_Search_address_country>();
      this.address_postalcode_List = new HashSet<Resource_Person_Search_address_postalcode>();
      this.address_state_List = new HashSet<Resource_Person_Search_address_state>();
      this.address_use_List = new HashSet<Resource_Person_Search_address_use>();
      this.identifier_List = new HashSet<Resource_Person_Search_identifier>();
      this.link_List = new HashSet<Resource_Person_Search_link>();
      this.name_List = new HashSet<Resource_Person_Search_name>();
      this.patient_List = new HashSet<Resource_Person_Search_patient>();
      this.phonetic_List = new HashSet<Resource_Person_Search_phonetic>();
      this.practitioner_List = new HashSet<Resource_Person_Search_practitioner>();
      this.relatedperson_List = new HashSet<Resource_Person_Search_relatedperson>();
      this.telecom_List = new HashSet<Resource_Person_Search_telecom>();
    }
  }
  
  public class Resource_Person_Search_address
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_address_city
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_address_country
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_address_postalcode
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_address_state
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_address_use
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_link
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_name
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_phonetic
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_practitioner
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_relatedperson
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }
  
  public class Resource_Person_Search_telecom
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Person Resource_Person { get; set; }                     
  }

  public class Resource_Practitioner
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string name_String {get; set;}                  
    public string phonetic_String {get; set;}                  

    public ICollection<Resource_Practitioner_Search_address> address_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_address_city> address_city_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_address_country> address_country_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_address_state> address_state_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_address_use> address_use_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_communication> communication_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_family> family_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_given> given_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_location> location_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_organization> organization_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_role> role_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_specialty> specialty_List { get; set; }   
    public ICollection<Resource_Practitioner_Search_telecom> telecom_List { get; set; }   

    public Resource_Practitioner()
    {
      this.address_List = new HashSet<Resource_Practitioner_Search_address>();
      this.address_city_List = new HashSet<Resource_Practitioner_Search_address_city>();
      this.address_country_List = new HashSet<Resource_Practitioner_Search_address_country>();
      this.address_postalcode_List = new HashSet<Resource_Practitioner_Search_address_postalcode>();
      this.address_state_List = new HashSet<Resource_Practitioner_Search_address_state>();
      this.address_use_List = new HashSet<Resource_Practitioner_Search_address_use>();
      this.communication_List = new HashSet<Resource_Practitioner_Search_communication>();
      this.family_List = new HashSet<Resource_Practitioner_Search_family>();
      this.given_List = new HashSet<Resource_Practitioner_Search_given>();
      this.identifier_List = new HashSet<Resource_Practitioner_Search_identifier>();
      this.location_List = new HashSet<Resource_Practitioner_Search_location>();
      this.organization_List = new HashSet<Resource_Practitioner_Search_organization>();
      this.role_List = new HashSet<Resource_Practitioner_Search_role>();
      this.specialty_List = new HashSet<Resource_Practitioner_Search_specialty>();
      this.telecom_List = new HashSet<Resource_Practitioner_Search_telecom>();
    }
  }
  
  public class Resource_Practitioner_Search_address
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_address_city
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_address_country
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_address_postalcode
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_address_state
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_address_use
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_communication
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_family
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_given
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_location
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_organization
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_role
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_specialty
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }
  
  public class Resource_Practitioner_Search_telecom
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Practitioner Resource_Practitioner { get; set; }                     
  }

  public class Resource_Procedure
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_Procedure_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Procedure_Search_performer> performer_List { get; set; }   

    public Resource_Procedure()
    {
      this.identifier_List = new HashSet<Resource_Procedure_Search_identifier>();
      this.performer_List = new HashSet<Resource_Procedure_Search_performer>();
    }
  }
  
  public class Resource_Procedure_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Procedure Resource_Procedure { get; set; }                     
  }
  
  public class Resource_Procedure_Search_performer
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Procedure Resource_Procedure { get; set; }                     
  }

  public class Resource_ProcedureRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string orderer_FhirId {get; set;}     
    public string orderer_Type {get; set;}     
    public string orderer_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Resource_ProcedureRequest_Search_identifier> identifier_List { get; set; }   

    public Resource_ProcedureRequest()
    {
      this.identifier_List = new HashSet<Resource_ProcedureRequest_Search_identifier>();
    }
  }
  
  public class Resource_ProcedureRequest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ProcedureRequest Resource_ProcedureRequest { get; set; }                     
  }

  public class Resource_ProcessRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string action_Code {get; set;}                  
    public string action_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string provider_FhirId {get; set;}     
    public string provider_Type {get; set;}     
    public string provider_Url {get; set;}     

    public ICollection<Resource_ProcessRequest_Search_identifier> identifier_List { get; set; }   

    public Resource_ProcessRequest()
    {
      this.identifier_List = new HashSet<Resource_ProcessRequest_Search_identifier>();
    }
  }
  
  public class Resource_ProcessRequest_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ProcessRequest Resource_ProcessRequest { get; set; }                     
  }

  public class Resource_ProcessResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string request_FhirId {get; set;}     
    public string request_Type {get; set;}     
    public string request_Url {get; set;}     
    public string requestorganization_FhirId {get; set;}     
    public string requestorganization_Type {get; set;}     
    public string requestorganization_Url {get; set;}     
    public string requestprovider_FhirId {get; set;}     
    public string requestprovider_Type {get; set;}     
    public string requestprovider_Url {get; set;}     

    public ICollection<Resource_ProcessResponse_Search_identifier> identifier_List { get; set; }   

    public Resource_ProcessResponse()
    {
      this.identifier_List = new HashSet<Resource_ProcessResponse_Search_identifier>();
    }
  }
  
  public class Resource_ProcessResponse_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ProcessResponse Resource_ProcessResponse { get; set; }                     
  }

  public class Resource_Provenance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset end_DateTimeOffset {get; set;}              
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public DateTimeOffset start_DateTimeOffset {get; set;}              

    public ICollection<Resource_Provenance_Search_agent> agent_List { get; set; }   
    public ICollection<Resource_Provenance_Search_entity> entity_List { get; set; }   
    public ICollection<Resource_Provenance_Search_entitytype> entitytype_List { get; set; }   
    public ICollection<Resource_Provenance_Search_patient> patient_List { get; set; }   
    public ICollection<Resource_Provenance_Search_sigtype> sigtype_List { get; set; }   
    public ICollection<Resource_Provenance_Search_target> target_List { get; set; }   
    public ICollection<Resource_Provenance_Search_userid> userid_List { get; set; }   

    public Resource_Provenance()
    {
      this.agent_List = new HashSet<Resource_Provenance_Search_agent>();
      this.entity_List = new HashSet<Resource_Provenance_Search_entity>();
      this.entitytype_List = new HashSet<Resource_Provenance_Search_entitytype>();
      this.patient_List = new HashSet<Resource_Provenance_Search_patient>();
      this.sigtype_List = new HashSet<Resource_Provenance_Search_sigtype>();
      this.target_List = new HashSet<Resource_Provenance_Search_target>();
      this.userid_List = new HashSet<Resource_Provenance_Search_userid>();
    }
  }
  
  public class Resource_Provenance_Search_agent
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_entity
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_entitytype
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_sigtype
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_target
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }
  
  public class Resource_Provenance_Search_userid
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Provenance Resource_Provenance { get; set; }                     
  }

  public class Resource_Questionnaire
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string title_String {get; set;}                  
    public string version_String {get; set;}                  

    public ICollection<Resource_Questionnaire_Search_code> code_List { get; set; }   
    public ICollection<Resource_Questionnaire_Search_identifier> identifier_List { get; set; }   

    public Resource_Questionnaire()
    {
      this.code_List = new HashSet<Resource_Questionnaire_Search_code>();
      this.identifier_List = new HashSet<Resource_Questionnaire_Search_identifier>();
    }
  }
  
  public class Resource_Questionnaire_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Questionnaire Resource_Questionnaire { get; set; }                     
  }
  
  public class Resource_Questionnaire_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Questionnaire Resource_Questionnaire { get; set; }                     
  }

  public class Resource_QuestionnaireResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset authored_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string questionnaire_FhirId {get; set;}     
    public string questionnaire_Type {get; set;}     
    public string questionnaire_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Resource_QuestionnaireResponse()
    {
    }
  }

  public class Resource_ReferralRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string priority_Code {get; set;}                  
    public string priority_System {get; set;}                
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string specialty_Code {get; set;}                  
    public string specialty_System {get; set;}                
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_ReferralRequest_Search_recipient> recipient_List { get; set; }   

    public Resource_ReferralRequest()
    {
      this.recipient_List = new HashSet<Resource_ReferralRequest_Search_recipient>();
    }
  }
  
  public class Resource_ReferralRequest_Search_recipient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_ReferralRequest Resource_ReferralRequest { get; set; }                     
  }

  public class Resource_RelatedPerson
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset birthdate_DateTimeOffset {get; set;}              
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string name_String {get; set;}                  
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string phonetic_String {get; set;}                  

    public ICollection<Resource_RelatedPerson_Search_address> address_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_address_city> address_city_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_address_country> address_country_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_address_state> address_state_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_address_use> address_use_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_RelatedPerson_Search_telecom> telecom_List { get; set; }   

    public Resource_RelatedPerson()
    {
      this.address_List = new HashSet<Resource_RelatedPerson_Search_address>();
      this.address_city_List = new HashSet<Resource_RelatedPerson_Search_address_city>();
      this.address_country_List = new HashSet<Resource_RelatedPerson_Search_address_country>();
      this.address_postalcode_List = new HashSet<Resource_RelatedPerson_Search_address_postalcode>();
      this.address_state_List = new HashSet<Resource_RelatedPerson_Search_address_state>();
      this.address_use_List = new HashSet<Resource_RelatedPerson_Search_address_use>();
      this.identifier_List = new HashSet<Resource_RelatedPerson_Search_identifier>();
      this.telecom_List = new HashSet<Resource_RelatedPerson_Search_telecom>();
    }
  }
  
  public class Resource_RelatedPerson_Search_address
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_address_city
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_address_country
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_address_postalcode
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_address_state
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_address_use
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }
  
  public class Resource_RelatedPerson_Search_telecom
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_RelatedPerson Resource_RelatedPerson { get; set; }                     
  }

  public class Resource_RiskAssessment
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string condition_FhirId {get; set;}     
    public string condition_Type {get; set;}     
    public string condition_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string method_Code {get; set;}                  
    public string method_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Resource_RiskAssessment()
    {
    }
  }

  public class Resource_Schedule
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string actor_FhirId {get; set;}     
    public string actor_Type {get; set;}     
    public string actor_Url {get; set;}     
    public DateTimeOffset date_DateTimeOffset {get; set;}              

    public ICollection<Resource_Schedule_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Schedule_Search_type> type_List { get; set; }   

    public Resource_Schedule()
    {
      this.identifier_List = new HashSet<Resource_Schedule_Search_identifier>();
      this.type_List = new HashSet<Resource_Schedule_Search_type>();
    }
  }
  
  public class Resource_Schedule_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Schedule Resource_Schedule { get; set; }                     
  }
  
  public class Resource_Schedule_Search_type
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Schedule Resource_Schedule { get; set; }                     
  }

  public class Resource_SearchParameter
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string base_Code {get; set;}                  
    public string base_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string description_String {get; set;}                  
    public string name_String {get; set;}                  
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string url_Uri {get; set;}     

    public ICollection<Resource_SearchParameter_Search_target> target_List { get; set; }   

    public Resource_SearchParameter()
    {
      this.target_List = new HashSet<Resource_SearchParameter_Search_target>();
    }
  }
  
  public class Resource_SearchParameter_Search_target
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_SearchParameter Resource_SearchParameter { get; set; }                     
  }

  public class Resource_Slot
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string fb_type_Code {get; set;}                  
    public string fb_type_System {get; set;}                
    public string schedule_FhirId {get; set;}     
    public string schedule_Type {get; set;}     
    public string schedule_Url {get; set;}     
    public string slot_type_Code {get; set;}                  
    public string slot_type_System {get; set;}                
    public DateTimeOffset start_DateTimeOffset {get; set;}              

    public ICollection<Resource_Slot_Search_identifier> identifier_List { get; set; }   

    public Resource_Slot()
    {
      this.identifier_List = new HashSet<Resource_Slot_Search_identifier>();
    }
  }
  
  public class Resource_Slot_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Slot Resource_Slot { get; set; }                     
  }

  public class Resource_Specimen
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string accession_Code {get; set;}                  
    public string accession_System {get; set;}                
    public string bodysite_Code {get; set;}                  
    public string bodysite_System {get; set;}                
    public DateTimeOffset collected_DateTimeOffset {get; set;}              
    public string collector_FhirId {get; set;}     
    public string collector_Type {get; set;}     
    public string collector_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Resource_Specimen_Search_container> container_List { get; set; }   
    public ICollection<Resource_Specimen_Search_container_id> container_id_List { get; set; }   
    public ICollection<Resource_Specimen_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Specimen_Search_parent> parent_List { get; set; }   

    public Resource_Specimen()
    {
      this.container_List = new HashSet<Resource_Specimen_Search_container>();
      this.container_id_List = new HashSet<Resource_Specimen_Search_container_id>();
      this.identifier_List = new HashSet<Resource_Specimen_Search_identifier>();
      this.parent_List = new HashSet<Resource_Specimen_Search_parent>();
    }
  }
  
  public class Resource_Specimen_Search_container
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Specimen Resource_Specimen { get; set; }                     
  }
  
  public class Resource_Specimen_Search_container_id
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Specimen Resource_Specimen { get; set; }                     
  }
  
  public class Resource_Specimen_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Specimen Resource_Specimen { get; set; }                     
  }
  
  public class Resource_Specimen_Search_parent
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Specimen Resource_Specimen { get; set; }                     
  }

  public class Resource_StructureDefinition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string abstract_Code {get; set;}                  
    public string abstract_System {get; set;}                
    public string base_Uri {get; set;}     
    public string context_type_Code {get; set;}                  
    public string context_type_System {get; set;}                
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string display_String {get; set;}                  
    public string experimental_Code {get; set;}                  
    public string experimental_System {get; set;}                
    public string kind_Code {get; set;}                  
    public string kind_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_StructureDefinition_Search_base_path> base_path_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_code> code_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_context> context_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_ext_context> ext_context_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_path> path_List { get; set; }   
    public ICollection<Resource_StructureDefinition_Search_valueset> valueset_List { get; set; }   

    public Resource_StructureDefinition()
    {
      this.base_path_List = new HashSet<Resource_StructureDefinition_Search_base_path>();
      this.code_List = new HashSet<Resource_StructureDefinition_Search_code>();
      this.context_List = new HashSet<Resource_StructureDefinition_Search_context>();
      this.ext_context_List = new HashSet<Resource_StructureDefinition_Search_ext_context>();
      this.identifier_List = new HashSet<Resource_StructureDefinition_Search_identifier>();
      this.path_List = new HashSet<Resource_StructureDefinition_Search_path>();
      this.valueset_List = new HashSet<Resource_StructureDefinition_Search_valueset>();
    }
  }
  
  public class Resource_StructureDefinition_Search_base_path
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_ext_context
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_path
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }
  
  public class Resource_StructureDefinition_Search_valueset
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_StructureDefinition Resource_StructureDefinition { get; set; }                     
  }

  public class Resource_Subscription
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string criteria_String {get; set;}                  
    public string payload_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string url_Uri {get; set;}     

    public ICollection<Resource_Subscription_Search_contact> contact_List { get; set; }   
    public ICollection<Resource_Subscription_Search_tag> tag_List { get; set; }   

    public Resource_Subscription()
    {
      this.contact_List = new HashSet<Resource_Subscription_Search_contact>();
      this.tag_List = new HashSet<Resource_Subscription_Search_tag>();
    }
  }
  
  public class Resource_Subscription_Search_contact
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Subscription Resource_Subscription { get; set; }                     
  }
  
  public class Resource_Subscription_Search_tag
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Subscription Resource_Subscription { get; set; }                     
  }

  public class Resource_Substance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                

    public ICollection<Resource_Substance_Search_category> category_List { get; set; }   
    public ICollection<Resource_Substance_Search_container_identifier> container_identifier_List { get; set; }   
    public ICollection<Resource_Substance_Search_expiry> expiry_List { get; set; }   
    public ICollection<Resource_Substance_Search_identifier> identifier_List { get; set; }   
    public ICollection<Resource_Substance_Search_quantity> quantity_List { get; set; }   
    public ICollection<Resource_Substance_Search_substance> substance_List { get; set; }   

    public Resource_Substance()
    {
      this.category_List = new HashSet<Resource_Substance_Search_category>();
      this.container_identifier_List = new HashSet<Resource_Substance_Search_container_identifier>();
      this.expiry_List = new HashSet<Resource_Substance_Search_expiry>();
      this.identifier_List = new HashSet<Resource_Substance_Search_identifier>();
      this.quantity_List = new HashSet<Resource_Substance_Search_quantity>();
      this.substance_List = new HashSet<Resource_Substance_Search_substance>();
    }
  }
  
  public class Resource_Substance_Search_category
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }
  
  public class Resource_Substance_Search_container_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }
  
  public class Resource_Substance_Search_expiry
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }
  
  public class Resource_Substance_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }
  
  public class Resource_Substance_Search_quantity
  {
    public int Id {get; set;}
    public decimal Quantity {get; set;}     
    public string System {get; set;}     
    public string Code {get; set;}     
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }
  
  public class Resource_Substance_Search_substance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_Substance Resource_Substance { get; set; }                     
  }

  public class Resource_SupplyDelivery
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string supplier_FhirId {get; set;}     
    public string supplier_Type {get; set;}     
    public string supplier_Url {get; set;}     

    public ICollection<Resource_SupplyDelivery_Search_receiver> receiver_List { get; set; }   

    public Resource_SupplyDelivery()
    {
      this.receiver_List = new HashSet<Resource_SupplyDelivery_Search_receiver>();
    }
  }
  
  public class Resource_SupplyDelivery_Search_receiver
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_SupplyDelivery Resource_SupplyDelivery { get; set; }                     
  }

  public class Resource_SupplyRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string kind_Code {get; set;}                  
    public string kind_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Resource_SupplyRequest_Search_supplier> supplier_List { get; set; }   

    public Resource_SupplyRequest()
    {
      this.supplier_List = new HashSet<Resource_SupplyRequest_Search_supplier>();
    }
  }
  
  public class Resource_SupplyRequest_Search_supplier
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Resource_SupplyRequest Resource_SupplyRequest { get; set; }                     
  }

  public class Resource_TestScript
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string description_String {get; set;}                  
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string name_String {get; set;}                  
    public string url_Uri {get; set;}     

    public ICollection<Resource_TestScript_Search_testscript_capability> testscript_capability_List { get; set; }   
    public ICollection<Resource_TestScript_Search_testscript_setup_capability> testscript_setup_capability_List { get; set; }   
    public ICollection<Resource_TestScript_Search_testscript_test_capability> testscript_test_capability_List { get; set; }   

    public Resource_TestScript()
    {
      this.testscript_capability_List = new HashSet<Resource_TestScript_Search_testscript_capability>();
      this.testscript_setup_capability_List = new HashSet<Resource_TestScript_Search_testscript_setup_capability>();
      this.testscript_test_capability_List = new HashSet<Resource_TestScript_Search_testscript_test_capability>();
    }
  }
  
  public class Resource_TestScript_Search_testscript_capability
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_TestScript Resource_TestScript { get; set; }                     
  }
  
  public class Resource_TestScript_Search_testscript_setup_capability
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_TestScript Resource_TestScript { get; set; }                     
  }
  
  public class Resource_TestScript_Search_testscript_test_capability
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Resource_TestScript Resource_TestScript { get; set; }                     
  }

  public class Resource_ValueSet
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string expansion_Uri {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string system_Uri {get; set;}     
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Resource_ValueSet_Search_code> code_List { get; set; }   
    public ICollection<Resource_ValueSet_Search_context> context_List { get; set; }   
    public ICollection<Resource_ValueSet_Search_reference> reference_List { get; set; }   

    public Resource_ValueSet()
    {
      this.code_List = new HashSet<Resource_ValueSet_Search_code>();
      this.context_List = new HashSet<Resource_ValueSet_Search_context>();
      this.reference_List = new HashSet<Resource_ValueSet_Search_reference>();
    }
  }
  
  public class Resource_ValueSet_Search_code
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ValueSet Resource_ValueSet { get; set; }                     
  }
  
  public class Resource_ValueSet_Search_context
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_ValueSet Resource_ValueSet { get; set; }                     
  }
  
  public class Resource_ValueSet_Search_reference
  {
    public int Id {get; set;}
    public string Uri {get; set;}     
    
    //Keyed
    public virtual Resource_ValueSet Resource_ValueSet { get; set; }                     
  }

  public class Resource_VisionPrescription
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset datewritten_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string prescriber_FhirId {get; set;}     
    public string prescriber_Type {get; set;}     
    public string prescriber_Url {get; set;}     

    public ICollection<Resource_VisionPrescription_Search_identifier> identifier_List { get; set; }   

    public Resource_VisionPrescription()
    {
      this.identifier_List = new HashSet<Resource_VisionPrescription_Search_identifier>();
    }
  }
  
  public class Resource_VisionPrescription_Search_identifier
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Resource_VisionPrescription Resource_VisionPrescription { get; set; }                     
  }

}






