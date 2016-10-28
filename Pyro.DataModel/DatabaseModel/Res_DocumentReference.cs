using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DocumentReference : ResourceIndexBase
  {
    public int Res_DocumentReferenceID {get; set;}
    public string authenticator_VersionId {get; set;}
    public string authenticator_FhirId {get; set;}
    public string authenticator_Type {get; set;}
    public virtual ServiceRootURL_Store authenticator_Url { get; set; }
    public int? authenticator_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string custodian_VersionId {get; set;}
    public string custodian_FhirId {get; set;}
    public string custodian_Type {get; set;}
    public virtual ServiceRootURL_Store custodian_Url { get; set; }
    public int? custodian_ServiceRootURL_StoreID { get; set; }
    public string description_String {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public DateTimeOffset? indexed_DateTimeOffset {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? period_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? period_DateTimeOffsetHigh {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DocumentReference_History> Res_DocumentReference_History_List { get; set; }
    public ICollection<Res_DocumentReference_Index_author> author_List { get; set; }
    public ICollection<Res_DocumentReference_Index_class> class_List { get; set; }
    public ICollection<Res_DocumentReference_Index_event> event_List { get; set; }
    public ICollection<Res_DocumentReference_Index_facility> facility_List { get; set; }
    public ICollection<Res_DocumentReference_Index_format> format_List { get; set; }
    public ICollection<Res_DocumentReference_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_DocumentReference_Index_language> language_List { get; set; }
    public ICollection<Res_DocumentReference_Index_location> location_List { get; set; }
    public ICollection<Res_DocumentReference_Index_related_id> related_id_List { get; set; }
    public ICollection<Res_DocumentReference_Index_related_ref> related_ref_List { get; set; }
    public ICollection<Res_DocumentReference_Index_relatesto> relatesto_List { get; set; }
    public ICollection<Res_DocumentReference_Index_relation> relation_List { get; set; }
    public ICollection<Res_DocumentReference_Index_securitylabel> securitylabel_List { get; set; }
    public ICollection<Res_DocumentReference_Index_setting> setting_List { get; set; }
    public ICollection<Res_DocumentReference_Index_type> type_List { get; set; }
    public ICollection<Res_DocumentReference_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DocumentReference_Index__security> _security_List { get; set; }
    public ICollection<Res_DocumentReference_Index__tag> _tag_List { get; set; }
   
    public Res_DocumentReference()
    {
      this.author_List = new HashSet<Res_DocumentReference_Index_author>();
      this.class_List = new HashSet<Res_DocumentReference_Index_class>();
      this.event_List = new HashSet<Res_DocumentReference_Index_event>();
      this.facility_List = new HashSet<Res_DocumentReference_Index_facility>();
      this.format_List = new HashSet<Res_DocumentReference_Index_format>();
      this.identifier_List = new HashSet<Res_DocumentReference_Index_identifier>();
      this.language_List = new HashSet<Res_DocumentReference_Index_language>();
      this.location_List = new HashSet<Res_DocumentReference_Index_location>();
      this.related_id_List = new HashSet<Res_DocumentReference_Index_related_id>();
      this.related_ref_List = new HashSet<Res_DocumentReference_Index_related_ref>();
      this.relatesto_List = new HashSet<Res_DocumentReference_Index_relatesto>();
      this.relation_List = new HashSet<Res_DocumentReference_Index_relation>();
      this.securitylabel_List = new HashSet<Res_DocumentReference_Index_securitylabel>();
      this.setting_List = new HashSet<Res_DocumentReference_Index_setting>();
      this.type_List = new HashSet<Res_DocumentReference_Index_type>();
      this._profile_List = new HashSet<Res_DocumentReference_Index__profile>();
      this._security_List = new HashSet<Res_DocumentReference_Index__security>();
      this._tag_List = new HashSet<Res_DocumentReference_Index__tag>();
      this.Res_DocumentReference_History_List = new HashSet<Res_DocumentReference_History>();
    }
  }
}

