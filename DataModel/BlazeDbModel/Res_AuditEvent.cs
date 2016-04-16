using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_AuditEvent
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string action_Code {get; set;}                  
    public string action_System {get; set;}                
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string site_Code {get; set;}                  
    public string site_System {get; set;}                
    public string source_Code {get; set;}                  
    public string source_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                

    public ICollection<Res_AuditEvent_Index_address> address_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_altid> altid_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_desc> desc_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_identity> identity_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_name> name_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_object_type> object_type_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_participant> participant_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_patient> patient_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_policy> policy_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_reference> reference_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_subtype> subtype_List { get; set; }   
    public ICollection<Res_AuditEvent_Index_user> user_List { get; set; }   

    public Res_AuditEvent()
    {
      this.address_List = new HashSet<Res_AuditEvent_Index_address>();
      this.altid_List = new HashSet<Res_AuditEvent_Index_altid>();
      this.desc_List = new HashSet<Res_AuditEvent_Index_desc>();
      this.identity_List = new HashSet<Res_AuditEvent_Index_identity>();
      this.name_List = new HashSet<Res_AuditEvent_Index_name>();
      this.object_type_List = new HashSet<Res_AuditEvent_Index_object_type>();
      this.participant_List = new HashSet<Res_AuditEvent_Index_participant>();
      this.patient_List = new HashSet<Res_AuditEvent_Index_patient>();
      this.policy_List = new HashSet<Res_AuditEvent_Index_policy>();
      this.reference_List = new HashSet<Res_AuditEvent_Index_reference>();
      this.subtype_List = new HashSet<Res_AuditEvent_Index_subtype>();
      this.user_List = new HashSet<Res_AuditEvent_Index_user>();
    }
  }
}