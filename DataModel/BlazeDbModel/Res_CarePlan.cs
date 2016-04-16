using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_CarePlan
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_CarePlan_Index_activitycode> activitycode_List { get; set; }   
    public ICollection<Res_CarePlan_Index_activitydate> activitydate_List { get; set; }   
    public ICollection<Res_CarePlan_Index_activityreference> activityreference_List { get; set; }   
    public ICollection<Res_CarePlan_Index_condition> condition_List { get; set; }   
    public ICollection<Res_CarePlan_Index_goal> goal_List { get; set; }   
    public ICollection<Res_CarePlan_Index_participant> participant_List { get; set; }   
    public ICollection<Res_CarePlan_Index_performer> performer_List { get; set; }   
    public ICollection<Res_CarePlan_Index_relatedcode> relatedcode_List { get; set; }   
    public ICollection<Res_CarePlan_Index_relatedplan> relatedplan_List { get; set; }   

    public Res_CarePlan()
    {
      this.activitycode_List = new HashSet<Res_CarePlan_Index_activitycode>();
      this.activitydate_List = new HashSet<Res_CarePlan_Index_activitydate>();
      this.activityreference_List = new HashSet<Res_CarePlan_Index_activityreference>();
      this.condition_List = new HashSet<Res_CarePlan_Index_condition>();
      this.goal_List = new HashSet<Res_CarePlan_Index_goal>();
      this.participant_List = new HashSet<Res_CarePlan_Index_participant>();
      this.performer_List = new HashSet<Res_CarePlan_Index_performer>();
      this.relatedcode_List = new HashSet<Res_CarePlan_Index_relatedcode>();
      this.relatedplan_List = new HashSet<Res_CarePlan_Index_relatedplan>();
    }
  }
}