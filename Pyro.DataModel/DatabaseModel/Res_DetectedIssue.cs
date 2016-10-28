using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DetectedIssue : ResourceIndexBase
  {
    public int Res_DetectedIssueID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DetectedIssue_History> Res_DetectedIssue_History_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_category> category_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_implicated> implicated_List { get; set; }
    public ICollection<Res_DetectedIssue_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DetectedIssue_Index__security> _security_List { get; set; }
    public ICollection<Res_DetectedIssue_Index__tag> _tag_List { get; set; }
   
    public Res_DetectedIssue()
    {
      this.category_List = new HashSet<Res_DetectedIssue_Index_category>();
      this.implicated_List = new HashSet<Res_DetectedIssue_Index_implicated>();
      this._profile_List = new HashSet<Res_DetectedIssue_Index__profile>();
      this._security_List = new HashSet<Res_DetectedIssue_Index__security>();
      this._tag_List = new HashSet<Res_DetectedIssue_Index__tag>();
      this.Res_DetectedIssue_History_List = new HashSet<Res_DetectedIssue_History>();
    }
  }
}

