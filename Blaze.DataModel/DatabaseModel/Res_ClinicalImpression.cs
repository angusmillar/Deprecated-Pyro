using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ClinicalImpression : ResourceIndexBase
  {
    public int Res_ClinicalImpressionID {get; set;}
    public string assessor_VersionId {get; set;}
    public string assessor_FhirId {get; set;}
    public string assessor_Type {get; set;}
    public virtual ServiceRootURL_Store assessor_Url { get; set; }
    public int? assessor_ServiceRootURL_StoreID { get; set; }
    public string context_VersionId {get; set;}
    public string context_FhirId {get; set;}
    public string context_Type {get; set;}
    public virtual ServiceRootURL_Store context_Url { get; set; }
    public int? context_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string previous_VersionId {get; set;}
    public string previous_FhirId {get; set;}
    public string previous_Type {get; set;}
    public virtual ServiceRootURL_Store previous_Url { get; set; }
    public int? previous_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_ClinicalImpression_History> Res_ClinicalImpression_History_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_action> action_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_finding_code> finding_code_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_finding_ref> finding_ref_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_investigation> investigation_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_plan> plan_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_problem> problem_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index__security> _security_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index__tag> _tag_List { get; set; }
   
    public Res_ClinicalImpression()
    {
      this.action_List = new HashSet<Res_ClinicalImpression_Index_action>();
      this.finding_code_List = new HashSet<Res_ClinicalImpression_Index_finding_code>();
      this.finding_ref_List = new HashSet<Res_ClinicalImpression_Index_finding_ref>();
      this.investigation_List = new HashSet<Res_ClinicalImpression_Index_investigation>();
      this.plan_List = new HashSet<Res_ClinicalImpression_Index_plan>();
      this.problem_List = new HashSet<Res_ClinicalImpression_Index_problem>();
      this._profile_List = new HashSet<Res_ClinicalImpression_Index__profile>();
      this._security_List = new HashSet<Res_ClinicalImpression_Index__security>();
      this._tag_List = new HashSet<Res_ClinicalImpression_Index__tag>();
      this.Res_ClinicalImpression_History_List = new HashSet<Res_ClinicalImpression_History>();
    }
  }
}

