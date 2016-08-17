using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImagingStudy : ResourceIndexBase
  {
    public int Res_ImagingStudyID {get; set;}
    public string accession_Code {get; set;}
    public string accession_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? started_DateTimeOffset {get; set;}
    public string study_Uri {get; set;}
    public ICollection<Res_ImagingStudy_History> Res_ImagingStudy_History_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_bodysite> bodysite_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_dicom_class> dicom_class_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_modality> modality_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_order> order_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_series> series_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_uid> uid_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_profile> profile_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_security> security_List { get; set; }
    public ICollection<Res_ImagingStudy_Index_tag> tag_List { get; set; }
   
    public Res_ImagingStudy()
    {
      this.bodysite_List = new HashSet<Res_ImagingStudy_Index_bodysite>();
      this.dicom_class_List = new HashSet<Res_ImagingStudy_Index_dicom_class>();
      this.identifier_List = new HashSet<Res_ImagingStudy_Index_identifier>();
      this.modality_List = new HashSet<Res_ImagingStudy_Index_modality>();
      this.order_List = new HashSet<Res_ImagingStudy_Index_order>();
      this.series_List = new HashSet<Res_ImagingStudy_Index_series>();
      this.uid_List = new HashSet<Res_ImagingStudy_Index_uid>();
      this.profile_List = new HashSet<Res_ImagingStudy_Index_profile>();
      this.security_List = new HashSet<Res_ImagingStudy_Index_security>();
      this.tag_List = new HashSet<Res_ImagingStudy_Index_tag>();
      this.Res_ImagingStudy_History_List = new HashSet<Res_ImagingStudy_History>();
    }
  }
}

