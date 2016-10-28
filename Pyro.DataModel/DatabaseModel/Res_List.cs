using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_List : ResourceIndexBase
  {
    public int Res_ListID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public string title_String {get; set;}
    public ICollection<Res_List_History> Res_List_History_List { get; set; }
    public ICollection<Res_List_Index_code> code_List { get; set; }
    public ICollection<Res_List_Index_empty_reason> empty_reason_List { get; set; }
    public ICollection<Res_List_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_List_Index_item> item_List { get; set; }
    public ICollection<Res_List_Index_notes> notes_List { get; set; }
    public ICollection<Res_List_Index__profile> _profile_List { get; set; }
    public ICollection<Res_List_Index__security> _security_List { get; set; }
    public ICollection<Res_List_Index__tag> _tag_List { get; set; }
   
    public Res_List()
    {
      this.code_List = new HashSet<Res_List_Index_code>();
      this.empty_reason_List = new HashSet<Res_List_Index_empty_reason>();
      this.identifier_List = new HashSet<Res_List_Index_identifier>();
      this.item_List = new HashSet<Res_List_Index_item>();
      this.notes_List = new HashSet<Res_List_Index_notes>();
      this._profile_List = new HashSet<Res_List_Index__profile>();
      this._security_List = new HashSet<Res_List_Index__security>();
      this._tag_List = new HashSet<Res_List_Index__tag>();
      this.Res_List_History_List = new HashSet<Res_List_History>();
    }
  }
}

