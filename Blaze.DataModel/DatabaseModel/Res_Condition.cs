using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Condition : ResourceIndexBase
  {
    public int Res_ConditionID {get; set;}
    public string asserter_FhirId {get; set;}
    public string asserter_Type {get; set;}
    public virtual Blaze_RootUrlStore asserter_Url { get; set; }
    public int? asserter_Url_Blaze_RootUrlStoreID { get; set; }
    public string clinicalstatus_Code {get; set;}
    public string clinicalstatus_System {get; set;}
    public DateTimeOffset? date_recorded_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? onset_DateTimeOffset {get; set;}
    public string onset_info_String {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Condition_History> Res_Condition_History_List { get; set; }
    public ICollection<Res_Condition_Index_body_site> body_site_List { get; set; }
    public ICollection<Res_Condition_Index_category> category_List { get; set; }
    public ICollection<Res_Condition_Index_code> code_List { get; set; }
    public ICollection<Res_Condition_Index_evidence> evidence_List { get; set; }
    public ICollection<Res_Condition_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Condition_Index_severity> severity_List { get; set; }
    public ICollection<Res_Condition_Index_stage> stage_List { get; set; }
    public ICollection<Res_Condition_Index_profile> profile_List { get; set; }
    public ICollection<Res_Condition_Index_security> security_List { get; set; }
    public ICollection<Res_Condition_Index_tag> tag_List { get; set; }
   
    public Res_Condition()
    {
      this.body_site_List = new HashSet<Res_Condition_Index_body_site>();
      this.category_List = new HashSet<Res_Condition_Index_category>();
      this.code_List = new HashSet<Res_Condition_Index_code>();
      this.evidence_List = new HashSet<Res_Condition_Index_evidence>();
      this.identifier_List = new HashSet<Res_Condition_Index_identifier>();
      this.severity_List = new HashSet<Res_Condition_Index_severity>();
      this.stage_List = new HashSet<Res_Condition_Index_stage>();
      this.profile_List = new HashSet<Res_Condition_Index_profile>();
      this.security_List = new HashSet<Res_Condition_Index_security>();
      this.tag_List = new HashSet<Res_Condition_Index_tag>();
      this.Res_Condition_History_List = new HashSet<Res_Condition_History>();
    }
  }
}

