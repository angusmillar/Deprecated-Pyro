using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImagingExcerpt : ResourceIndexBase
  {
    public int Res_ImagingExcerptID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? authoring_time_DateTimeOffset {get; set;}
    public string identifier_Uri {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ImagingExcerpt_History> Res_ImagingExcerpt_History_List { get; set; }
    public ICollection<Res_ImagingExcerpt_Index_selected_study> selected_study_List { get; set; }
    public ICollection<Res_ImagingExcerpt_Index_title> title_List { get; set; }
    public ICollection<Res_ImagingExcerpt_Index_profile> profile_List { get; set; }
    public ICollection<Res_ImagingExcerpt_Index_security> security_List { get; set; }
    public ICollection<Res_ImagingExcerpt_Index_tag> tag_List { get; set; }
   
    public Res_ImagingExcerpt()
    {
      this.selected_study_List = new HashSet<Res_ImagingExcerpt_Index_selected_study>();
      this.title_List = new HashSet<Res_ImagingExcerpt_Index_title>();
      this.profile_List = new HashSet<Res_ImagingExcerpt_Index_profile>();
      this.security_List = new HashSet<Res_ImagingExcerpt_Index_security>();
      this.tag_List = new HashSet<Res_ImagingExcerpt_Index_tag>();
      this.Res_ImagingExcerpt_History_List = new HashSet<Res_ImagingExcerpt_History>();
    }
  }
}

