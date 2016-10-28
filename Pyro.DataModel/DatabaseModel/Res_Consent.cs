using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Consent : ResourceIndexBase
  {
    public int Res_ConsentID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? period_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? period_DateTimeOffsetHigh {get; set;}
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Consent_History> Res_Consent_History_List { get; set; }
    public ICollection<Res_Consent_Index_action> action_List { get; set; }
    public ICollection<Res_Consent_Index_actor> actor_List { get; set; }
    public ICollection<Res_Consent_Index_category> category_List { get; set; }
    public ICollection<Res_Consent_Index_consentor> consentor_List { get; set; }
    public ICollection<Res_Consent_Index_data> data_List { get; set; }
    public ICollection<Res_Consent_Index_purpose> purpose_List { get; set; }
    public ICollection<Res_Consent_Index_recipient> recipient_List { get; set; }
    public ICollection<Res_Consent_Index_security> security_List { get; set; }
    public ICollection<Res_Consent_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Consent_Index__security> _security_List { get; set; }
    public ICollection<Res_Consent_Index__tag> _tag_List { get; set; }
   
    public Res_Consent()
    {
      this.action_List = new HashSet<Res_Consent_Index_action>();
      this.actor_List = new HashSet<Res_Consent_Index_actor>();
      this.category_List = new HashSet<Res_Consent_Index_category>();
      this.consentor_List = new HashSet<Res_Consent_Index_consentor>();
      this.data_List = new HashSet<Res_Consent_Index_data>();
      this.purpose_List = new HashSet<Res_Consent_Index_purpose>();
      this.recipient_List = new HashSet<Res_Consent_Index_recipient>();
      this.security_List = new HashSet<Res_Consent_Index_security>();
      this._profile_List = new HashSet<Res_Consent_Index__profile>();
      this._security_List = new HashSet<Res_Consent_Index__security>();
      this._tag_List = new HashSet<Res_Consent_Index__tag>();
      this.Res_Consent_History_List = new HashSet<Res_Consent_History>();
    }
  }
}

