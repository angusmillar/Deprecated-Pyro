using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DiagnosticOrder : ResourceIndexBase
  {
    public int Res_DiagnosticOrderID {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string orderer_VersionId {get; set;}
    public string orderer_FhirId {get; set;}
    public string orderer_Type {get; set;}
    public virtual ServiceRootURL_Store orderer_Url { get; set; }
    public int? orderer_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DiagnosticOrder_History> Res_DiagnosticOrder_History_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_actor> actor_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_bodysite> bodysite_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_code> code_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_event_date> event_date_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_event_status> event_status_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_item_date> item_date_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_item_past_status> item_past_status_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_item_status> item_status_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index_specimen> specimen_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index__security> _security_List { get; set; }
    public ICollection<Res_DiagnosticOrder_Index__tag> _tag_List { get; set; }
   
    public Res_DiagnosticOrder()
    {
      this.actor_List = new HashSet<Res_DiagnosticOrder_Index_actor>();
      this.bodysite_List = new HashSet<Res_DiagnosticOrder_Index_bodysite>();
      this.code_List = new HashSet<Res_DiagnosticOrder_Index_code>();
      this.event_date_List = new HashSet<Res_DiagnosticOrder_Index_event_date>();
      this.event_status_List = new HashSet<Res_DiagnosticOrder_Index_event_status>();
      this.identifier_List = new HashSet<Res_DiagnosticOrder_Index_identifier>();
      this.item_date_List = new HashSet<Res_DiagnosticOrder_Index_item_date>();
      this.item_past_status_List = new HashSet<Res_DiagnosticOrder_Index_item_past_status>();
      this.item_status_List = new HashSet<Res_DiagnosticOrder_Index_item_status>();
      this.specimen_List = new HashSet<Res_DiagnosticOrder_Index_specimen>();
      this._profile_List = new HashSet<Res_DiagnosticOrder_Index__profile>();
      this._security_List = new HashSet<Res_DiagnosticOrder_Index__security>();
      this._tag_List = new HashSet<Res_DiagnosticOrder_Index__tag>();
      this.Res_DiagnosticOrder_History_List = new HashSet<Res_DiagnosticOrder_History>();
    }
  }
}

