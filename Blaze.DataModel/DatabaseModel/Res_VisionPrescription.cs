using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_VisionPrescription : ResourceIndexBase
  {
    public int Res_VisionPrescriptionID {get; set;}
    public DateTimeOffset? datewritten_DateTimeOffset {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string prescriber_VersionId {get; set;}
    public string prescriber_FhirId {get; set;}
    public string prescriber_Type {get; set;}
    public virtual Blaze_RootUrlStore prescriber_Url { get; set; }
    public int? prescriber_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_VisionPrescription_History> Res_VisionPrescription_History_List { get; set; }
    public ICollection<Res_VisionPrescription_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_VisionPrescription_Index_profile> profile_List { get; set; }
    public ICollection<Res_VisionPrescription_Index_security> security_List { get; set; }
    public ICollection<Res_VisionPrescription_Index_tag> tag_List { get; set; }
   
    public Res_VisionPrescription()
    {
      this.identifier_List = new HashSet<Res_VisionPrescription_Index_identifier>();
      this.profile_List = new HashSet<Res_VisionPrescription_Index_profile>();
      this.security_List = new HashSet<Res_VisionPrescription_Index_security>();
      this.tag_List = new HashSet<Res_VisionPrescription_Index_tag>();
      this.Res_VisionPrescription_History_List = new HashSet<Res_VisionPrescription_History>();
    }
  }
}

