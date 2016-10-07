using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImagingObjectSelection : ResourceIndexBase
  {
    public int Res_ImagingObjectSelectionID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? authoring_time_DateTimeOffset {get; set;}
    public string identifier_Uri {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_ImagingObjectSelection_History> Res_ImagingObjectSelection_History_List { get; set; }
    public ICollection<Res_ImagingObjectSelection_Index_selected_study> selected_study_List { get; set; }
    public ICollection<Res_ImagingObjectSelection_Index_title> title_List { get; set; }
    public ICollection<Res_ImagingObjectSelection_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ImagingObjectSelection_Index__security> _security_List { get; set; }
    public ICollection<Res_ImagingObjectSelection_Index__tag> _tag_List { get; set; }
   
    public Res_ImagingObjectSelection()
    {
      this.selected_study_List = new HashSet<Res_ImagingObjectSelection_Index_selected_study>();
      this.title_List = new HashSet<Res_ImagingObjectSelection_Index_title>();
      this._profile_List = new HashSet<Res_ImagingObjectSelection_Index__profile>();
      this._security_List = new HashSet<Res_ImagingObjectSelection_Index__security>();
      this._tag_List = new HashSet<Res_ImagingObjectSelection_Index__tag>();
      this.Res_ImagingObjectSelection_History_List = new HashSet<Res_ImagingObjectSelection_History>();
    }
  }
}

