using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Task : ResourceIndexBase
  {
    public int Res_TaskID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string creator_FhirId {get; set;}
    public string creator_Type {get; set;}
    public virtual Blaze_RootUrlStore creator_Url { get; set; }
    public int? creator_Url_Blaze_RootUrlStoreID { get; set; }
    public string definition_Uri {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public DateTimeOffset? modified_DateTimeOffset {get; set;}
    public string owner_FhirId {get; set;}
    public string owner_Type {get; set;}
    public virtual Blaze_RootUrlStore owner_Url { get; set; }
    public int? owner_Url_Blaze_RootUrlStoreID { get; set; }
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual Blaze_RootUrlStore parent_Url { get; set; }
    public int? parent_Url_Blaze_RootUrlStoreID { get; set; }
    public string priority_Code {get; set;}
    public string priority_System {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Task_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Task_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Task_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Task_History> Res_Task_History_List { get; set; }
    public ICollection<Res_Task_Index_failure> failure_List { get; set; }
    public ICollection<Res_Task_Index_performer> performer_List { get; set; }
    public ICollection<Res_Task_Index_type> type_List { get; set; }
   
    public Res_Task()
    {
      this.failure_List = new HashSet<Res_Task_Index_failure>();
      this.performer_List = new HashSet<Res_Task_Index_performer>();
      this.type_List = new HashSet<Res_Task_Index_type>();
      this.meta_tag_List = new HashSet<Res_Task_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Task_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Task_Index_meta_profile>();
      this.Res_Task_History_List = new HashSet<Res_Task_History>();
    }
  }
}

