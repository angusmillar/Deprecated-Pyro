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
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? targetdate_DateTimeOffset {get; set;}
    public ICollection<Res_Goal_History> Res_Goal_History_List { get; set; }
    public ICollection<Res_Goal_Index_category> category_List { get; set; }
    public ICollection<Res_Goal_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Goal_Index_profile> profile_List { get; set; }
    public ICollection<Res_Goal_Index_security> security_List { get; set; }
    public ICollection<Res_Goal_Index_tag> tag_List { get; set; }
   
    public Res_Goal()
    {
      this.category_List = new HashSet<Res_Goal_Index_category>();
      this.identifier_List = new HashSet<Res_Goal_Index_identifier>();
      this.profile_List = new HashSet<Res_Goal_Index_profile>();
      this.security_List = new HashSet<Res_Goal_Index_security>();
      this.tag_List = new HashSet<Res_Goal_Index_tag>();
      this.Res_Goal_History_List = new HashSet<Res_Goal_History>();
    }
  }
}

