using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DetectedIssue : ResourceIndexBase
  {
    public int Res_DetectedIssueID {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DetectedIssue_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_DetectedIssue_History> Res_DetectedIssue_History_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_category> category_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_implicated> implicated_List { get; set; }
   
    public Res_DetectedIssue()
    {
      this.category_List = new HashSet<Res_DetectedIssue_Index_category>();
      this.implicated_List = new HashSet<Res_DetectedIssue_Index_implicated>();
      this.meta_tag_List = new HashSet<Res_DetectedIssue_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_DetectedIssue_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_DetectedIssue_Index_meta_profile>();
      this.Res_DetectedIssue_History_List = new HashSet<Res_DetectedIssue_History>();
    }
  }
}

