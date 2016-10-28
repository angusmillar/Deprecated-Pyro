using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Task : ResourceIndexBase
  {
    public int Res_TaskID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string definition_Uri {get; set;}
    public string focus_VersionId {get; set;}
    public string focus_FhirId {get; set;}
    public string focus_Type {get; set;}
    public virtual ServiceRootURL_Store focus_Url { get; set; }
    public int? focus_ServiceRootURL_StoreID { get; set; }
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public DateTimeOffset? modified_DateTimeOffset {get; set;}
    public string owner_VersionId {get; set;}
    public string owner_FhirId {get; set;}
    public string owner_Type {get; set;}
    public virtual ServiceRootURL_Store owner_Url { get; set; }
    public int? owner_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string priority_Code {get; set;}
    public string priority_System {get; set;}
    public string requester_VersionId {get; set;}
    public string requester_FhirId {get; set;}
    public string requester_Type {get; set;}
    public virtual ServiceRootURL_Store requester_Url { get; set; }
    public int? requester_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Task_History> Res_Task_History_List { get; set; }
    public ICollection<Res_Task_Index_code> code_List { get; set; }
    public ICollection<Res_Task_Index_parent> parent_List { get; set; }
    public ICollection<Res_Task_Index_performer> performer_List { get; set; }
    public ICollection<Res_Task_Index_stage> stage_List { get; set; }
    public ICollection<Res_Task_Index_statusreason> statusreason_List { get; set; }
    public ICollection<Res_Task_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Task_Index__security> _security_List { get; set; }
    public ICollection<Res_Task_Index__tag> _tag_List { get; set; }
   
    public Res_Task()
    {
      this.code_List = new HashSet<Res_Task_Index_code>();
      this.parent_List = new HashSet<Res_Task_Index_parent>();
      this.performer_List = new HashSet<Res_Task_Index_performer>();
      this.stage_List = new HashSet<Res_Task_Index_stage>();
      this.statusreason_List = new HashSet<Res_Task_Index_statusreason>();
      this._profile_List = new HashSet<Res_Task_Index__profile>();
      this._security_List = new HashSet<Res_Task_Index__security>();
      this._tag_List = new HashSet<Res_Task_Index__tag>();
      this.Res_Task_History_List = new HashSet<Res_Task_History>();
    }
  }
}

