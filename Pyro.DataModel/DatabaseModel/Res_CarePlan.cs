using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_CarePlan : ResourceIndexBase
  {
    public int Res_CarePlanID {get; set;}
    public DateTimeOffset? date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? date_DateTimeOffsetHigh {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_CarePlan_History> Res_CarePlan_History_List { get; set; }
    public ICollection<Res_CarePlan_Index_activitycode> activitycode_List { get; set; }
    public ICollection<Res_CarePlan_Index_activitydate> activitydate_List { get; set; }
    public ICollection<Res_CarePlan_Index_activityreference> activityreference_List { get; set; }
    public ICollection<Res_CarePlan_Index_careteam> careteam_List { get; set; }
    public ICollection<Res_CarePlan_Index_category> category_List { get; set; }
    public ICollection<Res_CarePlan_Index_condition> condition_List { get; set; }
    public ICollection<Res_CarePlan_Index_goal> goal_List { get; set; }
    public ICollection<Res_CarePlan_Index_performer> performer_List { get; set; }
    public ICollection<Res_CarePlan_Index_relatedcode> relatedcode_List { get; set; }
    public ICollection<Res_CarePlan_Index_relatedplan> relatedplan_List { get; set; }
    public ICollection<Res_CarePlan_Index__profile> _profile_List { get; set; }
    public ICollection<Res_CarePlan_Index__security> _security_List { get; set; }
    public ICollection<Res_CarePlan_Index__tag> _tag_List { get; set; }
   
    public Res_CarePlan()
    {
      this.activitycode_List = new HashSet<Res_CarePlan_Index_activitycode>();
      this.activitydate_List = new HashSet<Res_CarePlan_Index_activitydate>();
      this.activityreference_List = new HashSet<Res_CarePlan_Index_activityreference>();
      this.careteam_List = new HashSet<Res_CarePlan_Index_careteam>();
      this.category_List = new HashSet<Res_CarePlan_Index_category>();
      this.condition_List = new HashSet<Res_CarePlan_Index_condition>();
      this.goal_List = new HashSet<Res_CarePlan_Index_goal>();
      this.performer_List = new HashSet<Res_CarePlan_Index_performer>();
      this.relatedcode_List = new HashSet<Res_CarePlan_Index_relatedcode>();
      this.relatedplan_List = new HashSet<Res_CarePlan_Index_relatedplan>();
      this._profile_List = new HashSet<Res_CarePlan_Index__profile>();
      this._security_List = new HashSet<Res_CarePlan_Index__security>();
      this._tag_List = new HashSet<Res_CarePlan_Index__tag>();
      this.Res_CarePlan_History_List = new HashSet<Res_CarePlan_History>();
    }
  }
}

