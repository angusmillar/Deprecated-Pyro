using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_AuditEvent : ResourceIndexBase
  {
    public int Res_AuditEventID {get; set;}
    public string action_Code {get; set;}
    public string action_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string site_Code {get; set;}
    public string site_System {get; set;}
    public string source_Code {get; set;}
    public string source_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_AuditEvent_History> Res_AuditEvent_History_List { get; set; }
    public ICollection<Res_AuditEvent_Index_address> address_List { get; set; }
    public ICollection<Res_AuditEvent_Index_agent> agent_List { get; set; }
    public ICollection<Res_AuditEvent_Index_agent_name> agent_name_List { get; set; }
    public ICollection<Res_AuditEvent_Index_altid> altid_List { get; set; }
    public ICollection<Res_AuditEvent_Index_entity> entity_List { get; set; }
    public ICollection<Res_AuditEvent_Index_entity_id> entity_id_List { get; set; }
    public ICollection<Res_AuditEvent_Index_entity_name> entity_name_List { get; set; }
    public ICollection<Res_AuditEvent_Index_entity_type> entity_type_List { get; set; }
    public ICollection<Res_AuditEvent_Index_patient> patient_List { get; set; }
    public ICollection<Res_AuditEvent_Index_policy> policy_List { get; set; }
    public ICollection<Res_AuditEvent_Index_subtype> subtype_List { get; set; }
    public ICollection<Res_AuditEvent_Index_user> user_List { get; set; }
    public ICollection<Res_AuditEvent_Index_profile> profile_List { get; set; }
    public ICollection<Res_AuditEvent_Index_security> security_List { get; set; }
    public ICollection<Res_AuditEvent_Index_tag> tag_List { get; set; }
   
    public Res_AuditEvent()
    {
      this.address_List = new HashSet<Res_AuditEvent_Index_address>();
      this.agent_List = new HashSet<Res_AuditEvent_Index_agent>();
      this.agent_name_List = new HashSet<Res_AuditEvent_Index_agent_name>();
      this.altid_List = new HashSet<Res_AuditEvent_Index_altid>();
      this.entity_List = new HashSet<Res_AuditEvent_Index_entity>();
      this.entity_id_List = new HashSet<Res_AuditEvent_Index_entity_id>();
      this.entity_name_List = new HashSet<Res_AuditEvent_Index_entity_name>();
      this.entity_type_List = new HashSet<Res_AuditEvent_Index_entity_type>();
      this.patient_List = new HashSet<Res_AuditEvent_Index_patient>();
      this.policy_List = new HashSet<Res_AuditEvent_Index_policy>();
      this.subtype_List = new HashSet<Res_AuditEvent_Index_subtype>();
      this.user_List = new HashSet<Res_AuditEvent_Index_user>();
      this.profile_List = new HashSet<Res_AuditEvent_Index_profile>();
      this.security_List = new HashSet<Res_AuditEvent_Index_security>();
      this.tag_List = new HashSet<Res_AuditEvent_Index_tag>();
      this.Res_AuditEvent_History_List = new HashSet<Res_AuditEvent_History>();
    }
  }
}

