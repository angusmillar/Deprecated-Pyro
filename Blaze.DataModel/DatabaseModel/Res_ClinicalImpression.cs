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
    public string assessor_FhirId {get; set;}
    public string assessor_Type {get; set;}
    public virtual Blaze_RootUrlStore assessor_Url { get; set; }
    public int? assessor_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string previous_FhirId {get; set;}
    public string previous_Type {get; set;}
    public virtual Blaze_RootUrlStore previous_Url { get; set; }
    public int? previous_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string trigger_FhirId {get; set;}
    public string trigger_Type {get; set;}
    public virtual Blaze_RootUrlStore trigger_Url { get; set; }
    public int? trigger_Url_Blaze_RootUrlStoreID { get; set; }
    public string trigger_code_Code {get; set;}
    public string trigger_code_System {get; set;}
    public ICollection<Res_ClinicalImpression_History> Res_ClinicalImpression_History_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_action> action_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_finding> finding_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_investigation> investigation_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_plan> plan_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_problem> problem_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_resolved> resolved_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_ruledout> ruledout_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_profile> profile_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_security> security_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_tag> tag_List { get; set; }
   
    public Res_ClinicalImpression()
    {
      this.action_List = new HashSet<Res_ClinicalImpression_Index_action>();
      this.finding_List = new HashSet<Res_ClinicalImpression_Index_finding>();
      this.investigation_List = new HashSet<Res_ClinicalImpression_Index_investigation>();
      this.plan_List = new HashSet<Res_ClinicalImpression_Index_plan>();
      this.problem_List = new HashSet<Res_ClinicalImpression_Index_problem>();
      this.resolved_List = new HashSet<Res_ClinicalImpression_Index_resolved>();
      this.ruledout_List = new HashSet<Res_ClinicalImpression_Index_ruledout>();
      this.profile_List = new HashSet<Res_ClinicalImpression_Index_profile>();
      this.security_List = new HashSet<Res_ClinicalImpression_Index_security>();
      this.tag_List = new HashSet<Res_ClinicalImpression_Index_tag>();
      this.Res_ClinicalImpression_History_List = new HashSet<Res_ClinicalImpression_History>();
    }
  }
}

