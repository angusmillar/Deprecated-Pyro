using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_List
  {
    public int Res_ListID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public string title_String {get; set;}
    public ICollection<Res_List_Index_code> code_List { get; set; }
    public ICollection<Res_List_Index_empty_reason> empty_reason_List { get; set; }
    public ICollection<Res_List_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_List_Index_item> item_List { get; set; }
    public ICollection<Res_List_Index_notes> notes_List { get; set; }
   
    public Res_List()
    {
      this.code_List = new HashSet<Res_List_Index_code>();
      this.empty_reason_List = new HashSet<Res_List_Index_empty_reason>();
      this.identifier_List = new HashSet<Res_List_Index_identifier>();
      this.item_List = new HashSet<Res_List_Index_item>();
      this.notes_List = new HashSet<Res_List_Index_notes>();
    }
  }
}

