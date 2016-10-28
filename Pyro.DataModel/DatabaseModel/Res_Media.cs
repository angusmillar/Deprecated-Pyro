using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Media : ResourceIndexBase
  {
    public int Res_MediaID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string operator_VersionId {get; set;}
    public string operator_FhirId {get; set;}
    public string operator_Type {get; set;}
    public virtual ServiceRootURL_Store operator_Url { get; set; }
    public int? operator_ServiceRootURL_StoreID { get; set; }
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
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Media_History> Res_Media_History_List { get; set; }
    public ICollection<Res_Media_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Media_Index_subtype> subtype_List { get; set; }
    public ICollection<Res_Media_Index_view> view_List { get; set; }
    public ICollection<Res_Media_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Media_Index__security> _security_List { get; set; }
    public ICollection<Res_Media_Index__tag> _tag_List { get; set; }
   
    public Res_Media()
    {
      this.identifier_List = new HashSet<Res_Media_Index_identifier>();
      this.subtype_List = new HashSet<Res_Media_Index_subtype>();
      this.view_List = new HashSet<Res_Media_Index_view>();
      this._profile_List = new HashSet<Res_Media_Index__profile>();
      this._security_List = new HashSet<Res_Media_Index__security>();
      this._tag_List = new HashSet<Res_Media_Index__tag>();
      this.Res_Media_History_List = new HashSet<Res_Media_History>();
    }
  }
}

