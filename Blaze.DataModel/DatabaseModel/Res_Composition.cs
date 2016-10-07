using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Composition : ResourceIndexBase
  {
    public int Res_CompositionID {get; set;}
    public string confidentiality_Code {get; set;}
    public string confidentiality_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
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
    public string title_String {get; set;}
    public ICollection<Res_Composition_History> Res_Composition_History_List { get; set; }
    public ICollection<Res_Composition_Index_attester> attester_List { get; set; }
    public ICollection<Res_Composition_Index_author> author_List { get; set; }
    public ICollection<Res_Composition_Index_class> class_List { get; set; }
    public ICollection<Res_Composition_Index_context> context_List { get; set; }
    public ICollection<Res_Composition_Index_entry> entry_List { get; set; }
    public ICollection<Res_Composition_Index_period> period_List { get; set; }
    public ICollection<Res_Composition_Index_section> section_List { get; set; }
    public ICollection<Res_Composition_Index_type> type_List { get; set; }
    public ICollection<Res_Composition_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Composition_Index__security> _security_List { get; set; }
    public ICollection<Res_Composition_Index__tag> _tag_List { get; set; }
   
    public Res_Composition()
    {
      this.attester_List = new HashSet<Res_Composition_Index_attester>();
      this.author_List = new HashSet<Res_Composition_Index_author>();
      this.class_List = new HashSet<Res_Composition_Index_class>();
      this.context_List = new HashSet<Res_Composition_Index_context>();
      this.entry_List = new HashSet<Res_Composition_Index_entry>();
      this.period_List = new HashSet<Res_Composition_Index_period>();
      this.section_List = new HashSet<Res_Composition_Index_section>();
      this.type_List = new HashSet<Res_Composition_Index_type>();
      this._profile_List = new HashSet<Res_Composition_Index__profile>();
      this._security_List = new HashSet<Res_Composition_Index__security>();
      this._tag_List = new HashSet<Res_Composition_Index__tag>();
      this.Res_Composition_History_List = new HashSet<Res_Composition_History>();
    }
  }
}

