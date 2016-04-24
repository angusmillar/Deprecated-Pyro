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
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Aux_RootUrlStore encounter_Aux_RootUrlStoreID { get; set; }
    public string notes_String {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Aux_RootUrlStore source_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public string title_String {get; set;}
    public ICollection<Res_List_Index_code> code_List { get; set; }
    public ICollection<Res_List_Index_empty_reason> empty_reason_List { get; set; }
    public ICollection<Res_List_Index_item> item_List { get; set; }
   
    public Res_List()
    {
      this.code_List = new HashSet<Res_List_Index_code>();
      this.empty_reason_List = new HashSet<Res_List_Index_empty_reason>();
      this.item_List = new HashSet<Res_List_Index_item>();
    }
  }
}

