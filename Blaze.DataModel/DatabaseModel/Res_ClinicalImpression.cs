using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ClinicalImpression
  {
    public int Res_ClinicalImpressionID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string assessor_FhirId {get; set;}
    public string assessor_Type {get; set;}
    public virtual Aux_RootUrlStore assessor_Aux_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string previous_FhirId {get; set;}
    public string previous_Type {get; set;}
    public virtual Aux_RootUrlStore previous_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string trigger_FhirId {get; set;}
    public string trigger_Type {get; set;}
    public virtual Aux_RootUrlStore trigger_Aux_RootUrlStoreID { get; set; }
    public string trigger_code_Code {get; set;}
    public string trigger_code_System {get; set;}
    public ICollection<Res_ClinicalImpression_Index_action> action_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_finding> finding_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_investigation> investigation_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_plan> plan_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_problem> problem_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_resolved> resolved_List { get; set; }
    public ICollection<Res_ClinicalImpression_Index_ruledout> ruledout_List { get; set; }
   
    public Res_ClinicalImpression()
    {
      this.action_List = new HashSet<Res_ClinicalImpression_Index_action>();
      this.finding_List = new HashSet<Res_ClinicalImpression_Index_finding>();
      this.investigation_List = new HashSet<Res_ClinicalImpression_Index_investigation>();
      this.plan_List = new HashSet<Res_ClinicalImpression_Index_plan>();
      this.problem_List = new HashSet<Res_ClinicalImpression_Index_problem>();
      this.resolved_List = new HashSet<Res_ClinicalImpression_Index_resolved>();
      this.ruledout_List = new HashSet<Res_ClinicalImpression_Index_ruledout>();
    }
  }
}

