using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Goal : ResourceIndexBase
  {
    public int Res_GoalID {get; set;}
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
    public int? targetdate_Date {get; set;}
    public ICollection<Res_Goal_History> Res_Goal_History_List { get; set; }
    public ICollection<Res_Goal_Index_category> category_List { get; set; }
    public ICollection<Res_Goal_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Goal_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Goal_Index__security> _security_List { get; set; }
    public ICollection<Res_Goal_Index__tag> _tag_List { get; set; }
   
    public Res_Goal()
    {
      this.category_List = new HashSet<Res_Goal_Index_category>();
      this.identifier_List = new HashSet<Res_Goal_Index_identifier>();
      this._profile_List = new HashSet<Res_Goal_Index__profile>();
      this._security_List = new HashSet<Res_Goal_Index__security>();
      this._tag_List = new HashSet<Res_Goal_Index__tag>();
      this.Res_Goal_History_List = new HashSet<Res_Goal_History>();
    }
  }
}

