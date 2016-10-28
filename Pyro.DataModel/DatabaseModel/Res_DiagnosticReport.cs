using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DiagnosticReport : ResourceIndexBase
  {
    public int Res_DiagnosticReportID {get; set;}
    public DateTimeOffset? date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? date_DateTimeOffsetHigh {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? issued_DateTimeOffset {get; set;}
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
    public ICollection<Res_DiagnosticReport_History> Res_DiagnosticReport_History_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_category> category_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_code> code_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_diagnosis> diagnosis_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_image> image_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_performer> performer_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_request> request_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_result> result_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index_specimen> specimen_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index__security> _security_List { get; set; }
    public ICollection<Res_DiagnosticReport_Index__tag> _tag_List { get; set; }
   
    public Res_DiagnosticReport()
    {
      this.category_List = new HashSet<Res_DiagnosticReport_Index_category>();
      this.code_List = new HashSet<Res_DiagnosticReport_Index_code>();
      this.diagnosis_List = new HashSet<Res_DiagnosticReport_Index_diagnosis>();
      this.identifier_List = new HashSet<Res_DiagnosticReport_Index_identifier>();
      this.image_List = new HashSet<Res_DiagnosticReport_Index_image>();
      this.performer_List = new HashSet<Res_DiagnosticReport_Index_performer>();
      this.request_List = new HashSet<Res_DiagnosticReport_Index_request>();
      this.result_List = new HashSet<Res_DiagnosticReport_Index_result>();
      this.specimen_List = new HashSet<Res_DiagnosticReport_Index_specimen>();
      this._profile_List = new HashSet<Res_DiagnosticReport_Index__profile>();
      this._security_List = new HashSet<Res_DiagnosticReport_Index__security>();
      this._tag_List = new HashSet<Res_DiagnosticReport_Index__tag>();
      this.Res_DiagnosticReport_History_List = new HashSet<Res_DiagnosticReport_History>();
    }
  }
}

